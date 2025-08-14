using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace KASHOP.DAL.DTO.Requests
{
   public class BrandRequest
    {
public string Name { get; set; }
        public IFormFile MainImage { get; set; }
    }
}
