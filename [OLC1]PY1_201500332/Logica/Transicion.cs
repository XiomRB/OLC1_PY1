using _OLC1_PY1_201500332.Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _OLC1_PY1_201500332.Logica
{
    class Transicion
    {
        List<EstadoAFD> estados;
        public Transicion()
        {
            estados = new List<EstadoAFD>();
        }
        public void crearTransiciones(SubAFN afn,Stack<object[]>simbolos)
        {
            EstadoAFD nuevo = new EstadoAFD(0);
            nuevo.setCerradura(0);
            estados.Add(nuevo);
            for(int e = 0; e <estados.Count; e++)
            {
                for (int i = 0; i < estados[e].getCerraduras().Count; i++)
                {
                    Estado est = afn.getEstado(estados[e].getCerradura(i)); //entra al estado que indica la cerradura
                    foreach (TransicionThompson t in est.getTransiciones())
                    {
                        if (t.getFinal().getId().Equals(afn.getFinal().getId())) estados[e].setAcepta();
                        if (t.getLexema().Equals("ε") && !estados[e].encontrarC(t.getFinal().getId())) estados[e].setCerradura(t.getFinal().getId());
                        else if (!t.getLexema().Equals("ε"))
                        {
                            int m = encontrarMovimiento(t.getLexema(),estados[e]);
                            if(m == estados[e].getMovimiento().Count) //si el mover con dicho simbolo no existe
                            {
                                Movimiento mov = new Movimiento(t.getLexema(), encontrarSimbolo(simbolos, t.getLexema()));
                                mov.getMov().setCerradura(t.getFinal().getId());
                                mov.setMove(t.getFinal().getId());
                                estados[e].setMovimiento(mov);
                            }
                            else // si ya existe, se agrega a que otro estado se puede mover con la misma letra
                            {
                                estados[e].getMov(m).getMov().setCerradura(t.getFinal().getId());
                                estados[e].getMov(m).setMove(t.getFinal().getId());
                                estados[e].getMov(m).getMov().getCerraduras().Sort();
                            }
                            
                        }
                    }
                }
                estados[e].getCerraduras().Sort();
                int edo = encontrarEstado(estados[e].getCerraduras(), e);
                if (edo != e)
                {
                    estados.RemoveAt(e);
                    e--;
                }
                else
                {
                    for (int t = 0; t < estados[e].getMovimiento().Count; t++)
                    {
                        int m = encontrarMovEstado(estados[e].getMov(t).getMoves(), e);
                        if(m != -1)
                        {
                            estados[e].getMov(t).getMov().setId(m);
                        }
                        else
                        {
                            EstadoAFD n = estados[e].getMov(t).getMov();
                            n.setId(estados.Count);
                            estados.Add(n);
                        }
                    }
                }
                
                    

            }
        }
        public Token.TIPO encontrarSimbolo(Stack<object[]> simbolos, string simbolo)
        {
            int i = 0;
            while (i < simbolos.Count)
            {
                if (simbolos.ElementAt(i)[0].Equals(simbolo)) return (Token.TIPO)simbolos.ElementAt(i)[1];
                i++;
            }
            return Token.TIPO.DESCONOCIDO;
        }
        public int encontrarMovimiento(string lexema, EstadoAFD e)
        {
            int t = 0;
            while (t < e.getMovimiento().Count)
            {
                if (e.getMov(t).getId().Equals(lexema)) return t;
                t++;
            }
            return t;
        }
        public int encontrarEstado(List<int> cerradura,int est)
        {
            int e = 0;
            bool encontrado = false;
            while(e < est)
            {
                if(cerradura.Count == estados[e].getCerraduras().Count)
                {
                    int i = 0;
                    do
                    {
                        if (cerradura[i] == estados[e].getCerradura(i)) encontrado = true;
                        else encontrado = false;
                        i++;
                    } while (i < cerradura.Count && encontrado);
                }
                if (encontrado) return e;
                e++;
            }
            return e;
        }
        public int encontrarMovEstado(List<int> m,int e)
        {
            foreach(int n in m)
                Console.WriteLine(n);
            int i = 0;
            int j = 0;
            bool encontrado = false;
            while (i < e)
            {
                j = 0;
                while(j < estados[i].getMovimiento().Count)
                {
                    if(m.Count == estados[i].getMov(j).getMoves().Count)
                    {
                        int k = 0;
                        do
                        {
                            if (m[k] == estados[i].getMov(j).getMoves()[k]) encontrado = true;
                            else encontrado = false;
                            k++;
                        }
                        while (k < m.Count && encontrado);
                    }
                    if (encontrado) return estados[i].getMov(j).getMov().getId();
                    j++;
                }
                i++;
            }
            return -1;
        }
        public string dibujar()
        {
            string dibujo = " rankdir = LR;\n node[shape = circle];\n";
            foreach (EstadoAFD e in estados)
            {
                if (e.isAceptable()) dibujo += " S" + e.getId() + ", ";
            }
            dibujo = dibujo.Substring(0,dibujo.Length-2);
            dibujo += " [shape = doublecircle];\n";
            foreach(EstadoAFD e in estados)
                foreach(Movimiento m in e.getMovimiento())
                    dibujo += " S" + e.getId() + " -> S" + m.getMov().getId() + " [label = \"" + m.getId() + "\"];\n";
            return dibujo;
        }
    }
}
