using Microsoft.AspNetCore.Mvc.Testing;

namespace Sep6_API_Test
{
    [TestClass]
    public class FavoriteMovieControllerTests
    {

        private HttpClient _httpClient;

        public FavoriteMovieControllerTests()
        {
            var webAppFactory = new WebApplicationFactory<Program>();
            _httpClient = webAppFactory.CreateDefaultClient();
        }

        [TestMethod]
        public async Task GetFavMoviesByUserID_UserID()
        {
            var response = await _httpClient.GetAsync("/FavoriteMovie/getFavorites?userID=4");
            var respons = response.StatusCode;
            Assert.AreEqual(System.Net.HttpStatusCode.OK, respons);
        } 

        [TestMethod]
        public async Task PostAddMovieToUserFavList_GoodUserIDAndMovieID()
        {
            var response = await _httpClient.PostAsync("/FavoriteMovie/addFavorite?userID=4&movieID=55", null);
            var respons = response.StatusCode;
            Assert.AreEqual(System.Net.HttpStatusCode.OK, respons);
        }

        [TestMethod]
        public async Task PostAddMovieToUserFavList_BadUserIDAndMovieID()
        {
            var response = await _httpClient.PostAsync("/FavoriteMovie/addFavorite?userID=2000&movieID=1", null);
            var respons = response.StatusCode;
            Assert.AreEqual(System.Net.HttpStatusCode.OK, respons);
        }
  

        [TestMethod]
        public async Task GetFavMoviesByUserEmail_GoodUserEmail()
        {
            var response = await _httpClient.GetAsync("/FavoriteMovie/getFavoritesByEmail?email=didi%40gmail.com");
            var respons = response.StatusCode;
            Assert.AreEqual(System.Net.HttpStatusCode.OK, respons);
        }

        [TestMethod]
        public async Task GetFavMoviesByUserEmail_BadUserEmail()
        {
            var response = await _httpClient.GetAsync("/FavoriteMovie/getFavoritesByEmail?email=dididodo%40gmailol.com");
            var respons = response.StatusCode;
            Assert.AreEqual(System.Net.HttpStatusCode.NoContent, respons);
        }

        [TestMethod]
        public async Task GetFavMoviesCountByMovieID_GoodMovieID()
        {
            var response = await _httpClient.GetAsync("/FavoriteMovie/getFavoriteMovieCount?movieID=55");
            var respons = response.StatusCode;
            Assert.AreEqual(System.Net.HttpStatusCode.OK, respons);
        }

        [TestMethod]
        public async Task GetFavMoviesCountByMovieID_BadMovieID()
        {
            var response = await _httpClient.GetAsync("/FavoriteMovie/getFavoriteMovieCount?movieID=1");
            var respons = response.StatusCode;
            Assert.AreEqual(System.Net.HttpStatusCode.OK, respons);
        }

        [TestMethod]
        public async Task DeleteFavMovieByUserID_GoodUserIDAndMovieID()
        {
            var response = await _httpClient.DeleteAsync("/FavoriteMovie/removeFavorite?userID=4&movieID=55");
            var respons = response.StatusCode;
            Assert.AreEqual(System.Net.HttpStatusCode.OK, respons);
        }

        [TestMethod]
        public async Task DeleteFavMovieByUserID_BadUserIDAndMovieID()
        {
            var response = await _httpClient.DeleteAsync("/FavoriteMovie/removeFavorite?userID=2000&movieID=1");
            var respons = response.StatusCode;
            Assert.AreEqual(System.Net.HttpStatusCode.OK, respons);
        }
    }
}
