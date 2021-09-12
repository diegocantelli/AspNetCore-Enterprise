using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NSE.Identitidade.API.Controllers
{
    [ApiController]
    public abstract class MainController : Controller
    {
        protected ICollection<string> Erros = new List<string>();
        
        protected ActionResult CustomResponse(object result = null)
        {
            if (OperacaoValida()) return Ok(result);

            // ValidationProblemDetails -> é um padrão de como a api deve responder aos erros
            return BadRequest(new ValidationProblemDetails(new Dictionary<string, string[]> 
            {
                {"Mensagens", Erros.ToArray() }
            }));
        }

        protected ActionResult CustomResponse(ModelStateDictionary modelState)
        {
            var erros = modelState.Values.SelectMany(e => e.Errors);

            foreach (var erro in erros)
            {
                AdicionarErrosProcessamento(erro.ErrorMessage)
            }

            return CustomResponse();
        }

        protected bool OperacaoValida()
        {
            return Erros.Any();
        }

        protected void AdicionarErrosProcessamento(string erro)
        {
            Erros.Add(erro);
        }

        protected void LimparErrosProcessamento() => Erros.Clear();
    }
}
