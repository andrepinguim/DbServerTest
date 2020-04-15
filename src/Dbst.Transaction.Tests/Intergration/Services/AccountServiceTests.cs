using System;
using System.Threading.Tasks;
using Dbst.Transaction.Domain.Interfaces.Services;
using Dbst.Transaction.Service.Services;
using Dbst.Transaction.Tests.Unit.Data;
using Xunit;

namespace Dbst.Transaction.Tests.Intergration.Services
{
    public class AccountServiceTests
    {
        public IAccountService AccountService { get; private set; }

        public AccountServiceTests(string inMemoryDatabaseName = "Transaction_UserServiceTests")
        {
            var accountRepository = new AccountRepositoryTests(inMemoryDatabaseName).Repository;

            AccountService = new AccountService(accountRepository);
        }

        [Theory]
        [InlineData(2)]
        [InlineData(1)]
        public async Task GetByValidId(int id)
        {
            var result = await AccountService.SelectAsync(id);

            Assert.NotNull(result);
        }

        [Fact]
        public async Task GetByUnknowId()
        {
            var result = await AccountService.SelectAsync(99999);

            Assert.Null(result);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-3)]
        public async Task GetByInvalidId(int id)
        {
            await Assert.ThrowsAsync<ArgumentException>(async () => await AccountService.SelectAsync(id));
        }
    }
}
