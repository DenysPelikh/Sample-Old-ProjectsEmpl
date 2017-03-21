using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;

namespace PrEmpWin.DAL.Repository
{
    class GenericRepository<TEntity> where TEntity : class
    {
        private readonly EmpDBEntities _context;
        private readonly DbSet<TEntity> _dbSet;

        public GenericRepository()
        {
            _context = new EmpDBEntities();
            _dbSet = _context.Set<TEntity>();
        }

        public virtual IEnumerable<TEntity> Get()
        {
            return _dbSet.ToList();
        }

        public virtual IEnumerable<TEntity> GetMany(Func<TEntity, bool> where)
        {
            return _dbSet.Where(where).ToList();
        }

        public virtual void Delete(object id)
        {
            var entityToDelete = _dbSet.Find(id);
            Delete(entityToDelete);
            _context.SaveChanges();
        }

        public virtual void Delete(TEntity entityToDelete)
        {
            if (_context.Entry(entityToDelete).State == EntityState.Detached)
            {
                _dbSet.Attach(entityToDelete);
            }

            _dbSet.Remove(entityToDelete);
            _context.SaveChanges();
        }

        public virtual TEntity GetById(object id)
        {
            var entity = _dbSet.Find(id);

            if (entity == null)
            {
                throw new NullReferenceException();
            }

            return entity;
        }

        public virtual TEntity GetById(Func<TEntity, bool> where)
        {
            var entity = _dbSet.Where(where).First();

            if (entity == null)
            {
                throw new NullReferenceException();
            }

            return entity;
        }

        public virtual void Add(TEntity entity)
        {
            _dbSet.Add(entity);
            _context.SaveChanges();
        }

        public virtual void Update(TEntity entityToUpdate)
        {
            _dbSet.Attach(entityToUpdate);
            _context.Entry(entityToUpdate).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
