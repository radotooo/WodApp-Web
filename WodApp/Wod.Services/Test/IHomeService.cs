using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WodApp.Models;

namespace WodApp.Services.Test
{
    public interface IHomeService
    {
        Task GreateAsyns(CreateMovementInputModel input);
    }
}
