using MB.Domain.Aggregations.AccountAggregate.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MB.Domain.Aggregations.AccountAggregate.Interfaces.Services
{
    public interface IBankDataBaseService : IAccountService
    {
        Boolean AuthenticateUser(Account account);
    }
}
