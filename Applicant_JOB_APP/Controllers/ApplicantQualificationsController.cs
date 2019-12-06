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
    public class ApplicantQualificationsController : Controller
    {
        private Model2 db = new Model2();

        // GET: ApplicantQualifications
        public ActionResult Index()
        {
            var applicantQualification = db.ApplicantQualification.Include(a => a.Applicant).Include(a => a.CertificationSpecific).Include(a => a.CertificationType);
            return View(applicantQualification.ToList());
        }

        // GET: ApplicantQualifications/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicantQualification applicantQualification = db.ApplicantQualification.Find(id);
            if (applicantQualification == null)
            {
                return HttpNotFound();
            }
            return View(applicantQualification);
        }

        // GET: ApplicantQualifications/Create
        public ActionResult Create()
        {
            ViewBag.ApplicantId = new SelectList(db.Applicant, "ID", "Name");
            ViewBag.CertificationSpecificId = new SelectList(db.CertificationSpecific, "ID", "Name");
            ViewBag.CertificationTypeId = new SelectList(db.CertificationType, "ID", "Name");
            return View();
        }

        // POST: ApplicantQualifications/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ApplicantId,CertificationTypeId,CertificationSpecificId,Description")] ApplicantQualification applicantQualification)
        {
            if (ModelState.IsValid)
            {
                db.ApplicantQualification.Add(applicantQualification);
                db.SaveChanges();
                return RedirectToAction("Index","Home");
            }

            ViewBag.ApplicantId = new SelectList(db.Applicant, "ID", "Name", applicantQualification.ApplicantId);
            ViewBag.CertificationSpecificId = new SelectList(db.CertificationSpecific, "ID", "Name", applicantQualification.CertificationSpecificId);
            ViewBag.CertificationTypeId = new SelectList(db.CertificationType, "ID", "Name", applicantQualification.CertificationTypeId);
            return View(applicantQualification);
        }

        // GET: ApplicantQualifications/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicantQualification applicantQualification = db.ApplicantQualification.Find(id);
            if (applicantQualification == null)
            {
                return HttpNotFound();
            }
            ViewBag.ApplicantId = new SelectList(db.Applicant, "ID", "Name", applicantQualification.ApplicantId);
            ViewBag.CertificationSpecificId = new SelectList(db.CertificationSpecific, "ID", "Name", applicantQualification.CertificationSpecificId);
            ViewBag.CertificationTypeId = new SelectList(db.CertificationType, "ID", "Name", applicantQualification.CertificationTypeId);
            return View(applicantQualification);
        }

        // POST: ApplicantQualifications/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ApplicantId,CertificationTypeId,CertificationSpecificId,Description")] ApplicantQualification applicantQualification)
        {
            if (ModelState.IsValid)
            {
                db.Entry(applicantQualification).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ApplicantId = new SelectList(db.Applicant, "ID", "Name", applicantQualification.ApplicantId);
            ViewBag.CertificationSpecificId = new SelectList(db.CertificationSpecific, "ID", "Name", applicantQualification.CertificationSpecificId);
            ViewBag.CertificationTypeId = new SelectList(db.CertificationType, "ID", "Name", applicantQualification.CertificationTypeId);
            return View(applicantQualification);
        }

        // GET: ApplicantQualifications/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicantQualification applicantQualification = db.ApplicantQualification.Find(id);
            if (applicantQualification == null)
            {
                return HttpNotFound();
            }
            return View(applicantQualification);
        }

        // POST: ApplicantQualifications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ApplicantQualification applicantQualification = db.ApplicantQualification.Find(id);
            db.ApplicantQualification.Remove(applicantQualification);
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
