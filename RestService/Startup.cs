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

            services.AddTransient<IUserLogic, UserLogic>();
            services.AddTransient<IRoleLogic, RoleLogic>();
            services.AddTransient<IPostLogic, PostLogic>();
            //services.AddTransient<IEvent_KeywordConnectLogic, Event_KeywordConnectLogic>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IRoleRepository, RoleRepository>();
            services.AddTransient<IPostRepository, PostRepository>();
            services.AddTransient<NWDbContext, NWDbContext>();

            
            services.AddTransient<IEventLogic, EventLogic>();
            services.AddTransient<IKeywordLogic, KeywordLogic>();
            services.AddTransient<IAddressLogic, AddressLogic>();
            services.AddTransient<IEventRepository, EventRepository>();
            services.AddTransient<IAddressRepository, AddressRepository>();
            services.AddTransient<IKeywordRepository, KeywordRepository>();
            services.AddTransient<IEvent_KeywordConnectRepository, Event_KeywordConnectRepository>();
            services.AddTransient<IEvent_UserConnectRepository, Event_UserConnectRepository>();
            

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
