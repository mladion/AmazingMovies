﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace AmazingMovies.Models
{
    public class Movie
	{
        public int ID { get; set; }

        [StringLength(100)]
        public string Title { get; set; } = string.Empty;

        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        public Genre? Genre { get; set; } = null;
        public int GenreId { get; set; }

        [Range(1, 100), DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }
        public string? Poster { get; set; }
        public string? Plot { get; set; }
    }
}

