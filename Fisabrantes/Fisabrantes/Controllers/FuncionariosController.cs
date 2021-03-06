﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Fisabrantes.Models;

namespace Fisabrantes.Controllers
{

    [Authorize] //impedir que pessoas não autenticadas, acedam aos recursos deste controller
    public class FuncionariosController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Funcionarios
        [AllowAnonymous]//permitir que, momentaneamente, qualquer pessoa visualize
        public ActionResult Index()
        {
            //se o utilizador for do tipo ADMINISTRATIVO ou do tipo TERAPEUTA
            if (User.IsInRole("Administrativo") || User.IsInRole("Terapeuta"))
            {
                return View(db.Funcionarios.ToList().OrderBy(dd => dd.Nome));
            }
            // se for do tipo MÉDICO
            return View(db.Funcionarios
              .Where(d => d.UserName == User.Identity.Name)
              .ToList());
        }

        // GET: Funcionarios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)//se o parâmetro ID não for fornecido
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //procura na BD os 'funcionários' cujo 'id' seja igual ao parâmetro fornecido
            Funcionarios funcionarios = db.Funcionarios.Find(id);

            //se o 'funcionário' do centro 'fisabrantes' não for encontrado,
            //redirecionamos para a listagem dos 'funcionários'
            if (funcionarios == null)
            {
                // redirecionamos para a listagem 'index' dos 'funcionários'
                return RedirectToAction("Index");
                //return HttpNotFound();
            }
            return View(funcionarios);
        }

        // GET: Funcionarios/Create
        [Authorize(Roles = "Administrativo")] //só os funcionários com esta ROLE podem criar outros funcionários
        public ActionResult Create()
        {
            return View();
        }

        // POST: Funcionarios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrativo")] //só os funcionários com esta ROLE podem criar outros funcionários
        public ActionResult Create([Bind(Include = "idFuncionario,Nome,DataNasc,Rua,NumPorta,Localidade,CodPostal,NIF,DataEntClinica,CatProfissional")] Funcionarios funcionarios)
        {
            if (ModelState.IsValid)
            {
                db.Funcionarios.Add(funcionarios);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(funcionarios);
        }

        // GET: Funcionarios/Edit/5
        [Authorize(Roles = "Administrativo")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Funcionarios funcionarios = db.Funcionarios.Find(id);
            if (funcionarios == null)
            {
                return RedirectToAction("Index"); //redirecionamos para a listagem 'index' dos 'funcionários'
                //return HttpNotFound();
            }
            return View(funcionarios);
        }

        // POST: Funcionarios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idFuncionario,Nome,DataNasc,Rua,NumPorta,Localidade,CodPostal,NIF,DataEntClinica,CatProfissional")] Funcionarios funcionarios)
        {
            if (ModelState.IsValid)
            {
                db.Entry(funcionarios).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(funcionarios);
        }

        // GET: Funcionarios/Delete/5
        [Authorize(Roles = "Administrativo")]
        public ActionResult Delete(int? id)
        {
            if (id == null) // se o parâmetro ID não for fornecido ... 
            {
                //return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                return RedirectToAction("Index"); //redirecionamos para a listagem 'index' dos 'funcionários'
            }
            Funcionarios funcionarios = db.Funcionarios.Find(id); //pesquisa funcionário associado ao ID
            if (funcionarios == null) //se o funcionário não for encontrado
            {
                //return HttpNotFound(); 
                return RedirectToAction("Index"); //redirecionamos para a listagem 'index' dos 'funcionários'
            }
            return View(funcionarios); // mostra a view com os dados do 'funcionário'
        }

        // POST: Funcionarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //procura na BD por um funcionário cujo 'IdFuncionário' seja igual ao parâmetro fornecido
            Funcionarios funcionarios = db.Funcionarios.Find(id);
            db.Funcionarios.Remove(funcionarios);// retira à BD o objeto identificado acima
            db.SaveChanges();// torna definitiva a alteração na BD
            return RedirectToAction("Index");// redireciona o controlo da ação para a view 'Index'
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}