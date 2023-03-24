﻿using ECoffee.Domain.Entities.Common;

namespace ECoffee.Application.Repositories
{
    public interface ICommandRepository<T> : IRepository<T> where T : BaseEntity
    {
        Task<T> AddAsync(T entity); //DataResult Data, Message, Success
        Task<T> RemoveAsync(int id);
        T Update(T entity);
        Task<int> SaveAsync();
    }
}
