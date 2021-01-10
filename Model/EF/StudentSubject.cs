namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("StudentSubject")]
    public partial class StudentSubject
    {
        public int ID { get; set; }

        [StringLength(250)]
        public string StudentName { get; set; }

        [StringLength(250)]
        public string StudentEmail { get; set; }

        public int? Department { get; set; }

        public int? Class { get; set; }

        public int? Subject { get; set; }

        public virtual Class Class1 { get; set; }

        public virtual Department Department1 { get; set; }

        public virtual Subject Subject1 { get; set; }
    }
}
