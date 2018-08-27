using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using mywebapp.Application.Interfaces;
using mywebapp.Application.Services;
using mywebapp.Infra.Data.Context;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace mywebapp
{
    public class Startup
    {

        private static void HandleMapTest1(IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                await context.Response.WriteAsync("Map Test 1");
            });
        }

        private static void HandleMapTest2(IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                await context.Response.WriteAsync("Map Test 2");
            });
        }
        public IConfiguration _configuration { get; set; }
        //public HttpRequest _httpRequest { get; set; }

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
           // _httpRequest = httpRequest;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<MyWebAppContext>(options =>
                options.UseInMemoryDatabase("mywebapp"));

            services.AddSession();

            services.AddMvc();
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();


            services.AddTransient<IDateTimeAppService, DateTimeAppService>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStaticFiles();
            app.UseSession();
            app.UseMvc();

            app.Map("/map1", HandleMapTest1);

            app.Map("/map2", HandleMapTest2);

            //app.Run(async context =>
            //{
            //    await context.Response.WriteAsync("Hello from non-Map delegate. <p>");
            //});

            app.Run(async (context) =>
            {
                var i = context.Request.Host.ToString().IndexOf(":");
                await context.Response.WriteAsync(context.Request.Host.ToString().Substring(i + 1));
            });

            app.Use(async (context, next) => {
                //Do what you want with context,which is HttpContext
                await next.Invoke();
            });
        }
    }
}
