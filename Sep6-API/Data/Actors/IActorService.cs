using Sep6_API.Models;

namespace Sep6_API.Data.Actors
{
    public interface IActorService
    {
        Task<Actor> GetActorByID(int id); 
    }
}
