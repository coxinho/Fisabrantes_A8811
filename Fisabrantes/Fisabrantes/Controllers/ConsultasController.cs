using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Fisabrantes.Models;

namespace Fisabrantes.Controllers
{
    [Authorize]
    public class ConsultasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Consultas
        [AllowAnonymous]
        public ActionResult Index()
        {
            var consultas = db.Consultas.Include(c => c.Fisiatra).Include(c => c.Utente);
            return View(db.Utentes.ToList());
        }
    

        // GET: Consultas/Details/5
        [Authorize(Roles = "Administrativo, Terapeuta, Medico")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Consultas consultas = db.Consultas.Find(id);
            if (consultas == null)
            {
                //redirecionamos para a listagem 'index' das 'consultas'
                return RedirectToAction("Index");
                //return HttpNotFound();
            }
            return View(consultas);
        }

        // GET: Consultas/Create
        [Authorize(Roles = "Administrativo")]
        public ActionResult Create()
        {
            ViewBag.FisiatraFK = new SelectList(db.Funcionarios, "idFuncionario", "Nome");
            ViewBag.UtenteFK = new SelectList(db.Utentes, "idUtente", "Nome");
            return View();
        }

        // POST: Consultas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrativo")]
        public ActionResult Create([Bind(Include = "idConsulta,DataConsulta,UtenteFK,FisiatraFK")] Consultas consultas)
        {
            if (ModelState.IsValid)
            {
                db.Consultas.Add(consultas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FisiatraFK = new SelectList(db.Funcionarios, "idFuncionario", "Nome", consultas.FisiatraFK);
            ViewBag.UtenteFK = new SelectList(db.Utentes, "idUtente", "Nome", consultas.UtenteFK);
            return View(consultas);
        }

        // GET: Consultas/Edit/5
        [Authorize(Roles = "Administrativo")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Consultas consultas = db.Consultas.Find(id);
            if (consultas == null)
            {
                //redirecionamos para a listagem 'index' das 'consultas'
                return RedirectToAction("Index");
                //return HttpNotFound();
            }
            ViewBag.FisiatraFK = new SelectList(db.Funcionarios, "idFuncionario", "Nome", consultas.FisiatraFK);
            ViewBag.UtenteFK = new SelectList(db.Utentes, "idUtente", "Nome", consultas.UtenteFK);
            return View(consultas);
        }

        // POST: Consultas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrativo")]
        public ActionResult Edit([Bind(Include = "idConsulta,DataConsulta,UtenteFK,FisiatraFK")] Consultas consultas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(consultas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FisiatraFK = new SelectList(db.Funcionarios, "idFuncionario", "Nome", consultas.FisiatraFK);
            ViewBag.UtenteFK = new SelectList(db.Utentes, "idUtente", "Nome", consultas.UtenteFK);
            return View(consultas);
        }

        // GET: Consultas/Delete/5
        [Authorize(Roles = "Administrativo")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Consultas consultas = db.Consultas.Find(id);
            if (consultas == null)
            {
                //redirecionamos para a listagem 'index' das 'consultas'
                return RedirectToAction("Index");
                //return HttpNotFound();
            }
            return View(consultas);
        }

        // POST: Consultas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrativo")]
        public ActionResult DeleteConfirmed(int id)
        {
            Consultas consultas = db.Consultas.Find(id);
            db.Consultas.Remove(consultas);
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
