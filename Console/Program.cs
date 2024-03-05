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
             * Backup Current Data
             * Data saved into ./products_{timestamp}.txt
             * 
             */
            string timestamp = DateTime.Now.ToString("yyyyMMddHHmm");
            ProductRW.ExportProducts(timestamp); //Current data backup

           
            


            /*
             * 
             * Import information from products.txt into the database.
             * Records with new IDs will be addded, if the IDs in the file match existing IDs in Database -> Data will be overwritten.
             * 
             */
            string sCurrentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string sFile = System.IO.Path.Combine(sCurrentDirectory, @"../../../products.txt");
            if (File.Exists(sFile))
            {
                ProductRW.ImportProducts(sFile);                
            }
            Console.Write("#############");
            DatabaseControl.ReadRecords();

            /*
             * 
             * Remove record with ID = 1
             * 
             */
            DatabaseControl.DeleteRecords(1);
            Console.Write("#############");
            DatabaseControl.ReadRecords();

        }
    }
}
