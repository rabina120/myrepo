using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SI.Utility;
using SI.RequestHandling.ATT;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Globalization;
using SI.RequestHandling.DLL;

namespace Openend_SIP.Handler.RequestHandling
{
    /// <summary>
    /// Summary description for OnlinePurchaseReceipt
    /// </summary>
    public class OnlinePurchaseReceipt : BaseHandler
    {

        public object CreatePurchasePdfReceipt(string args)
        {
            JsonResponse response = new JsonResponse();
            ATTShareTransaction objatt = JsonUtility.DeSerialize(args, typeof(ATTShareTransaction)) as ATTShareTransaction;
            ServerMap sm = new ServerMap();
            string fileName = "";

            try
            {
                DLLPurchaseRequest objDll = new DLLPurchaseRequest();
                List<ATTShareTransaction> lstShareholder = new List<ATTShareTransaction>();
                lstShareholder = objDll.GetData(objatt.Scheme_code.ToString(), objatt.ccode.ToString(), int.Parse(objatt.REQUEST_NO.ToString()), "G", objatt.l_company_id.ToString());
                foreach (var objATT in lstShareholder)
                {
                    string strJson = new StreamReader(context.Request.InputStream).ReadToEnd();
                    //deserialize the object
                    string guid = Guid.NewGuid().ToString();

                    fileName = guid + ".pdf";
                    //fileName = objATT.Bo_Account_No + System.DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss")+objATT.DREQUEST_NO+"/Purchase Entry Report" + ".pdf";

                    string path = HttpContext.Current.Server.MapPath("/Reports/" + fileName);


                    System.IO.FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None);
                    Document document = new Document(PageSize.A4.Rotate(), 10, 10, 35, 150);


                    document.SetPageSize(iTextSharp.text.PageSize.A4);
                    PdfWriter writer = PdfWriter.GetInstance(document, fs);
                    // writer.PageEvent = new ITextEvents();
                    document.Open();

                    PdfPTable tableBOX = new PdfPTable(1);
                    tableBOX.WidthPercentage = 100f;
                    PdfPCell cellBox = new PdfPCell();
                    cellBox.UseVariableBorders = true;
                    cellBox.BorderColor = BaseColor.GRAY;

                    Image d = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath("/Styles/Images/headerpurchase.png"));


                    cellBox.AddElement(d);

                    BaseFont bfntHead = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);

                    //  Upload Image in PDF
                    //var logo = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath("/Styles/Images/header.png"));
                    //logo.Alignment = Element.ALIGN_CENTER;
                    //document.Add(logo);

                    iTextSharp.text.Font fntHead = new iTextSharp.text.Font(bfntHead, 16, 1, BaseColor.BLACK);
                    Paragraph prgHeadings = new Paragraph();
                    prgHeadings.Alignment = Element.ALIGN_CENTER;
                    prgHeadings.Add(new Chunk("\n", fntHead));
                    // prgHeadings.Add(new Chunk("\n",fntHead));
                    prgHeadings.Add(new Chunk("UNIT PURCHASE RECEIPT\n\n\n", fntHead));
                    //document.Add(prgHeadings);

                    //iTextSharp.text.Font fntHead3 = new iTextSharp.text.Font(bfntHead, 14, 1, BaseColor.BLACK);
                    //Paragraph prgsndHeadings = new Paragraph();
                    //prgsndHeadings.Alignment = Element.ALIGN_CENTER;
                    //prgsndHeadings.Add(new Chunk("\nUNIT PURCHASE RECEIPT\n", fntHead3));
                    //document.Add(prgsndHeadings);

                    iTextSharp.text.Font fntHead2 = new iTextSharp.text.Font(bfntHead, 12, 1, BaseColor.BLACK);
                    Paragraph prgHeading2 = new Paragraph();
                    prgHeading2.Alignment = Element.ALIGN_LEFT;
                    prgHeading2.Add(new Chunk("\nDate : " + DateTime.Now.ToString("yyyy/MM/dd").Replace('/', '-'), fntHead2));
                    prgHeading2.Add(new Chunk("\nApply Date : " + (objATT.APPLY_DT).ToString(), fntHead2));
                    // prgHeading2.Add(new Chunk("\nDistribution Center : "+  , fntHead2));
                    // document.Add(prgHeading2);


