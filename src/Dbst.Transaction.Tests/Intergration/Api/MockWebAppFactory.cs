using Dbst.Transaction.Infra.Data.Context;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Dbst.Transaction.Tests.Intergration.Api
{
    public class MockWebAppFactory<TStartup> : WebApplicationFactory<TStartup> where TStartup : class
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                var serviceProvider = new ServiceCollection()
                        .AddEntityFrameworkInMemoryDatabase()
                        .BuildServiceProvider();

                services.AddDbContext<TransactionContext>(options =>
                {
                    options.UseInMemoryDatabase("Transaction_Tests");
                    options.UseInternalServiceProvider(serviceProvider);
                });

                var sp = services.BuildServiceProvider();

                using (var scope = sp.CreateScope())
                {
                    var db = scope.ServiceProvider.GetRequiredService<TransactionContext>();

                    db.Database.EnsureCreated();
                }
            });
        }
    }
}
