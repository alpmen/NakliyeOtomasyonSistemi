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
    public partial class frmSikayetEkle : Form
    {
        public frmSikayetEkle()
        {
            InitializeComponent();
        }
        sqlBaglanti bgl = new sqlBaglanti();

        private void frmSikayetEkle_Load(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("select * from TBLŞOFÖRLER", bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr[1] + " " + dr[2]);
            }
            bgl.baglanti().Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text != "" && comboBox1.Text != "")
            {
                SqlCommand komut = new SqlCommand("insert into TBLSİKAYETLER (SİKAYET,ŞOFÖR) values(@p1,@p2)", bgl.baglanti());
                komut.Parameters.AddWithValue("@p1", richTextBox1.Text);
                komut.Parameters.AddWithValue("@p2", comboBox1.Text);
                komut.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Şikayet ekleme işlemi başarılı");
            }
            else
            {
                MessageBox.Show("Hata! Alanlar boş kalamaz");
            }

        }
    }
}
