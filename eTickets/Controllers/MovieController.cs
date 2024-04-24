using eTickets.Models;
using eTickets.Services;
using Microsoft.AspNetCore.Mvc;

namespace eTickets.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMovieService _movieService;

        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;

        }
        public async Task<IActionResult> Index()
        {
            var movie = await _movieService.GetAllAsync();
            // _context.Movies.Include(m => m.Cinema ).ToListAsync();
            return View();
        }

        [HttpGet]
        public IActionResult Edit()
        {
            Movie movie m = new Movie();
            movie.Cinema.Name;
            movie.Producer.FullName;
            foreach (var item in movie.Actors_Movies)
            {
                item.Actor.FullName;
            }

                return View();
        }

        [HttpPost]
        public IActionResult Update()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Create()
        {

            return View();
        }
        [HttpGet]
        public IActionResult Add()
        {

            return View();
        }

        public IActionResult Details()
        {

            return View();
        }
    }
}
