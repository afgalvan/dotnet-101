using System;
using System.Collections.Generic;
using System.Linq;
using ContosoPets._1.Data;
using ContosoPets._1.Models;
using ContosoPets._1.Settings;

namespace ContosoPets._1
{
    static class Program
    {
        static void Main(string[] args)
        {
            Configuration.Load(args);
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
            using var context = new ContosoPetsContext();
            context.Database.EnsureCreated();
            var bone = new Product
            {
                Name  = "Dog Bone",
                Price = 4.99M
            };
            context.Add(bone);

            var tennisBalls = new Product
            {
                Name  = "Tennis Ball 3-Pack",
                Price = 9.99M
            };
            context.Add(tennisBalls);

            context.SaveChanges();
        }

        private static void DisplayProducts()
        {
            List<Product> products = ReadProducts();
            products.ForEach(DisplayProduct);
        }

        private static List<Product> ReadProducts()
        {
            using var context = new ContosoPetsContext();
            return context.Products.OrderBy(p => p.Name).ToList();
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
            Action<ContosoPetsContext, Product> updateAction, string name)
        {
            using var context = new ContosoPetsContext();

            Product product =
                context.Products.FirstOrDefault(p => p.Name == name);
            if (product == null) return;
            updateAction(context, product);
            context.SaveChanges();
        }

        private static Product GetProductByName(string name)
        {
            using var context = new ContosoPetsContext();
            return context.Products.FirstOrDefault(p => p.Name == name);
        }
    }
}
