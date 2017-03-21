using System;
using System.Collections.Generic;

namespace Empl.Models.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> Get();

        IEnumerable<TEntity> GetMany(Func<TEntity, bool> where);

        void Delete(object id);

        void Delete(TEntity entityToDelete);

        TEntity GetById(object id);

        TEntity GetById(Func<TEntity, bool> where);

        void Add(TEntity entity);

        void Update(TEntity entityToUpdate);
    }
}