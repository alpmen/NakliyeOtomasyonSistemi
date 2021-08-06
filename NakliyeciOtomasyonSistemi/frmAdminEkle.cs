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
    public partial class frmAdminEkle : Form
    {
        public frmAdminEkle()
        {
            InitializeComponent();
        }
        sqlBaglanti bgl = new sqlBaglanti();
        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into TBLYONETİCİLER (AD,SOYAD,ŞİFRE,CİNSİYET) values(@p1,@p2,@p3,@p4)", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", textBox1.Text);
            komut.Parameters.AddWithValue("@p2", textBox2.Text);
            komut.Parameters.AddWithValue("@p3", textBox5.Text);
            komut.Parameters.AddWithValue("@p4", comboBox1.Text);

            if (textBox1.Text != "" && textBox2.Text != "" && comboBox1.Text != "" && textBox5.Text != "")
            {
                komut.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("EKLEME İŞLEMİ BAŞARILI");
            }
            else
            {
                MessageBox.Show("HATA!");
            }

        }

        private void frmAdminEkle_Load(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("select * from TBLYONETİCİLER", bgl.baglanti());
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            bgl.baglanti().Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox3.Text != "")
            {
                SqlCommand komut = new SqlCommand("delete from TBLYONETİCİLER where ID=@p1", bgl.baglanti());
                komut.Parameters.AddWithValue("@p1", textBox3.Text);
                komut.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Silme işlemi başarılı");
            }
            else
            {
                MessageBox.Show("Bir ürün seçin");
            }

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int x = dataGridView1.SelectedCells[0].RowIndex;
            textBox3.Text = dataGridView1.Rows[x].Cells[0].Value.ToString();
            textBox1.Text = dataGridView1.Rows[x].Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.Rows[x].Cells[2].Value.ToString();
            textBox5.Text = dataGridView1.Rows[x].Cells[3].Value.ToString();
            comboBox1.Text = dataGridView1.Rows[x].Cells[4].Value.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("select * from TBLYONETİCİLER", bgl.baglanti());
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            bgl.baglanti().Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox3.Text != "")
            {
                try
                {
                    SqlCommand komut = new SqlCommand("update TBLYONETİCİLER set AD=@P1,SOYAD=@P2,ŞİFRE=@P3,CİNSİYET=@P4 where ID=@P5", bgl.baglanti());
                    komut.Parameters.AddWithValue("@P1", textBox1.Text);
                    komut.Parameters.AddWithValue("@P2", textBox2.Text);
                    komut.Parameters.AddWithValue("@P3", textBox5.Text);
                    komut.Parameters.AddWithValue("@P4", comboBox1.Text);
                    komut.Parameters.AddWithValue("@P5", textBox3.Text);
                    komut.ExecuteNonQuery();
                    bgl.baglanti().Close();
                    MessageBox.Show("Güncelleme Başarılı");
                }
                catch (Exception)
                {

                    MessageBox.Show("Hata! ID geçersiz");
                }

            }
            else
            {
                MessageBox.Show("Lütfe bir ürün seçin");
            }

        }

        private void textBox3_EnabledChanged(object sender, EventArgs e)
        {

        }
    }
}
