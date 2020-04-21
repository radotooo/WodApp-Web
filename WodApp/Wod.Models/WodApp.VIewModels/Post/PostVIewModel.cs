using System;
using System.Collections.Generic;
using System.Text;

namespace Wod.Models.WodApp.VIewModels.Post
{
    public class PostVIewModel
    {
        
       
        public string UserUsernameName { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CategoryName { get; set; }
        public string PictureUrl { get; set; }
        public string Tittle { get; set; }
    }
}
