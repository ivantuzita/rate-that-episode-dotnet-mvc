using System.ComponentModel.DataAnnotations;

namespace RateThatEpisode.Models {
    public class Series {

        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int NumberOfEpisodes { get; set; }
        public double OverallRating { get; set; }
        public ICollection<Episode>? Episodes { get; set; }

        public void AddEpisode() {
            NumberOfEpisodes++;
        }

        public void RemoveEpisode() {
            NumberOfEpisodes--;
        }

        public void updateOverallRating(IEnumerable<Episode> episodes) {

            if (episodes == null || NumberOfEpisodes == 0) {
                OverallRating = 0;
                return;
            }

            OverallRating = episodes.Select(e => e.Rating).Sum() / NumberOfEpisodes;

        }

    }
}
