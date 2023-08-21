using System;
using Domain.Interfaces;
using Domain.Models;
using Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Repositories
{
    public class UsersRepository : IUsersRepository
	{
		private readonly SqlDbContext _sqlDbContext;
		public UsersRepository(SqlDbContext context)
		{
			_sqlDbContext = context;
		}

        public void Dispose()
        {
            _sqlDbContext.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task<User> GetUserByUserName(string username)
        {
            var user = await _sqlDbContext.Users.FirstOrDefaultAsync(user => user.Username.Equals(username));
            return user;
        }
        public async Task<int> InsertNewUser(User user)
        {
            await _sqlDbContext.Users.AddAsync(user);
            await _sqlDbContext.SaveChangesAsync();
            return user.Id;
        }
        
    }
}

