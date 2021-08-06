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
    public partial class frmKullanici : Form
    {

        public frmKullanici()
        {
            InitializeComponent();
        }
        public string musteriAd = "";
        sqlBaglanti bgl = new sqlBaglanti();

        private void frmKullanici_Load(object sender, EventArgs e)
        {

            label3.Text = musteriAd;
            SqlCommand komut = new SqlCommand("select * from TBLSİPARİŞLER WHERE SİPARİŞSAHİBİ=@P1 AND DURUM=1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", label3.Text);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(komut);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            bgl.baglanti().Close();



            SqlCommand komut2 = new SqlCommand("select * from TBLSİPARİŞLER WHERE SİPARİŞSAHİBİ=@P2 AND DURUM=0", bgl.baglanti());
            komut2.Parameters.AddWithValue("@p2", label3.Text);
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter(komut2);
            da2.Fill(dt2);
            dataGridView2.DataSource = dt2;
            bgl.baglanti().Close();


            SqlCommand command = new SqlCommand("select * from TBLSEHİR",bgl.baglanti());
            SqlDataReader rd = command.ExecuteReader();
            while (rd.Read())
            {
                comboBox2.Items.Add(rd[1]);
                comboBox3.Items.Add(rd[1]);
            }
            bgl.baglanti().Close();

            SqlCommand command2 = new SqlCommand("select * from TBLTURLER", bgl.baglanti());
            SqlDataReader rd2 = command2.ExecuteReader();
            while (rd2.Read())
            {
                comboBox1.Items.Add(rd2[1]);
            }
            bgl.baglanti().Close();


            SqlCommand command3 = new SqlCommand("select * from TBLŞOFÖRLER", bgl.baglanti());
            SqlDataReader dr = command3.ExecuteReader();
            while (dr.Read())
            {
                comboBox4.Items.Add(dr[1] + " " + dr[2]);
            }
            bgl.baglanti().Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            label3.Text = musteriAd;
            SqlCommand komut = new SqlCommand("select * from TBLSİPARİŞLER WHERE SİPARİŞSAHİBİ=@P1 AND DURUM=1 order by ÜCRET ", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", label3.Text);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(komut);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            bgl.baglanti().Close();



            SqlCommand komut2 = new SqlCommand("select * from TBLSİPARİŞLER WHERE SİPARİŞSAHİBİ=@P2 AND DURUM=0 order by ÜCRET", bgl.baglanti());
            komut2.Parameters.AddWithValue("@p2", label3.Text);
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter(komut2);
            da2.Fill(dt2);
            dataGridView2.DataSource = dt2;
            bgl.baglanti().Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label3.Text = musteriAd;
            SqlCommand komut = new SqlCommand("select * from TBLSİPARİŞLER WHERE SİPARİŞSAHİBİ=@P1 AND DURUM=1 order by YOLUZUNLUĞU ", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", label3.Text);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(komut);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            bgl.baglanti().Close();



            SqlCommand komut2 = new SqlCommand("select * from TBLSİPARİŞLER WHERE SİPARİŞSAHİBİ=@P2 AND DURUM=0 order by YOLUZUNLUĞU", bgl.baglanti());
            komut2.Parameters.AddWithValue("@p2", label3.Text);
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter(komut2);
            da2.Fill(dt2);
            dataGridView2.DataSource = dt2;
            bgl.baglanti().Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int x = dataGridView1.SelectedCells[0].RowIndex;
            textBox2.Text = dataGridView1.Rows[x].Cells[0].Value.ToString();
            comboBox2.Text = dataGridView1.Rows[x].Cells[1].Value.ToString();
            comboBox3.Text = dataGridView1.Rows[x].Cells[2].Value.ToString();
            comboBox1.Text = dataGridView1.Rows[x].Cells[3].Value.ToString();
            textBox6.Text = dataGridView1.Rows[x].Cells[4].Value.ToString();
            textBox8.Text = dataGridView1.Rows[x].Cells[6].Value.ToString();
            comboBox4.Text = dataGridView1.Rows[x].Cells[8].Value.ToString(); 
            radioButton2.PerformClick();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string durum = "";
                if (radioButton1.Checked)
                {
                    durum = "0";
                }
                else
                    durum = "1";

                SqlCommand komut = new SqlCommand
                    ("insert into TBLSİPARİŞLER (NEREDEN,NEREYE,TÜRÜ,ÜCRET,DURUM,YOLUZUNLUĞU,SİPARİŞSAHİBİ,ŞOFÖR) VALUES(@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8)", bgl.baglanti());
                komut.Parameters.AddWithValue("@p1", comboBox2.Text);
                komut.Parameters.AddWithValue("@p2", comboBox3.Text);
                komut.Parameters.AddWithValue("@p3", comboBox1.Text);
                komut.Parameters.AddWithValue("@p4", textBox6.Text);
                komut.Parameters.AddWithValue("@p5", durum);
                komut.Parameters.AddWithValue("@p6", textBox8.Text);
                komut.Parameters.AddWithValue("@p7", label3.Text);
                komut.Parameters.AddWithValue("@p8", comboBox4.Text);
                komut.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Kayıt eklendi");
            }
            catch (Exception)
            {

                MessageBox.Show("Hata! Alanlar boş olamaz");
            }
            SqlCommand komut2 = new SqlCommand("select * from TBLSİPARİŞLER WHERE SİPARİŞSAHİBİ=@p2 AND DURUM=1", bgl.baglanti());
            komut2.Parameters.AddWithValue("@p2", label3.Text);
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter(komut2);
            da2.Fill(dt2);
            dataGridView1.DataSource = dt2;
            bgl.baglanti().Close();


        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox2.Text != "")
                {
                    SqlCommand komut = new SqlCommand("delete from TBLSİPARİŞLER WHERE ID=@p1", bgl.baglanti());
                    komut.Parameters.AddWithValue("@p1", textBox2.Text);
                    komut.ExecuteNonQuery();
                    bgl.baglanti().Close();
                    MessageBox.Show("Silme işlemi başarılı");
                }
                else
                {
                    MessageBox.Show("Hata");
                }

            }
            catch (Exception)
            {

                MessageBox.Show("Hata! ID değeri girin ");
            }


        }

        private void button4_Click(object sender, EventArgs e)
        {

            try
            {
                if (textBox2.Text != "")
                {
                    SqlCommand komut = new SqlCommand
              ("update TBLSİPARİŞLER set NEREDEN=@P1 , NEREYE=@P2, TÜRÜ=@P3, ÜCRET=@P4, YOLUZUNLUĞU=@P5, ŞOFÖR=@P7 where ID=@P6 ", bgl.baglanti());
                    komut.Parameters.AddWithValue("@P1", comboBox2.Text);
                    komut.Parameters.AddWithValue("@P2", comboBox3.Text);
                    komut.Parameters.AddWithValue("@P3", comboBox1.Text);
                    komut.Parameters.AddWithValue("@P4", textBox6.Text);
                    komut.Parameters.AddWithValue("@P5", textBox8.Text);
                    komut.Parameters.AddWithValue("@P6", textBox2.Text);
                    komut.Parameters.AddWithValue("@P7", comboBox4.Text);
                    komut.ExecuteNonQuery();
                    bgl.baglanti().Close();
                    MessageBox.Show("güncelleme baarılı");
                }
                else
                    MessageBox.Show("Hata");
            }
            catch (Exception)
            {

                MessageBox.Show("Hata! Güncelleme Başarısız");
            }


            SqlCommand komut2 = new SqlCommand("select * from TBLSİPARİŞLER WHERE SİPARİŞSAHİBİ=@P2 AND DURUM=1", bgl.baglanti());
            komut2.Parameters.AddWithValue("@p2", label3.Text);
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter(komut2);
            da2.Fill(dt2);
            dataGridView1.DataSource = dt2;
            bgl.baglanti().Close();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {

                SqlCommand komut = new SqlCommand("select * from TBLSİPARİŞLER where NEREDEN=@p1", bgl.baglanti());
                komut.Parameters.AddWithValue("@p1", textBox1.Text);
                SqlDataAdapter da = new SqlDataAdapter(komut);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                bgl.baglanti().Close();
            }
            catch (Exception)
            {

                MessageBox.Show("HATA");
            }

        }

        private void button7_Click(object sender, EventArgs e)
        {
            frmGiris fr = new frmGiris();
            fr.Show();
            this.Hide();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime zaman = DateTime.Now;
            label10.Text = zaman.ToString();
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int x = dataGridView2.SelectedCells[0].RowIndex;
            textBox2.Text = dataGridView2.Rows[x].Cells[0].Value.ToString();
            comboBox2.Text = dataGridView2.Rows[x].Cells[1].Value.ToString();
            comboBox3.Text = dataGridView2.Rows[x].Cells[2].Value.ToString();
            comboBox1.Text = dataGridView2.Rows[x].Cells[3].Value.ToString();
            textBox6.Text = dataGridView2.Rows[x].Cells[4].Value.ToString();
            textBox8.Text = dataGridView2.Rows[x].Cells[6].Value.ToString();
            comboBox4.Text = dataGridView2.Rows[x].Cells[8].Value.ToString();
            radioButton1.PerformClick();

        }

        private void button8_Click(object sender, EventArgs e)
        {
            frmSikayetEkle fr = new frmSikayetEkle();
            fr.Show();
        }
    }
}
