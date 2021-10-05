using FluentValidation.Results;
using NSE.Core.Messages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NSE.Core.Mediator
{
    public class MediatorHandler : IMediatorHandler
    {
        public Task<ValidationResult> EnviarComando<T>(T comando) where T : Command
        {
            throw new NotImplementedException();
        }

        public Task PublicarEvento<T>(T evento) where T : Event
        {
            throw new NotImplementedException();
        }
    }
}
