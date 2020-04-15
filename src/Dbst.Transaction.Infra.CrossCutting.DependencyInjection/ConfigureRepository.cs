using Dbst.Transaction.Domain.Interfaces.Repositories;
using Dbst.Transaction.Infra.Data.Context;
using Dbst.Transaction.Infra.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace Dbst.Transaction.Infra.CrossCutting.DependencyInjection
{
    public class ConfigureRepository
    {
        public static void ConfigureDependenciesRepository(IServiceCollection serviceCollection, string connString)
        {
            serviceCollection.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            serviceCollection.AddScoped<IAccountRepository, AccountRepository>();
            serviceCollection.AddScoped<ITransactionRepository, TransactionRepository>();

            serviceCollection.AddDbContext<TransactionContext>(opt => opt.UseSqlite(connString));
        }
    }
}
