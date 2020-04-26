using System;
using Wod.Data;

namespace Wod.Models
{
    public class Comment : IBaseModel
    {
        public int Id { get; set; }
        public DateTime CreatedOn { get ; set ; }
        public DateTime? ModifiedOn { get ; set ; }
        public bool IsDeleted { get ; set ; }
        public DateTime? DeletedOn { get ; set ; }
        public string Content { get; set; }
        public int? ParentId { get; set; }
        public virtual Comment Parent { get; set; }
        public int PostId { get; set; }
        public virtual Post Post { get; set; }
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}