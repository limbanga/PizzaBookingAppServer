namespace PizzaBookingAppServer.Repositories
{
	public interface IGenericRepository<T> where T : class
	{
		Task CreateAsync(T entity);
		Task<T> GetAsync(int id);
		Task<List<T>> GetAllAsync();
		Task UpdateAsync(T entity);
		Task DeleteAsync(int id);
		Task<T?> FindByIdAsync(int id);
		Task SaveChangeAsync(int id);

	}
}
