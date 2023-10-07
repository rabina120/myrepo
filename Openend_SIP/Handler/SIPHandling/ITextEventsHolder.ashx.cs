using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using iTextSharp.text.pdf;
using iTextSharp.text;
using iTextSharp.text.pdf.draw;

namespace Openend_SIP.Handler.SIPHandling
{
    /// <summary>
    /// Summary description for ITextEventsHolder
    /// </summary>
    public class ITextEventsHolder : PdfPageEventHelper
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


            Image watermark = Image.GetInstance(HttpContext.Current.Server.MapPath("/Styles/transparent.png"));
            iTextSharp.text.Image jpg1 = watermark;

            jpg1.Alignment = iTextSharp.text.Image.UNDERLYING;
            jpg1.SetAbsolutePosition(150, 270);

            jpg1.ScaleAbsoluteHeight(250);
            jpg1.ScaleAbsoluteWidth(290);
            document.Add(jpg1);


            int pageN = writer.CurrentPageNumber;
            String pageText = "Page No. " + pageN.ToString();

            BaseFont bf = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            float len = bf.GetWidthPoint(pageText, 10);


            PdfPTable footerTbl = new PdfPTable(1);

            footerTbl.TotalWidth = document.PageSize.Width;

            Image logo = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath("/Styles/footer.png"));

            footerTbl.AddCell(logo);

            BaseFont btnDistributor = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1250, BaseFont.NOT_EMBEDDED);
            BaseFont btnDistributor1 = BaseFont.CreateFont(BaseFont.TIMES_BOLD, BaseFont.CP1250, BaseFont.NOT_EMBEDDED);
            iTextSharp.text.Font fntDistributor = new iTextSharp.text.Font(btnDistributor, 11, 2, BaseColor.RED);
            iTextSharp.text.Font fntHeader = new iTextSharp.text.Font(btnDistributor, 10, 1, BaseColor.BLACK);
            iTextSharp.text.Font fntBody = new iTextSharp.text.Font(btnDistributor, 10, 0, BaseColor.BLACK);

            PdfPTable detailsTable = new PdfPTable(6);
            if (pageN == 1)
            {
                detailsTable.TotalWidth = document.PageSize.Width - 15;


                PdfPCell cell10 = new PdfPCell();
                cell10.BackgroundColor = BaseColor.WHITE;
                cell10.AddElement(new Chunk("Date", fntHeader));
                detailsTable.AddCell(cell10);

                //PdfPCell cell2 = new PdfPCell();
                //cell2.BackgroundColor = BaseColor.WHITE;
                //cell2.AddElement(new Chunk("Name", fntHeader));
                //table.AddCell(cell2);

                PdfPCell cell2 = new PdfPCell();
                cell2.Colspan = 2;
                cell2.BackgroundColor = BaseColor.WHITE;
                cell2.AddElement(new Chunk("Particulars", fntHeader));
                detailsTable.AddCell(cell2);

                PdfPCell cell3 = new PdfPCell();
                cell3.BackgroundColor = BaseColor.WHITE;
                cell3.AddElement(new Chunk("Debit (Nrs.)", fntHeader));
                detailsTable.AddCell(cell3);

                PdfPCell cell4 = new PdfPCell();
                cell4.BackgroundColor = BaseColor.WHITE;
                cell4.AddElement(new Chunk("Credit (Nrs.)", fntHeader));
                detailsTable.AddCell(cell4);


                PdfPCell cell5 = new PdfPCell();
                cell5.BackgroundColor = BaseColor.WHITE;
                cell5.AddElement(new Chunk("Balance Amount", fntHeader));
                detailsTable.AddCell(cell5);

                //detailsTable.WriteSelectedRows(0, -1, 10, document.PageSize.Height - 103, writer.DirectContent);
            }


            PdfPCell cell = new PdfPCell(logo);

            cell.HorizontalAlignment = Element.ALIGN_RIGHT;


            footerTbl.AddCell(cell);

            footerTbl.WriteSelectedRows(0, -1, 0, document.PageSize.Height - 718, writer.DirectContent);

            cb.BeginText();
            cb.SetFontAndSize(bf, 7);
            cb.SetTextMatrix(540, 60);
            cb.ShowText(pageText);
            cb.EndText();
            PdfPTable headerTbl = new PdfPTable(1);

            headerTbl.TotalWidth = document.PageSize.Width;

            Image logo1 = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath("/Styles/Images/HeaderReceiptHolder.png"));

            logo1.ScaleAbsoluteWidth(document.PageSize.Width - 23);
            logo1.ScaleAbsoluteHeight(90);

            PdfPCell cell1 = new PdfPCell(logo1);

            cell1.HorizontalAlignment = Element.ALIGN_RIGHT;

            cell1.Border = 0;

            headerTbl.AddCell(cell1);

            headerTbl.WriteSelectedRows(0, -1, -10, (document.PageSize.Height - 10), writer.DirectContent);
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

            //headerTemplate.BeginText();
            //headerTemplate.SetFontAndSize(bf, 12);
            //headerTemplate.SetTextMatrix(0, 0);
            ////headerTemplate.AddImage();
            //// headerTemplate.ShowText((writer.PageNumber - 1).ToString());
            //headerTemplate.EndText();

            //footerTemplate.BeginText();
            //footerTemplate.SetFontAndSize(bf, 12);
            //footerTemplate.SetTextMatrix(0, 0);
            //footerTemplate.ShowText((writer.PageNumber - 1).ToString());
            //footerTemplate.SetTextMatrix(500, 250);
            //footerTemplate.EndText();
        }
    }
}