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

        public void setOverallRating(double rating) {
            OverallRating = (OverallRating + rating) / NumberOfEpisodes;
        }

    }
}
