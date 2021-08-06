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
    public partial class frmGiris : Form
    {
        public frmGiris()
        {
            InitializeComponent();
        }
        sqlBaglanti bgl = new sqlBaglanti();

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmKullaniciEkle fr = new frmKullaniciEkle();
            fr.Show();
        }

        

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox3.Text != "" && textBox4.Text != "")
            {
                SqlCommand komut = new SqlCommand("select * from TBLYONETİCİLER where AD=@p1 and ŞİFRE=@p2", bgl.baglanti());
                komut.Parameters.AddWithValue("@p1", textBox4.Text);
                komut.Parameters.AddWithValue("@p2", textBox3.Text);
                SqlDataReader rd = komut.ExecuteReader();
                if (rd.Read())
                {
                    frmYonetici fr = new frmYonetici();
                    fr.YoneticiAd = textBox4.Text;
                    fr.Show();
                    this.Hide();
                }
                else
                    MessageBox.Show("HATALI ŞİFRE VEYA T.C.");
                textBox2.Text = "";
                textBox1.Text = "";
            }
            else MessageBox.Show("Lütfen Alanları Doldurun");

            bgl.baglanti().Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                SqlCommand komut = new SqlCommand("select * from TBLMUSTERILER where AD=@p1 and ŞİFRE=@p2", bgl.baglanti());
                komut.Parameters.AddWithValue("@p1", textBox1.Text);
                komut.Parameters.AddWithValue("@p2", textBox2.Text);
                SqlDataReader rd = komut.ExecuteReader();
                if (rd.Read())
                {
                    frmKullanici fr = new frmKullanici();
                    fr.musteriAd = textBox1.Text;
                    fr.Show();
                    this.Hide();
                }
                else
                    MessageBox.Show("HATALI ŞİFRE VEYA T.C.");
                textBox2.Text = "";
                textBox1.Text = "";
            }
            else MessageBox.Show("Lütfen Alanları Doldurun");

            bgl.baglanti().Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox5.Text != "" && textBox6.Text != "")
            {
                SqlCommand komut = new SqlCommand("select * from TBLŞOFÖRLER where AD=@p1 and ŞİFRE=@p2", bgl.baglanti());
                komut.Parameters.AddWithValue("@p1", textBox5.Text);
                komut.Parameters.AddWithValue("@p2", textBox6.Text);
                SqlDataReader rd = komut.ExecuteReader();
                if (rd.Read())
                {
                    frmSoför fr = new frmSoför();
                    fr.şoförAdi = textBox5.Text;
                    fr.Show();
                    this.Hide();
                }
                else
                    MessageBox.Show("HATALI ŞİFRE VEYA T.C.");
                textBox2.Text = "";
                textBox1.Text = "";
            }
            else MessageBox.Show("Lütfen Alanları Doldurun");

            bgl.baglanti().Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmWeatherAppcs fr = new frmWeatherAppcs();
            fr.Show();
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmFotografAlbumu fr = new frmFotografAlbumu();
            fr.Show();
        }
    }
}
