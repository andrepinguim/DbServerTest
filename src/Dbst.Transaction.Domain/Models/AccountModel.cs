using System;
using Dbst.Transaction.Domain.Entities;
using Dbst.Transaction.Domain.Exceptions;

namespace Dbst.Transaction.Domain.Models
{
    public class AccountModel
    {
        public AccountModel() { }

        public AccountModel(AccountEntity entity)
        {
            Id = entity.Id;
            Number = entity.Number;
            Agency = entity.Agency;
            Digit = entity.Digit;
            Balance = entity.Balance;
        }

        public int Id { get; set; }
        public string Number { get; set; }
        public string Agency { get; set; }
        public string Digit { get; set; }
        public double Balance { get; private set; }

        public void Credit(double value)
        {
            if (value <= 0) throw new ArgumentException("Valor creditado deve ser maior que zero");

            Balance = Balance + value;
        }
        public void Debit(double value)
        {
            if (value <= 0) throw new ArgumentException("Valor debitado deve ser maior que zero");
            if (value > Balance) throw new InsufficientBalanceException("Saldo insuficiente para debitar");

            Balance = Balance - value;
        }
    }
}
