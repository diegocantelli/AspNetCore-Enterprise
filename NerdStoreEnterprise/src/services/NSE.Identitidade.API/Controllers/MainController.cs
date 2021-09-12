using Microsoft.AspNetCore.Mvc;
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
