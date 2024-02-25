using System;
using System.Diagnostics;
using System.Linq;
using System.Xml.Linq;
using ProductManager;

namespace ProductManager
{
    class Program
    {
        static void Main(string[] args)
        {
            
                decimal test = 15.9m;
                DatabaseControl.CreateRecord("Test", test);
                DatabaseControl.ReadRecords();           
            
        }
    }
}
