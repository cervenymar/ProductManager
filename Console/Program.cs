using System;
using System.Diagnostics;
using System.Linq;
using System.Xml.Linq;
using ProductManager;

namespace ProductManager
{
    class Program
    {
        static async Task Main(string[] args)
        {
            /*
            * Read Data from API and print to Console
            */
            string apiUrl = "https://jsonplaceholder.typicode.com/users";
            await ApiService.GetAndDisplayUserData(apiUrl);

            /*
             * Current Data backup
             * Data saved into ./products_{timestamp}.txt
             * 
             */
            string timestamp = DateTime.Now.ToString("yyyyMMddHHmm");
            ProductRW.ExportProducts(timestamp); //Current data backup

           
            


            /*
             * 
             * 
             */
            string sCurrentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string sFile = System.IO.Path.Combine(sCurrentDirectory, @"../../../products.txt");
            if (File.Exists(sFile))
            {
                ProductRW.ImportProducts(sFile);                
            }


            
            
            DatabaseControl.ReadRecords();           
            
        }
    }
}
