using Application.Common.Results;
using FluentValidation;
using MediatR;

namespace Application.Common.Behaviors;

public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if (!_validators.Any())
            return await next();

        var context = new ValidationContext<TRequest>(request);

        var validationResults = await Task.WhenAll(
            _validators.Select(v => v.ValidateAsync(context, cancellationToken))
        );

        var failures = validationResults
            .SelectMany(r => r.Errors)
            .Where(f => f != null)
            .ToList();

        if (failures.Count != 0)
        {
            var errorMessages = failures.Select(f => f.ErrorMessage).ToList();

            // Case 1: Handler returns Result (non-generic)
            if (typeof(TResponse) == typeof(NonGenericResult))
            {
                return (TResponse)(object)NonGenericResult.ValidationError(errorMessages);
            }

            // Case 2: Handler returns Result<T>
            if (typeof(TResponse).IsGenericType && typeof(TResponse).GetGenericTypeDefinition() == typeof(Result<>))
            {
                var innerType = typeof(TResponse).GetGenericArguments()[0];
                var resultType = typeof(Result<>).MakeGenericType(innerType);
                var method = resultType.GetMethod("ValidationError", new[] { typeof(List<string>) });

                if (method is not null)
                {
                    var result = method.Invoke(null, new object[] { errorMessages });
                    return (TResponse)result!;
                }
            }

            // Fallback if response type is unknown
            throw new ValidationException(failures);
        }

        return await next();
    }
}
