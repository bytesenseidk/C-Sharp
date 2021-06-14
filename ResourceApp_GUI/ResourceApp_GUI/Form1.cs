using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ResourceApp_GUI
{
    public partial class window_title : Form
    {
        public window_title()
        {
            InitializeComponent();

            DVIMonitor.monitorSoapClient ds = new DVIMonitor.monitorSoapClient();
            string ingen_data = "Data ikke tilgængelig";

            klima_setup(ds, ingen_data);
            lager_setup(ds, ingen_data);
            tid_setup(ds, ingen_data);
        }

        void klima_setup(DVIMonitor.monitorSoapClient ds, string ingen_data)
        {
            try
            {
                double lager_temp = ds.StockTemp();
                double lager_fugt = ds.StockHumidity();
                double ude_temp = ds.OutdoorTemp();
                double ude_fugt = ds.OutdoorHumidity();

                if (lager_temp < 10 || lager_temp > 16) 
                {
                    resultat_lager_temp.ForeColor = Color.Red;
                } 
                else 
                {
                    resultat_lager_temp.ForeColor = Color.Green;
                }

                if (lager_fugt < 65 || lager_fugt > 75) 
                {
                    resultat_lager_fugt.ForeColor = Color.Red;
                } 
                else 
                {
                    resultat_lager_fugt.ForeColor = Color.Green;
                }

                resultat_lager_temp.Text = $"{lager_temp}°C";
                resultat_lager_fugt.Text = $"{lager_fugt}%";
                resultat_ude_temp.Text = $"{ude_temp}°C";
                resultat_ude_fugt.Text = $"{ude_fugt}%";
            }
            catch
            {
                resultat_lager_temp.Text = ingen_data;
                resultat_lager_fugt.Text = ingen_data;
                resultat_ude_temp.Text = ingen_data;
                resultat_ude_fugt.Text = ingen_data;
            }
        }
        private void resultat_lager_temp_TextChanged(object sender, EventArgs e){}
        private void resultat_lager_fugt_TextChanged(object sender, EventArgs e){}
        private void resultat_ude_temp_TextChanged(object sender, EventArgs e){}
        private void resultat_ude_fugt_TextAlignChanged(object sender, EventArgs e){}

        void lager_setup(DVIMonitor.monitorSoapClient ds, string ingen_data)
        {    
            try
            {
                List<string> temp_min = new List<string>();
                string over_max = "";
                string mest_solgt = "";

                foreach (string element in ds.StockItemsUnderMin()) { temp_min.Add(element); }
                foreach (string element in ds.StockItemsOverMax()) { over_max += $"{element.Trim()}"; }
                foreach (string element in ds.StockItemsMostSold()) { mest_solgt += $"{element.Trim()}"; }
                
                string[] under_min = temp_min.ToArray();

                resultat_lstatus_min.ForeColor = Color.Red;
                resultat_lstatus_max.ForeColor = Color.Red;
                resultat_lstatus_solgt.ForeColor = Color.Green;

                resultat_lstatus_min.Text = $"{under_min[0]}\n{under_min[1]}";
                resultat_lstatus_max.Text = over_max;
                resultat_lstatus_solgt.Text = mest_solgt;
            }
            catch
            {
                resultat_lstatus_min.Text = ingen_data;
                resultat_lstatus_max.Text = ingen_data;
                resultat_lstatus_solgt.Text = ingen_data;
            }
        }
        private void resultat_lstatus_min_TextChanged(object sender, EventArgs e){}
        private void resultat_lstatus_max_TextChanged(object sender, EventArgs e){}
        private void resultat_lstatus_solgt_TextChanged(object sender, EventArgs e){}

        void tid_setup(DVIMonitor.monitorSoapClient ds, string ingen_data)
        {
            try
            {
                resultat_tid_kbh.Text = DateTime.Now.ToString("HH:mm:ss");
                resultat_tid_ldn.Text = DateTime.Now.AddHours(-1).ToString("HH:mm:ss");
                resultat_tid_sgp.Text = DateTime.Now.AddHours(2).ToString("HH:mm:ss");
            }
            catch
            {
                resultat_tid_kbh.Text = ingen_data;
                resultat_tid_ldn.Text = ingen_data;
                resultat_tid_sgp.Text = ingen_data;
            }
        }

        private void resultat_tid_kbh_TextChanged(object sender, EventArgs e){}
        private void resultat_tid_ldn_TextChanged(object sender, EventArgs e){}
        private void resultat_tid_sgp_TextChanged(object sender, EventArgs e){}
    }
}
