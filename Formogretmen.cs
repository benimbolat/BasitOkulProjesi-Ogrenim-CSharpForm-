using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Okul_Projesi
{
    public partial class Formogretmen : Form
    {
        public Formogretmen()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormKulup fr = new FormKulup();
            fr.Show();
            this.Hide();
    
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormDers frders = new FormDers();
            frders.Show();
            this.Hide();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            FormOgrenci fr = new FormOgrenci();
            fr.Show();
            this.Hide();
        }

        private void linkLabelcıkıs_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Application.Exit();

        }

        private void linkLabelgeri_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form1 fr = new Form1();
            fr.Show();
            this.Hide();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            FormSinavNotlari fr = new FormSinavNotlari();
            fr.Show();
            this.Hide();
        }
    }
}
