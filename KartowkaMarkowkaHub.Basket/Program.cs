
using KartowkaMarkowkaHub.Basket.rabbitmq;
using KartowkaMarkowkaHub.Basket.Services;
using MassTransit;

namespace KartowkaMarkowkaHub.Basket
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

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
                x.AddConsumer<ConsumerByProduct>();
                x.UsingRabbitMq((context, config) =>
                {
                    config.Host(rabbitmqOptions["Host"], h =>
                    {
                        h.Username(rabbitmqOptions["Username"]??"");
                        h.Password(rabbitmqOptions["Password"]??"");
                    });
                    config.ReceiveEndpoint("product-queue-response", e =>
                    {
                        e.ConfigureConsumer<ConsumerByProduct>(context);
                    });
                });               
            });

            builder.Services.AddHttpClient();
            builder.Services.AddScoped<IBasketService, BasketService>();    

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
