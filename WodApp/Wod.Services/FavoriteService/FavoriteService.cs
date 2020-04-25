using LearningSystem.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wod.Data.Models;
using Wod.Services.FavoriteService.Contracts;
using WodApp.Data;

namespace Wod.Services.FavoriteService
{
    public class FavoriteService : IFavoriteService
    {
        private readonly IRepository<Favorite> repository;
        private readonly ApplicationDbContext dbContext;

        public FavoriteService(IRepository<Favorite> repository,ApplicationDbContext dbContext)
        {
            this.repository = repository;
            this.dbContext = dbContext;
        }
        public async Task<string> Create(int postId, string userId, string tittle)
        {
            var chekIdALreadyAdded = this.repository.All().Where(x => x.UserId == userId && x.PostId == postId).ToList();
            if (chekIdALreadyAdded.Count <= 0)
            {
                var favorite = new Favorite
                {
                    PostId = postId,
                    UserId = userId,
                    AddetOn = DateTime.UtcNow
                };
                await this.repository.AddAsync(favorite);
                return $"{tittle} has beeen added to your Favorites!";
            }

            return $"{tittle} already in your Favorites!";
        }

        public async Task<string> Delete(string userId,int postId,string tittle)
        {

           var entity =  repository.Get().FirstOrDefault(x => x.UserId == userId && x.PostId == postId);
           
           
                await repository.RemoveAsync(entity);

            return $"{tittle} has beeen removed from your Favorites!";

        }
           


        //to do vzemi vsi4ki favriti ot tqh id-tata na postovete vzima6 postovete posle i sme gotovi
        public IEnumerable<Favorite> GetAll(string userId)
        {

            var favorite = this.repository.All().Where(x => x.UserId == userId).OrderByDescending(x=>x.AddetOn).ToList();

            return favorite;
        }
    }
}
