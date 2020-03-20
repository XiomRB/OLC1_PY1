using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _OLC1_PY1_201500332.Logica
{
    class TransicionThompson
    {
        private Estado inicial;
        private Estado final;
        private string lexema;

        public TransicionThompson(Estado inicio, Estado final, string lexema)
        {
            this.inicial = inicio;
            this.final = final;
            this.lexema = lexema;
        }

        public void setInicio(Estado inicio)
        {
            this.inicial = inicio;
        }

        public void setFinal(Estado final)
        {
            this.final = final;
        }
        public Estado getInicio()
        {
            return this.inicial;
        }

        public Estado getFinal()
        {
            return this.final;
        }

        public string getLexema()
        {
            return this.lexema;
        }
    }
}
