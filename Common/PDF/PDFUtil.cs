using System;

//importamos 
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;
using System.IO;
using System.Collections.Generic;

namespace Common.PDF
{
    public class PDFUtil 
    {
        private Document documento;
        public Document Documento
        {
            get
            {
                if (documento == null)
                {
                    //creamos el Documentoo
                    //...ahora configuramos para que el tamaño de hoja sea A4
                    documento = new Document(iTextSharp.text.PageSize.A4);
                    return documento;
                }
                else
                    return documento;
            }
        }

        private String institucion;
        public String Institucion
        {
            get
            {
                return institucion;
            }

            set
            {
                institucion = value;
            }
        }

        private String programa;
        public String Programa
        {
            get
            {
                return programa;
            }

            set
            {
                programa = value;
            }
        }

        private String dependencia;
        public String Dependencia
        {
            get
            {
                return dependencia;
            }

            set
            {
                dependencia = value;
            }
        }

        private String logo;
        public String Logo
        {
            get
            {
                return logo;
            }

            set
            {
                logo = value;
            }
        }

        private String titulo = "";
        public String Titulo
        {
            get
            {
                return titulo;
            }

            set
            {
                titulo = value;
            }
        }

        public void InicializarPDF(string path)
        {
            PDFEventsUtil ev = new PDFEventsUtil();

            //Documento.PageSize.BackgroundColor= new iTextSharp.text.Color(255, 255,255);
            try
            {
                Documento.PageSize.Rotate();


                //...definimos el autor del Documentoo.
                Documento.AddAuthor("CertuIT Consultores S.C.");

                //...el creador, que será el mismo eh!
                Documento.AddCreator("CertuIT Consultores S.C.");

                //hacemos que se inserte la fecha de creación para el Documentoo
                Documento.AddCreationDate();
                //...título

                Documento.AddTitle("Ficha Técnica");
                //... el asunto

                //Documento.AddSubject("Este es un paso muy important");
                //... palabras claves
                Documento.AddKeywords("pdf, PdfWriter; Documento; iTextSharp");
                //creamos un instancia del objeto escritor de Documentoo

                //string ruta = Server.MapPath(path);
                string ruta = path;
                PdfWriter writer = PdfWriter.GetInstance(Documento, new System.IO.FileStream(ruta, System.IO.FileMode.Create));

                //encriptamos el pdf, dándole como clave de usuario "key" y la clave del dueño será "owner"
                //si quitas los comentarios (en writer.SetEncryption...), entonces el Documentoo generado
                //no mostrarà tanto la información de autor, titulo, fecha de creacion... 
                //que habiamos establecio más arriba. y sólo podrás abrirlo con una clave

                //writer.SetEncryption(PdfWriter.STRENGTH40BITS,"key","owner", PdfWriter.CenterWindow);

                //definimos la manera de inicialización de abierto del Documentoo.
                //esto, hará que veamos al inicio, todas la páginas del Documentoo
                //en la parte izquierda
                //writer.ViewerPreferences = PdfWriter.PageModeUseThumbs;


                //con esto conseguiremos que el Documentoo sea presentada de dos en dos 
                //writer.ViewerPreferences = PdfWriter.PageLayoutTwoColumnLeft;

                writer.PageEvent = ev;
                ev.Logo = Logo;
                ev.Institucion = Institucion; // "UNIVERSIDAD AUTÓNOMA DE SINALOA";
                ev.Dependencia = Dependencia; // "Dirección General de Planeación y Desarrollo";
                ev.Programa = Programa; // "Sistema Institucional de Indicadores";
                ev.Titulo = Titulo;
                //con esto podemos oculta las barras de herramienta y de menú respectivamente.
                //(quite las dos barras de comentario de la siguiente línea para ver los efectos)
                //PdfWriter.HideToolbar | PdfWriter.HideMenubar

                //abrimos el Documentoo para agregarle contenido
                Documento.Open();
            }
            catch (DocumentException docEx)
            {
                Documento.Close();
                Console.Write(docEx);
            }
        }

        public void TerminarPDF()
        {
            if (Documento.IsOpen()) //esto es importante, pues si no cerramos el Documento entonces no se creara el pdf.
                Documento.Close();
        }

        public void TituloTabla(string texto, string colorEncabezado, string colorFuente)
        {
            string html = "<html>"
            + " <head>"
            + "</head>"
            + "<body>"
            + "<table border=\"1\" bgcolor= " + colorEncabezado + " width=100% bordercolor=blue>"
            + "<tr>"
            + "<td>"
            + "<p style=\"text-align: center; color: " + colorFuente + " ; font-family: Arial, Helvetica, sans-serif; font-size: medium; font-weight:bold;\">" + texto + "</p>"
            + "</td>"
            + "</tr>"
            + "</table>"
            + "</body>"
            + "</html>";

            foreach (IElement E in HTMLWorker.ParseToList(new StringReader(html), new StyleSheet()))
                Documento.Add(E);
        }

