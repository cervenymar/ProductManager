using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ProductManager
{
    public class ApiService
    {
        public static async Task GetAndDisplayUserData(string apiUrl)
        {
            using (HttpClient client = new HttpClient())
            {
                // Send GET request to API endpoint {apiURL}
                
                HttpResponseMessage response = await client.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    // Read content
                    string jsonContent = await response.Content.ReadAsStringAsync();

                    // Deserialize JSON data into an Array
                    User[] users = JsonConvert.DeserializeObject<User[]>(jsonContent);

                    // Print data to console
                    foreach (var user in users)
                    {
                        Console.WriteLine($"User ID: {user.Id}");
                        Console.WriteLine($"Name: {user.Name}");
                        Console.WriteLine($"Username: {user.Username}");
                        Console.WriteLine($"Email: {user.Email}");
                        Console.WriteLine();
                    }
                }
                else
                {
                    Console.WriteLine($"Chyba při získávání dat. Kód odpovědi: {response.StatusCode}");
                }
            }
        }
    }
}


    
    
    


    