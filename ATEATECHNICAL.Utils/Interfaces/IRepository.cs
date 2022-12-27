using System;
using System.Collections.Generic;

namespace ATEATECHNICAL.Utils.Interfaces
{
    public interface IRepository<T> : IDisposable where T : class
    {
        IEnumerable<T> GetAll();
        T Insert(T entity);
    }
}
