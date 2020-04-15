using System;
using System.Threading.Tasks;
using Dbst.Transaction.Domain.Entities;
using Dbst.Transaction.Domain.Exceptions;
using Dbst.Transaction.Domain.Interfaces.Repositories;
using Dbst.Transaction.Domain.Interfaces.Services;

namespace Dbst.Transaction.Service.Services
{
    public class TransactionService : ITransactionService
    {
        private ITransactionRepository _transactionRepository;
        private IAccountService _accountService;

        public TransactionService(ITransactionRepository transactionRepository, IAccountService accountService)
        {
            _transactionRepository = transactionRepository;
            _accountService = accountService;
        }

        public async Task<bool> Create(int originAccountId, int destinationAccountId, double value)
        {
            if (originAccountId <= 0) throw new ArgumentException($"{nameof(originAccountId)} deve ser maior que zero");
            if (destinationAccountId <= 0) throw new ArgumentException($"{nameof(destinationAccountId)} deve ser maior que zero");
            if (value <= 0) throw new ArgumentException($"{nameof(value)} deve ser maior que zero");

            var originAccount = await _accountService.SelectAsync(originAccountId);
            if (originAccount == null) throw new AccountNotFoundException("Conta de Origem não encontrada");

            var destinationAccount = await _accountService.SelectAsync(destinationAccountId);
            if (destinationAccount == null) throw new AccountNotFoundException("Conta de Destino não encontrada");

            originAccount.Debit(value);
            destinationAccount.Credit(value);

            var transaction = new TransactionEntity()
            {
                Created = DateTime.UtcNow,
                FromAccountId = originAccountId,
                ToAccountId = destinationAccountId,
                Value = value,
            };

            var result = await _transactionRepository.InsertAsync(transaction);

            return result?.Id != 0;
        }
    }
}
