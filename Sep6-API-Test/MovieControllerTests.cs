using Microsoft.AspNetCore.Mvc.Testing;

namespace Sep6_API_Test
{
    [TestClass]
    public class MovieControllerTests
    {
        private HttpClient _httpClient;

        public MovieControllerTests()
        {
            var webAppFactory = new WebApplicationFactory<Program>();
            _httpClient = webAppFactory.CreateDefaultClient();
        }

        [TestMethod]
        public async Task GetMovieById_GoodMovieId()
        {
            var response = await _httpClient.GetAsync("/Movie/55");
            var respons = response.StatusCode;
            Assert.AreEqual(System.Net.HttpStatusCode.OK, respons);
        }

        [TestMethod]
        public async Task GetMovieById_BadMovieId()
        {
            var response = await _httpClient.GetAsync("/Movie/0");
            var respons = response.StatusCode;
            Assert.AreEqual(System.Net.HttpStatusCode.InternalServerError, respons);
        }

        [TestMethod]
        public async Task GetMoviesByRating_GoodPage()
        {
            var response = await _httpClient.GetAsync("/Movie/ByRating?page=1");
            var respons = response.StatusCode;
            Assert.AreEqual(System.Net.HttpStatusCode.OK, respons);
        }

        [TestMethod]
        public async Task GetMoviesByRating_BadPage()
        {
            var response = await _httpClient.GetAsync("/Movie/ByRating?page=2000");
            var respons = response.StatusCode;
            Assert.AreEqual(System.Net.HttpStatusCode.InternalServerError, respons);
        }


        [TestMethod]
        public async Task GetMoviesByTitle_GoodPage()
        {
            var response = await _httpClient.GetAsync("/Movie/ByTitle?page=1");
            var respons = response.StatusCode;
            Assert.AreEqual(System.Net.HttpStatusCode.OK, respons);
        }

        [TestMethod]
        public async Task GetMoviesByTitle_BadPage()
        {
            var response = await _httpClient.GetAsync("/Movie/ByTitle?page=2000");
            var respons = response.StatusCode;
            Assert.AreEqual(System.Net.HttpStatusCode.InternalServerError, respons);
        }

        [TestMethod]
        public async Task GetCreditsByMovieId_GoodMovieId()
        {
            var response = await _httpClient.GetAsync("/Movie/5/credits");
            var respons = response.StatusCode;
            Assert.AreEqual(System.Net.HttpStatusCode.OK, respons);
        }

        [TestMethod]
        public async Task GetCreditsByMovieId_BadMovieId()
        {
            var response = await _httpClient.GetAsync("/Movie/0/credits");
            var respons = response.StatusCode;

            Assert.AreEqual(System.Net.HttpStatusCode.InternalServerError, respons);
        }

        [TestMethod]
        public async Task GetDirectorByMovieId_GoodMovieId()
        {
            var response = await _httpClient.GetAsync("/Movie/55/director");
            var respons = response.StatusCode;
            Assert.AreEqual(System.Net.HttpStatusCode.OK, respons);
        }

        [TestMethod]
        public async Task GetDirectorByMovieId_BadMovieId()
        {
            var response = await _httpClient.GetAsync("/Movie/0/director");
            var respons = response.StatusCode;
            Assert.AreEqual(System.Net.HttpStatusCode.InternalServerError, respons);
        }


        [TestMethod]
        public async Task GetVideosByMovieId_GoodMovieId()
        {
            var response = await _httpClient.GetAsync("/Movie/55/videos");
            var respons = response.StatusCode;
            Assert.AreEqual(System.Net.HttpStatusCode.OK, respons);
        }

        [TestMethod]
        public async Task GetVideosByMovieId_BadMovieId()
        {
            var response = await _httpClient.GetAsync("/Movie/0/videos");
            var respons = response.StatusCode;
            Assert.AreEqual(System.Net.HttpStatusCode.InternalServerError, respons);
        }


        [TestMethod]
        public async Task GetMoviesBySearch_GoodPageAndQuery()
        {
            var response = await _httpClient.GetAsync("/Movie/search?page=1&query=jesus");
            var respons = response.StatusCode;
            Assert.AreEqual(System.Net.HttpStatusCode.OK, respons);
        }

        [TestMethod]
        public async Task GetMoviesBySearch_BadPageAndQuery()
        {
            var response = await _httpClient.GetAsync("/Movie/search?page=2000&query=xxxxxxxxdddd");
            var respons = response.StatusCode;

            Assert.AreEqual(System.Net.HttpStatusCode.InternalServerError, respons);
        }

        [TestMethod]
        public async Task GetNowPlayingMoviesBySearch_GoodPage()
        {
            var response = await _httpClient.GetAsync("/Movie/NowPlaying?page=1");
            var respons = response.StatusCode;
            Assert.AreEqual(System.Net.HttpStatusCode.OK, respons);
        }

        [TestMethod]
        public async Task GetNowPlayingMoviesBySearch_BadPage()
        {
            var response = await _httpClient.GetAsync("/Movie/NowPlaying?page=2000");
            var respons = response.StatusCode;
            Assert.AreEqual(System.Net.HttpStatusCode.InternalServerError, respons);
        }

        [TestMethod]
        public async Task GetPopularMoviesBySearch_GoodPage()
        {
            var response = await _httpClient.GetAsync("/Movie/Popular?page=1");
            var respons = response.StatusCode;
            Assert.AreEqual(System.Net.HttpStatusCode.OK, respons);
        } 
        
        [TestMethod]
        public async Task GetPopularMoviesBySearch_BadPage()
        {
            var response = await _httpClient.GetAsync("/Movie/Popular?page=2000");
            var respons = response.StatusCode;
            Assert.AreEqual(System.Net.HttpStatusCode.InternalServerError, respons);
        }

        [TestMethod]
        public async Task GetUpcomingMoviesBySearch_GoodPage()
        {
            var response = await _httpClient.GetAsync("/Movie/Upcoming?page=1");
            var respons = response.StatusCode;
            Assert.AreEqual(System.Net.HttpStatusCode.OK, respons);
        } 
        
        [TestMethod]
        public async Task GetUpcomingMoviesBySearch_BadPage()
        {
            var response = await _httpClient.GetAsync("/Movie/Upcoming?page=2000");
            var respons = response.StatusCode;
            Assert.AreEqual(System.Net.HttpStatusCode.InternalServerError, respons);
        }
    }
}