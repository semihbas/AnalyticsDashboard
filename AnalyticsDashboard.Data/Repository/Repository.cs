using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AnalyticsDashboard.Data.Entity;
using AnalyticsDashboard.Data.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace AnalyticsDashboard.Data.Repository
{
    public class Repository<TEntity> : IRepository<TEntity>
  where TEntity : class, IEntity, new()
    {
        private readonly DbContext _context;
        public Repository(DbContext context)
        {
            _context = context;
        }
        public async Task<TEntity> Get(Expression<Func<TEntity, bool>> filter)
        {
            var entity = await _context.Set<TEntity>().SingleOrDefaultAsync(filter);
            return entity;
        }

        public async Task<IList<TEntity>> GetList(Expression<Func<TEntity, bool>> filter = null)
        {
            List<TEntity> entities;
            if (filter == null)
            {
                entities = await _context.Set<TEntity>().ToListAsync();
                return entities;
            }

            entities = await _context.Set<TEntity>().Where(filter).ToListAsync();
            return entities;
        }

        public async Task<TEntity> Add(TEntity entity)
        {
            var addedEntity = _context.Entry(entity);
            addedEntity.State = EntityState.Added;
            await _context.SaveChangesAsync();
            return addedEntity.Entity;

        }

        public async Task<TEntity> Update(TEntity entity)
        {
            var updatedEntity = _context.Entry(entity);
            updatedEntity.State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return updatedEntity.Entity;
        }

        public async Task Delete(TEntity entity)
        {
            var deletedEntity = _context.Entry(entity);
            deletedEntity.State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }
    }
}
