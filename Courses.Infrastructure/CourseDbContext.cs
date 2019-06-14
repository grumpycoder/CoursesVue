using Courses.Core.Models;
using Courses.Infrastructure.Persistence.EntityConfigurations;
using System;
using System.Data.Entity;
using System.Diagnostics;

namespace Courses.Infrastructure
{
    public class CourseDbContext : DbContext
    {
        public CourseDbContext() : base("CourseContext")
        {
            Database.Log = msg => Debug.WriteLine(msg);
            Database.SetInitializer<CourseDbContext>(null);
            Configuration.LazyLoadingEnabled = false;
        }

        public static CourseDbContext Create()
        {
            return new CourseDbContext();
        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseView> CourseViews { get; set; }

        // Lookup References
        public DbSet<SchoolYear> SchoolYears { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<CourseType> CourseTypes { get; set; }
        public DbSet<CreditType> CreditTypes { get; set; }
        public DbSet<ClassType> ClassTypes { get; set; }
        public DbSet<SubjectArea> SubjectAreas { get; set; }
        public DbSet<Program> Programs { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
            modelBuilder.Properties<string>().Configure(c => c.HasColumnType("varchar").HasMaxLength(255));
            modelBuilder.Properties<string>();

            modelBuilder.Properties<DateTime>().Configure(c => c.HasColumnType("smalldatetime"));

            modelBuilder.Configurations.Add(new CourseConfiguration());
            modelBuilder.Configurations.Add(new CourseViewConfiguration());
            modelBuilder.Configurations.Add(new SchoolYearConfiguration());
            modelBuilder.Configurations.Add(new GradeConfiguration());
            modelBuilder.Configurations.Add(new CourseTypeConfiguration());
            modelBuilder.Configurations.Add(new CreditTypeConfiguration());
            modelBuilder.Configurations.Add(new ClassTypeConfiguration());
            modelBuilder.Configurations.Add(new DeliveryTypeConfiguration());
            modelBuilder.Configurations.Add(new SubjectAreaConfiguration());

            modelBuilder.Configurations.Add(new ClusterConfiguration());
            modelBuilder.Configurations.Add(new ProgramConfiguration());

            modelBuilder.Configurations.Add(new ProgramCourseConfiguration());
            //modelBuilder.Configurations.Add(new ProgramCredentialConfiguration());
            //modelBuilder.Configurations.Add(new CredentialConfiguration());
            //modelBuilder.Configurations.Add(new CredentialTypeConfiguration());



        }


    }
}
