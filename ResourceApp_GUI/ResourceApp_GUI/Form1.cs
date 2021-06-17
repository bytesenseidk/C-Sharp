using System;
using System.Drawing;
using System.Windows.Forms;


namespace ResourceApp_GUI
{
    public partial class window_title : Form
    {
        // Variabel vi kan tilgå i alle metoder.
        DVIMonitor.monitorSoapClient ds = null;

        public window_title()
        {
            InitializeComponent(); // Starter vores GUI

            // try-catch gør at vores applikation vil køre uanset hvad. 
            try // Hvis ikke der er internetforbindelse, vil det ikke være muligt at tilgå DVIMonitor.monitorSoapClient(), dette tjekker vi her.
            {
                ds = new DVIMonitor.monitorSoapClient();
                // Initialiser data i applikationen før timeren starter.
                resource_setup(); // Køre metode
                tid_setup();
            }
            catch // Hvis ikke der er internet, vil try statement'en fejle, og istedetfor at afslutte programmet, vil den køre denne sektion istedetfor.
            {
                fejl_initiator();
            }
        }

        void fejl_initiator()
        {
            string ingen_data = "Data ikke tilgængelig"; // I tilfælde af mangel på internet
            // Klima
            resultat_lager_temp.Text = ingen_data;
            resultat_lager_fugt.Text = ingen_data;
            resultat_ude_temp.Text = ingen_data;
            resultat_ude_fugt.Text = ingen_data;
            // Lager
            resultat_lstatus_min.Text = ingen_data;
            resultat_lstatus_max.Text = ingen_data;
            resultat_lstatus_solgt.Text = ingen_data;
            // Tidszoner
            resultat_tid_kbh.Text = ingen_data;
            resultat_tid_ldn.Text = ingen_data;
            resultat_tid_sgp.Text = ingen_data;
        }
        void resource_setup()
        {
            /*
             * Denne metode henter resource data ned fra DVIMonitor.monitorSoapClient.
             * Initialisere både klima og lagerstatus feldt i applikationen.
             * Bliver først kaldt i window_title metoden for at initialisere applikationen.
             * herefter bliver den kaldt kontinuereligt hvert 5 minut fra timer_resourcer_Tick metoden.
             */
            try
            {
                // Klima 
                double lager_temp = ds.StockTemp();
                double lager_fugt = ds.StockHumidity();
                double ude_temp = ds.OutdoorTemp();
                double ude_fugt = ds.OutdoorHumidity();

                /* Optimale temperature for rødvin */
                if (lager_temp < 10 || lager_temp > 16) // Hvis temperaturene ligger udenfor disse værdier.
                {
                    resultat_lager_temp.ForeColor = Color.Red; // Køres denne kommando.
                }
                else // Hvis temperaturene ligger indenfor disse værdier.
                {
                    resultat_lager_temp.ForeColor = Color.Green; // Køres denne kommando.
                }

                if (lager_fugt < 65 || lager_fugt > 75)
                {
                    resultat_lager_fugt.ForeColor = Color.Red;
                }
                else
                {
                    resultat_lager_fugt.ForeColor = Color.Green;
                }

                // Her ændre vi vores labels inde i applikationen til de hentede informationer.
                resultat_lager_temp.Text = $"{lager_temp}°C";
                resultat_lager_fugt.Text = $"{lager_fugt}%";
                resultat_ude_temp.Text = $"{ude_temp}°C";
                resultat_ude_fugt.Text = $"{ude_fugt}%";

                // Lager
                /* En List fungere som en dynamisk array. 
                 * Dette vil sige vi kan tilføje værdier efter listen er oprettet */
                string over_max = "";
                string mest_solgt = "";
                string under_min = "";

                /* For hvert lager element hentet ned fra DVIMonitor.monitorSoapClient
                 * tillægges værdierne til de respektive variabler */
                foreach (string element in ds.StockItemsUnderMin()) { under_min += $"{element.Trim()}\n"; }
                foreach (string element in ds.StockItemsOverMax()) { over_max += $"{element.Trim()}\n"; }
                foreach (string element in ds.StockItemsMostSold()) { mest_solgt += $"{element.Trim()}\n"; }

                // Ændre farverne på lager indholdet
                resultat_lstatus_min.ForeColor = Color.Red;
                resultat_lstatus_max.ForeColor = Color.Red;
                resultat_lstatus_solgt.ForeColor = Color.Green;

                // Tillægger applikations labels med de respektive værdier
                resultat_lstatus_min.Text = under_min;
                resultat_lstatus_max.Text = over_max;
                resultat_lstatus_solgt.Text = mest_solgt;
            }
            catch
            {
                fejl_initiator();
            }
        }

        void tid_setup()
        {
            try
            {
                TimeZoneInfo kbh, ldn, sgp;
                DateTime kbh_tid, ldn_tid, sgp_tid;

                // Tid i København
                kbh = TimeZoneInfo.FindSystemTimeZoneById("Central European Standard Time"); // Insans af KBH tidszone
                kbh_tid = TimeZoneInfo.ConvertTime(DateTime.Now, kbh); // Konvertere tidszone til et læseligt format
                resultat_tid_kbh.Text = kbh_tid.ToString(); // Ændre label i applikation.

                // Tid i London
                ldn = TimeZoneInfo.FindSystemTimeZoneById("GMT Standard Time");
                ldn_tid = TimeZoneInfo.ConvertTime(DateTime.Now, ldn);
                resultat_tid_ldn.Text = ldn_tid.ToString();

                // Tid i Singapore
                sgp = TimeZoneInfo.FindSystemTimeZoneById("SA Western Standard Time");
                sgp_tid = TimeZoneInfo.ConvertTime(DateTime.Now, sgp);
                resultat_tid_sgp.Text = sgp_tid.ToString();
            }
            catch
            {
                fejl_initiator();
            }
        }

        // Timere der kontinuereligt kalder vores metoder indenfor deres intervaller.
        private void timer_resourcer_Tick(object sender, EventArgs e)
        {
            // Interval: 5 min >> 300.000 ms.
            resource_setup();
        }
        private void timer_konstant_Tick(object sender, EventArgs e)
        {
            // Interval 1 sekund >> 1000 ms. 
            tid_setup();
        }

        // Disse metoder er EventHandlers, uden disse, kan vi ikke ændre vores lables i applikationen.
        private void resultat_lager_temp_TextChanged(object sender, EventArgs e) { }
        private void resultat_lager_fugt_TextChanged(object sender, EventArgs e) { }
        private void resultat_ude_temp_TextChanged(object sender, EventArgs e) { }
        private void resultat_ude_fugt_TextAlignChanged(object sender, EventArgs e) { }
        private void resultat_lstatus_min_TextChanged(object sender, EventArgs e) { }
        private void resultat_lstatus_max_TextChanged(object sender, EventArgs e) { }
        private void resultat_lstatus_solgt_TextChanged(object sender, EventArgs e) { }
        private void resultat_tid_kbh_TextChanged(object sender, EventArgs e) { }
        private void resultat_tid_ldn_TextChanged(object sender, EventArgs e) { }
        private void resultat_tid_sgp_TextChanged(object sender, EventArgs e) { }
    }
}
