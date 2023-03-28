using ECoffee.Application.Repositories;
using ECoffee.Domain.Entities.Common;
using ECoffee.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace ECoffee.Persistence.Repositories
{
    public class CommandRepository<T> : ICommandRepository<T> where T : BaseEntity
    {
        private readonly ECoffeeDbContext _context;
        public CommandRepository(ECoffeeDbContext context) => _context = context;

        public DbSet<T> Table => _context.Set<T>();

        public async Task<T> AddAsync(T entity)
            => Table.AddAsync(entity).Result.Entity;

        public async Task<T> RemoveAsync(int id)
            => Table.Remove(await Table.FirstOrDefaultAsync(data => data.Id == id)).Entity;

        public async Task<int> SaveAsync()
            => await _context.SaveChangesAsync();

        public T Update(T entity)
            => Table.Update(entity).Entity;

    }
}
