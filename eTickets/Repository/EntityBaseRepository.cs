using eTickets.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace eTickets.Repository
{
    public class EntityBaseRepository<T> : IEntityBaseRepository<T> where T : class, IEntityBase
    {
        private readonly AppDbContext _context;

        public EntityBaseRepository(AppDbContext context)
        {
            _context = context;
                
        }
        public async Task AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            T entity = await GetByIdAsync(id);
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();

        }
        public async Task<T> GetByIdAsync(int id)
        {
             return await _context.Set<T>().FirstOrDefaultAsync(n => n.Id == id);
           // return await _context.Set<T>().FindAsync(id);
        }


        public async Task<IEnumerable<T>> GetAllAsync()
        {
           return await _context.Set<T>().ToListAsync(); 
        }


        public async Task UpdateAsync(T newEntity)
        {
            EntityEntry entityEntry = _context.Entry<T>(newEntity);
            entityEntry.State = EntityState.Modified;

            await _context.SaveChangesAsync();

        }
       /* public async Task UpdateAsync(int id, T newEntity)
        {
            
            T entity = await GetByIdAsync(id);

            _context.Entry(entity).CurrentValues.SetValues(newEntity);

            await _context.SaveChangesAsync();
            }
        } */
    }
}
