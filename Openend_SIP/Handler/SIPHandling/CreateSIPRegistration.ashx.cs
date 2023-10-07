using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SI.Utility;
using SI.SIPHandling.ATT;
using System.IO;
using iTextSharp.text.pdf.draw;
using DocumentFormat.OpenXml.Office2010.CustomUI;
using System.Globalization;
using DocumentFormat.OpenXml.Drawing.Wordprocessing;
using iTextSharp.text;
using iTextSharp.text.pdf;
using SI.SIPHandling.DLL;

namespace Openend_SIP.Handler.SIPHandling
{
    /// <summary>
    /// Summary description for CreateSIPRegistration
    /// </summary>
    public class CreateSIPRegistration : BaseHandler
    {

        public object CreateRegistrationPdf(string args)
        {
            ValidateToken("A", null);
            JsonResponse response = new JsonResponse();
            ATTSIP_Registration objatt = JsonUtility.DeSerialize(args, typeof(ATTSIP_Registration)) as ATTSIP_Registration;
            ServerMap sm = new ServerMap();
            string fileName = "";
           
            try
            {
                DLLSIP_Registration objDll = new DLLSIP_Registration();
                List<ATTSIP_Registration> lstSip = new List<ATTSIP_Registration>();
                lstSip = objDll.GetSIPHolderDetail(objatt.scheme_code, objatt.ccode, objatt.SIP_Reg_No, "U", objatt.l_company_id);
                foreach (var objATT in lstSip)
                {
                string strJson = new StreamReader(context.Request.InputStream).ReadToEnd();
                //deserialize the object
                string guid = Guid.NewGuid().ToString();

                //fileName = "/SIP Registraion Report -" + System.DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + ".pdf";
                fileName =  guid + ".pdf";
                string path = HttpContext.Current.Server.MapPath("/Reports/Registration/" + fileName);


                System.IO.FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None);
                Document document = new Document(PageSize.A4.Rotate(), 10, 10, 31, 0);


                document.SetPageSize(iTextSharp.text.PageSize.A4);
                PdfWriter writer = PdfWriter.GetInstance(document, fs);


                //writer.PageEvent = new ItextForWaterMark();
                document.Open();



                Image watermark = Image.GetInstance(HttpContext.Current.Server.MapPath("/Styles/transparent.png"));
                iTextSharp.text.Image jpg1 = watermark;

                jpg1.Alignment = iTextSharp.text.Image.UNDERLYING;
                jpg1.SetAbsolutePosition(170, 512);

                jpg1.ScaleAbsoluteHeight(200);
                jpg1.ScaleAbsoluteWidth(250);
                document.Add(jpg1);


                //document.NewPage();


                Paragraph ph = new Paragraph();

                PdfPTable tableBOX = new PdfPTable(1);
                tableBOX.WidthPercentage = 100f;

                // Watermark watermark = new Watermark(Image.getInstance("watermark.jpg"), 200, 420);

                PdfPCell cellBox = new PdfPCell();
                cellBox.UseVariableBorders = true;
                cellBox.BorderColor = BaseColor.GRAY;

                BaseFont bfntHead = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);



                iTextSharp.text.Font fntHead = new iTextSharp.text.Font(bfntHead, 14, 1, BaseColor.BLACK);
                iTextSharp.text.Font fntHeadD = new iTextSharp.text.Font(bfntHead, 10, 1, BaseColor.BLACK);

                Image d = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath("/Styles/Images/HeaderReceiptReg.png"));


                cellBox.AddElement(d);



                Paragraph prgHeadings = new Paragraph();

                var FontColour = new BaseColor(0, 0, 153);

                iTextSharp.text.Font fntHead3 = new iTextSharp.text.Font(bfntHead, 11, 1, FontColour);

                Paragraph prgsndHeadings = new Paragraph();
                prgsndHeadings.Alignment = Element.ALIGN_CENTER;

                prgsndHeadings.Add(new Chunk("\u00a0 \u00a0 \u00a0 \u00a0 \u00a0 \u00a0 \u00a0 \u00a0 SIP REGISTRATION RECEIPT\n", fntHead3));
                //cellBox.AddElement(prgsndHeadings);

