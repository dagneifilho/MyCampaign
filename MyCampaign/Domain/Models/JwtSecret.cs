using System;
namespace Domain.Models
{
	public class JwtSecret
	{
		public string? Key { get;set; }
		public string? Issuer { get;set; }
	}
}

