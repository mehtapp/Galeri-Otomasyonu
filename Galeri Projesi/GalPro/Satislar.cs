using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GalPro
{
    public partial class Satislar : Form
    {
        GaleriProje3Entities con=new GaleriProje3Entities();
        public Satislar()
        {
            InitializeComponent();
        }

        private void Satislar_Load(object sender, EventArgs e)
        {
            comboBoxSubeNoAd.DataSource = con.Subes.ToList();
            comboBoxAracNoAd.DataSource=con.aracs.ToList();
            comboBoxMusteriNoAd.DataSource= con.Musteris.ToList();
            
        }
        public void SatisListesi()
        {
            dataGridView1.DataSource = con.Satis.ToList();
        }
        private void btnlist_Click(object sender, EventArgs e)
        {
            SatisListesi();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow satir = dataGridView1.CurrentRow;
            txt_SatisNo.Text =satir.Cells["SatisId"].Value.ToString();
            int Subeid = Convert.ToInt32(satir.Cells["SubeId"].Value);
            comboBoxSubeNoAd.Text = con.Subes.FirstOrDefault(p => p.id == Subeid).SubeAd;
            int MusteriNo = Convert.ToInt32(satir.Cells["MusteriId"].Value);
            comboBoxMusteriNoAd.Text = con.Musteris.FirstOrDefault(m => m.id == MusteriNo).nameSurname;
            int AracNo = Convert.ToInt32(satir.Cells["AracId"].Value);
            comboBoxAracNoAd.Text = con.aracs.FirstOrDefault(a => a.id == AracNo).marka;
        }

        private void btn_ekle_Click(object sender, EventArgs e)
        {
            Satis satis1 = new Satis();
            satis1.MusteriId = Convert.ToInt32(comboBoxMusteriNoAd.SelectedValue) ;
            satis1.AracId = Convert.ToInt32(comboBoxAracNoAd.SelectedValue);
            satis1.SubeId = Convert.ToInt32(comboBoxSubeNoAd.SelectedValue);
            satis1.SatisTarih = Convert.ToDateTime(dateTimePickerTarih.Text);
            con.Satis.Add(satis1);
            con.SaveChanges();
            SatisListesi();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 Anasayfa=new Form1();
            Anasayfa.Show();
            this.Hide();
                
        }

        private void comboBoxMusteriNoAd_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btn_guncel_Click(object sender, EventArgs e)
        {
            int id=Convert.ToInt32(txt_SatisNo.Text);
            Satis satis1= con.Satis.SingleOrDefault(a => a.SatisId == id);
            
            satis1.MusteriId = Convert.ToInt32(comboBoxMusteriNoAd.SelectedValue);
            satis1.AracId = Convert.ToInt32(comboBoxAracNoAd.SelectedValue);
            satis1.SubeId = Convert.ToInt32(comboBoxSubeNoAd.SelectedValue);
            satis1.SatisTarih = Convert.ToDateTime(dateTimePickerTarih.Text);
            con.SaveChanges();
            SatisListesi();

        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            int Id= Convert.ToInt32(txt_SatisNo.Text);
            Satis satisdel= con.Satis.Where(a => a.SatisId == Id).FirstOrDefault();
            con.Satis.Remove(satisdel);
            con.SaveChanges();
            SatisListesi();
        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            int Id = Convert.ToInt32(txt_SatisNo.Text);
            dataGridView1.DataSource= con.Satis.Where(s => s.SatisId == Id).ToList();
        }
    }
}
