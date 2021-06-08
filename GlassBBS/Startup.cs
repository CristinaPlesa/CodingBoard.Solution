using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;

using GlassBBS.Models;

namespace GlassBBS
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    // Represents a set of key/value application configuration properties.
    public IConfiguration Configuration { get; set; }

    // This method gets called by the runtime. Use this method to add services to the container via Dependency Injection.
    public void ConfigureServices(IServiceCollection services)
    {
      // Inject MVC Services
      services.AddMvc();
      // Cross Origin Resource Sharing
      services.AddCors();
      // This method configures the MVC services for the commonly used features with controllers for an API
      services.AddControllers();

      // TRYING STUFF https://stackoverflow.com/questions/62906939/error-while-validating-the-service-descriptor-servicetype-microsoft-aspnetcore
      // Register the DBContext (prior to configuring stores/using IS4)
      // services.AddDbContext<GlassBBSContext>();

      // Inject Entity Framework for MySql DB, configured via DBContext file in Models folder
      services.AddEntityFrameworkMySql().AddDbContext<GlassBBSContext>(opt =>
        // Gets the config for how to connect to MySql from the protected appsettings.json file and auto determines which version of MySql is installed/being utilized
        opt.UseMySql(Configuration["ConnectionStrings:DefaultConnection"], ServerVersion.AutoDetect(Configuration["ConnectionStrings:DefaultConnection"])));
      // Inject Identity specific method overrides for the Entity Framework
      services.AddIdentity<BoardUser, IdentityRole>()
      .AddEntityFrameworkStores<GlassBBSContext>()
      // Inject the default Identity token provider methods for creating 2FA, password reset, and other short-lived tokens
      .AddDefaultTokenProviders();
      // Inject Identity Server and AspNetIdentity extension method to allow use of IdentityServer4 for JWT/API auth
      services.AddIdentityServer().AddAspNetIdentity<BoardUser>(); // this was added last and caused the explosion... TODO

      // Overrides Identity-set Password Requirements
      services.Configure<IdentityOptions>(options =>
      {
        options.Password.RequireDigit = false;
        options.Password.RequiredLength = 1;
        options.Password.RequireLowercase = false;
        options.Password.RequireNonAlphanumeric = false;
        options.Password.RequireUppercase = false;
        options.Password.RequiredUniqueChars = 0;
      });
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }
      app.UseAuthentication();
      // app.UseHttpsRedirection();
      app.UseRouting();
      app.UseAuthorization();
      app.UseEndpoints(endpoints => endpoints.MapControllers());
      app.UseStaticFiles();
      app.UsePathBase(env.ContentRootPath);
    }
  }
}
