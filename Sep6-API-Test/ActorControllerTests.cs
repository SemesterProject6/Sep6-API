using Microsoft.AspNetCore.Mvc.Testing;

namespace Sep6_API_Test
{
    [TestClass]
    public class ActorControllerTests
    {
        private HttpClient _httpClient;

        public ActorControllerTests()
        {
            var webAppFactory = new WebApplicationFactory<Program>();
            _httpClient = webAppFactory.CreateDefaultClient();
        }

        [TestMethod]
        public async Task GetActorById_GoodActorId()
        {
            var response = await _httpClient.GetAsync("/Actor/1100");
            var respons = response.StatusCode;
            Assert.AreEqual(System.Net.HttpStatusCode.OK, respons);
        }

        [TestMethod]
        public async Task GetActorById_BadActorId()
        {
            var response = await _httpClient.GetAsync("/Actor/222333");
            var respons = response.StatusCode;
            Assert.AreEqual(System.Net.HttpStatusCode.InternalServerError, respons);
        }

        [TestMethod]
        public async Task GetActorsMovies_WithExsitingActorId()
        {
            var response = await _httpClient.GetAsync("/Actor/1100/movie_credits");
            var respons = response.StatusCode;
            Assert.AreEqual(System.Net.HttpStatusCode.OK, respons);
        }

        [TestMethod]
        public async Task GetActorsMovies_WithoutExsitingActorId()
        {
            var response = await _httpClient.GetAsync("/Actor/222333/movie_credits");
            var respons = response.StatusCode;
            Assert.AreEqual(System.Net.HttpStatusCode.InternalServerError, respons);
        }

        [TestMethod]
        public async Task GetPopularActors_WithExsitingPage()
        {
            var response = await _httpClient.GetAsync("/Actor/popularActors?page=1");
            var respons = response.StatusCode;
            Assert.AreEqual(System.Net.HttpStatusCode.OK, respons);
        }

        [TestMethod]
        public async Task GetPopularActors_WithoutExsitingPage()
        {
            var response = await _httpClient.GetAsync("/Actor/popularActors?page=2000");
            var respons = response.StatusCode;
            Assert.AreEqual(System.Net.HttpStatusCode.InternalServerError, respons);
        }

        [TestMethod]
        public async Task GetActorsSearch_WithExsitingPageAndQuery()
        {
            var response = await _httpClient.GetAsync("/Actor/search?page=1&query=arnold");
            var respons = response.StatusCode;
            Assert.AreEqual(System.Net.HttpStatusCode.OK, respons);
        }

        [TestMethod]
        public async Task GetActorsSearch_WithoutExsitingPageAndQuery()
        {
            var response = await _httpClient.GetAsync("/Actor/search?page=2000&query=huehuehuehue");
            var respons = response.StatusCode;
            Assert.AreEqual(System.Net.HttpStatusCode.InternalServerError, respons);
        }
    }
}
