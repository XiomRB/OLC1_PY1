using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _OLC1_PY1_201500332.Logica
{
    class TransicionThompson
    {
        private Estado edoinicial;
        private Estado edofinal;
        private string lexema;

        public TransicionThompson(Estado inicio, Estado final, string lexema)
        {
            this.edoinicial = inicio;
            this.edofinal = final;
            this.lexema = lexema;
        }
        public void setInicio(Estado inicio)
        {
            this.edoinicial = inicio;
        }
        public void setFinal(Estado final)
        {
            this.edofinal = final;
        }
        public Estado getInicio()
        {
            return this.edoinicial;
        }
        public Estado getFinal()
        {
            return this.edofinal;
        }
        public string getLexema()
        {
            return this.lexema;
        }
    }
}
