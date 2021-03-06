﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Teste.Application.Interfaces;
using Teste.Application.Interfaces.Model;
using Teste.Application.Model;

namespace Teste.WebAPI.Controllers
{
    public class VeiculoController : Controller
    {
        private readonly IVeiculoApp _veiculoApp;

        public VeiculoController(IVeiculoApp veiculoApp)
        {
            _veiculoApp = veiculoApp;
        }

        // GET: VeiculoController
        public ActionResult Index()
        {
            return View();
        }

        // GET: VeiculoController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: VeiculoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VeiculoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(VeiculoDTO pessoaDto)
        {
            try
            {
                var retorno = _veiculoApp.Incluir(pessoaDto);

                return Ok(retorno);
            }
            catch
            {
                return View();
            }
        }

        // GET: VeiculoController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: VeiculoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: VeiculoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: VeiculoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
