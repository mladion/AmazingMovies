using AmazingMovies.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using MovieApp.Data;
namespace MovieApp;

public static class MoviesEndpoint
{
    public static void MapMovieEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/Movie").WithTags(nameof(Movie));

        group.MapGet("/", async (AppMovieContext db) =>
        {
            return await db.Movie.ToListAsync();
        })
        .WithName("GetAllMovies")
        .WithOpenApi();

        group.MapGet("/{id}", async Task<Results<Ok<Movie>, NotFound>> (int id, AppMovieContext db) =>
        {
            return await db.Movie.AsNoTracking()
                .FirstOrDefaultAsync(model => model.ID == id)
                is Movie model
                    ? TypedResults.Ok(model)
                    : TypedResults.NotFound();
        })
        .WithName("GetMovieById")
        .WithOpenApi();

        group.MapPut("/{id}", async Task<Results<Ok, NotFound>> (int id, Movie movie, AppMovieContext db) =>
        {
            var affected = await db.Movie
                .Where(model => model.ID == id)
                .ExecuteUpdateAsync(setters => setters
                  .SetProperty(m => m.ID, movie.ID)
                  .SetProperty(m => m.Title, movie.Title)
                  .SetProperty(m => m.ReleaseDate, movie.ReleaseDate)
                  .SetProperty(m => m.GenreId, movie.GenreId)
                  .SetProperty(m => m.Price, movie.Price)
                  .SetProperty(m => m.Poster, movie.Poster)
                  .SetProperty(m => m.Plot, movie.Plot)
                );

            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("UpdateMovie")
        .WithOpenApi();

        group.MapPost("/", async (Movie movie, AppMovieContext db) =>
        {
            db.Movie.Add(movie);
            await db.SaveChangesAsync();
            return TypedResults.Created($"/api/Movie/{movie.ID}",movie);
        })
        .WithName("CreateMovie")
        .WithOpenApi();

        group.MapDelete("/{id}", async Task<Results<Ok, NotFound>> (int id, AppMovieContext db) =>
        {
            var affected = await db.Movie
                .Where(model => model.ID == id)
                .ExecuteDeleteAsync();

            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("DeleteMovie")
        .WithOpenApi();
    }
}
