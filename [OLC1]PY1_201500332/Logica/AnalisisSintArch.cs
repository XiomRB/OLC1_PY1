using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _OLC1_PY1_201500332.Logica
{
    class AnalisisSintArch
    {
        public AnalisisLexicoArch lexico;
        PrincipalAFN p = new PrincipalAFN();
        int i = 0;
        public AnalisisSintArch()
        {
            this.lexico = new AnalisisLexicoArch();
        }
        public void analizar(RichTextBox texto, ArrayList conjuntos, ArrayList expresiones, ArrayList cadenas)
        {
            Token token;
            ArrayList tokens = this.lexico.analizar(texto);
            for(i =0;i < tokens.Count; i++)
            {
                token = (Token)tokens[i];
                if (token.getTipo() == Token.TIPO.IDENTIFICADOR)
                {
                    Token tokensig = (Token)tokens[i + 1];
                    switch (tokensig.getTipo())
                    {
                        case Token.TIPO.FLECHA:
                            tokensig = (Token)tokens[i + 2];
                            if (tokensig.getTipo() == Token.TIPO.CONJ)
                            {
                                conjuntos.Add(new Conjunto(token.getLexema(), tokensig.getLexema()));
                                i += 2;
                            }else
                            {
                                i += 2;
                                Stack<Object []> lista = new Stack<Object[]>();
                                while(tokensig.getTipo()!= Token.TIPO.PUNTOCOMA)
                                {
                                    switch (tokensig.getTipo())
                                    {
                                        case Token.TIPO.CERRADURAKLEENE:
                                        case Token.TIPO.CERRADURAPOSITIVA:
                                        case Token.TIPO.CONCATENACION:
                                        case Token.TIPO.OR:
                                        case Token.TIPO.INTERROGACION:
                                        case Token.TIPO.ENTER:
                                        case Token.TIPO.TAB:
                                        case Token.TIPO.COMILLA:
                                        case Token.TIPO.APOSTROFE:
                                            lista.Push(new object[2] { tokensig.getLexema(), tokensig.getTipo() });
                                            break;
                                        case Token.TIPO.TODO:
                                            int l = tokensig.getLexema().Length;
                                            lista.Push(new object[2] { tokensig.getLexema().Substring(2,l-4), tokensig.getTipo() });
                                            break;
                                        case Token.TIPO.CADENA:
                                            int m = tokensig.getLexema().Length;
                                            lista.Push(new object[2] { tokensig.getLexema().Substring(1, m - 2), tokensig.getTipo() });
                                            break;
                                        case Token.TIPO.LLAVEABRE:
                                            tokensig = (Token)tokens[i + 1];
                                            if (tokensig.getTipo() == Token.TIPO.IDENTIFICADOR)
                                            {
                                                Conjunto conj;
                                                int c = 0;
                                                while (c < conjuntos.Count)
                                                {
                                                    conj = (Conjunto)conjuntos[c];
                                                    if (tokensig.getLexema().Equals(conj.nombre))
                                                    {
                                                        lista.Push(new object[2] { conj.conjunto, Token.TIPO.CONJ });
                                                        break;
                                                    }
                                                    c++;
                                                }                                                
                                            }
                                            i += 2;
                                            break;
                                    }
                                    i++;
                                    tokensig = (Token)tokens[i];
                                }
                                ExpresionRegular exp = new ExpresionRegular(token.getLexema());
                                exp.setAFN(p.crearAFN(lista, exp.simbolos));
                                expresiones.Add(exp);
                            }

                            break;
                        case Token.TIPO.DOSPUNTOS:
                            tokensig = (Token)tokens[i + 2];
                            if (tokensig.getTipo() == Token.TIPO.CADENA)
                            {
                                string cad = tokensig.getLexema();
                                cadenas.Add(new CadenaAValidar(token.getLexema(), cad.Substring(1, cad.Length - 2)));
                                i += 2;
                            }
                            break;
                    }
                }
            }
        }
    }
}
