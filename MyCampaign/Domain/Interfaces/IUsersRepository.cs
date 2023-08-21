using System;
using Domain.Models;

namespace Domain.Interfaces
{
	public interface IUsersRepository : IDisposable
	{
		Task<int> InsertNewUser(User user);
		Task<User> GetUserByUserName(string username);
	}
}

