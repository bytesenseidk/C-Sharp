using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceOvervågning
{
    class Program
    {
        static void Main(string[] args)
        {

            Dictionary<string, string> data = ResourceData();
            Console.WriteLine(data["Lager"]);
            Console.WriteLine("\n\n");
            Console.WriteLine(data["Klima"]);

            Console.Write("Press any key to continue...");
            Console.ReadKey();
        }

        static Dictionary<string, string> ResourceData()
        {
            DVIMonitor.monitorSoapClient ds = new DVIMonitor.monitorSoapClient();

            // Lager Informationer
            string varer = "=====================[ Varelager ]=====================\n";
            varer += "\n_____________________[ Mest Solgt ]____________________\n";
            foreach (string element in ds.StockItemsMostSold()) { varer += $"{element}\n"; }
            varer += "\n____________________[ Over Maximum ]___________________\n";
            foreach (string element in ds.StockItemsOverMax()) { varer += $"{element}\n"; }
            varer += "\n___________________[ Under Minimum ]___________________\n";
            foreach (string element in ds.StockItemsUnderMin()) { varer += $"{element}\n"; }

            // Klima Informationer
            string klima = "========================[ Klima ]======================\n";
            klima += "\n________________________[ Lager ]______________________\n";
            klima += $"Temperatur: {ds.StockTemp()}°C\n";
            klima += $"Fugtighed:  {ds.StockHumidity()}%\n";
            klima += "_______________________[ Udendørs ]____________________\n";
            klima += $"Temperatur: {ds.OutdoorTemp()}°C\n";
            klima += $"Fugtighed:  {ds.OutdoorHumidity()}%\n";

            Dictionary<string, string> resultater = new Dictionary<string, string>
            {
                {"Lager", varer},
                {"Klima", klima }
            };

            return resultater;
        }
    }
}



/*static Dictionary<string, string> MonitorData(string key)
{
    //  Instans af monitorSoapClient (Online Data)
    DVIMonitor.monitorSoapClient ds = new DVIMonitor.monitorSoapClient();

    // Lager Informationer
    string varer = "========================[ Varelager ]======================\n";
    varer += "\n_____________________[ Mest Solgt ]____________________\n";
    foreach (string element in ds.StockItemsMostSold()) { varer += $"{element}\n\n"; }
    varer += "\n____________________[ Over Maximum ]___________________\n";
    foreach (string element in ds.StockItemsOverMax()) { varer += $"{element}\n\n"; }
    varer += "\n___________________[ Under Minimum ]___________________\n";
    foreach (string element in ds.StockItemsUnderMin()) { varer += $"{element}\n"; }

    // Klima Informationer
    string klima = "========================[ Lager Klima ]======================\n";
    klima += "\n_____________________[ Temperatur ]____________________\n";
    foreach (string element in ds.StockTemp().ToString() { klima += $"{element}\n\n"; }
    klima += "\n____________________[ Fugtighed ]___________________\n";
    foreach (string element in ds.StockHumidity().ToString() { klima += $"{element}\n\n"; }

    string klima = "========================[ Udendørs Klima ]======================\n";
    klima += "\n_____________________[ Temperatur ]____________________\n";
    foreach (string element in ds.OutdoorTemp().ToString() { klima += $"{element}\n\n"; }
    klima += "\n____________________[ Fugtighed ]___________________\n";
    foreach (string element in ds.OutdoorHumidity().ToString() { klima += $"{element}\n\n"; }

    Dictionary<string, string> monitor_data = new Dictionary<string, string>()
    {
        {"lager", varer},
        {"klima", klima}
    };

    return monitor_data[key];
} */

/*

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitorService
{
    class Program
    {
        static void Main(string[] args)
        {
            string lager_data = monitorData("lager");
            string klima_data = monitorData("klima");

            Console.WriteLine(klima_data);

            Console.WriteLine("\n\nPress Enter to continue..");
            Console.ReadLine();
        }

        static Dictionary<string, string> MonitorData(string key)
        {
            
              //  Instans af monitorSoapClient (Online Data)
             

DVIService.monitorSoapClient ds = new DVIService.monitorSoapClient();

// Lager Informationer
string varer = "========================[ Varelager ]======================\n";
varer += "\n_____________________[ Mest Solgt ]____________________\n";
foreach (string element in ds.StockItemsMostSold()) { varer += $"{element}\n\n"; }
varer += "\n____________________[ Over Maximum ]___________________\n";
foreach (string element in ds.StockItemsOverMax()) { varer += $"{element}\n\n"; }
varer += "\n___________________[ Under Minimum ]___________________\n";
foreach (string element in ds.StockItemsUnderMin()) { varer += $"{element}\n"; }

// Klima Informationer
string klima = "========================[ Lager Klima ]======================\n";
klima += "\n_____________________[ Temperatur ]____________________\n";
foreach (string element in ds.StockTemp()) { klima += $"{element}\n\n"; }
klima += "\n____________________[ Fugtighed ]___________________\n";
foreach (string element in ds.StockHumidity()) { klima += $"{element}\n\n"; }

string klima = "========================[ Udendørs Klima ]======================\n";
klima += "\n_____________________[ Temperatur ]____________________\n";
foreach (string element in ds.OutdoorTemp()) { klima += $"{element}\n\n"; }
klima += "\n____________________[ Fugtighed ]___________________\n";
foreach (string element in ds.OutdoorHumidity()) { klima += $"{element}\n\n"; }

Dictionary<string, string> monitor_data = new Dictionary<string, string>()
            {
                {"lager", varer},
                {"klima", klima}
            };

return monitor_data[key];
        }
    }
}


*/