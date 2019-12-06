namespace Applicant_JOB_APP.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ApplicantApplicationsField")]
    public partial class ApplicantApplicationsField
    {
        public int ID { get; set; }

        public int? ApplicantId { get; set; }

        public int? ApplicationsFieldId { get; set; }

        public virtual Applicant Applicant { get; set; }

        public virtual ApplicationsField ApplicationsField { get; set; }
    }
}
