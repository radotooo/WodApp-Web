using LearningSystem.Repository.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WodApp.Data;
using WodApp.Data.Domain;
using WodApp.Models;

namespace WodApp.Services.Test
{
    public class HomeService :IHomeService
    {
        
        private readonly IRepository<WodMovements> repository;

        public HomeService(IRepository<WodMovements> repository)
        {
            
            
            this.repository = repository;
        }

        

        public async Task GreateAsyns(CreateMovementInputModel input)
        {
            var movement = new WodMovements
            {
                Name = input.Name
            };
            await repository.AddAsync(movement);
           
        }
    }
}
