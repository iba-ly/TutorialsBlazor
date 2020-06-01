using System;
using System.Collections.Generic;
using System.Text;

namespace Tutorials.Kudvenkat.Models
{
    public class Employee
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime Birthday { get; set; }
        public Gender Gender { get; set; }
        public int DepartmentId { get; set; }
        //public Department Department { get; set; }
        public string Photo { get; set; }
    }

    public enum Gender
    {
        Male,
        Female,
        Other
    }

    public class Department
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
}
