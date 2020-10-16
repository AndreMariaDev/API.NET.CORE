using App.Application.Interfaces;
using App.Domain.Models;
using App.Infra.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace App.Application.Services
{
    public class BaseService<T> : IBaseService<T> where T : DomainEntity, new()
    {
        #region Properts
        private IRepositoryBase<T> Repository { get; set; }
        #endregion

        #region Constructor
        public BaseService(IRepositoryBase<T> repository)
        {
            Repository = repository;
        }
        #endregion

        #region Methods
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await Repository.GetAllAsync();
        }
        public async Task<T> GetByIdAsync(Guid Id)
        {
            return await Repository.GetByIdAsync(Id);
        }
        public async Task<T> GetWithDetailsAsync(Guid Id)
        {
            return await Repository.GetWithDetailsAsync(Id);
        }
        public async Task<T> Create(T entity)
        {
            return await Repository.Create(entity);
        }
        public async Task<T> Update(T entity)
        {
            return await Repository.Update(entity);
        }
        public void Delete(T entity)
        {
            Repository.Delete(entity);
        }
        #endregion
    }
}
