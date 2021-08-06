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
    public partial class frmTur : Form
    {
        public frmTur()
        {
            InitializeComponent();
        }
        sqlBaglanti bgl = new sqlBaglanti();
       
        private void frmTur_Load_1(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("select * from TBLTURLER", bgl.baglanti());
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            bgl.baglanti().Close();
        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            if (textBox2.Text != "")
            {
                SqlCommand komut = new SqlCommand("insert into TBLTURLER (TÜR) values(@p1)", bgl.baglanti());
                komut.Parameters.AddWithValue("@p1", textBox2.Text);
                komut.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Ekleme İşlemi Başarılı");
            }
            else
            {
                MessageBox.Show("Tür ismi girin");
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                SqlCommand komut = new SqlCommand("delete from TBLTurler where ID=@p1", bgl.baglanti());
                komut.Parameters.AddWithValue("@p1", textBox1.Text);
                komut.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Silme işlemi başarılı");
            }
            else
            {
                MessageBox.Show("Lütfen tür seçiniz");
            }

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                SqlCommand komut = new SqlCommand("update TBLTurler set TÜR=@p1 where ID=@p2", bgl.baglanti());
                komut.Parameters.AddWithValue("@p1", textBox2.Text);
                komut.Parameters.AddWithValue("@p2", textBox1.Text);
                komut.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Güncelleme Başarılı");
            }
            else
            {
                MessageBox.Show("Lütfen tür seçiniz");
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("select * from TBLTurler", bgl.baglanti());
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            bgl.baglanti().Close();
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int x = dataGridView1.SelectedCells[0].RowIndex;
            textBox1.Text = dataGridView1.Rows[x].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[x].Cells[1].Value.ToString();
        }
    }
}
