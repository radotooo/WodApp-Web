using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Wod.Models.WodApp.Inputmodels;

using Wod.Data;
using Wod.Services.PostService.Contracts;
using Wod.Models;
using LearningSystem.Repository.Contracts;
using Wod.Services.Claudinary.Contracts;
using Microsoft.AspNetCore.Identity;
using Wod.Models.WodApp.VIewModels.Post;
using System.Linq;
using WodApp.Data;
using Microsoft.EntityFrameworkCore;

namespace Wod.Services.PostService
{
    public class PostService : IPostService

    {
        private readonly IRepository<Post> postsRepo;

        private readonly UserManager<ApplicationUser> userManager;
        private readonly ApplicationDbContext dbContext;

        public PostService(IRepository<Post> postsRepo, UserManager<ApplicationUser> userManager,ApplicationDbContext dbContext)
        {
            this.postsRepo = postsRepo;

            this.userManager = userManager;
            this.dbContext = dbContext;
        }

        public PostVIewModel Get(int Id)
        {
           // var postWithDb = dbContext.Posts.Where(x => x.Id == Id).Include(c => c.Category.Name).Include(b => b.User.UserName).ToList();
            
            var currentPost = postsRepo.All().Where(x => x.Id == Id).FirstOrDefault();
            var model = new PostVIewModel
            {
                CategoryName = currentPost.Category.Name,
             CreatedOn = currentPost.CreatedOn,
                UserUsernameName = currentPost.User.UserName,
                Comments = currentPost.Comments,
                PictureUrl = currentPost.PictureUrl,
                Tittle = currentPost.Tittle,
                UserId = currentPost.UserId,
                Id=currentPost.Id,
                UserAvatarUrl = currentPost.User.AvatarUrl

            };




            return model;
        }

        public IEnumerable<PostVIewModel> GetAll()
        {
            var allPost = this.postsRepo.Get();
            var posts = new List<PostVIewModel>();
            foreach (var post in allPost)
            {
                posts.Add(new PostVIewModel
                {
                    Id=post.Id,
                    CategoryName = post.Category.Name,
                    CreatedOn = post.CreatedOn,
                    UserUsernameName = post.User.UserName,
                    Comments = post.Comments,
                    PictureUrl = post.PictureUrl,
                    Tittle = post.Tittle
                });
            }
           

            return posts;
        }

        public async Task<int> GreateAsyns(string title, int categoryId, string userId, DateTime date, string PictureUrl)
        {

            var post = new Post
            {
                Tittle = title,
                CategoryId = categoryId,
                UserId = userId,
                CreatedOn = date,
                PictureUrl = PictureUrl

            };

            await this.postsRepo.AddAsync(post);
            return post.Id;
        }

    }
}
