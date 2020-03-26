using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _OLC1_PY1_201500332.Logica
{
    class Ejecutar
    {
        public ArrayList expresiones;
        public ArrayList conjuntos;
        public ArrayList cadenas;

        public Ejecutar()
        {
            this.expresiones = new ArrayList();
            this.conjuntos = new ArrayList();
            this.cadenas = new ArrayList();
        }
        public void crearAFD()
        {
            foreach(ExpresionRegular exp in expresiones)
                exp.afd.crearTransiciones(exp.getAFN(),exp.simbolos);
        }
        public string validarLexema(CadenaAValidar cadena)
        {
            ExpresionRegular exp = buscarExp(cadena.getId());
            string valida = "Cadena Valida";
            int estado = 0;
            int edoant = 0;
            string tok = "";
            char c;
            string aux;
            string cad = cadena.getCadena() + "¿";
            for(int i = 0; i < cad.Length; i++)
            {
                c = cad.ElementAt(i);
                int j = 0;
                if(c == '¿' && i == cad.Length - 1)
                {
                    if (exp.afd.getEstado(estado).isAceptable()) cadena.tokens.Add(new Token(0, i, tok, Token.TIPO.CADENA));
                    else cadena.errores.Add(new Token(0, i, tok, Token.TIPO.DESCONOCIDO));
                    tok = "";
                    if (i < cad.Length - 1 || estado == 0) i--;
                    estado = 0;
                }
                else
                {
                    bool val = false;
                    while (j < exp.afd.getEstado(estado).getMovimiento().Count)
                    {
                        Movimiento mov = exp.afd.getEstado(estado).getMov(j);
                        if (mov.getTipo() == Token.TIPO.TODO)
                        {
                            aux = cad.Substring(i, mov.getId().Length);
                            if (aux.Equals(mov.getId()))
                            {
                                edoant = estado;
                                estado = mov.getMov().getId();
                                i += mov.getId().Length - 1;
                                tok += aux;
                                val = true;
                                break;
                            }
                        }
                        else if (mov.getTipo() == Token.TIPO.CONJ)
                        {
                            if (mov.getId().Length == 1)
                            {
                                if (c.ToString() == mov.getId())
                                {
                                    edoant = estado;
                                    estado = mov.getMov().getId();
                                    tok += c;
                                    val = true;
                                    break;
                                }
                            }
                            else if (mov.getId().Length == 2)
                            {
                                bool encontrado = false;
                                if (mov.getId().Equals("\\n")) if (c == '\n') encontrado = true;
                                else if (mov.getId().Equals("\\t")) if (c == '\t') encontrado = true;
                                else if (mov.getId().Equals("\\\'")) if (c == '\'') encontrado = true;
                                else if (mov.getId().Equals("\\\"")) if (c == '"') encontrado = true;
                                if (encontrado)
                                {
                                    tok += c;
                                    val = true;
                                    edoant = estado;
                                    estado = mov.getMov().getId();
                                    break;
                                }
                            }
                            else if (mov.getId().ElementAt(1) == '~')
                            {
                                if (c >= mov.getId().ElementAt(0) && c <= mov.getId().ElementAt(2))
                                {
                                    edoant = estado;
                                    val = true;
                                    tok += c;
                                    estado = mov.getMov().getId();
                                    break;
                                }
                            }
                            else if (mov.getId().ElementAt(1) == ',')
                            {
                                int z = 0;
                                while (z < mov.getId().Length)
                                {
                                    if (c == mov.getId().ElementAt(z))
                                    {
                                        edoant = estado;
                                        tok += c;
                                        val = true;
                                        estado = mov.getMov().getId();
                                        break;
                                    }
                                    z += 2;
                                }
                                if (z < mov.getId().Length) break;
                            }
                        }
                        else if (mov.getTipo() == Token.TIPO.CADENA)
                        {
                            if (c.ToString() == mov.getId())
                            {
                                tok += c;
                                edoant = estado;
                                val = true;
                                estado = mov.getMov().getId();
                                break;
                            }
                        }
                        else if (mov.getTipo() == Token.TIPO.APOSTROFE)
                        {
                            if (c == '\'')
                            {
                                tok += c;
                                val = true;
                                edoant = estado;
                                estado = mov.getMov().getId();
                                break;
                            }
                        }
                        else if (mov.getTipo() == Token.TIPO.COMILLA)
                        {
                            if (c == '"')
                            {
                                tok += c;
                                edoant = estado;
                                val = true;
                                estado = mov.getMov().getId();
                                break;
                            }
                        }
                        else if (mov.getTipo() == Token.TIPO.ENTER)
                        {
                            if (c == '\n')
                            {
                                tok += c;
                                edoant = estado;
                                val = true;
                                estado = mov.getMov().getId();
                                break;
                            }
                        }
                        else if (mov.getTipo() == Token.TIPO.TAB)
                        {
                            if (c == '\t')
                            {
                                tok += c;
                                val = true;
                                edoant = estado;
                                estado = mov.getMov().getId();
                                break;
                            }
                        }
                        j++;
                    }
                    if (j >= exp.afd.getEstado(edoant).getMovimiento().Count || !val)
                    {
                        if (exp.afd.getEstado(estado).isAceptable()) cadena.tokens.Add(new Token(0, i, tok, Token.TIPO.CADENA));
                        else
                        {
                            if (tok.Equals("")) tok = c.ToString();
                            cadena.errores.Add(new Token(0, i, tok, Token.TIPO.DESCONOCIDO));
                        }
                        tok = "";
                        if (i < cad.Length - 1 || estado == 0) i--;
                        estado = 0;
                    }
                }
                
            }
            if (cadena.errores.Count != 0) valida = "Cadena No Valida";
            return valida;
        }
        public ExpresionRegular buscarExp(string id)
        {
            int i = 0;
            while(i < expresiones.Count)
            {
                ExpresionRegular exp = (ExpresionRegular)expresiones[i];
                if (exp.getId().Equals(id)) return exp;
                i++;
            }
            return null;
        }
    }
}
