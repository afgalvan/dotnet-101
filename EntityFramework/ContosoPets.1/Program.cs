using System;
using System.Collections.Generic;
using System.Linq;
using ContosoPets._1.Models;
using ContosoPets._1.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ContosoPets._1
{
    internal static class Program
    {
        private static IProductRepository _repository;

        private static void Main(string[] args) =>
            CreateHostBuilder(args).Build().Run();

        private static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureLogging(logging =>
                    logging.AddFilter(
                        "Microsoft.EntityFrameworkCore.Database.Command",
                        LogLevel.Warning
                    )
                )
                .ConfigureServices(services =>
                {
                    var startup = new Startup();
                    startup.ConfigureServices(services);
                    using var provider = services.BuildServiceProvider();
                    _repository =
                        provider.GetRequiredService<IProductRepository>();
                    Run();
                });

        private static void Run()
        {
            SaveProducts();
            Console.WriteLine("\nOriginal products.");
            DisplayProducts();
            DeleteProduct("Tennis Ball 3-Pack");
            UpdateProductPriceByName(7.99M, "Dog Bone");
            Console.WriteLine("\nUpdated data.");
            DisplayProducts();
        }

        private static void SaveProducts()
        {
            var bone = new Product
            {
                Name  = "Dog Bone",
                Price = 4.99M
            };
            _repository.Save(bone);

            var tennisBalls = new Product
            {
                Name  = "Tennis Ball 3-Pack",
                Price = 9.99M
            };
            _repository.Save(tennisBalls);
        }

        private static void DisplayProducts()
        {
            IEnumerable<Product> products = _repository.GetAll();
            products.ToList().ForEach(DisplayProduct);
        }

        private static void DisplayProduct(Product product)
        {
            Console.WriteLine($"Id:    {product.Id}");
            Console.WriteLine($"Name:  {product.Name}");
            Console.WriteLine($"Price: ${product.Price}");
            Console.WriteLine(new string('-', 25));
        }

        private static void UpdateProductPriceByName(decimal price, string name)
        {
            AlterOnFind((_, product) => product.Price = price, name);
        }

        private static void DeleteProduct(string name)
        {
            AlterOnFind((context, product) => context.Remove(product), name);
        }

        private static void AlterOnFind(
            Action<IProductRepository, Product> updateAction, string name)
        {
            Product product = _repository.GetAll().FirstOrDefault(
                p => p.Name == name
            );
            if (product == null) return;
            updateAction(_repository, product);
        }
    }
}
