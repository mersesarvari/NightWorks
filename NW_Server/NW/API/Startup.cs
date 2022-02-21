using Castle.Core.Configuration;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using NightWorks.Logic;
using NightWorks.Repository;
using NightWorksLogic;
using NigthWorks.Data;
using NigthWorks.Logic;
using NigthWorks.Models;
using NigthWorks.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace API
{
    public class Startup
    {
        
        public void ConfigureServices(IServiceCollection services)
        {            
            services.AddControllers();
            /*
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options => 
            {
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateActor = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = Configuration["Jwt:Issuer"],

                };
            
            });
            */
            #region Addtransients
            services.AddTransient<IUser_Logic, User_Logic>();
            services.AddTransient<IRole_Logic, Role_Logic>();
            services.AddTransient<IPost_Logic, Post_Logic>();
            services.AddTransient<IEvent_Logic, Event_Logic>();
            services.AddTransient<IKeyword_Logic, Keyword_Logic>();
            services.AddTransient<IAddress_Logic, Address_Logic>();
            services.AddTransient<IFile_Logic, File_Logic>();
            //services.AddTransient<IJwtAuthenticationmanager, JwtAuthenticationmanager>();
            //services.AddTransient<IEvent_KeywordConnectLogic, Event_KeywordConnectLogic>(); //Még nincsen készen


            services.AddTransient<IUser_Repository, User_Repository>();
            services.AddTransient<IRole_Repository, Role_Repository>();
            services.AddTransient<IPost_Repository, Post_Repository>();         
            services.AddTransient<IEvent_Repository, Event_Repository>();
            services.AddTransient<IKeyword_Repository, Keyword_Repository>();
            services.AddTransient<IAddress_Repository, Address_Repository>();
            services.AddTransient<IEvent_Keyword_ConnectRepository, Event_Keyword_ConnectRepository>();
            services.AddTransient<IEvent_User_Connect_Repository, Event_User_Connect_Repository>();
            services.AddTransient<IUserSettings_Keyword_ConnectRepository, UserSettings_Keyword_ConnectRepository>();
            services.AddTransient<IFile_Repository, File_Repository>();
            services.AddTransient<NWDbContext, NWDbContext>();
            #endregion

            services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

            services.AddCors(options => options.AddDefaultPolicy
            (
                builder => builder.AllowAnyOrigin())
            );
            /*
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = Configuration["Jwt:Issuer"],
                    ValidAudience = Configuration["Jwt:Issuer"],
                    IssuerSigningKey = new
                    SymmetricSecurityKey
                    (Encoding.UTF8.GetBytes
                    (Configuration["Jwt:Key"]))
                };
            });
            */



        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //Added
            //app.UseSession();
            app.UseRouting();
            app.UseStaticFiles();
            app.UseRouting();
            //app.UseAuthentication();
            //app.UseAuthorization();
            app.UseCors();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            
        }
    }
}
