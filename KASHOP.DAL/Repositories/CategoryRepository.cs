using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KASHOP.DAL.Data;
using KASHOP.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace KASHOP.DAL.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext dbcontext;

        public CategoryRepository(ApplicationDbContext context)
        {
            dbcontext = context;
        }

        public int add(Category category)
        {
            dbcontext.Categories.Add(category);
            return dbcontext.SaveChanges();
        }

        public IEnumerable<Category> GetAll(bool withTracking = false)
        {
            if (withTracking)
            return dbcontext.Categories.ToList();
            return dbcontext.Categories.AsNoTracking().ToList();
        }

        public Category? GetById(int id)
        {
            return dbcontext.Categories.Find(id);

        }

        public int Remove(Category category)
        {
            dbcontext.Categories.Remove(category);
           return dbcontext.SaveChanges();
                
        }

        public int Update(Category category)
        {
            dbcontext.Categories.Update(category);
            return dbcontext.SaveChanges();
        }
    }
}
