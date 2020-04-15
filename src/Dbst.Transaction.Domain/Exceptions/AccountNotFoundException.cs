using System;

namespace Dbst.Transaction.Domain.Exceptions
{
    public class AccountNotFoundException : Exception
    {
        public AccountNotFoundException() { }

        public AccountNotFoundException(string message) : base(message) { }
    }
}
