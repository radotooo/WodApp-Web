using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Wod.Data.Models;

namespace Wod.Services.FavoriteService.Contracts
{
    public interface IFavoriteService
    {
        Task<string> Create(int postId, string userId , string tittle);
        IEnumerable<Favorite> GetAll(string userId);
        Task<string> Delete(string userId , int postId,string tittle);
    }
}
