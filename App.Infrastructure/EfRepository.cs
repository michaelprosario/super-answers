using System.Collections.Generic;
using System.Linq;
using App.Core.Interfaces;
using App.Core.SharedKernel;
using Microsoft.EntityFrameworkCore;
 namespace App.Infrastructure
{
    public class EfRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly GZContext _dbContext;
         public EfRepository(GZContext dbContext)
        {
            _dbContext = dbContext;
        }
         public T GetById(string id)
        {
            return _dbContext.Set<T>().SingleOrDefault(e => e.Id.Equals(id));
        }
         public List<T> List()
        {
            return _dbContext.Set<T>().ToList();
        }
         public T Add(T entity)
        {
            _dbContext.Set<T>().Add(entity);
            _dbContext.SaveChanges();
             return entity;
        }
         public void Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            _dbContext.SaveChanges();
        }
         public void Update(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }
    }
} 
