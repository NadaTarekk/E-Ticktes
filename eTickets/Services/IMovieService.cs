using eTickets.Models;
using eTickets.Repository;
using eTickets.ViewModels;

namespace eTickets.Services
{
    public interface IMovieService : IEntityBaseRepository<Movie>
    {
       Task<Movie> GetMovieByIdAsync(int id);
       Task AddNewMovieAsync(NewMovieVM data);
       Task UpdateMovieAsync(NewMovieVM data);

    }
}
