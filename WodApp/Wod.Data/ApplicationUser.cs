using Microsoft.AspNetCore.Identity;
using System;
using Wod.Models;

namespace Wod.Data
{
    public class ApplicationUser : IdentityUser , IBaseModel
    {
        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }
        public bool IsDeleted { get ; set ; }
        public DateTime? DeletedOn { get ; set ; }
        public string AvatarUrl { get; set; }
    }
}
