using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _OLC1_PY1_201500332.Logica
{
    class PrincipalAFN
    {
        public SubAFN crearBasico(string simbolo)
        {
            SubAFN basico = new SubAFN();
            Estado ini = new Estado(0);
            Estado fin = new Estado(1);
            TransicionThompson transicion = new TransicionThompson(ini, fin, simbolo);
            ini.setTransicion(transicion);
            basico.setEstado(ini);
            basico.setEstado(fin);
            basico.setInicial(ini);
            basico.setFinal(fin);
            return basico;
        }

        public SubAFN crearKleene(SubAFN basico)
        {
            int tam = basico.getEstados().Count;
            SubAFN kleene = new SubAFN();
            Estado inicio = new Estado(0);
            kleene.setEstado(inicio);
            kleene.setInicial(inicio);
            for(int i = 0; i < tam; i++)
            {
                Estado aux = (Estado)basico.getEstado(i);
                aux.setId(i + 1);
                kleene.setEstado(aux);
            }
            Estado fin = new Estado(tam + 1);
            kleene.setEstado(fin);
            kleene.setFinal(fin);
            Estado inibasico = basico.getInicial();
            Estado finbasico = basico.getFinal();
            //verificar
            inicio.setTransicion(new TransicionThompson(inicio, inibasico, "ε"));
            inicio.setTransicion(new TransicionThompson(inicio, fin,"ε"));
            finbasico.setTransicion(new TransicionThompson(finbasico, inibasico,"ε"));
            finbasico.setTransicion(new TransicionThompson(finbasico, fin,"ε"));
            return kleene;

        }
    }
}
