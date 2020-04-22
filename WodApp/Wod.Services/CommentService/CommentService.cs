using LearningSystem.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Wod.Models;
using Wod.Models.WodApp.Inputmodels;
using Wod.Services.CommentService.Contracts;
using WodApp.Data;

namespace Wod.Services.CommentService
{
    public class CommentService : ICommentService
    {
        private readonly IRepository<Comment> repository;
        private readonly ApplicationDbContext dbContext;

        public CommentService(IRepository<Comment> repository, ApplicationDbContext dbContext)
        {
            this.repository = repository;
            this.dbContext = dbContext;
        }
        public async Task Greate(CreateCommentInputModel input)
        {
            var comment = new Comment
            {
                CreatedOn = DateTime.UtcNow,
                Content = input.Content,
                PostId = input.PostId,
                UserId = input.UserId

            };
            //Give error with repository for some reason ...ToDO..
            await this.dbContext.Comments.AddAsync(comment);
            this.dbContext.SaveChanges();
            //await this.repository.AddAsync(comment);
           
        }
    }
}
