using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KASHOP.DAL.DTO.Requests;
using KASHOP.DAL.DTO.Responses;
using Mapster;
using KASHOP.DAL.Models;
using KASHOP.DAL.Repositories.Interfaces;
using KASHOP.BLL.Services.Interfaces;

namespace KASHOP.BLL.Services.Classes
{
    public class CategoryService : GenericService<CategoryRequest,CategoryResponse,Category>,ICategoryService
    {
        public CategoryService(ICategoryRepository repository) : base(repository) { }
        

     

    

     
      
    }
}
