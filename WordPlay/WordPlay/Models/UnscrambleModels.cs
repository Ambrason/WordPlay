using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WordPlay.Models
{
    public class UnscrambledSentence
    {
        [Key]
        public int Id { get; set; }

        public string Sentence { get; set; }

    }

    public class UnscrambleGameViewmodel
    {
        public int Id { get; set; }

        public string ScrambledSentence { get; set; }

        public string AnsweredSentence { get; set; }

        public UnscrambleGameViewmodel() { }

        public UnscrambleGameViewmodel(UnscrambledSentence that) {
            this.Id = that.Id;
            this.AnsweredSentence = null;

            var scramble = that.Sentence.Split(' ');
            Random random = new Random();
            this.ScrambledSentence = string.Join(" ",scramble.OrderBy((item) => random.Next()).ToList());
        }
    }

    public class UnscrambleGameResultViewModel
    {
        public UnscrambleGameResultViewModel() { }

        public UnscrambleGameResultViewModel(UnscrambledSentence that, string answer)
        {
            this.Id = that.Id;
            this.CorrectSentence = that.Sentence;
            this.AnsweredSentence = answer;

            this.CorrectlyAnsweredWords = new List<string>();
            this.WronglyAnsweredWords = new List<string>();

            var correctWords = that.Sentence.Split(' ');
            var answeredWords = answer.Split(' ');

            for(int i = 0; i < answeredWords.Count(); i++)
            {
                if (i >= correctWords.Count() || answeredWords[i] != correctWords[i])
                {
                    WronglyAnsweredWords.Add(answeredWords[i]);
                }
                else {
                    CorrectlyAnsweredWords.Add(answeredWords[i]);
                }
            
            }

        }

        public int Id { get; set; }

        public string CorrectSentence { get; set; }

        public string AnsweredSentence { get; set; }

        public List<String> CorrectlyAnsweredWords { get; set; }

        public List<String> WronglyAnsweredWords { get; set; }
    }
}