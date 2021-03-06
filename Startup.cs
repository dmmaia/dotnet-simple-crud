    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using user_register_test.Repository;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.HttpsPolicy;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Options;
    using Swashbuckle.AspNetCore.Swagger;
    namespace user_register_test
    {
        public class Startup
        {
            public Startup(IConfiguration configuration)
            {
                Configuration = configuration;
            }
            public IConfiguration Configuration { get; }
            public void ConfigureServices(IServiceCollection services)
            {
                services.AddControllers();
                services.Configure<IISOptions>(o =>
                {
                    o.ForwardClientCertificate = false;
                });
                services.AddSwaggerGen(c =>
                {
                    c.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1" });
                });
                services.AddScoped<IUserRepository>(factory => {
                        return new UserRepository(Configuration.GetConnectionString("MySqlDbConnection"));
                });
            }
            public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
            {
                app.UseDeveloperExceptionPage();
                
                // Configurações do Swagger no pipiline de execução da aplicação.
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Minha API .Net Core e VS Code");
                });
            }
        }
    }