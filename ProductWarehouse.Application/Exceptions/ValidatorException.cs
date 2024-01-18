using FluentValidation.Results;

namespace ProductWarehouse.Application.Exceptions;

public class ValidatorException : Exception
{
    public IEnumerable<ValidationFailure> Errors { get; }

    public ValidatorException(IEnumerable<ValidationFailure> errors)
    {
        Errors = errors;
    }
}
