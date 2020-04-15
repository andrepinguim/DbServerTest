using System;
using System.Threading.Tasks;
using Dbst.Transaction.Domain.Entities;
using Dbst.Transaction.Domain.Interfaces.Repositories;
using Dbst.Transaction.Infra.Data.Context;
using Dbst.Transaction.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace Dbst.Transaction.Tests.Unit.Data
{
    public class TransactionRepositoryTests
    {
        public TransactionContext Context { get; private set; }
        public ITransactionRepository Repository { get; private set; }

        public TransactionRepositoryTests(string inMemoryDatabaseName = "Transaction_TransactionRepositoryTests")
        {
            var dbOptionsBuilder = new DbContextOptionsBuilder<TransactionContext>().UseInMemoryDatabase(inMemoryDatabaseName);
            Context = new TransactionContext(dbOptionsBuilder.Options);
            Context.Database.EnsureCreated();

            Repository = new TransactionRepository(Context);
        }

        [Fact]
        public async Task CreateNewTransaction()
        {
            var input = new TransactionEntity()
            {
                Created = DateTime.UtcNow,
                FromAccountId = 1,
                ToAccountId = 2,
                Value = 50
            };
            var result = await Repository.InsertAsync(input);

            Assert.NotNull(result);
            Assert.True(result.Id == 1);
            Assert.True(result.Created == input.Created);
            Assert.True(result.FromAccountId == input.FromAccountId);
            Assert.True(result.ToAccountId == input.ToAccountId);
            Assert.True(result.Value == input.Value);
        }

        [Fact]
        public async Task CreateTransactionsWithValueHigherThanBalances()
        {
            await Assert.ThrowsAsync<ArgumentNullException>(async () => await Repository.InsertAsync(null));
        }
    }
}
