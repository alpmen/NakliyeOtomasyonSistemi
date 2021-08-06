using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NakliyeciOtomasyonSistemi
{
    public partial class frmFotografAlbumu : Form
    {
        public frmFotografAlbumu()
        {
            InitializeComponent();
        }

        int resimindex = -1;

        int slaytindex = 0;

        //-------------------------
        //-------------------------
        //-------------------------
        //-------------------------
        //-------------------------
        //-------------------------
        private void btnResimSec_Click(object sender, EventArgs e)
        {
            OpenFileDialog dosya_sec = new OpenFileDialog();
            DialogResult sonuc = dosya_sec.ShowDialog();
            if (sonuc == DialogResult.OK)
            {
                //ımageList1.Images.Add(Image.FromFile(dosya_sec.FileName));
                Image secilenResim = Image.FromFile(dosya_sec.FileName);
                ımageList1.Images.Add(secilenResim);
            }
        }

        private void btnileri_Click_1(object sender, EventArgs e)
        {
            try
            {
                btnGeri.Enabled = true;

                if (resimindex == ımageList1.Images.Count - 1)
                {
                    resimindex = 0;
                }
                else
                {
                    resimindex++;
                }
                pictureBox1.Image = ımageList1.Images[resimindex];
            }
            catch (Exception)
            {

                MessageBox.Show("Hata! ileri gidilmez");
            }
        }

        private void btnGeri_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (resimindex == 0)
                {
                    resimindex = ımageList1.Images.Count - 1;
                }
                else
                {
                    resimindex--;
                }
                pictureBox1.Image = ımageList1.Images[resimindex];
            }
            catch (Exception)
            {

                MessageBox.Show("Hata! Geri Gidilmez");
            }
        }

        private void btnSlayt_Click_1(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //try
            //{
                ımageList1.Images.RemoveAt(resimindex);
                MessageBox.Show("Resim silindi");
                if (resimindex != 0)
                {
                    resimindex--;
                }
                else
                {
                    try
                    {
                        resimindex++;
                    }
                    catch (Exception)
                    {

                        MessageBox.Show("Tek resim");
                    }
                }
            //}
            //catch (Exception)
            //{

            //    MessageBox.Show("Resim bulunamadı");
            //}

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                pictureBox1.Image = ımageList1.Images[slaytindex];
                slaytindex++;
                if (slaytindex == ımageList1.Images.Count)
                {
                    slaytindex = 0;
                    timer1.Stop();
                }
                else
                {
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Önce resim ekleyin");
            }
        }

        private void frmFotografAlbumu_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                ımageList1.Images.RemoveAt(resimindex);

                OpenFileDialog dosya_sec = new OpenFileDialog();
                DialogResult sonuc = dosya_sec.ShowDialog();
                if (sonuc == DialogResult.OK)
                {
                    //ımageList1.Images.Add(Image.FromFile(dosya_sec.FileName));
                    Image secilenResim = Image.FromFile(dosya_sec.FileName);
                    ımageList1.Images.Add(secilenResim);
                }

                MessageBox.Show("Güncelleme Başarılı");
            }
            catch (Exception)
            {

                MessageBox.Show("Resim bulunamadı");
            }

        }
    }
}
