using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WordPlay.Models
{
    public class PgTask
    {
        

        [Key]
        public int k { get; set; }
        [Display(Name="Rätt svar:")]
        public string PgTaskString { get; set; } // Text
        [Display(Name="Hitta tecknet")]
        public string PgTaskOut { get; set; } // Utdata
        [Display(Name = "Poäng")]
        public int? PgTaskScore { get; set; } //Poäng
        [Display(Name = "Svar:")]
        [Required]
        public string PgTaskAnswer { get; set; } // Inskickat svar
        
        public PgTask()
        {
            this.PgTaskScore = 0;
        }
        // Tar emot en sträng. Ersätter skiljetecken med * och returnerar den strängen.
        public string EncodeText(string s)
        {
            return s.Replace('.', '*').Replace(',','*').Replace('?','*').Replace('-','*').Replace('!','*');
        
        }//EncodeText

        // Returnerar "true" om strängen innehåller något skiljetecken
        public bool CheckAnswer(string s)// s= svar
        {
            if (PgTaskScore == null)
            {
                PgTaskScore = 0;
            }
            if (PgTaskAnswer == null)
            {
                PgTaskAnswer = "";
            }

            string tmp = PgTaskAnswer;
            bool result = true;
            // Räkna poäng för de skiljetecken som blivit rätt - CHECK
           // returnera true om PgTaskAnswer == s, annars false - CHECK
            // true - skall skriva ut en gratulation och antal poång i UI't
            // false - skriver ut att det inte blev helt rätt, antal poäng för det som blev rätt och den korrekta strängen
            // Egen metod för utdata? - NÄÄÄ
            
            PgTaskAnswer = PgTaskAnswer.Trim();
            
            if(PgTaskString.Length != s.Length)
            {
                result = false;
            }
            for(int i = 0; i < s.Length; i++)
            {
                if (s[i] == PgTaskString[i])
                {
                    //rätt skiljetecken
                    if ((s[i] == '.') || (s[i] == ',') || (s[i] == '?') || (s[i] == '-') || (s[i] == '!')) //.,?-!
                    {
                        PgTaskScore++; // Räkna upp poängen
                    }

                }
                else
                
                    if (s[i] != PgTaskString[i]) //fel svar
                    {
                        if ((s[i] == '.') || (s[i] == ',') || (s[i] == '?') || (s[i] == '-') || (s[i] == '!')) //.,?-!
                        {
                            result = false; // Skiljetecken felar
                        }
                        else
                        {
                            result = false;// Skiljetecken saknas
                        }
                    }//if
               
            }//for
            return result;
        }//CheckAnswer

    }//PgTask

}// end namespace

/** (Punktuation Game)
* Möjlighet att presentera en text på skärmen där skiljetecken saknas men markeras med en
* asterisk (*) på skärmen, där användaren sen skall skriva av texten, med skiljetecken istället
* för varje *. För varje rätt skiljetecken får användaren en poäng, om något är fel visas rätt svar
* upp.
* (. , ? - !)
*/