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

        public async Task<CreditsForMovies> GetMovieCreditsByActorId(int actorId)
        {
            string message = await client.GetStringAsync(url + "/" + actorId + "/movie_credits" + apiKey);
            CreditsForMovies result = JsonSerializer.Deserialize<CreditsForMovies>(message);
            return result;
        }

        public async Task<ListOfActors> GetPopularActors(int page)
        {
            string message = await client.GetStringAsync(url + "popular" + apiKey + "&language=en-US&page=" + page);
            ListOfActors result = JsonSerializer.Deserialize<ListOfActors>(message);
            return result;
        }

        public async Task<ListOfActors> GetActorsBySearch(int page, string query)
        {
            string newUrl = url.Remove(url.IndexOf('3') + 1);
            Console.WriteLine(newUrl);
            var moviesUrl = newUrl + "/search/person" + apiKey + "&query=" + query + "&page=" + page;
            string message = await client.GetStringAsync(moviesUrl);
            ListOfActors results = JsonSerializer.Deserialize<ListOfActors>(message);
            return results;
        }
    }
}
