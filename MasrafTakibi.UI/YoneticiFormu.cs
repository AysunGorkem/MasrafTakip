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
    public partial class YoneticiFormu : Form
    {
        public YoneticiFormu()
        {
            InitializeComponent();
        }
        YoneticiRepository yr = new YoneticiRepository();

        private void btnUnvan_Click(object sender, EventArgs e)
        {
            comboBox1.DataSource = yr.SelectAll().Select(x => new
            {
                Unvan = x.YoneticiUnvani,
                x.YoneticiID
            }).ToList();
            comboBox1.DisplayMember = "YoneticiUnvani";
            comboBox1.ValueMember = "YoneticiID";
        }
        public void Getir()
        {
            dataGridView1.DataSource = yr.SelectAll().ToList();
        }


        private void btnKaydet_Click(object sender, EventArgs e)
        {
            Yonetici y = new Yonetici();
            y.YoneticiAdi = textBox1.Text;
            y.YoneticiUnvani = textBox2.Text;
            yr.Insert(y);
            Getir();
        }

        private void btnGetir_Click(object sender, EventArgs e)
        {
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
                yr.Delete(ID);
                Getir();
            }
        }
        Yonetici guncelle;

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int ID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);

                guncelle = yr.SelectById(ID);
                textBox1.Text = guncelle.YoneticiAdi;
                textBox2.Text = guncelle.YoneticiUnvani;
            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            guncelle.YoneticiAdi = textBox1.Text;
            guncelle.YoneticiUnvani = textBox2.Text;
            yr.Update(guncelle);
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

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            int ID = (int)comboBox1.SelectedValue;
            dataGridView1.DataSource = yr.SelectByYoneticiID(ID).Select(p => new
            {
                p.YoneticiUnvani,
                p.YoneticiID
            }).ToList();
        }
    }
}
