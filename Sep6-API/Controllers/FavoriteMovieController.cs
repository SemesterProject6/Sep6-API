using Microsoft.AspNetCore.Mvc;
using Sep6_API.Data.FavoriteMovies;
using Sep6_API.Models;

namespace Sep6_API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class FavoriteMovieController : ControllerBase
    {
        IFavoriteMovieService favoriteMovieService;

        public FavoriteMovieController(IFavoriteMovieService favoriteMovieService)
        {
            this.favoriteMovieService = favoriteMovieService;
        }

        [HttpPost("addFavorite")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task AddFavoriteMovie([FromQuery] int userID, [FromQuery] int movieID)
        {
            await favoriteMovieService.AddFavoriteMovie(userID, movieID);
        }

        [HttpGet("getFavorites")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ListOfMovies> GetFavoriteMoviesByID([FromQuery] int userID)
        {
            return await favoriteMovieService.GetFavoriteMoviesByID(userID);
        }


        [HttpGet("getFavoritesByEmail")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ListOfMovies> GetFavoriteMoviesByEmail([FromQuery] string email)
        {
            return await favoriteMovieService.GetFavoriteMoviesByEmail(email);
        }
        [HttpGet("getFavoritesByUser")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<List<Movie>> GetFavoriteMoviesByUser([FromQuery] int userID)
        {
            return await favoriteMovieService.GetFavoriteMoviesByUser(userID);
        }        

        [HttpGet("getFavorite")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<bool> GetIsFavoriteMovieByID([FromQuery] int userID, [FromQuery] int movieID)
        {
            return await favoriteMovieService.GetIsFavoriteMovieByID(userID, movieID);
        }

        [HttpGet("getFavoriteMovieCount")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<int>> GetFavoriteMovieCount([FromQuery] int movieID)
        {
            int count =  await favoriteMovieService.GetFavoriteMovieCount(movieID);
            return  Ok(count);
        }


        [HttpDelete("removeFavorite")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task RemoveFavoriteMovieByID([FromQuery] int userID, [FromQuery] int movieID)
        {
            await favoriteMovieService.RemoveFavoriteMovieByID(userID, movieID);
        }
    }
}
