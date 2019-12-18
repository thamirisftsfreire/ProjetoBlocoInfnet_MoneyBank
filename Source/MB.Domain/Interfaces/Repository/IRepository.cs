using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MB.Domain.Interfaces.Repository
{
    public interface IRepository<TEntity> where TEntity : EntityBase<Guid>
    {
        Task<TEntity> AddAsync(TEntity tEntity);
        Task<TEntity> FindAsync(Guid id);
        Task<IEnumerable<TEntity>> GetAllAsNoTrackingAsync();
        TEntity Update(TEntity tEntity);
        Task RemoveAsync(Guid id);
        void Remove(TEntity tEntity);
        int SaveChanges();
    }
}
