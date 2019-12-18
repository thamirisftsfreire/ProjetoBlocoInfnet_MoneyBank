using System;
using System.Collections.Generic;
using System.Text;

namespace MB.Data.Interfaces
{
    public interface IUnitOfWork
    {
        void BeginTransaction();
        void Commit();
    }
}
