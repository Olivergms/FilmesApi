using FilmesApi.Authorization;
using FilmesApi.Data;
using FilmesApi.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;

namespace FilmesAPI
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
            services.AddDbContext<AppDbContext>(opts =>
                opts.UseLazyLoadingProxies()
                .UseSqlServer(Configuration
                .GetConnectionString("CinemaConnection")));

            #region Configuração do jwt
            services.AddAuthentication(auth =>
            {
                auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(token =>
                {
                    token.RequireHttpsMetadata = false;
                    token.SaveToken = true;
                    token.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        //chave do token
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding
                        .UTF8.GetBytes("Curs0Alura0Identity0d0tnetc1inc0")),
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ClockSkew = TimeSpan.Zero
                    };
                });

            #endregion


            #region Configuração de idade minima
            services.AddAuthorization(opt => 
            {
                opt.AddPolicy("IdadeMinima", policy =>
                {
                    policy.Requirements.Add(new IdadeMinimaRequiriment(18));
                });                    
            });

            services.AddSingleton<IAuthorizationHandler, IdadeMinimaHandler>();

            #endregion

            #region Services
            services.AddScoped<FilmeService, FilmeService>();
            services.AddScoped<CinemaService, CinemaService>();
            services.AddScoped<GerenteService, GerenteService>();
            services.AddScoped<EnderecoService, EnderecoService>();
            #endregion

            services.AddControllers();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
