using MB.Data.Context;
using MB.Domain.Entities;
using MB.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace MB.Data.Repository
{
    public class AccountRepository : Repository<Account>, IAccountRepository
    {
        public AccountRepository(MoneyBankContext context)
            : base(context)
        {

        }
    }
}
