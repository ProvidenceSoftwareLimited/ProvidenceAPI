using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ProvidenceAPI.Services;
using Microsoft.EntityFrameworkCore;
using ProvidenceAPI.Data;

namespace ProvidenceAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        //{
        //    services.AddControllers();
        //    services.AddSingleton<ISecurities, Securities>();

        //    services.AddDbContext<ProvidenceAPIContext>(options =>
        //            options.UseSqlServer(Configuration.GetConnectionString("ProvidenceAPIContext")));


        { 
            services.AddControllers();
            services.AddDbContext<ProvidenceAPIContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("ProvidenceAPIContext")));

            var context = services.BuildServiceProvider().GetService<ProvidenceAPIContext>();

            services.AddSingleton<ISecurities, Securities>(cont =>
            {
                return new Securities(context);
            }
            );

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }


    }
}
