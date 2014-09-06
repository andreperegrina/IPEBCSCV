using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common.Repository
{
    public interface IRepository<T>
    {
        List<T> GetAll();
        void Insert(T obj);
        void Update(T obj);
        void Delete(T obj);        
    }
}
