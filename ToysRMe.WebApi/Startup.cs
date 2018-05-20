using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using ToysRMe.CommonLibrary;
using ToysRMe.CommonLibrary.Contracts;
using ToysRMe.CommonLibrary.Models;
using ToysRMe.WebApi.Services;

namespace ToysRMe.WebApi
{
  public class Startup
  {
    public Startup(IHostingEnvironment env)
    {
      var builder = new ConfigurationBuilder()
          .SetBasePath(env.ContentRootPath)
          .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
          .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

      if (env.IsEnvironment("Development"))
      {
        // This will push telemetry data through Application Insights pipeline faster, allowing you to view results immediately.
      }

      builder.AddEnvironmentVariables();
      Configuration = builder.Build();
    }

    public IConfigurationRoot Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container
    public void ConfigureServices(IServiceCollection services)
    {
      // Add framework services.
      services.AddTransient<IRepository<Product>, ProductRepository>();
      services.AddCors(x => x.AddPolicy("Cors", builder => 
      {
        builder.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader();
      }));

      services.AddMvc();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline
    public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
    {
      loggerFactory.AddConsole(Configuration.GetSection("Logging"));
      loggerFactory.AddDebug();
      app.UseCors("Cors");

      app.UseMvc();
    }
  }
}
