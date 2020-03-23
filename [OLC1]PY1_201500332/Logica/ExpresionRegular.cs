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
        private string id;
        public Stack<object[]> simbolos;
        private SubAFN afn;
        public ExpresionRegular(string id)
        {
            this.id = id;
            this.simbolos = new Stack<object[]>();
            this.afn = new SubAFN();
        }
        public string getId()
        {
            return this.id;
        }
        public void setAFN(SubAFN afn)
        {
            this.afn = afn;
        }
        public SubAFN getAFN()
        {
            return this.afn;
        }
    }
}
