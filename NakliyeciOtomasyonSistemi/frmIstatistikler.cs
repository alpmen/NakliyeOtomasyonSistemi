using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace NakliyeciOtomasyonSistemi
{
    public partial class frmIstatistikler : Form
    {
        public frmIstatistikler()
        {
            InitializeComponent();
        }
        sqlBaglanti bgl = new sqlBaglanti();
        private void frmIstatistikler_Load(object sender, EventArgs e)
        {

            //TOPLAM GELİR

            int gelir = 0;
            int gider = 0;
            SqlCommand komut = new SqlCommand("select sum(ÜCRET) from TBLSİPARİŞLER ",bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                label12.Text = dr[0]+" TL";
                gelir = Convert.ToInt32(dr[0].ToString());
            }
            bgl.baglanti().Close();

            //TOPLAM MAAŞ GİDERİ

            SqlCommand komut2 = new SqlCommand("select sum(MAAŞ) from TBLŞOFÖRLER", bgl.baglanti());
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read()) {
                label13.Text = dr2[0] + " TL";
                gider = Convert.ToInt32(dr2[0].ToString());
            }
            bgl.baglanti().Close();

            //NET CİRO

            label8.Text = (gelir - gider).ToString();

            //MÜŞTERİ SAYISI

            SqlCommand komut3 = new SqlCommand("select count(ID) from TBLMUSTERILER", bgl.baglanti());
            SqlDataReader dr3 = komut3.ExecuteReader();
            while (dr3.Read())
            {
                label14.Text = dr3[0].ToString();
            }
            bgl.baglanti().Close();

            //İL SAYISI

            SqlCommand komut4 = new SqlCommand("select count(ID) from TBLSEHİR", bgl.baglanti());
            SqlDataReader dr4 = komut4.ExecuteReader();
            while (dr4.Read())
            {
                label15.Text = dr4[0].ToString();
            }
            bgl.baglanti().Close();

            //ORTALAMA ŞOFÖR MAAŞI

            SqlCommand komut5 = new SqlCommand("select avg(MAAŞ) from TBLŞOFÖRLER", bgl.baglanti());
            SqlDataReader dr5 = komut5.ExecuteReader();
            while (dr5.Read())
            {
                label16.Text = dr5[0].ToString();
            }
            bgl.baglanti().Close();

            //EN YÜKSEK ŞOFÖR MAAŞI:

            SqlCommand komut6 = new SqlCommand("select max(MAAŞ) from TBLŞOFÖRLER", bgl.baglanti());
            SqlDataReader dr6 = komut6.ExecuteReader();
            while (dr6.Read())
            {
                label17.Text = dr6[0].ToString();
            }
            bgl.baglanti().Close();

            //EN DÜŞÜK ŞOFÖR MAAŞI:

            SqlCommand komut7 = new SqlCommand("select min(MAAŞ) from TBLŞOFÖRLER", bgl.baglanti());
            SqlDataReader dr7 = komut7.ExecuteReader();
            while (dr7.Read())
            {
                label18.Text = dr7[0].ToString();
            }
            bgl.baglanti().Close();

            //TOPLAM ŞOFÖR SAYISI

            SqlCommand komut8 = new SqlCommand("select count(ID) from TBLŞOFÖRLER", bgl.baglanti());
            SqlDataReader dr8 = komut8.ExecuteReader();
            while (dr8.Read())
            {
                label20.Text = dr8[0].ToString();
            }
            bgl.baglanti().Close();

            //TOPLAM YOL

            SqlCommand komut9 = new SqlCommand("select sum(YOLUZUNLUĞU) from TBLSİPARİŞLER", bgl.baglanti());
            SqlDataReader dr9 = komut9.ExecuteReader();
            while (dr9.Read())
            {
                label21.Text = dr9[0].ToString();
            }
            bgl.baglanti().Close();

            //TOPLAM YÖNETİCİ SAYISI

            SqlCommand komut10 = new SqlCommand("select COUNT(ID) from TBLYONETİCİLER", bgl.baglanti());
            SqlDataReader dr10 = komut10.ExecuteReader();
            while (dr10.Read())
            {
                label22.Text = dr10[0].ToString();
            }
            bgl.baglanti().Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmGrafikler fr = new frmGrafikler();
            fr.Show();
        }
    }
}
