using Sep6_API.Models;

namespace Sep6_API.Data.FavoriteMovies
{
    public interface IFavoriteMovieService
    {
        Task AddFavoriteMovie(int userID, int movieID);
        Task<ListOfMovies> GetFavoriteMoviesByID(int userID);
        Task<bool> GetIsFavoriteMovieByID(int userID, int movieID);
        Task<ListOfMovies> GetFavoriteMoviesByEmail(string email);
        Task RemoveFavoriteMovieByID(int userID, int movieID);
        Task<int> GetFavoriteMovieCount(int movieID);
        Task<List<Movie>> GetFavoriteMoviesByUser(int userID);
    }
}
