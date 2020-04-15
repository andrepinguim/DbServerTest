using System.Threading.Tasks;
using Dbst.Transaction.Domain.Entities;

namespace Dbst.Transaction.Domain.Interfaces.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<T> InsertAsync(T item);
        Task<T> UpdateAsync(T item);
        Task<bool> DeleteAsync(int Id);
        Task<T> SelectAsync(int Id);
        Task<bool> ExistsAsync(int id);
    }
}
