using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;



namespace Common.PDF
{
    public class PDFEventsUtil : PdfPageEventHelper
    {
        protected BaseFont helv;
        protected DateTime PrintTime = DateTime.Now;
        protected PdfTemplate total;
        protected PdfContentByte cb;
        protected PdfContentByte cbLocal;
        public String Institucion { get; set; }
        public String Programa { get; set; }
        public String Dependencia { get; set; }
        public String Logo { get; set; }
        public String Titulo { get; set; }

        public override void OnOpenDocument(PdfWriter writer, Document document)
        {
            try
            {
                PrintTime = DateTime.Now;
                helv = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.WINANSI, BaseFont.NOT_EMBEDDED);
                cb = writer.DirectContent;
                cbLocal = writer.DirectContent;
                total = total = writer.DirectContent.CreateTemplate(100, 100);
            }
            catch (DocumentException de)
            {
                Console.Write(de);
            }
        }
        
        public override void OnStartPage(PdfWriter writer, Document document)
        {
            base.OnStartPage(writer, document);

            string html = "<html>"
                   + " <head>"
                    + "</head>"
                    + "<body>"

                        + "<table border=0>"
                            + "<tr>"
                                + "<td rowspan=\"2\">"
                                    + "<img src=\"" + Logo + "\" height=\"60px\" width=\"60px\" align=\"center\" />"
                                + "</td>"
                                + "<td colspan=\"6\">";
            if (Institucion.Length > 30)
            {
                html += "<p style=\"text-align: center; font-family: Arial, Helvetica, sans-serif; font-size:18; font-weight:bold;\">" + Institucion + "</p>";
            }
            else
            {
                html += "<p style=\"text-align: center; font-family: Arial, Helvetica, sans-serif; font-size:20; font-weight:bold;\">" + Institucion + "</p>";
            }                                   
                                html+= "</td>"
                                + "<td rowspan=\"2\">"                                   
                                + "</td>" 

                            +"</tr>"                       
                            + "<tr>"
                                + "<td colspan=\"6\">"
                                        + "<p style=\"text-align: center; font-family: Arial, Helvetica, sans-serif; font-size:13; \">" + Programa + "</p>"
                                + "</td>"
                            + "</tr>"
                            + "<tr>"
                                + "<td colspan=\"6\">"
                                        + "<p style=\"font-family: Arial, Helvetica, sans-serif; font-size:11; \">"  + Titulo + "</p>"
                                + "</td>"
                            + "</tr>"
                        +"</table>"
                    +"</body>"
                    +"</html>";

                
            foreach (IElement E in HTMLWorker.ParseToList(new StringReader(html), new StyleSheet()))
                document.Add(E);
        }

        public override void OnEndPage(PdfWriter writer, Document document)
        {
            base.OnEndPage(writer, document);
            
            cb.SaveState();
            cb.BeginText();
            cb.SetFontAndSize(helv, 10);

            float textSize = 60;
            float textBase = 15; // Este lo pone la informacion en la parte inferior
            
            
            float x = 365 - (Dependencia.Length/2)*8;           
            cb.SetTextMatrix(x, textBase); //Dependencia
            cb.ShowText(Dependencia);


            cb.SetFontAndSize(helv, 8);

            cb.SetTextMatrix(document.Left, textBase); //Fecha
            cb.ShowText(String.Format("{0}-{1}-{2}", PrintTime.Day, PrintTime.Month, PrintTime.Year));
            
            cb.SetTextMatrix(document.Right-textSize, textBase); //Numero de pagina
            cb.ShowText(String.Format("Página {0} de ", writer.PageNumber));
            cb.AddTemplate(total, document.Right-15, textBase);
            cb.EndText();

            //cb.SetRGBColorStroke(0x00, 0x00, 0x00);
            //cb.Rectangle(35, 10, 525, 20);
            //cb.Stroke();


            cb.MoveTo(90, 25); //Linea horizontal
            cb.LineTo(90, 10);           

            cb.MoveTo(490, 25); //Linea vertical 1
            cb.LineTo(490, 10);

            cb.MoveTo(35, 25); //Linea vertical 2
            cb.LineTo(560, 25);  


            cb.ClosePathStroke();

            cb.RestoreState();
        }

        public override void OnCloseDocument(PdfWriter writer, Document document)
        {
            base.OnCloseDocument(writer, document);
          
            total.BeginText();
            total.SetFontAndSize(helv, 8);
            total.SetTextMatrix(0, 0);
            total.ShowText((writer.PageNumber - 1).ToString());
            total.EndText();
        }
    }
}