using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Sep6_API.Models;

namespace SEP6_API.Data.Movies
{
    public class MovieService : IMovieService
    {
        private readonly string url = "https://api.themoviedb.org/3/movie/";
        private readonly string newUrl = "https://api.themoviedb.org/3/discover/movie";
        private readonly HttpClient client;
        private readonly IConfiguration configuration;
        private readonly string apiKey;

        public MovieService(IConfiguration iConfig)
        {
            client = new HttpClient();
            configuration = iConfig;
            apiKey = configuration["APIKeys:ApiKey"];
        }

        public async Task<Movie> GetMovieByID(int id)
        {
            string message = await client.GetStringAsync(url + id + apiKey);
            Movie movie = JsonSerializer.Deserialize<Movie>(message);
            return movie;
        }

        public async Task<ListOfMovies> GetMoviesBySearch(int page, string query)
        {
            string newUrl = url.Remove(url.IndexOf('3') + 1);
            var moviesUrl = newUrl + "/search/movie" + apiKey + "&query=" + query + "&page=" + page;
            string message = await client.GetStringAsync(moviesUrl);
            ListOfMovies results = JsonSerializer.Deserialize<ListOfMovies>(message);
            return results;
        }

        public async Task<ListOfMovies> GetMoviesByRating(int page)
        {
            var moviesUrl = apiKey + "&language=en-US&sort_by=vote_average.desc&vote_count.gte=215&vote_average.gte=3&page=";
            if (page != 0)
                moviesUrl += page;
            string message = await client.GetStringAsync(newUrl + moviesUrl);
            ListOfMovies results = JsonSerializer.Deserialize<ListOfMovies>(message);
            return results;
        }

        public async Task<ListOfMovies> GetMoviesByTitle(int page)
        {
            var moviesUrl = apiKey + "&language=en-US&sort_by=original_title.asc&vote_count.gte=215&vote_average.gte=3&page=";
            if (page != 0)
                moviesUrl += page;
            string message = await client.GetStringAsync(newUrl + moviesUrl);
            ListOfMovies results = JsonSerializer.Deserialize<ListOfMovies>(message);
            return results;
        }

        public async Task<Credits> GetCreditsByMovieId(int movieId)
        {
            string message = await client.GetStringAsync(url + movieId + "/credits" + apiKey + "&language=en-US");
            Credits result = JsonSerializer.Deserialize<Credits>(message);
            return result;
        }

        public async Task<VideoList> GetVideosByMovieId(int movieId)
        {
            string message = await client.GetStringAsync(url + movieId + "/videos" + apiKey);
            VideoList result = JsonSerializer.Deserialize<VideoList>(message);
            return result;
        }

        public async Task<ListOfMovies> GetNowPlayingMovies(int page)
        {
            var moviesUrl = "now_playing" + apiKey + "&language=en-US&page=";
            if (page != 0)
                moviesUrl += page;
            string message = await client.GetStringAsync(url+moviesUrl);
            ListOfMovies results = JsonSerializer.Deserialize<ListOfMovies>(message);
            return results;
        }
    }
}
