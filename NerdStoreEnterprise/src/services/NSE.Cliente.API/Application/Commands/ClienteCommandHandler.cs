using FluentValidation.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace NSE.Cliente.API.Application.Commands
{
    // IRequestHandler<RegistrarClienteCommand, ValidationResult> -> é o manipulador daquele que implementa a interface IRequest
    public class ClienteCommandHandler : IRequestHandler<RegistrarClienteCommand, ValidationResult>
    {
        public async Task<ValidationResult> Handle(RegistrarClienteCommand message, CancellationToken cancellationToken)
        {
            if (!message.EhValido()) return message.ValidationResult;

            //var cliente = new Cliente(message.Id, message.Nome, message.Cpf, message.Email);

            return message.ValidationResult;
        }
    }
}
