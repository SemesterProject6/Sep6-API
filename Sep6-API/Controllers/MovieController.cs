﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sep6_API.Models;
using SEP6_API.Data.Movies;

namespace Sep6_API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService movieService;

        public MovieController(IMovieService movieService)
        {
            this.movieService = movieService;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Movie))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Movie>> GetMovieByID(int id)
        {
            try
            {
                Movie movie = await movieService.GetMovieByID(id);
                return Ok(movie);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("{id}/videos")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(VideoList))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<VideoList>> GetVideosByMovieId(int id)
        {
            try
            {
                VideoList videos = await movieService.GetVideosByMovieId(id);
                return Ok(videos);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("ByRating")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ListOfMovies))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ListOfMovies>> GetMoviesByRating(int page)
        {
            try
            {
                ListOfMovies movies = await movieService.GetMoviesByRating(page);
                return Ok(movies);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("ByTitle")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ListOfMovies))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ListOfMovies>> GetMoviesByTitle(int page)
        {
            try
            {
                ListOfMovies movies = await movieService.GetMoviesByTitle(page);
                return Ok(movies);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("search")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ListOfMovies))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ListOfMovies>> SearchForMovies([FromQuery] int page, [FromQuery] string query)
        {
            try
            {
                ListOfMovies movies = await movieService.GetMoviesBySearch(page, query);
                return Ok(movies);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("{id}/credits")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Credits))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Credits>> GetCredits(int id)
        {
            try
            {
                Credits credit = await movieService.GetCreditsByMovieId(id);
                return Ok(credit);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("{id}/director")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CrewMember))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<CrewMember>> GetDirectorByMovieId(int id)
        {
            try
            {
                CrewMember director = await movieService.GetDirectorByMovieId(id);
                return Ok(director);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }



        [HttpGet("NowPlaying")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ListOfMovies))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ListOfMovies>> GetNowPlayingMovies([FromQuery] int page)
        {
            try
            {
                ListOfMovies movies = await movieService.GetNowPlayingMovies(page);
                return Ok(movies);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("Popular")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ListOfMovies))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ListOfMovies>> GetPopularMovies([FromQuery] int page)
        {
            try
            {
                ListOfMovies movies = await movieService.GetPopularMovies(page);
                return Ok(movies);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("Upcoming")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ListOfMovies))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ListOfMovies>> GetUpcomingMovies([FromQuery] int page)
        {
            try
            {
                ListOfMovies movies = await movieService.GetUpcomingMovies(page);
                return Ok(movies);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
    }
}
