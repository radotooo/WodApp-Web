using System;
using System.Collections.Generic;
using System.Text;

namespace Wod.Models
{
    public interface IBaseModel 
    {
        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedOn { get; set; }

    }
}
