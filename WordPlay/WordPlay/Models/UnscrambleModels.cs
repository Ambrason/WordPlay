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
        [Key]
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

        [Key]
        public int Id { get; set; }

        public string CorrectSentence { get; set; }

        public string AnsweredSentence { get; set; }

        public List<String> CorrectWords { get; set; }

        public List<String> WrongWords { get; set; }
    }
}