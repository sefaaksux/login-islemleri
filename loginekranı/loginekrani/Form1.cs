using loginekrani.controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace loginekrani
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_giris_Click_1(object sender, EventArgs e)
        {
            controller controller = new controller();   // controller'dan örnek oluşturduk.

            users donenDeger = controller.login(txt_kullaniciadi.Text, txt_sifre.Text); //controller login'e değer gönderdik sonucu aldık.
            
            
            if (donenDeger.status == loginStatus.basarili && donenDeger.yetki=="admin")
            {
                // admin sayfasına yönlendirme
                adminPage adminPage = new adminPage(); 
                adminPage.Show();
                this.Hide();
            }
            else if (donenDeger.status == loginStatus.basarili && donenDeger.yetki == "üye")
            {
                // üye sayfasına yönlendirme
                memberPage memberPage = new memberPage();
                memberPage.Show();
                this.Hide();
            }

            //Error işlemleri
            else if (donenDeger.status == loginStatus.basarisiz)
            {
                MessageBox.Show("Yanlış giriş yaptınız.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (donenDeger.status == loginStatus.eksikParametre)
            {
                MessageBox.Show("Bütün alanları doldurunuz !! ", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void txt_sifre_TextChanged(object sender, EventArgs e)
        {
            // şifre görünürlüğü ayarları (İlk başta gizli olarak başlatmak için);
            
            if(checkBox1.Checked)
            {
                txt_sifre.PasswordChar = char.Parse("*");

            }
            
        }

        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
        {
            // Şifre görünürlüğü ayarı (Gizleyip göstermek için);

            if (txt_sifre.PasswordChar.ToString() == "*")
            {
                txt_sifre.PasswordChar = char.Parse("\0");
            }
            else if (txt_sifre.PasswordChar.ToString() == "\0")
            {
                txt_sifre.PasswordChar = char.Parse("*");

            }

          
        }
    }
}
