using System;
using System.Linq;

namespace ProductManager { 
class Program
{
    static void Main()
    {
        using (var db = new ProductContext())
        {
            
            // Create
            Console.WriteLine("Adding new products...");
            db.Products.Add(new Product { Id = 1, Name = "Product1", Price = 10.99m });
            db.Products.Add(new Product { Id = 2, Name = "Product2", Price = 20.49m });
            db.SaveChanges();
                
                // Read
                Console.WriteLine("Querying for all products:");
                var products = db.Products.ToList();
                foreach (var product in products)
                {
                    Console.WriteLine($"Id: {product.Id}, Name: {product.Name}, Price: {product.Price}");
                }

                // Update
                Console.WriteLine("Updating the price of the first product...");
                var productToUpdate = db.Products.FirstOrDefault(p => p.Id == 1);
                if (productToUpdate != null)
                {
                    productToUpdate.Price = 15.99m;
                    db.SaveChanges();
                }

                // Delete
                Console.WriteLine("Deleting the second product...");
                var productToDelete = db.Products.FirstOrDefault(p => p.Id == 2);
                if (productToDelete != null)
                {
                    db.Products.Remove(productToDelete);
                    db.SaveChanges();
                }

                // Read again
                Console.WriteLine("Querying for all products after modifications:");
                products = db.Products.ToList();
                foreach (var product in products)
                {
                    Console.WriteLine($"Id: {product.Id}, Name: {product.Name}, Price: {product.Price}");
                }
                
            }
        }
}
}
