using System.ComponentModel.DataAnnotations;

namespace RateThatEpisode.Models {
    public class Series {

        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public DateOnly DebutYear { get; set; }
        public ICollection<Episode>? Episodes { get; set; }

    }
}
