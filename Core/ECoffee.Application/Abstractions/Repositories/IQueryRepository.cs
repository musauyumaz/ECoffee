using ECoffee.Domain.Entities.Common;

namespace ECoffee.Application.Abstractions.Repositories
{
    public interface IQueryRepository<T> : IRepository<T> where T : BaseEntity
    {
        IQueryable<T> GetAll();
        Task<T> GetByIdAsync(int id);
    }
}
