using LearningSystem.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wod.Data.Models;
using Wod.Data.Models.Enums;
using Wod.Services.VoteService.Contracts;

namespace Wod.Services.VoteService
{
    public class VoteSysService : IVoteSysService
    {
        private readonly IRepository<Vote> repository;

        public VoteSysService(IRepository<Vote> repository)
        {
            this.repository = repository;
        }
        public async Task Create(string userId, int postId, bool VoteTupe)
        {
            var vote = repository.All().FirstOrDefault(x => x.PostId == postId && x.UserId == userId);
            if (vote != null)
            {
                vote.Value = VoteTupe ? VoteValueEnum.ThumbsUp : VoteValueEnum.ThumbsDown;
            }
            else
            {
               vote = new Vote
                {
                    UserId = userId,
                    PostId = postId,
                    Value = VoteTupe ? VoteValueEnum.ThumbsUp : VoteValueEnum.ThumbsDown

                };
                await repository.AddAsync(vote);
            }
            await repository.SaveChangesAsync();
        }

        public int GetVoteCount(int postId)
        {
           var result = repository.Get().Where(x => x.PostId == postId);
            return result.Sum(x => (int)x.Value);
        }
    }
}
