using KartowkaMarkowkaHub.Basket.Services;
using MassTransit;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

namespace KartowkaMarkowkaHub.Basket
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            string Origin = "MyAllowOrigin";

            builder.Services.AddCors(options =>
            {
                options.AddPolicy(name: Origin,
                    corsBuilder =>
                    {
                        corsBuilder
                          //.WithOrigins(["http://localhost:3000"])
                            .AllowAnyOrigin()                           
                            .AllowAnyHeader();
                    });
            });


            const string KEY = "mysecretsdasdasdasdkeyasdasdasdasdasda";

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new()
                {
                    // указывает, будет ли валидироваться издатель при валидации токена
                    ValidateIssuer = true,
                    // строка, представляющая издателя
                    ValidIssuer = "KartowkaMarkowkaHub",
                    // будет ли валидироваться потребитель токена
                    ValidateAudience = true,
                    // установка потребителя токена
                    ValidAudience = "KartowkaMarkowkaHub.Web",
                    // будет ли валидироваться время существования
                    ValidateLifetime = true,
                    // установка ключа безопасности
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(KEY)),
                    // валидация ключа безопасности
                    ValidateIssuerSigningKey = true,
                };
                options.Events = new JwtBearerEvents
                {
                    OnAuthenticationFailed = context =>
                    {
                        context.Response.StatusCode = 401;
                        return Task.CompletedTask;
                    }
                };
            });

            builder.Services.AddAuthorization();

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(options =>
            {
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "Bearer"
                });
                options.AddSecurityRequirement(new OpenApiSecurityRequirement()
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
            });

            builder.Services.AddOptions<Options>().Bind(builder.Configuration);
            Options options = builder.Configuration.Get<Options>() ?? throw new ArgumentException("Options not load from apsettings!");

            builder.Services.AddStackExchangeRedisCache(op =>
            {
                op.Configuration = options.RedisConnection;
                op.InstanceName = "basket_";
            });

            var rabbitmqOptions = builder.Configuration.GetSection("RabbitMq");
            builder.Services.AddMassTransit(x =>
            {
                x.UsingRabbitMq((context, config) =>
                {
                    config.Host(rabbitmqOptions["Host"], h =>
                    {
                        h.Username(rabbitmqOptions["Username"] ?? "");
                        h.Password(rabbitmqOptions["Password"] ?? "");
                    });
                });               
            });

            builder.Services.AddHttpClient();
            builder.Services.AddScoped<IBasketService, BasketService>();

            var app = builder.Build();

            app.UseCors(Origin);

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();    

            app.MapControllers();

            app.Run();
        }
    }
}
