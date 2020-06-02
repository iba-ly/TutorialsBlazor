using System;
using System.Linq;
using System.Threading.Tasks;
using Tutorials.Kudvenkat.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Tutorial.Kudvenkad.Api.Contexts;

namespace Tutorial.Kudvenkad.Api.Repositries.EmployeeRepo
{

    public interface IEmployeeRepositry : IRepositryBase<Employee>
    {
    }

    public class EmployeeRepositry : RepositryBase<Employee>, IEmployeeRepositry
    {
        public EmployeeRepositry ( EmployeeDbContext dbContext ) : base( dbContext )
        {
        }
    }

    /* (int id, Department employee )
    public class EmployeeRepositry : IEmployeeRepositry
    {
        private readonly EmployeeDbContext dbContext;

        public EmployeeRepositry (EmployeeDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Employee> AddEmployee ( Employee employee )
        {
            var res = await dbContext.Employees.AddAsync( employee );
            await dbContext.SaveChangesAsync();
            return res.Entity;
        }

        public async void DeleteEmployee ( int employeeid )
        {
            var res = await dbContext.Employees.FindAsync(employeeid);
            if(res != null )
            {
                dbContext.Employees.Remove( res );
                await dbContext.SaveChangesAsync(); 
            }
        }

        public async Task<Employee> GetEmployee ( int employeeid )
        { 
            return await dbContext.Employees.FindAsync( employeeid );
        }

        public async Task<IEnumerable<Employee>> GetEmployees ()
        {
            return await dbContext.Employees.ToListAsync();
        }

        public async Task<Employee> UpdateEmployee ( Employee employee )
        {
            var res = await dbContext.Employees.FindAsync( employee.ID );
            if( res != null )
            {
                dbContext.Entry( res ).State = EntityState.Detached;
                dbContext.Entry( employee ).State = EntityState.Modified;
                await dbContext.SaveChangesAsync();
                return res;
            }
            return null;
        }
    }
    */
}
