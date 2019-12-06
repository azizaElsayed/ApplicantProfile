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
    public class ApplicantApplicationsFieldsController : Controller
    {
        private Model2 db = new Model2();

        // GET: ApplicantApplicationsFields
        public ActionResult Index()
        {
            var applicantApplicationsField = db.ApplicantApplicationsField.Include(a => a.Applicant).Include(a => a.ApplicationsField);
            return View(applicantApplicationsField.ToList());
        }

        // GET: ApplicantApplicationsFields/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicantApplicationsField applicantApplicationsField = db.ApplicantApplicationsField.Find(id);
            if (applicantApplicationsField == null)
            {
                return HttpNotFound();
            }
            return View(applicantApplicationsField);
        }

        // GET: ApplicantApplicationsFields/Createth
        [Authorize]
        public ActionResult Create()
        {
            ViewBag.ApplicantId = new SelectList(db.Applicant, "ID", "Name");
            ViewBag.ApplicationsFieldId = new SelectList(db.ApplicationsField, "ID", "Name");
            return View();
        }

        // POST: ApplicantApplicationsFields/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ApplicantId,ApplicationsFieldId")] ApplicantApplicationsField applicantApplicationsField)
        {
            if (ModelState.IsValid)
            {
                db.ApplicantApplicationsField.Add(applicantApplicationsField);
                db.SaveChanges();
                return RedirectToAction("Index","Home");
            }

            ViewBag.ApplicantId = new SelectList(db.Applicant, "ID", "Name", applicantApplicationsField.ApplicantId);
            ViewBag.ApplicationsFieldId = new SelectList(db.ApplicationsField, "ID", "Name", applicantApplicationsField.ApplicationsFieldId);
            return View(applicantApplicationsField);
        }

        // GET: ApplicantApplicationsFields/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicantApplicationsField applicantApplicationsField = db.ApplicantApplicationsField.Find(id);
            if (applicantApplicationsField == null)
            {
                return HttpNotFound();
            }
            ViewBag.ApplicantId = new SelectList(db.Applicant, "ID", "Name", applicantApplicationsField.ApplicantId);
            ViewBag.ApplicationsFieldId = new SelectList(db.ApplicationsField, "ID", "Name", applicantApplicationsField.ApplicationsFieldId);
            return View(applicantApplicationsField);
        }

        // POST: ApplicantApplicationsFields/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ApplicantId,ApplicationsFieldId")] ApplicantApplicationsField applicantApplicationsField)
        {
            if (ModelState.IsValid)
            {
                db.Entry(applicantApplicationsField).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ApplicantId = new SelectList(db.Applicant, "ID", "Name", applicantApplicationsField.ApplicantId);
            ViewBag.ApplicationsFieldId = new SelectList(db.ApplicationsField, "ID", "Name", applicantApplicationsField.ApplicationsFieldId);
            return View(applicantApplicationsField);
        }

        // GET: ApplicantApplicationsFields/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicantApplicationsField applicantApplicationsField = db.ApplicantApplicationsField.Find(id);
            if (applicantApplicationsField == null)
            {
                return HttpNotFound();
            }
            return View(applicantApplicationsField);
        }

        // POST: ApplicantApplicationsFields/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ApplicantApplicationsField applicantApplicationsField = db.ApplicantApplicationsField.Find(id);
            db.ApplicantApplicationsField.Remove(applicantApplicationsField);
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
