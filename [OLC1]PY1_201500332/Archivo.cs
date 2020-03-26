using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using _OLC1_PY1_201500332.Logica;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Collections;
using System.Xml;

namespace _OLC1_PY1_201500332
{
    class Archivo
    {
        public string guardarArchivo(string ruta,string texto)
        {
            StreamWriter guardado = new StreamWriter(ruta);
            try {
                guardado.Write(texto);
                return "Archivo guardado";
            }
            catch{
                return "Error al guardar el archivo";
            }
            finally {guardado.Close();}
        }
        public string abrirArchivo(string ruta)
        {
            StreamReader lectura = new StreamReader(ruta);
            string texto = "";
            try
            {
                texto = lectura.ReadToEnd();
            }
            catch
            {
                texto = "Error al leer el archivo";
            }
            finally
            {
                lectura.Close();
            }
            return texto;
        }
        public string graficar(string tipo,string nombre, string graph)
        {
            string ruta = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            string resultado = "no exito";
            string rdot = ruta + "\\ArchivosOLC1PY1\\" + tipo + "\\" + nombre + ".dot";
            string rpng = ruta + "\\ArchivosOLC1PY1\\" + tipo + "\\" + nombre + ".png";
            string dibujo = "digraph G{ \n";
            dibujo += graph;
            dibujo += "}";
            string retorno = this.guardarArchivo(rdot, dibujo);
            if(retorno.Equals("Archivo guardado"))
            {
                try
                {
                    ProcessStartInfo p = new ProcessStartInfo("dot.exe");
                    p.WorkingDirectory = @"C:\Program Files (x86)\Graphviz2.38\bin";
                    p.WindowStyle = ProcessWindowStyle.Normal;
                    p.RedirectStandardOutput = true;
                    p.UseShellExecute = false;
                    p.CreateNoWindow = true;
                    p.WindowStyle = ProcessWindowStyle.Hidden;
                    p.Arguments = "-Tpng \"" + rdot + "\" -o \"" + rpng + "\"";
                    Process.Start(p);
                    resultado = "exito";
                }
                catch (Exception e){ resultado = e.Message; }
            }
            return resultado;
        }
        public void generarPDF(ArrayList errores)
        {
            string ruta = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            FileStream fs = new FileStream(ruta + "/ArchivosOLC1PY1/reporteLexico.pdf",FileMode.Create);
            Document doc = new Document(iTextSharp.text.PageSize.LETTER,0,0,0,0);
            PdfWriter escrito = PdfWriter.GetInstance(doc, fs);
            doc.Open();
            PdfPTable tabla = new PdfPTable(4);
            doc.Add(new Paragraph("          REPORTE DE ERRORES LEXICOS"));
            tabla.AddCell(new Paragraph("TOKEN"));
            tabla.AddCell(new Paragraph("LINEA"));
            tabla.AddCell(new Paragraph("COLUMNA"));
            tabla.AddCell(new Paragraph("TIPO"));
            foreach (Token t in errores)
            {
                tabla.AddCell(new Paragraph(t.getLexema()));
                tabla.AddCell(new Paragraph(t.getLinea().ToString()));
                tabla.AddCell(new Paragraph(t.getColumna().ToString()));
                tabla.AddCell(new Paragraph(t.getTipo().ToString()));
            }
            doc.Add(tabla);
            doc.Close();
        }
        public void generarXMLTok(ArrayList cadena, ExpresionRegular exp ,string arch)
        {
            XmlDocument doc = new XmlDocument();
            XmlElement lista = doc.CreateElement("ListaTokens");
            doc.AppendChild(lista);
            XmlElement token;
            XmlElement nombre;
            XmlElement valor;
            XmlElement fila;
            XmlElement columna;
            foreach (CadenaAValidar c in cadena)
            {
                if (c.getId().Equals(exp.getId()))
                {
                    foreach(Token t in c.tokens)
                    {
                        token = doc.CreateElement("Token");
                        lista.AppendChild(token);
                        nombre = doc.CreateElement("NombreToken");
                        nombre.AppendChild(doc.CreateTextNode(t.getTipo().ToString()));
                        token.AppendChild(nombre);
                        valor = doc.CreateElement("Valor");
                        valor.AppendChild(doc.CreateTextNode(t.getLexema()));
                        token.AppendChild(valor);
                        fila = doc.CreateElement("Fila");
                        fila.AppendChild(doc.CreateTextNode(t.getLinea().ToString()));
                        token.AppendChild(fila);
                        columna = doc.CreateElement("Columna");
                        columna.AppendChild(doc.CreateTextNode(t.getColumna().ToString()));
                        token.AppendChild(columna);
                    }
                }
            }
            doc.Save("C:\\Users\\Oliveira Raymundo\\Desktop\\ArchivosOLC1PY1\\XML\\" + arch + ".xml");
        }
        public void generarXMLFail(ArrayList cadena, ExpresionRegular exp, string arch)
        {
            XmlDocument doc = new XmlDocument();
            XmlElement lista = doc.CreateElement("ListaTokens");
            doc.AppendChild(lista);
            XmlElement token;
            XmlElement valor;
            XmlElement fila;
            XmlElement columna;
            foreach (CadenaAValidar c in cadena)
            {
                if (c.getId().Equals(exp.getId()))
                {
                    foreach(Token t in c.errores)
                    {
                        token = doc.CreateElement("Token");
                        lista.AppendChild(token);
                        valor = doc.CreateElement("Valor");
                        valor.AppendChild(doc.CreateTextNode(t.getLexema()));
                        token.AppendChild(valor);
                        fila = doc.CreateElement("Fila");
                        fila.AppendChild(doc.CreateTextNode(t.getLinea().ToString()));
                        token.AppendChild(fila);
                        columna = doc.CreateElement("Columna");
                        columna.AppendChild(doc.CreateTextNode(t.getColumna().ToString()));
                        token.AppendChild(columna);
                    }
                }
            }
            doc.Save("C:\\Users\\Oliveira Raymundo\\Desktop\\ArchivosOLC1PY1\\XML\\" + arch + ".xml");
        }
    }
}
