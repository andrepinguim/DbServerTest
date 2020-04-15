using System;
using Dbst.Transaction.Domain.Entities;
using Dbst.Transaction.Domain.Exceptions;
using Dbst.Transaction.Domain.Models;
using Xunit;

namespace Dbst.Transaction.Tests.Unit.Domain
{
    public class AccountModelTests
    {
        private AccountModel _account;

        public AccountModelTests()
        {
            var entity = new AccountEntity("123456", "12", "1");
            entity.Balance = 500;

            _account = new AccountModel(entity);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(47.55)]
        [InlineData(100)]
        [InlineData(500)]
        public void CreditValues(double v)
        {
            var balance = _account.Balance + v;
            _account.Credit(v);

            Assert.True(balance == _account.Balance);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(47.55)]
        [InlineData(100)]
        [InlineData(500)]
        public void DebitValues(double v)
        {
            var balance = _account.Balance - v;
            _account.Debit(v);

            Assert.True(balance == _account.Balance);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-3)]
        [InlineData(-12.50)]
        public void DebitInvalidValues(double v)
        {
            Assert.Throws<ArgumentException>(() => _account.Debit(v));
        }

        [Theory]
        [InlineData(501)]
        [InlineData(600)]
        [InlineData(1000)]
        public void DebitHigherValueThanBalance(double v)
        {
            Assert.Throws<InsufficientBalanceException>(() => _account.Debit(v));
        }
    }
}
