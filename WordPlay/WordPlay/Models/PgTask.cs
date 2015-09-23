using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WordPlay.Models
{
    public class PgTask
    {
        // Skiljetecken och tecknets index i indatasträngen
        public class TokenAndPosition
        {
            public int Idx { get; set; }
            public char Token { get; set; }
        }// end inner class

        private List<TokenAndPosition> tokens;

        public List<string> facit = new List<string>();
        public List<int> errors = new List<int>();
        //public enum punctuation {dot,comma,qmark,hyphen,exclamation};
        //'.',',','?','-','!'
        public string PgTaskString { get; set; } // Text
        public string PgTaskOut { get; set; } // Utdata
        public int PgTaskScore { get; set; } //Poäng
        public string PbTaskAnswer { get; set; }

        // Tar emot en sträng. Ersätter skiljetecken med * och returnerar den strängen.
        public string EncodeText(string s)
        {
            string result = s;


            for (int i = 0; i < s.Length; i++)
            {

                if ((s[i] == '.') || (s[i] == ',') || (s[i] == '?') || (s[i] == '-') || (s[i] == '?'))
                {
                    //skiljetecknet sparas undan
                    TokenAndPosition t = new TokenAndPosition();
                    t.Idx = i;
                    t.Token = s[i];
                    tokens.Add(t);
                    // ersätt med *
                    result.Insert(i, "*");
                }

            }

            return result;
        }//EncodeText

        // Tar emot en sträng och en lista . Kontrollerar om skiljetecken matchar sparade tecken (tokens)
        public bool CheckAnswer(string s, List<TokenAndPosition> l)// s= svar, l = tokens
        {
            bool result = true;
            string str = "";
            int idx = 0;

            for (int i = 0; i < s.Length; i++)
            {

                if ((s[i] == '.') || (s[i] == ',') || (s[i] == '?') || (s[i] == '-') || (s[i] == '?'))
                {
                    //Skiljetecknet i indatasträngen jämförs med sparade skiljetecken
                    TokenAndPosition t = new TokenAndPosition();
                    t = l.First();
                    if( (t.Idx != i) || (t.Token != s[i]) )
                    {
                        result = false;
                        l.RemoveAt(0);
                    }
                    else
                    {
                        l.RemoveAt(0);
                    }
                }//if

            }// for

            return result;
        }//CheckAnswer
    }//PgTask
}// end namespace

/** (Punktuation Game)
* Möjlighet att presentera en text på skärmen där skiljetecken saknas men markeras med en
* asterisk (*) på skärmen, där användaren sen skall skriva av texten, med skiljetecken istället
* för varje *. För varje rätt skiljetecken får användaren en poäng, om något är fel visas rätt svar
* upp
*/