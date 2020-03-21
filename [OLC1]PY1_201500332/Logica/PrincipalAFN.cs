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
        public SubAFN crearConcatenacion(SubAFN basico1, SubAFN basico2)
        {
            SubAFN concatenacion = new SubAFN();
            int e = 0;
            for(e = 0; e < basico1.getEstados().Count-1; e++)
            {
                Estado aux = (Estado)basico1.getEstado(e);
                aux.setId(e);
                if (e == 0) concatenacion.setInicial(aux);
                concatenacion.setEstado(aux);
            }
            for(int i = 0; i<basico2.getEstados().Count; i++)
            {
                Estado aux = (Estado)basico2.getEstado(i);
                aux.setId(e);
                if (i == basico2.getEstados().Count - 1) concatenacion.setFinal(aux);
                concatenacion.setEstado(aux);
                e++;
            }
            return concatenacion;
        }
        public SubAFN crearOr(SubAFN basico1,SubAFN basico2)
        {
            SubAFN or = new SubAFN();
            Estado inicial = new Estado(0);
            inicial.setTransicion(new TransicionThompson(inicial, basico1.getInicial(), "ε"));
            inicial.setTransicion(new TransicionThompson(inicial, basico2.getInicial(), "ε"));
            or.setEstado(inicial);
            or.setInicial(inicial);
            int e = 0;
            int basico1tam = basico1.getEstados().Count;
            int basico2tam = basico2.getEstados().Count;
            for (e = 0; e< basico1tam; e++)
            {
                Estado aux = (Estado)basico1.getEstado(e);
                aux.setId(e + 1);
                or.setEstado(aux);
            }
            for(int i = 0; i < basico2tam; i++)
            {
                Estado aux = (Estado)basico2.getEstado(i);
                aux.setId(e + 1);
                or.setEstado(aux);
                e++;
            }
            Estado final = new Estado(basico1tam + basico2tam + 1);
            or.setFinal(final);
            or.setEstado(final);

            Estado basico1fin = basico1.getFinal();
            Estado basico2fin = basico2.getFinal();
            basico1fin.setTransicion(new TransicionThompson(basico1fin, final,"ε"));
            basico2fin.setTransicion(new TransicionThompson(basico2fin, final, "ε"));
            return or;
        }
        public SubAFN crearPositiva(string simbolo)
        {
            SubAFN kleene = this.crearKleene(this.crearBasico(simbolo));
            return this.crearConcatenacion(this.crearBasico(simbolo), kleene);
        }

        public SubAFN crearUnaoNinguna(SubAFN basico)
        {
            SubAFN ningun = this.crearBasico("ε");
            return this.crearOr(basico, ningun);
        }
    }
}
