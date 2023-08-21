using System;
using Microsoft.AspNetCore.Mvc;
using Shared.Result;

namespace WebApi.Controllers.Base
{
	public class CustomController : ControllerBase
	{
		protected IActionResult CustomResponse<T>(Result<T> result )
		{
			switch(result.ResultType)
			{
				case ResultType.Success:
					return Ok(result.Data);
				case ResultType.Created:
					return Created(string.Empty, result.Data);
				case ResultType.NoContent:
					return NoContent();
				case ResultType.BadRequest:
					return StatusCode(400,result.ErrorMessage);
				case ResultType.ValidationError:
					return BadRequest(result.Data);
			}
			return new StatusCodeResult(500);
		}
	}
}

