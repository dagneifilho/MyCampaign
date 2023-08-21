using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Application.Models.Request
{
	public class UserRegister
	{
		[Required]
		[JsonProperty("username")]
		public string? Username { get;set; }
		[JsonProperty("password")]
		[Required]
		public string? Password { get;set; }
		[JsonProperty("firstName")]
		public string? FirstName { get;set; }
		[JsonProperty("lastName")]
		public string? LastName { get;set;}
		[JsonProperty("birthDate")]
		public DateTime? BirthDate { get;set; }
    }
}

