using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KASHOP.DAL.DTO.Requests;
using KASHOP.DAL.DTO.Responses;
using KASHOP.DAL.Repositories;
using Mapster;
using KASHOP.DAL.Models;

namespace KASHOP.BLL.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        public int CreateCategory(CategoryRequest request)
        {
            var category = request.Adapt<Category>();
            return categoryRepository.add(category);
        }

        public int DeleteCategory(int id)
        {
            var category = categoryRepository.GetById(id);
            if (category is null) return 0;
            return categoryRepository.Remove(category);
        }

        public IEnumerable<CategoryResponse> GetAllCategories()
        {
            var categories = categoryRepository.GetAll();
            return categories.Adapt<IEnumerable<CategoryResponse>>();
        }

        public CategoryResponse? GetCategoryById(int id)
        {
            var category = categoryRepository.GetById(id);
           return category is null ? null : category.Adapt<CategoryResponse>();
        }

        public int UpdateCategory(int id, CategoryRequest request)
        {
            var category = categoryRepository.GetById(id);
            if (category is null) return 0;
            category.Name = request.Name;
            return categoryRepository.Update(category);
           
        }
        public bool ToggleStatus(int id )
        {
            var category = categoryRepository.GetById(id);
            if (category is null) return false;
            category.status = category.status == Status.Active ?Status.Inactive : Status.Active;
            categoryRepository.Update(category);
            return true;
        }
    }
}
