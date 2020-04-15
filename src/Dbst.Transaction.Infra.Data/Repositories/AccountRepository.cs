using Dbst.Transaction.Domain.Entities;
using Dbst.Transaction.Domain.Interfaces.Repositories;
using Dbst.Transaction.Infra.Data.Context;

namespace Dbst.Transaction.Infra.Data.Repositories
{
    public class AccountRepository : BaseRepository<AccountEntity>, IAccountRepository
    {
        public AccountRepository(TransactionContext context) : base(context) { }
    }
}
