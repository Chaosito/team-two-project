using FluentValidation;
using KartowkaMarkowkaHub.Application.Common.Behaviours;
using KartowkaMarkowkaHub.Application.Common.Exceptions;
using MediatR;
using MediatR.Pipeline;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace KartowkaMarkowkaHub.Application
{
    public static class Registrar
    {
        public static IServiceCollection AddApplication(
            this IServiceCollection services)
        {
            services.AddTransient(
                typeof(IRequestExceptionHandler<,,>), 
                typeof(GlobalRequestExceptionHandler<,,>));
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            services.AddValidatorsFromAssemblies([Assembly.GetExecutingAssembly()]);
            services.AddAutoMapper([Assembly.GetExecutingAssembly()]);
            services.AddTransient(
                typeof(IPipelineBehavior<,>),
                typeof(ValidationBehavior<,>));
            services.AddTransient(
                typeof(IPipelineBehavior<,>),
                typeof(LoggingBehavior<,>));
            return services;
        }
    }
}
