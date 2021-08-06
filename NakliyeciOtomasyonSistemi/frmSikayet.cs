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
    public partial class frmSikayet : Form
    {
        public frmSikayet()
        {
            InitializeComponent();
        }
        sqlBaglanti bgl = new sqlBaglanti();
        private void frmSikayet_Load(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("select * from TBLSİKAYETLER",bgl.baglanti());
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            bgl.baglanti().Close();

        }
    }
}
