using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _OLC1_PY1_201500332.Logica
{
    class CadenaAValidar
    {
        private string id;
        private string cadena;
        public CadenaAValidar(string id, string cadena)
        {
            this.id = id;
            this.cadena = cadena;
        }
        public string getId()
        {
            return this.id;
        }
        public string getCadena()
        {
            return this.cadena;
        }
    }
}
