using ECoffee.Application.Repositories;
using ECoffee.Domain.Entities.Common;
using ECoffee.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace ECoffee.Persistence.Repositories
{
    public class QueryRepository<T> : IQueryRepository<T> where T : BaseEntity
    {
        private readonly ECoffeeDbContext _context;
        public QueryRepository(ECoffeeDbContext eCoffeeDbContext)=> _context = eCoffeeDbContext;

        public DbSet<T> Table => _context.Set<T>();

        public IQueryable<T> GetAll() => Table.AsQueryable();

        public async Task<T> GetByIdAsync(int id) => await Table.AsQueryable().FirstOrDefaultAsync(x => x.Id == id);
    }
}
