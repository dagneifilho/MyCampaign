using System;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Data.Mapping
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => new { u.Id,u.Username });
            builder.HasIndex(u => u.Username);
            builder.HasIndex(u=> u.Id);
            builder.Property(u=> u.Id).ValueGeneratedOnAdd();
            builder.Property(u => u.Password).IsRequired();
            builder.Property(u => u.Username).IsRequired();


        }
    }
}

