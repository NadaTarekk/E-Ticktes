using eTickets.Data;
using eTickets.Models;
using eTickets.Repository;
using eTickets.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Services
{
    public class MovieService : EntityBaseRepository<Movie>, IMovieService
    {
        private readonly AppDbContext _context;
        public MovieService(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public Task AddNewMovieAsync(NewMovieVM data)
        {
            throw new NotImplementedException();
        }

        public async Task<Movie> GetMovieByIdAsync(int id)
        {
           
           return await _context.Movies.FirstOrDefaultAsync(m => m.Id == id);  
            
        }

        public Task UpdateMovieAsync(NewMovieVM data)
        {
            throw new NotImplementedException();
        }
    }
}
