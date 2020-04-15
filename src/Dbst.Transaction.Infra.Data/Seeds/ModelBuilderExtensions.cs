using System;
using Dbst.Transaction.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Dbst.Transaction.Infra.Data.Seeds
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccountEntity>().HasData(
                new AccountEntity { Id = 1, Number = "012345", Agency = "1234", Digit = "0", Balance = 1000 },
                new AccountEntity { Id = 2, Number = "123456", Agency = "4567", Digit = "1", Balance = 2500 },
                new AccountEntity { Id = 3, Number = "150000", Agency = "7890", Digit = "2", Balance = 350.5 }
            );

            modelBuilder.Entity<TransactionEntity>().HasData(
                new TransactionEntity { Id = 999, Created = DateTime.UtcNow, FromAccountId = 1, ToAccountId = 2, Value = 100 }
            );
        }
    }
}
