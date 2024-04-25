using eTickets.Models;
using eTickets.Repository;
using eTickets.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Services
{
    public interface IMovieService : IEntityBaseRepository<Movie>
    {
       Task<Movie> GetMovieByIdAsync(int id);
       Task AddNewMovieAsync(NewMovieVM data);
       Task UpdateMovieAsync(NewMovieVM data);
       Task<IEnumerable<Movie>> GetMoviesAsync();
       Task<NewMovieDropdownsVM> GetNewMovieDropdownsValues();

    }
}
