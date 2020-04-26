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

using Wod.Services.VoteService.Contracts;
using Wod.Data.Models;

namespace Wod.Services.PostService
{
    public class PostService : IPostService

    {
        private readonly IRepository<Post> postsRepo;

        private readonly IVoteSysService voteSysService;

        public PostService(IRepository<Post> postsRepo, IVoteSysService voteSysService)
        {
            this.postsRepo = postsRepo;

           
            this.voteSysService = voteSysService;
        }

        public async Task<PostVIewModel> GetAsync(int Id)
        {
           
            var currentPost = await this.postsRepo.FindByIdAsync(Id);

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
                UserAvatarUrl = currentPost.User.AvatarUrl,
             
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
                    Tittle = post.Tittle,
                    VoteCount = voteSysService.GetVoteCount(post.Id)
                });
            }
           

            return posts;
        }
        
        public  IEnumerable<PostVIewModel> GetAllPostFromCategory(string name)
        {
            var allPost = this.postsRepo.All().Where(x => x.Category.Name == name);
            var posts = new List<PostVIewModel>();
            foreach (var post in allPost)
            {
                posts.Add(new PostVIewModel
                {
                    Id = post.Id,
                    CategoryName = post.Category.Name,
                    CreatedOn = post.CreatedOn,
                    UserUsernameName = post.User.UserName,
                    Comments = post.Comments,
                    PictureUrl = post.PictureUrl,
                    Tittle = post.Tittle,
                    VoteCount = voteSysService.GetVoteCount(post.Id)
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

        public async Task<IndexPostViewModel> GetAll(IEnumerable<Favorite> favorites)
        {
            var favoritePostsIds = new List<Post>();
          
            foreach (var postId in favorites)
            {
                favoritePostsIds.Add(await this.postsRepo.FindByIdAsync(postId.PostId));
        
            }
            var postView = new List<PostVIewModel>();

            foreach (var post in favoritePostsIds)
            {
                postView.Add(new PostVIewModel
                {
                    Id = post.Id,
                    CategoryName = post.Category.Name,
                    CreatedOn = post.CreatedOn,
                    UserUsernameName = post.User.UserName,
                    Comments = post.Comments,
                    PictureUrl = post.PictureUrl,
                    Tittle = post.Tittle,
                    VoteCount = voteSysService.GetVoteCount(post.Id)
                });
            }
           
            return new IndexPostViewModel {Posts=postView };
        }
    }
}
