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
using Mapster;
namespace KASHOP.BLL.Services.Classes
{
  public  class BrandService :GenericService<BrandRequest,BrandResponse,Brand>,IBrandservice
    {
        private readonly IBrandRepository _repository;
        private readonly IFileService _fileService;

        public BrandService(IBrandRepository repository,IFileService fileService) : base(repository)
        {
            _repository = repository;
            _fileService = fileService;
        }

        public async Task<int> CreateFile(BrandRequest request)
        {
            var entity = request.Adapt<Brand>();
            entity.CreatedAt = DateTime.UtcNow;
            if (request.MainImage != null)
            {
              var ImagePath=  await _fileService.UploadAsync(request.MainImage);
                entity.MainImage = ImagePath;

            }
            return _repository.add(entity);





        }
    }
        }
    


