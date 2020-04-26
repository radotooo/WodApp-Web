using LearningSystem.Repository.Contracts;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wod.Data;
using Wod.Models.WodApp.VIewModels;
using Wod.Services.ProfileService.Contracts;

namespace Wod.Services.ProfileService
{
    public class ProfileService : IprofileService
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IRepository<ApplicationUser> repository;

        public ProfileService(UserManager<ApplicationUser> userManager, IRepository<ApplicationUser> repository)
        {
            this.userManager = userManager;
            this.repository = repository;
        }
        public UserViewModel GetByUsername(string username)
        { 
            var currentUser = this.repository.Get().Where(x => x.UserName == username).FirstOrDefault();
            var model = new UserViewModel
            {
                Address = currentUser.Address,
                FirstName = currentUser.FirstName,
                LastName = currentUser.LastName,
                AvatarUrl = currentUser.AvatarUrl,
                CreatedOn = currentUser.CreatedOn,
                Username = currentUser.UserName,
                Email = currentUser.Email,
                Phone = currentUser.PhoneNumber

            };
            return model;
        }
    }
}
