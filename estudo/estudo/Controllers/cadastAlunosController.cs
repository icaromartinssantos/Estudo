using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using estudo.Models;

namespace estudo.Controllers
{
    public class cadastAlunosController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: cadastAlunos
        public ActionResult Index()
        {
            return View(db.cadastAlunos.ToList());
        }

        // GET: cadastAlunos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cadastAlunos cadastAlunos = db.cadastAlunos.Find(id);
            if (cadastAlunos == null)
            {
                return HttpNotFound();
            }
            return View(cadastAlunos);
        }

        // GET: cadastAlunos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: cadastAlunos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,nome,dataNasc,RG,RA")] cadastAlunos cadastAlunos)
        {
            if (ModelState.IsValid)
            {
                db.cadastAlunos.Add(cadastAlunos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cadastAlunos);
        }

        // GET: cadastAlunos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cadastAlunos cadastAlunos = db.cadastAlunos.Find(id);
            if (cadastAlunos == null)
            {
                return HttpNotFound();
            }
            return View(cadastAlunos);
        }

        // POST: cadastAlunos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,nome,dataNasc,RG,RA")] cadastAlunos cadastAlunos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cadastAlunos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cadastAlunos);
        }

        // GET: cadastAlunos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cadastAlunos cadastAlunos = db.cadastAlunos.Find(id);
            if (cadastAlunos == null)
            {
                return HttpNotFound();
            }
            return View(cadastAlunos);
        }

        // POST: cadastAlunos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            cadastAlunos cadastAlunos = db.cadastAlunos.Find(id);
            db.cadastAlunos.Remove(cadastAlunos);
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
