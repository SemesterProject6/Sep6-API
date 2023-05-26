namespace Sep6_API.Data.Users
{
    public interface IUserService
    {
        Task<Models.User> ValidateUser(Models.User user);
        Task CreateAccount(Models.User user);
        Task UpdateAccountAsync(Models.User user);
        Task<Models.User> GetUserByID(int id);
    }
}
