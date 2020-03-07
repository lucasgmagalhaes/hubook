using Dort.Enum;
using Dort.I18n;
using Dort.Migrations;
using Dort.Repository.Db;
using Dort.Repository.GoogleBook;
using Dort.Repository.Http;
using Dort.RepositoryImpl.Database;
using Dort.RepositoryImpl.Http;
using Dort.WebApi.Extensions;
using Dort.WebApi.Filters;
using FluentMigrator.Runner;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Repository;
using System;

namespace WebApi
{
    public class Startup
    {
        private readonly string dbConnection;

        public Startup(IConfiguration configuration)
        {
            dbConnection = configuration.GetConnectionString("hubrayDB");

            CultureManager.AddResource("en", new Language_en());
            CultureManager.AddResource("pt-br", new Language_pt_br());
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers(options => options.Filters.Add(new HttpResponseExceptionFilter()));
            services.AddCors();

            ConfigureHttp(services);
            ConfigureSingletions(services, dbConnection);
            ConfigureAuthentication(services);

            AddScopedServices(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app,
            IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRequestCulture();

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

            IServiceProvider provider = CreateServices(dbConnection);
            using IServiceScope scope = provider.CreateScope();
            UpdateDatabase(scope.ServiceProvider);
        }

        private void AddScopedServices(IServiceCollection services)
        {
            services.AddScoped(typeof(IGoogleBookRepository), typeof(GoogleBookRepository));
            services.AddScoped(typeof(IHttpRepository), typeof(HttpRepository));
            services.AddScoped(typeof(IUserRepository), typeof(UserRepository));
        }

        private void ConfigureHttp(IServiceCollection services)
        {
            services.AddHttpClient();
            services.AddHttpClient(Integration.GOOGLE_BOOK.Description(), c =>
            {
                c.BaseAddress = new Uri(IntegrationUrl.GOOGLE_BOOK.Description());
            });
        }

        public void ConfigureSingletions(IServiceCollection services, string dbConnection)
        {
            SigningConfigurations signingConfigurations = new SigningConfigurations();
            PostgreDbConnectionFactory dbFactory = new PostgreDbConnectionFactory() { ConnectionString = dbConnection };

            services.AddSingleton(signingConfigurations);
            services.AddSingleton(typeof(IDbConnectionFactory), dbFactory);
        }

        public void ConfigureAuthentication(IServiceCollection services)
        {
            services.AddAuthentication(authOptions =>
            {
                authOptions.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                authOptions.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(bearerOptions =>
            {
                Microsoft.IdentityModel.Tokens.TokenValidationParameters paramsValidation = bearerOptions.TokenValidationParameters;
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

        /// <summary>
        /// Configure the dependency injection services
        /// </summary>
        private static IServiceProvider CreateServices(string dbConection)
        {
            return new ServiceCollection()
                .AddFluentMigratorCore()
                .ConfigureRunner(rb => rb
                    .AddPostgres()
                    .WithGlobalConnectionString(dbConection)
                    .ScanIn(typeof(AddUserBookAndUserLevelTable_0001).Assembly).For.Migrations())
                .AddLogging(lb => lb.AddFluentMigratorConsole())
                .BuildServiceProvider(false);
        }

        /// <summary>
        /// Update the database
        /// </summary>
        private static void UpdateDatabase(IServiceProvider serviceProvider)
        {
            IMigrationRunner runner = serviceProvider.GetRequiredService<IMigrationRunner>();
            runner.MigrateUp();
        }
    }
}
