using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Wod.Models.Common;

namespace Wod.Models
{
    public class Category
    {
        public Category()
        {
            this.Posts = new HashSet<Post>();
        }
        public int Id { get; set; }

        [MaxLength(ModelValidation.NameMaxLength)]
        public string Name { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
    }
}