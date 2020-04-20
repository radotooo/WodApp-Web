using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Wod.Data;
using Wod.Models.WodApp.VIewModels;

namespace WodApp.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        private readonly UserManager<ApplicationUser> usermanager;

        public ProfileController(UserManager<ApplicationUser> usermanager)
        {
            this.usermanager = usermanager;
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

        public IActionResult Edit()
        {

            return View();
        }

        public IActionResult ChangePicture()
        {

            return View();
        }
    }
}