using System;
using System.Threading.Tasks;
using Dbst.Transaction.Domain.Entities;
using Dbst.Transaction.Domain.Interfaces.Repositories;
using Dbst.Transaction.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Dbst.Transaction.Infra.Data.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly TransactionContext _context;
        protected DbSet<T> DbSet;

        public BaseRepository(TransactionContext context)
        {
            _context = context;
            DbSet = _context.Set<T>();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var result = await DbSet.SingleOrDefaultAsync(x => x.Id.Equals(id));
            if (result == null)
                return false;

            DbSet.Remove(result);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await DbSet.AnyAsync(x => x.Id == id);
        }

        public async Task<T> InsertAsync(T item)
        {
            if (item == null) throw new ArgumentNullException($"{nameof(item)} não pode ser nulo");

            DbSet.Add(item);
            await _context.SaveChangesAsync();

            return item;
        }

        public async Task<T> SelectAsync(int id)
        {
            return await DbSet.SingleOrDefaultAsync(x => x.Id.Equals(id));
        }

        public async Task<T> UpdateAsync(T item)
        {
            if (item == null) throw new ArgumentNullException($"{nameof(item)} não pode ser nulo");

            var result = await SelectAsync(item.Id);
            if (result == null)
                return null;

            _context.Entry(result).CurrentValues.SetValues(item);

            await _context.SaveChangesAsync();

            return item;
        }
    }
}
