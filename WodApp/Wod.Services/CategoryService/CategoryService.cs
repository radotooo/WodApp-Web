using LearningSystem.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wod.Models;
using Wod.Models.WodApp.VIewModels.Category;
using Wod.Services.CategoryService.Contracts;

namespace Wod.Services.CategoryService
{
    public class CategoryService : ICategoryService
    {
        private readonly IRepository<Category> repository;

        public CategoryService(IRepository<Category> repository)
        {
            this.repository = repository;
        }
       

        public IEnumerable<CategoryDropDownViewModel> GetAll()
        {
            var categoryes = repository.Get().OrderBy(x=>x.Name).ToArray();
            var dropDown = new List<CategoryDropDownViewModel>();
            foreach (var item in categoryes)
            {
                dropDown.Add(new CategoryDropDownViewModel { Id = item.Id, Name = item.Name });
            }
            return dropDown;
        }
    }
}
