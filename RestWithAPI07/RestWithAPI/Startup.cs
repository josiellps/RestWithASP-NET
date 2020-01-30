using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using RestWithAPI.Business;
using RestWithAPI.Business.Implementation;
using RestWithAPI.Repository;
using RestWithAPI.Repository.Implementattion;
using RestWithAPI.Model.Context;
using MySql.Data.MySqlClient;
using RestWithAPI.Repository.Generic;
using Tapioca.HATEOAS;
using RestWithAPI.HiperMedia;
using RestWithAPI.Data.Converters;
using RestWithAPI.Data.Converter;

namespace RestWithAPI
{
    public class Startup
    {
        public IConfiguration _configuration { get; }
        private readonly ILogger _logger;
        public IHostingEnvironment _hostingEnvironment;
        public Startup(IConfiguration configuration, ILogger<Startup> logger, IHostingEnvironment hostingEnvironment)
        {
            _configuration = configuration;
            _logger = logger;
            _hostingEnvironment = hostingEnvironment;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var connection = _configuration["MySQLConnection:MySQLConnectionString"];
            services.AddDbContext<MySQLContext>(options => options.UseMySql(connection));

            if (_hostingEnvironment.IsDevelopment())
            {
                try
                {
                    var envolveConnection = new MySql.Data.MySqlClient.MySqlConnection(connection);

                    var evolve = new Evolve.Evolve(envolveConnection, msg => _logger.LogInformation(msg))
                    {
                        Locations = new List<string> { "db/migrations", "db/dataset" },
                        IsEraseDisabled = true
                    };
                    evolve.Migrate();
                }
                catch (System.Exception ex)
                {
                    _logger.LogCritical($"Migration Database Failed.====>{ex.Message}", ex.Message);
                }
            }



            var filterOptions = new HyperMediaFilterOptions();
            filterOptions.ObjectContentResponseEnricherList.Add(new PersonEnricher());
            services.AddSingleton(filterOptions);

            services.AddScoped<IPersonBusiness, PersonBusiness>();
            services.AddScoped<IPersonRepository, PersonRepository>();
            services.AddScoped<IBookBusiness, BookBusiness>();

            services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));

            services.AddMvc();                

            services.AddApiVersioning();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
 
            app.UseMvc(routes => {
                routes.MapRoute(
                    name: "DefaultApi",
                    template: "{Controller=Values}/{id?}");
            });
        }
    }
}
