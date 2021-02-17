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
    public partial class FormDers : Form
    {
        public FormDers()
        {
            InitializeComponent();
        }
        DataSet1TableAdapters.Table_DersTableAdapter ds = new DataSet1TableAdapters.Table_DersTableAdapter();

        private void FormDers_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.Derslistesi();
        }

        private void buttondersListele_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.Derslistesi();
            MessageBox.Show("Ders listeleme işlemi başarılı");

        }

        private void buttondersguncelle_Click(object sender, EventArgs e)
        {
            ds.dersguncelle(textBoxdersad.Text,byte.Parse(textBoxdersid.Text));
            dataGridView1.DataSource = ds.Derslistesi();
            MessageBox.Show("Ders güncelleme işlemi başarılı");

        }

        private void buttondersekle_Click(object sender, EventArgs e)
        {
            ds.dersekle(textBoxdersad.Text);
            MessageBox.Show("Ders ekleme işlemi başarılı");
            dataGridView1.DataSource = ds.Derslistesi();

        }

        private void buttonderssil_Click(object sender, EventArgs e)
        {
            ds.Derssil(byte.Parse(textBoxdersid.Text));
            dataGridView1.DataSource = ds.Derslistesi();
            MessageBox.Show("Ders silme işlemi başarılı");

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBoxdersid.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            textBoxdersad.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
        }
    }
}
