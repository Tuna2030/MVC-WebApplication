using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using PortfolioWebPage.Models;

namespace PortfolioWebPage.Controllers
{
    public class AppointmentsController : Controller
    {
        private DoctorAppointmentModel db = new DoctorAppointmentModel();

        // GET: Appointments
        [Authorize]
        public ActionResult Index()
        {
            var UserID = User.Identity.GetUserId();
            var appointments = db.Appointments.Include(a => a.Doctor);
            var appointment = db.Appointments.Where(a => a.userID == UserID).ToList();
            if (UserID.Equals("3fb258ec-cf19-4c47-a4e0-15f67f93c866")) return View(appointments);
            else return View(appointment);
        }

        // GET: Appointments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Appointment appointment = db.Appointments.Find(id);
            if (appointment == null)
            {
                return HttpNotFound();
            }
            return View(appointment);
        }

        // GET: Appointments/Create
        public ActionResult Create()
        {
            var temp = new SelectList(db.Doctors, "id", "Fullname");
            ViewBag.doc_id = temp;

            var timetemp = new SelectList(
    new List<SelectListItem>
    {
        new SelectListItem { Selected = true, Text = "08:00", Value = "08:00"},
        new SelectListItem { Selected = false, Text = "08:30", Value = "08:30"},
        new SelectListItem { Selected = false, Text = "09:00", Value = "09:00"},
        new SelectListItem { Selected = false, Text = "09:30", Value = "09:30"},
        new SelectListItem { Selected = false, Text = "10:00", Value = "10:00"},
        new SelectListItem { Selected = false, Text = "10:30", Value = "10:30"},
        new SelectListItem { Selected = false, Text = "11:00", Value = "11:00"},
        new SelectListItem { Selected = false, Text = "11:30", Value = "11:30"},
        new SelectListItem { Selected = false, Text = "12:00", Value = "12:00"},
        new SelectListItem { Selected = false, Text = "12:30", Value = "12:30"},
        new SelectListItem { Selected = false, Text = "13:00", Value = "13:00"},
        new SelectListItem { Selected = false, Text = "13:30", Value = "13:30"},
        new SelectListItem { Selected = false, Text = "14:00", Value = "14:00"},
        new SelectListItem { Selected = false, Text = "14:30", Value = "14:30"},
        new SelectListItem { Selected = false, Text = "15:00", Value = "15:00"},
        new SelectListItem { Selected = false, Text = "15:30", Value = "15:30"},
        new SelectListItem { Selected = false, Text = "16:00", Value = "16:00"},
        new SelectListItem { Selected = false, Text = "16:30", Value = "16:30"},
    }, "Value", "Text", 1);

            ViewBag.time = timetemp;
            return View();
        }

        // POST: Appointments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create([Bind(Include = "id,doc_id,date,time")] Appointment appointment)
        {
            appointment.userID = User.Identity.GetUserId();
            ModelState.Clear();
            TryValidateModel(appointment);

            if (ModelState.IsValid)
            {
                db.Appointments.Add(appointment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.doc_id = new SelectList(db.Doctors, "id", "Fullname", appointment.doc_id);
            return View(appointment);
        }

        // GET: Appointments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Appointment appointment = db.Appointments.Find(id);
            if (appointment == null)
            {
                return HttpNotFound();
            }
            ViewBag.doc_id = new SelectList(db.Doctors, "id", "Fullname", appointment.doc_id);

            var timetemp = new SelectList(
    new List<SelectListItem>
    {
        new SelectListItem { Selected = true, Text = "08:00", Value = "08:00"},
        new SelectListItem { Selected = false, Text = "08:30", Value = "08:30"},
        new SelectListItem { Selected = false, Text = "09:00", Value = "09:00"},
        new SelectListItem { Selected = false, Text = "09:30", Value = "09:30"},
        new SelectListItem { Selected = false, Text = "10:00", Value = "10:00"},
        new SelectListItem { Selected = false, Text = "10:30", Value = "10:30"},
        new SelectListItem { Selected = false, Text = "11:00", Value = "11:00"},
        new SelectListItem { Selected = false, Text = "11:30", Value = "11:30"},
        new SelectListItem { Selected = false, Text = "12:00", Value = "12:00"},
        new SelectListItem { Selected = false, Text = "12:30", Value = "12:30"},
        new SelectListItem { Selected = false, Text = "13:00", Value = "13:00"},
        new SelectListItem { Selected = false, Text = "13:30", Value = "13:30"},
        new SelectListItem { Selected = false, Text = "14:00", Value = "14:00"},
        new SelectListItem { Selected = false, Text = "14:30", Value = "14:30"},
        new SelectListItem { Selected = false, Text = "15:00", Value = "15:00"},
        new SelectListItem { Selected = false, Text = "15:30", Value = "15:30"},
        new SelectListItem { Selected = false, Text = "16:00", Value = "16:00"},
        new SelectListItem { Selected = false, Text = "16:30", Value = "16:30"},
    }, "Value", "Text", 1);

            ViewBag.time = timetemp;

            return View(appointment);
        }

        // POST: Appointments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Edit([Bind(Include = "id,doc_id,date,time")] Appointment appointment)
        {
            appointment.userID = User.Identity.GetUserId();
            ModelState.Clear();
            TryValidateModel(appointment);

            if (ModelState.IsValid)
            {
                db.Entry(appointment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.doc_id = new SelectList(db.Doctors, "id", "first_name", appointment.doc_id);
            return View(appointment);
        }

        // GET: Appointments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Appointment appointment = db.Appointments.Find(id);
            if (appointment == null)
            {
                return HttpNotFound();
            }
            return View(appointment);
        }

        // POST: Appointments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Appointment appointment = db.Appointments.Find(id);
            db.Appointments.Remove(appointment);
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
