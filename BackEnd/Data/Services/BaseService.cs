using BackEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Data.Services
{
    public abstract class BaseService<TEntity, TRepository> : IService<TEntity>
        where TEntity : class, IEntity
        where TRepository : IRepository<TEntity>
    {
        TRepository repository;

        public BaseService(TRepository repository)
        {
            this.repository = repository;
        }

        public async Task<TEntity> Add(TEntity entity)
        {
            return await repository.Add(entity);
        }

        public async Task<TEntity> Delete(int id)
        {
            return await repository.Delete(id);
        }

        public async Task<TEntity> Get(int id)
        {
            return await repository.Get(id);
        }

        public async Task<List<TEntity>> GetAll()
        {
            return await repository.GetAll();
        }

        public async Task<TEntity> Update(TEntity entity)
        {
            return await repository.Update(entity);
        }
    }
}
