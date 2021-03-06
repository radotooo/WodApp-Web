﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Wod.Data;
using Wod.Models.WodApp.Inputmodels;
using Wod.Services.CategoryService.Contracts;
using Wod.Services.Claudinary;
using Wod.Services.Claudinary.Contracts;
using Wod.Services.PostService.Contracts;
using Wod.Services.VoteService.Contracts;

namespace WodApp.Controllers
{
    [Authorize]
    public class PostController : Controller
    {
        private readonly IPostService postService;
        private readonly ICloudinaryService cloudinaryService;
        private readonly ICategoryService categoryService;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IVoteSysService voteSysService;

        public PostController(IPostService postService , ICloudinaryService cloudinaryService,
            ICategoryService categoryService, UserManager<ApplicationUser> userManager,IVoteSysService voteSysService)
        {
            this.postService = postService;
            this.cloudinaryService = cloudinaryService;
            this.categoryService = categoryService;
            this.userManager = userManager;
            this.voteSysService = voteSysService;
        }
        public IActionResult Index()
        {

            return View();
        }

        public async Task<IActionResult> ShowPost(int id)
        {
            var model = await postService.GetAsync(id);
            model.VoteCount = voteSysService.GetVoteCount(model.Id);
            return View(model);
        }


        public IActionResult Create()
        {
       
            var categories = this.categoryService.GetAll();
            var model = new CreatePostInputModel
            {
                Categoryes = categories,
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreatePostInputModel model)
        {
            var categories = this.categoryService.GetAll();
            model.Categoryes = categories;
            


            var user = await this.userManager.GetUserAsync(this.User);
            if (!ModelState.IsValid)
            {
                return this.View(model);
            }
            var coverUrl = await this.cloudinaryService
                .UploadAsync(model.PictureUrl, User.Identity.Name);
            var date = DateTime.UtcNow;
          var postId =  await postService.GreateAsyns(model.Tittle, model.CategoryId, user.Id, date, coverUrl);
            return this.RedirectToAction("ShowPost", new { id= postId});
        }

    }
}