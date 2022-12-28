using ATEATECHNICAL.Utils.Models;
using System;
using System.Collections.Generic;

namespace ATEATECHNICAL.Utils.Interfaces
{
    public interface IRepository<T> : IDisposable where T : BaseModel
    {
        List<T> GetAll();
        T Insert(T entity);
    }
}
