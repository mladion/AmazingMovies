using AmazingMovies.Models;
using Microsoft.EntityFrameworkCore;

namespace MovieApp.Data;

public class AppMovieContext : DbContext
{
    public AppMovieContext(DbContextOptions<AppMovieContext> options)
        : base(options)
    {
    }

    public DbSet<Movie> Movie => Set<Movie>();
    public DbSet<Genre> Genre { get; set; } = default!;
}