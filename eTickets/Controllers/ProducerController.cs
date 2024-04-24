using Microsoft.AspNetCore.Mvc;

namespace eTickets.Controllers
{
    public class ProducerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
