using System.Threading.Tasks;

namespace eTickets.Repository
{
    public interface IEntityBaseRepository<T>
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task DeleteAsync(int id);
        Task UpdateAsync(int id, T entity);
        Task AddAsync(T entity);

    }
}
