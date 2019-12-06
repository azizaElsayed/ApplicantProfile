using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Applicant_JOB_APP.Models;
using Microsoft.AspNet.Identity;

namespace Applicant_JOB_APP.Controllers
{
    public class HomeController : Controller
    {
        private Model2 db = new Model2();

        [Authorize]
        public ActionResult Apply()
        {
            ViewBag.GenderId = new SelectList(db.Gender, "ID", "Name");

            return View();
        }

        public ActionResult Index()
        {
            ViewBag.GenderId = new SelectList(db.Gender, "ID", "Name");

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


        public ActionResult ProfileApplicant()
        {

          //  var userId = User.Identity.GetUserId();
           // var applicant = db.ApplicantQualification.Where(a => a.UserID == userId);

           // return View(applicant);

            return View();
        }

        public ActionResult viewAdmin()
        {
            return View();
        }





    }
}