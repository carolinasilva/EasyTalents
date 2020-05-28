using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace EasyTalents.Domain.Interfaces.Repositories
{
    public interface IRepository<T> where T : class
    {
        T GetById(Guid id);
        T GetById(int id);
        IEnumerable<T> ListAll();
        IEnumerable<T> ListBy(Expression<Func<T, bool>> where);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
