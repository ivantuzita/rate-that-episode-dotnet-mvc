using Microsoft.AspNetCore.Mvc;
using RateThatEpisode.Data;
using RateThatEpisode.Models;

namespace RateThatEpisode.Controllers {
    public class SeriesController : Controller {

        private readonly ApplicationDbContext _db;
        private RatingViewModel ViewModel = new RatingViewModel();
        public SeriesController(ApplicationDbContext db) {
            _db = db;
        }

        public IActionResult Index() {
            ViewModel.GetSeries = _db.Series;
            return View(ViewModel);
        }
    }
}
