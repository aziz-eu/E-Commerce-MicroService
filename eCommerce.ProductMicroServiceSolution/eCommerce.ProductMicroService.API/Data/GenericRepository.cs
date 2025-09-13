using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace eCommerce.ProductMicroService.API.Data
{
    public class GenericRepository<T> where T : class
    {
        public readonly ApplicationDbContext context;
        private readonly DbSet<T> dbSet;

        public GenericRepository(ApplicationDbContext context)
        {

            this.context = context;
            dbSet = this.context.Set<T>();
            //context.ChangeTracker.LazyLoadingEnabled = false;
        }

       
        public virtual T FindOne(Expression<Func<T, bool>> predicate)
        {
            return dbSet.FirstOrDefault(predicate);
        }

        public virtual T FindOne(Expression<Func<T, bool>> predicate, List<string> includeProperties)
        {
            IQueryable<T> query = dbSet.Where(predicate);

            if (includeProperties != null)
            {
                foreach (var name in includeProperties)
                {
                    query = query.Include(name);
                }
            }

            return query.FirstOrDefault();
        }

       
        public virtual bool Exists(Expression<Func<T, bool>> predicate)
        {
            return dbSet.Any(predicate);
        }

        public virtual IQueryable<T> AsQueryable()
        {
            return dbSet.AsQueryable();
        }

      
        public IQueryable<T> Where(Expression<Func<T, bool>> predicate)
        {
            return dbSet.Where(predicate);
        }

        public virtual int Count()
        {
            return dbSet.Count();
        }

        public virtual int Count(Expression<Func<T, bool>> predicate)
        {
            return dbSet.Count(predicate);
        }


        public virtual T FinedOneInclude(Expression<Func<T, bool>> predicate, params string[] include)
        {
            IQueryable<T> query = this.dbSet.AsNoTracking();
            query = include.Aggregate(query, (current, inc) => current.Include(inc));
            return query.FirstOrDefault(predicate);
        }

        public virtual IQueryable<T> FilterWithInclude(Expression<Func<T, bool>> predicate, params string[] include)
        {
            IQueryable<T> query = this.dbSet.AsNoTracking();
            query = include.Aggregate(query, (current, inc) => current.Include(inc));
            return query.Where(predicate).AsQueryable();
        }

        public virtual Task<int> CountAsync(Expression<Func<T, bool>> predicate)
        {
            return dbSet.CountAsync(predicate);
        }

        public virtual Task<int> CountAsync()
        {
            return dbSet.CountAsync();
        }




        public virtual Task<T> FindOneAsync(Expression<Func<T, bool>> predicate)
        {
            return dbSet.FirstOrDefaultAsync(predicate);
        }

        public Task<T> FindOneAsync(Expression<Func<T, bool>> predicate, params string[] include)
        {
            IQueryable<T> query = this.dbSet.AsNoTracking();
            query = include.Aggregate(query, (current, inc) => current.Include(inc));
            return query.FirstOrDefaultAsync(predicate);
        }


        public virtual Task<bool> ExistsAsync(Expression<Func<T, bool>> predicate)
        {
            return dbSet.AnyAsync(predicate);
        }

        public async virtual Task<ICollection<T>> FilterAsync(Expression<Func<T, bool>> predicate)
        {
            return await dbSet.Where(predicate).ToListAsync();
        }





        public async Task<T> Add(T entity)
        {
            await dbSet.AddAsync(entity);
            return entity;
        }

        public async Task Delete(T entity)
        {
            context.Set<T>().Remove(entity);
        }

        public async Task<bool> Exists(int id)
        {
            var entity = await Get(id);
            return entity != null;
        }

        public async Task<T> Get(int id)
        {
            return await context.Set<T>().FindAsync(id);
        }

        public async Task<IReadOnlyList<T>> GetAll()
        {
            return await context.Set<T>().ToListAsync();
        }

        public async Task Update(T entity)
        {
            context.Entry(entity).State = EntityState.Modified;
        }

        public async Task AddRangeAsync(IEnumerable<T> entities)
        {
            await dbSet.AddRangeAsync(entities);
        }
        public async Task RemoveRangeAsync(IEnumerable<T> entities)
        {
            dbSet.RemoveRange(entities);
        }

    }
}
