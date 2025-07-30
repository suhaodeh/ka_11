using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using Azure;
using KASHOP.BLL.Services.Interfaces;
using KASHOP.DAL.Models;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using KASHOP.DAL.DTO.Requests;
using KASHOP.DAL.Repositories.Interfaces;
using KASHOP.DAL.Repositories.Classes;
using Mapster;
using KASHOP.DAL.DTO.Responses;

namespace KASHOP.BLL.Services.Classes
{
    public class GenericService<TRequest, TResponse, TEntity> : IGenericService <TRequest, TResponse, TEntity>
         where TEntity : BaseModel
    {
        private readonly IGenericRepository<TEntity> _repository;

        public GenericService(IGenericRepository<TEntity> genericRepository)
        {
           _repository =genericRepository;
        }
        public int Create(TRequest request)
        {
            var entity = request.Adapt<TEntity>();
            return _repository.add(entity);
        }

        public int Delete(int id)
        {
            var entity = _repository.GetById(id);
            if (entity is null) return 0;
            return _repository.Remove(entity);
        }

        public IEnumerable<TResponse> GetAll()
        {
            var entity = _repository.GetAll();
            return entity.Adapt<IEnumerable<TResponse>>();
        }

        public TResponse? GetById(int id)
        {
            var entity = _repository.GetById(id);
            return entity is null ? default : entity.Adapt<TResponse>();
        }

     

        public bool ToggleStatus(int id)
        {
            var entity = _repository.GetById(id);
            if (entity is null) return false;
            entity.status = entity.status == Status.Active ? Status.Inactive : Status.Active;
            _repository.Update(entity);
            return true;
        }

        public int Update(int id, TRequest request)
        {
            var entity = _repository.GetById(id);
            if (entity is null) return 0;
            var updateEntity = request.Adapt(entity);
            return _repository.Update(updateEntity);
        }

        public int Update(int id, CategoryRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
