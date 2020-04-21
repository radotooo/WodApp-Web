using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Wod.Models;
using Wod.Models.WodApp.VIewModels.Category;

namespace Wod.Services.CategoryService.Contracts
{
    public interface ICategoryService
    {
        IEnumerable<CategoryDropDownViewModel> GetAll();
    }
}
