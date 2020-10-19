using App.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace App.Infra.Data.Interfaces
{
    public interface IRepositoryBase<T> : IDisposable where T : DomainEntity
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> GetAllAsyncMultipleIncludes();
        Task<T> GetByIdAsync(Guid Id);
        Task<T> GetWithDetailsAsync(Guid Id);
        Task<T> Create(T entity);
        Task<T> Update(T entity);
        void Delete(T entity);
    }
}
