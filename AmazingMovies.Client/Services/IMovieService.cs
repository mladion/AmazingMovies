using AmazingMovies.Models;

namespace AmazingMovies.Client.Services
{
    public interface IMovieService
    {
        IQueryable<Movie> GetMovies();
    }
}