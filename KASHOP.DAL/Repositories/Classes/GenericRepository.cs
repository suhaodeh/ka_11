using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KASHOP.DAL.Data;
using KASHOP.DAL.Models;
using KASHOP.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace KASHOP.DAL.Repositories.Classes
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseModel
    {

        private readonly ApplicationDbContext dbcontext;

        public GenericRepository(ApplicationDbContext context)
        {
            dbcontext = context;
        }
        public int add(T entity)
        {
            dbcontext.Set<T>().Add(entity);
            return dbcontext.SaveChanges();
        }

        public IEnumerable<T> GetAll(bool withTracking = false)
        {
            if (withTracking)
                return dbcontext.Set<T>().ToList();
            return dbcontext.Set<T>().AsNoTracking().ToList();
        }

    
        

        public T? GetById(int id)
        {

            return dbcontext.Set<T>().Find(id);
        }

        public int Remove(T entity)
        {
            dbcontext.Set<T>().Remove(entity);
            return dbcontext.SaveChanges();
        }

        public int Update(T entity)
        {
            dbcontext.Set<T>().Update(entity);
            return dbcontext.SaveChanges();
        }
    }
}
