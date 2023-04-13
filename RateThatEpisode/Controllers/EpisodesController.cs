using Microsoft.AspNetCore.Mvc;
using RateThatEpisode.Data;
using RateThatEpisode.Models;

namespace RateThatEpisode.Controllers {
    public class EpisodesController : Controller {

        private readonly ApplicationDbContext _db;
        public EpisodesController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index() {
            IEnumerable<Episode> objEpisodeList = _db.Episodes;
            return View(objEpisodeList);
        }
    }
}
