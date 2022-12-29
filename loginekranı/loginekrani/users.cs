using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace loginekrani
{
    public class users
    {
        // Database tablonuza göre şekillendirin.
        public int id { get; set; }
        public string adi { get; set; }
        public string soyadi { get; set; }
        public string kullaniciadi { get; set; }
        public string sifre { get; set; }
        public string yetki { get; set; }
        public string dogumTarihi { get; set; }
        public string emailadres { get; set; }
        public loginStatus status { get; set; }


    }
}
