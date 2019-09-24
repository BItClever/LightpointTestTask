using System.Collections.Generic;
using AutoMapper;
using LightpointTestTask.BLL;
using LightpointTestTask.BLL.Infrastructure;
using LightpointTestTask.BLL.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace LightpointTestTask.WEB
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            var mappingConfig = new MapperConfiguration(mc =>
                mc.AddProfiles(new List<Profile>
                {
                    new MappingProfileBLLtoWEB(),
                    new MappingProfileDALtoBLL()
                })
            );
            

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
            services.AddTransient<IShopsService, ShopsService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Shops}/{action=Index}/{id?}");
            });
        }
    }
}
