using Courses.Core.Models;
using Courses.Infrastructure.Persistence.EntityConfigurations;
using System;
using System.Data.Entity;
using System.Diagnostics;

namespace Courses.Infrastructure
{

    public class CareerTechDbContext : DbContext
    {
        public CareerTechDbContext() : base("CareerTechContext")
        {
            Database.Log = msg => Debug.WriteLine(msg);
            Database.SetInitializer<CareerTechDbContext>(null);
            Configuration.LazyLoadingEnabled = false;
        }

        public static CareerTechDbContext Create()
        {
            return new CareerTechDbContext();
        }

        public DbSet<Program> Programs { get; set; }
        public DbSet<Cluster> Clusters { get; set; }
        public DbSet<Credential> Credentials { get; set; }
        public DbSet<ProgramCourse> ProgramCourses { get; set; }

        public DbSet<ProgramCredential> ProgramCredentials { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
            modelBuilder.Properties<string>().Configure(c => c.HasColumnType("varchar").HasMaxLength(255));
            modelBuilder.Properties<string>();

            modelBuilder.Properties<DateTime>().Configure(c => c.HasColumnType("smalldatetime"));

            modelBuilder.Configurations.Add(new CourseConfiguration());
            modelBuilder.Configurations.Add(new ProgramConfiguration());
            modelBuilder.Configurations.Add(new ClusterTypeConfiguration());
            modelBuilder.Configurations.Add(new ClusterConfiguration());
            modelBuilder.Configurations.Add(new ProgramTypeConfiguration());
            modelBuilder.Configurations.Add(new ProgramCourseConfiguration());
            modelBuilder.Configurations.Add(new CredentialConfiguration());
            modelBuilder.Configurations.Add(new CredentialTypeConfiguration());
            modelBuilder.Configurations.Add(new ProgramCredentialConfiguration());
            
            modelBuilder.Configurations.Add(new GradeConfiguration());
            modelBuilder.Configurations.Add(new CourseTypeConfiguration());
            modelBuilder.Configurations.Add(new CreditTypeConfiguration());
            modelBuilder.Configurations.Add(new ClassTypeConfiguration());
            modelBuilder.Configurations.Add(new DeliveryTypeConfiguration());
            modelBuilder.Configurations.Add(new SubjectAreaConfiguration());
        }
    }
}
