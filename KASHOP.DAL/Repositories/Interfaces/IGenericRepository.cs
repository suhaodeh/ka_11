using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KASHOP.DAL.Models;

namespace KASHOP.DAL.Repositories.Interfaces
{
   public interface IGenericRepository<T> where T :BaseModel
    {

        int add(T entity);
        IEnumerable<T> GetAll(bool withTracking = false);
        int Remove(T entity);
        int Update(T entity);
        T? GetById(int id);
    }
}
