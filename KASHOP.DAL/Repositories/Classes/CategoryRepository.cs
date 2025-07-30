﻿using System;
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
    public class CategoryRepository : GenericRepository<Category>,ICategoryRepository
    {
       

        public CategoryRepository(ApplicationDbContext context):base(context)
        {
          
        }

   
    }
}
