using NSE.WebApp.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NSE.WebApp.MVC.Services
{
    public class AutenticacaoService : IAutenticacaoService
    {
        public Task<string> Login(UsuarioLogin usuarioLogin)
        {
            throw new NotImplementedException();
        }

        public Task<string> Registro(UsuarioRegistro usuarioRegistro)
        {
            throw new NotImplementedException();
        }
    }
}
