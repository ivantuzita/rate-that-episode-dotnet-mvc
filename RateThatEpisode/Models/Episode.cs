using System.ComponentModel.DataAnnotations;

namespace RateThatEpisode.Models {
    public class Episode {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        [Required]
        public int Number { get; set; }
        public string Synopsys { get; set; }
        public double OverallRating { get; set; }

    }
}
