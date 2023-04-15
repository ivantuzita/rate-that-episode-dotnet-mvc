using Microsoft.AspNetCore.Mvc;
using RateThatEpisode.Data;
using RateThatEpisode.Models;

namespace RateThatEpisode.Controllers {
    public class EpisodesController : Controller {

        private readonly ApplicationDbContext _db;
        private RatingViewModel ViewModel = new RatingViewModel();
        public EpisodesController(ApplicationDbContext db) {
            _db = db;
        }

        public IActionResult Index() {
            ViewModel.GetSeries = _db.Series;
            ViewModel.GetEpisodes = _db.Episodes;
            return View(ViewModel);
        }

        public IActionResult Add() {
            ViewModel.GetSeries = _db.Series;
            ViewModel.GetEpisodes = _db.Episodes;
            return View(ViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(RatingViewModel obj) {

            if (!ModelState.IsValid) {
                return View();
            }
            Series upSeries = _db.Series.Find(obj.Episode.SeriesID);
            upSeries.AddEpisode();
            upSeries.setOverallRating(obj.Episode.Rating);
            _db.Series.Attach(upSeries);
            _db.Entry(upSeries).Property(x => x.NumberOfEpisodes).IsModified = true;
            _db.Episodes.Add(obj.Episode);
            _db.SaveChanges();
            TempData["addSuccess"] = "The episode has been added successfully!";
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int? id) {

            if (id == null || id == 0) { return NotFound(); }

            var episodeFromDB = _db.Episodes.Find(id);

            if (episodeFromDB == null) { return NotFound(); }

            return View(episodeFromDB);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Episode obj) {
            if (!ModelState.IsValid) {
                return View();
            }
            _db.Episodes.Attach(obj);
            _db.Entry(obj).Property(x => x.Number).IsModified = true;
            _db.Entry(obj).Property(x => x.Name).IsModified = true;
            _db.Entry(obj).Property(x => x.Synopsys).IsModified = true;
            _db.SaveChanges();
            TempData["editSuccess"] = "The episode has been edited successfully!";
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int? id) {

            if (id == null || id == 0) { return NotFound(); }

            var episodeFromDB = _db.Episodes.Find(id);

            if (episodeFromDB == null) { return NotFound(); }

            return Delete(episodeFromDB);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Episode obj) {
            if (!ModelState.IsValid) {
                return RedirectToAction("Index");
            }
            Series upSeries = _db.Series.Find(obj.SeriesID);
            upSeries.RemoveEpisode();
            _db.Series.Attach(upSeries);
            _db.Entry(upSeries).Property(x => x.NumberOfEpisodes).IsModified = true;
            _db.Episodes.Remove(obj);
            _db.SaveChanges();
            TempData["deleteSuccess"] = "The episode has been deleted successfully!";
            return RedirectToAction("Index");
        }
    }
}
