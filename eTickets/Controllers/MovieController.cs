using eTickets.Models;
using eTickets.Services;
using eTickets.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

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
            var movies = await _movieService.GetMoviesAsync();

            return View(movies);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var movie = await _movieService.GetMovieByIdAsync(id);

            var movieVM = new NewMovieVM()
            {
                Name = movie.Name,
                Id = movie.Id,
                Description = movie.Description,    
                StartDate = movie.StartDate,
                EndDate =movie.EndDate,
                Price = movie.Price,
                ImageURL = movie.ImageUrl,
                ProducerId =movie.ProducerId,
                CinemaId = movie.CinemaId,
                ActorIds = movie.Actors_Movies.Select(n => n.ActorId).ToList()
            };

            var movieDropdownsData = await _movieService.GetNewMovieDropdownsValues();
            ViewBag.Cinemas = new SelectList(movieDropdownsData.Cinemas, "Id", "Name");
            ViewBag.Producers = new SelectList(movieDropdownsData.Producers, "Id", "FullName");
            ViewBag.Actors = new SelectList(movieDropdownsData.Actors, "Id", "FullName");

            return View(movieVM);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, NewMovieVM movie)
        {

            if (!ModelState.IsValid)
            {
                var movieDropdownsData = await _movieService.GetNewMovieDropdownsValues();

                ViewBag.Cinemas = new SelectList(movieDropdownsData.Cinemas, "Id", "Name");
                ViewBag.Producers = new SelectList(movieDropdownsData.Producers, "Id", "FullName");
                ViewBag.Actors = new SelectList(movieDropdownsData.Actors, "Id", "FullName");

                return View(movie);
            }

            await _movieService.UpdateMovieAsync(movie);
            return RedirectToAction(nameof(Index));
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
