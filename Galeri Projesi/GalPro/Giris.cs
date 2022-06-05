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
    public partial class Giris : Form
    {
        GaleriProje3Entities con = new GaleriProje3Entities();
        public Giris()
        {
            InitializeComponent();
        }
        private void btn_login_Click(object sender, EventArgs e)
        {
            string var_mi = con.Kullanicis.Any((x) => x.kulAd == log_username.Text && x.Sifre == log_password.Text).ToString();
            if (Convert.ToBoolean(var_mi))
            {
                Form1 anasayfa = new Form1();
                anasayfa.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Kullanıcı adı yada şifre hatalı. Tekrar Deneyiniz.");
            }
            log_username.Clear();
            log_password.Clear();
        }
        private void btn_forvisiblegbSignUp_Click(object sender, EventArgs e)
        {
            gBox_KayitOl.Visible = true;
        }

        private void btn_signup_Click(object sender, EventArgs e)
        {
            if (con.Kullanicis.Any(u=>u.kulAd==txt_userName.Text))
            {
                MessageBox.Show("Bu kullanıcı adı alınmış. Başka bir kullanıcı adı seçiniz.");
                txt_userName.Clear();
                txtPssword.Clear();
            }
            else
            {
                try
                {
                    Kullanici k1 = new Kullanici();
                    k1.kulAd = txt_userName.Text;
                    k1.Sifre = txtPssword.Text;
                    con.Kullanicis.Add(k1);
                    con.SaveChanges();
                    MessageBox.Show("Kaydınız başarıyla tamamlandı. Giriş yapabilirsiniz.");
               
                }catch(Exception ex)
                {
                    MessageBox.Show(ex.Message+ "Hata oluştu. Tekrar Deneyiniz.");
                }
                txt_userName.Clear();
                txtPssword.Clear();
            }
        }
    }
}
