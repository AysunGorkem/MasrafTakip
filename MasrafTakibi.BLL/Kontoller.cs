using MasrafTakibi.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasrafTakibi.BLL
{
    public class Kontoller
    {
        MasrafDBEntities db = new MasrafDBEntities();

        public string KullaniciAdi { get; set; }
        public string KullaniciSifre { get; set; }

        public bool IsimKontrolu(string Adi)
        {
            bool varMi = true;
            var KAdi = (from k in db.KullaniciGiris where k.KullaniciAdi == Adi select k).FirstOrDefault();
            if (KAdi == null)
                varMi = false;
            return varMi;
        }

        public bool SifreKontrolu(string Sifre)
        {
            bool sifre = true;
            var kSifre = (from k in db.KullaniciGiris where k.KullaniciSifre == Sifre select k).FirstOrDefault();
            if (kSifre == null)
                sifre = false;
            return sifre;
        }

    }
}
