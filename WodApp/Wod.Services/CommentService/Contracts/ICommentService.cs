using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Wod.Models.WodApp.Inputmodels;

namespace Wod.Services.CommentService.Contracts
{
    public interface ICommentService
    {
         Task Greate(CreateCommentInputModel input);
    }
}
