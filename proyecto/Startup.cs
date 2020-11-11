using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;

namespace proyecto
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
            services.AddAuthentication("OAuth")
            .AddJwtBearer("OAuth", config =>
            {                
                var secretBytes = Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]);
                var key = new SymmetricSecurityKey(secretBytes);

                //Valida que el token viaje en la comunicación del controlador
                //Ejemplo
                //https://localhost:5001/Home/Secret?token_acceso=eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJBZG1pbmlzdHJhZG9yIiwiZW1haWwiOiJtaWNvcnJlb0BnbWFpbC5jb20iLCJqdGkiOiI5YTg5OGZlMi1iZThhLTRlNGEtYTJkOS01Zjg4MjI2ZTkyZjUiLCJuYmYiOjE1OTA5NDg0MDMsImV4cCI6MTU5MDk1NTYwMywiaXNzIjoiZ29vZ2xlLmNvbSIsImF1ZCI6Imdvb2dsZS5jb20ifQ.JAxOcsQz9BezjAyDKJHBN3rNaWBAP2lBCDTG0EVpduc
                config.Events = new JwtBearerEvents(){
                    OnMessageReceived = context =>
                    {
                        if(context.Request.Query.ContainsKey("token_acceso")){
                            context.Token = context.Request.Query["token_acceso"];
                        }
                        return Task.CompletedTask;
                    }
                };

                //Valida el acceso
                //Sin esto, el estado es 401 Unauthorized 
                //https://localhost:5001/Home/Autenticar para obtener el token
                //Ejemplo en Postman
                //https://localhost:5001/Home/Secret
                //Headers: key: Authorization y en value : "Bearer "+token_acceso)

                 config.TokenValidationParameters = new TokenValidationParameters(){
                     ValidIssuer = Configuration["Jwt:Issuer"],
                     ValidAudience = Configuration["Jwt:Audiance"],
                     IssuerSigningKey = key,

                 };

            });
            
            services.AddControllersWithViews();

            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //Usa los archivos de la carpeta wwwroot (bootstrap, jquery)
            app.UseStaticFiles();
            //
            if(env.IsDevelopment()){
                app.UseDeveloperExceptionPage();
            }
            app.UseRouting();
            //Validar acceso de usuario
            app.UseAuthentication();

            //Validar permisos del usuario
            app.UseAuthorization();
            
            app.UseEndpoints( endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
