using LearningSystem.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wod.Data.Models;
using Wod.Services.FavoriteService.Contracts;

namespace Wod.Services.FavoriteService
{
    public class FavoriteService : IFavoriteService
    {
        private readonly IRepository<Favorite> repository;

        public FavoriteService(IRepository<Favorite> repository)
        {
            this.repository = repository;
        }
        public async Task<string> Create(int postId, string userId, string tittle)
        {
            var chekIdALreadyAdded = repository.All().Where(x => x.UserId == userId && x.PostId == postId).ToList();
            if (chekIdALreadyAdded.Count <= 0)
            {
                var favorite = new Favorite
                {
                    PostId = postId,
                    UserId = userId
                };
                await this.repository.AddAsync(favorite);
                return $"{tittle} has beeen added to your Favorites!";
            }

            return $"{tittle} already in your Favorites!";
        }
    }
}
