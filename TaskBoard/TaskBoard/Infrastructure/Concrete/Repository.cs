using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using TaskBoard.Data;
using TaskBoard.Infrastructure.Abstract;

namespace TaskBoard.Infrastructure.Concrete
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly TaskBoardDbContext _dbContext;
        private readonly DbSet<TEntity> _dbSet;

        public Repository(TaskBoardDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<TEntity>();
        }

        public TEntity Create(TEntity entity)
        {
            _dbSet.Add(entity);
            return entity;
        }

        public TEntity GetSingle(Expression<Func<TEntity, bool>> criteria, params Expression<Func<TEntity, object>>[] includes)
        {
            var query = _dbSet.Where(criteria);
            return includes.Aggregate(query, (current, includeProperty) => current.Include(includeProperty)).FirstOrDefault();
        }

        public IEnumerable<TEntity> GetAll(params Expression<Func<TEntity, object>>[] includes)
        {
            return includes.Aggregate(_dbSet.AsQueryable(), (current, includeProperty) => current.Include(includeProperty)).ToList();
        }

        public IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> criteria, params Expression<Func<TEntity, object>>[] includes)
        {
            var query = _dbSet.Where(criteria);
            return includes.Aggregate(query, (current, includeProperty) => current.Include(includeProperty)).ToList();
        }

        public TEntity Update(TEntity entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            return entity;
        }

        public void Delete(TEntity entity)
        {
            _dbSet.Remove(entity);
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
    }
}
