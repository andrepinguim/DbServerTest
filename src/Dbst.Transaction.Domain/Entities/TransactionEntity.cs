using System;

namespace Dbst.Transaction.Domain.Entities
{
    public class TransactionEntity : BaseEntity
    {
        public DateTime Created { get; set; }
        public int FromAccountId { get; set; }
        public int ToAccountId { get; set; }
        public double Value { get; set; }
    }
}
