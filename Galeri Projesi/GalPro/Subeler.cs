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
    public partial class Subeler : Form
    {
        GaleriProje3Entities con= new GaleriProje3Entities();
        public Subeler()
        {
            InitializeComponent();
        }
         public void SubeListele()
         {
            dataGridView1.DataSource = con.Subes.ToList();
         }
        private void button3_Click(object sender, EventArgs e)  //list
        {
            SubeListele();
        }

        private void button5_Click(object sender, EventArgs e)  //update
        {
            int S_id = Convert.ToInt32(txt_subNo.Text);
            Sube sube = con.Subes.SingleOrDefault(a => a.id == S_id);
            sube.SubeAd = txtSubAd.Text;
            sube.CalisanSayisi = Convert.ToInt32(txt_CalSayi.Text);
            sube.SubeCiro = Convert.ToInt32(txt_SubeCiro.Text);
           
            con.SaveChanges();
            SubeListele();


        }

        private void button4_Click(object sender, EventArgs e)  //Add
        {
            Sube sube= new Sube();
            sube.SubeAd = txtSubAd.Text;
            sube.CalisanSayisi = Convert.ToInt32(txt_CalSayi.Text);
            sube.SubeCiro = Convert.ToInt32(txt_SubeCiro.Text);
            con.Subes.Add(sube);
            con.SaveChanges();
            SubeListele();
        }

        private void button6_Click(object sender, EventArgs e)  //Del
        {
            int id = Convert.ToInt32(txt_subNo.Text);
            Sube sub_del = con.Subes.SingleOrDefault(a => a.id == id);
            con.Subes.Remove(sub_del);
            con.SaveChanges();
            SubeListele();
        }

        private void button7_Click(object sender, EventArgs e)  //Search
        {
            
            dataGridView1.DataSource = con.Subes.Where(x=> x.SubeAd.ToLower().
            Contains(txtSubAd.Text) || x.SubeAd.ToUpper().Contains(txtSubAd.Text)).ToList();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Form1 anasayfa= new Form1();
            anasayfa.Show();
            this.Hide();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Subeler_Load(object sender, EventArgs e)
        {
            //textBox1.Text = liste.Find(p => p.yasi == 21).Ad.ToString();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow satir = dataGridView1.CurrentRow;
            txt_subNo.Text = satir.Cells["id"].Value.ToString();
            txtSubAd.Text = satir.Cells["SubeAd"].Value.ToString();
            txt_CalSayi.Text = satir.Cells["CalisanSayisi"].Value.ToString();
            txt_SubeCiro.Text = satir.Cells["SubeCiro"].Value.ToString();
        }
    }
}
