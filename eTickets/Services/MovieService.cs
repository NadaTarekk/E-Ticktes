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

        public async Task AddNewMovieAsync(NewMovieVM data)
        {
            Movie movie = new Movie()
            {
                Name = data.Name,
                Description = data.Description,
                Price = data.Price,
                ImageUrl = data.ImageURL,
                StartDate = data.StartDate,
                EndDate = data.EndDate,
                CinemaId = data.CinemaId,
                ProducerId = data.ProducerId
               
            };
            await _context.Movies.AddAsync(movie);
            await _context.SaveChangesAsync();
            
            foreach(var item in data.ActorIds)
            {
                Actor_Movie actor_movie = new Actor_Movie()
                {
                    ActorId = item,
                    MovieId = movie.Id
                };
                await _context.Actors_Movies.AddAsync(actor_movie);
             }
            await _context.SaveChangesAsync();  
            
            }
          
        

        public async Task<Movie> GetMovieByIdAsync(int id)
        {

            var movie = await _context.Movies.Include(c => c.Cinema).Include(p => p.Producer)
                            .Include(am => am.Actors_Movies).ThenInclude(a => a.Actor)
                            .FirstOrDefaultAsync(n => n.Id == id);

            return movie;
        }

        public Task UpdateMovieAsync(NewMovieVM data)
        {
            throw new NotImplementedException();
        }
    }
}
