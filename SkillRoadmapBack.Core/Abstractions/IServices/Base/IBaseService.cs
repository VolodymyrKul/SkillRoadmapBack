using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SkillRoadmapBack.Core.Abstractions.IServices.Base
{
    public interface IBaseService<TEntity, REntity> 
        where TEntity : class
        where REntity : class
    {
        Task CreateAsync(REntity entity);
        Task<List<TEntity>> GetAll();
        Task<TEntity> GetIdAsync(int id);
        Task<TEntity> UpdateAsync(TEntity entity);
        Task DeleteAsync(int id);
    }
}
