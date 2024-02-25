using ProductManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManager
{
    class DatabaseControl
    {
        public static void CreateRecord(string name, decimal price)
        {
            using (var db = new ProductContext())
            {
                // Create
                Console.WriteLine($"Adding Product {name} into products...");
                db.Products.Add(new Product { Name = name, Price = price });
                db.SaveChanges();
            }
        }
        public static void ReadRecords()
        {
            using (var db = new ProductContext())
            {
                // Read
                Console.WriteLine("Querying for all products:");
                var products = db.Products.ToList();
                foreach (var product in products)
                {

                    Console.WriteLine($"Id: {product.Id}, Name: {product.Name}, Price: {product.Price}");
                }
            }
        }
        public static void UpdateRecords(int Id, double price)
        {
            using (var db = new ProductContext())
            {
                // Update
                Console.WriteLine("Updating the price of the first product...");
                var productToUpdate = db.Products.FirstOrDefault(p => p.Id == Id);
                if (productToUpdate != null)
                {
                    productToUpdate.Price = (decimal)price;
                    db.SaveChanges();
                }
            }
        }
        public static void DeleteRecords(int Id)
        {
            using (var db = new ProductContext())
            {
                // Delete
                Console.WriteLine("Deleting the second product...");
                var productToDelete = db.Products.FirstOrDefault(p => p.Id == Id);
                if (productToDelete != null)
                {
                    db.Products.Remove(productToDelete);
                    db.SaveChanges();
                }
            }
        }
    }
}
