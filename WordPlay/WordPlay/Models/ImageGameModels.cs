using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WordPlay.Models
{
    public class ImageQuery
    {
        [Key]
        public int Id { get; set; }
        public string Word { get; set; }
        public string ImageUrl { get; set; }
    }
}