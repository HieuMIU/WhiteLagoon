﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WhiteLagoon.Application.Common.Interface;
using WhiteLagoon.Domain.Entities;
using WhiteLagoon.Infrastructure.Data;

namespace WhiteLagoon.Infrastructure.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _db;

        internal DbSet<T> dbSet;

        public Repository(ApplicationDbContext db)
        {
            _db = db;
            dbSet = _db.Set<T>();
        }

        public void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public void Delete(T entity)
        {
            dbSet.Remove(entity);
        }

        public T Get(Expression<Func<T, bool>> filter, string? includeProperties = null, bool isTracked = false)
        {
            IQueryable<T> query;

            if(isTracked)
            {
                query = dbSet.AsNoTracking();
            }
            else
            {
                query = dbSet;
            }


            if (filter is not null)
            {
                query = query.Where(filter);
            }
            if (includeProperties is not null)
            {
                //Case sensitive
                foreach (var includeProp in includeProperties
                    .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }
            return query.FirstOrDefault();
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter = null, string? includeProperties = null, bool isTracked = false)
        {
            IQueryable<T> query;

            if (isTracked)
            {
                query = dbSet.AsNoTracking();
            }
            else
            {
                query = dbSet;
            }

            if (filter is not null)
            {
                query = query.Where(filter);
            }
            if (includeProperties is not null)
            {
                //Case sensitive
                foreach (var includeProp in includeProperties
                    .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }
            return query.ToList();
        }

        public bool Any(Expression<Func<T, bool>> filter)
        {
            return dbSet.Any(filter);
        }
    }
}
