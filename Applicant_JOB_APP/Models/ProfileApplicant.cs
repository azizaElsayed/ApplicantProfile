using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Applicant_JOB_APP.Models
{
	public class ProfileApplicant
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int QualID { get; set; }
        public virtual ApplicationUser User { get; set; }
        public virtual ApplicantQualification qual { get; set; }










    }
}