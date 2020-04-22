using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Wod.Models.WodApp.Inputmodels;
using Wod.Models.WodApp.VIewModels.Post;

namespace Wod.Services.PostService.Contracts
{
    public interface IPostService
    {
        Task<int> GreateAsyns(string title, int categoryId, string userId, DateTime date, string PictureUrl);

        PostVIewModel Get(int Id);
        IEnumerable<PostVIewModel> GetAll();
    }
}
