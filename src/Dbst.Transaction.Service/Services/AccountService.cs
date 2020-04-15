using System;
using System.Threading.Tasks;
using Dbst.Transaction.Domain.Interfaces.Repositories;
using Dbst.Transaction.Domain.Interfaces.Services;
using Dbst.Transaction.Domain.Models;

namespace Dbst.Transaction.Service.Services
{
    public class AccountService : IAccountService
    {
        private IAccountRepository _repository;

        public AccountService(IAccountRepository repository)
        {
            _repository = repository;
        }

        public async Task<AccountModel> SelectAsync(int id)
        {
            if (id <= 0) throw new ArgumentException($"{nameof(id)} deve ser maior que zero");

            var entity = await _repository.SelectAsync(id);
            if (entity == null)
                return null;

            return new AccountModel(entity);
        }
    }
}
