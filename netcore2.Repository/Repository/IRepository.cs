using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace netcore2_mongodb.Repository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        void Add(TEntity item);

        Task AddAsync(TEntity item);

        void AddRange(IEnumerable<TEntity> list);

        Task AddRangeAsync(IEnumerable<TEntity> list);

        bool Any();

        bool Any(Expression<Func<TEntity, bool>> where);

        Task<bool> AnyAsync();

        Task<bool> AnyAsync(Expression<Func<TEntity, bool>> where);

        long Count();

        long Count(Expression<Func<TEntity, bool>> where);

        Task<long> CountAsync();

        Task<long> CountAsync(Expression<Func<TEntity, bool>> where);

        void Delete(object key);

        void Delete(Expression<Func<TEntity, bool>> where);

        Task DeleteAsync(object key);

        Task DeleteAsync(Expression<Func<TEntity, bool>> where);

        TEntity FirstOrDefault(Expression<Func<TEntity, bool>> where);

        Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> where);

        IEnumerable<TEntity> List();

        IEnumerable<TEntity> List(Expression<Func<TEntity, bool>> where);

        Task<IEnumerable<TEntity>> ListAsync();

        Task<IEnumerable<TEntity>> ListAsync(Expression<Func<TEntity, bool>> where);

        TEntity Find(object key);

        Task<TEntity> FindAsync(object key);

        TEntity SingleOrDefault(Expression<Func<TEntity, bool>> where);

        Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> where);

        void Update(TEntity item, object key);

        Task UpdateAsync(TEntity item, object key);
    }
}
