using MB.Application.AccountAppServices;
using MB.Application.Interfaces;
using MB.Application.ViewModels;
using MB.Data.Context;
using MB.Data.Interfaces;
using MB.Data.Repository;
using MB.Data.Uow;
using MB.Domain.Entities;
using MB.Domain.Interfaces.Repository;
using MB.Domain.Interfaces.Services;
using MB.Domain.Services;
using SimpleInjector;

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
            container.Register<ATMViewModel>(Lifestyle.Scoped);
            container.Register<CashDispenserViewModel>(Lifestyle.Scoped);
            container.Register<DepositSlotViewModel>(Lifestyle.Scoped);
            container.Register<KeypadViewModel>(Lifestyle.Scoped);
            container.Register<ScreenViewModel>(Lifestyle.Scoped);
            container.Register<IBalanceInquiryAppService, BalanceInquiryAppService>(Lifestyle.Scoped);
            container.Register<IDepositAppService, DepositAppService>(Lifestyle.Scoped);
            container.Register<IWithdrawalAppService, WithdrawalAppService>(Lifestyle.Scoped);

            // Domain
            container.Register<Account>(Lifestyle.Scoped);
            container.Register<Client>(Lifestyle.Scoped);
            container.Register<IAccountService, AccountService>(Lifestyle.Scoped);
            container.Register<IBalanceInquiryService, BalanceInquiryService>(Lifestyle.Scoped);
            container.Register<IBankDataBaseService, BankDataBaseService>(Lifestyle.Scoped);
            container.Register<IDepositService, DepositService>(Lifestyle.Scoped);
            container.Register<IWithdrawalService, WithdrawalService>(Lifestyle.Scoped);

            // Infra Dados
            container.Register<IClientRepository, ClientRepository>(Lifestyle.Scoped);
            container.Register<IAccountRepository, AccountRepository>(Lifestyle.Scoped);
            container.Register<IUnitOfWork, UnitOfWork>(Lifestyle.Scoped);
            container.Register<MoneyBankContext>(Lifestyle.Scoped);

        }
    }
}
