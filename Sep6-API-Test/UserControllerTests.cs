using Microsoft.AspNetCore.Mvc.Testing;

namespace Sep6_API_Test
{
    [TestClass]
    public class UserControllerTests
    {
        private HttpClient _httpClient;

        public UserControllerTests()
        {
            var webAppFactory = new WebApplicationFactory<Program>();
            _httpClient = webAppFactory.CreateDefaultClient();
        }

        [TestMethod]
        public async Task GetValidateUserByEmailAndPassword_GoodEmailAndPassword()
        {
            var response = await _httpClient.GetAsync("/User/validate?email=didi%40gmail.com&password=samil123");
            var respons = response.StatusCode;
            Assert.AreEqual(System.Net.HttpStatusCode.OK, respons);
        }

        [TestMethod]
        public async Task GetValidateUserByEmailAndPassword_BadExsitingEmailAndPassword()
        {
            var response = await _httpClient.GetAsync("/User/validate?email=didi%40gmailol.com&password=lololololol");
            var respons = response.StatusCode;
            Assert.AreEqual(System.Net.HttpStatusCode.NoContent, respons);
        }

        [TestMethod]
        public async Task GetUserByUserID_GoodUserID()
        {
            var response = await _httpClient.GetAsync("/User/get?id=4");
            var respons = response.StatusCode;
            Assert.AreEqual(System.Net.HttpStatusCode.OK, respons);
        }

        [TestMethod]
        public async Task GetUserByUserID_BadUserID()
        {
            var response = await _httpClient.GetAsync("/User/get?id=2000");
            var respons = response.StatusCode;
            Assert.AreEqual(System.Net.HttpStatusCode.NoContent, respons);
        }
    }
}
