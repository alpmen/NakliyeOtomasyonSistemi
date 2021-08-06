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
    public partial class frmGrafikler : Form
    {
        public frmGrafikler()
        {
            InitializeComponent();
        }
        sqlBaglanti bgl = new sqlBaglanti();

        private void frmGrafikler_Load(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("select TÜRÜ , count(*) FROM TBLSİPARİŞLER group by TÜRÜ", bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                chart1.Series["NAKLİYE TÜRÜ"].Points.AddXY(dr[0], dr[1]);
            }
            bgl.baglanti().Close();

            SqlCommand komut2 = new SqlCommand("select AD,MAAŞ FROM TBLŞOFÖRLER", bgl.baglanti());
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                chart2.Series["MAAS"].Points.AddXY(dr2[0], dr2[1]);
            }
            bgl.baglanti().Close();

            SqlCommand komut3 = new SqlCommand("select SİPARİŞSAHİBİ , count(*) FROM TBLSİPARİŞLER group by SİPARİŞSAHİBİ", bgl.baglanti());
            SqlDataReader dr3 = komut3.ExecuteReader();
            while (dr3.Read())
            {
                chart3.Series["EN ÇOK SİPARİŞ VERENLER"].Points.AddXY(dr3[0], dr3[1]);
            }
            bgl.baglanti().Close();


            SqlCommand komut4 = new SqlCommand("select ŞOFÖR , count(*) FROM TBLSİKAYETLER group by ŞOFÖR", bgl.baglanti());
            SqlDataReader dr4 = komut4.ExecuteReader();
            while (dr4.Read())
            {
                chart4.Series["EN ÇOK ŞİKAYET ALANLAR"].Points.AddXY(dr4[0], dr4[1]);
            }
            bgl.baglanti().Close();
        }
    }
}
