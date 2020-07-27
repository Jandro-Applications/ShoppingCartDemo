using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using ShoppingCart.Services.Interfaces.Products;
using ShoppingCart.Services.Interfaces.ShoppingCart;
using ShoppingCart.Services.Services.Products;
using ShoppingCart.Services.Services.ShoppingCart;

namespace ShoppingCartDemo
{
    public class Startup
    {
        IConfigurationRoot Configuration { get; }

        public Startup()
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            Configuration = builder.Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddLogging(c => c.AddConsole().SetMinimumLevel(LogLevel.Trace));

            services.AddSingleton<IConfigurationRoot>(Configuration);
            services.AddSingleton<IShoppingCartService, ShoppingCartService>();
            services.AddSingleton<IProductsService, ProductsService>();
        }
    }
}
