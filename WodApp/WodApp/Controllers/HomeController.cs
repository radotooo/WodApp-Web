using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Wod.Data;
using Wod.Models.WodApp.VIewModels;
using Wod.Models.WodApp.VIewModels.Post;
using Wod.Services.Claudinary.Contracts;
using Wod.Services.FavoriteService.Contracts;
using Wod.Services.PostService.Contracts;
using Wod.Services.VoteService;
using Wod.Services.VoteService.Contracts;

using WodApp.Models;


namespace WodApp.Controllers
{

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
               private readonly SignInManager<ApplicationUser> appUser;
        private readonly ICloudinaryService cloudinaryService;
        private readonly IPostService postService;
        private readonly IVoteSysService voteSysService;
        private readonly IFavoriteService favoriteService;

        public HomeController(ILogger<HomeController> logger,SignInManager<ApplicationUser> appUser,
            ICloudinaryService cloudinaryService, IPostService postService, IVoteSysService voteSysService, IFavoriteService favoriteService)
        {
            _logger = logger;
            
            this.appUser = appUser;
            this.cloudinaryService = cloudinaryService;
            this.postService = postService;
            this.voteSysService = voteSysService;
            this.favoriteService = favoriteService;
        }

        [Authorize]
        public IActionResult Index()
        {
            if (User.IsInRole("Admin"))
            {
                return RedirectToAction("Index", "Test", new { area = "Administration" });
            }
            var model = new IndexPostViewModel
            {
                Posts = postService.GetAll()
            };

            foreach (var post in model.Posts)
            {
                post.VoteCount = this.voteSysService.GetVoteCount(post.Id);
            }
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            ViewData["userId"] = userId;
            return View(model);
        }


        [AllowAnonymous]
        [Area("Identity")]
        public IActionResult Privacy()
        {

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        
        public async Task<IActionResult> Favorite()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var favorite = this.favoriteService.GetAll(userId);
            var model = await this.postService.GetAll(favorite);
            return View(model);
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

        public IActionResult Profile()
        {

            ViewData["Test"] = "http://res.cloudinary.com/radotooo/image/upload/v1587114349/Test.png";
            return View();
        }



    }

}