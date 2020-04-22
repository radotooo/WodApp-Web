using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Wod.Data;
using Wod.Models.WodApp.Inputmodels;
using Wod.Models.WodApp.VIewModels.Vote;
using Wod.Services.VoteService.Contracts;

namespace WodApp.Controllers
{
    [Route("api/Vote")]
    [ApiController]
    public class VoteApiController : ControllerBase
    {
        private readonly IVoteSysService voteSysService;
        private readonly UserManager<ApplicationUser> appUser;

        public VoteApiController(IVoteSysService voteSysService ,UserManager<ApplicationUser> appUser)
        {
            this.voteSysService = voteSysService;
            this.appUser = appUser;
        }
        //[Authorize]
        [HttpPost]
        public async Task<ActionResult<VoteViewModel>> Vote(VoteInputModel input)
            {
          
            await voteSysService.Create(appUser.GetUserId(User), input.PostId, input.VoteType);
            var voteCount = voteSysService.GetVoteCount(input.PostId);
            return new VoteViewModel { Count = voteCount};
            }
    }
}