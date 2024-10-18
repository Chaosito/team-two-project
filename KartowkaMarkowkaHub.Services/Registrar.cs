using FluentValidation;
using KartowkaMarkowkaHub.Services.Account;
using KartowkaMarkowkaHub.Services.Orders;
using KartowkaMarkowkaHub.Services.OrderStatuses;
using KartowkaMarkowkaHub.Services.Products;
using KartowkaMarkowkaHub.Services.Roles;
using KartowkaMarkowkaHub.Services.Vendors;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace KartowkaMarkowkaHub.Application
{
    public static class Registrar
    {
        public static IServiceCollection AddServices(
            this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IOrderService, OrderService>();

            #region ?

            services.AddScoped<IOrderStatusService, OrderStatusService>();
            services.AddScoped<IVendorService, VendorService>(); 

            #endregion

            services.AddValidatorsFromAssemblies([Assembly.GetExecutingAssembly()]);
            services.AddAutoMapper([Assembly.GetExecutingAssembly()]);

            return services;
        }
    }
}
