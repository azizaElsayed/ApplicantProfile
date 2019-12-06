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
    public class CertificationSpecificsController : Controller
    {
        private Model2 db = new Model2();

        // GET: CertificationSpecifics
        public ActionResult Index()
        {
            var certificationSpecific = db.CertificationSpecific.Include(c => c.CertificationType);
            return View(certificationSpecific.ToList());
        }

        // GET: CertificationSpecifics/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CertificationSpecific certificationSpecific = db.CertificationSpecific.Find(id);
            if (certificationSpecific == null)
            {
                return HttpNotFound();
            }
            return View(certificationSpecific);
        }

        // GET: CertificationSpecifics/Create
        public ActionResult Create()
        {
            ViewBag.CertificationTypeID = new SelectList(db.CertificationType, "ID", "Name");
            return View();
        }

        // POST: CertificationSpecifics/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,CertificationTypeID")] CertificationSpecific certificationSpecific)
        {
            if (ModelState.IsValid)
            {
                db.CertificationSpecific.Add(certificationSpecific);
                db.SaveChanges();
                return RedirectToAction("Index","Home");
            }

            ViewBag.CertificationTypeID = new SelectList(db.CertificationType, "ID", "Name", certificationSpecific.CertificationTypeID);
            return View(certificationSpecific);
        }

        // GET: CertificationSpecifics/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CertificationSpecific certificationSpecific = db.CertificationSpecific.Find(id);
            if (certificationSpecific == null)
            {
                return HttpNotFound();
            }
            ViewBag.CertificationTypeID = new SelectList(db.CertificationType, "ID", "Name", certificationSpecific.CertificationTypeID);
            return View(certificationSpecific);
        }

        // POST: CertificationSpecifics/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,CertificationTypeID")] CertificationSpecific certificationSpecific)
        {
            if (ModelState.IsValid)
            {
                db.Entry(certificationSpecific).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CertificationTypeID = new SelectList(db.CertificationType, "ID", "Name", certificationSpecific.CertificationTypeID);
            return View(certificationSpecific);
        }

        // GET: CertificationSpecifics/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CertificationSpecific certificationSpecific = db.CertificationSpecific.Find(id);
            if (certificationSpecific == null)
            {
                return HttpNotFound();
            }
            return View(certificationSpecific);
        }

        // POST: CertificationSpecifics/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CertificationSpecific certificationSpecific = db.CertificationSpecific.Find(id);
            db.CertificationSpecific.Remove(certificationSpecific);
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
