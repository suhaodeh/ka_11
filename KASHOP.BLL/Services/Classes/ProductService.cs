using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KASHOP.BLL.Services.Interfaces;
using KASHOP.DAL.Models;
using KASHOP.DAL.DTO.Requests;
using KASHOP.DAL.DTO.Responses;
using KASHOP.DAL.Repositories.Interfaces;
using Mapster;

namespace KASHOP.BLL.Services.Classes
{
 public   class ProductService: GenericService<ProductRequest,ProductResponse,Product>,IProductService
    {
        private readonly IFileService _fileService;
        private readonly IProductRepository _repository;

        public ProductService(IProductRepository repository,IFileService fileService) : base(repository)
        {
            _fileService = fileService;
            _repository = repository;
        }
        public async Task<int> CreateFile(ProductRequest request)
        {
            var entity = request.Adapt<Product>();
            entity.CreatedAt = DateTime.UtcNow;
            if(request.MainImage !=null)
            {
              var ImagePath=  await _fileService.UploadAsync(request.MainImage);
                entity.MainImage = ImagePath;
            }
            return _repository.add(entity);

        }

    
    }
}
