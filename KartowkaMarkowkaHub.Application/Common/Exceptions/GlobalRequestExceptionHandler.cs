using KartowkaMarkowkaHub.Application.Abstractions.Common.Models;
using MediatR.Pipeline;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace KartowkaMarkowkaHub.Application.Common.Exceptions
{
    public class GlobalRequestExceptionHandler<TRequest, TResponse, TException>
       : IRequestExceptionHandler<TRequest, TResponse, TException>
       where TResponse : IExceptionResponce, new()
       where TException : Exception
    {
        private readonly ILogger<GlobalRequestExceptionHandler<TRequest, TResponse, TException>> _logger;
        public GlobalRequestExceptionHandler(
           ILogger<GlobalRequestExceptionHandler<TRequest, TResponse, TException>> logger)
        {
            _logger = logger;
        }
        public Task Handle(TRequest request, TException exception, RequestExceptionHandlerState<TResponse> state,
            CancellationToken cancellationToken)
        {
            var ex = exception.Demystify();
            _logger.LogError(ex, "Something went wrong while handling request of type {@requestType}.", typeof(TRequest));
            var response = new TResponse
            {
                HasError = true,
                Message = ex.Message,
            };
            state.SetHandled(response);
            return Task.CompletedTask;
        }
    }
}
