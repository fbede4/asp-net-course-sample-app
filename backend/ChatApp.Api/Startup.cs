using ChatApp.Api.Middlewares;
using ChatApp.Application.Interfaces;
using ChatApp.Bll.Services;
using ChatApp.Dal;
using ChatApp.Dal.Repositories;
using ChatApp.Dal.UoW;
using ChatApp.Domain.Configuration;
using ChatApp.Domain.Repositories;
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
            services.AddScoped<UserRepository>();
            services.AddScoped<IUserRepository, CachedUserRepository>();

            services.AddScoped<IMessageRepository, MessageRepository>();

            services.AddScoped<IMessagesAppService, MessagesAppService>();
            services.AddScoped<IUsersAppService, UsersAppService>();

            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ChatApp.Api", Version = "v1" });
            });
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
