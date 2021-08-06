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
    public partial class frmYonetici : Form
    {
        public frmYonetici()
        {
            InitializeComponent();
        }
        public string YoneticiAd = "";
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        sqlBaglanti bgl = new sqlBaglanti();
        private void frmYonetici_Load(object sender, EventArgs e)
        {
            label2.Text = YoneticiAd;
            SqlCommand komut = new SqlCommand("select * from TBLSİPARİŞLER WHERE DURUM=0", bgl.baglanti());
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            bgl.baglanti().Close();


            SqlCommand komut2 = new SqlCommand("select * from TBLSİPARİŞLER WHERE DURUM=1", bgl.baglanti());
            SqlDataAdapter da2 = new SqlDataAdapter(komut2);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            dataGridView2.DataSource = dt2;
            bgl.baglanti().Close();


            SqlCommand komut3 = new SqlCommand("select * from TBLŞOFÖRLER  ", bgl.baglanti());
            SqlDataAdapter da3 = new SqlDataAdapter(komut3);
            DataTable dt3 = new DataTable();
            da3.Fill(dt3);
            dataGridView3.DataSource = dt3;
            bgl.baglanti().Close();


            SqlCommand komut4 = new SqlCommand("select * from TBLMUSTERILER ", bgl.baglanti());
            SqlDataAdapter da4 = new SqlDataAdapter(komut4);
            DataTable dt4 = new DataTable();
            da4.Fill(dt4);
            dataGridView4.DataSource = dt4;
            bgl.baglanti().Close();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmSoförEkle fr = new frmSoförEkle();
            fr.Show();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            frmIstatistikler fr = new frmIstatistikler();
            fr.Show();
        }


        private void button8_Click(object sender, EventArgs e)
        {
            frmAdminEkle fr = new frmAdminEkle();
            fr.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            frmSikayet fr = new frmSikayet();
            fr.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmSehirİslemleri fr = new frmSehirİslemleri();
            fr.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmYoneticiTabanliKullaniciEkle fr = new frmYoneticiTabanliKullaniciEkle();
            fr.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            frmTur fr = new frmTur();
            fr.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("select * from TBLSİPARİŞLER WHERE DURUM=0", bgl.baglanti());
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            bgl.baglanti().Close();


            SqlCommand komut2 = new SqlCommand("select * from TBLSİPARİŞLER WHERE DURUM=1", bgl.baglanti());
            SqlDataAdapter da2 = new SqlDataAdapter(komut2);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            dataGridView2.DataSource = dt2;
            bgl.baglanti().Close();


            SqlCommand komut3 = new SqlCommand("select * from TBLŞOFÖRLER  ", bgl.baglanti());
            SqlDataAdapter da3 = new SqlDataAdapter(komut3);
            DataTable dt3 = new DataTable();
            da3.Fill(dt3);
            dataGridView3.DataSource = dt3;
            bgl.baglanti().Close();


            SqlCommand komut4 = new SqlCommand("select * from TBLMUSTERILER ", bgl.baglanti());
            SqlDataAdapter da4 = new SqlDataAdapter(komut4);
            DataTable dt4 = new DataTable();
            da4.Fill(dt4);
            dataGridView4.DataSource = dt4;
            bgl.baglanti().Close();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            frmGiris fr = new frmGiris(); fr.Show();
            this.Hide();
        }
    }
}
