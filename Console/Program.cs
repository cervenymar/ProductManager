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
            await ApiService.GetAndDisplayUserData();
            //decimal test = 420.69m;
            //DatabaseControl.CreateRecord("Test39", test);
            //DatabaseControl.UpdateRecords(12, 69.420);
            //DatabaseControl.DeleteRecords(7);
            //DatabaseControl.ReadRecords();           
            
        }
    }
}
