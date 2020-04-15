using System;
using System.Linq;
using System.Threading.Tasks;
using Dbst.Transaction.Domain.Exceptions;
using Dbst.Transaction.Domain.Interfaces.Services;
using Dbst.Transaction.Infra.Data.Context;
using Dbst.Transaction.Service.Services;
using Dbst.Transaction.Tests.Unit.Data;
using Xunit;

namespace Dbst.Transaction.Tests.Intergration.Services
{
    public class TransactionServiceTests
    {
        public TransactionContext Context { get; private set; }
        public ITransactionService TransactionService { get; private set; }
        public IAccountService AccountService { get; private set; }

        public TransactionServiceTests(string inMemoryDatabaseName = "Transaction_UserServiceTests")
        {
            var transactionRepositoryTests = new TransactionRepositoryTests(inMemoryDatabaseName);
            var TransactionRepository = transactionRepositoryTests.Repository;
            var AccountService = new AccountServiceTests(inMemoryDatabaseName).AccountService;

            Context = transactionRepositoryTests.Context;
            TransactionService = new TransactionService(TransactionRepository, AccountService);
        }

        [Theory]
        [InlineData(2, 3, 100)]
        [InlineData(1, 3, 550)]
        public async Task CreateTransactionsSuccessfuly(int originTransactionId, int destinationTransactionId, double value)
        {
            var result = await TransactionService.Create(originTransactionId, destinationTransactionId, value);

            var exists = Context.Transactions.Any(x =>
                x.FromAccountId == originTransactionId &&
                x.ToAccountId == destinationTransactionId &&
                x.Value == value
            );

            Assert.True(result);
            Assert.True(exists);
        }

        [Theory]
        [InlineData(0, 0, 0)]
        [InlineData(1, 0, 0)]
        [InlineData(1, 2, 0)]
        [InlineData(-1, 0, 0)]
        [InlineData(-1, -2, 0)]
        [InlineData(-1, -2, -3)]
        public async Task CreateTransactionsWithInvalidParams(int originTransactionId, int destinationTransactionId, double value)
        {
            await Assert.ThrowsAsync<ArgumentException>(async () => await TransactionService.Create(originTransactionId, destinationTransactionId, value));
        }

        [Theory]
        [InlineData(9999, 2, 100)]
        [InlineData(1, 8888, 100)]
        public async Task CreateTransactionsWithUnknownAccounts(int originTransactionId, int destinationTransactionId, double value)
        {
            await Assert.ThrowsAsync<AccountNotFoundException>(async () => await TransactionService.Create(originTransactionId, destinationTransactionId, value));
        }

        [Theory]
        [InlineData(3, 2, 99999)]
        [InlineData(1, 2, 99999)]
        public async Task CreateTransactionsWithValueHigherThanBalances(int originTransactionId, int destinationTransactionId, double value)
        {
            await Assert.ThrowsAsync<InsufficientBalanceException>(async () => await TransactionService.Create(originTransactionId, destinationTransactionId, value));
        }
    }
}
