using Microsoft.AspNetCore.Mvc;
using RateThatEpisode.Data;
using RateThatEpisode.Models;
using System.Diagnostics;

namespace RateThatEpisode.Controllers {
    public class HomeController : Controller {

        private readonly ApplicationDbContext _db;
        private RatingViewModel ViewModel = new RatingViewModel();
        public HomeController(ApplicationDbContext db) {
            _db = db;
        }

        public IActionResult Index() {
            ViewModel.GetSeries = _db.Series;
            return View(ViewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}