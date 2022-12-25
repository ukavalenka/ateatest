using System;
using System.Collections.Generic;
using System.Text;

namespace ATEATECHNICAL.Utils.Interfaces
{
    public interface IRepository<T> : IDisposable where T : class
    {
        //T GetById(int id);
        IEnumerable<T> GetAll();
        void Insert(T entity);
        //T Update(T entity);
        //T Delete(T entity);
    }
}
