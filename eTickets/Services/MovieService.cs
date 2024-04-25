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
        public async Task<IEnumerable<Movie>> GetMoviesAsync()
        {
            return await _context.Movies.Include(m => m.Cinema).ToListAsync();
        }

        public async Task<NewMovieDropdownsVM> GetNewMovieDropdownsValues()
        {
            var response = new NewMovieDropdownsVM()
            {
                Actors = await _context.Actors.OrderBy(n => n.FullName).ToListAsync(),
                Cinemas = await _context.Cinemas.OrderBy(n => n.Name).ToListAsync(),
                Producers = await _context.Producers.OrderBy(n => n.FullName).ToListAsync()
            };

            return response;
        }

        public async Task UpdateMovieAsync(NewMovieVM data)
        {
            var dbMovie = await _context.Movies.FirstOrDefaultAsync(n => n.Id == data.Id);

            if (dbMovie != null)
            {
                dbMovie.Name = data.Name;
                dbMovie.Description = data.Description;
                dbMovie.Price = data.Price;
                dbMovie.ImageUrl = data.ImageURL;
                dbMovie.CinemaId = data.CinemaId;
                dbMovie.StartDate = data.StartDate;
                dbMovie.EndDate = data.EndDate;
                dbMovie.ProducerId = data.ProducerId;
                await _context.SaveChangesAsync();
            }

            //Remove existing actors
            var existingActorsDb = _context.Actors_Movies.Where(n => n.MovieId == data.Id).ToList();
            _context.Actors_Movies.RemoveRange(existingActorsDb);
            await _context.SaveChangesAsync();

            //Add Movie Actors
            foreach (var actorId in data.ActorIds)
            {
                var newActorMovie = new Actor_Movie()
                {
                    MovieId = data.Id,
                    ActorId = actorId
                };
                await _context.Actors_Movies.AddAsync(newActorMovie);
            }
            await _context.SaveChangesAsync();
        }
    }
}

