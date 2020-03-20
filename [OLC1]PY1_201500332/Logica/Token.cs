using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _OLC1_PY1_201500332.Logica
{
    class Token
    {
        private int linea;
        private int columna;
        private string lexema;
        private TIPO tipo;

        public Token(int linea, int columna, string lexema, TIPO tipo)
        {
            this.linea = linea;
            this.columna = columna;
            this.lexema = lexema;
            this.tipo = tipo;
        }

        public int getLinea()
        {
            return this.linea;
        }

        public int getColumna()
        {
            return this.columna;
        }

        public TIPO getTipo()
        {
            return this.tipo;
        }

        public string getLexema()
        {
            return this.lexema;
        }

        public enum TIPO
        {
            PR_CONJ, 
            CONJ,
            IDENTIFICADOR,
            CONCATENACION,
            OR,
            CERRADURAPOSITIVA,
            CERRADURAKLEENE,
            INTERROGACION,
            CADENA,
            TODO,
            TAB,
            ENTER,
            COMILLA,
            APOSTROFE,
            DOSPUNTOS,
            COMA,
            PUNTOCOMA,
            FLECHA,
            LLAVEABRE,
            LLAVECIERRA,
            COMENTMULTI,
            COMENTLINEA,
            DESCONOCIDO
        }

        public string stringtipo()
        {
            switch (tipo)
            {
                case TIPO.APOSTROFE:
                    return "APOSTROFE";
                case TIPO.CADENA:
                    return "CADENA";
                case TIPO.CERRADURAKLEENE:
                    return "CERRADURA DE KLEENE";
                case TIPO.CERRADURAPOSITIVA:
                    return "CERRADURA POSITIVA";
                case TIPO.COMENTLINEA:
                    return "COMENTARIO LINEA";
                case TIPO.COMENTMULTI:
                    return "COMENTARIO MULTILINEA";
                case TIPO.COMILLA:
                    return "COMILLA";
                case TIPO.CONCATENACION:
                    return "CONCATENACION";
                case TIPO.CONJ:
                    return "CONJUNTO";
                case TIPO.DOSPUNTOS:
                    return "DOS PUNTOS";
                case TIPO.ENTER:
                    return "SALTO DE LINEA";
                case TIPO.FLECHA:
                    return "FLECHA";
                case TIPO.IDENTIFICADOR:
                    return "IDENTIFICADOR";
                case TIPO.INTERROGACION:
                    return "UNA O 0 VECES";
                case TIPO.LLAVEABRE:
                    return "LLAVE ABRE";
                case TIPO.LLAVECIERRA:
                    return "LLAVE CIERRA";
                case TIPO.OR:
                    return "OR";
                case TIPO.PR_CONJ:
                    return "PR CONJ";
                case TIPO.PUNTOCOMA:
                    return "PUNTO Y COMA";
                case TIPO.TAB:
                    return "TABULACION";
                case TIPO.TODO:
                    return "TODO";
                case TIPO.COMA:
                    return "COMA";
                default:
                    return "DESCONOCIDO";
            }
        }
    }
}
