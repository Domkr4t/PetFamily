﻿namespace PetFamily.Domain.Shared
{
    public class Result
    {
        public Result(bool isSuccess, string? error)
        {
            if (isSuccess == true && error is not null)
                throw new InvalidOperationException();

            if (isSuccess == false && error == null)
                throw new InvalidOperationException();

            IsSuccess = isSuccess;
            Error = error;
        }

        public string? Error { get; set; }

        public bool IsSuccess { get; }

        public bool IsFailure => !IsSuccess;

        public static Result Success() => new(true, null);

        public static Result Failure(string error) => new(false, error);
    }

    public class Result<TValue> : Result
    {
        private readonly TValue _value;

        public TValue Value => IsSuccess
            ? _value
            : throw new InvalidOperationException();

        public Result(TValue value, bool isSuccess, string? error) : base(isSuccess, error)
        {
            _value = value;
        }

        public static Result<TValue> Success(TValue value) => new(value, true, null);

        public static new Result<TValue> Failure(string error) => new(default!, false, error);

        public static implicit operator Result<TValue>(TValue value) => new(value, true, null);
    }
}
