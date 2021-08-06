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
    public partial class frmSoförEkle : Form
    {
        public frmSoförEkle()
        {
            InitializeComponent();
        }
        sqlBaglanti bgl = new sqlBaglanti();
        private void frmŞoförEkle_Load(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("select * from  TBLŞOFÖRLER ", bgl.baglanti());
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            bgl.baglanti().Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox3.Text!="")
            {
                try
                {
                    SqlCommand komut = new SqlCommand
                               ("update TBLŞOFÖRLER set AD=@P1,SOYAD=@P2,YAŞ=@P3,TOPLAMYOL=@P4,MAAŞ=@P5,ŞİFRE=@P6 WHERE ID=@P7", bgl.baglanti());
                    komut.Parameters.AddWithValue("@P1", textBox1.Text);
                    komut.Parameters.AddWithValue("@P2", textBox2.Text);
                    komut.Parameters.AddWithValue("@P3", textBox4.Text);
                    komut.Parameters.AddWithValue("@P4", textBox5.Text);
                    komut.Parameters.AddWithValue("@P5", textBox6.Text);
                    komut.Parameters.AddWithValue("@P6", textBox7.Text);
                    komut.Parameters.AddWithValue("@P7", textBox3.Text);
                    komut.ExecuteNonQuery();
                    bgl.baglanti().Close();
                    MessageBox.Show("Güncelleme işlemi başarılı");
                }
                catch (Exception)
                {

                    MessageBox.Show("HATA!");
                }
                
            }
            else
            {
                MessageBox.Show("Geçerli bir şoför seçin ID girilmeden güncelleme yapılamaz");
            }
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != "" && textBox7.Text != "")
            {
                try
                {
                    SqlCommand komut = new SqlCommand
               ("insert into TBLŞOFÖRLER (AD,SOYAD,YAŞ,TOPLAMYOL,MAAŞ,ŞİFRE) VALUES (@P1,@P2,@P3,@P4,@P5,@P6)", bgl.baglanti());
                    komut.Parameters.AddWithValue("@P1", textBox1.Text);
                    komut.Parameters.AddWithValue("@P2", textBox2.Text);
                    komut.Parameters.AddWithValue("@P3", textBox4.Text);
                    komut.Parameters.AddWithValue("@P4", textBox5.Text);
                    komut.Parameters.AddWithValue("@P5", textBox6.Text);
                    komut.Parameters.AddWithValue("@P6", textBox7.Text);
                    komut.ExecuteNonQuery();
                    bgl.baglanti().Close();
                    MessageBox.Show("KAYIT BAŞARILI");
                }
                catch (Exception)
                {

                    MessageBox.Show("HATA");
                }
            }
            else
            {
                MessageBox.Show("HATA! ALANLAR BOŞ BIRAKILAMAZ");
            }

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int x = dataGridView1.SelectedCells[0].RowIndex;
            textBox3.Text = dataGridView1.Rows[x].Cells[0].Value.ToString();
            textBox1.Text = dataGridView1.Rows[x].Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.Rows[x].Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.Rows[x].Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.Rows[x].Cells[4].Value.ToString();
            textBox6.Text = dataGridView1.Rows[x].Cells[5].Value.ToString();
            textBox7.Text = dataGridView1.Rows[x].Cells[6].Value.ToString();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox3.Text!="")
                {
                    SqlCommand komut = new SqlCommand("delete from TBLŞOFÖRLER where ID=@P1", bgl.baglanti());
                    komut.Parameters.AddWithValue("@P1", textBox3.Text);
                    komut.ExecuteNonQuery();
                    bgl.baglanti().Close();
                    MessageBox.Show("Silme işlemi başarılı");
                }
                else
                {
                    MessageBox.Show("Hata! ID Giriniz");
                }
                
            }
            catch (Exception)
            {

                MessageBox.Show("Hata! Id yanlış veya bulunamadı");
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("select * from  TBLŞOFÖRLER ", bgl.baglanti());
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            bgl.baglanti().Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("select * from  TBLŞOFÖRLER ORDER BY AD ", bgl.baglanti());
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            bgl.baglanti().Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("select * from  TBLŞOFÖRLER ORDER BY MAAŞ", bgl.baglanti());
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            bgl.baglanti().Close(); 
        }
    }
}
