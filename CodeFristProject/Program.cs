using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFristProject
{
    class Program
    {
        public class SchoolContext : DbContext
        {
            public SchoolContext() : base("name=SchoolDBConnectionString") 
            {
            
            }

            public DbSet<Student> Students { get; set; }
            public DbSet<Standard> Standards { get; set; }
            protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
                modelBuilder.Entity<Student>().Map(m =>
                {
                    m.Properties(p => new { p.StudentID, p.StudentName });
                    m.ToTable("StudentInfo");

                }).Map(m => {
                    m.Properties(p => new { p.StudentID, p.Height, p.Weight, p.Photo, p.DateOfBirth });
                    m.ToTable("StudentInfoDetail");

                });

                modelBuilder.Entity<Standard>().ToTable("StandardInfo");

            }

        }
        static void Main(string[] args)
        {
           // var ctx = new SchoolContext();
            using (var ctx = new SchoolContext())
            {
                Student stud = new Student() { StudentName = "New Student" };

                ctx.Students.Add(stud);
                ctx.SaveChanges();
            }
        }
    }
}
