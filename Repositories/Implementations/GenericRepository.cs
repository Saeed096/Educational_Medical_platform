﻿using Microsoft.EntityFrameworkCore;
using Shoghlana.Core.DTO;
using Shoghlana.Core.Interfaces;
using System.Linq.Expressions;


namespace Shoghlana.EF.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly ApplicationDBContext context;

        protected readonly DbSet<T> dbSet;

        public GenericRepository(ApplicationDBContext Context)
        {
            this.context = Context;

            this.dbSet = context.Set<T>();
        }

        //*********************************************************

        public T? GetById(int id)
        {
            return dbSet.Find(id);
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            return await dbSet.FindAsync(id);
        }

        //----------------------------------------------------------

        public T? Find(Expression<Func<T, bool>> criteria, string[] includes = null)
        {
            IQueryable<T> query = dbSet;

            if (criteria is not null)
            {
                query = query.Where(criteria);
            }

            if (includes != null)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }

            return query.FirstOrDefault();
        }

        public async Task<T?> FindAsync(Expression<Func<T, bool>> criteria, string[] includes = null)
        {
            IQueryable<T> query = dbSet.Where(criteria);

            if (includes != null)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }

            return await query.FirstOrDefaultAsync();
        }

        //----------------------------------------------------------

        public IEnumerable<T> FindAll(string[] includes = null, Expression<Func<T, bool>> criteria = null)
        {
            IQueryable<T> query = dbSet;

            if (criteria is not null)
            {
                query = query.Where(criteria);
            }

            if (includes != null)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }

            return query.ToList();
        }

        public async Task<IEnumerable<T>> FindAllAsync(string[] includes = null, Expression<Func<T, bool>> criteria = null)
        {
            IQueryable<T> query = dbSet;

            if (criteria is not null)
            {
                query = query.Where(criteria);
            }

            if (includes != null)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }

            return await query.ToListAsync();
        }

        public int GetCount(Expression<Func<T, bool>> criteria = null)
        {
            if (criteria is not null)
            {
                return dbSet.Count(criteria);
            }
            else
            {
                return dbSet.Count();
            }
        }

        //----------------------------------------------------------

        public PaginatedListDTO<T> FindPaginated(int page, int pageSize, string[] includes = null, Expression<Func<T, bool>> criteria = null)
        {
            IQueryable<T> query = dbSet;

            if (criteria != null)
            {
                query = query.Where(criteria);
            }

            if (includes != null)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }

            int totalFilteredItems = query.Count();

            // If no items are found, return an empty PaginatedListDTO
            if (totalFilteredItems == 0)
            {
                return new PaginatedListDTO<T>
                {
                    TotalItems = 0,
                    TotalPages = 0,
                    CurrentPage = 1,
                    Items = new List<T>()
                };
            }

            if (page < 1)
            {
                page = 1;
            }

            int totalPages = (int)Math.Ceiling(totalFilteredItems / (double)pageSize);

            if (page > totalPages)
            {
                page = totalPages;
            }

            var items = query.Skip((page - 1) * pageSize)
                             .Take(pageSize)
                             .ToList();

            return new PaginatedListDTO<T>
            {
                TotalItems = totalFilteredItems,
                TotalPages = totalPages,
                CurrentPage = page,
                Items = items
            };
        }

        public async Task<PaginatedListDTO<T>> FindPaginatedAsync(int page, int pageSize, string[] includes = null, Expression<Func<T, bool>> criteria = null)
        {
            IQueryable<T> query = dbSet;

            if (criteria != null)
            {
                query = query.Where(criteria);
            }

            if (includes != null)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }

            int totalFilteredItems = await query.CountAsync();

            int totalPages = (int)Math.Ceiling(totalFilteredItems / (double)pageSize);

            // Add a check to ensure the page number is within a valid range
            if (page < 1)
            {
                page = 1;
            }

            if (page > totalPages)
            {
                page = totalPages;
            }

            var items = await query.Skip((page - 1) * pageSize)
                                   .Take(pageSize)
                                   .ToListAsync();

            return new PaginatedListDTO<T>
            {
                TotalItems = totalFilteredItems,
                TotalPages = totalPages,
                CurrentPage = page,
                Items = items
            };
        }

        //----------------------------------------------------------

        public IEnumerable<T> GetRecentSixRecords<TKey>(Expression<Func<T, TKey>> orderByProperty, string[] includes = null)
        {
            IQueryable<T> query = dbSet;

            if (includes != null)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }

            return query.OrderByDescending(orderByProperty)
                        .Take(6)
                        .ToList();
        }

        public async Task<IEnumerable<T>> GetRecentSixRecordsAsync<TKey>(Expression<Func<T, TKey>> orderByProperty, string[] includes = null)
        {
            IQueryable<T> query = dbSet;

            if (includes != null)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }

            return await query.OrderByDescending(orderByProperty)
                        .Take(6)
                        .ToListAsync();
        }

        //----------------------------------------------------------

        public T Add(T entity)
        {
            dbSet.Add(entity);

            return entity;
        }

        public async Task<T> AddAsync(T entity)
        {
            await dbSet.AddAsync(entity);

            return entity;
        }

        public IEnumerable<T> AddRange(IEnumerable<T> entities)
        {
            dbSet.AddRange(entities);
            return entities;
        }

        public async Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities)
        {
            await dbSet.AddRangeAsync(entities);
            return entities;
        }

        //----------------------------------------------------------

        public T Update(T entity)
        {
            dbSet.Update(entity);
            return entity;
        }

        //----------------------------------------------------------

        public void Delete(T entity)
        {
            dbSet.Remove(entity);
        }

        public void DeleteRange(IEnumerable<T> entities)
        {
            dbSet.RemoveRange(entities);
        }

        //----------------------------------------------------------

        public void Save()
        {
            context.SaveChanges();
        }

        public Task SaveAsync()
        {
            return context.SaveChangesAsync();
        }
    }
}