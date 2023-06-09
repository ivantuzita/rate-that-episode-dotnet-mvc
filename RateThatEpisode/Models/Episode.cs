﻿using System.ComponentModel.DataAnnotations;

namespace RateThatEpisode.Models {
    public class Episode {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }

        [Range(1, 5000, ErrorMessage = "Episode number must be between 1 and 5000!")]
        public int Number { get; set; }
        public string? Notes { get; set; }
        public double Rating { get; set; }

        public int SeriesID { get; set; }
        public Series? Series { get; set; }

    }
}
