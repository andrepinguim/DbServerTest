using Dbst.Transaction.Domain.Interfaces.Services;
using Dbst.Transaction.Service.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Dbst.Transaction.Infra.CrossCutting.DependencyInjection
{
    public class ConfigureService
    {
        public static void ConfigureDependenciesService(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IAccountService, AccountService>();
            serviceCollection.AddTransient<ITransactionService, TransactionService>();
        }
    }
}
