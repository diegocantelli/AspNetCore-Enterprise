using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NSE.Cliente.API.services;
using NSE.Core.Utils;
using NSE.MessageBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NSE.Identitidade.API.Configuration
{
    public static class MessageBusConfig
    {
        public static void AddMessageBusConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMessageBus(configuration.GetMessageQueueConnection("MessageBus"))
                .AddHostedService<RegistroClienteIntegrationHandler>();
        }
    }
}
