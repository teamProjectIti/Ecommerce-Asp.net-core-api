using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.Data;
using WebApplication1.Helper;
using WebApplication1.Model;
using WebApplication1.Model.Repositery;
using WebApplication1.Model.RepositeryDashboroad;
using WebApplication1.Model.ViewModelIdentity.SeedRole;

namespace WebApplication1
{
    public class Startup
    {
        public string Connectionstring { get; set; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            Connectionstring = Configuration.GetConnectionString("DefaultConnection");
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers().AddNewtonsoftJson(ww => ww.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            services.AddDbContext<ApplicationContext>(x =>
                  x.UseLazyLoadingProxies().UseSqlServer(Connectionstring));

            services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<ApplicationContext>()
             .AddDefaultTokenProviders();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebApplication1", Version = "v1" });
            });
            services.AddScoped<IRepositerCart, CartRepositer>();
            services.AddScoped<IrepositeryCat, RepositeyCAt>();
            services.AddScoped<IRepositeryProduct, RepositeryProduct>(); 
            services.AddScoped<IRepositeryBrand, RepositeryBrand>(); 
            services.AddScoped<IRepositeryCategory, RepositeryCategory>();
            services.AddScoped<IRepositeryProductClotes, RepositeryProductClothes>(); 

            services.AddAutoMapper(typeof(MappingProfiles));
            services.AddAutoMapper(typeof(MappingProfilesGallary)); 
            services.AddAutoMapper(typeof(MappingProfileCart)); 
            services.AddCors(opt =>
            {
                opt.AddPolicy("CorsPolicy", policy =>
                {
                    policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();

                });
            });


            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters =
                       new TokenValidationParameters()
                       {
                           ValidateIssuer = true,
                           ValidIssuer = Configuration["JWT:ValidIssuer"],
                           ValidateAudience = true,
                           ValidAudience = Configuration["JWT:ValidAudience"],
                           IssuerSigningKey =
                            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWT:SecrtKey"]))
                       };
            });
            services.AddCors(opt =>
            {
                opt.AddPolicy("CorsPolicy", policy =>
                {
                    policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebApplication1 v1"));
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseStaticFiles();
            app.UseCors("CorsPolicy");
            app.UseAuthentication();
            app.UseAuthorization();


    app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            //seed data
            AppDBInitlization.seedRoleDB(app).Wait();
        }
    }
}
