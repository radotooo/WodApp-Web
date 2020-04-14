using Microsoft.AspNetCore.Identity;
using System;

namespace Wod.Data
{
    public class ApplicationUser : IdentityUser
    {
        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}
