using System;
using Domain.Models.Database;
using Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Configurations
{
	public static class DatabaseConfig
	{
		public static void ConfigureDatabases(IServiceCollection services ,IConfiguration configuration)
		{
			string? connectionString = configuration.GetConnectionString("MySql");
			services.AddSingleton<DbConfig>(new DbConfig { ConnectionString = connectionString });

			services.AddDbContext<SqlDbContext>(
        options => options.UseMySql(connectionString,ServerVersion.AutoDetect(connectionString)));
		}
	}
}