                    BaseFont btnDistributor = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1250, BaseFont.NOT_EMBEDDED);
                    BaseFont btnDistributor1 = BaseFont.CreateFont(BaseFont.TIMES_BOLD, BaseFont.CP1250, BaseFont.NOT_EMBEDDED);
                    iTextSharp.text.Font fntDistributor = new iTextSharp.text.Font(btnDistributor, 11, 2, BaseColor.RED);
                    iTextSharp.text.Font fntHeader = new iTextSharp.text.Font(btnDistributor, 10, 1, BaseColor.BLACK);
                    iTextSharp.text.Font fntBody = new iTextSharp.text.Font(btnDistributor, 10, 0, BaseColor.BLACK);

                    //new design
                    var total = Convert.ToDecimal(objATT.CashAmount);
                    var frefundamt = total - (Convert.ToDecimal(objATT.AMOUNT));
                    //var frefundamt1 = frefundamt.ToString("0.00");
                    //var frefundamt = Math.Round((frefundamt), 2);
                    string Total_Received_Amount = DecimalToWords(decimal.Parse(total.ToString()));
                    var Net_Purchase_Amount = DecimalToWords(decimal.Parse((objATT.AMOUNT).ToString()));
                    var Refund_Amount = DecimalToWords(decimal.Parse((frefundamt).ToString()));
                    //var amt = String.Format(new CultureInfo("en-IN"), "{0:C2}", (objATT.APPLY_UNIT * objATT.current_nav));
                    var amt = String.Format(new CultureInfo("en-IN"), "{0:C2}", Math.Round((objATT.APPLY_UNIT * objATT.current_nav), 2));
                    var received = String.Format(new CultureInfo("en-IN"), "{0:C2}", total);


                    PdfPTable tableDetails = new PdfPTable(7);
                    //tableDetails.HeaderRows = 1;
                    tableDetails.WidthPercentage = 100f;
                    tableDetails.DefaultCell.BorderColor = BaseColor.WHITE;
                    tableDetails.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;


