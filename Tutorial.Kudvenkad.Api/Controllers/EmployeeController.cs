using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Tutorial.Kudvenkad.Api.Repositries.EmployeeRepo;
using Microsoft.AspNetCore.Http;
using Tutorials.Kudvenkat.Models;
using Tutorial.Kudvenkad.Api.Custom.Controller;

namespace Tutorial.Kudvenkad.Api.Controllers
{
    [ApiController]
    public class EmployeeController : CustomControllerBase
    {
        private readonly IEmployeeRepositry employeeRepositry;

        public EmployeeController (IEmployeeRepositry employeeRepositry)
        {
            this.employeeRepositry = employeeRepositry;
        }

        [HttpGet]
        public async Task<ActionResult> GetEmployees ()
        {
            try
            {
                return Ok( await employeeRepositry.GetAll() );
            }
            catch ( Exception )
            {
                return StatusCode( StatusCodes.Status500InternalServerError, "Error" );
            }        
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Employee>> GetEmployee (int id)
        {
            try
            {
                var res = await employeeRepositry.Get(id);

                if(res == null )
                {
                    return NotFound();
                }
                return res;
            }
            catch ( Exception )
            {
                return StatusCode( StatusCodes.Status500InternalServerError, "Error" );
            }
        }

        [HttpPost ]
        public async Task<ActionResult<Employee>> CreareEmployee ( Employee employee )
        {
            try
            {

                if ( employee == null )
                {
                    return BadRequest();
                }

                var isEx = employeeRepositry.GetEmployeeByEmail(employee.Email);
                if( isEx != null )
                {
                    ModelState.AddModelError( nameof( employee.Email ), "Ex" );
                    return BadRequest(ModelState);
                }
                var res = await employeeRepositry.Add(employee);
                

                return CreatedAtAction( nameof( GetEmployee ), new { id = employee.ID }, employee );
            }
            catch ( Exception )
            {
                return StatusCode( StatusCodes.Status500InternalServerError, "Error" );
            }
        }

        [HttpPut]
        public async Task<ActionResult<Employee>> UpdateEmployee ( Employee employee )
        {
            try
            {
                var res = await employeeRepositry.Update(employee.ID, employee);

                if ( res == null )
                {
                    return NotFound();
                }
                return AcceptedAtAction( nameof( GetEmployee ), new { id = employee.ID }, employee );
            }
            catch ( Exception )
            {
                return StatusCode( StatusCodes.Status500InternalServerError, "Error" );
            }
        }

    }
}