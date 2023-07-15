﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieList.Models
{
    public class Movie
    {
        public int MovieId { get; set; }

        [Required(ErrorMessage = "Please enter a name.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter a year")]
        [Range(1889, 2999, ErrorMessage = "Year must be after 1889.")]
        public int? Year { get; set; }

        [Required(ErrorMessage = "Please enter a rating.")]
        [Range(1, 5, ErrorMessage = "Rating must be between q and 5.")]
        public int? Rating { get; set; }

        // Genre is a foreign key a property of the Genre Class
        [Required(ErrorMessage = "Please enter a genre")]
        public string GenreId { get; set; }
        public Genre Genre { get; set; }

        public string Slug => Name?.Replace(' ', '-').ToLower() + '-' + Year.ToString();

    }
}
