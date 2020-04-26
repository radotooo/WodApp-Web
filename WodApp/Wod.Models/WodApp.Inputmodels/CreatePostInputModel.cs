using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Wod.Models.Common;
using Wod.Models.CustomValidationAttributes;
using Wod.Models.WodApp.VIewModels.Category;

namespace Wod.Models.WodApp.Inputmodels
{
    public class CreatePostInputModel
    {
       [Required]
        [DataType(DataType.Upload)]
        [MaxFileSize(5 * 1024 * 1024)]
        [AllowedExtensions(new string[] { ".jpg", ".png" ,".jpeg"})]
        
        public IFormFile PictureUrl { get; set; }
       [Required]
       [MaxLength(ModelValidation.NameMaxLength)]
        public string Tittle { get; set; }

        [Required]
        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        public IEnumerable<CategoryDropDownViewModel> Categoryes { get; set; }
       

    }
}
