using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Wod.Data.Models;
using Wod.Models.WodApp.Inputmodels;
using Wod.Models.WodApp.VIewModels.Post;

namespace Wod.Services.PostService.Contracts
{
    public interface IPostService
    {
        Task<int> GreateAsyns(string title, int categoryId, string userId, DateTime date, string PictureUrl);

        Task<PostVIewModel> GetAsync(int Id);
        
        IEnumerable<PostVIewModel> GetAll();
        Task<IndexPostViewModel> GetAll(IEnumerable<Favorite> favorites);

        IEnumerable<PostVIewModel> GetAllPostFromCategory(string name);

    }
}
