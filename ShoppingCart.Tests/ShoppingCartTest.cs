using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ShoppingCart.Services.Services.Products;
using ShoppingCart.Services.Services.ShoppingCart;
using System.Linq;

namespace ShoppingCart.Tests
{
    [TestClass]
    public class ShoppingCartTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            decimal expected = 2.95m;

            var mockProductsLogger = new Mock<ILogger<ProductsService>>();
            ILogger<ProductsService> productsLogger = mockProductsLogger.Object;

            var productsService = new ProductsService(productsLogger);
            var products = productsService.GetAll();

            var mockCartLogger = new Mock<ILogger<ShoppingCartService>>();
            ILogger<ShoppingCartService> logger = mockCartLogger.Object;
            var shoppingCartService = new ShoppingCartService(logger);

            shoppingCartService.AddToCart(products.FirstOrDefault(x => x.Code == 888));
            shoppingCartService.AddToCart(products.FirstOrDefault(x => x.Code == 123));
            shoppingCartService.AddToCart(products.FirstOrDefault(x => x.Code == 456));

            var summary = shoppingCartService.GetSummary();

            Assert.AreEqual(expected, summary.Price);
        }

        [TestMethod]
        public void TestMethod2()
        {
            decimal expected = 3.10m;

            var mockProductsLogger = new Mock<ILogger<ProductsService>>();
            ILogger<ProductsService> productsLogger = mockProductsLogger.Object;

            var productsService = new ProductsService(productsLogger);
            var products = productsService.GetAll();

            var mockCartLogger = new Mock<ILogger<ShoppingCartService>>();
            ILogger<ShoppingCartService> logger = mockCartLogger.Object;
            var shoppingCartService = new ShoppingCartService(logger);

            shoppingCartService.AddToCart(products.FirstOrDefault(x => x.Code == 123));
            shoppingCartService.AddToCart(products.FirstOrDefault(x => x.Code == 123));
            shoppingCartService.AddToCart(products.FirstOrDefault(x => x.Code == 456));
            shoppingCartService.AddToCart(products.FirstOrDefault(x => x.Code == 456));

            var summary = shoppingCartService.GetSummary();

            Assert.AreEqual(expected, summary.Price);
        }

        [TestMethod]
        public void TestMethod3()
        {
            decimal expected = 3.45m;

            var mockProductsLogger = new Mock<ILogger<ProductsService>>();
            ILogger<ProductsService> productsLogger = mockProductsLogger.Object;

            var productsService = new ProductsService(productsLogger);
            var products = productsService.GetAll();

            var mockCartLogger = new Mock<ILogger<ShoppingCartService>>();
            ILogger<ShoppingCartService> logger = mockCartLogger.Object;
            var shoppingCartService = new ShoppingCartService(logger);

            shoppingCartService.AddToCart(products.FirstOrDefault(x => x.Code == 888));
            shoppingCartService.AddToCart(products.FirstOrDefault(x => x.Code == 888));
            shoppingCartService.AddToCart(products.FirstOrDefault(x => x.Code == 888));
            shoppingCartService.AddToCart(products.FirstOrDefault(x => x.Code == 888));

            var summary = shoppingCartService.GetSummary();

            Assert.AreEqual(expected, summary.Price);
        }

        [TestMethod]
        public void TestMethod4()
        {
            decimal expected = 9.00m;

            var mockProductsLogger = new Mock<ILogger<ProductsService>>();
            ILogger<ProductsService> productsLogger = mockProductsLogger.Object;

            var productsService = new ProductsService(productsLogger);
            var products = productsService.GetAll();

            var mockCartLogger = new Mock<ILogger<ShoppingCartService>>();
            ILogger<ShoppingCartService> logger = mockCartLogger.Object;
            var shoppingCartService = new ShoppingCartService(logger);

            shoppingCartService.AddToCart(products.FirstOrDefault(x => x.Code == 888));
            shoppingCartService.AddToCart(products.FirstOrDefault(x => x.Code == 888));
            shoppingCartService.AddToCart(products.FirstOrDefault(x => x.Code == 888));
            shoppingCartService.AddToCart(products.FirstOrDefault(x => x.Code == 888));
            shoppingCartService.AddToCart(products.FirstOrDefault(x => x.Code == 888));
            shoppingCartService.AddToCart(products.FirstOrDefault(x => x.Code == 888));
            shoppingCartService.AddToCart(products.FirstOrDefault(x => x.Code == 888));
            shoppingCartService.AddToCart(products.FirstOrDefault(x => x.Code == 888));
            shoppingCartService.AddToCart(products.FirstOrDefault(x => x.Code == 456));
            shoppingCartService.AddToCart(products.FirstOrDefault(x => x.Code == 123));
            shoppingCartService.AddToCart(products.FirstOrDefault(x => x.Code == 123));

            var summary = shoppingCartService.GetSummary();

            Assert.AreEqual(expected, summary.Price);
        }
    }
}
