using Microsoft.AspNetCore.Mvc;
using NSE.WebApi.Core.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NSE.Cliente.API.Controllers
{
    public class ClienteController : MainController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
