using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Applicant_JOB_APP.Models;

namespace Applicant_JOB_APP.Controllers
{
   [Authorize]
    public class ApplicantsController : Controller
    {
        
        private Model2 db = new Model2();

        // GET: Applicants
        [Authorize(Users = "aziza99@gmail.com")]

        public ActionResult Index()
        {
            var applicant = db.Applicant.Include(a => a.Gender);
            return View(applicant.ToList());
        }

        // GET: Applicants/Details/5
        [Authorize(Users = "aziza99@gmail.com")]

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Applicant applicant = db.Applicant.Find(id);
            if (applicant == null)
            {
                return HttpNotFound();
            }
            return View(applicant);
        }

        // GET: Applicants/Create
        public ActionResult Create()
        {
            ViewBag.GenderId = new SelectList(db.Gender, "ID", "Name");
            return View();
        }

        // POST: Applicants/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,BirthDate,MobileNo,EMail,GenderId")] Applicant applicant)
        {
            if (ModelState.IsValid)
            {
                db.Applicant.Add(applicant);
                db.SaveChanges();
                return RedirectToAction("Index","Home");
            }

            ViewBag.GenderId = new SelectList(db.Gender, "ID", "Name", applicant.GenderId);
            return View(applicant);
        }

        // GET: Applicants/Edit/5

        [Authorize(Users = "aziza99@gmail.com")]

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Applicant applicant = db.Applicant.Find(id);
            if (applicant == null)
            {
                return HttpNotFound();
            }
            ViewBag.GenderId = new SelectList(db.Gender, "ID", "Name", applicant.GenderId);
            return View(applicant);
        }

        // POST: Applicants/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,BirthDate,MobileNo,EMail,GenderId")] Applicant applicant)
        {
            if (ModelState.IsValid)
            {
                db.Entry(applicant).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GenderId = new SelectList(db.Gender, "ID", "Name", applicant.GenderId);
            return View(applicant);
        }

        // GET: Applicants/Delete/5
        [Authorize(Users = "aziza99@gmail.com")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Applicant applicant = db.Applicant.Find(id);
            if (applicant == null)
            {
                return HttpNotFound();
            }
            return View(applicant);
        }

        // POST: Applicants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Applicant applicant = db.Applicant.Find(id);
            db.Applicant.Remove(applicant);
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
