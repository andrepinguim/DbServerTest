using System.Threading.Tasks;

namespace Dbst.Transaction.Domain.Interfaces.Services
{
    public interface ITransactionService
    {
        Task<bool> Create(int originAccountId, int destinationAccountId, double value);
    }
}
