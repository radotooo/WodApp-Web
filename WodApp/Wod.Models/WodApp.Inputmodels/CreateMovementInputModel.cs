using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WodApp.Data.Domain;


namespace WodApp.Models
{
    public class CreateMovementInputModel 
    {



        [Required(ErrorMessage = "blabla")]
        [StringLength(10,ErrorMessage ="Mnogobaaa")]
        public string Name { get; set; }
    }
}
