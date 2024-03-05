using MediatR.Pipeline;

namespace ProductWarehouse.Application.Interfaces;
public interface IRequestExceptionHandler<in TRequest, TResponse, in TException>
	where TRequest : notnull
	where TException : Exception
{
	Task Handle(
		TRequest request,
		TException exception,
		RequestExceptionHandlerState<TResponse> state,
		CancellationToken cancellationToken);
}

public interface IRequestExceptionHandler<in TRequest, TResponse> : IRequestExceptionHandler<TRequest, TResponse, Exception>
{
}