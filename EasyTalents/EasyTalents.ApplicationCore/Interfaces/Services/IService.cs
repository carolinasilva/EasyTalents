using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyTalents.Domain.Interfaces.Services
{
    public interface IService<T> where T : class
    {
        T GetById(Guid id);
        IEnumerable<T> ListAll();
        void Add(T entity);
        void Update(T entity);
        void Delete(Guid id);
    }
}
