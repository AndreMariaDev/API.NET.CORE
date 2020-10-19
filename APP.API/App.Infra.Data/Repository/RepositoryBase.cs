using App.Domain.Models;
using App.Infra.Data.Context;
using App.Infra.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace App.Infra.Data.Repository
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : DomainEntity
    {
        protected PostgreDbContext RepositoryContext { get; set; }
        public RepositoryBase(PostgreDbContext repositoryContext)
        {
            this.RepositoryContext = repositoryContext;
        }

        #region Private
        private IQueryable<T> FindAll()
        {
            return this.RepositoryContext.Set<T>().AsNoTracking();
        }

        private IEnumerable<T> GetAll()
        {
            return this.RepositoryContext.Set<T>().AsEnumerable();
        }

        private IQueryable<T> GetAllMultipleIncludes()
        {
            var query = this.RepositoryContext.Set<T>().AsQueryable();
            foreach (var property in this.RepositoryContext.Model.FindEntityType(typeof(T)).GetNavigations())
                query = query.Include(property.Name);
            return query;
        }

        private IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return this.RepositoryContext.Set<T>()
                .Where(expression).AsNoTracking();
        }
        #endregion 
        #region Methods
        public async Task<T> Create(T entity)
        {
            await this.RepositoryContext.Set<T>().AddAsync(entity);
            return entity;
        }
        public async Task<T> Update(T entity)
        {
            this.RepositoryContext.Set<T>().Update(entity);
            await RepositoryContext.SaveChangesAsync();
            return entity;
        }
        public void Delete(T entity)
        {
            this.RepositoryContext.Set<T>().Remove(entity);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            var teste = await FindAll()
               .OrderBy(ow => ow.Id)
               .ToListAsync();

            return await FindAll()
               .OrderBy(ow => ow.Id)
               .ToListAsync();
        }
        public async Task<T> GetByIdAsync(Guid Id)
        {
            return await FindByCondition(entity => entity.Id.Equals(Id))
                .FirstOrDefaultAsync();
        }
        public async Task<T> GetWithDetailsAsync(Guid Id)
        {
            return await FindByCondition(entity => entity.Id.Equals(Id))
                .Include(ac => ac.Id)
                .FirstOrDefaultAsync();
        }
        public async Task<IEnumerable<T>> GetAllAsyncMultipleIncludes()
        {
            return await GetAllMultipleIncludes()
               .OrderBy(ow => ow.Id)
               .ToListAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            this.RepositoryContext.SaveChanges();
            this.RepositoryContext.Dispose();
        }
        #endregion 
    }
}
