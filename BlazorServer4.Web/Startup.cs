using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using BlazorServer4.Database;
using BlazorServer4.DataAccess;
using System.Net.Http;

#pragma warning disable CA1822 // Mark members as static
namespace BlazorServer4.Web
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
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddTransient<IDbContext, MyDbContext>();
            services.AddTransient<ICategoryData, CategoryData>();
            services.AddTransient<IProductData, ProductData>();
            services.AddTransient<IProductCategoryData, ProductCategoryData>();
            services.AddTransient<IShoppingBasketData, ShoppingBasketData>();
            services.AddTransient<IShoppingBasketItemData, ShoppingBasketItemData>();
            services.AddTransient<IShoppingBasketProductData, ShoppingBasketProductData>();
            services.AddProtectedBrowserStorage();
            services.AddHttpClient();
            services.AddScoped<HttpClient>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
