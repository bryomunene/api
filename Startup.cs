using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
//using MySql.Data.EntityFrameworkCore.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using web_api.Models;
using web_api.Services;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Security.Authentication;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace web_api
{
    public class Startup
    {

        [Obsolete]
        public Startup(IConfiguration configuration, Microsoft.Extensions.Hosting.IHostingEnvironment env)
        {
            Configuration = configuration;

            var builder = new ConfigurationBuilder()
            .SetBasePath(env.ContentRootPath)
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
            .AddEnvironmentVariables();
                    Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();

            ServicePointManager.SecurityProtocol = (SecurityProtocolType)(SslProtocols.Tls12 | SslProtocols.Tls11 | SslProtocols.Tls );

            services.AddControllersWithViews();

            services.AddRazorPages();

            //services.AddControllers();

            services.AddDbContextPool<DatabaseContext>(options => 
                options.UseMySql(Configuration.GetConnectionString("DefaultConnection"),
                mySqlOptionsAction: options => { options.EnableRetryOnFailure(); }
                ));

            services.AddScoped<IProductCategoryService, ProductsCategoryService>();


            //services.AddControllers(options => options.EnableEndpointRouting = false);

            // Add framework services.  
            //services.AddMvc().AddRazorPagesOptions(options =>
            //{
            //    options.Conventions.AddPageRoute("/ProductCategory/Index", "");
            //});

            services.Configure<HtmlHelperOptions>(o => o.ClientValidationEnabled = true);

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = context =>
                {
                    var result = new BadRequestObjectResult(context.ModelState);
                    result.ContentTypes.Clear();
                    result.ContentTypes.Add("application/vnd.error+json");

                    return result;
                };
            });



            // Register the Swagger generator, defining 1 or more Swagger documents  
            services.AddSwaggerGen();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.   , ILoggerFactory loggerFactory
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            //loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {

                endpoints.MapControllers();

                endpoints.MapRazorPages();

                    //endpoints.MapControllerRoute(
                    //        name: "default",
                    //        pattern: "{controller=Home}/{action=Index}/{id?}");


                endpoints.MapGet("/", async context =>
                        {
                            await context.Response.WriteAsync("Hello From ASP.NET Core Web API");
                        });

                //endpoints.MapControllerRoute("default", "{controller=ProductCategory}/{action=Index}");

            });

            app.UseStaticFiles();

            // Enable middleware to serve generated Swagger as a JSON endpoint.  
            // Enable middleware to serve generated Swagger as a JSON endpoint.  
            app.UseSwagger(c =>
            {
                c.SerializeAsV2 = true;
            });

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),  
            // specifying the Swagger JSON endpoint.  
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                c.RoutePrefix = string.Empty;
            });

            //app.UseMvc(routes =>
            //{
            //    routes.MapRoute(
            //        name: "ProductCategory",
            //        template: "{controller=ProductCategory}/{action=Index}/{id?}");
            //});


        }
    }
}
