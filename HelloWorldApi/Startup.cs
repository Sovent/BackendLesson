using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogic;
using HelloWorldApi.Filters;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;

namespace HelloWorldApi
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
            services.AddMvc(options => {
				options.Filters.Add(new ModelValidationFilter());
			});

			var conn = Configuration.GetValue<string>("mongoConnectionString");
			var sqlConn = Configuration.GetValue<string>("sqlConnectionString");
			var businessLogicCompositionRoot = CompositionRoot.Configure();
			services.AddSingleton(businessLogicCompositionRoot.UserFacade);
			IUserRepository mongoUserRepo = new MongoUserRepository(conn);
			IUserRepository sqlUserRepo = new SqlUserRepository(sqlConn);
			services.AddSingleton(sqlUserRepo);


			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new Info { Title = "UserApi", Version = "v1" });
			});
		}

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
		
			app.UseSwagger();

			app.UseSwaggerUI(c =>
			{
				c.SwaggerEndpoint("/swagger/v1/swagger.json", "UserApi V1");
			});

			app.UseMvc();
        }
    }
}
