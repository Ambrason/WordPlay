using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WordPlay.Models
{
    public class QuizQuestion
    {
        [Key]
        public int Id {get;set;}
        public string Question {get;set;}
        
        public string CorrectAnswer {get;set;}

        [ForeignKey("Category")]
        public int CategoryId{get;set;}
        public virtual QuizCategory Category {get;set;}

        [InverseProperty("Question")]
        public virtual ICollection<QuizAnswer> Answers {get;set;}
    }

    public class QuizAnswer
    {
        [Key]
        public int Id {get;set;}
        public string Answer {get;set;}

        [ForeignKey("Question")]
        public int QuestionId {get;set;}
        public virtual QuizQuestion Question {get;set;}
    }

    public class QuizCategory
    { 
        [Key]
        public int Id {get;set;}
        public string Category {get;set;}

        [InverseProperty("Category")]
        public virtual ICollection<QuizQuestion> Questions {get;set;}
    }
    public class QuizHighscore
    {
        [Key]
        public int Id { get; set; }
        public int Score { get; set; }
        public string Name { get; set; }
        public DateTime DateTime { get; set; }

        [ForeignKey("Category")]
        public int? CategoryId { get; set; }
        public virtual QuizCategory Category { get; set; }
    }

    public class QuizPlayViewmodel
    {
        public int? CategoryId { get; set; }
        public string CategoryName { get; set; }

        public int CurrentQuestionNr { get; set; }
        public int CurrentQuestionId { get; set; }
        public string CurrentQuestion { get; set; }

        public List<string> Answers { get; set; }

        public int Score { get; set; }

        public bool? PreviousQuestionCorrect { get; set; }
        public string PreviousQuestion { get; set; }
        public string PreviousGivenAnswer { get; set; }
        public string PreviousCorrectAnswer { get; set; }

        public List<int> AnsweredQuestions { get; set; }

        public QuizPlayViewmodel()
        {
            Answers = new List<string>();
            AnsweredQuestions = new List<int>();
        }

        public QuizPlayViewmodel(QuizCategory category) : this()
        {
            this.CategoryId = category == null ? null : category.Id as int?;
            this.CategoryName = category == null ? null : category.Category;
        }
    }

    public class QuizResultViewmodel
    {
        public int? CategoryId { get; set; }
        public string CategoryName { get; set; }

        public int Score { get; set; }
    }
}