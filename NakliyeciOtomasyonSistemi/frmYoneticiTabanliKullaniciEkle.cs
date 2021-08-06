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
    public partial class frmYoneticiTabanliKullaniciEkle : Form
    {
        public frmYoneticiTabanliKullaniciEkle()
        {
            InitializeComponent();
        }
        sqlBaglanti bgl = new sqlBaglanti();
        private void frmYoneticiTabanliKullaniciEkle_Load(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("select * from TBLMUSTERILER", bgl.baglanti());
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            bgl.baglanti().Close();

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int x = dataGridView1.SelectedCells[0].RowIndex;
            textBox1.Text = dataGridView1.Rows[x].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[x].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.Rows[x].Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.Rows[x].Cells[3].Value.ToString();
            comboBox1.Text = dataGridView1.Rows[x].Cells[4].Value.ToString();
            textBox6.Text = dataGridView1.Rows[x].Cells[5].Value.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            comboBox1.Text = "";
            textBox6.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("select * from TBLMUSTERILER", bgl.baglanti());
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            bgl.baglanti().Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && comboBox1.Text != "" && textBox6.Text != "")
            {
                try
                {
                    SqlCommand komut = new SqlCommand("insert into TBLMUSTERILER (AD,SOYAD,MESLEK,CİNSİYET,ŞİFRE) values (@p1,@p2,@p3,@p4,@p5)", bgl.baglanti());
                    komut.Parameters.AddWithValue("@p1", textBox2.Text);
                    komut.Parameters.AddWithValue("@p2", textBox3.Text);
                    komut.Parameters.AddWithValue("@p3", textBox4.Text);
                    komut.Parameters.AddWithValue("@p4", comboBox1.Text);
                    komut.Parameters.AddWithValue("@p5", textBox6.Text);
                    komut.ExecuteNonQuery();
                    bgl.baglanti().Close();
                    MessageBox.Show("Ekleme işlemi başarılı");
                }
                catch (Exception)
                {

                    MessageBox.Show("Hata!");
                }
                
            }
            else
            {
                MessageBox.Show("Lütfen tüm alanları doldurun");
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text!="")
            {
                try
                {
                    SqlCommand komut = new SqlCommand("delete from TBLMUSTERILER WHERE ID=@p1", bgl.baglanti());
                    komut.Parameters.AddWithValue("@p1", textBox1.Text);
                    komut.ExecuteNonQuery();
                    bgl.baglanti().Close();
                    MessageBox.Show("Silme işlemi başarılı");
                }
                catch (Exception)
                {

                    MessageBox.Show("Hata");
                }
            }
            else
            {
                MessageBox.Show("Lütfen bir müşteri seçin");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && comboBox1.Text != "" && textBox6.Text != "")
            {
                SqlCommand komut = new SqlCommand("update TBLMUSTERILER set AD=@P1,SOYAD=@P2,MESLEK=@P3,CİNSİYET=@P4,ŞİFRE=@P5 where ID=@P6", bgl.baglanti());
                komut.Parameters.AddWithValue("@P1", textBox2.Text);
                komut.Parameters.AddWithValue("@P2", textBox3.Text);
                komut.Parameters.AddWithValue("@P3", textBox4.Text);
                komut.Parameters.AddWithValue("@P4", comboBox1.Text);
                komut.Parameters.AddWithValue("@P5", textBox6.Text);
                komut.Parameters.AddWithValue("@P6", textBox1.Text);
                komut.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Güncelleme Başarılı");
            }
            else
            {
                MessageBox.Show("Lütfen tüm alanları doldurun");
            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
