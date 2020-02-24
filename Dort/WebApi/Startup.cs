using Dort.Enum;
using Dort.i18n;
using Dort.i18n.Resources;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Repository;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi
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
            services.AddControllers();
            services.AddCors();

            ConfigureHttp(services);
            ConfigureSingletions(services);
            ConfigureAuthentication(services);
            ConfigureLanguages(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app,
            IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.Use(async (ctx, next) =>
            {
                await next();
                if (ctx.Response.StatusCode == 204)
                {
                    ctx.Response.ContentLength = 0;
                }
            });

            app.UseCors(builder =>
            builder.AllowAnyHeader()
            .AllowAnyOrigin()
            .AllowAnyMethod());

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            ConfigureAppCultureRequest(app);
        }

        private void ConfigureAppCultureRequest(IApplicationBuilder app)
        {

            var supportedCultures = new[]
            {
                new CultureInfo("en"),
                new CultureInfo("pt-BR")
            };

            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture("pt-BR"),
                SupportedCultures = supportedCultures,
                SupportedUICultures = supportedCultures,
            });
        }

        private void ConfigureLanguages(IServiceCollection services)
        {
            services.AddLocalization(options => options.ResourcesPath = "Resources");
            services.Configure<RequestLocalizationOptions>(
               opts =>
               {
                   var supportedCultures = new List<CultureInfo>
                   {
                        new CultureInfo("en"),
                        new CultureInfo("pt-BR")
                   };
                   opts.DefaultRequestCulture = new RequestCulture("pt-BR");
                   opts.SupportedCultures = supportedCultures;
                   opts.SupportedUICultures = supportedCultures;
                   opts.RequestCultureProviders.Insert(0, new CustomRequestCultureProvider(context =>
                   {
                       var userLangs = context.Request.Headers["Accept-Language"].ToString();
                       var firstLang = userLangs.Split(',').FirstOrDefault();
                       var defaultLang = string.IsNullOrEmpty(firstLang) ? "en" : firstLang;
                       return Task.FromResult(new ProviderCultureResult(defaultLang, defaultLang));
                   }));
               });

            services.AddMvc()
                .AddDataAnnotationsLocalization()
                .SetCompatibilityVersion(CompatibilityVersion.Latest);
        }

        private void ConfigureHttp(IServiceCollection services)
        {
            services.AddHttpClient();
            services.AddHttpClient(Integration.GOOGLE_BOOK.Description(), c =>
            {
                c.BaseAddress = new Uri(IntegrationUrl.GOOGLE_BOOK.Description());
            });
        }

        public void ConfigureSingletions(IServiceCollection services)
        {
            var connectionString = Configuration.GetConnectionString("BaseIdentity");

            var signingConfigurations = new SigningConfigurations();
            var dbFactory = new PostgreDbConnectionFactory() { ConnectionString = connectionString };

            services.AddSingleton(signingConfigurations);
            services.AddSingleton(dbFactory);
            services.AddSingleton<IAppResource, DortResourcesManager>();
        }

        public void ConfigureAuthentication(IServiceCollection services)
        {
            services.AddAuthentication(authOptions =>
            {
                authOptions.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                authOptions.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(bearerOptions =>
            {
                var paramsValidation = bearerOptions.TokenValidationParameters;
                paramsValidation.IssuerSigningKey = new SigningConfigurations().Key;
                paramsValidation.ValidateIssuerSigningKey = true;
                paramsValidation.ValidateLifetime = true;
                paramsValidation.ClockSkew = TimeSpan.Zero;
            });

            services.AddAuthorization(auth =>
            {
                auth.AddPolicy("Bearer", new AuthorizationPolicyBuilder()
                    .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
                    .RequireAuthenticatedUser().Build());
            });

        }
    }
}
