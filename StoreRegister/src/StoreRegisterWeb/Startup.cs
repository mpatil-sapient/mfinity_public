using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.AspNet.Http;
using Microsoft.Extensions.DependencyInjection;
using React.AspNet;

namespace StoreRegisterWeb
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddReact();
            services.AddMvc();
            //services.AddScoped
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            app.UseDeveloperExceptionPage();
            app.UseExceptionHandler("/home/error");
            app.UseReact(config =>
            {
                config
                    .SetLoadBabel(false)
                    .AddScriptWithoutTransform("~/lib/generated/bundle.react.js");
            });
            app.UseStaticFiles();
            app.UseFileServer();
            app.UseMvc(routes =>
                routes.MapRoute("Default", 
                    "{controller=Home}/{action=Index}/{id?}")
            );
            app.Use(async (context, next) =>
            {
                if (context.Request.Path.Value.StartsWith("/hello"))
                    await context.Response.WriteAsync("Hello World!");
                if (context.Request.Path.Value.StartsWith("/checkout"))
                    await context.Response.WriteAsync("Hello World!");
                next();
            });
        }

        // Entry point for the application.
        public static void Main(string[] args) => WebApplication.Run<Startup>(args);
    }
}
