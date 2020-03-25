using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _OLC1_PY1_201500332.Logica
{
    class Movimiento
    {
        string id;
        List<int> mueve;
        Token.TIPO tipo;
        EstadoAFD edomov;
        public Movimiento(string id, Token.TIPO tipo)
        {
            this.id = id;
            this.tipo = tipo;
            mueve = new List<int>();
            edomov = new EstadoAFD(-1);
        }
        public void setEdoMov(EstadoAFD mov)
        {
            this.edomov = mov;
        }
        public string getId()
        {
            return this.id;
        }
        public Token.TIPO getTipo()
        {
            return this.tipo;
        }
        public EstadoAFD getMov()
        {
            return this.edomov;
        }
        public List<int> getMoves()
        {
            return this.mueve;
        }
        public void setMove(int move)
        {
            mueve.Add(move);
            mueve.Sort();
        }
    }
}
