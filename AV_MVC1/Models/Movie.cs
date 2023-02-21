using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AV_MVC1.Models
{
    public class Movie
    {
        public int id { get; set; }
        [Required]
        public string name { get; set; }
        [Display(Name="Download URL ")]
        public string downloadURL { get; set; }
        [Required]
        [Display(Name = "Image URL ")]
        public string imageURL { get; set; }
        [Display(Name = "Movie Rating ")]
        public float rating { get; set; }

    }
}