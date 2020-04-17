namespace LearningSystem.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    using Contracts;
    using Microsoft.EntityFrameworkCore;
    using WodApp.Data;

    public class Repository<T> : IRepository<T>
       
        where T : class 
    {
        private readonly ApplicationDbContext dbContext;


        
        public Repository(ApplicationDbContext dbContext)
        {
           
            this.dbContext = dbContext;
        }

       
        public async Task AddAsync(T entity)
        {
            await this.dbContext
                .Set<T>()
                .AddAsync(entity);
                

            await this.dbContext.SaveChangesAsync();
        }

        public async Task AddRangeAsync(IEnumerable<T> entity)
        {
            await this.dbContext
                .Set<T>()
                .AddRangeAsync(entity);
                
                

            await this.dbContext.SaveChangesAsync();
        }

       
        public async Task<T> FindByIdAsync(string id) 
            => await this.dbContext
                .Set<T>()
                .FindAsync(id);
                

       
        public async Task<T> FindByIdAsync(int id) 
            => await this.dbContext
                .Set<T>()
                .FindAsync(id);
               

        public void Delete(T entity, int id)
        {
            var existing = this.dbContext
                .Set<T>()
                .Find(id);
                

            if (existing != null)
            {
                this.dbContext
                    .Set<T>()
                    .Remove(existing);
                   

                this.dbContext.SaveChangesAsync();
            }
        }

       
        public IEnumerable<T> Get()
            => this.dbContext
                .Set<T>()
                .AsEnumerable<T>();
                

       
        public IEnumerable<T> Get(Expression<Func<T, bool>> predicate) 
            => this.dbContext
                .Set<T>()
                .Where(predicate)
                .AsEnumerable<T>();
                

       
        
        public void Update(T entity)
        {
            this.dbContext
                .Entry(entity)
                .State = EntityState.Modified;
                

            this.dbContext
                .Set<T>()
                .Attach(entity);
               
        }

        public async Task SaveChangesAsync() => await this.dbContext.SaveChangesAsync();

        


        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.dbContext?.Dispose();
            }
        }
    }
}