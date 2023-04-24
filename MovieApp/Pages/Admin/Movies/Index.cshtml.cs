using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AmazingMovies.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MovieApp.Data;

namespace MovieApp.Pages.Admin.Movies
{
    public class IndexModel : PageModel
    {
        private readonly MovieApp.Data.AppMovieContext _context;

        public IndexModel(MovieApp.Data.AppMovieContext context)
        {
            _context = context;
        }

        public IList<Movie> Movie { get;set; } = default!;
        public SelectList Genres { get; set; } = default!;
        public string GenreId { get; set; } = default!;

        public async Task OnGetAsync(int? GenreId, string searchString)
        {
            if (_context.Movie != null)
            {
                Movie = await _context.Movie
                .Include(m => m.Genre).ToListAsync();

                var genres = Movie.Select(m => m.Genre).ToList();

                if (!String.IsNullOrEmpty(searchString))
                {
                    Movie = Movie
                        .Where(s => s.Title != null && s.Title.Contains(searchString))
                        .ToList();
                }

                if (GenreId != null)
                {
                    Movie = Movie
                        .Where(m => m.GenreId == GenreId)
                        .ToList();
                }

                Genres = new SelectList(genres, nameof(Genre.ID), nameof(Genre.Name));
            }
        }
    }
}
