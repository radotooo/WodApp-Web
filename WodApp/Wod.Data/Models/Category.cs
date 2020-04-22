using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Wod.Models.Common;

namespace Wod.Models
{
    public class Category:IBaseModel
    {
        public Category()
        {
            this.Posts = new HashSet<Post>();
        }
        public int Id { get; set; }

        [MaxLength(ModelValidation.NameMaxLength)]
        public string Name { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
        public DateTime CreatedOn { get ; set ; }
        public DateTime? ModifiedOn { get ; set ; }
        public bool IsDeleted { get ; set ; }
        public DateTime? DeletedOn { get; set; }
    }
}