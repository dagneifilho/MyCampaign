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
	public class UnauthorizedResult<T> : Result<T> {
		public UnauthorizedResult(){
			StatusCode = 401;
			ResultType = ResultType.Unauthorized;
		}
	}
	public class OkResult<T> : Result<T> {
		public OkResult(T? data) {
			StatusCode = 200;
			ResultType = ResultType.Success;
			Data= data;
		}
	}
}

