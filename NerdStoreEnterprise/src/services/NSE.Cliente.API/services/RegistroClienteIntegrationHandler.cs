using EasyNetQ;
using FluentValidation.Results;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NSE.Cliente.API.Application.Commands;
using NSE.Core.Mediator;
using NSE.Core.Messages.Integration;
using NSE.MessageBus;
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
        private IMessageBus _bus;

        public RegistroClienteIntegrationHandler(IServiceProvider provider, IMessageBus bus)
        {
            _provider = provider;
            _bus = bus;
        }
        
        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _bus.RespondAsync<UsuarioRegistradoIntegrationEvent, ResponseMessage>(async request =>
               new ResponseMessage(await RegistrarCliente(request))
           );

            return Task.CompletedTask;
        }

        private async Task<ValidationResult> RegistrarCliente(UsuarioRegistradoIntegrationEvent message)
        {
            var clienteCommand = new RegistrarClienteCommand(message.Id, message.Nome, message.Email, message.Cpf);
            ValidationResult sucesso;

            // criando um serviço do mediator dentro de um contexto singleton
            using (var scope = _provider.CreateScope())
            {
                var mediator = scope.ServiceProvider.GetRequiredService<IMediatorHandler>();
                sucesso = await mediator.EnviarComando(clienteCommand);
            }

            return sucesso;
        }
    }
}
