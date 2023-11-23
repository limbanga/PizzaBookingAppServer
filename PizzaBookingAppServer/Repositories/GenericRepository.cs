using Microsoft.EntityFrameworkCore;

namespace PizzaBookingShared.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> CreateAsync(T entity);
        Task<T?> GetAsync(int id);
        Task<List<T>> GetAllAsync();
        Task<T> UpdateAsync(T entity);
        Task<T> DeleteAsync(int id);

    }

    public class GenericRepository<T> : IGenericRepository<T> where T : class
	{
		protected AppContext _context;
		protected DbSet<T> _dbSet;

		public GenericRepository(AppContext context)
		{
			_context = context;
			_dbSet = context.Set<T>();	
		}

		public virtual async Task<T> CreateAsync(T entity)
		{
			await _dbSet.AddAsync(entity);
			await _context.SaveChangesAsync();
			return entity;
		}

		public virtual async Task<T> DeleteAsync(int id)
		{
			T? entitie = await _dbSet.FindAsync(id);
			if (entitie == null)
			{
				throw new Exception("GenericRepository.DeleteAsync: Nothing to delete");
			}
			_dbSet.Remove(entitie);
			await _context.SaveChangesAsync();
            return entitie;
		}

		public virtual async Task<List<T>> GetAllAsync()
		{
			return await _dbSet.ToListAsync();
		}

		public virtual async Task<T?> GetAsync(int id)
		{
			return await _dbSet.FindAsync(id);
        }

		public virtual async Task<T> UpdateAsync(T entity)
		{
			_dbSet.Update(entity);
			await _context.SaveChangesAsync();
			return entity;
		}

    }
}
