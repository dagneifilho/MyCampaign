using System;
namespace Shared.Result
{
	public abstract class Result<T>
	{
		public ResultType ResultType { get;set; }
		public T? Data { get;set; }
		public int StatusCode { get;set;}
		public string? ErrorMessage { get;set; }
	}

	public class CreatedResult<T> : Result<T>
	{
		public CreatedResult(T? data)
		{
			Data = data;
			ResultType = ResultType.Created;
			StatusCode = 201;
		}
	}
	public class BadRequestResult<T> : Result<T>
	{
		public BadRequestResult( string? errorMessage = null)
		{
			StatusCode = 400;
			ResultType = ResultType.BadRequest;
			ErrorMessage = errorMessage;
		}
	}
}

