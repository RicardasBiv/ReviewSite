using BackEnd.Data;
using Microsoft.AspNetCore.Cors;
using BackEnd.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Identity;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Filters;
using BackEnd.Data.Services.IServices;
using BackEnd.Data.Repositories;
using BackEnd.Data.Repositories.IRepositories;
using BackEnd.Data.Services;
using AutoMapper;

namespace BackEnd
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
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAllHeaders",
                      builder =>
                      {
                          builder.AllowAnyOrigin()
                                 .AllowAnyHeader()
                                 .AllowAnyMethod();
                      });
            });
            //Swagger

            AddSwagger(services);
            services.AddControllers().AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );
            services.AddAutoMapper(typeof(Startup));

            // Database Context
            services.AddDbContext<ApplicationDbContext>(o => o.UseSqlServer(Configuration.GetConnectionString("SaitynasDbContextConnection")));

            // Identity
            services.AddIdentity<Naudotojas, Role>()
                .AddRoles<Role>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            // Authentication
            var key = Encoding.ASCII.GetBytes("secretToVerifyJwtTokens");
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(x =>
                {
                    x.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });
            services.Configure<IdentityOptions>(x =>
            {
                x.Password.RequireDigit = false;
                x.Password.RequireNonAlphanumeric = false;
                x.Password.RequireUppercase = false;
                x.Password.RequireLowercase = false;
                x.User.RequireUniqueEmail = true;
            }
            );

            //Repositories
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRecenzijaRepository, RecenzijaRepository>();
            services.AddScoped<IKomentarasRepository, KomentarasRepository>();
            services.AddScoped<IVertinimasRepository, VertinimasRepository>();
            services.AddScoped<ITipasRepository, TipasRepository>();
            services.AddScoped<IZanraiRepository, ZanraiRepository>();
            //Services
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IRecenzijuService, RecenzijaService>();
            services.AddScoped<IKomentarasService, KomentarasService>();
            services.AddScoped<IVertinimasService, VertinimasService>();

           


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors("AllowAllHeaders");
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Recenziju API V1");
            }); 
        }
        private static void AddSwagger(IServiceCollection services)
        {
            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Recenziju API", Version = "v1" });

                 c.OperationFilter<SecurityRequirementsOperationFilter>();
                 c.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                 {
                     Description = "Standard Authorization header using the Bearer scheme. Example: \"bearer {token}\"",
                     In = ParameterLocation.Header,
                     Name = "Authorization",
                     Type = SecuritySchemeType.ApiKey
                 });
             
            });
        }
    }
}
