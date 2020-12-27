using E_Ticaret.Core.Entity;
using E_Ticaret.Core.Entity.Enums;
using E_Ticaret.Core.Service;
using E_Ticaret.Model.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace E_Ticaret.Service.Service.Base
{
    public class BaseService<T> : ICoreService<T> where T : CoreEntity
    {
        private readonly DataContext _db;

        public BaseService(DataContext db)
        {
            _db = db;
        }
        private DbSet<T> _entities;

        public DbSet<T> Entities
        {
            get
            {
                if (_entities == null)
                    _entities = _db.Set<T>();
                return _entities;
            }
        }

        public IQueryable<T> Table
        {
            get
            {
                return Entities;
            }
        }

        public IQueryable<T> TableNoTracking
        {
            get
            {
                return Entities.AsNoTracking();
            }
        }

        public async Task<bool> Activate(int id)
        {
            var item = await Table.FirstOrDefaultAsync(x => x.Id == id);
            if (item== null)
                return false;
            try
            {
                item.Status = Status.Active;
                if (await Update(item, id) != null)
                    return true;
                return false;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<T> Add(T item)
        {
            try
            {
                if (item == null)
                    return null;
                await Entities.AddAsync(item);
                if (await Save() > 0)
                    return item;
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> AddRange(List<T> items)
        {
            try
            {
                if (items.Count <= 0)
                    return false;
                Entities.AddRange(items);
                if (await Save() > 0)
                    return true;
                return false;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<bool> Any(Expression<Func<T, bool>> exp) => await Entities.AnyAsync(exp);

        public async Task<T> Update(T item, int id)
        {
            if (item.Id != id)
                return null;
            try
            {
                Entities.Update(item);
                if (await Save() > 0)
                    return item;
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> Delete(T item)
        {
            item.Status = Status.Passive;
            try
            {
                Entities.Update(item);
                if (await Save() > 0)
                    return true;
                return false;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<bool> DeleteAll(Expression<Func<T, bool>> exp)
        {
            var items = await Entities.Where(exp).ToListAsync();
            int count = 0;
            foreach (var item in items)
            {
                item.Status = Status.Deleted;
                if (await Update(item,item.Id) != null)
                    count++;
            }
            return count == items.Count;
        }

        public IQueryable<T> GetActive() => GetDefault(x => x.Status == Status.Active || x.Status == Status.Updated);

        public async Task<T> GetById(int id, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> quaryable = Table;

            foreach (Expression<Func<T, object>> property in includeProperties)
            {
                quaryable = quaryable.Include(property);
            }

            return await quaryable.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<T> GetByDefault(Expression<Func<T, bool>> exp, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> item = Table;
            foreach (Expression<Func<T, object>> includeProperty in includeProperties)
            {
                item = item.Include(includeProperty);
            }
            return await item.FirstOrDefaultAsync(exp);
        }

        public IQueryable<T> GetDefault(Expression<Func<T, bool>> exp, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> queryable = Table;
            foreach (Expression<Func<T, object>> includeProperty in includeProperties)
            {
                queryable = queryable.Include(includeProperty);
            }
            return queryable.Where(exp).AsQueryable();
        }

        public async Task<int> Save()
        {
            return await _db.SaveChangesAsync();
        }

        
    }
}