                iTextSharp.text.Font fntHead2 = new iTextSharp.text.Font(bfntHead, 10, 1, BaseColor.BLACK);
                Paragraph prgHeading2 = new Paragraph();
                prgHeading2.Alignment = Element.ALIGN_LEFT;

                PdfPTable mtable = new PdfPTable(2);
                mtable.WidthPercentage = 100;

                Paragraph para = new Paragraph();
                Chunk glue = new Chunk(new VerticalPositionMark());
                Phrase ph12 = new Phrase();
                Phrase ph1 = new Phrase();

                BaseFont btnDistributor = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1250, BaseFont.NOT_EMBEDDED);
                BaseFont btnDistributor1 = BaseFont.CreateFont(BaseFont.TIMES_BOLD, BaseFont.CP1250, BaseFont.NOT_EMBEDDED);
                iTextSharp.text.Font fntDistributor = new iTextSharp.text.Font(btnDistributor, 11, 2, BaseColor.RED);
                iTextSharp.text.Font fntHeader = new iTextSharp.text.Font(btnDistributor, 10, 1, BaseColor.BLACK);
                iTextSharp.text.Font fntBody = new iTextSharp.text.Font(btnDistributor, 10, 0, BaseColor.BLACK);

                PdfPTable tableDetailBox = new PdfPTable(1);
                tableDetailBox.WidthPercentage = 100f;

                PdfPTable tableDetails = new PdfPTable(7);

                tableDetails.WidthPercentage = 100f;
                tableDetails.DefaultCell.BorderColor = BaseColor.WHITE;
                tableDetails.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;

