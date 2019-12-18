using MB.Data.Context;
using MB.Data.Interfaces;
using MB.Data.Repository;
using MB.Data.Uow;
using MB.Domain.Interfaces.Repository;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Text;

namespace MB.CrossCutting
{
    public class BootStrapper
    {
        public static void RegisterServices(Container container)
        {
            // Lifestyle.Transient => Uma instancia para cada solicitacao;
            // Lifestyle.Singleton => Uma instancia unica para a classe
            // Lifestyle.Scoped => Uma instancia unica para o request

            // App


            // Domain


            // Infra Dados
            container.Register<IClientRepository, ClientRepository>(Lifestyle.Scoped);
            container.Register<IAccountRepository, AccountRepository>(Lifestyle.Scoped);
            container.Register<IUnitOfWork, UnitOfWork>(Lifestyle.Scoped);
            container.Register<MoneyBankContext>(Lifestyle.Scoped);

        }
    }
}
