namespace PetFamily.Domain.Shared
{
    public class Result
    {
        public Result(bool isSuccess, Error? error)
        {
            if (isSuccess == true && error is not null)
                throw new InvalidOperationException("1");

            if (isSuccess == false && error == null)
                throw new InvalidOperationException("2");

            IsSuccess = isSuccess;
            Error = error;
        }

        public Error Error { get; } = default!;

        public bool IsSuccess { get; }

        public bool IsFailure => !IsSuccess;

        public static Result Success() => new(true, null);

        public static Result Failure(Error error) => new(false, error);
    }

    public class Result<TValue, TError> : Result
    {
        private readonly TValue _value;

        public TValue Value => IsSuccess
            ? _value
            : default!;

        public Result(TValue value, bool isSuccess, Error? error) : base(isSuccess, error)
        {
            _value = value;
        }

        public static Result<TValue, TError> Success(TValue value) => new(value, true, null);

        public static new Result<TValue, TError> Failure(Error error) => new(default!, false, error);

        public static implicit operator Result<TValue, TError>(TValue value) => new(value, true, null);

        public static implicit operator Result<TValue, TError> (Error error) => new(default!, false, error);
    }
}
