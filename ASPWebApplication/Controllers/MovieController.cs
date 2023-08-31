using Microsoft.AspNetCore.Mvc;
using ASPWebApplication.Models;
using ASPWebApplication.Data;

namespace ASPWebApplication.Controllers
{
    public class MovieController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MovieController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Random()
        {
            // these guys without evne db so mind that
            var list = _context.Movie.ToString();
            Console.Write(list);
            var movie = new Movie() { Name = "The burning train" };
            var customers = new List<Customer>
            {
                new Customer { Name = "Bunny"},
                new Customer { Name = "Bingo"}
            };

            var reviews = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers,
            };
            // return View(reviews);
            return Content(list);
        }
    }
}
