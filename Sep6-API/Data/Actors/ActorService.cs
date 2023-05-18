using System.Text.Json;
using Sep6_API.Models;

namespace Sep6_API.Data.Actors
{
    public class ActorService : IActorService
    {
        string url = "https://api.themoviedb.org/3/person/";
        HttpClient client;
        private readonly IConfiguration configuration;
        private string apiKey;

        public ActorService(IConfiguration iConfig)
        {
            client = new HttpClient();
            configuration = iConfig;
            apiKey = configuration["APIKeys:ApiKey"];
        }

        public async Task<Actor> GetActorByID(int id)
        {
            string message = await client.GetStringAsync(url + id + apiKey);
            Actor movie = JsonSerializer.Deserialize<Actor>(message);
            return movie;
        }

    }
}
