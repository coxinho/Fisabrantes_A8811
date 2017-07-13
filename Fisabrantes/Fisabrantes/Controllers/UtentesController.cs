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
        [AllowAnonymous]
        public ActionResult Index()
        {
            //return View(db.Utentes.ToList());
            //se o utilizador for do tipo ADMINISTRATIVO, do tipo TERAPEUTA ou do tipo MÉDICO
            if (User.IsInRole("Administrativo") || User.IsInRole("Terapeuta") || User.IsInRole("Medico"))
            {
                return View(db.Utentes.ToList().OrderBy(dd => dd.Nome));
            }
            // se for do tipo UTENTE
            return View(db.Utentes
              .Where(d => d.UserName == User.Identity.Name)
              .ToList());
        }

        // GET: Utentes/Details/5
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
        public ActionResult Create([Bind(Include = "idUtente,Nome,DataNasc,NIF,Telefone,Morada,CodPostal,SNS,UserName")] Utentes utentes)
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
        public ActionResult Edit([Bind(Include = "idUtente,Nome,DataNasc,NIF,Telefone,Morada,CodPostal,SNS,UserName")] Utentes utentes)
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
