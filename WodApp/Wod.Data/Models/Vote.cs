using System;
using System.Collections.Generic;
using System.Text;
using Wod.Data.Models.Enums;
using Wod.Models;

namespace Wod.Data.Models
{
    public class Vote 
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        public virtual Post Post { get; set; }
        
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
        public VoteValueEnum Value { get; set; }
    }
}
