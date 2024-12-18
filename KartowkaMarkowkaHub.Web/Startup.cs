﻿using FluentValidation;
using FluentValidation.AspNetCore;
using KartowkaMarkowkaHub.Core.Abstractions.Repositories;
using KartowkaMarkowkaHub.Core.Domain;
using KartowkaMarkowkaHub.Data;
using KartowkaMarkowkaHub.Data.Repositories;
using KartowkaMarkowkaHub.Services.Account;
using KartowkaMarkowkaHub.Services.Identity;
using KartowkaMarkowkaHub.Services.Orders;
using KartowkaMarkowkaHub.Services.Products;
using KartowkaMarkowkaHub.Web.Validators;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Reflection;
using KartowkaMarkowkaHub.Application;
using KartowkaMarkowkaHub.Services.Roles;
using Serilog;
using Serilog.Sinks.Graylog;
using System.Configuration;

namespace KartowkaMarkowkaHub.Web
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        string Origin = "MyAllowOrigin";

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
            string corsAllowedOrigins = Configuration["CORS_ALLOWED_ORIGINS"] ?? string.Empty;
            services.AddCors(options =>
            {
                options.AddPolicy(name: Origin,
                    corsBuilder =>
                    {
                        corsBuilder
                            .WithOrigins(corsAllowedOrigins)
                            .AllowAnyHeader()
                            .AllowAnyMethod();
                    });
            });
        
            #region Add Serialog + Graylog
            //Добавление логера напрямую
            //Log.Logger = new LoggerConfiguration()
            // .Enrich.FromLogContext()
            // .WriteTo.Graylog(
            //     new GraylogSinkOptions
            //     {
            //         HostnameOrAddress = "localhost",
            //         Port = 12201,
            //         Facility = "kartowkamarkowka",
            //         TransportType = Serilog.Sinks.Graylog.Core.Transport.TransportType.Udp
            //     })
            // .CreateLogger();

            Log.Logger = new LoggerConfiguration()
            .ReadFrom.Configuration(Configuration) // Подключение конфигурации из appsettings.json
            .CreateLogger();

            services.AddLogging(loggingBuilder =>
            {
                loggingBuilder.ClearProviders();
                loggingBuilder.AddSerilog();
            });

            #endregion

            services.AddControllersWithViews();

            //https://github.com/FluentValidation/FluentValidation.AspNetCore
            services.AddFluentValidationAutoValidation();
            services.AddFluentValidationClientsideAdapters();
            services.AddValidatorsFromAssemblyContaining(typeof(UserViewModelValidator));

            services.AddOptions<Options>().Bind(Configuration);
            Options options = Configuration.Get<Options>() ?? throw new ArgumentException("Options not load from apsettings!");

            switch (DbConfiguration.CurrentDbType)
            {
                case DbType.SqlLite:
                    services.AddDbContext<HubContext>(o => o.UseSqlite());
                    break;

                case DbType.PostgreSql:
                    services.AddDbContext<HubContext>(o => o.UseNpgsql(options.ConnectionStrings.PostgresConnection));
                    break;
            }

            //services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "KartowkaMarkowkaHub ", Version = "v1" });

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please insert JWT token into field",
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    BearerFormat = "JWT",
                    Scheme = "Bearer"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header,
                        },
                        new List<string>()
                    }
                });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

            services.AddValidatorsFromAssemblies([Assembly.GetExecutingAssembly()]);
            services.AddAutoMapper([Assembly.GetExecutingAssembly()]);

            services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
            services.AddScoped<IClaimService, ClaimService>();
            services.AddScoped<ITokenService, TokenService>();         
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            //Добавляет DI зависимости проекта Application
            services.AddApplication();
            services.AddServices();

            //Авторизация
            //services.AddAuthorization();
            services
                .AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(options =>
                {
                    //options.SaveToken = true;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        // указывает, будет ли валидироваться издатель при валидации токена
                        ValidateIssuer = true,
                        // строка, представляющая издателя
                        ValidIssuer = AuthOptions.ISSUER,
                        // будет ли валидироваться потребитель токена
                        ValidateAudience = true,
                        // установка потребителя токена
                        ValidAudience = AuthOptions.AUDIENCE,
                        // будет ли валидироваться время существования
                        ValidateLifetime = true,
                        // установка ключа безопасности
                        IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
                        // валидация ключа безопасности
                        ValidateIssuerSigningKey = true,
                    };
                    options.Events = new JwtBearerEvents
                    {
                        OnAuthenticationFailed = context =>
                        {
                            Console.WriteLine("Authentication failed: " + context.Exception.Message);
                            return Task.CompletedTask;
                        },
                        OnTokenValidated = context =>
                        {
                            Console.WriteLine("Token validated: " + context.SecurityToken);
                            return Task.CompletedTask;
                        }
                    };
                });

            services.AddStackExchangeRedisCache(cacheOptions =>
            {
                cacheOptions.Configuration = options.ConnectionStrings.RedisConnection;
                cacheOptions.InstanceName = "kartowka-markowka-hub_";
            });
        }

        // Метод для настройки конвейера HTTP-запросов
        // Configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serviceProvider)
        {
            app.UseCors(Origin);
            using (var scope = serviceProvider.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetService<HubContext>();
                //DbHelper.Initialize(dbContext);

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

            // Включение аутентификации
            app.UseAuthentication();
            app.UseAuthorization();

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
