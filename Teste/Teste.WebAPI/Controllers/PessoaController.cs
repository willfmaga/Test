using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Teste.Application.Interfaces;
using Teste.Application.Interfaces.Model;
using Teste.Infra.CrossCutting.CustomError;

namespace Teste.WebAPI.Controllers
{
    public class PessoaController : Controller
    {
        private readonly IPessoaApp pessoaApp;

        public PessoaController(IPessoaApp pessoaApp)
        {
            this.pessoaApp = pessoaApp;
        }
        // GET: Pessoa
        public ActionResult Index()
        {
            return View();
        }

        // GET: Pessoa/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Pessoa/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pessoa/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PessoaDTO pessoaDTO)
        {
            try
            {
                pessoaApp.Incluir(pessoaDTO);

                return RedirectToAction("create");
            }
            catch (RepomVaiDeVisaException err)
            {
                
                return View();
            }
        }

        // GET: Pessoa/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Pessoa/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Pessoa/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Pessoa/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}