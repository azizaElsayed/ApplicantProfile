namespace Applicant_JOB_APP.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ApplicantQualification")]
    public partial class ApplicantQualification
    {
        public int ID { get; set; }

        public int? ApplicantId { get; set; }

        public int? CertificationTypeId { get; set; }

        public int? CertificationSpecificId { get; set; }

        public string Description { get; set; }

        public virtual Applicant Applicant { get; set; }

        public virtual CertificationSpecific CertificationSpecific { get; set; }

        public virtual CertificationType CertificationType { get; set; }
        
    }
}
