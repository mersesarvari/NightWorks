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

namespace NightWorks.Endpoint
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public IConfiguration Configuration { get;}
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = "JwtBearer";
                options.DefaultChallengeScheme = "JwtBearer";

            }).AddJwtBearer(jwtoptions =>
            {
                jwtoptions.TokenValidationParameters = new TokenValidationParameters()
                {
                    //IssuerSigningKey = SIGNING_KEY,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidIssuer = "http://localhost:5000",
                    ValidAudience = "http://localhost:5000",
                    ValidateLifetime = true
                };
            });
            
            
            services.AddTransient<IUser_Logic, User_Logic>();
            services.AddTransient<IRole_Logic, Role_Logic>();
            services.AddTransient<IPost_Logic, Post_Logic>();
            services.AddTransient<IEvent_Logic, Event_Logic>();
            services.AddTransient<IKeyword_Logic, Keyword_Logic>();
            services.AddTransient<IAddress_Logic, Address_Logic>();
            services.AddTransient<IFile_Logic, File_Logic>();
            services.AddTransient<IJwtAuthenticationmanager, JwtAuthenticationmanager>();
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


            //Ez általa, hozzáadott rész
            services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

            services.AddCors(options => options.AddDefaultPolicy
            (
                builder => builder.AllowAnyOrigin())
            );
            


        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseCors();
             
            //Ez eddig nem volt itt, szóval lehet kérdéses
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            
        }
    }
}
