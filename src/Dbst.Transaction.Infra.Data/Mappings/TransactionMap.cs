using Dbst.Transaction.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dbst.Transaction.Infra.Data.Mappings
{
    public class TransactionMap : IEntityTypeConfiguration<TransactionEntity>
    {
        public void Configure(EntityTypeBuilder<TransactionEntity> builder)
        {
            builder.ToTable("Transactions");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.FromAccountId)
                .IsRequired();
            builder.Property(x => x.ToAccountId)
                .IsRequired();
        }
    }
}
