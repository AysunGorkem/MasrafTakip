using MasrafTakibi.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MasrafTakibi.UI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnGiris_Click(object sender, EventArgs e)
        {
            Kontoller k = new Kontoller();
            k.KullaniciAdi = txtAd.Text;
            k.KullaniciSifre = txtSifre.Text;


            if (!k.IsimKontrolu(k.KullaniciAdi))
            {
                MessageBox.Show("Kullanici adi hatali!");
            }
            else if (!k.SifreKontrolu(k.KullaniciSifre))
            {
                MessageBox.Show("Kullanici Sifresi Hatali");
            }
            else
            {
                if (k.KullaniciAdi == "Cigdem")
                {
                    YoneticiFormu yf = new YoneticiFormu();
                    yf.Show();
                }
                if (k.KullaniciAdi == "Aysun")
                {
                    CalisanFormu cf = new CalisanFormu();
                    cf.Show();
                }
            }
            this.Visible = false;
        }
    }
}
