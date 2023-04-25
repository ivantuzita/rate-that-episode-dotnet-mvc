using Microsoft.AspNetCore.Mvc;
using RateThatEpisode.Data;
using RateThatEpisode.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;
using System.Security.Policy;

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

            int mal_id = int.Parse(obj.Series.MAL_url.Split('/')[4]);

            using (var jikan = new HttpClient()) {
                var response = jikan.GetAsync($"https://api.jikan.moe/v4/anime/{mal_id}").Result;
                response.EnsureSuccessStatusCode();
                string responseBody = response.Content.ReadAsStringAsync().Result;
                var parsedObject = JObject.Parse(responseBody);
                var scoreJson = parsedObject["data"]["score"].ToString();
                obj.Series.MAL_Rating = double.Parse(scoreJson);
            }

            if (!ModelState.IsValid) {
                return View();
            }

            _db.Series.Add(obj.Series);
            _db.SaveChanges();
            TempData["addSuccess"] = "The episode has been added successfully!";
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int? id) {

            if (id == null || id == 0) { return NotFound(); }

            var seriesFromDB = _db.Series.Find(id);

            if (seriesFromDB == null) { return NotFound(); }

            return View(seriesFromDB);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Series obj) {
            if (!ModelState.IsValid) {
                return View();
            }
            _db.Series.Attach(obj);
            _db.Entry(obj).Property(x => x.Name).IsModified = true;
            _db.SaveChanges();
            TempData["editSuccess"] = "The episode has been edited successfully!";
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
