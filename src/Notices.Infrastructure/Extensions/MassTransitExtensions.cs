using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MassTransit;
using Notices.Application.Consumers;
namespace Notices.Infrastructure.Extensions;


public static class MassTransitExtensions
{
    public static IServiceCollection AddNoticeApiMassTransit(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddMassTransit(x =>
        {
            x.AddConsumer<UserCreatedConsumer>();

            x.UsingRabbitMq((context, cfg) =>
            {
                cfg.Host(configuration["RabbitMq:Host"], h =>
                {
                    h.Username(configuration["RabbitMq:Username"]);
                    h.Password(configuration["RabbitMq:Password"]);
                });

                cfg.ReceiveEndpoint("notice-user-created", e =>
                {
                    e.ConfigureConsumer<UserCreatedConsumer>(context);
                });
            });
        });
        return services;
    }
}