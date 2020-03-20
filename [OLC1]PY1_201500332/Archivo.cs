using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace _OLC1_PY1_201500332
{
    class Archivo
    {
        public string guardarArchivo(string ruta,string texto)
        {
            StreamWriter guardado = new StreamWriter(ruta);
            try
            {
                guardado.Write(texto);
                return "Archivo guardado";
            }
            catch
            {
                return "Error al guardar el archivo";
            }
            finally
            {
                guardado.Close();
            }
            
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
    }
}
