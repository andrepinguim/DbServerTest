using System;

namespace Dbst.Transaction.Domain.Entities
{
    public class TransactionModel
    {
        public TransactionModel() { }

        public TransactionModel(TransactionEntity entity)
        {
            Id = entity.Id;
            Created = entity.Created;
            FromAccountId = entity.FromAccountId;
            ToAccountId = entity.ToAccountId;
            Value = entity.Value;
        }

        public int Id { get; set; }
        public DateTime Created { get; internal set; }
        public int FromAccountId { get; set; }
        public int ToAccountId { get; set; }
        public double Value { get; set; }
    }
}
