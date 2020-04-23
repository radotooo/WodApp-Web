using System;
using System.Collections.Generic;
using System.Text;
using Wod.Models;

namespace Wod.Data.Models
{
   public  class Favorite
    {
        public Favorite()
        {
            Posts = new HashSet<Post>();
        }
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
        public int PostId { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
    }
}
