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
    [Authorize(Roles ="Medico, Terapeuta")]
    public class PrescricoesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Prescricoes
        public ActionResult Index()
        {
            var prescricao = db.Prescricao.Include(p => p.Consulta);
            return View(prescricao.ToList());
        }

        // GET: Prescricoes/Details/5
        [Authorize(Roles = "Medico")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prescricoes prescricoes = db.Prescricao.Find(id);
            if (prescricoes == null)
            {
                //redirecionamos para a listagem 'index' das 'prescrições'
                return RedirectToAction("Index");
                //return HttpNotFound();
            }
            return View(prescricoes);
        }

        // GET: Prescricoes/Create
        [Authorize(Roles = "Medico")]
        public ActionResult Create()
        {
            ViewBag.ConsultaFK = new SelectList(db.Consultas, "idConsulta", "idConsulta");
            return View();
        }

        // POST: Prescricoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Medico")]
        public ActionResult Create([Bind(Include = "idPrescricao,Descricao,ConsultaFK")] Prescricoes prescricoes)
        {
            if (ModelState.IsValid)
            {
                db.Prescricao.Add(prescricoes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ConsultaFK = new SelectList(db.Consultas, "idConsulta", "idConsulta", prescricoes.ConsultaFK);
            return View(prescricoes);
        }

        // GET: Prescricoes/Edit/5
        [Authorize(Roles = "Medico")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prescricoes prescricoes = db.Prescricao.Find(id);
            if (prescricoes == null)
            {
                //redirecionamos para a listagem 'index' das 'prescrições'
                return RedirectToAction("Index");
                //return HttpNotFound();
            }
            ViewBag.ConsultaFK = new SelectList(db.Consultas, "idConsulta", "idConsulta", prescricoes.ConsultaFK);
            return View(prescricoes);
        }

        // POST: Prescricoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Medico")]
        public ActionResult Edit([Bind(Include = "idPrescricao,Descricao,ConsultaFK")] Prescricoes prescricoes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(prescricoes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ConsultaFK = new SelectList(db.Consultas, "idConsulta", "idConsulta", prescricoes.ConsultaFK);
            return View(prescricoes);
        }

        // GET: Prescricoes/Delete/5
        [Authorize(Roles = "Medico")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prescricoes prescricoes = db.Prescricao.Find(id);
            if (prescricoes == null)
            {
                //redirecionamos para a listagem 'index' das 'prescrições'
                return RedirectToAction("Index");
                //return HttpNotFound();
            }
            return View(prescricoes);
        }

        // POST: Prescricoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Medico")]
        public ActionResult DeleteConfirmed(int id)
        {
            Prescricoes prescricoes = db.Prescricao.Find(id);
            db.Prescricao.Remove(prescricoes);
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
