using KartowkaMarkowkaHub.Core.Domain;
using KartowkaMarkowkaHub.Data;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace KartowkaMarkowkaHub.Web
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // Метод для добавления служб в контейнер DI (Default name)
        // Add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            #region Авторизация
            //// Добавление и настройка служб авторизации
            //services.AddAuthorization(options =>
            //{
            //    // Пример политики авторизации
            //    options.AddPolicy("AdminOnly", policy => policy.RequireRole("Admin"));
            //});

            //// Добавление аутентификации (например, с использованием cookie)
            //services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            //.AddCookie(options =>
            //{
            //    options.LoginPath = "/Account/Login";
            //    options.AccessDeniedPath = "/Account/AccessDenied";
            //});
            #endregion
        }

        // Метод для добавления служб в контейнер DI
        // Add services to the container.
        public void DependencyInjectionRegistration(IServiceCollection services)
        {
            services.AddControllersWithViews();

            if (DbConfiguration.CurrentDbType == DbType.SqlLite)
            {
                services.AddDbContext<HubContext>(o => o.UseSqlite());
            }

            //services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "KartowkaMarkowkaHub ", Version = "v1" });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
        }
        // Метод для настройки конвейера HTTP-запросов
        // Configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serviceProvider)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetService<HubContext>();
                DbHelper.Initialize(dbContext);

                //dbContext.Database.EnsureDeleted();
                //dbContext.Database.EnsureCreated();
                //dbContext.Database.Migrate();
            }

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            } 
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            //app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                // Наиболее гибкий вариант роутинга.
                endpoints.MapControllers();

                #region Как могло бы быть
                // Основной маршрут для контроллеров без области
                //endpoints.MapControllerRoute(
                //    name: "default",
                //    pattern: "{controller=Home}/{action=Index}/{id?}");

                // Маршрут для области Admin
                endpoints.MapAreaControllerRoute(
                    name: "admin",
                    areaName: "Admin",
                    pattern: "Admin/{controller=Home}/{action=Index}/{id?}");

                // Маршрут для области Фермер
                endpoints.MapAreaControllerRoute(
                    name: "farmer",
                    areaName: "Farmer",
                    pattern: "Farmer/{controller=Home}/{action=Index}/{id?}");

                // Маршрут для области Клиент
                endpoints.MapAreaControllerRoute(
                    name: "client",
                    areaName: "Client",
                    pattern: "Client/{controller=Home}/{action=Index}/{id?}");

                endpoints.MapAreaControllerRoute(
                    name: "Account",
                    areaName: "Account",
                    pattern: "Account/{controller=Home}/{action=Index}/{id?}");
                #endregion
            });

            // Включаем middleware для генерации Swagger JSON и Swagger UI
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "API V1");
                c.RoutePrefix = "swagger"; // Чтобы Swagger UI был доступен по корню приложения
            });
        }
    }
}
