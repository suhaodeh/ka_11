﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KASHOP.DAL.Models;
using Microsoft.AspNetCore.Http;

namespace KASHOP.DAL.DTO.Requests
{
  public  class ProductRequest
    {
        public String Name { get; set; }
        public String Description { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public int Quantity { get; set; }
      
        
        //img
      public IFormFile MainImage { get; set; }


        public double Rate { get; set; }
        public int CategoryId { get; set; }

        public int? BrandId { get; set; }
        
    }
}
