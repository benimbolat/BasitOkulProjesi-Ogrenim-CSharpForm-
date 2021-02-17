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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            FormOgrenciNotlari fr = new FormOgrenciNotlari();
            fr.numara = textBox1.Text;
            fr.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Formogretmen frogrt = new Formogretmen();
            frogrt.Show();
        }
    }
}
