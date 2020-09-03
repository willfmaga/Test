using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Teste.Application.Interfaces;
using Teste.Application.Interfaces.Model;
using Teste.Infra.CrossCutting.CustomError;
using Teste.WebAPI.Models;

namespace Teste.WebAPI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IPessoaApp pessoaApp;

        public HomeController(ILogger<HomeController> logger, IPessoaApp pessoaApp)
        {
            this.pessoaApp = pessoaApp;
            _logger = logger;
        }

        public IActionResult Index()
        {
            pessoaApp.Incluir(new PessoaDTO() { Nome = "Julio", Sobrenome = "Trevizan" });


            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            // return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            return View(new ErrorViewModel(Guid.NewGuid().ToString(), new List<MensagemErro>() { }));
        }
    }
}
