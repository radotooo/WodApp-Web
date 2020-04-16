using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Wod.Data;
using WodApp.Models;
using WodApp.Services.Test;

namespace WodApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHomeService homeService;
        private readonly SignInManager<ApplicationUser> appUser;

        public HomeController(ILogger<HomeController> logger,IHomeService homeService , SignInManager<ApplicationUser> appUser)
        {
            _logger = logger;
            this.homeService = homeService;
            this.appUser = appUser;
        }
        [Authorize]
        public IActionResult Index()
        {
           


            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Test()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(CreateMovementInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);

            }
            await this.homeService.GreateAsyns(model);
            return View("Bravo");
        }
        public async Task<IActionResult> SingOut(string returnUrl = null)
        {
            await appUser.SignOutAsync();
            _logger.LogInformation("User logged out.");
            if (returnUrl != null)
            {
                return LocalRedirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Home");
            }
        }

    }
}

