using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KASHOP.BLL.Services.Classes;
using KASHOP.DAL.DTO.Requests;
using KASHOP.DAL.DTO.Responses;
using KASHOP.DAL.Models;
using KASHOP.DAL.Repositories.Interfaces;

namespace KASHOP.BLL.Services.Interfaces
{
    public interface IBrandservice : IGenericService<BrandRequest, BrandResponse, Brand> {

        Task<int> CreateFile(BrandRequest request);
            }
 
}
