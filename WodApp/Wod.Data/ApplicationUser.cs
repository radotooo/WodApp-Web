using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Wod.Models;

namespace Wod.Data
{
    public class ApplicationUser : IdentityUser, IBaseModel
    {
        public ApplicationUser()
        {

            this.Posts = new HashSet<Post>();
        }
        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedOn { get; set; }
        public string AvatarUrl { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string Address { get; set; }
        public virtual ICollection<Post> Posts { get; set; }

    }
}


