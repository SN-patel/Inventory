using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Repositories
{
    public interface IRepository<T>
    {
        T Get(object id);
        IEnumerable<T> GetAll();
        int Add(T entity);
        void AddRange(List<T> entities);
        void Delete(T entity);
        void Update(T entity);
        void Save();
    }
}
