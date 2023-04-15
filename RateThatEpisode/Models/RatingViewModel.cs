namespace RateThatEpisode.Models {
    public class RatingViewModel {
        public Series? Series { get; set; }
        public Episode? Episode { get; set; }

        public IEnumerable<Series>? GetSeries { get; set; }
        public IEnumerable<Episode>? GetEpisodes { get; set; }
    }
}
