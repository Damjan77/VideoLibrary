using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AV_MVC1.Models
{
    public class Client
    {
        public int id { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public string address { get; set; }
        public string phone { get; set; }
        public string MovieCard { get; set; }
        [Range(1,90,ErrorMessage ="Vnesete validni godini!")]
        public int age { get; set; }
    }
}