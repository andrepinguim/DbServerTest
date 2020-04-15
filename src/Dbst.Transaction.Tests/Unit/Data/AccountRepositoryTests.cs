using System.Threading.Tasks;
using Dbst.Transaction.Domain.Interfaces.Repositories;
using Dbst.Transaction.Infra.Data.Context;
using Dbst.Transaction.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace Dbst.Transaction.Tests.Unit.Data
{
    public class AccountRepositoryTests
    {
        public IAccountRepository Repository { get; private set; }

        public AccountRepositoryTests(string inMemoryDatabaseName = "Transaction_AccountRepositoryTests")
        {
            var dbOptionsBuilder = new DbContextOptionsBuilder<TransactionContext>().UseInMemoryDatabase(inMemoryDatabaseName);
            var context = new TransactionContext(dbOptionsBuilder.Options);
            context.Database.EnsureCreated();

            Repository = new AccountRepository(context);
        }

        [Theory]
        [InlineData(2)]
        [InlineData(1)]
        public async Task GetByValidId(int id)
        {
            var result = await Repository.SelectAsync(id);

            Assert.NotNull(result);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-3)]
        [InlineData(99999)]
        public async Task GetByUnknowId(int id)
        {
            var result = await Repository.SelectAsync(id);

            Assert.Null(result);
        }
    }
}
