using MasrafTakibi.BLL;
using MasrafTakibi.DAL;
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
    public partial class CalisanFormu : Form
    {
        public CalisanFormu()
        {
            InitializeComponent();
        }
        CalisanRepository cr = new CalisanRepository();
        private void btnBirimler_Click(object sender, EventArgs e)
        {
            cmbBoxBirimler.DataSource = cr.SelectAll().Select(x => new
            {
                Birimler = x.CalisanBirimi, x.CalisanID
            }).ToList();
            cmbBoxBirimler.DisplayMember = "CalisanBirimi";
            cmbBoxBirimler.ValueMember = "CalisanID";
        }

        private void btnGetir_Click(object sender, EventArgs e)
        {
            Getir();
        }
        public void Getir()
        {
            dataGridView1.DataSource = cr.SelectAll().ToList();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            Calisan c = new Calisan();
            c.CalisanAdi = textBox1.Text;
            c.CalisanSoyadi = textBox2.Text;
            cr.Insert(c);
            Getir();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count <= 0)
            {
                MessageBox.Show("Satır Seçmeden silme yapilamaz!");
            }
            else
            {
                int ID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
                cr.Delete(ID);
                Getir();
            }
        }
        Calisan guncelle;
        //SEciliyi alma
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int ID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);

                guncelle = cr.SelectById(ID);
                textBox1.Text = guncelle.CalisanAdi;
                textBox2.Text = guncelle.CalisanSoyadi;
            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            guncelle.CalisanAdi = textBox1.Text;
            guncelle.CalisanSoyadi = textBox2.Text;
            cr.Update(guncelle);
            Getir();
            Temizle();
        }

        void Temizle()
        {
            foreach (Control item in this.Controls)
            {
                if (item is TextBox)
                {
                    TextBox a = (TextBox)item;
                    a.Clear();

                }

            }
        }

        private void cmbBoxBirimler_SelectionChangeCommitted(object sender, EventArgs e)
        {
            int ID = (int)cmbBoxBirimler.SelectedValue;
            dataGridView1.DataSource = cr.SelectByCalisanID(ID).Select(p => new
            {
                p.CalisanBirimi,
                p.CalisanID
            }).ToList();
        }

        private void cmbBoxBirimler_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
