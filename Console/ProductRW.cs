using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using System.Collections.Generic;
using Newtonsoft.Json;
using JsonException = Newtonsoft.Json.JsonException;
using NuGet.Protocol.Core.Types;

namespace ProductManager
{
    public class ProductRW
    {
        public static void ImportProducts(string filePath)
        {
            try
            {


                string jsonContent = File.ReadAllText(filePath);
                List<Product> products = JsonConvert.DeserializeObject<List<Product>>(jsonContent);


                foreach (Product product in products)
                {                    
                    Console.WriteLine($"Id: {product.Id}, Name: {product.Name}, Price: {product.Price}");
                    DatabaseControl.CreateRecord(product.Id, product.Name, product.Price);
                }
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine($"FileNotFoundException: {ex.Message}");
                // Handle or log the specific exception
                
            }
            catch (JsonException ex)
            {
                Console.WriteLine($"JsonException: {ex.Message}");
                // Handle or log the specific exception
                
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading products from file: {ex.Message}");
                
            }
        }


        public static void ExportProducts(string timestamp)
        {
            try
            {                
                string sCurrentDirectory = AppDomain.CurrentDomain.BaseDirectory;
                string sFile = System.IO.Path.Combine(sCurrentDirectory, $@"../../../products_{timestamp}.txt");
                string outputFilePath = Path.GetFullPath(sFile);
                using (var db = new ProductContext())
                {
                    // Read
                    Console.WriteLine("Querying for all products:");
                    var products = db.Products.ToList();

                    // Write to file
                    try
                    {
                        // Serialize the list of products to JSON
                        string jsonContent = System.Text.Json.JsonSerializer.Serialize(products);

                        // Write JSON content to the specified file
                        File.WriteAllText(outputFilePath, jsonContent);

                        Console.WriteLine($"Successfully wrote products to file: {outputFilePath}");
                    }
                    catch (UnauthorizedAccessException ex)
                    {
                        Console.WriteLine($"UnauthorizedAccessException: {ex.Message}");
                        // Handle or log the specific exception
                    }
                    catch (IOException ex)
                    {
                        Console.WriteLine($"IOException: {ex.Message}");
                        // Handle or log the specific exception
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error writing products to file: {ex.Message}");
                    }

                    // Display products in the console
                    /*foreach (var product in products)
                    {
                        Console.WriteLine($"Id: {product.Id}, Name: {product.Name}, Price: {product.Price}");
                    }*/
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error querying products from the database: {ex.Message}");
            }
        }
    }
}
