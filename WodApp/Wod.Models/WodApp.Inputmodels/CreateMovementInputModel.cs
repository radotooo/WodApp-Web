using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;



namespace WodApp.Models
{
    public class CreateMovementInputModel
    {


        [Display(Name = "YdriDedoPope")]
        [Required(ErrorMessage = "blabla")]
        [StringLength(10,ErrorMessage ="Mnogobaaa")]
        public string Name { get; set; }

        public IFormFile CoverImage { get; set; }
    }
}