                    d = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath("/Styles/customer details.png"));

                    PdfPCell cell1 = new PdfPCell();
                    //PdfPCell cell1 = new PdfPCell(new Phrase("\nCUSTOMER DETAILS\n\n", fntDistributor)) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER };
                    cell1.Colspan = 7;
                    cell1.AddElement(d);
                    //cell1.BackgroundColor = BaseColor.WHITE;
                    cell1.Border = iTextSharp.text.Rectangle.NO_BORDER;
                    tableDetails.AddCell(cell1);

                    cell1 = new PdfPCell(new Phrase(" Branch ", fntHeader)) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT };
                    // cell1.BackgroundColor = BaseColor.WHITE;
                    cell1.Border = iTextSharp.text.Rectangle.NO_BORDER;
                    //cell1.AddElement(new Chunk("\u00a0 \u00a0 Branch ", fntHeader));
                    tableDetails.AddCell(cell1);



                    PdfPCell cell2 = new PdfPCell(new Phrase(" : " + objATT.cname, fntBody)) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT };
                    cell2.Colspan = 3;
                    // cell2.BackgroundColor = BaseColor.WHITE;
                    //cell2.AddElement(new Chunk(" : \u00a0 " + objATT.cname, fntBody));
                    cell2.Border = iTextSharp.text.Rectangle.NO_BORDER;
                    tableDetails.AddCell(cell2);

                    PdfPCell cell5 = new PdfPCell(new Phrase("Total Received Amount ", fntHeader)) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT };
                    // cell5.BackgroundColor = BaseColor.WHITE;
                    cell5.Colspan = 2;
                    cell5.Border = iTextSharp.text.Rectangle.NO_BORDER;
                    // cell5.AddElement(new Chunk("SIP Start Date ", fntHeader));
                    tableDetails.AddCell(cell5);


                    cell5 = new PdfPCell(new Phrase(" : " + received, fntBody)) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT };
                    // cell5.BackgroundColor = BaseColor.WHITE;

                    cell5.BorderColor = BaseColor.WHITE;
                    //cell5.AddElement(new Chunk(": \u00a0" + Convert.ToString(objATT.Action_Date), fntBody));
                    tableDetails.AddCell(cell5);

                    PdfPCell cell3 = new PdfPCell(new Phrase(" Print Date ", fntHeader)) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT };
                    // cell3.BackgroundColor = BaseColor.WHITE;
                    //    cell3.AddElement(new Chunk("\u00a0 \u00a0 Reg. Date ", fntHeader));
                    cell3.Border = iTextSharp.text.Rectangle.NO_BORDER;
                    tableDetails.AddCell(cell3);

                    PdfPCell cell4 = new PdfPCell(new Phrase(" : " + DateTime.Now.ToString("yyyy/MM/dd").Replace('/', '-'), fntBody)) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT };
                    // cell4.BackgroundColor = BaseColor.WHITE;
                    cell4.Colspan = 3;
                    // cell4.AddElement(new Chunk(" : \u00a0 " + Convert.ToDateTime(objATT.SIP_Reg_Date).ToString("yyyy/MM/dd"), fntBody));
                    cell4.Border = iTextSharp.text.Rectangle.NO_BORDER;
                    tableDetails.AddCell(cell4);

                    cell5 = new PdfPCell(new Phrase("Total Purchase Amount ", fntHeader)) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT };
                    // cell5.BackgroundColor = BaseColor.WHITE;
                    cell5.Colspan = 2;
                    cell5.BorderColor = BaseColor.WHITE;
                    // cell5.AddElement(new Chunk("SIP Amount  ", fntHeader));
                    tableDetails.AddCell(cell5);

                    cell5 = new PdfPCell(new Phrase(" : " + String.Format(new CultureInfo("en-IN"), "{0:C2}", Convert.ToDouble(objATT.AMOUNT)), fntBody)) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT };
                    // cell5.BackgroundColor = BaseColor.WHITE;
                    //cell5.Colspan = 2;
                    cell5.BorderColor = BaseColor.WHITE;
                    //cell5.AddElement(new Chunk(": \u00a0" + String.Format(new CultureInfo("en-IN"), "{0:C2}", Convert.ToDouble(objATT.Sip_amt)), fntBody));
                    tableDetails.AddCell(cell5);

                    cell1 = new PdfPCell(new Phrase(" Apply Date", fntHeader)) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT };
                    //cell1.BackgroundColor = BaseColor.WHITE;
                    // cell1.AddElement(new Chunk("\u00a0 \u00a0 Reg. Number ", fntHeader));
                    cell1.Border = iTextSharp.text.Rectangle.NO_BORDER;
                    tableDetails.AddCell(cell1);


                    cell2 = new PdfPCell(new Phrase(" : " + objATT.APPLY_DT, fntBody)) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT };
                    cell2.Colspan = 3;
                    // cell2.BackgroundColor = BaseColor.WHITE;
                    cell2.Border = iTextSharp.text.Rectangle.NO_BORDER;
                    //cell2.AddElement(new Chunk(" : \u00a0 " + objATT.SIP_Reg_No, fntBody));
                    tableDetails.AddCell(cell2);

                    cell1 = new PdfPCell(new Phrase("Refund Amount", fntHeader)) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT };
                    // cell1.BackgroundColor = BaseColor.WHITE;
                    cell1.Colspan = 2;
                    // cell1.AddElement(new Chunk("\u00a0 \u00a0 Reg. Number ", fntHeader));
                    cell1.Border = iTextSharp.text.Rectangle.NO_BORDER;
                    tableDetails.AddCell(cell1);


                    cell2 = new PdfPCell(new Phrase(" : " + String.Format(new CultureInfo("en-IN"), "{0:C2}", Convert.ToDouble(frefundamt)), fntBody)) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT };
                    // cell2.Colspan = 3;
                    // cell2.BackgroundColor = BaseColor.WHITE;
                    cell2.Border = iTextSharp.text.Rectangle.NO_BORDER;
                    //cell2.AddElement(new Chunk(" : \u00a0 " + objATT.SIP_Reg_No, fntBody));
                    tableDetails.AddCell(cell2);


                    cell3 = new PdfPCell(new Phrase(" BOID ", fntHeader)) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT };
                    // cell3.BackgroundColor = BaseColor.WHITE;
                    //    cell3.AddElement(new Chunk("\u00a0 \u00a0 Reg. Date ", fntHeader));
                    cell3.Border = iTextSharp.text.Rectangle.NO_BORDER;
                    tableDetails.AddCell(cell3);


                    cell4 = new PdfPCell(new Phrase(" : " + objATT.Bo_Account_No, fntBody)) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT };
                    //cell4.BackgroundColor = BaseColor.WHITE;
                    cell4.Colspan = 6;
                    // cell4.AddElement(new Chunk(" : \u00a0 " + Convert.ToDateTime(objATT.SIP_Reg_Date).ToString("yyyy/MM/dd"), fntBody));
                    cell4.Border = iTextSharp.text.Rectangle.NO_BORDER;
                    tableDetails.AddCell(cell4);

                    cell3 = new PdfPCell(new Phrase(" Name ", fntHeader)) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT };
                    // cell3.BackgroundColor = BaseColor.WHITE;
                    //    cell3.AddElement(new Chunk("\u00a0 \u00a0 Reg. Date ", fntHeader));
                    cell3.Border = iTextSharp.text.Rectangle.NO_BORDER;
                    tableDetails.AddCell(cell3);


                    cell4 = new PdfPCell(new Phrase(" : " + objATT.Name, fntBody)) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT };
                    // cell4.BackgroundColor = BaseColor.WHITE;
                    cell4.Colspan = 6;
                    // cell4.AddElement(new Chunk(" : \u00a0 " + Convert.ToDateTime(objATT.SIP_Reg_Date).ToString("yyyy/MM/dd"), fntBody));
                    cell4.Border = iTextSharp.text.Rectangle.NO_BORDER;
                    tableDetails.AddCell(cell4);

                    cellBox.AddElement(tableDetails);




                    iTextSharp.text.Font fntHead2t = new iTextSharp.text.Font(bfntHead, 8, 0, BaseColor.BLACK);
                    Paragraph p = new Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(0.0F, 100.0F, BaseColor.BLACK, Element.ALIGN_LEFT, 1)));
                    //cellBox.AddElement(p);

                    btnDistributor = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1250, BaseFont.NOT_EMBEDDED);
                    btnDistributor1 = BaseFont.CreateFont(BaseFont.TIMES_BOLD, BaseFont.CP1250, BaseFont.NOT_EMBEDDED);
                    fntDistributor = new iTextSharp.text.Font(btnDistributor, 10, 2, BaseColor.BLACK);
                    //fntHeader = new iTextSharp.text.Font(btnDistributor1, 8, 1, BaseColor.BLACK);
                    //fntBody = new iTextSharp.text.Font(bfntHead, 10, 1, BaseColor.BLACK);


                    Paragraph prgHeading3 = new Paragraph();
                    cellBox.AddElement(new Paragraph(Chunk.NEWLINE));
                    prgHeading3.Add(new Chunk("\u00a0 We have purchased the undernoted units of 'NIBL Sahabhagita Fund'.", fntBody));
                    prgHeading3.Add(Chunk.NEWLINE);
                    cellBox.AddElement(prgHeading3);
                    // document.Add(prgHeading3);
                    d = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath("/Styles/transaction.png"));


                    cellBox.AddElement(d);

                    PdfPTable tableup = new PdfPTable(1);
                    tableup.WidthPercentage = 100f;
                    tableup.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                    PdfPCell cellup = new PdfPCell();
                    // cell1.BackgroundColor = BaseColor.WHITE;
                    cellup.BorderColor = BaseColor.WHITE;

                    PdfPTable table = new PdfPTable(8);
                    table.HorizontalAlignment = 1;
                    table.WidthPercentage = 100f;

                    cell1 = new PdfPCell(new Phrase("Token No.", fntHeader)) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER };
                    // cell1.BackgroundColor = BaseColor.WHITE;
                    // cell1.AddElement(new Chunk("Trans. No.", fntHeader));
                    table.AddCell(cell1);

                    //PdfPCell cell2 = new PdfPCell();
                    //cell2.BackgroundColor = BaseColor.WHITE;
                    //cell2.AddElement(new Chunk("Name", fntHeader));
                    //table.AddCell(cell2);

                    cell2 = new PdfPCell(new Phrase("Units", fntHeader)) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER };
                    //  cell2.BackgroundColor = BaseColor.WHITE;
                    //cell2.AddElement(new Chunk("Units", fntHeader));
                    table.AddCell(cell2);

                    cell3 = new PdfPCell(new Phrase("Applicable Nav", fntHeader)) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER };
                    //cell3.BackgroundColor = BaseColor.WHITE;
                    //cell3.AddElement(new Chunk("Applicable NAV", fntHeader));
                    table.AddCell(cell3);

                    cell4 = new PdfPCell(new Phrase("Amount", fntHeader)) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER };
                    //cell4.BackgroundColor = BaseColor.WHITE;
                    //cell4.AddElement(new Chunk("Amount", fntHeader));
                    table.AddCell(cell4);


                    cell5 = new PdfPCell(new Phrase("Sc Amount", fntHeader)) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER };
                    // cell5.BackgroundColor = BaseColor.WHITE;
                    //cell5.AddElement(new Chunk("SC Amount", fntHeader));
                    table.AddCell(cell5);

                    PdfPCell cell6 = new PdfPCell(new Phrase("DP Charge", fntHeader)) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER };
                    //cell6.BackgroundColor = BaseColor.WHITE;
                    //cell6.AddElement(new Chunk("DP Charge", fntHeader));
                    table.AddCell(cell6);

                    PdfPCell cell7 = new PdfPCell(new Phrase("Sebon Fee", fntHeader)) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER };
                    //cell7.BackgroundColor = BaseColor.WHITE;
                    //cell7.AddElement(new Chunk("SEBON Fee", fntHeader));
                    table.AddCell(cell7);


                    PdfPCell cell8 = new PdfPCell(new Phrase("Net Amount", fntHeader)) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER };
                    cell8.BackgroundColor = BaseColor.WHITE;
                    //cell8.AddElement(new Chunk("Net Amount", fntHeader));
                    table.AddCell(cell8);




                    //  var amt = String.Format(new CultureInfo("en-IN"), "{0:C2}", (objATT.APPLY_UNIT * objATT.current_nav));

                    //amt = String.Format(new CultureInfo("en-IN"), "{0:C2}", (objATT.APPLY_UNIT * objATT.current_nav));
                    amt = String.Format(new CultureInfo("en-IN"), "{0:C2}", Math.Round((objATT.APPLY_UNIT * objATT.current_nav), 2));


                    cell5 = new PdfPCell(new Phrase(Convert.ToString(objATT.REQUEST_NO), fntBody)) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER };
                    // cell5.BackgroundColor = BaseColor.WHITE;
                    cell5.BorderColor = BaseColor.BLACK;
                    table.AddCell(cell5);

                    cell5 = new PdfPCell(new Phrase(Convert.ToString(objATT.APPLY_UNIT), fntBody)) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER };
                    //cell5.BackgroundColor = BaseColor.WHITE;
                    cell5.BorderColor = BaseColor.BLACK;
                    table.AddCell(cell5);

                    cell5 = new PdfPCell(new Phrase(Convert.ToString(objATT.current_nav), fntBody)) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER };
                    // cell5.BackgroundColor = BaseColor.WHITE;
                    cell5.BorderColor = BaseColor.BLACK;
                    table.AddCell(cell5);

                    cell5 = new PdfPCell(new Phrase(amt, fntBody)) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT };
                    //cell5.BackgroundColor = BaseColor.WHITE;
                    cell5.BorderColor = BaseColor.BLACK;
                    table.AddCell(cell5);

                    cell5 = new PdfPCell(new Phrase(String.Format(new CultureInfo("en-IN"), "{0:C2}", Convert.ToDouble(objATT.charge_amount)), fntBody)) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT };
                    // cell5.BackgroundColor = BaseColor.WHITE;
                    cell5.BorderColor = BaseColor.BLACK;
                    table.AddCell(cell5);

                    cell5 = new PdfPCell(new Phrase(String.Format(new CultureInfo("en-IN"), "{0:C2}", Convert.ToDouble(objATT.other_charges)), fntBody)) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT };
                    //cell5.BackgroundColor = BaseColor.WHITE;
                    cell5.BorderColor = BaseColor.BLACK;
                    table.AddCell(cell5);

                    cell5 = new PdfPCell(new Phrase(String.Format(new CultureInfo("en-IN"), "{0:C2}", Convert.ToDouble(objATT.SEBON_Fee)), fntBody)) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT };
                    // cell5.BackgroundColor = BaseColor.WHITE;
                    cell5.BorderColor = BaseColor.BLACK;
                    table.AddCell(cell5);

                    cell5 = new PdfPCell(new Phrase(String.Format(new CultureInfo("en-IN"), "{0:C2}", Convert.ToDouble(objATT.AMOUNT)), fntBody)) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT };
                    //cell5.BackgroundColor = BaseColor.WHITE;
                    cell5.BorderColor = BaseColor.BLACK;
                    table.AddCell(cell5);


                    cellup.AddElement(table);
                    tableup.AddCell(cellup);
                    cellBox.AddElement(tableup);

                    cellBox.AddElement(new Paragraph(Chunk.NEWLINE));
                    cellBox.AddElement(new Paragraph(Chunk.NEWLINE));
                    d = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath("/Styles/footer.png"));


                    cellBox.AddElement(d);

                    tableBOX.AddCell(cellBox);
                    document.Add(tableBOX);

                    Image watermark = Image.GetInstance(HttpContext.Current.Server.MapPath("/Styles/transparent.png"));
                    iTextSharp.text.Image jpg1 = watermark;

                    jpg1.Alignment = iTextSharp.text.Image.UNDERLYING;
                    jpg1.SetAbsolutePosition(170, 485);

                    jpg1.ScaleAbsoluteHeight(200);
                    jpg1.ScaleAbsoluteWidth(250);
                    document.Add(jpg1);

                    document.Close();
                    //writer.Close();
                    fs.Close();


                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            response.ResponseData = fileName;
            return JsonUtility.Serialize(response);


        }
        public string DecimalToWords(decimal d)
        {
            //Grab a string form of your decimal value ("12.34")
            var formatted = d.ToString();

            if (formatted.Contains("."))
            {
                //If it contains a decimal point, split it into both sides of the decimal
                string[] sides = formatted.Split('.');
                int rs = Int32.Parse(sides[0]);
                int paisa = Int32.Parse((sides[1] + "00").Substring(0, 2));

                //Process each side and append them with "and", "dot" or "point" etc.
                string NumberInWords = NumberToWords(rs) + " and " + NumberToWords(paisa) + " Paisa";
                return NumberInWords;
            }
            else
            {
                //Else process as normal
                return NumberToWords(Convert.ToInt32(d));
            }
        }
        public static string NumberToWords(int number)
        {
            if (number == 0)
                return "zero";

            if (number < 0)
                return "minus " + NumberToWords(Math.Abs(number));

            string words = "";
            if ((number / 10000000) > 0)
            {
                words += NumberToWords(number / 10000000) + " Crore ";
                number %= 10000000;
            }
            if ((number / 100000) > 0)
            {
                words += NumberToWords(number / 100000) + " Lakh ";
                number %= 100000;
            }

            if ((number / 1000) > 0)
            {
                words += NumberToWords(number / 1000) + " Thousand ";
                number %= 1000;
            }

            if ((number / 100) > 0)
            {
                words += NumberToWords(number / 100) + " Hundred ";
                number %= 100;
            }

            if (number > 0)
            {
                if (words != "")
                    words += "";

                var unitsMap = new[] { "zero", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen" };
                var tensMap = new[] { "zero", "Ten", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };

                if (number < 20)
                    words += unitsMap[number];
                else
                {
                    words += tensMap[number / 10];
                    if ((number % 10) > 0)
                        words += "-" + unitsMap[number % 10];
                }
            }

            return words;
        }
        public object DeleteFile(string file, string Action)
        {
            JsonResponse response = new JsonResponse();
            string path = "";
            if (Action == "R")
            {
                path = HttpContext.Current.Server.MapPath("/Reports/" + file);
            }
            else if (Action == "U")
            {
                path = HttpContext.Current.Server.MapPath("/Uploads/" + file);
            }


            File.Delete(Path.Combine(path));
            response.IsSucess = true;
            return JsonUtility.Serialize(response);
        }
    }
}