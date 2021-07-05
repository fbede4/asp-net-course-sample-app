using Autofac;
using ChatApp.Api.AutofacModules;
using ChatApp.Api.Middlewares;
using ChatApp.Dal;
using ChatApp.Dal.UoW;
using ChatApp.Domain.Configuration;
using ChatApp.Domain.UoW;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace ChatApp.Api
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
        {
            services.Configure<UserHandlingConfiguration>(Configuration.GetSection("UserHandling"));

            services.AddDbContext<ChatAppDbContext>(opt =>
            {
                opt.UseSqlite("Data Source = chatapp.db");
            });

            services.AddScoped<IUnitOfWork>(serviceProvider =>
            {
                var dbContext = serviceProvider.GetRequiredService<ChatAppDbContext>();
                return new UnitOfWork(dbContext);
            });

            services.AddMemoryCache();

            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ChatApp.Api", Version = "v1" });
            });
        }

        public void ConfigureContainer(ContainerBuilder container)
        {
            container.RegisterModule(new DalAutofacModule());
            container.RegisterModule(new BllAutofacModule());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseMiddleware<RequestLoggerMiddleware>();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ChatApp.Api v1"));
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
