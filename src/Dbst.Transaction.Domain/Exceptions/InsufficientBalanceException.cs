using System;

namespace Dbst.Transaction.Domain.Exceptions
{
    public class InsufficientBalanceException : Exception
    {
        public InsufficientBalanceException() { }

        public InsufficientBalanceException(string message) : base(message) { }
    }
}
