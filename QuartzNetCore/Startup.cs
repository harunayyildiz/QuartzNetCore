using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Quartz;
using QuartzNetCore.BaseQuartz;
using QuartzNetCore.Jobs;

namespace QuartzNetCore
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            CallQuartz.UseQuartz(services,typeof(JobV1), typeof(JobV2));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
            });
            var scheduler = app.ApplicationServices.GetService<IScheduler>();
            QuartzServiceUtility.StartJob<JobV1>(scheduler,TimeSpan.FromSeconds(10));
            QuartzServiceUtility.StartJob<JobV2>(scheduler,TimeSpan.FromSeconds(15));

        }
      
    }
}
