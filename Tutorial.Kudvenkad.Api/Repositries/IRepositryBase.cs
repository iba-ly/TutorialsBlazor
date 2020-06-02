using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tutorial.Kudvenkad.Api.Contexts;
using Tutorials.Kudvenkat.Models;

namespace Tutorial.Kudvenkad.Api.Repositries
{
    public interface IRepositryBase<Tentity>
        where Tentity : class
    {
        Task<IEnumerable<Tentity>> GetAll ();
        Task<Tentity> Get (int employeeid);
        Task<Tentity> Add ( Tentity employee );
        Task<Tentity> Update (int id, Tentity employee );
        void Delete ( int employeeid );
    }

    public class RepositryBase<Tentity> : IRepositryBase<Tentity>
        where Tentity : class
    {
        protected readonly EmployeeDbContext dbContext;
        protected DbSet<Tentity> _DbSet => dbContext.Set<Tentity>();
        public RepositryBase ( EmployeeDbContext dbContext )
        {
            this.dbContext = dbContext;
        }

        public async Task<Tentity> Add ( Tentity employee )
        {
            var res = await _DbSet.AddAsync( employee );
            await dbContext.SaveChangesAsync();
            return res.Entity;
        }

        public async void Delete ( int employeeid )
        {
            var res = await dbContext.Employees.FindAsync(employeeid);
            if ( res != null )
            {
                dbContext.Employees.Remove( res );
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task<Tentity> Get ( int employeeid )
        {
            return await _DbSet.FindAsync( employeeid );
        }

        public async Task<IEnumerable<Tentity>> GetAll ()
        {
            return await _DbSet.ToListAsync();
        }

        public async Task<Tentity> Update (int id, Tentity employee )
        {
            var res = await _DbSet.FindAsync( id );
            if ( res != null )
            {
                dbContext.Entry( res ).State = EntityState.Detached;
                dbContext.Entry( employee ).State = EntityState.Modified;
                await dbContext.SaveChangesAsync();
                return res;
            }
            return null;
        }
    }

}
