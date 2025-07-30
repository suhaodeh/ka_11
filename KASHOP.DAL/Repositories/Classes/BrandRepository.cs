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
  

        public class BrandRepository : GenericRepository<Brand>, IBrandRepository
        {


            public BrandRepository(ApplicationDbContext context) : base(context)
            {

            }


        }
    }

