using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sep6_API.Data.Actors;
using Sep6_API.Models;

namespace Sep6_API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ActorController : ControllerBase
    {
        IActorService actorService;

        public ActorController(IActorService actorService)
        {
            this.actorService = actorService;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Actor))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Actor>> GetActorByID(int id)
        {
            try
            {
                Actor actor = await actorService.GetActorByID(id);
                return Ok(actor);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
        [HttpGet("{id}/movie_credits")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CreditsForMovies))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<CreditsForMovies>> GetMovieCredits(int id)
        {
            try
            {
                CreditsForMovies credit = await actorService.GetMovieCreditsByActorId(id);
                return Ok(credit);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("popularActors")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ListOfActors))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ListOfActors>> GetPopularActors(int page)
        {
            try
            {
                ListOfActors actors = await actorService.GetPopularActors(page);
                return Ok(actors);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("search/")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ListOfActors))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ListOfActors>> SearchForActors([FromQuery] int page, [FromQuery] string query)
        {
            try
            {
                ListOfActors actors = await actorService.GetActorsBySearch(page, query);
                return Ok(actors);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
    }
}
