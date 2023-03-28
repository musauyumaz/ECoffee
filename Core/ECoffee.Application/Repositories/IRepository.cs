using ECoffee.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;

namespace ECoffee.Application.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        DbSet<T> Table { get; }
    }
}