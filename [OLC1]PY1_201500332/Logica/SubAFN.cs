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
        private List<Estado> estados = new List<Estado>();
        PrincipalAFN principal = new PrincipalAFN();

        public SubAFN()
        {
            this.estados = new List<Estado>();
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
        public List<Estado> getEstados()
        {
            return this.estados;
        }
        public void setEstados(List<Estado> estados)
        {
            this.estados = estados;
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

        public string dibujar()
        {
            string dibujo = " rankdir = LR;\n  node[shape = circle];\n ";
            dibujo += this.getFinal().getId() + " [shape = doublecircle] " + ";\n";
            foreach (Estado e in this.estados)
                foreach (TransicionThompson t in e.getTransiciones())
                    dibujo +=" " + t.getInicio().getId() + " -> " + t.getFinal().getId() + "[label = \"" + t.getLexema() + "\"];\n";
            return dibujo;
        }
    }

    
}
