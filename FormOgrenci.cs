using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Okul_Projesi
{
    public partial class FormOgrenci : Form
    {
        public FormOgrenci()
        {
            InitializeComponent();
        }
        string c = "";

        private void buttondersekle_Click(object sender, EventArgs e)
        {
           
            ds.ogrenciekle(txtad.Text, txtsad.Text,c, byte.Parse(comboBoxkulup.SelectedValue.ToString()));
            MessageBox.Show("Ekleme işlemi tamamlandı.");
            dataGridView1.DataSource = ds.ogrencilistesi();

        }

        private void linkLabelcıkıs_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Application.Exit();

        }
        DataSet1TableAdapters.DataTable1TableAdapter ds = new DataSet1TableAdapters.DataTable1TableAdapter();
        private void linkLabelgeri_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Formogretmen fr = new Formogretmen();
            fr.Show();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-HKI8OF4;Initial Catalog=OkulProjesi;Integrated Security=True");

        private void FormOgrenci_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.ogrencilistesi();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * From Table_Kulup", baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            comboBoxkulup.DisplayMember = "kulupad";
            comboBoxkulup.ValueMember = "kulupid";
            comboBoxkulup.DataSource = dt;
            baglanti.Close();

        }

        private void buttondersListele_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.ogrencilistesi();

        }

        private void buttonderssil_Click(object sender, EventArgs e)
        {
            ds.Silmesorgusu(int.Parse(txtid.Text));
            dataGridView1.DataSource = ds.ogrencilistesi();

        }

        private void buttondersguncelle_Click(object sender, EventArgs e)
        {
            ds.guncellemesorgusu(txtad.Text, txtsad.Text, byte.Parse(comboBoxkulup.SelectedValue.ToString()), c, int.Parse(txtid.Text));
            dataGridView1.DataSource = ds.ogrencilistesi();

        }

        private void comboBoxkulup_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtid.Text = comboBoxkulup.SelectedValue.ToString();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtid.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtad.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtsad.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
           // comboBoxkulup.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
           // c = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
        }

        private void radioButtonOglan_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonOglan.Checked == true)
            {
                c = "Erkek";
            }
           
        }

        private void radiobuttonkız_CheckedChanged(object sender, EventArgs e)
        {
          
            if (radiobuttonkız.Checked == true)
            {
                c = "Kız";
            }
        }
    }
}
