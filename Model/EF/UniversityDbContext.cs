namespace Model.EF
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class UniversityDbContext : DbContext
    {
        public UniversityDbContext()
            : base("name=University")
        {
        }

        public virtual DbSet<Class> Classes { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Manager> Managers { get; set; }
        public virtual DbSet<Schedule> Schedules { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Subject> Subjects { get; set; }
        public virtual DbSet<Teacher> Teachers { get; set; }
        public virtual DbSet<Test> Tests { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Class>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Department>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Manager>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Manager>()
                .Property(e => e.Image)
                .IsUnicode(false);

            modelBuilder.Entity<Manager>()
                .Property(e => e.Email)
                .IsFixedLength();

            modelBuilder.Entity<Manager>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<Student>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Student>()
                .Property(e => e.Image)
                .IsUnicode(false);

            modelBuilder.Entity<Student>()
                .Property(e => e.FatherName)
                .IsUnicode(false);

            modelBuilder.Entity<Student>()
                .Property(e => e.MotherName)
                .IsUnicode(false);

            modelBuilder.Entity<Student>()
                .Property(e => e.Gender)
                .IsUnicode(false);

            modelBuilder.Entity<Student>()
                .Property(e => e.ResidentialAddress)
                .IsUnicode(false);

            modelBuilder.Entity<Student>()
                .Property(e => e.PermanentAddress)
                .IsUnicode(false);

            modelBuilder.Entity<Student>()
                .Property(e => e.SportDetails)
                .IsUnicode(false);

            modelBuilder.Entity<Student>()
                .Property(e => e.Status)
                .IsUnicode(false);

            modelBuilder.Entity<Student>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<Subject>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Subject>()
                .Property(e => e.Status)
                .IsUnicode(false);

            modelBuilder.Entity<Teacher>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Teacher>()
                .Property(e => e.Image)
                .IsUnicode(false);

            modelBuilder.Entity<Teacher>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Teacher>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<Test>()
                .Property(e => e.Status)
                .IsUnicode(false);

            modelBuilder.Entity<Test>()
                .Property(e => e.Note)
                .IsUnicode(false);
        }
    }
}
