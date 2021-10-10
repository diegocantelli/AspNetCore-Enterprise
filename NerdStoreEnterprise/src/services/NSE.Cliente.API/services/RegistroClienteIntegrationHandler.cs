using EasyNetQ;
using FluentValidation.Results;
using Microsoft.Extensions.Hosting;
using NSE.Cliente.API.Application.Commands;
using NSE.Core.Messages.Integration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace NSE.Cliente.API.services
{
    // BackgroundService -> irá atuar como um serviço aguardando algo para ser executado
    public class RegistroClienteIntegrationHandler : BackgroundService
    {
        private readonly IServiceProvider _provider;
        private IBus _bus;

        public RegistroClienteIntegrationHandler(IServiceProvider provider)
        {
            _provider = provider;
        }
        
        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _bus = RabbitHutch.CreateBus("host=localhost:5672");

            _bus.RespondAsync<UsuarioRegistradoIntegrationEvent, ResponseMessage>(async request =>
               new ResponseMessage(await RegistrarCliente(request))
           );

            return Task.CompletedTask;
        }

        private async Task<ValidationResult> RegistrarCliente(UsuarioRegistradoIntegrationEvent message)
        {
            var clienteCommand = new RegistrarClienteCommand(message.Id, message.Nome, message.Email, message.Cpf);
        }
    }
}
