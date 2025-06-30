namespace Application.Common.Results
{
    public class Result<T>
    {
        public bool Success { get; init; }
        public T? Data { get; init; }
        public string? Message { get; init; }
        public List<string>? Errors { get; init; }

        public bool HasErrors => Errors != null && Errors.Any();

        public static Result<T> Ok(T data) =>
            new() { Success = true, Data = data };

        public static Result<T> Fail(string message) =>
            new() { Success = false, Message = message };

        public static Result<T> Fail() =>
            new() { Success = false };

        public static Result<T> Fail(List<string> errors) =>
            new() { Success = false, Errors = errors };

        public static Result<T> ValidationError(List<string> errors) =>
            new() { Success = false, Message = "Validation failed", Errors = errors };
    }
}
