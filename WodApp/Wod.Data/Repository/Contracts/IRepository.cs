namespace LearningSystem.Repository.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;

    public interface IRepository<T> : IDisposable
        where T : class
        
    {
       
        Task<T> FindByIdAsync(string id);

        
        Task<T> FindByIdAsync(int id);

        
        IEnumerable<T> Get();

       
        IEnumerable<T> Get(Expression<Func<T, bool>> predicate);

       
        Task AddAsync(T entity);

        Task AddRangeAsync(IEnumerable<T> entity);

        
        void Delete(T entity, int id);

        void Update(T entity);

       
       

        Task SaveChangesAsync();

       
    }
}