using Sep6_API.Models;

namespace Sep6_API.Persistence.FavoriteMovie
{
    public interface IFavoriteMovieR
    {
        Task AddFavoriteMovie(int userID, int movieID); 
        Task<List<int>> GetFavoriteMoviesByID(int userID); 
        Task<bool> GetIsFavoriteMovieByID(int userID, int movieID);
        Task RemoveFavoriteMovieByID(int userID, int movieID);
        Task<int> GetFavoriteMovieCount(int movieID);
    }
}
