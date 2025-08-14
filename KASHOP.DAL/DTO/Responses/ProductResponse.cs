using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace KASHOP.DAL.DTO.Responses
{
 public   class ProductResponse
    {
        public String Name { get; set; }
        public String Description { get; set; }

        [JsonIgnore]
        public string MainImage { get; set; }
        public string MainImageUrl => $"https://localhost:7205/images/{MainImage}";
    }
}
