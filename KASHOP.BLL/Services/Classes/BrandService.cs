using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KASHOP.DAL.DTO.Requests;
using KASHOP.DAL.DTO.Responses;
using KASHOP.DAL.Models;
using KASHOP.DAL.Repositories.Interfaces;
using KASHOP.BLL.Services.Interfaces;
namespace KASHOP.BLL.Services.Classes
{
  public  class BrandService :GenericService<BrandRequest,BrandResponse,Brand>,IBrandservice
    {
           
        public BrandService(IBrandRepository repository) : base(repository) { }
    
}
}
