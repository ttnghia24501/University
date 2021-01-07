namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Test")]
    public partial class Test
    {
        public int Id { get; set; }

        public int? StudentId { get; set; }

        public int? SubjectId { get; set; }

        public int Mark { get; set; }

        [Required]
        [StringLength(255)]
        public string Status { get; set; }

        public int? Attendance { get; set; }

        [StringLength(255)]
        public string Note { get; set; }

        public virtual Student Student { get; set; }

        public virtual Subject Subject { get; set; }
    }
}
