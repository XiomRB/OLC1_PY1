using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _OLC1_PY1_201500332.Logica
{
    class SubAFN
    {
        private Estado inicial;
        private Estado final;
        private ArrayList estados = new ArrayList();

        public SubAFN()
        {
            this.estados = new ArrayList();
        }

        public Estado getInicial()
        {
            return this.inicial;
        }
        public Estado getFinal()
        {
            return this.final;
        }
        public Estado getEstado(int indice)
        {
            return (Estado) this.estados[indice];
        }
        public ArrayList getEstados()
        {
            return this.estados;
        }
        public void setInicial(Estado inicio)
        {
            this.inicial = inicio;
        }
        public void setFinal(Estado fin)
        {
            this.final = fin;
        }
        public void setEstado(Estado estado)
        {
            this.estados.Add(estado);
        }
    }

    
}
