using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Data.SqlClient;

namespace NakliyeciOtomasyonSistemi
{
    public partial class frmWeatherAppcs : Form
    {
        public frmWeatherAppcs()
        {
            InitializeComponent();
        }
        sqlBaglanti bgl = new sqlBaglanti();

        private void frmWeatherAppcs_Load(object sender, EventArgs e)
        {
            label2.Text = DateTime.Now.ToShortDateString();

            SqlCommand komut = new SqlCommand("select * from TBLSEHİR",bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr[1]);
            }
            bgl.baglanti().Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string api = "a89628607be204417aed37bea3dfb38f";
            string connection =
                "https://api.openweathermap.org/data/2.5/weather?q=" + comboBox1.Text.ToLower() + "&mode=xml&lang=tr&units=metric&appid=" + api;
            XDocument weather = XDocument.Load(connection);
            var temp = weather.Descendants("temperature").ElementAt(0).Attribute("value").Value;
            var state = weather.Descendants("weather").ElementAt(0).Attribute("value").Value;
            var nem= weather.Descendants("humidity").ElementAt(0).Attribute("value").Value;
            var rüzgar= weather.Descendants("speed").ElementAt(0).Attribute("value").Value;
            label1.Text = "Sıcaklık: "+temp +" ' ";
            label5.Text = "Durum: " + state;
            label6.Text = "Nem: " + nem+" %";
            label7.Text = "Rüzgar: " + rüzgar + " m/s";

        }
    }
}
