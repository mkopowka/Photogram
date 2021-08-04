using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Photogram.Models
{
    public class Photography
    {
        public int Id { get; set; }

        [Display(Name = "name")]
        [Required(ErrorMessage = "error! You need give photo name")]
        public string Name { get; set; }

        [Display(Name = "image")]
        public string ImagePhoto { get; set; }

        [Display(Name = "description")]
        [Required(ErrorMessage = "error! You need give description")]
        public string Description { get; set; }


        [Display(Name = "category")]
        [Required(ErrorMessage = "error! you need choose gallery")]
        public int CategoryId { get; set; }

        [Display(Name = "gallery")]
        [Required(ErrorMessage = "error! you need choose gallery")]
        public int GalleryId { get; set; }

        public virtual Gallery Gallery { get; set; }

        public virtual Category Category { get; set; }
    }
}