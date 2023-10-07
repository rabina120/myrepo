using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using iTextSharp.text.pdf;
using iTextSharp.text;

namespace Openend_SIP.Handler.RequestHandling
{
    /// <summary>
    /// Summary description for ITextEvents
    /// </summary>
    public class ITextEvents : PdfPageEventHelper
    {

        PdfContentByte cb;

        // we will put the final number of pages in a template
        PdfTemplate headerTemplate, footerTemplate;

        // this is the BaseFont we are going to use for the header / footer
        BaseFont bf = null;

        // This keeps track of the creation time
        DateTime PrintTime = DateTime.Now;


        #region Fields
        private string _header;
        #endregion

        #region Properties
        public string Header
        {
            get { return _header; }
            set { _header = value; }
        }
        #endregion
        public override void OnOpenDocument(PdfWriter writer, Document document)
        {
            try
            {
                PrintTime = DateTime.Now;
                bf = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                cb = writer.DirectContent;

                headerTemplate = cb.CreateTemplate(100, 100);
                footerTemplate = cb.CreateTemplate(50, 50);
            }
            catch (DocumentException de)
            {

            }
            catch (System.IO.IOException ioe)
            {

            }
        }

        public override void OnEndPage(iTextSharp.text.pdf.PdfWriter writer, iTextSharp.text.Document document)
        {
            base.OnEndPage(writer, document);

            PdfPTable footerTbl = new PdfPTable(1);

            footerTbl.TotalWidth = document.PageSize.Width;

            Image logo = Image.GetInstance(new Uri(string.Format(HttpContext.Current.Server.MapPath("/Styles/Images/footer.png"))));

            logo.SetAbsolutePosition(5, 5);

            PdfPCell cell = new PdfPCell(logo);

            cell.HorizontalAlignment = Element.ALIGN_RIGHT;

            cell.PaddingRight = 20;

            cell.Border = 0;

            footerTbl.AddCell(cell);

            footerTbl.WriteSelectedRows(0, -1, -7, (document.PageSize.GetRight(430)), writer.DirectContent);
            

            PdfPTable headerTbl = new PdfPTable(1);

            headerTbl.TotalWidth = document.PageSize.Width;

            Image logo1 = Image.GetInstance(new Uri(string.Format(HttpContext.Current.Server.MapPath("/Styles/Images/header.png"))));

            logo1.ScalePercent(90);

            logo1.SetAbsolutePosition(0, 0);

            PdfPCell cell1 = new PdfPCell(logo1);

            cell1.HorizontalAlignment = Element.ALIGN_RIGHT;

            cell1.Border = 0;

            headerTbl.AddCell(cell1);

            headerTbl.WriteSelectedRows(0, -1, -40, (document.PageSize.Height - 10), writer.DirectContent);
           // iTextSharp.text.Font baseFontNormal = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12f, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK);

           // iTextSharp.text.Font baseFontBig = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12f, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK);

           // iTextSharp.text.Image logo = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath("/Styles/Images/footer.png"));
           // iTextSharp.text.Image fllogo = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath("/Styles/Images/header.png"));
           // fllogo.SetAbsolutePosition(5,5);
           // logo.SetAbsolutePosition(5,5);
           
           //// frlogo.SetAbsolutePosition(350f,350f);
            
           //// logo.Alignment = Element.ALIGN_CENTER;

           // //Create PdfTable object
           // PdfPTable pdfTab = new PdfPTable(3);

           // //We will have to create separate cells to include image logo and 2 separate strings
           // //Row 1
           // PdfPCell pdfCell1 = new PdfPCell();
           // //Add paging to header
           // {
           //     //cb.BeginText();
           //     //cb.SetFontAndSize(bf, 12);
           //     //cb.SetTextMatrix(document.PageSize.GetRight(200), document.PageSize.GetTop(45));
           //     //cb.AddImage(fllogo);
           //     //cb.EndText();
           //     //float len = bf.GetWidthPoint(fllogo, 12);
           //     //Adds "12" in Page 1 of 12
           //     //cb.AddTemplate(headerTemplate, document.PageSize.GetRight(200) , document.PageSize.GetTop(45));
            
           // }
           // //Add paging to footer
           // {
           //     cb.BeginText();
           //     cb.SetFontAndSize(bf, 12);
           //     cb.SetTextMatrix(document.PageSize.GetRight(180), document.PageSize.GetBottom(30));

           //     cb.AddImage(logo);
           //     cb.EndText();

           //     cb.AddTemplate(footerTemplate, document.PageSize.GetRight(180), document.PageSize.GetBottom(30));
           // }
          
           // //set the alignment of all three cells and set border to 0
           // pdfCell1.HorizontalAlignment = Element.ALIGN_LEFT;

           // //add all three cells into PdfTable
           // pdfTab.AddCell(pdfCell1);
          


           // pdfTab.TotalWidth = document.PageSize.Width - 80f;
           // pdfTab.WidthPercentage = 70;
           // //pdfTab.HorizontalAlignment = Element.ALIGN_CENTER;


            //call WriteSelectedRows of PdfTable. This writes rows from PdfWriter in PdfTable
            //first param is start row. -1 indicates there is no end row and all the rows to be included to write
            //Third and fourth param is x and y position to start writing
           // pdfTab.WriteSelectedRows(0, -1, 40, document.PageSize.Height - 30, writer.DirectContent);
            //set pdfContent value

            //Move the pointer and draw line to separate header section from rest of page
            //cb.MoveTo(40, document.PageSize.Height - 100);
            //cb.LineTo(document.PageSize.Width - 40, document.PageSize.Height - 100);
            //cb.Stroke();

            ////Move the pointer and draw line to separate footer section from rest of page
            //cb.MoveTo(40, document.PageSize.GetBottom(50));
            //cb.LineTo(document.PageSize.Width - 40, document.PageSize.GetBottom(50));
            //cb.Stroke();
        }

        public override void OnCloseDocument(PdfWriter writer, Document document)
        {
            base.OnCloseDocument(writer, document);

           // headerTemplate.BeginText();
           // headerTemplate.SetFontAndSize(bf, 12);
           // headerTemplate.SetTextMatrix(0, 0);
           // //headerTemplate.AddImage();
           //// headerTemplate.ShowText((writer.PageNumber - 1).ToString());
           // headerTemplate.EndText();

           // footerTemplate.BeginText();
           // footerTemplate.SetFontAndSize(bf, 12);
           // footerTemplate.SetTextMatrix(0, 0);
           // footerTemplate.ShowText((writer.PageNumber - 1).ToString());
           // footerTemplate.EndText();
        }
    }
    
}