﻿using System;
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
    public class IngresosController : Controller
    {
        private ClassRegistContext db = new ClassRegistContext();

        // GET: Ingresos
        public ActionResult Index()
        {
            var ingresos = db.Ingresos.Include(c => c.Habitaciones).Include(c => c.Pacientes);
            return View(ingresos.ToList());
        }

        // GET: Ingresos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClassIngresos classIngresos = db.Ingresos.Find(id);
            if (classIngresos == null)
            {
                return HttpNotFound();
            }
            return View(classIngresos);
        }

        // GET: Ingresos/Create
        public ActionResult Create()
        {
            ViewBag.ID_Habitacion = new SelectList(db.Habitaciones, "ID_Habitacion", "Num_Habitacion");
            ViewBag.ID_Paciente = new SelectList(db.Pacientes, "ID_Paciente", "Nombre_Paciente");
            return View();
        }

        // POST: Ingresos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Ingresos,ID_Habitacion,ID_Paciente,Fecha_Ingreso")] ClassIngresos classIngresos)
        {
            if (ModelState.IsValid)
            {
                db.Ingresos.Add(classIngresos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_Habitacion = new SelectList(db.Habitaciones, "ID_Habitacion", "Num_Habitacion", classIngresos.ID_Habitacion);
            ViewBag.ID_Paciente = new SelectList(db.Pacientes, "ID_Paciente", "Nombre_Paciente", classIngresos.ID_Paciente);
            return View(classIngresos);
        }

        // GET: Ingresos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClassIngresos classIngresos = db.Ingresos.Find(id);
            if (classIngresos == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_Habitacion = new SelectList(db.Habitaciones, "ID_Habitacion", "Num_Habitacion", classIngresos.ID_Habitacion);
            ViewBag.ID_Paciente = new SelectList(db.Pacientes, "ID_Paciente", "Nombre_Paciente", classIngresos.ID_Paciente);
            return View(classIngresos);
        }

        // POST: Ingresos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Ingresos,ID_Habitacion,ID_Paciente,Fecha_Ingreso")] ClassIngresos classIngresos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(classIngresos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_Habitacion = new SelectList(db.Habitaciones, "ID_Habitacion", "Num_Habitacion", classIngresos.ID_Habitacion);
            ViewBag.ID_Paciente = new SelectList(db.Pacientes, "ID_Paciente", "Nombre_Paciente", classIngresos.ID_Paciente);
            return View(classIngresos);
        }

        // GET: Ingresos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClassIngresos classIngresos = db.Ingresos.Find(id);
            if (classIngresos == null)
            {
                return HttpNotFound();
            }
            return View(classIngresos);
        }

        // POST: Ingresos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ClassIngresos classIngresos = db.Ingresos.Find(id);
            db.Ingresos.Remove(classIngresos);
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
