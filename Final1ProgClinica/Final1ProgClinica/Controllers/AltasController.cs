using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Final1ProgClinica.Models;

namespace Final1ProgClinica.Controllers
{
    public class AltasController : Controller
    {
        private ClassRegistContext db = new ClassRegistContext();

        // GET: Altas
        public ActionResult Index()
        {
            var altas = db.Altas.Include(c => c.Ingresos);
            return View(altas.ToList());
        }

        // GET: Altas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClassAltas classAltas = db.Altas.Find(id);
            if (classAltas == null)
            {
                return HttpNotFound();
            }
            return View(classAltas);
        }

        // GET: Altas/Create
        public ActionResult Create()
        {
            ViewBag.ID_Ingresos = new SelectList(db.Ingresos, "ID_Ingresos", "ID_Ingresos");
            return View();
        }

        // POST: Altas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Altas,ID_Ingresos,Monto_Pagar,ID_Paciente,ID_Habitacion,Fecha_Ingreso")] ClassAltas classAltas)
        {
            if (ModelState.IsValid)
            {
                db.Altas.Add(classAltas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_Ingresos = new SelectList(db.Ingresos, "ID_Ingresos", "Fecha_Ingreso", classAltas.ID_Ingresos);
            return View(classAltas);
        }

        // GET: Altas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClassAltas classAltas = db.Altas.Find(id);
            if (classAltas == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_Ingresos = new SelectList(db.Ingresos, "ID_Ingresos", "Fecha_Ingreso", classAltas.ID_Ingresos);
            return View(classAltas);
        }

        // POST: Altas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Altas,ID_Ingresos,Monto_Pagar,ID_Paciente,ID_Habitacion,Fecha_Ingreso")] ClassAltas classAltas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(classAltas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_Ingresos = new SelectList(db.Ingresos, "ID_Ingresos", "Fecha_Ingreso", classAltas.ID_Ingresos);
            return View(classAltas);
        }

        // GET: Altas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClassAltas classAltas = db.Altas.Find(id);
            if (classAltas == null)
            {
                return HttpNotFound();
            }
            return View(classAltas);
        }

        // POST: Altas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ClassAltas classAltas = db.Altas.Find(id);
            db.Altas.Remove(classAltas);
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
