using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NSE.Identitidade.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NSE.Identitidade.API.Controllers
{
    public class AuthController : Controller
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;

        public AuthController(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }
        public async Task<IActionResult> Registrar(UsuarioRegistro usuarioRegistro)
        {
            if (!ModelState.IsValid) return BadRequest();

            var user = new IdentityUser
            {
                UserName = usuarioRegistro.Email,
                Email = usuarioRegistro.Email,
                EmailConfirmed = true
            };

            // criando um usuário através do Identity
            var result = await _userManager.CreateAsync(user, usuarioRegistro.Senha);

            if (result.Succeeded)
            {
                // Em caso de usuário criado com sucesso, já faz o login do mesmo no sistema
                await _signInManager.SignInAsync(user, isPersistent: false);
                return Ok();
            }

            return BadRequest();
        }

        public async Task<IActionResult> Login(Usuariologin usuariologin)
        {

        }


    }
}
