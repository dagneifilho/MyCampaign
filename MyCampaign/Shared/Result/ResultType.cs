using System;
namespace Shared.Result
{
	public enum ResultType
	{
		Success,
		Created,
		ValidationError,
		BadRequest,
		NoContent,
		Unauthorized
	}
}

