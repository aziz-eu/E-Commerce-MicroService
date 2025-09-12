using Microsoft.Extensions.Configuration;
using Npgsql;
using System.Data;

namespace eCommerce.Infrastructure.DbContext
{
    public class DepperDbContext
    {
        private readonly IDbConnection _connection;
        private readonly IConfiguration _configuration;
        public DepperDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
            string? connectionString = _configuration.GetConnectionString("DefaultConnection");
            _connection = new NpgsqlConnection(connectionString);

        }

        public IDbConnection DbConnection => _connection;
    }
}
