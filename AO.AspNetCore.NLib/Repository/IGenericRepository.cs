using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace AO.AspNetCore.NLib
{
    public interface IGenericRepository<T> where T : class
    {
        List<T> GetAll(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedEnumerable<T>> orderBy = null, string includeProperties = "");

        T FindBy(Expression<Func<T, bool>> predicate, string includeProperties = "");

        T Get(Expression<Func<T, bool>> predicate);

        T Find(object id);

        void Add(T entity);

        void Delete(T entity);

        void Edit(T entity);

        void Save();

        void Attach(T entity);

        Object SQL(String sqlquery);

    }
}