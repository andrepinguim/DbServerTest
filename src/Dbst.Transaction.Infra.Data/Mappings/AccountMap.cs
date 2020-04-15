using Dbst.Transaction.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dbst.Transaction.Infra.Data.Mappings
{
    public class AccountMap : IEntityTypeConfiguration<AccountEntity>
    {
        public void Configure(EntityTypeBuilder<AccountEntity> builder)
        {
            builder.ToTable("Accounts");

            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.Number)
                .IsUnique();
            builder.Property(x => x.Balance)
                .IsRequired();
        }
    }
}
