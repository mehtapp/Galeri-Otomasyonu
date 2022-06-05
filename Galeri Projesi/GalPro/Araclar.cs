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
    public partial class Araclar : Form
    {
        GaleriProje3Entities con= new GaleriProje3Entities();
        public Araclar()
        {
            InitializeComponent();
        }
        public void AracListele()
        {
            dataGridView1.DataSource = con.aracs.ToList();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Form1 anasayfa = new Form1();
            anasayfa.Show();
            this.Hide();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_ekle_Click(object sender, EventArgs e)
        {
            arac a1 = new arac();
            a1.fiyat = Convert.ToInt32(txt_fiyatt.Text);
            a1.adet = Convert.ToInt32(txt_adett.Text);
            a1.marka = txt_marka.Text;
            a1.model = txt_model.Text;
            a1.yil = txt_yil.Text;
            a1.ozellik = txt_ozellik.Text;
            a1.motor = txt_motor.Text;
            a1.renk = txt_renk.Text;

            con.aracs.Add(a1);
            con.SaveChanges();
            AracListele();
        }

        private void btn_guncel_Click(object sender, EventArgs e)
        {
            int S_id = Convert.ToInt32(txt_AracNo.Text);

            arac a1 = con.aracs.SingleOrDefault(a => a.id == S_id);
            a1.fiyat = Convert.ToInt32(txt_fiyatt.Text);
            a1.adet = Convert.ToInt32(txt_adett.Text);
            a1.marka = txt_marka.Text;
            a1.model = txt_model.Text;
            a1.yil = txt_yil.Text;
            a1.ozellik = txt_ozellik.Text;
            a1.motor = txt_motor.Text;
            a1.renk = txt_renk.Text;
            con.SaveChanges();
            AracListele();
        }

        private void btnlist_Click(object sender, EventArgs e)
        {
            AracListele();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txt_AracNo.Text);
            arac arac_del = con.aracs.SingleOrDefault(a => a.id == id);
            con.aracs.Remove(arac_del);
            con.SaveChanges();
            AracListele();
        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            int arac_Id=Convert.ToInt32(txt_AracNo.Text);
            dataGridView1.DataSource= con.aracs.Where(a=>a.id== arac_Id).ToList();
        }

        private void Araclar_Load(object sender, EventArgs e)
        {
           
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow satir = dataGridView1.CurrentRow;
            txt_AracNo.Text = satir.Cells["id"].Value.ToString();
            txt_fiyatt.Text = satir.Cells["fiyat"].Value.ToString();
            txt_adett.Text = satir.Cells["adet"].Value.ToString();
            txt_marka.Text = satir.Cells["marka"].Value.ToString();
            txt_model.Text = satir.Cells["model"].Value.ToString();
            txt_yil.Text = satir.Cells["yil"].Value.ToString();
            txt_ozellik.Text = satir.Cells["ozellik"].Value.ToString();
            txt_motor.Text = satir.Cells["motor"].Value.ToString();
            txt_renk.Text = satir.Cells["renk"].Value.ToString();
        }

        private void cb_subeNo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
