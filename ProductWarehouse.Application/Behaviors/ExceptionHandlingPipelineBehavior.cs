using MediatR;
using MediatR.Pipeline;
using Microsoft.Extensions.DependencyInjection;
using ProductWarehouse.Application.Interfaces;

namespace ProductWarehouse.Application.Behaviors;
internal class ExceptionHandlingPipelineBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
{
	private readonly IEnumerable<IRequestExceptionHandler<TRequest, TResponse>> _exceptionHandlers;
	private readonly IServiceProvider _serviceProvider;

	public ExceptionHandlingPipelineBehavior(IEnumerable<IRequestExceptionHandler<TRequest, TResponse>> exceptionHandlers, IServiceProvider serviceProvider)
	{
		_exceptionHandlers = exceptionHandlers;
		_serviceProvider = serviceProvider;
	}

	public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
	{
		try
		{
			return await next();
		}
		catch (Exception exception)
		{
			var state = new RequestExceptionHandlerState<TResponse>();
			var exceptionType = exception.GetType();

			do
			{
				var exHandlerInterfaceType = typeof(Interfaces.IRequestExceptionHandler<,,>).MakeGenericType(typeof(TRequest), typeof(TResponse), exceptionType);
				var enumerableExceptionHandlerInterfaceType = typeof(IEnumerable<>).MakeGenericType(exHandlerInterfaceType);
				var handleMethod = exHandlerInterfaceType.GetMethod(nameof(IRequestExceptionHandler<TRequest, TResponse>.Handle));

				var exceptionHandlers = (IEnumerable<object>)_serviceProvider.GetServices(exHandlerInterfaceType);
				foreach (var exceptionHandler in exceptionHandlers)
				{
					await ((Task)handleMethod.Invoke(exceptionHandler, new object[] { request, exception, state, cancellationToken }));
				}
				exceptionType = exceptionType.BaseType;
			}
			while (exceptionType != typeof(Exception).BaseType);

			foreach (var handler in _exceptionHandlers)
			{
				await handler.Handle(request, exception, state, cancellationToken);
			}

			if (!state.Handled)
			{
				throw;
			}

			return state.Response;
		}
	}
}