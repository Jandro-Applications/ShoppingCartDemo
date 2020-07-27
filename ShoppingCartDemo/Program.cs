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

            List<Product> products = null;

            DisplayMenu(products);

            int userInput = 0;

            do
            {
                var result = Console.ReadLine();

                try
                {
                    userInput = Convert.ToInt32(result);
                }
                catch (Exception)
                {

                    Console.WriteLine("You need to specify valid number");
                }
            }
            while (userInput != 999);
        }

        static public void DisplayMenu(List<Product> products)
        {
            Console.WriteLine("Type article code number to add it to a cart");
            Console.WriteLine("All articles:");
            Console.WriteLine("");

            DisplayProductsToMenu(products);

            Console.WriteLine("");
            Console.WriteLine("99. Summary");
            Console.WriteLine("999. End");
        }

        static public void DisplayProductsToMenu(List<Product> products)
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
    }
}
