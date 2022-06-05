using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GalPro
{
    public partial class Raporlar : Form
    {
        GaleriProje3Entities con = new GaleriProje3Entities();
        public Raporlar()
        {
            InitializeComponent();
        }

        private void btnRap1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = con.Subes.Where(x => x.CalisanSayisi > 10).ToList();
        }

        private void btnRap_2_Click(object sender, EventArgs e)
        {
            var sorgu = from arac1 in con.aracs orderby arac1.fiyat descending
                        select new
                                       {
                                           arac1.model,
                                           arac1.marka,
                                           arac1.fiyat
                                       };
            dataGridView1.DataSource = sorgu.ToList();

        }

        private void btnRap5_Click(object sender, EventArgs e)
        {
            var sorgu = from sube1 in con.Subes join satis1 in con.Satis on sube1.id equals satis1.SubeId
                        join musteri1 in con.Musteris on satis1.MusteriId equals musteri1.id
                        join arac1 in con.aracs on satis1.AracId equals arac1.id

                        select new
                        {
                            musteri1.nameSurname,
                            sube1.SubeAd,
                            arac1.model,
                            arac1.marka,
                            satis1.SatisTarih
                        };
            dataGridView1.DataSource = sorgu.ToList();
        }

        private void btnRap_4_Click(object sender, EventArgs e)
        {
            var sonuc = from mus in con.Musteris orderby mus.nameSurname descending select mus;
           
            dataGridView1.DataSource = sonuc.ToList();
        }


        private void button11_Click(object sender, EventArgs e)
        {
            Form1 anasayfa = new Form1();
            anasayfa.Show();
            this.Hide();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_Rap3_Click(object sender, EventArgs e)
        {
            var sorgu = from sube1 in con.Subes join satis1 in con.Satis on sube1.id equals satis1.SubeId join musteri1 in 
                        con.Musteris on satis1.MusteriId equals musteri1.id 
                        select new
                        {
                            musteri1.nameSurname,
                            sube1.SubeAd
                        };
            dataGridView1.DataSource = sorgu.ToList();
        }
    }
}
 
   
        
