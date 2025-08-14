using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KASHOP.DAL.Data;
using KASHOP.DAL.Models;
    
using KASHOP.DAL.Repositories.Interfaces;

namespace KASHOP.DAL.Repositories.Classes
{
 public class ProductRepository:GenericRepository<Product>,IProductRepository
    {
        public ProductRepository(ApplicationDbContext context) : base(context) { }
    }
}
