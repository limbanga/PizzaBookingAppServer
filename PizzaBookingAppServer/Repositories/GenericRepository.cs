using Microsoft.EntityFrameworkCore;

namespace PizzaBookingAppServer.Repositories
{
	public class GenericRepository<T> : IGenericRepository<T> where T : class
	{
		protected AppContext _context;
		protected DbSet<T> _dbSet;

		public GenericRepository(AppContext context)
		{
			_context = context;
			_dbSet = context.Set<T>();	
		}
		public async Task CreateAsync(T entity)
		{
			await _dbSet.AddAsync(entity);
			await _context.SaveChangesAsync();
		}

		public async Task DeleteAsync(int id)
		{
			T? entitie = await _dbSet.FindAsync(id);
			if (entitie == null)
			{
				throw new Exception("--------- Nothing to delete ------------------.");
			}
			_dbSet.Remove(entitie);
			await _context.SaveChangesAsync();
		}

		public async Task<T?> FindByIdAsync(int id)
		{
			return await _dbSet.FindAsync(id);
		}

		public async Task<List<T>> GetAllAsync()
		{
			return await _dbSet.ToListAsync();
		}

		public async Task<T> GetAsync(int id)
		{
			return await _dbSet.FindAsync(id) ?? 
				throw new Exception("---------- id doesn't exit ---------------");
		}

		public async Task UpdateAsync(T entity)
		{
			_dbSet.Update(entity);
			 await _context.SaveChangesAsync();
		}
		public async Task SaveChangeAsync(int id)
		{
			await _context.SaveChangesAsync();
		}
	}
}
