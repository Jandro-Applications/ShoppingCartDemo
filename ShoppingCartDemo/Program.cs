using Microsoft.Extensions.DependencyInjection;
using ShoppingCart.Services.Interfaces.Products;
using ShoppingCart.Services.Interfaces.ShoppingCart;
using ShoppingCart.Services.Models.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;

namespace ShoppingCartDemo
{
    class Program
    {
        static void Main(string[] args)
        {

            var serviceProvider = InitializeStartup();

            var productsService = serviceProvider.GetService<IProductsService>();
            var shoppingCartService = serviceProvider.GetService<IShoppingCartService>();

            List<Product> products = productsService.GetAll();

            DisplayMenu(products);

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
                            var shoppingCart = shoppingCartService.GetSummary();

                            if (shoppingCart != null)
                            {
                                DisplaySummaryItems(shoppingCart);
                            }
                        }
                        else if (userInput == 88)
                        {
                            shoppingCartService.ClearCart();
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("All items have been removed from cart");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("");
                            DisplayMenu(products);
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
            Console.WriteLine("88. Clear cart");
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

        static private void DisplaySummaryItems(ShoppingCart.Services.Models.ShoppingCart.ShoppingCart shoppingCart)
        {
            if (shoppingCart != null && shoppingCart.Items != null && shoppingCart.Items.Count() > 0)
            {
                Console.WriteLine("");

                foreach (var item in shoppingCart.Items)
                {
                    Console.WriteLine($" => {item.ProductTitle, 10} - Qty {item.Quantity} - Price {item.BasePrice} - Sum {item.Price}");
                }

                Console.WriteLine($"Total: {shoppingCart.Price}");
                Console.WriteLine("");
                Console.WriteLine("");
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
