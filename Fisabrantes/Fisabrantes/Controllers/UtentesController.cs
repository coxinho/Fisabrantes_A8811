using System;
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
    [Authorize]
    public class UtentesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Utentes
        [Authorize(Roles = "Administrativo, Terapeuta, Medico, Utente")]
        public ActionResult Index()
        {
            return View(db.Utentes.ToList());
        }

        // GET: Utentes/Details/5
        [Authorize(Roles = "Administrativo, Terapeuta, Medico")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Utentes utentes = db.Utentes.Find(id);
            if (utentes == null)
            {
                return HttpNotFound();
            }
            return View(utentes);
        }

        [Authorize(Roles = "Administrativo")]
        // GET: Utentes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Utentes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrativo")]
        public ActionResult Create([Bind(Include = "idUtente,Nome,DataNasc,NIF,Telefone,Morada,CodPostal,SNS")] Utentes utentes)
        {
            if (ModelState.IsValid)
            {
                db.Utentes.Add(utentes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(utentes);
        }

        // GET: Utentes/Edit/5
        [Authorize(Roles = "Administrativo")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Utentes utentes = db.Utentes.Find(id);
            if (utentes == null)
            {
                return HttpNotFound();
            }
            return View(utentes);
        }

        // POST: Utentes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrativo")]
        public ActionResult Edit([Bind(Include = "idUtente,Nome,DataNasc,NIF,Telefone,Morada,CodPostal,SNS")] Utentes utentes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(utentes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(utentes);
        }

        // GET: Utentes/Delete/5
        [Authorize(Roles = "Administrativo")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Utentes utentes = db.Utentes.Find(id);
            if (utentes == null)
            {
                return HttpNotFound();
            }
            return View(utentes);
        }

        // POST: Utentes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrativo")]
        public ActionResult DeleteConfirmed(int id)
        {
            Utentes utentes = db.Utentes.Find(id);
            db.Utentes.Remove(utentes);
            db.SaveChanges();
            return RedirectToAction("Index");
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
