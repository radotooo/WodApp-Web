using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WodApp.Data;

namespace Wod.Data.SeedingData.Contracts
{
    public interface ISeeder
    {
        Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider);

    }
}
