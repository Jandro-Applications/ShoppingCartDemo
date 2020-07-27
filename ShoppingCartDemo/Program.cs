using Microsoft.Extensions.DependencyInjection;
using ShoppingCart.Services.Interfaces.Products;
using ShoppingCart.Services.Interfaces.ShoppingCart;
using ShoppingCart.Services.Models.Product;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingCartDemo
{
    class Program
    {
        static void Main(string[] args)
        {

            var serviceProvider = InitializeStartup();

            var productsService = serviceProvider.GetService<IProductsService>();
            List<Product> products = productsService.GetAll();

            DisplayMenu(products);

            var shoppingCartService = serviceProvider.GetService<IShoppingCartService>();

            int userInput = 0;

            do
            {
                var result = Console.ReadLine();

                try
                {
                    userInput = Convert.ToInt32(result);

                    var product = products.FirstOrDefault(x => x.Code == userInput);

                    if (product != null)
                    {
                        if (shoppingCartService.AddToCart(product))
                        {
                            Console.WriteLine("Product added succesfully");
                        }
                    }
                    else
                    {
                        if (userInput == 99)
                        {
                            shoppingCartService.Get();
                        }
                        else if (userInput == 999)
                        {
                            Console.WriteLine("Bye!");
                        }
                        else
                        {
                            Console.WriteLine("Not valid code for article or menu item");
                        }

                    }
                }
                catch (Exception)
                {

                    Console.WriteLine("You need to specify valid number");
                }
            }
            while (userInput != 999);
        }

        static private void DisplayMenu(List<Product> products)
        {
            Console.WriteLine("Type article code number to add it to a cart");
            Console.WriteLine("All articles:");
            Console.WriteLine("");

            DisplayProductsToMenu(products);

            Console.WriteLine("");
            Console.WriteLine("99. Summary");
            Console.WriteLine("999. End");
        }

        static private void DisplayProductsToMenu(List<Product> products)
        {
            if (products != null && products.Count() > 0)
            {
                foreach (var product in products)
                {
                    Console.WriteLine(string.Format("{0}. {1} - {2} $", product.Code, product.Title, product.Price.ToString()));
                    Console.WriteLine(string.Format("-----{0}", product.Description));
                }
            }
        }

        static private IServiceProvider InitializeStartup()
        {
            IServiceCollection services = new ServiceCollection();
            Startup startup = new Startup();
            startup.ConfigureServices(services);

            return services.BuildServiceProvider();
        }
    }
}
