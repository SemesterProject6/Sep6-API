using Npgsql;

namespace Sep6_API.Persistence.User
{
    public class UserR : IUserR
    {
        private readonly IConfiguration configuration;
        string connectionString;

        public UserR(IConfiguration iConfig)
        {
            configuration = iConfig;
            connectionString = configuration["ConnectionStrings:DefaultConnection"];
        }
        public async Task CreateAccountAsync(Models.User user)
        {
            using var con = new NpgsqlConnection(connectionString);
            con.Open();

            string command = $"INSERT INTO sep6.\"users\"(\"firstname\", \"lastname\", \"birthday\", \"email\", \"password\", \"age\") VALUES (@FirstName, @LastName, @Birthday, @Email, @Password, @Age);";
            await using (NpgsqlCommand cmd = new NpgsqlCommand(command, con))
            {
                cmd.Parameters.AddWithValue("@FirstName", user.FirstName);
                cmd.Parameters.AddWithValue("@LastName", user.LastName);
                cmd.Parameters.AddWithValue("@Birthday", user.Birthday);
                cmd.Parameters.AddWithValue("@Email", user.Email);
                cmd.Parameters.AddWithValue("@Password", user.Password);
                cmd.Parameters.AddWithValue("@Age", user.Age);

                cmd.ExecuteNonQuery();
            }
            con.Close();
        }

        public async Task<Models.User> GetUserAsync(string Email)
        {
            using var con = new NpgsqlConnection(connectionString);
            con.Open();

            string command = $"SELECT * FROM sep6.\"users\" where \"email\" = @Email ;";
            await using (NpgsqlCommand cmd = new NpgsqlCommand(command, con))
            {
                cmd.Parameters.AddWithValue("@Email", NpgsqlTypes.NpgsqlDbType.Varchar, Email);

                await using (NpgsqlDataReader reader = await cmd.ExecuteReaderAsync())
                    while (await reader.ReadAsync())
                    {
                        Models.User user = ReadUser(reader);
                        con.Close();
                        return user;
                    }
            }
            con.Close();
            return null;
        }
        private static Models.User ReadUser(NpgsqlDataReader reader)
        {
            try
            {
                Models.User user = new Models.User
                {
                    UserID = reader["userid"] as int?,
                    FirstName = reader["firstname"] as string,
                    LastName = reader["lastname"] as string,
                    Birthday = reader["birthday"] as DateTime?,
                    Email = reader["email"] as string,
                    Password = reader["password"] as string,
                    Age = reader["age"] as int?,
                };
                return user;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<Models.User> GetUserByID(int id)
        {
            using var con = new NpgsqlConnection(connectionString);
            con.Open();

            string command = $"SELECT * FROM sep6.\"users\" where \"userid\" = @ID ;";
            await using (NpgsqlCommand cmd = new NpgsqlCommand(command, con))
            {
                cmd.Parameters.AddWithValue("@ID", id);

                await using (NpgsqlDataReader reader = await cmd.ExecuteReaderAsync())
                    while (await reader.ReadAsync())
                    {
                        Models.User user = ReadUser(reader);
                        con.Close();
                        return user;
                    }
            }
            con.Close();
            return null;
        }

        public async Task UpdateAccountAsync(Models.User user)
        {
            using var con = new NpgsqlConnection(connectionString);
            con.Open();

            string command = $"UPDATE sep6.\"users\" SET \"firstname\" = @FirstName, \"lastname\" = @LastName, \"birthday\" = @Birthday, \"password\" = @Password, \"age\" = @Age WHERE \"email\" = @Email;";
            await using (NpgsqlCommand cmd = new NpgsqlCommand(command, con))
            {
                cmd.Parameters.AddWithValue("@FirstName", user.FirstName);
                cmd.Parameters.AddWithValue("@LastName", user.LastName);
                cmd.Parameters.AddWithValue("@Birthday", user.Birthday);
                cmd.Parameters.AddWithValue("@Password", user.Password);
                cmd.Parameters.AddWithValue("@Age", user.Age);
                cmd.Parameters.AddWithValue("@Email", user.Email);

                cmd.ExecuteNonQuery();
            }
            con.Close();
        }
    }
}
