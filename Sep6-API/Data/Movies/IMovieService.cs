﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Sep6_API.Models;

namespace SEP6_API.Data.Movies
{
    public interface IMovieService
    {
        Task<Movie> GetMovieByID(int id);
        Task<ListOfMovies> GetMoviesByRating(int page);
        Task<ListOfMovies> GetMoviesByTitle(int page);
        Task<ListOfMovies> GetMoviesBySearch(int page, string query);
        Task<ListOfMovies> GetNowPlayingMovies(int page);
        Task<ListOfMovies> GetPopularMovies(int page);
        Task<ListOfMovies> GetUpcomingMovies(int page);
        Task<Credits> GetCreditsByMovieId(int movieId);
        Task<VideoList> GetVideosByMovieId(int movieId);
        Task<CrewMember> GetDirectorByMovieId(int movieId);
    }
}
