using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Wod.Models.WodApp.VIewModels.Post;
using Wod.Services.PostService.Contracts;
using Wod.Services.VoteService.Contracts;

namespace WodApp.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IPostService postService;
        private readonly IVoteSysService voteSysService;

        public CategoryController(IPostService postService,IVoteSysService voteSysService)
        {
            this.postService = postService;
            this.voteSysService = voteSysService;
        }
        public IActionResult Index(string category)
        {
            var model = new IndexPostViewModel
            {
                Posts = postService.GetAllPostFromCategory(category)
            };

            foreach (var post in model.Posts)
            {
                post.VoteCount = voteSysService.GetVoteCount(post.Id);
            }
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            ViewData["userId"] = userId;
            return View(model);
        }
    }
}