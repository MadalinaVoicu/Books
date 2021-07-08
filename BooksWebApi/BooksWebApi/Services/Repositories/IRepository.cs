using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace BooksWebApi.Services.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity Add(TEntity entity);

        IEnumerable<TEntity> AddRange(IEnumerable<TEntity> entities);

        TEntity FindDefault(Expression<Func<TEntity, bool>> predicate);

        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

        IEnumerable<TEntity> GetAll();

        TEntity Get(Guid id);

        TEntity Remove(TEntity entity);

        IEnumerable<TEntity> RemoveRange(IEnumerable<TEntity> entities);
    }
}
