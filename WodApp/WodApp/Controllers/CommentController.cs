using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Wod.Models.WodApp.Inputmodels;
using Wod.Services.CommentService.Contracts;

namespace WodApp.Controllers
{
    public class CommentController : Controller
    {
        private readonly ICommentService commentService;

        public CommentController(ICommentService commentService)
        {
            this.commentService = commentService;
        }
        [HttpPost]
        public IActionResult Create(CreateCommentInputModel input)
        {
           
            commentService.Greate(input);
            return this.RedirectToAction("ShowPost", "Post", new { Id = input.PostId });
        }
    }
}