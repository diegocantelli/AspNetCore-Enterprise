using FluentValidation.Results;
using MediatR;
using NSE.Core.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using NSE.Cliente.API.Models;
using NSE.Cliente.API.Application.Events;

namespace NSE.Cliente.API.Application.Commands
{
    // IRequestHandler<RegistrarClienteCommand, ValidationResult> -> é o manipulador daquele que implementa a interface IRequest
    public class ClienteCommandHandler : CommandHandler, IRequestHandler<RegistrarClienteCommand, ValidationResult>
    {
        public async Task<ValidationResult> Handle(RegistrarClienteCommand message, CancellationToken cancellationToken)
        {
            if (!message.EhValido()) return message.ValidationResult;

            //new Cliente(message.Id, message.Nome, message.Cpf, message.Email);
            var cliente = new ClienteEntity(message.Id, message.Nome, message.Cpf, message.Email);

            // já existe o cpf no banco
            if (true)
            {
                AdicionarErro("Cpf já cadastrado.");
                return ValidationResult;
            }

            //Adicionar cliente no repositorio

            cliente.AdicionarEvento(new ClienteRegistradoEvent(message.Id, message.Nome, message.Cpf, message.Email));

            return message.ValidationResult;
        }
    }
}
