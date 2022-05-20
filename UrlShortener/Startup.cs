namespace UrlShortener
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using UrlShortener.MongoDb;
    using UrlShortener.Options;
    using UrlShortener.Services;
    using UrlShortener.ShortUrlGenerator;
    using UrlShortener.Validation;

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
           
            services.AddOptions<UrlDatabaseOptions>()
                .Bind(Configuration.GetSection(UrlDatabaseOptions.UrlDatabase))
                .ValidateDataAnnotations();
            services.AddScoped<IStringValidator, StringValidator>();
            services.AddScoped<IShortUrlGenerator, ShortUrlGenerator.ShortUrlGenerator>();
            services.AddScoped<IUrlService, UrlService>();
            services.AddScoped<IUrlDal, UrlDal>();
            services.AddControllers();
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

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
