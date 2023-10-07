using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SI.Utility;
using SI.SIPHandling.ATT;
using System.IO;
using iTextSharp.text.pdf.draw;
using System.Globalization;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace Openend_SIP.Handler.SIPHandling
{
    /// <summary>
    /// Summary description for CreateHolderStatement
    /// </summary>
    public class CreateHolderStatement : BaseHandler
    {

         public object CreateHolderStatementPdf(string holders,string Name, string BOID, string startdate, string enddate)
        {
            ValidateToken("A", null);
            JsonResponse response = new JsonResponse();
            List<ATTHolderStatement> objATT = JsonUtility.DeSerialize(holders, typeof(List<ATTHolderStatement>)) as List<ATTHolderStatement>;

            ServerMap sm = new ServerMap();
            string fileName = "";
            try
            {

                string strJson = new StreamReader(context.Request.InputStream).ReadToEnd();
                //deserialize the object
                string guid = Guid.NewGuid().ToString();
                fileName = guid + ".pdf";

                //fileName = "/SIP Holder Statement  Report -" + System.DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + ".pdf";

                string path = HttpContext.Current.Server.MapPath("/Reports/HolderStatement/" + fileName);


                System.IO.FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None);
                Document document = new Document(PageSize.A4, 10, 10, 110, 130);


                
                PdfWriter writer = PdfWriter.GetInstance(document, fs);
                writer.PageEvent = new ITextEventsHolder();
                document.Open();

                BaseFont bfntHead = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                Paragraph ph = new Paragraph();
                Chunk glue1 = new Chunk(new VerticalPositionMark());
                Phrase ph12 = new Phrase();

                iTextSharp.text.Font fntHead = new iTextSharp.text.Font(bfntHead, 12, 1, BaseColor.BLACK);
                iTextSharp.text.Font fntHeadD = new iTextSharp.text.Font(bfntHead, 8, 1, BaseColor.BLACK);

               // ph.Add(Chunk.NEWLINE);
                ph.Add(Chunk.NEWLINE);
                
                Image d = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath("/Styles/Images/HeaderReceiptHolder.png"));
                d.ScaleAbsoluteWidth(document.PageSize.Width - 15);
                d.ScaleAbsoluteHeight(80);              
             
                var FontColour = new BaseColor(0, 0, 153);

                iTextSharp.text.Font fntHead3 = new iTextSharp.text.Font(bfntHead, 12, 1, FontColour);
                iTextSharp.text.Font fntHead3T = new iTextSharp.text.Font(bfntHead, 9, 1, BaseColor.BLACK);
                Paragraph prgsndHeadings = new Paragraph();
                prgsndHeadings.Alignment = Element.ALIGN_CENTER;

                prgsndHeadings.Add(new Chunk("\n\n  \u00a0 \u00a0 \u00a0 \u00a0 \u00a0 SIP HOLDER STATEMENT \n\n", fntHead3));

                iTextSharp.text.Font fntHead2 = new iTextSharp.text.Font(bfntHead, 10, 1, BaseColor.BLACK);
                Paragraph prgHeading2 = new Paragraph();
                Paragraph prgHeading2R = new Paragraph();
                prgHeading2.Alignment = Element.ALIGN_LEFT;
                prgHeading2R.Alignment = Element.ALIGN_RIGHT;

                BaseFont btnDistributor = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1250, BaseFont.NOT_EMBEDDED);
                BaseFont btnDistributor1 = BaseFont.CreateFont(BaseFont.TIMES_BOLD, BaseFont.CP1250, BaseFont.NOT_EMBEDDED);
                iTextSharp.text.Font fntDistributor = new iTextSharp.text.Font(btnDistributor, 11, 2, BaseColor.RED);
                iTextSharp.text.Font fntHeader = new iTextSharp.text.Font(btnDistributor, 10, 1, BaseColor.BLACK);
                iTextSharp.text.Font fntBody = new iTextSharp.text.Font(btnDistributor, 10, 0, BaseColor.BLACK);
                    

                PdfPTable tableDetails = new PdfPTable(7);
                tableDetails.WidthPercentage = 100f;
                tableDetails.DefaultCell.FixedHeight = 100f;
                tableDetails.DefaultCell.BorderColor = BaseColor.WHITE;
                tableDetails.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;

                d = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath("/Styles/unitholder.png"));


                PdfPCell cell1 = new PdfPCell();
                cell1.Colspan = 7;
                cell1.AddElement(d);
                cell1.Border = iTextSharp.text.Rectangle.NO_BORDER;

                tableDetails.AddCell(cell1);

                cell1 = new PdfPCell(new Phrase(" Branch ", fntHeader)) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT };
                cell1.Border = iTextSharp.text.Rectangle.NO_BORDER;
                tableDetails.AddCell(cell1);

                PdfPCell cell2 = new PdfPCell(new Phrase(" : " + "NIBL Online System", fntBody)) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT };

                cell2.Colspan = 3;
                cell2.Border = iTextSharp.text.Rectangle.NO_BORDER;
                tableDetails.AddCell(cell2);


                PdfPCell cell5 = new PdfPCell(new Phrase("Reg. Date ", fntHeader)) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT };
                cell5.Border = iTextSharp.text.Rectangle.NO_BORDER;
                tableDetails.AddCell(cell5);

                cell5 = new PdfPCell(new Phrase(" : " + Convert.ToDateTime(objATT[0].actionDate).ToString("yyyy-MM-dd"), fntBody)) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT };
                cell5.Colspan = 2;
                cell5.BorderColor = BaseColor.WHITE;
                tableDetails.AddCell(cell5);

                PdfPCell cell3 = new PdfPCell(new Phrase(" BOID ", fntHeader)) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT };
                cell3.Border = iTextSharp.text.Rectangle.NO_BORDER;
                tableDetails.AddCell(cell3);

                PdfPCell cell4 = new PdfPCell(new Phrase(" : " + BOID, fntBody)) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT };

                cell4.Colspan = 3;
                cell4.Border = iTextSharp.text.Rectangle.NO_BORDER;
                tableDetails.AddCell(cell4);

                cell5 = new PdfPCell(new Phrase("Reg No ", fntHeader)) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT };
                cell5.BorderColor = BaseColor.WHITE;
                tableDetails.AddCell(cell5);

                cell5 = new PdfPCell(new Phrase(" : " + objATT[0].SIP_Reg_No, fntBody)) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT };
                cell5.Colspan = 2;
                cell5.BorderColor = BaseColor.WHITE;;
                tableDetails.AddCell(cell5);

                cell1 = new PdfPCell(new Phrase(" Name", fntHeader)) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT };
                cell1.Border = iTextSharp.text.Rectangle.NO_BORDER;
                tableDetails.AddCell(cell1);

                cell2 = new PdfPCell(new Phrase(" : " + Name, fntBody)) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT };
                cell2.Colspan = 3;
                cell2.Border = iTextSharp.text.Rectangle.NO_BORDER;
                tableDetails.AddCell(cell2);

                cell5 = new PdfPCell(new Phrase("Print Date ", fntHeader)) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT };
                cell5.BorderColor = BaseColor.WHITE;
                tableDetails.AddCell(cell5);

                cell5 = new PdfPCell(new Phrase(" : " + DateTime.Now.ToString("yyyy/MM/dd").Replace('/', '-'), fntBody)) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT };
                cell5.Colspan = 2;
                cell5.BorderColor = BaseColor.WHITE;
                tableDetails.AddCell(cell5);

                document.Add(tableDetails);

                fntHeader = new iTextSharp.text.Font(btnDistributor, 11, 1, BaseColor.BLACK);
                Paragraph prgHeading3 = new Paragraph();
                prgHeading3.Alignment = Element.ALIGN_CENTER;
                prgHeading3.Add(new Chunk("\nSTATEMENT DATE FROM " + Convert.ToDateTime(startdate).ToString("yyyy-MM-dd") + " TO " + Convert.ToDateTime(enddate).ToString("yyyy-MM-dd"), fntHeader));
                document.Add(prgHeading3);

                Paragraph p = new Paragraph();
                p.Add(Chunk.NEWLINE);
                d = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath("/Styles/transaction.png"));

                document.Add(p);
                tableDetails = new PdfPTable(7);
                tableDetails.WidthPercentage = 100f;
                tableDetails.DefaultCell.BorderColor = BaseColor.WHITE;
                tableDetails.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                cell1 = new PdfPCell();
                cell1.Colspan = 7;
                cell1.AddElement(d);
                cell1.Border = iTextSharp.text.Rectangle.NO_BORDER;
                tableDetails.AddCell(cell1);
                document.Add(tableDetails);

                btnDistributor = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1250, BaseFont.NOT_EMBEDDED);
                btnDistributor1 = BaseFont.CreateFont(BaseFont.TIMES_BOLD, BaseFont.CP1250, BaseFont.NOT_EMBEDDED);
                fntDistributor = new iTextSharp.text.Font(btnDistributor, 10, 2, BaseColor.BLACK);
                fntHeader = new iTextSharp.text.Font(btnDistributor1, 11, 1, BaseColor.BLACK);
                fntBody = new iTextSharp.text.Font(btnDistributor, 9, 1, BaseColor.BLACK);
                iTextSharp.text.Font subFntBody = new iTextSharp.text.Font(btnDistributor, 7, 1, BaseColor.BLACK);
                iTextSharp.text.Font fntBodyCr = new iTextSharp.text.Font(btnDistributor, 9, 1, BaseColor.BLUE);
                iTextSharp.text.Font fntBodyDb = new iTextSharp.text.Font(btnDistributor, 9, 1, BaseColor.RED);

                PdfPTable table = new PdfPTable(8);
                table.HeaderRows = 1;
                table.WidthPercentage = 100f;

                cell1 = new PdfPCell(new Phrase("Trans. Date", fntHeader)) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER }; 
                cell1.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER; 
                table.AddCell(cell1);


                cell2 = new PdfPCell(new Phrase("Particulars", fntHeader)) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER };
                cell2.Colspan = 4;
                table.AddCell(cell2);

                cell3 = new PdfPCell(new Phrase("Debit (Nrs.)", fntHeader)) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER };
                cell3.BackgroundColor = BaseColor.WHITE;
                cell3.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER; 
                table.AddCell(cell3);

                cell4 = new PdfPCell(new Phrase("Credit (Nrs.)", fntHeader)) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER };
               // cell4.BackgroundColor = BaseColor.WHITE;
                //cell4.AddElement(new Chunk("Credit (Nrs.)", fntHeader));
                cell4.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER; 
                table.AddCell(cell4);


                cell5 = new PdfPCell(new Phrase("Bal Amt", fntHeader)) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER };
                //cell5.BackgroundColor = BaseColor.WHITE;
                //cell5.AddElement();
                cell5.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER; 
                table.AddCell(cell5);

                double total_dr = 0;
                double total_cr = 0;
                double balance = 0;

                PdfPCell db ;
                PdfPCell cr;

                foreach (var obj in objATT)
                {
                    cell1 = new PdfPCell();
                   // cell1.BackgroundColor = BaseColor.WHITE;
                    cell1.AddElement(new Chunk(Convert.ToString(obj.installmentDate), fntBody));
                    cell1.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER; 
                    table.AddCell(cell1);

                    Phrase phraseTable = new Phrase();
                    //table.AddCell(new Phrase(Convert.ToString(obj.actionDate), fntBody));
                    if (obj.Amount_cr != "-")
                    {
                        cell2 = new PdfPCell();
                        cell2.Colspan = 4;
                        cell2.AddElement(new Chunk("SIP Installment Received (< " + obj.actionDate + " >,< "+obj.payment+" >)", fntBody));
                        table.AddCell(cell2);

                         phraseTable = new Phrase();
                        total_cr += Convert.ToDouble(obj.Amount_cr);
                    }
                    else
                    {
                        var fee = Convert.ToDouble(obj.otherCharges) + Convert.ToDouble(obj.sebon_fee);
                        var unitvalue = Convert.ToDouble(obj.unit);
                        var amtvalue = Convert.ToDouble(obj.Amount_dr) - Convert.ToDouble(obj.otherCharges) - Convert.ToDouble(obj.sebon_fee);
                        unitvalue = (Math.Round(Convert.ToDouble(amtvalue / Convert.ToDouble(obj.appnav)), 3));
                        
                        cell2 = new PdfPCell();
                        cell2.Colspan = 4;;
                        cell2.AddElement(new Chunk("Unit Purchased (< " + obj.actionDate + " >,<" + unitvalue + " @ " + obj.appnav + "+" + fee + " >)\n", fntBody));
                        table.AddCell(cell2);
                        total_dr += Convert.ToDouble(obj.Amount_dr);
                        
                    }
                    if (Convert.ToString(obj.Amount_cr) != "-")
                    {
                        db = new PdfPCell(new Phrase("" + String.Format(new CultureInfo("en-IN"), "{0:C2}", obj.Amount_dr), fntBody)) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER };
                        table.AddCell(db); 

                        cr = new PdfPCell(new Phrase("" + String.Format(new CultureInfo("en-IN"), "{0:C2}", Convert.ToDouble(obj.Amount_cr)), fntBody)) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT };

                        table.AddCell(cr);
                    }
                    if (Convert.ToString(obj.Amount_dr) != "-")
                    {
                        db = new PdfPCell(new Phrase("" + String.Format(new CultureInfo("en-IN"), "{0:C2}", Convert.ToDouble(obj.Amount_dr)), fntBody)) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT };
                        table.AddCell(db);

                        cr = new PdfPCell(new Phrase("" + String.Format(new CultureInfo("en-IN"), "{0:C2}", obj.Amount_cr), fntBody)) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER };

                        table.AddCell(cr);
                    }
                   
                    balance = total_cr - total_dr;
                    balance = Math.Round(balance, 4);
                    PdfPCell ttt = new PdfPCell(new Phrase("" + String.Format(new CultureInfo("en-IN"), "{0:C2}", (balance)), fntBody)) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT };
                    table.AddCell(ttt);
                  

                }
                
                
                cell2 = new PdfPCell(new Phrase("\nTOTAL ", fntBody)) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER };
                cell2.Colspan = 5;

                table.AddCell(cell2);

                PdfPCell tdb = new PdfPCell(new Phrase("\n" + String.Format(new CultureInfo("en-IN"), "{0:C2}", (total_dr)), fntBody)) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT };
                table.AddCell(tdb);

                PdfPCell tcr = new PdfPCell(new Phrase("\n" + String.Format(new CultureInfo("en-IN"), "{0:C2}", (total_cr)), fntBody)) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT };
                table.AddCell(tcr);

                PdfPCell tto = new PdfPCell(new Phrase("\n" + String.Format(new CultureInfo("en-IN"), "{0:C2}", (balance)), fntBody)) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT };
                table.AddCell(tto);

                
                document.Add(table);
                document.Close();
                writer.Close();
                fs.Close();


            }
            catch (Exception ex)
            {
                throw ex;
            }
            response.ResponseData = fileName;
            return JsonUtility.Serialize(response);


        }

        //public bool IsReusable
        //{
        //    get
        //    {
        //        return false;
        //    }
        //}
    }
    
}