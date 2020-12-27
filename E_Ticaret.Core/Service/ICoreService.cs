using E_Ticaret.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace E_Ticaret.Core.Service
{
    public interface ICoreService<T> where T : CoreEntity
    {
        public Task<T> Add(T item);
        public Task<bool> AddRange(List<T> items);
        public Task<T> Update(T item, int id);
        public Task<bool> Delete(T item);
        public Task<bool> Activate(int id);
        public Task<bool> DeleteAll(Expression<Func<T, bool>> exp);
        public Task<bool> Any(Expression<Func<T,bool>> exp);
        public Task<T> GetById(int id, params Expression<Func<T, object>>[] includeProperties);
        public Task<T> GetByDefault(Expression<Func<T, bool>> exp, params Expression<Func<T, object>>[] includeProperties);
        public IQueryable<T> GetDefault(Expression<Func<T, bool>> exp, params Expression<Func<T, object>>[] includeProperties);
        public IQueryable<T> GetActive();
        public IQueryable<T> Table { get; }
        public IQueryable<T> TableNoTracking { get; }
        public Task<int> Save();

    }
}
