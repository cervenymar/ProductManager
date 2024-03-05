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
                // Zaslat GET požadavek na daný API endpoint
                
                HttpResponseMessage response = await client.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    // Přečíst obsah odpovědi jako řetězec
                    string jsonContent = await response.Content.ReadAsStringAsync();

                    // Deserializovat JSON data do pole objektů User
                    User[] users = JsonConvert.DeserializeObject<User[]>(jsonContent);

                    // Zobrazit relevantní informace
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


    
    
    


    