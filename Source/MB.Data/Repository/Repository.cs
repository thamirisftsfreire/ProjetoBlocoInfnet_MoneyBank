using MB.Data.Context;
using MB.Domain;
using MB.Domain.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MB.Data.Repository
{
    public class Repository<TEntity> : IRepository<TEntity>, IDisposable where TEntity : BaseEntity<int>
    {
        protected MoneyBankContext Ctx { get; }
        protected DbSet<TEntity> Set { get; }

        public Repository(MoneyBankContext context)
        {
            Ctx = context;
            Set = Ctx.Set<TEntity>();
        }
        public virtual async Task<TEntity> AddAsync(TEntity tEntity)
        {
            var entity = await Set.AddAsync(tEntity);
            return entity.Entity;
        }
        public virtual async Task<TEntity> FindAsync(int id)
        {
            return await Set.FindAsync(id);
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsNoTrackingAsync()
        {
            return await Set.AsNoTracking().ToListAsync();
        }

        public virtual TEntity Update(TEntity tEntity)
        {
            var entry = Ctx.Entry(tEntity);
            Set.Attach(tEntity);
            entry.State = EntityState.Modified;

            return tEntity;
        }

        public virtual void Remove(TEntity tEntity)
        {
            Set.Remove(tEntity);
        }

        public virtual async Task RemoveAsync(int id)
        {
            Set.Remove(await Set.FindAsync(id));
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                Ctx?.Dispose();
            }
        }

        public int SaveChanges()
        {
            return Ctx.SaveChanges();
        }

    }
}
