using System;
using System.Linq;
using System.Text;
using ConsoleTables;
using System.Threading.Tasks;
using System.Collections.Generic;

/* Nødvendig package der installeres under "Tools > NuGet Package Manager > Package Manager Console"
   Under konsolen, skriv: "Install-Package ConsoleTables -Version 2.4.2" */

namespace ResourceOvervågning
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true) // Uendeligt loop
            {
                ResourceData(); // Print Resource Tabel.
            }
        }

        static void ResourceData()
        {
            DVIMonitor.monitorSoapClient ds = new DVIMonitor.monitorSoapClient(); // API Instans.
            
            int sleeptime = 5 * 60000; // Opdateringstid: 1 min = 60.000 ms.

            /* Lager Informationer */
            string mest_solgt = "";
            string over_max   = "";
            
            List<string> under_min = new List<string>(); // Liste indeholdende stringe (Arrays kan ikke tillægges nye værdier)
            
            /* Tillæg div. værdier til variablerne. */
            foreach (string element in ds.StockItemsMostSold()) { mest_solgt += $"{element.Trim()}"; }
            foreach(string element in ds.StockItemsOverMax()) { over_max += $"{element.Trim()}"; }
            foreach (string element in ds.StockItemsUnderMin()) { under_min.Add(element); }
            string[] u_min = under_min.ToArray();
            
            var lager = new ConsoleTable("Mest Solgte Varer: ", mest_solgt); // Lager Tabel.
            lager.AddRow("Varer Over Maximum: ", over_max)
                 .AddRow("Varer Under Minimum: ", under_min[0])
                 .AddRow("", under_min[1]);
            lager.Write(Format.Alternative);

            /* Klima Informationer */
            string lager_temp      = $"Lager: {ds.StockTemp()}°C";
            string lager_fugtighed = $"Lager: {ds.StockHumidity()}%";
            string ude_temp        = $"Ude: {ds.OutdoorTemp()}°C";
            string ude_fugtighed   = $"Ude: {ds.OutdoorHumidity()}%";
            
            var klima = new ConsoleTable("[ TEMPERATUR ]", "[ FUGTIGHED ]"); // Klima Tabel
            klima.AddRow(lager_temp, lager_fugtighed)
                 .AddRow(ude_temp, ude_fugtighed);
            klima.Write(Format.Alternative);

            System.Threading.Thread.Sleep(sleeptime); // Vent 5 Minutter.

            return;
        }
    }
}
