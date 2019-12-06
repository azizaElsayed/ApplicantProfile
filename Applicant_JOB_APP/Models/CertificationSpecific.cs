namespace Applicant_JOB_APP.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CertificationSpecific")]
    public partial class CertificationSpecific
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CertificationSpecific()
        {
            ApplicantQualification = new HashSet<ApplicantQualification>();
        }

        public int ID { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        public int? CertificationTypeID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ApplicantQualification> ApplicantQualification { get; set; }

        public virtual CertificationType CertificationType { get; set; }
    }
}
