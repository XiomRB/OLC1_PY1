using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _OLC1_PY1_201500332.Logica
{
    class Estado
    {
        private int id;
        private List<TransicionThompson> transiciones  = new List<TransicionThompson>();

        public Estado(int id, List<TransicionThompson> transiciones)
        {
            this.id = id;
            this.transiciones = transiciones;
        }

        public Estado(int id)
        {
            this.id = id;
        }

        public void setTransicion(TransicionThompson transicion)
        {
            this.transiciones.Add(transicion);
        }

        public void setId(int id)
        {
            this.id = id;
        }
        public List<TransicionThompson> getTransiciones()
        {
            return this.transiciones;
        }
        public void setTransiciones(List<TransicionThompson> transiciones)
        {
            this.transiciones = transiciones;
        }
        public int getId()
        {
            return this.id;
        }
    }
}
