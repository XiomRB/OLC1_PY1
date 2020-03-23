using System;
using System.Collections;
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
                Console.WriteLine(aux.getId().ToString());
                kleene.setEstado(aux);
            }
            Estado fin = new Estado(tam + 1);
            kleene.setEstado(fin);
            kleene.setFinal(fin);
            Estado inibasico = basico.getInicial();
            Estado finbasico = basico.getFinal();
            //verificar
            inicio.setTransicion(new TransicionThompson(inicio, inibasico, "ε"));
            inicio.setTransicion(new TransicionThompson(inicio, fin, "ε"));
            finbasico.setTransicion(new TransicionThompson(finbasico, inibasico, "ε"));
            finbasico.setTransicion(new TransicionThompson(finbasico, fin, "ε"));
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
        public SubAFN crearPositiva(SubAFN basico)
        {
            SubAFN b1 = new SubAFN();
            foreach(Estado e in basico.getEstados())
            {
                int en = e.getId();
                Estado aux = new Estado(en);
                foreach(TransicionThompson t in e.getTransiciones())
                {
                    int ti = t.getInicio().getId();
                    Estado temp = new Estado(ti);
                    int tf = t.getFinal().getId();
                    Estado temp1 = new Estado(tf);
                    string l = t.getLexema();
                    aux.setTransicion(new TransicionThompson(temp, temp1, l));
                }
                b1.setEstado(aux);
            }
            b1.setInicial(b1.getEstado(0));
            b1.setFinal(b1.getEstado(b1.getEstados().Count - 1));
            SubAFN kleene = this.crearKleene(basico);
            return this.crearConcatenacion(b1, kleene);
        }

        public SubAFN crearUnaoNinguna(SubAFN basico)
        {
            SubAFN ningun = this.crearBasico("ε");
            return this.crearOr(basico, ningun);
        }
        public SubAFN crearAFN(Stack<Object[]> p, Stack<object[]> simbolos)
        {
            Stack<SubAFN> pila = new Stack<SubAFN>();
            while (p.Count != 0)
            {
                Object[] simbolo = p.Pop();
                Token.TIPO tipo = (Token.TIPO)simbolo[1];
                switch (tipo)
                {
                    case Token.TIPO.CADENA:
                    case Token.TIPO.TODO:
                    case Token.TIPO.CONJ:
                    case Token.TIPO.TAB:
                    case Token.TIPO.ENTER:
                    case Token.TIPO.COMILLA:
                    case Token.TIPO.APOSTROFE:
                        simbolos.Push(simbolo);
                        pila.Push(this.crearBasico((string)simbolo[0]));
                        break;
                    case Token.TIPO.CONCATENACION:
                        pila.Push(this.crearConcatenacion(pila.Pop(),pila.Pop()));
                        break;
                    case Token.TIPO.OR:
                        pila.Push(this.crearOr(pila.Pop(),pila.Pop()));
                        break;
                    case Token.TIPO.CERRADURAKLEENE:
                        pila.Push(this.crearKleene(pila.Pop()));
                        break;
                    case Token.TIPO.CERRADURAPOSITIVA:
                        pila.Push(this.crearPositiva(pila.Pop()));
                        break;
                    case Token.TIPO.INTERROGACION:
                        pila.Push(this.crearUnaoNinguna(pila.Pop()));
                        break;
                }
            }
            return pila.Peek();
        }
    }
}
