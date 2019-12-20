using MB.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MB.Domain.Interfaces.Services
{
    public interface IBankDataBaseService : IAccountService
    {
        Boolean AuthenticateUser(Account account);
    }
}
