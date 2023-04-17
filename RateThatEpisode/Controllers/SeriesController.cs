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

        public IActionResult Add() {
            ViewModel.GetSeries = _db.Series;
            return View(ViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(RatingViewModel obj) {

            if (!ModelState.IsValid) {
                return View();
            }

            _db.Series.Add(obj.Series);
            _db.SaveChanges();
            TempData["addSuccess"] = "The episode has been added successfully!";
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int? id) {

            if (id == null || id == 0) { return NotFound(); }

            var SeriesFromDB = _db.Series.Find(id);

            if (SeriesFromDB == null) { return NotFound(); }

            return Delete(SeriesFromDB);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Series obj) {
            if (!ModelState.IsValid) {
                return RedirectToAction("Index");
            }
            _db.Series.Remove(obj);
            _db.SaveChanges();
            TempData["deleteSuccess"] = "The episode has been deleted successfully!";
            return RedirectToAction("Index");
        }
    }
}
