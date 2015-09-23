using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WordPlay.Models
{
    public class ColorModel
    {
        [Key]
        public int ID { get; set; }
        public string Color { get; set; }
        public int Counter { get; set; }
    }
}