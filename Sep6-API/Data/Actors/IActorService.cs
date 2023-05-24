using Sep6_API.Models;

namespace Sep6_API.Data.Actors
{
    public interface IActorService
    {
        Task<Actor> GetActorByID(int id);
        Task<CreditsForMovies> GetMovieCreditsByActorId(int actorId);
        Task<ListOfActors> GetPopularActors(int page);
        Task<ListOfActors> GetActorsBySearch(int page, string query);
    }
}
