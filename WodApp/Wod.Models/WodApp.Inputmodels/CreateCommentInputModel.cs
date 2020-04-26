using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Wod.Models.WodApp.Inputmodels
{
   public  class CreateCommentInputModel
    {
        public string UserId { get; set; }
        

        [Required]
        public  string Content { get; set; }
       
        public int PostId { get; set; }
        public int? ParentId { get; set; }
    }
}
