using Sep6_API.Models;
using Sep6_API.Persistence.User;

namespace Sep6_API.Data.Users
{
    public class UserService : IUserService
    {

        IUserR repo;

        public UserService(IConfiguration configuration)
        {
            repo = new UserR(configuration);
        }
        public async Task CreateAccount(User user)
        {
            await repo.CreateAccountAsync(user);
        }

        public async Task<User> GetUserByID(int id)
        {
            return await repo.GetUserByID(id);
        }

        public async Task UpdateAccountAsync(User user)
        {
            await repo.UpdateAccountAsync(user);
        }

        public async Task<User> ValidateUser(User user)
        {
            User verifiedUser = await VerifyUser(user);

            if (verifiedUser == null)
            {
                return null;
            }
            else
            {
                return verifiedUser;
            }
        }
        private async Task<User> VerifyUser(User user)
        {
            User userToVerify = await repo.GetUserAsync(user.Email);

            if (userToVerify == null)
            {
                return null;
            }

            if (user.Password == null)
            {
                return null;
            }

            if (user.Password == userToVerify.Password)
            {
                return userToVerify;
            }

            return null;
        }
    }
}
