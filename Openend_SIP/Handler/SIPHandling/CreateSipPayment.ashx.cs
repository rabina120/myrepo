using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SI.Utility;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Globalization;
using System.IO;
using iTextSharp.text.pdf.draw;
using SI.SIPHandling.ATT;
using SI.SIPHandling.DLL;


namespace Openend_SIP.Handler.SIPHandling
{
    /// <summary>
    /// Summary description for CreateSipPayment
    /// </summary>
    public class CreateSipPayment : BaseHandler
    {
        public object CreateSipPaymentReceipt(string TXNID, string l_company)
        {
            ValidateToken("A", null);
            JsonResponse response = new JsonResponse();
            DLLSIPPayment objDll = new DLLSIPPayment();

            List<ATTSIP_Registration> objATT = new List<ATTSIP_Registration>();
            objATT = objDll.GetTXNData(TXNID);

            ServerMap sm = new ServerMap();
            string fileName = "";
          
            try
            {

                string strJson = new StreamReader(context.Request.InputStream).ReadToEnd();
                //deserialize the object

                string guid = Guid.NewGuid().ToString();
                fileName = guid + ".pdf";
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

                Image d = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath("/Styles/Images/paymentReceiptReg.png"));


                cellBox.AddElement(d);



                Paragraph prgHeadings = new Paragraph();

                var FontColour = new BaseColor(0, 0, 153);

                iTextSharp.text.Font fntHead3 = new iTextSharp.text.Font(bfntHead, 11, 1, FontColour);

                Paragraph prgsndHeadings = new Paragraph();
                prgsndHeadings.Alignment = Element.ALIGN_CENTER;

                prgsndHeadings.Add(new Chunk("\u00a0 \u00a0 \u00a0 \u00a0 \u00a0 \u00a0 \u00a0 \u00a0 SIP PAYMENT RECEIPT\n", fntHead3));
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


                PdfPCell cell5 = new PdfPCell(new Phrase("", fntHeader)) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT };

                cell5.Border = iTextSharp.text.Rectangle.NO_BORDER;

                tableDetails.AddCell(cell5);


                cell5 = new PdfPCell(new Phrase("  " , fntBody)) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT };

                cell5.Colspan = 2;
                cell5.BorderColor = BaseColor.WHITE;

                tableDetails.AddCell(cell5);




