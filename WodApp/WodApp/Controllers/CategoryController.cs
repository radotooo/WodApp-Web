using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Wod.Models.WodApp.VIewModels.Post;
using Wod.Services.PostService.Contracts;

namespace WodApp.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IPostService postService;

        public CategoryController(IPostService postService)
        {
            this.postService = postService;
        }
        public IActionResult Index(string category)
        {
            var model = new IndexPostViewModel
            {
                Posts = postService.GetAllPostFromCategory(category)
            };


            return View(model);
        }
    }
}