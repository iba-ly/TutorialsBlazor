using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tutorial.Kudvenkad.Api.Custom.Controller;
using Tutorial.Kudvenkad.Api.Repositries.DepartmentRepo;
using Tutorials.Kudvenkat.Models;

namespace Tutorial.Kudvenkad.Api.Controllers
{
    
    [ApiController]
    public class DepartmentController : CustomControllerBase
    {
        private readonly IDepartmentRepositry departmentRepositry;

        public DepartmentController ( IDepartmentRepositry departmentRepositry )
        {
            this.departmentRepositry = departmentRepositry;
        }

        [HttpGet]
        public async Task<ActionResult> GetEmployees ()
        {
            try
            {
                return Ok( await departmentRepositry.GetAll() );
            }
            catch ( Exception )
            {
                return StatusCode( StatusCodes.Status500InternalServerError, "Error" );
            }
        }
        [HttpGet( "{id:int}" )]
        public async Task<ActionResult<Department>> GetEmployee ( int id )
        {
            try
            {
                var res = await departmentRepositry.Get(id);

                if ( res == null )
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

    }
}
