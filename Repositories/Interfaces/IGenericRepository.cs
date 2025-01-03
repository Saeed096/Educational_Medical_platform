﻿using Microsoft.EntityFrameworkCore;
using Shoghlana.Core.DTO;
using System.Linq.Expressions;
namespace Shoghlana.Core.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        public T? GetById(int id);

        public Task<T?> GetByIdAsync(int id);

        //-------------------------------------------------------------------------

        public T? Find(Expression<Func<T, bool>> criteria = null, string[] includes = null);

        public Task<T?> FindAsync(Expression<Func<T, bool>> criteria, string[] includes = null);

        //-------------------------------------------------------------------------

        public IEnumerable<T> FindAll(string[] includes = null, Expression<Func<T, bool>> criteria = null);

        public Task<IEnumerable<T>> FindAllAsync(string[] includes = null, Expression<Func<T, bool>> criteria = null);

        public int GetCount(Expression<Func<T, bool>> criteria = null);

        //-------------------------------------------------------------------------

        public PaginatedListDTO<T> FindPaginated(int page, int pageSize, string[] includes = null, Expression<Func<T, bool>> criteria = null);

        public Task<PaginatedListDTO<T>> FindPaginatedAsync(int page, int pageSize, string[] includes = null, Expression<Func<T, bool>> criteria = null);

        //-------------------------------------------------------------------------

        public IEnumerable<T> GetRecentSixRecords<TKey>(Expression<Func<T, TKey>> orderByProperty, string[] includes = null);

        public  Task<IEnumerable<T>> GetRecentSixRecordsAsync<TKey>(Expression<Func<T, TKey>> orderByProperty, string[] includes = null);

        //-------------------------------------------------------------------------

        public T Add(T entity);

        public Task<T> AddAsync(T entity);

        //-------------------------------------------------------------------------

        public IEnumerable<T> AddRange(IEnumerable<T> entities);

        public Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities);

        //-------------------------------------------------------------------------

        public T Update(T entity);

        //-------------------------------------------------------------------------

        public void Delete(T entity);

        public void DeleteRange(IEnumerable<T> entities);

        //-------------------------------------------------------------------------

        public void Save();

        public Task SaveAsync();
    }
}