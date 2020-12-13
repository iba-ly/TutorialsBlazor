using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Tutorials.Kudvenkat.Localizations.ModelsErrors;

namespace Tutorials.Kudvenkat.Models
{
    public class Employee
    {
        public int ID { get; set; }
        [Required(ErrorMessageResourceType = typeof(ModelError), ErrorMessageResourceName = "Required" )]
        [MinLength( 3, ErrorMessageResourceType = typeof( ModelError ) , ErrorMessageResourceName = "Min" )]
        public string FirstName { get; set; }

        [Required(ErrorMessageResourceType = typeof(ModelError), ErrorMessageResourceName = "Required" )]
        public string LastName { get; set; }

        [Required(ErrorMessageResourceType = typeof(ModelError), ErrorMessageResourceName = "Required" )]
        [EmailAddress(ErrorMessageResourceType = typeof(ModelError), ErrorMessageResourceName = "EmailAddress" )]
        public string Email { get; set; }

        [Required(ErrorMessageResourceType = typeof(ModelError), ErrorMessageResourceName = "Required" )]
        public DateTime Birthday { get; set; }

        [Required(ErrorMessageResourceType = typeof(ModelError), ErrorMessageResourceName = "Required" )]
        public Gender Gender { get; set; }

        [Required(ErrorMessageResourceType = typeof(ModelError), ErrorMessageResourceName = "Required" )]
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

        [Required( ErrorMessageResourceType = typeof( ModelError ), ErrorMessageResourceName = "Required" )]
        public string Name { get; set; }
    }
}
