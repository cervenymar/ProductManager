using Microsoft.EntityFrameworkCore;
using ProductManager;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManager
{
    class DatabaseControl
    {
        public static void CreateRecord(int Id, string name, decimal price)
        {
            try
            {
                using (var db = new ProductContext())
                {
                    
                    var productToCreate = db.Products.FirstOrDefault(p => p.Id == Id);
                    if (productToCreate == null)
                    {
                        // Create
                        Console.WriteLine($"Adding Product {name} into products...");
                        db.Products.Add(new Product { Id = Id, Name = name, Price = price });
                    }
                    else
                    {
                        Console.WriteLine($"Product with ID = {Id} already exists. Updating product.");
                        UpdateRecords(Id, name, price);
                    }
                    db.SaveChanges();
                }
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine($"Error creating record: {ex.Message}");
            }
            catch (DbEntityValidationException ex)
            {
                Console.WriteLine($"DbEntityValidationException: {ex.Message}");
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"InvalidOperationException: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating record: {ex.Message}");
            }
        }

        public static void ReadRecords()
        {
            try
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
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"InvalidOperationException: {ex.Message}");
            }
            catch (EntityException ex)
            {
                Console.WriteLine($"EntityException: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading records: {ex.Message}");
            }
        }

        public static void UpdateRecords(int Id, string name, decimal price)
        {
            try
            {

                using (var db = new ProductContext())
                {
                    // Update
                    Console.WriteLine($"Updating the price of Product with Id = {Id}");
                    var productToUpdate = db.Products.FirstOrDefault(p => p.Id == Id);
                    if (productToUpdate != null)
                    {
                        productToUpdate.Name = name;
                        productToUpdate.Price = (decimal)price;
                        db.SaveChanges();
                    }
                }
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine($"DbUpdateException: {ex.Message}");
            }
            catch (DbEntityValidationException ex)
            {
                Console.WriteLine($"DbEntityValidationException: {ex.Message}");
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"InvalidOperationException: {ex.Message}");

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating record: {ex.Message}");
            }
        }

        public static void DeleteRecords(int Id)
        {
            try
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
            catch (DbUpdateException ex)
            {
                Console.WriteLine($"DbUpdateException: {ex.Message}");
            }
            catch (DbEntityValidationException ex)
            {
                Console.WriteLine($"DbEntityValidationException: {ex.Message}");
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"InvalidOperationException: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting record: {ex.Message}");
            }
        }
    }
}