                PdfPCell cell3 = new PdfPCell(new Phrase(" BOID ", fntHeader)) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT };

                cell3.Border = iTextSharp.text.Rectangle.NO_BORDER;
                tableDetails.AddCell(cell3);

                PdfPCell cell4 = new PdfPCell(new Phrase(" : " + objATT[0].boid, fntBody)) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT };


                cell4.Colspan = 3;

                cell4.Border = iTextSharp.text.Rectangle.NO_BORDER;
                tableDetails.AddCell(cell4);


                cell5 = new PdfPCell(new Phrase("Date", fntHeader)) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT };

                cell5.BorderColor = BaseColor.WHITE;

                tableDetails.AddCell(cell5);

                cell5 = new PdfPCell(new Phrase(" : "+DateTime.Now.ToString("yyyy-MM-dd"), fntBody)) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT };

                cell5.Colspan = 2;
                cell5.BorderColor = BaseColor.WHITE;

                tableDetails.AddCell(cell5);


                cell1 = new PdfPCell(new Phrase(" Name", fntHeader)) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT };

                cell1.Border = iTextSharp.text.Rectangle.NO_BORDER;
                tableDetails.AddCell(cell1);


                cell2 = new PdfPCell(new Phrase(" : " + objATT[0].Name, fntBody)) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT };
                cell2.Colspan = 3;

                cell2.Border = iTextSharp.text.Rectangle.NO_BORDER;

                tableDetails.AddCell(cell2);


                cell5 = new PdfPCell(new Phrase("SIP_Reg_no ", fntHeader)) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT };

                cell5.BorderColor = BaseColor.WHITE;


                tableDetails.AddCell(cell5);



                cell5 = new PdfPCell(new Phrase(" : " + objATT[0].SIP_Reg_No, fntBody)) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT };
                cell5.Colspan = 2;

                cell5.BorderColor = BaseColor.WHITE;

                tableDetails.AddCell(cell5);

                PdfPCell cell10 = new PdfPCell(new Phrase(" : " + " Online Client Portal ", fntBody)) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT };

                cell10.Colspan = 3;

                cell10.Border = iTextSharp.text.Rectangle.NO_BORDER;
                tableDetails.AddCell(cell10);
                cellBox.AddElement(tableDetails);

                //cellBox.AddElement(new Paragraph(Chunk.NEWLINE));

                d = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath("/Styles/payment_details.png"));


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


                PdfPTable table = new PdfPTable(4);

                table.WidthPercentage = 100f;
                table.DefaultCell.BorderColor = BaseColor.WHITE;


           


                PdfPCell cell15 = new PdfPCell();

              



                cell5 = new PdfPCell(new Phrase("Installment No.", fntHeader)) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER };

                cell5.BorderColor = BaseColor.BLACK;

                table.AddCell(cell5);

                PdfPCell cell6 = new PdfPCell(new Phrase("SIP Installment Date ", fntHeader)) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER };

                cell6.BorderColor = BaseColor.BLACK;

                table.AddCell(cell6);

                PdfPCell cell7 = new PdfPCell(new Phrase("SIP Amount ", fntHeader)) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER };

                cell7.BorderColor = BaseColor.BLACK;

                table.AddCell(cell7);

                PdfPCell cell8 = new PdfPCell(new Phrase("Transaction Status", fntHeader)) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER };

                cell8.BorderColor = BaseColor.BLACK;

                table.AddCell(cell8);


                //cell5 = new PdfPCell(new Phrase(Convert.ToString(objATT.SIP_Reg_No), fntBody)) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER };

                //cell5.BorderColor = BaseColor.BLACK;

                //table.AddCell(cell5);

                //cell5 = new PdfPCell(new Phrase(Convert.ToDateTime(objATT.Installment_Dt).ToString("yyyy-MM-dd"), fntBody)) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER };

                //cell5.BorderColor = BaseColor.BLACK;
                //table.AddCell(cell5);

                //cell5 = new PdfPCell(new Phrase(Convert.ToString(objATT.Sip_amt), fntBody)) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER };

                //cell5.BorderColor = BaseColor.BLACK;

                //table.AddCell(cell5);

                //cell5 = new PdfPCell(new Phrase("Transaction Successfull", fntBody)) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER };

                //cell5.BorderColor = BaseColor.BLACK;


                for (int i = 0; i < objATT.Count; i++)
                {
                    var famt = String.Format(new CultureInfo("en-IN"), "{0:C2}", (objATT[i].ReceivedAmt));
                   
                    cell5 = new PdfPCell(new Phrase(Convert.ToString(objATT[i].Interval_Seq_No), fntBody)) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER };

                    cell5.BorderColor = BaseColor.BLACK;

                    table.AddCell(cell5);

                    cell5 = new PdfPCell(new Phrase(Convert.ToDateTime(objATT[i].Action_Date).ToString("yyyy-MM-dd"), fntBody)) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER };

                    cell5.BorderColor = BaseColor.BLACK;
                    table.AddCell(cell5);

                    cell5 = new PdfPCell(new Phrase(Convert.ToString(famt), fntBody)) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER };

                    cell5.BorderColor = BaseColor.BLACK;

                    table.AddCell(cell5);

                    cell5 = new PdfPCell(new Phrase("Transaction Successfull", fntBody)) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER };

                    cell5.BorderColor = BaseColor.BLACK;
                    table.AddCell(cell5);
                    //table.AddCell(new Phrase(Convert.ToString(objATT[i].Interval_Seq_No), fntBody));
                    //table.AddCell(new Phrase(Convert.ToString(objATT[i].Action_Date), fntBody));
                    //table.AddCell(new Phrase(Convert.ToString(famt), fntBody));
                    //table.AddCell(new Phrase(Convert.ToString("Transaction Successfull"), fntBody));
                   
                }
                cellBox.AddElement(table);
             

                fntBody = new iTextSharp.text.Font(btnDistributor, 9, 1, BaseColor.BLACK);
                Paragraph p = new Paragraph();

                prgHeading3 = new Paragraph();
                Paragraph prgAutho = new Paragraph();
                prgAutho.Add(Chunk.NEWLINE);
                cellBox.AddElement(prgAutho);
                d = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath("/Styles/footer.png"));
                cellBox.AddElement(d);
                tableBOX.AddCell(cellBox);
                document.Add(tableBOX);
                document.Close();
                fs.Close();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            response.ResponseData = fileName;
            return JsonUtility.Serialize(response);
        }
       
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}