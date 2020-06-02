using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Tutorial.Kudvenkad.Api.Contexts;
using Tutorial.Kudvenkad.Api.Repositries;
using Tutorial.Kudvenkad.Api.Repositries.DepartmentRepo;
using Tutorial.Kudvenkad.Api.Repositries.EmployeeRepo;

namespace Tutorial.Kudvenkad.Api
{
    public class Startup
    {
        public Startup ( IConfiguration configuration )
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices ( IServiceCollection services )
        {
            services.AddControllers();

            services.AddScoped(typeof( IRepositryBase<> ), typeof( RepositryBase<> ) );
            services.AddScoped<IEmployeeRepositry, EmployeeRepositry>();
            services.AddScoped<IDepartmentRepositry, DepartmentRepositry>();

            services.AddDbContext<EmployeeDbContext>( op => op.UseSqlServer( Configuration.GetConnectionString( nameof( EmployeeDbContext ) ) ) );
        }

        public void Configure ( IApplicationBuilder app, IWebHostEnvironment env )
        {
            if ( env.IsDevelopment() )
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints( endpoints =>
             {
                 endpoints.MapControllers();
             } );
        }
    }
}
