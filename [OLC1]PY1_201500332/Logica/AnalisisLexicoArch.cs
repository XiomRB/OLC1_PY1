using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _OLC1_PY1_201500332.Logica
{
    class AnalisisLexicoArch
    {
        private string token;
        public ArrayList tokens;
        public ArrayList errores;
        private int estado = 0;
        public bool mal = false;
        int i = 0;

        public AnalisisLexicoArch()
        {
            this.tokens = new ArrayList();
            this.errores = new ArrayList();
            this.token = "";
            this.estado = 0;
        }

        public ArrayList analizar(RichTextBox texto)
        {
            int c = 0;
            char caracter;
            texto.Text += "¿";
            for(i =0; i < texto.Text.Length; i++)
            {
                caracter = texto.Text.ElementAt(i);
                switch (estado)
                {
                    case 0:
                        if (((int)caracter == 33) || ((int)caracter > 34 && (int)caracter < 42) ||  caracter == '>' || caracter == '=' || caracter == '@' || ((int)caracter > 92 && (int)caracter < 97))
                        {
                            estado = 1;
                            token += caracter;
                        }
                        else if (Char.IsLetter(caracter))
                        {
                            estado = 2;
                            token += caracter;
                        }
                        else if (Char.IsDigit(caracter))
                        {
                            estado = 3;
                            token += caracter;
                        }
                        else if (caracter == '\"')
                        {
                            estado = 4;
                            token += caracter;
                        }
                        else if (caracter == '[')
                        {
                            estado = 5;
                            token += caracter;
                        }
                        else if (caracter == '\\')
                        {
                            estado = 6;
                            token += caracter;
                        }
                        else if (caracter == '.' || caracter == ':' || caracter == '?' || caracter == '*' || caracter == '+' || caracter == '|' || caracter == ';' || caracter == '{' || caracter == '}' || caracter == ',')
                        {
                            token += caracter;
                            estado = 29;
                        }
                        else if (caracter == '-')
                        {
                            estado = 8;
                            token += caracter;
                        }
                        else if (caracter == '<')
                        {
                            estado = 9;
                            token += caracter;
                        }
                        else if (caracter == '/')
                        {
                            estado = 10;
                            token += caracter;
                        }
                        else if (Char.IsWhiteSpace(caracter) || caracter == '\n' || caracter == '\r' || caracter == '\t') estado = 0;
                        else
                        {
                            if (caracter == '¿' && i == texto.Text.Length - 1) return this.tokens;
                            else
                            {
                                token += caracter;
                                validarError(Token.TIPO.DESCONOCIDO, texto.GetLineFromCharIndex(i), texto.GetPositionFromCharIndex(i).Y);
                                i++;
                            }
                        }
                        break;
                    case 1:
                        if (caracter == '~')
                        {
                            estado = 11;
                            token += caracter;
                        }
                        else if (caracter == ',')
                        {
                            estado = 12;
                            token += caracter;
                        }
                        else validarToken(texto.GetLineFromCharIndex(i), texto.GetPositionFromCharIndex(i).Y, Token.TIPO.CONJ);
                        break;
                    case 2:
                        if(caracter == '~')
                        {
                            estado = 13;
                            token += caracter;
                        }else if (Char.IsLetterOrDigit(caracter) || caracter == '_')
                        {
                            estado = 15;
                            token += caracter;
                        }else if(caracter == ',')
                        {
                            estado = 14;
                            token += caracter;
                        }else if(caracter == ';') validarToken(texto.GetLineFromCharIndex(i), texto.GetPositionFromCharIndex(i).Y, Token.TIPO.CONJ);
                        else validarToken(texto.GetLineFromCharIndex(i), texto.GetPositionFromCharIndex(i).Y, Token.TIPO.IDENTIFICADOR);
                        break;
                    case 3:
                        if(caracter == '~')
                        {
                            estado = 16;
                            token += caracter;
                        }else if(caracter == ',')
                        {
                            estado = 17;
                            token += caracter;
                        }else validarToken(texto.GetLineFromCharIndex(i), texto.GetPositionFromCharIndex(i).Y, Token.TIPO.CONJ);
                        break;
                    case 4:
                        if(caracter == '"')
                        {
                            estado = 7;
                            token += caracter;
                        }
                        else token += caracter;
                        break;
                    case 5:
                        if(caracter == ':')
                        {
                            estado = 18;
                            token += caracter;
                        }else if(caracter == ',')
                        {
                            estado = 12;
                            token += caracter;
                        }else if(caracter == '~')
                        {
                            estado = 11;
                            token += caracter;
                        }else if(caracter == ';') validarToken(texto.GetLineFromCharIndex(i), texto.GetPositionFromCharIndex(i).Y, Token.TIPO.CONJ);
                        else validarError(Token.TIPO.DESCONOCIDO,texto.GetLineFromCharIndex(i), texto.GetPositionFromCharIndex(i).Y);
                        break;
                    case 6:
                        if(caracter == '\"' || caracter == 'n' || caracter=='t' ||caracter == '\'')
                        {
                            estado = 19;
                            token += caracter;
                        }else if(caracter == ',')
                        {
                            estado = 12;
                            token += caracter;
                        }else if(caracter == '~')
                        {
                            estado = 11;
                            token += caracter;
                        }else if(caracter == ';') validarToken(texto.GetLineFromCharIndex(i), texto.GetPositionFromCharIndex(i).Y, Token.TIPO.CONJ);
                        else validarError(Token.TIPO.DESCONOCIDO, texto.GetLineFromCharIndex(i), texto.GetPositionFromCharIndex(i).Y);
                        break;
                    case 7:
                        if (token.ElementAt(1) == '~' || token.ElementAt(1) == ',') validarToken(texto.GetLineFromCharIndex(i), texto.GetPositionFromCharIndex(i).Y, Token.TIPO.CONJ);
                        else if(token.Equals("->")) validarToken(texto.GetLineFromCharIndex(i), texto.GetPositionFromCharIndex(i).Y, Token.TIPO.FLECHA);
                        else if(token.ElementAt(token.Length-1) == ']') validarToken(texto.GetLineFromCharIndex(i), texto.GetPositionFromCharIndex(i).Y, Token.TIPO.TODO);
                        else if(token.ElementAt(token.Length - 1) == '>') validarToken(texto.GetLineFromCharIndex(i), texto.GetPositionFromCharIndex(i).Y, Token.TIPO.COMENTMULTI);
                        else if(token.ElementAt(token.Length - 1) == '"') validarToken(texto.GetLineFromCharIndex(i), texto.GetPositionFromCharIndex(i).Y, Token.TIPO.CADENA);
                        break;
                    case 8:
                        if(caracter == '>')
                        {
                            estado = 7;
                            token += caracter;
                        } else if(caracter == ',')
                        {
                            estado = 12;
                            token += caracter;
                        }else if(caracter == '~'){
                            estado = 11;
                            token += caracter;
                        }
                        else validarError(Token.TIPO.DESCONOCIDO, texto.GetLineFromCharIndex(i), texto.GetPositionFromCharIndex(i).Y);
                        break;
                    case 9:
                        if(caracter == '!')
                        {
                            estado = 20;
                            token += caracter;
                        }else if(caracter == ';') validarToken(texto.GetLineFromCharIndex(i), texto.GetPositionFromCharIndex(i).Y, Token.TIPO.CONJ);
                        else if(caracter == '~')
                        {
                            estado = 11;
                            token += caracter;
                        }else if(caracter == ',')
                        {
                            estado = 12;
                            token += caracter;
                        }else validarError(Token.TIPO.DESCONOCIDO, texto.GetLineFromCharIndex(i), texto.GetPositionFromCharIndex(i).Y);
                        break;
                    case 10:
                        if(caracter == '/')
                        {
                            estado = 21;
                            token += caracter;
                        }
                        else if (caracter == ',')
                        {
                            estado = 12;
                            token += caracter;
                        }
                        else validarError(Token.TIPO.DESCONOCIDO, texto.GetLineFromCharIndex(i), texto.GetPositionFromCharIndex(i).Y);
                        break;
                    case 11:
                        c = caracter;
                        if((c >32 && c<48) || (c>57 && c<65) || (c>90 && c<97) || (c>122 && c < 126))
                        {
                            estado = 7;
                            token += caracter;
                        }else validarError(Token.TIPO.DESCONOCIDO, texto.GetLineFromCharIndex(i), texto.GetPositionFromCharIndex(i).Y);
                        break;
                    case 12:
                        c = caracter;
                        if ((c > 32 && c < 48) || (c > 57 && c < 65) || (c > 90 && c < 97) || (c > 122 && c < 126))
                        {
                            estado = 22;
                            token += caracter;
                        }
                        else validarError(Token.TIPO.DESCONOCIDO, texto.GetLineFromCharIndex(i), texto.GetPositionFromCharIndex(i).Y);
                        break;
                    case 13:
                        if (Char.IsLetter(caracter))
                        {
                            estado = 7;
                            token += caracter;
                        }
                        else validarError(Token.TIPO.DESCONOCIDO, texto.GetLineFromCharIndex(i), texto.GetPositionFromCharIndex(i).Y);
                        break;
                    case 14:
                        if (Char.IsLetter(caracter))
                        {
                            estado = 23;
                            token += caracter;
                        }
                        else validarError(Token.TIPO.DESCONOCIDO, texto.GetLineFromCharIndex(i), texto.GetPositionFromCharIndex(i).Y);
                        break;
                    case 15:
                        if(Char.IsLetterOrDigit(caracter) || caracter == '_')
                        {
                            estado = 15;
                            token += caracter;
                        }
                        else
                        {
                            if(token.Equals("CONJ")) validarToken(texto.GetLineFromCharIndex(i), texto.GetPositionFromCharIndex(i).Y, Token.TIPO.PR_CONJ);
                            else validarToken(texto.GetLineFromCharIndex(i), texto.GetPositionFromCharIndex(i).Y, Token.TIPO.IDENTIFICADOR);
                        }
                        break;
                    case 16:
                        if (Char.IsDigit(caracter))
                        {
                            estado = 7;
                            token += caracter;
                        }else validarError(Token.TIPO.DESCONOCIDO, texto.GetLineFromCharIndex(i), texto.GetPositionFromCharIndex(i).Y);
                        break;
                    case 17:
                        if (Char.IsDigit(caracter))
                        {
                            estado = 24;
                            token += caracter;
                        }else validarError(Token.TIPO.DESCONOCIDO, texto.GetLineFromCharIndex(i), texto.GetPositionFromCharIndex(i).Y);
                        break;
                    case 18:
                        if (caracter == ':')
                        {
                            estado = 25;
                            token += caracter;
                        }
                        else token += caracter;
                        break;
                    case 19:
                        if(caracter == ',')
                        {
                            estado = 26;
                            token += caracter;
                        }
                        else if(caracter == ';') validarToken(texto.GetLineFromCharIndex(i), texto.GetPositionFromCharIndex(i).Y, Token.TIPO.CONJ);
                        else
                        {
                            if (token.Equals("\\n"))  validarToken(texto.GetLineFromCharIndex(i), texto.GetPositionFromCharIndex(i).Y, Token.TIPO.ENTER);                     
                            else if (token.Equals("\\t")) validarToken(texto.GetLineFromCharIndex(i), texto.GetPositionFromCharIndex(i).Y, Token.TIPO.TAB);
                            else if (token.Equals("\\\'")) validarToken(texto.GetLineFromCharIndex(i), texto.GetPositionFromCharIndex(i).Y, Token.TIPO.APOSTROFE);
                            else if (token.Equals("\\\"")) validarToken(texto.GetLineFromCharIndex(i), texto.GetPositionFromCharIndex(i).Y, Token.TIPO.COMILLA);
                        }
                        break;
                    case 20:
                        if (caracter == '!')
                        {
                            estado = 27;
                            token += caracter;
                        }
                        else token += caracter;
                        break;
                    case 21:
                        if (caracter == '\n') validarToken(texto.GetLineFromCharIndex(i), texto.GetPositionFromCharIndex(i).Y, Token.TIPO.COMENTLINEA);
                        else token += caracter;
                        break;
                    case 22:
                        if(caracter == ',')
                        {
                            estado = 12;
                            token += caracter;
                        }else validarToken(texto.GetLineFromCharIndex(i), texto.GetPositionFromCharIndex(i).Y, Token.TIPO.CONJ);
                        break;
                    case 23:
                        if(caracter == ',')
                        {
                            estado = 14;
                            token += caracter;
                        }else validarToken(texto.GetLineFromCharIndex(i), texto.GetPositionFromCharIndex(i).Y, Token.TIPO.CONJ);
                        break;
                    case 24:
                        if(caracter == ',')
                        {
                            estado = 17;
                            token += caracter;
                        }else validarToken(texto.GetLineFromCharIndex(i), texto.GetPositionFromCharIndex(i).Y, Token.TIPO.CONJ);
                        break;
                    case 25:
                        if(caracter == ']')
                        {
                            estado = 7;
                            token += caracter;
                        }else validarError(Token.TIPO.DESCONOCIDO, texto.GetLineFromCharIndex(i), texto.GetPositionFromCharIndex(i).Y);
                        break;
                    case 26:
                        if(caracter == '\\')
                        {
                            estado = 28;
                            token += caracter;
                        }else validarError(Token.TIPO.DESCONOCIDO, texto.GetLineFromCharIndex(i), texto.GetPositionFromCharIndex(i).Y);
                        break;
                    case 27:
                        if(caracter == '>')
                        {
                            estado = 7;
                            token += caracter;
                        }else validarError(Token.TIPO.DESCONOCIDO, texto.GetLineFromCharIndex(i), texto.GetPositionFromCharIndex(i).Y);
                        break;
                    case 28:
                        if(caracter == '\"' || caracter == '\'' || caracter == 'n' || caracter == 't')
                        {
                            estado = 19;
                            token += caracter;
                        }
                        break;
                    case 29:
                        if(caracter == ',')
                        {
                            token += caracter;
                            estado = 12;
                        }else if(caracter == '~')
                        {
                            token += caracter;
                            estado = 11;
                        }else if(caracter == ';') validarToken(texto.GetLineFromCharIndex(i), texto.GetPositionFromCharIndex(i).Y, Token.TIPO.CONJ);
                        else
                        {
                            if(token.Equals(".")) validarToken(texto.GetLineFromCharIndex(i), texto.GetPositionFromCharIndex(i).Y, Token.TIPO.CONCATENACION);
                            else if(token.Equals(":")) validarToken(texto.GetLineFromCharIndex(i), texto.GetPositionFromCharIndex(i).Y, Token.TIPO.DOSPUNTOS);
                            else if(token.Equals("?")) validarToken(texto.GetLineFromCharIndex(i), texto.GetPositionFromCharIndex(i).Y, Token.TIPO.INTERROGACION);
                            else if(token.Equals("*")) validarToken(texto.GetLineFromCharIndex(i), texto.GetPositionFromCharIndex(i).Y, Token.TIPO.CERRADURAKLEENE);
                            else if(token.Equals("+")) validarToken(texto.GetLineFromCharIndex(i), texto.GetPositionFromCharIndex(i).Y, Token.TIPO.CERRADURAPOSITIVA);
                            else if(token.Equals("|")) validarToken(texto.GetLineFromCharIndex(i), texto.GetPositionFromCharIndex(i).Y, Token.TIPO.OR);
                            else if(token.Equals(";")) validarToken(texto.GetLineFromCharIndex(i), texto.GetPositionFromCharIndex(i).Y, Token.TIPO.PUNTOCOMA);
                            else if(token.Equals("{")) validarToken(texto.GetLineFromCharIndex(i), texto.GetPositionFromCharIndex(i).Y, Token.TIPO.LLAVEABRE);
                            else if(token.Equals("}")) validarToken(texto.GetLineFromCharIndex(i), texto.GetPositionFromCharIndex(i).Y, Token.TIPO.LLAVECIERRA);
                            else if(token.Equals(",")) validarToken(texto.GetLineFromCharIndex(i), texto.GetPositionFromCharIndex(i).Y, Token.TIPO.COMA);
                        }
                        break;
                }
            }
            return this.tokens;
        }
        public void validarError(Token.TIPO tipo,int linea, int columna)
        {
            errores.Add(new Token(linea, columna, token,tipo));
            token = "";
            estado = 0;
            mal = true;
            i--;
        }

        public void validarToken(int linea,int columna, Token.TIPO tipo)
        {
            tokens.Add(new Token(linea, columna, token, tipo));
            token = "";
            estado = 0;
            i--;
        }
    }
}
