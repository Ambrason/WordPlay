using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WordPlay.Models
{
    public class ColorQuery
    {
        [Key]
        public int Id { get; set; }
        public string ColorCode { get; set; }
        public string ColorName { get; set; }
        public string ColorText { get; set; }
    }
}