using Sep6_API.Models;

namespace SEP6_API.Data.Movies
{
    public interface IMovieService
    {
        Task<Movie> GetMovieByID(int id);

        Task<ListOfMovies> GetMoviesByRating(int page);

        Task<ListOfMovies> GetMoviesByTitle(int page);

        Task<ListOfMovies> GetMoviesBySearch(int page, string query);

    }
}
