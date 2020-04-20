using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Wod.Data;
using Wod.Models.Common;

namespace Wod.Models
{
    public class Post : IBaseModel
    {
        public Post()
        {
            Comments = new HashSet<Comment>();
        }
        public int Id { get; set; }
        public DateTime CreatedOn { get ; set ; }
        public DateTime? ModifiedOn { get ; set ; }
        public bool IsDeleted { get ; set; }
        public DateTime? DeletedOn { get ; set ; }
        [MaxLength(ModelValidation.NameMaxLength)]
        public string Tittle { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}
