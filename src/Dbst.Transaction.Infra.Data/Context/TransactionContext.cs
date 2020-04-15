using Dbst.Transaction.Domain.Entities;
using Dbst.Transaction.Infra.Data.Mappings;
using Dbst.Transaction.Infra.Data.Seeds;
using Microsoft.EntityFrameworkCore;

namespace Dbst.Transaction.Infra.Data.Context
{
    public class TransactionContext : DbContext
    {
        public TransactionContext(DbContextOptions<TransactionContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<AccountEntity>(new AccountMap().Configure);
            modelBuilder.Entity<TransactionEntity>(new TransactionMap().Configure);

            modelBuilder.Seed();
        }

        public DbSet<AccountEntity> Accounts { get; set; }
        public DbSet<TransactionEntity> Transactions { get; set; }
    }
}
