using System.Collections.Generic;
using App.Core.SharedKernel;
 namespace App.Core.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        T GetById(string id);
        List<T> List();
        T Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
} 
