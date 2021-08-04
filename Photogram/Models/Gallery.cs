using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Photogram.Models
{
    public class Gallery
    {
        public int Id { get; set; }

        [Display(Name = "gallery")]
        [Required(ErrorMessage = "error! You need give name to your gallery")]
        public string Name { get; set; }

        [Display(Name = "description")]
        [Required(ErrorMessage = "error! you need give description to your gallery")]
        public string Description { get; set; }


        [Display(Name = "image")]
        public string ImageGallery { get; set; }


        public virtual ICollection<Photography> Photographies { get; set; }
    }
}