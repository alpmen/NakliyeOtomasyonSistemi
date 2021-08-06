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
    public partial class frmSoför : Form
    {
        public frmSoför()
        {
            InitializeComponent();
        }
        sqlBaglanti bgl = new sqlBaglanti();
        public string şoförAdi="";
        private void button2_Click(object sender, EventArgs e)
        {
            frmweb fr = new frmweb();
            fr.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmGiris fr = new frmGiris();
            fr.Show();
            this.Hide();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmSikayet fr = new frmSikayet();
            fr.Show();
        }

        private void frmŞoför_Load(object sender, EventArgs e)
        {
            label2.Text = şoförAdi;
            SqlCommand komut = new SqlCommand("select * from TBLSİPARİŞLER where ŞOFÖR = @p1 and DURUM=0", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", label2.Text);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            bgl.baglanti().Close();

            SqlCommand komut2 = new SqlCommand("select * from TBLSİPARİŞLER where ŞOFÖR = @p2 and DURUM=1", bgl.baglanti());
            komut2.Parameters.AddWithValue("@p2", label2.Text);
            SqlDataAdapter da2 = new SqlDataAdapter(komut2);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            dataGridView2.DataSource = dt2;
            bgl.baglanti().Close();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime zaman = DateTime.Now;
            label3.Text = zaman.ToString();
        }
    }
}
