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
    public partial class Musteriler : Form
    {
        GaleriProje3Entities con= new GaleriProje3Entities();
        public Musteriler()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e) //Add
        {
            Musteri musteri_Add= new Musteri();
            musteri_Add.nameSurname = txt_adSoyad.Text;
            musteri_Add.adress=txt_adres.Text;
            musteri_Add.phone = txt_tel.Text;
            con.Musteris.Add(musteri_Add);
            con.SaveChanges();
            MusListele();
        }
        public void MusListele()
        {
            dataGridView1.DataSource = con.Musteris.ToList();
        }

        private void button3_Click(object sender, EventArgs e) //list
        {
            MusListele();
        }

        private void button5_Click(object sender, EventArgs e) //update
        {
            try
            {
                int id = Convert.ToInt32(txt_musNo.Text);
                Musteri musteriUpdate = con.Musteris.SingleOrDefault(a => a.id == id);
                musteriUpdate.id = Convert.ToInt32(txt_musNo.Text);
                musteriUpdate.nameSurname = txt_adSoyad.Text;
                musteriUpdate.phone = txt_tel.Text;
                musteriUpdate.adress = txt_adres.Text;
                con.SaveChanges();
                MusListele();
            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message+ "Şu anda işlem gerçekleştirilemiyor. Daha sonra tekrar deneyiniz");
            }
        }

        private void button6_Click(object sender, EventArgs e)  //del
        {
            try
            { 
                int id = Convert.ToInt32(txt_musNo.Text);
                Musteri musteriSil = con.Musteris.SingleOrDefault(a => a.id == id);
                con.Musteris.Remove(musteriSil);
                con.SaveChanges();
                MusListele();

            }catch (Exception)
            {
                MessageBox.Show("Bu Müşteriyle ilgili bir işlem gerçekleştiği için silemezsiniz. Önce gerçekleştirdiğiniz işlemi silmelisinz.");
            }
           
        }

        private void button7_Click(object sender, EventArgs e)  //search
        {
            int id = Convert.ToInt32(txt_musNo.Text);
            dataGridView1.DataSource = con.Musteris.Where(a => a.id == id).ToList();

        }

        private void button11_Click(object sender, EventArgs e)
        {
            Form1 anasayfa= new Form1();
            anasayfa.Show();
            this.Hide();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow satir = dataGridView1.CurrentRow; 
            txt_musNo.Text = satir.Cells["id"].Value.ToString();
            txt_adSoyad.Text = satir.Cells["nameSurname"].Value.ToString();
            txt_adres.Text = satir.Cells["adress"].Value.ToString();
            txt_tel.Text = satir.Cells["phone"].Value.ToString();
          
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
