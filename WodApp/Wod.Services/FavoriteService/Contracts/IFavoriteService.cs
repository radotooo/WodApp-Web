using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Wod.Services.FavoriteService.Contracts
{
    public interface IFavoriteService
    {
        Task<string> Create(int postId, string userId , string tittle);
    }
}
