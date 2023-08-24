using System;
using Microsoft.AspNetCore.Mvc;
using Shared.Result;

namespace WebApi.Controllers.Base
{
	public class CustomController : ControllerBase
	{
		protected IActionResult CustomResponse<T>(Result<T> result )
		{
			return StatusCode(result.StatusCode, result.Data != null ? result.Data : result.ErrorMessage);
		}
	}
}

