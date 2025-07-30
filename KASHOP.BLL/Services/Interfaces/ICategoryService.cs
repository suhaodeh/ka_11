using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KASHOP.DAL.DTO.Requests;
using KASHOP.DAL.DTO.Responses;
using KASHOP.DAL.Models;

namespace KASHOP.BLL.Services.Interfaces
{
   public interface ICategoryService :IGenericService<CategoryRequest,CategoryResponse,Category>
    {
       
    
    }
}
