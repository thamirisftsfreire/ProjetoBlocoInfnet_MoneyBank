using MB.Data.Context;
using MB.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MB.Data.Uow
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MoneyBankContext _context;
        private bool _disposed;

        public UnitOfWork(MoneyBankContext context)
        {
            _context = context;
        }

        public void BeginTransaction()
        {
            _disposed = false;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            _disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
