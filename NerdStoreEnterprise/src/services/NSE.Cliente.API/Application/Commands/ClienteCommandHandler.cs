using FluentValidation.Results;
using MediatR;
using NSE.Core.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace NSE.Cliente.API.Application.Commands
{
    // IRequestHandler<RegistrarClienteCommand, ValidationResult> -> é o manipulador daquele que implementa a interface IRequest
    public class ClienteCommandHandler : CommandHandler, IRequestHandler<RegistrarClienteCommand, ValidationResult>
    {
        public async Task<ValidationResult> Handle(RegistrarClienteCommand message, CancellationToken cancellationToken)
        {
            if (!message.EhValido()) return message.ValidationResult;

            //var cliente = new Cliente(message.Id, message.Nome, message.Cpf, message.Email);

            // já existe o cpf no banco
            if (true)
            {
                AdicionarErro("Cpf já cadastrado.");
                return ValidationResult;
            }

            return message.ValidationResult;
        }
    }
}
