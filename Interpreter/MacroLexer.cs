using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using ScintillaNET;
using System.Threading.Tasks;

namespace Interpreter
{
    class MacroLexer
    {
        private HashSet<string> keywords;

        public const int DefaultS = 0;
        public const int KeywordS = 1;
        public const int StringS = 2;
        public const int NumberS = 3;
        public const int CharS = 4;
        public const int OperatorS = 5;
        public const int PreprocessorS = 6;
        public const int CommentS = 7;

        public const int STATE_UNKNOWN = 0;
        public const int STATE_NUMBER = 1;
        public const int STATE_STRING = 2;
        public const int STATE_PREPROCESSOR = 3;
        public const int STATE_COMMENT = 4;

        public MacroLexer(string keywords)
        {
            // konstruktor sa kljucnim recima
            var list = Regex.Split(keywords ?? string.Empty, @"\s+").Where(l => !string.IsNullOrEmpty(l));
            this.keywords = new HashSet<string>(list);
        }

        public void Style(Scintilla scintilla, int endPos, int startPos)
        {
            //postavljanje pokazivaca na pocetak linije
            var line = scintilla.LineFromPosition(startPos);
            startPos = scintilla.Lines[line].Position;
            var length = 0;
            var state = STATE_UNKNOWN;

            //pocetak stilisanja
            scintilla.StartStyling(startPos);
            while(startPos < endPos)
            {
                var c = (char)scintilla.GetCharAt(startPos);

            REPROCES:
                switch (state)
                {
                    case STATE_UNKNOWN:
                        if (c == '"')
                        {
                            scintilla.SetStyling(0, StringS);
                            state = STATE_STRING;
                        }
                        else if (Char.IsDigit(c))
                        {
                            state = STATE_NUMBER;
                            goto REPROCES;
                        }
                        else if (Char.IsLetter(c))
                        {
                            state = STATE_PREPROCESSOR;
                            goto REPROCES;
                        }
                        else if (c == '/')
                        {
                            scintilla.SetStyling(0, CommentS);
                            state = STATE_COMMENT;
                        }
                        else
                        {
                            scintilla.SetStyling(0, DefaultS);
                        }
                        break;
                    case STATE_STRING:
                    if (c == '"')
                        {
                            length++;
                            scintilla.SetStyling(length, StringS);
                            length = 0;
                            state = STATE_UNKNOWN;
                        }
                        else
                        {
                            length++;
                        }
                        break;
                    case STATE_NUMBER:
                        if (Char.IsDigit(c) || (c >= 'a' && c <= 'f') || (c >= 'A' && c <= 'F') || c == 'x')
                        {
                            length++;
                        }
                        else
                        {
                            scintilla.SetStyling(length, NumberS);
                            length = 0;
                            state = STATE_UNKNOWN;
                            goto REPROCES;
                        }
                        break;
                    case STATE_COMMENT:
                        if (c == '/')
                        {
                            length++;
                            scintilla.SetStyling(length, CommentS);
                            length = 0;
                            state = STATE_UNKNOWN;
                        }
                        else
                        {
                            length++;
                        }
                        break;
                    case STATE_PREPROCESSOR:
                        if (Char.IsLetterOrDigit(c))
                        {
                            length++;
                        }
                        else
                        {
                            var style = PreprocessorS;
                            var identifier = scintilla.GetTextRange(startPos - length, length);
                            if (keywords.Contains(identifier))
                                style = KeywordS;

                            scintilla.SetStyling(length, style);
                            length = 0;
                            state = STATE_UNKNOWN;
                            goto REPROCES;
                        }
                        break;

                }

                startPos++;
            }
        }
    }
}
