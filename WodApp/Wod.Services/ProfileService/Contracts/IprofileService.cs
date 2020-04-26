using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Wod.Data;
using Wod.Models.WodApp.VIewModels;

namespace Wod.Services.ProfileService.Contracts
{
   public  interface IprofileService
    {
        UserViewModel GetByUsername(string username);
        
    }
}
