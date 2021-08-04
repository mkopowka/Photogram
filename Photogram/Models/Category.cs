using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Photogram.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Display(Name = "name")]
        [Required(ErrorMessage = "error! You need give category name to your category")]
        public string Name { get; set; }

        [Display(Name = "description")]
        [Required(ErrorMessage = "error! You need give category description to your category")]
        public string Description { get; set; }

        [Display(Name = "image")]
        public string ImageCategory { get; set; }

        public virtual ICollection<Photography> Photographies { get; set; }
    }
}