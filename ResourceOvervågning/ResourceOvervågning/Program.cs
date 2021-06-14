using System;
using System.Linq;
using System.Text;
using System.Xml;
using ConsoleTables;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.ServiceModel.Syndication;

/* Nødvendig package der installeres under "Tools > NuGet Package Manager > Package Manager Console"
   Under konsolen, skriv: "Install-Package ConsoleTables -Version 2.4.2" */

namespace ResourceOvervågning
{
    class Program
    {
        static void Main(string[] args)
        {
            Nyheder();
            while (true) // Uendeligt loop
            {
                break;
                // ResourceData(); // Print Resource Tabel.
            }
            Console.ReadKey();
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

        static void Nyheder()
        {
            string url = "https://nordjyske.dk/rss/nyheder";
            string titel = "";
            string beskrivelse = "";
            string nyhed = "";

            try // Prøver at køre følgende kode, hvis der opstår en fejl, fx ingen data (mangel på internet) springer den videre til "catch".
            {
                XmlReader reader = XmlReader.Create(url); // Reader objekt til at indlæse URL.
                SyndicationFeed feed = SyndicationFeed.Load(reader); // Parser reader object til et håndtereligt object.

                foreach (SyndicationItem elm in feed.Items) // Looper igennem hver artikel.
                {
                    titel += elm.Title.Text.Trim(); // Tillægger titel fra artikel til titel variabel, samt fjerner overflødige whitespaces.
                    beskrivelse += elm.Summary.Text.Trim();
                }
            } catch // Bliver kørt hvis try statementen fejler.
            {
                titel = "Data ikke tilgængelig, tjek internet-forbindelse..";
                beskrivelse = titel;
            } finally // Når enten try eller catch sektionen er kørt, vil denne sektion køre (Den vil altid køre)
            {
                nyhed += $"{titel} {beskrivelse}".Replace("\n", ""); // Fjerner newlines fra tekst
            }
            
            char[] temp_nyhed = nyhed.ToCharArray(); // Convertere string til character array
            int terminal_start = 0;
            int terminal_slut = Console.WindowWidth;
            foreach(char cha in temp_nyhed)
            {
                Console.Write($"{cha}");
            }
        }
    }
}
