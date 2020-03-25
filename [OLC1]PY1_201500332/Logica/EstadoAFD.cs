using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _OLC1_PY1_201500332.Logica
{
    class EstadoAFD
    {
        int id;
        List<int> cerradura;
        List<Movimiento> movimientos;
        bool acepta;
        public EstadoAFD(int id)
        {
            this.id = id;
            cerradura = new List<int>();
            movimientos = new List<Movimiento>();
        }
        public void setCerradura(int c)
        {
            cerradura.Add(c);
        }
        public void setMovimiento(Movimiento mov)
        {
            movimientos.Add(mov);
        }
        public int getCerradura(int c)
        {
            return cerradura[c];
        }
        public List<int> getCerraduras()
        {
            return cerradura;
        }
        public Movimiento getMov(int m)
        {
            return movimientos[m];
        }
        public List<Movimiento> getMovimiento()
        {
            return movimientos;
        }
        public void setAcepta()
        {
            this.acepta = true;
        }
        public bool isAceptable()
        {
            return acepta;
        }
        public void setId(int id)
        {
            this.id = id;
        }
        public int getId()
        {
            return id;
        }
        public bool encontrarC(int c)
        {
            int i = 0;
            while (i < cerradura.Count)
            {
                if (c == cerradura[i]) return true;
                i++;
            }
            return false;
        }
    }
}