                cellBox.AddElement(new Paragraph(Chunk.NEWLINE));
                d = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath("/Styles/customer details.png"));

                PdfPCell cell1 = new PdfPCell();
                cell1.Colspan = 7;
                cell1.AddElement(d);

                cell1.Border = iTextSharp.text.Rectangle.NO_BORDER;
                tableDetails.AddCell(cell1);

                PdfPCell cellE = new PdfPCell();

                cellE.BackgroundColor = BaseColor.WHITE;
                cellE.Border = iTextSharp.text.Rectangle.NO_BORDER;
                cellE.Border = iTextSharp.text.Rectangle.NO_BORDER;

                cell1 = new PdfPCell(new Phrase(" Branch ", fntHeader)) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT };
                cell1.BackgroundColor = BaseColor.WHITE;
                cell1.Border = iTextSharp.text.Rectangle.NO_BORDER;

                tableDetails.AddCell(cell1);

                PdfPCell cell2 = new PdfPCell(new Phrase(" : " + " Online Client Portal ", fntBody)) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT };

                cell2.Colspan = 3;

                cell2.Border = iTextSharp.text.Rectangle.NO_BORDER;
                tableDetails.AddCell(cell2);

                PdfPCell cell5 = new PdfPCell(new Phrase("Reg. Date ", fntHeader)) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT };

                cell5.Border = iTextSharp.text.Rectangle.NO_BORDER;

                tableDetails.AddCell(cell5);


                cell5 = new PdfPCell(new Phrase(" : " + Convert.ToDateTime(objATT.SIP_Reg_Date).ToString("yyyy-MM-dd"), fntBody)) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT };

                cell5.Colspan = 2;
                cell5.BorderColor = BaseColor.WHITE;

                tableDetails.AddCell(cell5);


                PdfPCell cell3 = new PdfPCell(new Phrase(" BOID ", fntHeader)) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT };

                cell3.Border = iTextSharp.text.Rectangle.NO_BORDER;
                tableDetails.AddCell(cell3);

                PdfPCell cell4 = new PdfPCell(new Phrase(" : " + objATT.boid, fntBody)) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT };

                cell4.Colspan = 3;

                cell4.Border = iTextSharp.text.Rectangle.NO_BORDER;
                tableDetails.AddCell(cell4);

                cell5 = new PdfPCell(new Phrase("Reg No ", fntHeader)) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT };

                cell5.BorderColor = BaseColor.WHITE;

                tableDetails.AddCell(cell5);

                cell5 = new PdfPCell(new Phrase(" : " + objATT.DSIP_Reg_No, fntBody)) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT };

                cell5.Colspan = 2;
                cell5.BorderColor = BaseColor.WHITE;

                tableDetails.AddCell(cell5);

                cell1 = new PdfPCell(new Phrase(" Name", fntHeader)) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT };

                cell1.Border = iTextSharp.text.Rectangle.NO_BORDER;
                tableDetails.AddCell(cell1);

                cell2 = new PdfPCell(new Phrase(" : " + objATT.Name, fntBody)) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT };
                cell2.Colspan = 3;

                cell2.Border = iTextSharp.text.Rectangle.NO_BORDER;

                tableDetails.AddCell(cell2);


                cell5 = new PdfPCell(new Phrase("Holder Type ", fntHeader)) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT };

                cell5.BorderColor = BaseColor.WHITE;

                tableDetails.AddCell(cell5);

                cell5 = new PdfPCell(new Phrase(" : " + "Individual", fntBody)) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT };
                cell5.Colspan = 2;

                cell5.BorderColor = BaseColor.WHITE;

                tableDetails.AddCell(cell5);

                cellBox.AddElement(tableDetails);

                cellBox.AddElement(new Paragraph(Chunk.NEWLINE));

                d = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath("/Styles/registration details.png"));

                Paragraph prgHeading3 = new Paragraph();

                prgHeading3.Add(Chunk.NEWLINE);

                cellBox.AddElement(prgHeading3);

                btnDistributor = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1250, BaseFont.NOT_EMBEDDED);
                btnDistributor1 = BaseFont.CreateFont(BaseFont.TIMES_BOLD, BaseFont.CP1250, BaseFont.NOT_EMBEDDED);
                fntDistributor = new iTextSharp.text.Font(btnDistributor, 10, 2, BaseColor.BLACK);
                fntHeader = new iTextSharp.text.Font(btnDistributor1, 9, 1, BaseColor.BLACK);

                PdfPTable tableup = new PdfPTable(1);
                tableup.WidthPercentage = 100f;
                tableup.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                PdfPCell cellup = new PdfPCell();
                cell1.BackgroundColor = BaseColor.WHITE;
                cellup.BorderColor = BaseColor.WHITE;

                PdfPTable table = new PdfPTable(8);

                table.WidthPercentage = 100f;
                table.DefaultCell.BorderColor = BaseColor.WHITE;

                PdfPCell cell15 = new PdfPCell();

                cell15.AddElement(d);
                cell15.Border = iTextSharp.text.Rectangle.NO_BORDER;
                cell15.Colspan = 8;
                table.AddCell(cell15);

                cell5 = new PdfPCell(new Phrase("SIP Start Date", fntHeader)) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER };

                cell5.BorderColor = BaseColor.BLACK;

                table.AddCell(cell5);

                PdfPCell cell6 = new PdfPCell(new Phrase("SIP Amount", fntHeader)) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER };

                cell6.BorderColor = BaseColor.BLACK;

                table.AddCell(cell6);

                PdfPCell cell7 = new PdfPCell(new Phrase("SIP Interval ", fntHeader)) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER };

                cell7.BorderColor = BaseColor.BLACK;

                table.AddCell(cell7);

                PdfPCell cell8 = new PdfPCell(new Phrase("SIP Maturity Term", fntHeader)) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER };

                cell8.BorderColor = BaseColor.BLACK;

                table.AddCell(cell8);

                PdfPCell cell9 = new PdfPCell(new Phrase("SIP Maturity Date ", fntHeader)) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER };

                cell9.BorderColor = BaseColor.BLACK;

                table.AddCell(cell9);

                cell9 = new PdfPCell(new Phrase("SIP Mode ", fntHeader)) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER };

                cell9.BorderColor = BaseColor.BLACK;

                table.AddCell(cell9);

                cell9 = new PdfPCell(new Phrase("Payment Mode ", fntHeader)) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER };

                cell9.Colspan = 2;
                cell9.BorderColor = BaseColor.BLACK;

                table.AddCell(cell9);

                cell5 = new PdfPCell(new Phrase(Convert.ToDateTime(objATT.SIP_Eff_Date).ToString("yyyy-MM-dd"), fntBody)) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER };

                cell5.BorderColor = BaseColor.BLACK;

                table.AddCell(cell5);

                cell5 = new PdfPCell(new Phrase(String.Format(new CultureInfo("en-IN"), "{0:C2}", Convert.ToDouble(objATT.Sip_amt)), fntBody)) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT };

                cell5.BorderColor = BaseColor.BLACK;
                table.AddCell(cell5);

                cell5 = new PdfPCell(new Phrase(Convert.ToString(objATT.Interval), fntBody)) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER };

                cell5.BorderColor = BaseColor.BLACK;

                table.AddCell(cell5);

                cell5 = new PdfPCell(new Phrase(Convert.ToString(objATT.Terms), fntBody)) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER };

                cell5.BorderColor = BaseColor.BLACK;

                table.AddCell(cell5);


                cell5 = new PdfPCell(new Phrase(objATT.SIP_Last_Date, fntBody)) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER };

                cell5.BorderColor = BaseColor.BLACK;

                table.AddCell(cell5);
                if (objATT.Model_of_Sip == "Limited [ अवधि तोकिएको ] " || objATT.Model_of_Sip == "Limited [ अवधि तोकिएको ]")
                {
                    objATT.Model_of_Sip = "Limited";
                }
                else
                {
                    objATT.Model_of_Sip = "Unlimited";
                }
                cell5 = new PdfPCell(new Phrase(objATT.Model_of_Sip, fntBody)) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER };

                cell5.BorderColor = BaseColor.BLACK;

                table.AddCell(cell5);

                cell5 = new PdfPCell(new Phrase(Convert.ToString(objATT.PaymentMode), fntBody)) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER };

                cell5.BorderColor = BaseColor.BLACK;
                cell5.Colspan = 2;

                table.AddCell(cell5);

                cellup.AddElement(table);
                tableup.AddCell(cellup);
                cellBox.AddElement(tableup);

                //tableDetails = new PdfPTable(7);


                //tableDetails.DefaultCell.BorderColor = BaseColor.WHITE;
                //tableDetails.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;

                //cell1 = new PdfPCell();
                //cell1.Colspan = 2;
                //cell1.BackgroundColor = BaseColor.WHITE;
                //cell1.Border = iTextSharp.text.Rectangle.NO_BORDER;

                //tableDetails.AddCell(cell1);

                //cellE = new PdfPCell();
                //cellE.Colspan = 5;
                //cellE.BackgroundColor = BaseColor.WHITE;
                //cellE.Border = iTextSharp.text.Rectangle.NO_BORDER;
                //cellE.Border = iTextSharp.text.Rectangle.NO_BORDER;
                //tableDetails.AddCell(cellE);


                //cell1 = new PdfPCell(new Phrase(" Payment Mode ", fntHeader)) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT };
                //cell1.BackgroundColor = BaseColor.WHITE;
                //cell1.Border = iTextSharp.text.Rectangle.NO_BORDER;


                //tableDetails.AddCell(cell1);



                //cell2 = new PdfPCell(new Phrase(" : " + objATT.PaymentMode, fntBody)) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT };

                //cell2.Colspan = 3;
                //cell2.BackgroundColor = BaseColor.WHITE;

                //cell2.Border = iTextSharp.text.Rectangle.NO_BORDER;
                //tableDetails.AddCell(cell2);


                //cell2 = new PdfPCell(new Phrase(" SIP Amount ", fntHeader)) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT };
                //cell2.BackgroundColor = BaseColor.WHITE;
                //cell2.Border = iTextSharp.text.Rectangle.NO_BORDER;

                //tableDetails.AddCell(cell2);

                //cell2 = new PdfPCell(new Phrase(" : " + objATT.Sip_amt, fntBody)) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT };
                //cell2.BackgroundColor = BaseColor.WHITE;
                //cell2.Colspan = 2;
                //cell2.Border = iTextSharp.text.Rectangle.NO_BORDER;

                //tableDetails.AddCell(cell2);


                //cell2 = new PdfPCell(new Phrase(" SIP Start Date ", fntHeader)) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT };

                //cell2.BackgroundColor = BaseColor.WHITE;
                //cell2.Border = iTextSharp.text.Rectangle.NO_BORDER;

                //tableDetails.AddCell(cell2);

                //cell2 = new PdfPCell(new Phrase(" : " + objATT.Action_Date, fntBody)) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT };
                //cell2.Colspan = 3;
                //cell2.BackgroundColor = BaseColor.WHITE;
                //cell2.Border = iTextSharp.text.Rectangle.NO_BORDER;

                //tableDetails.AddCell(cell2);

                //cell2 = new PdfPCell(new Phrase(" SIP Last Date ", fntHeader)) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT };
                //cell2.BackgroundColor = BaseColor.WHITE;

                //cell2.Border = iTextSharp.text.Rectangle.NO_BORDER;

                //tableDetails.AddCell(cell2);

                //cell2 = new PdfPCell(new Phrase(" : " + objATT.SIP_Last_Date, fntBody)) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT };
                //cell2.Colspan = 2;
                //cell2.BackgroundColor = BaseColor.WHITE;
                //cell2.Border = iTextSharp.text.Rectangle.NO_BORDER;

                //tableDetails.AddCell(cell2);

                //cell2 = new PdfPCell(new Phrase(" SIP Interval ", fntHeader)) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT };
                //cell2.BackgroundColor = BaseColor.WHITE;
                //cell2.Border = iTextSharp.text.Rectangle.NO_BORDER;

                //tableDetails.AddCell(cell2);

                //cell2 = new PdfPCell(new Phrase(" : " + objATT.SIP_Interval, fntBody)) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT };
                //cell2.Colspan = 3;
                //cell2.BackgroundColor = BaseColor.WHITE;
                //cell2.Border = iTextSharp.text.Rectangle.NO_BORDER;

                //tableDetails.AddCell(cell2);

                //cell2 = new PdfPCell(new Phrase(" SIP Terms ", fntHeader)) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT };
                //cell2.BackgroundColor = BaseColor.WHITE;
                //cell2.Border = iTextSharp.text.Rectangle.NO_BORDER;

                //tableDetails.AddCell(cell2);

                //cell2 = new PdfPCell(new Phrase(" : " + objATT.Terms, fntBody)) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT };
                //cell2.BackgroundColor = BaseColor.WHITE;
                //cell2.Colspan = 2;
                //cell2.Border = iTextSharp.text.Rectangle.NO_BORDER;

                //tableDetails.AddCell(cell2);

                //cell2 = new PdfPCell(new Phrase(" SIP Mode ", fntHeader)) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT };
                //cell2.BackgroundColor = BaseColor.WHITE;
                //cell2.Border = iTextSharp.text.Rectangle.NO_BORDER;

                //tableDetails.AddCell(cell2);

                //cell2 = new PdfPCell(new Phrase(" : " + objATT.modeofSIP, fntBody)) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT };
                //cell2.Colspan = 3;
                //cell2.BackgroundColor = BaseColor.WHITE;
                //cell2.Border = iTextSharp.text.Rectangle.NO_BORDER;

                //tableDetails.AddCell(cell2);

                //cell2 = new PdfPCell();
                //cell2.BackgroundColor = BaseColor.WHITE;
                //cell2.Border = iTextSharp.text.Rectangle.NO_BORDER;

                //tableDetails.AddCell(cell2);

                //cell2 = new PdfPCell();
                //cell2.Colspan = 2;
                //cell2.BackgroundColor = BaseColor.WHITE;
                //cell2.Border = iTextSharp.text.Rectangle.NO_BORDER;

                //tableDetails.AddCell(cell2);


                fntBody = new iTextSharp.text.Font(btnDistributor, 9, 1, BaseColor.BLACK);
                Paragraph p = new Paragraph();

                prgHeading3 = new Paragraph();

                Paragraph prgAutho = new Paragraph();
                prgAutho.Add(Chunk.NEWLINE);
                prgAutho.Add(Chunk.NEWLINE);
                prgAutho.Add(Chunk.NEWLINE);
                cellBox.AddElement(prgAutho);

                d = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath("/Styles/footer.png"));

                cellBox.AddElement(d);

                tableBOX.AddCell(cellBox);
                document.Add(tableBOX);
                document.Close();

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
    }
}