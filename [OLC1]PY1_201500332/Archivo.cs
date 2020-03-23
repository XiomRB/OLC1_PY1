using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

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
    }
}
