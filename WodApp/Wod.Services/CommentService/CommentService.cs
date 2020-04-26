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
       
        private readonly ApplicationDbContext dbContext;

        public CommentService(ApplicationDbContext dbContext)
        {
            
            this.dbContext = dbContext;
        }
        public async Task Greate(CreateCommentInputModel input)
        {
            var comment = new Comment
            {
                CreatedOn = DateTime.UtcNow,
                Content = input.Content,
                PostId = input.PostId,
                UserId = input.UserId,
                ParentId= input.ParentId

            };
           
           
            await this.dbContext.Comments.AddAsync(comment);
            this.dbContext.SaveChanges();
            //await this.repository.AddAsync(comment);

        }
    }
}
