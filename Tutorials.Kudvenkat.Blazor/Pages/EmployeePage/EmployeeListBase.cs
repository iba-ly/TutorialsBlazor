using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tutorials.Kudvenkat.Models;

namespace Tutorials.Kudvenkat.Blazor.Pages.EmployeePage
{
    public class EmployeeListBase : ComponentBase
    {
        public IEnumerable<Employee> Employees { get; set; }

        protected override async Task OnInitializedAsync ()
        {
            await Task.Delay(3 * 1000);
            await Task.Run( () => { 
                Load();
            } );
        }

        private void Load ()
        {
            var d1 = new Department(){ 
                ID = 9,
                Name = "IT"
            };
            var d2 = new Department()
            {
                ID = 2,
                Name = "HR"
            };
            var e1 = new Employee()
            {
                ID = 1,
                FirstName = "Islam",
                LastName = "Alshiki",
                Birthday = new DateTime(1994, 07, 28),
                DepartmentId = 1,
                Email = "eslam.alhiki94@gmail.com",
                Gender = Gender.Male,
                Photo = "image.jpg",
            };
            var e2 = new Employee()
            {
                ID = 1,
                FirstName = "Abdulrahman",
                LastName = "Alfaydi",
                Birthday = new DateTime(1994, 05, 1),
                DepartmentId = 1,
                Email = "Abdulrahman.Alfaydi@gmail.com",
                Gender = Gender.Male,
                Photo = "image.jpg",
            };
            var e3 = new Employee()
            {
                ID = 1,
                FirstName = "Ali",
                LastName = "Alawami",
                Birthday = new DateTime(1991, 08, 1),
                DepartmentId = 2,
                Email = "Ali.Alawami@gmail.com",
                Gender = Gender.Male,
                Photo = "image.jpg",
            };
            Employees = new List<Employee>() { e1, e2, e3 };
        }

    }
}
