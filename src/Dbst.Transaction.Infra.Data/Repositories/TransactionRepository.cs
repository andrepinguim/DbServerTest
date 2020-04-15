using Dbst.Transaction.Domain.Entities;
using Dbst.Transaction.Domain.Interfaces.Repositories;
using Dbst.Transaction.Infra.Data.Context;

namespace Dbst.Transaction.Infra.Data.Repositories
{
    public class TransactionRepository : BaseRepository<TransactionEntity>, ITransactionRepository
    {
        public TransactionRepository(TransactionContext context) : base(context) { }
    }
}
