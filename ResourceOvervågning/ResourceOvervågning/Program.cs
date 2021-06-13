using System;
using System.Linq;
using System.Text;
using ConsoleTables;
using System.Threading.Tasks;
using System.Collections.Generic;

// Nødvendig package der installeres under Tools > NuGet Package Manager > Package Manager Console
// Under konsolen, skriv: Install-Package ConsoleTables -Version 2.4.2

namespace ResourceOvervågning
{
    class Program
    {
        static void Main(string[] args)
        {
            // Opdateringstid: 1 min = 60.000 ms.
            int sleeptime = 5 * 60000;

            // Uendeligt loop
            while (true)
            {
                // Print Resource Tabel.
                ResourceData();
                // Vent 5 Minutter.
                System.Threading.Thread.Sleep(sleeptime);
            }
        }

        static void ResourceData()
        {
            // API Instans.
            DVIMonitor.monitorSoapClient ds = new DVIMonitor.monitorSoapClient();
            
            /* Lager Informationer */
            string mest_solgt = "";
            string over_max   = "";
            // Liste indeholdende stringe (Arrays kan ikke tillægges nye værdier)
            List<string> under_min = new List<string>();
            // Tillæg div. værdier til variablerne.
            foreach(string element in ds.StockItemsMostSold()) { mest_solgt += $"{element.Trim()}"; }
            foreach(string element in ds.StockItemsOverMax()) { over_max += $"{element.Trim()}"; }
            foreach (string element in ds.StockItemsUnderMin()) { under_min.Add(element); }
            string[] u_min = under_min.ToArray();
            // Lager Tabel.
            var lager = new ConsoleTable("Mest Solgte Varer: ", mest_solgt);
            lager.AddRow("Varer Under Minimum: ", under_min[0])
                 .AddRow("", under_min[1])
                 .AddRow("Varer Over Maximum: ", over_max);
            lager.Write(Format.Alternative);

            /* Klima Informationer */
            string lager_temp      = $"Lager: {ds.StockTemp()}°C";
            string lager_fugtighed = $"Lager: {ds.StockHumidity()}%";
            string ude_temp        = $"Ude: {ds.OutdoorTemp()}°C";
            string ude_fugtighed   = $"Ude: {ds.OutdoorHumidity()}%";
            // Klima Tabel
            var klima = new ConsoleTable("[ TEMPERATUR ]", "[ FUGTIGHED ]");
            klima.AddRow(lager_temp, lager_fugtighed)
                 .AddRow(ude_temp, ude_fugtighed);
            klima.Write(Format.Alternative);

            return;
        }
    }
}
