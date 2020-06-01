using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tutorials.Kudvenkat.Models;

namespace Tutorial.Kudvenkad.Api.Contexts
{
    public class EmployeeDbContext : DbContext 
    {
        public EmployeeDbContext (DbContextOptions<EmployeeDbContext> options) : base(options)
        {}
        public DbSet<Employee> Employees{ get; set; }
        public DbSet<Department> Departments{ get; set; }
        protected override void OnModelCreating ( ModelBuilder modelBuilder )
        {

            modelBuilder.Entity<Department>().HasData(
                new Department() { ID = 1, Name = "IT" },
                new Department() { ID = 2, Name = "HR" },
                new Department() { ID = 3, Name = "Payroll" },
                new Department() { ID = 4, Name = "Admin" }
            );

            modelBuilder.Entity<Employee>().HasData(
                new Employee()
                {
                    ID = 1,
                    FirstName = "Islam",
                    LastName = "Alshiki",
                    Birthday = new DateTime( 1994, 07, 28 ),
                    DepartmentId = 1,
                    Email = "eslam.alhiki94@gmail.com",
                    Gender = Gender.Male,
                    Photo = "image.jpg",
                },
                new Employee()
                {
                    ID = 2,
                    FirstName = "Abdulrahman",
                    LastName = "Alfaydi",
                    Birthday = new DateTime( 1994, 05, 1 ),
                    DepartmentId = 1,
                    Email = "Abdulrahman.Alfaydi@gmail.com",
                    Gender = Gender.Male,
                    Photo = "image.jpg",
                },
                new Employee()
                {
                    ID = 3,
                    FirstName = "Ali",
                    LastName = "Alawami",
                    Birthday = new DateTime( 1991, 08, 1 ),
                    DepartmentId = 2,
                    Email = "Ali.Alawami@gmail.com",
                    Gender = Gender.Male,
                    Photo = "image.jpg",
                }
            );

            base.OnModelCreating( modelBuilder );
        }
    }
}
