using System;
using System.Collections.Generic;
using System.Text;

namespace Wod.Models.WodApp.VIewModels.Profile
{
    public class ProfileViewModel
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string AvatarUrl { get; set; }
        public DateTime CreatedOn { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }

    }
}
