using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AmazingMovies.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MovieApp.Data;

namespace MovieApp.Pages.Admin.Genres
{
    public class DetailsModel : PageModel
    {
        private readonly MovieApp.Data.AppMovieContext _context;

        public DetailsModel(MovieApp.Data.AppMovieContext context)
        {
            _context = context;
        }

        public Genre Genre { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Genre == null)
            {
                return NotFound();
            }

            var genre = await _context.Genre.FirstOrDefaultAsync(m => m.ID == id);
            if (genre == null)
            {
                return NotFound();
            }
            else 
            {
                Genre = genre;
            }
            return Page();
        }
    }
}
