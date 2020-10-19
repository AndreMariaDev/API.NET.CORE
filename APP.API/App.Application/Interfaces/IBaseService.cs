using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace App.Application.Interfaces
{
    public interface IBaseService<T>
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
