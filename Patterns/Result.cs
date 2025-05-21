﻿namespace KSProject.Patterns
{
	public sealed record Error(string Code, string Descript)
	{
		public static readonly Error None = new Error("None", "No error");
	}
	public class Result
	{
		public bool IsSuccess { get; }
		public bool IsFailure => !IsSuccess;
		public Error Error { get; }

		public Result(bool isSuccess, Error error)
		{
			IsSuccess = isSuccess; ;
			Error = error;
		}

		public static Result Success() => new(true, Error.None);
		public static Result Failure(Error error) => new(false, error);
	}
}
