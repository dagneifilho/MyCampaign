using System;
using Application.AppServices;
using Application.Interfaces;
using Domain.Interfaces;
using Domain.Models.Database;
using Infra.Data.Context;
using Infra.Data.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infra.CrossCutting
{
	public static class IoC
	{
		public static void ConfigureServices(IServiceCollection services)
		{
			services.AddTransient<IAuthAppService,AuthAppService>();



			services.AddTransient<IUsersRepository, UsersRepository>();



			services.AddTransient<SqlDbContext>();

		}
	}
}

