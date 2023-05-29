using Sep6_API.Models;
using Sep6_API.Persistence.User;
using Sep6_API.Persistence.FavoriteMovie;
using SEP6_API.Data.Movies;
namespace Sep6_API.Data.FavoriteMovies
{
    public class FavoriteMovieService : IFavoriteMovieService
    {
        IFavoriteMovieR repo;
        IMovieService movieService;
        IUserR userRepo;

        public FavoriteMovieService(IConfiguration configuration)
        {
            repo = new FavoriteMovieR(configuration);
            movieService = new MovieService(configuration);
            userRepo = new UserR(configuration);
        }

        public async Task AddFavoriteMovie(int userID, int movieID)
        {
            await repo.AddFavoriteMovie(userID, movieID);
        }

        public async Task<ListOfMovies> GetFavoriteMoviesByEmail(string email)
        {
            User user = await userRepo.GetUserAsync(email);
            if (user == null) return null;

            return await GetFavoriteMoviesByID((int)user.UserID);
        }
        public async Task<int> GetFavoriteMovieCount(int movieID)
        {
            int count = await repo.GetFavoriteMovieCount(movieID);
            return count;
        }

        public async Task<List<Movie>> GetFavoriteMoviesByUser(int userID)
        {
            var movieIdList = await repo.GetFavoriteMoviesByID(userID);

            List<Movie> toReturn = new();
            
            foreach (var movieId in movieIdList)
            {
                toReturn.Add(await movieService.GetMovieByID(movieId));
            }
            return toReturn;
        }

        public async Task<ListOfMovies> GetFavoriteMoviesByID(int userID)
        {
            var movieList = await repo.GetFavoriteMoviesByID(userID);

            ListOfMovies toReturn = new()
            {
                CurrentPage = 1,
                Movies = new List<Movie>()
            };
            foreach (var movie in movieList)
            {
                toReturn.Movies.Add(await movieService.GetMovieByID(movie));
            }
            float pageNum = (float)toReturn.Movies.Count / 20;
            toReturn.TotalPage = (int)Math.Ceiling(pageNum);
            return toReturn;
        }

        public async Task<bool> GetIsFavoriteMovieByID(int userID, int movieID)
        {
            return await repo.GetIsFavoriteMovieByID(userID, movieID);
        }

        public async Task RemoveFavoriteMovieByID(int userID, int movieID)
        {
            await repo.RemoveFavoriteMovieByID(userID, movieID);
        }
    }
}
