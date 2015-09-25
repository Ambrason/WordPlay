using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WordPlay.Models
{
    public class ChallengeHighscore
    {
        [Key]
        public int Id { get; set; }
        public int Score { get; set; }
        public string Name { get; set; }
        public DateTime DateTime { get; set; }

        [ForeignKey("Category")]
        public int? CategoryId { get; set; }
        public virtual ChallengeCategory Category { get; set; }
    }

    public class ChallengeCategory
    {
        [Key]
        public int Id { get; set; }
        public string Category { get; set; }

        [InverseProperty("Category")]
        public virtual ICollection<ChallengeHighscore> Highscores { get; set; }
    }
}