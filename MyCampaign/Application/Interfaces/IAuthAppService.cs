using System;
using Application.Models.Request;
using Application.Models.Response;
using Shared.Result;

namespace Application.Interfaces
{
	public interface IAuthAppService : IDisposable
	{
		Task<Result<TokenResponse>> RegisterUser(UserRegister user); 
		Task<Result<TokenResponse>> Login(Login login);
	}
}

