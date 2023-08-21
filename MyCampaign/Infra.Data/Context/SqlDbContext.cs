using System;
using Domain.Models;
using Domain.Models.Database;
using Infra.Data.Mapping;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Context
{
	public class SqlDbContext : DbContext
	{
        private readonly DbConfig _config;
		public DbSet<User> Users { get;set; }
		public SqlDbContext(DbConfig configuration)
		{
            _config = configuration;
		}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
			modelBuilder.ApplyConfiguration(new UserMap());
		}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connectionString = _config.ConnectionString;
                optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
            }
        }
    }
}

