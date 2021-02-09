using Microsoft.EntityFrameworkCore;
using SkillRoadmapBack.Core.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillRoadMapBack.DAL.Repositories.Base
{
    public class BaseRepo<TEntity> where TEntity : class, IBaseEntity
    {
        private readonly SkillRoadMapDbContext _context;
        private readonly DbSet<TEntity> _dbSet;
        protected BaseRepo(SkillRoadMapDbContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public virtual async Task AddAsync(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity).ConfigureAwait(false);
            await _context.SaveChangesAsync().ConfigureAwait(false);
            //return entity;
        }

        public virtual async Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await _context.Set<TEntity>().AddRangeAsync(entities).ConfigureAwait(false);
            await _context.SaveChangesAsync().ConfigureAwait(false);
        }

        public virtual async Task DeleteAsync(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
            await _context.SaveChangesAsync().ConfigureAwait(false);
        }

        public virtual async Task DeleteRangeAsync(IEnumerable<TEntity> entities)
        {
            _context.Set<TEntity>().RemoveRange(entities);
            await _context.SaveChangesAsync().ConfigureAwait(false);
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }

        public virtual IQueryable<TEntity> Get()
        {
            IQueryable<TEntity> query = _dbSet;
            return query;
        }

        public virtual async Task<TEntity> GetByIdAsync(int id)
        {
            return await _context.Set<TEntity>().Where(e => e.Id == id).FirstOrDefaultAsync().ConfigureAwait(false);
        }

        public void RefreshEntity(TEntity entity)
        {
            _context.Entry(entity).Reload();
        }

        public virtual async Task UpdateAsync(TEntity entity)
        {
            var local = _context.Set<TEntity>().Local.FirstOrDefault(entry => entry.Id.Equals(entity.Id));
            if (local != null) _context.Entry(local).State = EntityState.Detached;

            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync().ConfigureAwait(false);
        }

        public virtual async Task UpdateRangeAsync(IEnumerable<TEntity> entities)
        {
            _context.Set<TEntity>().UpdateRange(entities);
            await _context.SaveChangesAsync().ConfigureAwait(false);
        }
    }
}
