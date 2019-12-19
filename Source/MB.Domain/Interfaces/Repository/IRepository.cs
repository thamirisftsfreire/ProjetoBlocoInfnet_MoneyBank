using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MB.Domain.Interfaces.Repository
{
    public interface IRepository<TEntity> where TEntity : BaseEntity<int>
    {
        Task<TEntity> AddAsync(TEntity tEntity);
        Task<TEntity> FindAsync(int id);
        Task<IEnumerable<TEntity>> GetAllAsNoTrackingAsync();
        TEntity Update(TEntity tEntity);
        Task RemoveAsync(int id);
        void Remove(TEntity tEntity);
        int SaveChanges();
    }
}
