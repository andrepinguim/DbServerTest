using System.Threading.Tasks;
using Dbst.Transaction.Domain.Models;

namespace Dbst.Transaction.Domain.Interfaces.Services
{
    public interface IAccountService
    {
        Task<AccountModel> SelectAsync(int id);
    }
}
