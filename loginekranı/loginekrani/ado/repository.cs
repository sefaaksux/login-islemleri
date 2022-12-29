using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace loginekrani.ado
{
    public class repository
    {
        SqlConnection con;
        SqlCommand cmd;
        public repository()
        {
            //database bağlantısı;
            con = new SqlConnection("Data Source="); //LÜTFEN KENDİ VERİTABANI BAĞLANTINIZI YAPINIZ!!!
        }

        public users login(string kullaniciadi, string sifre)
        {
            List<users> userList = new List<users>(); // kullanıcının bilgilerini toplayacağımız liste.
            con.Open();
            cmd = new SqlCommand("select * from loginTable where kullaniciAdi=@p1 and sifre=@p2", con);
            cmd.Parameters.AddWithValue("@p1", kullaniciadi);
            cmd.Parameters.AddWithValue("@p2", sifre);
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                // Kendi verilerinizi girin!! (Bu sadece örnektir.)
                users users = new users();
                users.id = int.Parse(dr["id"].ToString());
                users.adi = dr["adi"].ToString();
                users.soyadi = dr["soyAdi"].ToString();
                users.kullaniciadi = dr["kullaniciAdi"].ToString();
                users.sifre = dr["sifre"].ToString();
                users.yetki = dr["yetki"].ToString();
                users.dogumTarihi = dr["dogumTarihi"].ToString();
                users.emailadres = dr["emailAdres"].ToString();
                userList.Add(users);
                con.Close();
                users.status = loginStatus.basarili;
                return users;

            }
            else
            {
                users users = new users();
                users.status = loginStatus.basarisiz;
                return users;
            }
        }
    }
}
