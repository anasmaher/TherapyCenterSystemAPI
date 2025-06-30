namespace Application.Common.Results
{
    public class NonGenericResult
    {
        public bool Success { get; init; }
        public string? Message { get; init; }
        public List<string>? Errors { get; init; }

        public static NonGenericResult Ok(string? message = null) => new() { Success = true, Message = message };
        public static NonGenericResult Fail(string? message = null) => new() { Success = false, Message = message };
        public static NonGenericResult ValidationError(List<string> errors) => new() { Success = false, Errors = errors };
    }
}
