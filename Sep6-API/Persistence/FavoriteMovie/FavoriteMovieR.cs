using Npgsql;
using Sep6_API.Models;

namespace Sep6_API.Persistence.FavoriteMovie
{
    public class FavoriteMovieR : IFavoriteMovieR
    {
        private readonly IConfiguration configuration;
        string connectionString;

        public FavoriteMovieR(IConfiguration iConfig)
        {
            configuration = iConfig;
            connectionString = configuration["ConnectionStrings:DefaultConnection"];
        }

        public async Task AddFavoriteMovie(int UserId, int MovieId)
        {
            if (await GetIsFavoriteMovieByID(UserId, MovieId)) return; 

            using var con = new NpgsqlConnection(connectionString);
            con.Open();

            string command = $"INSERT INTO sep6.\"FavouriteMovie\"(\"UserId\", \"MovieId\") VALUES (@UserId, @MovieId);";
            await using (NpgsqlCommand cmd = new(command, con))
            {
                cmd.Parameters.AddWithValue("@UserId", UserId);
                cmd.Parameters.AddWithValue("@MovieId", MovieId);

                cmd.ExecuteNonQuery();
            }
            con.Close();
        }

        public async Task<List<int>> GetFavoriteMoviesByID(int UserId)
        {
            using var con = new NpgsqlConnection(connectionString);
            con.Open();

            List<int> MovieIds = new();

            string command = $"SELECT * FROM sep6.\"FavouriteMovie\" where \"UserId\" = @UserId ;";
            await using NpgsqlCommand cmd = new(command, con);
            cmd.Parameters.AddWithValue("@UserId", NpgsqlTypes.NpgsqlDbType.Integer, UserId);

            await using (NpgsqlDataReader reader = await cmd.ExecuteReaderAsync())
                while (await reader.ReadAsync())
                {
                    int? idToAdd = reader["MovieId"] as int?;
                    if (idToAdd != null) MovieIds.Add((int)idToAdd);
                }
            con.Close();
            return MovieIds;
        }

        public async Task<bool> GetIsFavoriteMovieByID(int UserId, int MovieId)
        {
            List<int> MovieIds = await GetFavoriteMoviesByID(UserId);
            foreach (var movie in MovieIds)
            {
                if (movie == MovieId) return true;
            }
            return false;
        }


        public async Task RemoveFavoriteMovieByID(int UserId, int MovieId)
        {
            if (await GetIsFavoriteMovieByID(UserId, MovieId) == false) return; //if the movie is not a favorite, just return

            using var con = new NpgsqlConnection(connectionString);
            con.Open();

            string command = $"DELETE FROM sep6.\"FavouriteMovie\" where \"UserId\" = @UserId AND \"MovieId\" = @MovieId ;";
            await using (NpgsqlCommand cmd = new(command, con))
            {
                cmd.Parameters.AddWithValue("@UserId", UserId);
                cmd.Parameters.AddWithValue("@MovieId", MovieId);
                cmd.ExecuteNonQuery();
            }
            con.Close();
        }

        public async Task<int> GetFavoriteMovieCount(int MovieId)
        {
            using var con = new NpgsqlConnection(connectionString);
            con.Open();
            int count = 0;

            string command = $"SELECT COUNT(\"MovieId\") FROM sep6.\"FavouriteMovie\" WHERE \"MovieId\" = @MovieId;";
            await using (NpgsqlCommand cmd = new(command, con))
            {
                cmd.Parameters.AddWithValue("@MovieId", MovieId);

                await using NpgsqlDataReader reader = await cmd.ExecuteReaderAsync();
                while (await reader.ReadAsync())
                {
                    count = int.Parse(reader["count"].ToString());
                }
            }
            con.Close();
            return count;
        }
     
    }
}
