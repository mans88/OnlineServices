using Microsoft.EntityFrameworkCore;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineServices.Common.DataAccessHelpers
{
    public class GenericRepositoryAsync<T, U> : IRepositoryAsync<T, U>
        where T : class
    {
        private readonly DbContext dbContext;

        public GenericRepositoryAsync(DbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        async Task IRepositoryAsync<T, U>.CreateAsync(T entity)
        {
            dbContext.Set<T>().Add(entity);
        }

        async Task IRepositoryAsync<T, U>.DeleteAsync(T entity)
        {
            dbContext.Set<T>().Remove(entity);
        }

        async Task<List<T>> IRepositoryAsync<T, U>.FindAll()
        {
            return await dbContext.Set<T>().ToListAsync();
        }

        async Task<T> IRepositoryAsync<T, U>.FindById(U id)
        {
            return await dbContext.Set<T>().FindAsync(id);
        }

        async Task IRepositoryAsync<T, U>.SaveChangesAsync()
        {
            await dbContext.SaveChangesAsync();
        }

        async Task IRepositoryAsync<T, U>.UpdateAsync(T entity)
        {
            dbContext.Set<T>().Update(entity);
        }
    }
}
