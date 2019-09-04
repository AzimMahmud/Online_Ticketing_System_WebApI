using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using AutoMapper;
using BusTicket.API.Controllers;
using BusTicket.API.Core;
using BusTicket.API.Core.Domain;
using BusTicket.API.Core.Repositories;

using BusTicket.API.DTOs;
using BusTicket.API.Helper;
using BusTicket.API.Persistence;
using BusTicket.API.Persistence.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;

namespace BusTicket.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {

            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }


        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {


            //Inject AppSettings
            services.Configure<ApplicationSettings>(Configuration.GetSection("ApplicationSettings"));
            // Configure DbContext File
            services.AddDbContext<BusTicketContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DbCon")));

            // Configure Cloudinary


            // Identity Configuration 
            IdentityBuilder identitybuilder = services.AddIdentityCore<User>(opt =>
                       {
                           opt.Password.RequireDigit = false;
                           opt.Password.RequiredLength = 4;
                           opt.Password.RequireNonAlphanumeric = false;
                           opt.Password.RequireUppercase = false;
                       });

            identitybuilder = new IdentityBuilder(identitybuilder.UserType, typeof(Role), identitybuilder.Services);
            identitybuilder.AddEntityFrameworkStores<BusTicketContext>();
             identitybuilder.AddRoleValidator<RoleValidator<Role>>();
             identitybuilder.AddRoleManager<RoleManager<Role>>();
            identitybuilder.AddSignInManager<SignInManager<User>>();



            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII
                            .GetBytes(Configuration.GetSection("AppSettings:Token").Value)),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("RequireAdminRole", policy => policy.RequireRole("Admin"));

            });





            // Auto Mapper Configurations
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);



            services.AddMvc(options =>
                           {
                               var policy = new AuthorizationPolicyBuilder()
                                   .RequireAuthenticatedUser()
                                   .Build();
                               options.Filters.Add(new AuthorizeFilter(policy));
                           })
                           .SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                           .AddJsonOptions(opt =>
                           {
                               opt.SerializerSettings.ReferenceLoopHandling =
                                   Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                           });
            services.AddCors();







            // Configure AutoFac
            var builder = new ContainerBuilder();

            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();
            builder.Populate(services);

            var container = builder.Build();
            return container.Resolve<IServiceProvider>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler(builder =>
                {
                    builder.Run(async context =>
                    {
                        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                        var error = context.Features.Get<IExceptionHandlerFeature>();
                        if (error != null)
                        {
                            context.Response.AddApplicationError(error.Error.Message);
                            await context.Response.WriteAsync(error.Error.Message);
                        }
                    });
                });
                // app.UseHsts();
            }
            
            // app.UseHttpsRedirection();
            app.UseCors(x => x.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
            app.UseAuthentication();
            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseMvc();


        }
    }
}
