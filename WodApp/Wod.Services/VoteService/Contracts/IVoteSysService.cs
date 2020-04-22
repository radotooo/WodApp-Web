using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Wod.Services.VoteService.Contracts
{
   public interface IVoteSysService
    {
        Task Create(string userId, int postId, bool VoteTupe);
        int GetVoteCount(int postId);
    }
}
