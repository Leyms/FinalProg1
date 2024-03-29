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
    public class CitasController : Controller
    {
        private ClassRegistContext db = new ClassRegistContext();

        // GET: Citas
        public ActionResult Index()
        {
            var citas = db.Citas.Include(c => c.Medicos).Include(c => c.Pacientes);
            return View(citas.ToList());
        }

        // GET: Citas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClassCitas classCitas = db.Citas.Find(id);
            if (classCitas == null)
            {
                return HttpNotFound();
            }
            return View(classCitas);
        }

        // GET: Citas/Create
        public ActionResult Create()
        {
            ViewBag.ID_Medico = new SelectList(db.Medicos, "ID_Medico", "Nombre_Medico");
            ViewBag.ID_Paciente = new SelectList(db.Pacientes, "ID_Paciente", "Nombre_Paciente");
            return View();
        }

        // POST: Citas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Citas,ID_Paciente,Fecha_Cita,Hora_cita,ID_Medico")] ClassCitas classCitas)
        {
            if (ModelState.IsValid)
            {
                db.Citas.Add(classCitas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_Medico = new SelectList(db.Medicos, "ID_Medico", "Nombre_Medico", classCitas.ID_Medico);
            ViewBag.ID_Paciente = new SelectList(db.Pacientes, "ID_Paciente", "Nombre_Paciente", classCitas.ID_Paciente);
            return View(classCitas);
        }

        // GET: Citas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClassCitas classCitas = db.Citas.Find(id);
            if (classCitas == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_Medico = new SelectList(db.Medicos, "ID_Medico", "Nombre_Medico", classCitas.ID_Medico);
            ViewBag.ID_Paciente = new SelectList(db.Pacientes, "ID_Paciente", "Nombre_Paciente", classCitas.ID_Paciente);
            return View(classCitas);
        }

        // POST: Citas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Citas,ID_Paciente,Fecha_Cita,Hora_cita,ID_Medico")] ClassCitas classCitas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(classCitas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_Medico = new SelectList(db.Medicos, "ID_Medico", "Nombre_Medico", classCitas.ID_Medico);
            ViewBag.ID_Paciente = new SelectList(db.Pacientes, "ID_Paciente", "Nombre_Paciente", classCitas.ID_Paciente);
            return View(classCitas);
        }

        // GET: Citas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClassCitas classCitas = db.Citas.Find(id);
            if (classCitas == null)
            {
                return HttpNotFound();
            }
            return View(classCitas);
        }

        // POST: Citas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ClassCitas classCitas = db.Citas.Find(id);
            db.Citas.Remove(classCitas);
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
