using Dapper;
using eCommerce.Core.Dtos.Enums;
using eCommerce.Core.Entities;
using eCommerce.Core.RepositoryContracts;
using eCommerce.Infrastructure.DbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Infrastructure.Repositories
{
    public class UsersRepository : IUsersRepository
    {

        private readonly DepperDbContext _dbContext;

        public UsersRepository(DepperDbContext depperDbContext)
        {
            _dbContext = depperDbContext;
        }

        public async Task<ApplicationUser?> AddUser(ApplicationUser user)
        {
           user.UserId = Guid.NewGuid();
            string query = $"INSERT INTO public.\"Users\" (\"UserId\",\"Email\",\"Password\", \"Name\", \"Gender\" ) Values(@UserId, @Email, @Password, @Name, @Gender)";
            int affectedRowCount = await _dbContext.DbConnection.ExecuteAsync(query, user);

            if (affectedRowCount>0)
            {
                return user;
            }
            return null;

        }

        public async Task<ApplicationUser?> GetUserByEmailAndPassword(string? email, string? password)
        {

            string query = "Select * From Public.\"Users\" Where \"Email\"=@Email AND \"Password\"=@Password";
            var parameters = new { Email = email, Password = password };
             ApplicationUser? user =    await _dbContext.DbConnection.QueryFirstOrDefaultAsync<ApplicationUser>(query,parameters);

            return user;
        }
    }
}
