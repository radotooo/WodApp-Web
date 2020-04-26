using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Wod.Data;
using Wod.Models.WodApp.VIewModels;
using Wod.Services.ProfileService.Contracts;

namespace WodApp.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        private readonly UserManager<ApplicationUser> usermanager;
        private readonly IprofileService profileService;

        public ProfileController(UserManager<ApplicationUser> usermanager,IprofileService profileService)
        {
            this.usermanager = usermanager;
            this.profileService = profileService;
        }
        public async Task<IActionResult> Index()
        {
            var currentUser = await usermanager.GetUserAsync(User);
            var model = new UserViewModel
            {
                Address = currentUser.Address,
                FirstName = currentUser.FirstName,
                LastName = currentUser.LastName,
                AvatarUrl = currentUser.AvatarUrl,
                CreatedOn = currentUser.CreatedOn,
                Username= currentUser.UserName,
                Email=currentUser.Email,
                Phone=currentUser.PhoneNumber
         
            };
            return View(model);
        }

        public async Task<IActionResult> ShowProfile(string username)
        {
            var currentUser = await usermanager.GetUserAsync(User);
            if(username == currentUser.UserName)
            {
               return RedirectToAction("Index");
            }
            var model = profileService.GetByUsername(username);
            return View(model);

        }

        public IActionResult ChangePicture()
        {

            return View();
        }
    }
}