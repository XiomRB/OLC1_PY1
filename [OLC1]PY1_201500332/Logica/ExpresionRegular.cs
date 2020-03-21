using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _OLC1_PY1_201500332.Logica
{
    class ExpresionRegular
    {
        string id;
        ArrayList lista;
        public ExpresionRegular(string id, ArrayList lista)
        {
            this.id = id;
            this.lista = lista;
        }
        public void setElemento(string el)
        {
            this.lista.Add(el);
        }
        public string getElemento(int i)
        {
            return (string)this.lista[i];
        }
        public ArrayList getLista()
        {
            return this.lista;
        }
        public string getId()
        {
            return this.id;
        }
    }
}
