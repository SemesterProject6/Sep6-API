namespace Sep6_API.Persistence.User
{
    public interface IUserR
    {
        Task<Models.User> GetUserAsync(string Email);
        Task CreateAccountAsync(Models.User user);
        Task UpdateAccountAsync(Models.User user);
        Task<Models.User> GetUserByID(int id);
    }
}
