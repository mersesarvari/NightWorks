using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NightWorks.Logic;
using NightWorks.Repository;
using NightWorksLogic;
using NigthWorks.Data;
using NigthWorks.Logic;
using NigthWorks.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace NightWorks.Endpoint
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddTransient<IUser_Logic, User_Logic>();
            services.AddTransient<IRole_Logic, Role_Logic>();
            services.AddTransient<IPost_Logic, Post_Logic>();
            services.AddTransient<IEvent_Logic, Event_Logic>();
            services.AddTransient<IKeyword_Logic, Keyword_Logic>();
            services.AddTransient<IAddress_Logic, Address_Logic>();
            //services.AddTransient<IEventMainImageLogic, EventMainImageLogic>();
            //services.AddTransient<IEvent_KeywordConnectLogic, Event_KeywordConnectLogic>(); //Még nincsen készen

            
            services.AddTransient<IUserRepository, User_Repository>();
            services.AddTransient<IRoleRepository, Role_Repository>();
            services.AddTransient<IPostRepository, Post_Repository>();         
            services.AddTransient<IEventRepository, Event_Repository>();
            services.AddTransient<IKeywordRepository, Keyword_Repository>();
            services.AddTransient<IAddressRepository, AddressRepository>();
            services.AddTransient<IEvent_Keyword_ConnectRepository, Event_Keyword_ConnectRepository>();
            services.AddTransient<IEvent_User_ConnectRepository, Event_User_Connect_Repository>();
            //services.AddTransient<IEventMainImageRepository, EventMainImageRepository>();


            services.AddTransient<NWDbContext, NWDbContext>();


            //Ez általa, hozzáadott rész
            services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
            
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
