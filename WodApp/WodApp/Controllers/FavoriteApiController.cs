using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Wod.Models.WodApp.Inputmodels;
using Wod.Models.WodApp.VIewModels.Favorite;
using Wod.Services.FavoriteService.Contracts;

namespace WodApp.Controllers
{
    [Route("api/Favorite")]
    [ApiController]
    public class FavoriteApiController : ControllerBase
    {
        private readonly IFavoriteService favoriteService;

        public FavoriteApiController(IFavoriteService favoriteService)
        {
            this.favoriteService = favoriteService;
        }

        [HttpPost]
        public async Task<ActionResult<FavoriteApiViewModel>> Favorite(FavoriteApiInputModel input)
        {

          var result =   await favoriteService.Create(input.PostId, input.UserId,input.Tittle);

            return new FavoriteApiViewModel { Message = result }; 
        }
    }
}