        public void IngresarCampos(string concepto, string descripcion)
        {
            string html = "<html>"
            + " <head>"
            + "</head>"
            + "<body>"
            + "<table border=\"1\" width=100% bordercolor=#0859C2>"
            + "<tr>"
            + "<td >"
            + "<p style=\"text-align: left; font-size: 9; font-family: Arial, Helvetica, sans-serif; font-weight:bold;\">  " + concepto + "</p>"
            + "</td>"

            + "<td colspan=3 width=100% align=justify >"
            + "<p style=\"font-size: 8; font-family: Arial, Helvetica, sans-serif;\">" + descripcion + "</p>"
            + "</td>"
            + "</tr>"
            + "</table>"
            + "</body>"
            + "</html>";

            foreach (IElement E in HTMLWorker.ParseToList(new StringReader(html), new StyleSheet()))
                Documento.Add(E);
        }

        public void IngresarCampos(string concepto, List<string> lista)
        {
            string tabla = "<table border=\"0\" width=100%>";

            for (int x = 0; x < lista.Count; x++)
            {
                float aux = x % 2;
                if (aux == 0)
                {
                    tabla += "<tr bgcolor= #FFFFCC>";
                }
                else
                {
                    tabla += "<tr bgcolor= #F3F3F3>";
                }
                tabla += "<td>"
                + "<p style=\"text-align: left; font-size: 8; font-family: Arial, Helvetica, sans-serif; font-weight:bold;\">" + lista[x] + "</p>"
                + "</td>"
                + "</tr>";
            }
            tabla += "</table>";

            string html = "<html>"
            + " <head>"
            + "</head>"
            + "<body>"
            + "<table border=\"1\" width=100%>"
            + "<tr>"
            + "<td>"
            + "<p style=\"text-align: left; font-size: 9; font-family: Arial, Helvetica, sans-serif; font-weight:bold;\">" + concepto + "</p>"
            + "</td>"

            + "<td colspan=3>"
            + tabla
            + "</td>"
            + "</tr>"
            + "</table>"
            + "</body>"
            + "</html>";

            foreach (IElement E in HTMLWorker.ParseToList(new StringReader(html), new StyleSheet()))
                Documento.Add(E);
        }

        public void IngresarCampos(string concepto, List<string> abreviaciones, List<string> descripciones)
        {
            string tabla = "<table border=\"0\" width=100%>";

            for (int x = 0; x < abreviaciones.Count; x++)
            {
                float aux = x % 2;
                if (aux == 0)
                {
                    tabla += "<tr bgcolor= #FFFFCC>";
                }
                else
                {
                    tabla += "<tr bgcolor= #F3F3F3>";
                }
                tabla += "<td>"
                + "<p style=\"text-align: left; font-size: 8; font-family: Arial, Helvetica, sans-serif; font-weight:bold;\">" + abreviaciones[x] + "</p>"
                + "</td>"

                + "<td colspan=4>"

                + "<p style=\"font-size: 8; font-family: Arial, Helvetica, sans-serif;\">" + descripciones[x] + "</p>"
                + "</td>"
                + "</tr>";
            }
            tabla += "</table>";

            string html = "<html>"
            + " <head>"
            + "</head>"
            + "<body>"
            + "<table border=\"1\" width=100%>"
            + "<tr>"
            + "<td>"
            + "<p style=\"text-align: left; font-size: 9; font-family: Arial, Helvetica, sans-serif; font-weight:bold;\">" + concepto + "</p>"
            + "</td>"

            + "<td colspan=3>"
            + tabla
            + "</td>"
            + "</tr>"
            + "</table>"
            + "</body>"
            + "</html>";

            foreach (IElement E in HTMLWorker.ParseToList(new StringReader(html), new StyleSheet()))
                Documento.Add(E);
        }

        public void DefinicionConceptos(string titulo, List<string> conceptos, List<string> descripciones)
        {
            string tabla = "<table border=\"0\" width=100%>";

            for (int x = 0; x < conceptos.Count; x++)
            {
                float aux = x % 2;
                if (aux == 0)
                {
                    tabla += "<tr bgcolor= #FFFFCC>";
                }
                else
                {
                    tabla += "<tr bgcolor= #F3F3F3>";
                }
                tabla += "<td width=100% align=justify >"
                + "<p style=\"text-align: left; font-size: 8; font-family: Arial, Helvetica, sans-serif; font-weight:bold;\">" + conceptos[x] + " </p>"
                + "<p style=\"font-size: 8; font-family: Arial, Helvetica, sans-serif;\">" + descripciones[x] + "</p>"
                + "</td>"
                + "</tr>";
            }
            tabla += "</table>";

            string html = "<html>"
            + " <head>"
            + "</head>"
            + "<body>"
            + "<table border=\"1\" width=100%>"
            + "<tr>"
            + "<td>"
            + " <p style=\"text-align: left; font-size: 10; font-family: Arial, Helvetica, sans-serif; font-weight:bold;\">  " + titulo + "</p>"
            + tabla
            + "</td>"
            + "</tr>"
            + "</table>"
            + "</body>"
            + "</html>";

            foreach (IElement E in HTMLWorker.ParseToList(new StringReader(html), new StyleSheet()))
                Documento.Add(E);
        }
    }
}
