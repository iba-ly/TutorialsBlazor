using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tutorial.Kudvenkad.Api.Contexts;
using Tutorials.Kudvenkat.Models;

namespace Tutorial.Kudvenkad.Api.Repositries.DepartmentRepo
{

    public interface IDepartmentRepositry : IRepositryBase<Department>
    {

    }

    public class DepartmentRepositry : RepositryBase<Department>, IDepartmentRepositry
    {
        public DepartmentRepositry ( EmployeeDbContext dbContext ) : base( dbContext )
        {
        }
    }
}
