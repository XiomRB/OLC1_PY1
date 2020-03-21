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
        AnalisisLexicoArch lexico;
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
                                ArrayList lista = new ArrayList();
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
                                            lista.Add(new Object[2] { tokensig.getLexema(), tokensig.getTipo() });
                                            break;
                                        case Token.TIPO.TODO:
                                            int l = tokensig.getLexema().Length;
                                            lista.Add(new Object[2] { tokensig.getLexema().Substring(2,l-4), tokensig.getTipo() });
                                            break;
                                        case Token.TIPO.CADENA:
                                            int m = tokensig.getLexema().Length;
                                            lista.Add(new Object[2] { tokensig.getLexema().Substring(1, m - 2), tokensig.getTipo() });
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
                                                        lista.Add(new Object[2] { tokensig.getLexema(), tokensig.getTipo() });
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
                                expresiones.Add(new ExpresionRegular(token.getLexema(), lista));
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

        public void tomarExpresion(ArrayList toks)
        {
            Token tok = (Token) toks[i];
            switch (tok.getTipo())
            {
                case Token.TIPO.CADENA:
                    break;
                case Token.TIPO.LLAVEABRE:
                    break;
                case Token.TIPO.TODO:
                    break;
                case Token.TIPO.ENTER:
                    break;
                case Token.TIPO.TAB:
                    break;
                case Token.TIPO.COMILLA:
                    break;
                case Token.TIPO.APOSTROFE:
                    break;
                case Token.TIPO.CERRADURAKLEENE:
                    break;
                case Token.TIPO.CERRADURAPOSITIVA:
                    break;
                case Token.TIPO.CONCATENACION:
                    break;
                case Token.TIPO.OR:
                    break;
                case Token.TIPO.INTERROGACION:
                    break;
            }
        }
    }
}
