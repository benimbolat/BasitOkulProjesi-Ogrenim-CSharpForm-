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
    public partial class FormSinavNotlari : Form
    {
        public FormSinavNotlari()
        {
            InitializeComponent();
        }

        private void linkLabelgeri_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Formogretmen fr = new Formogretmen();
            fr.Show();
        }

        private void linkLabelcıkıs_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Application.Exit();

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-HKI8OF4;Initial Catalog=OkulProjesi;Integrated Security=True");

        DataSet1TableAdapters.Table_NotTableAdapter ds = new DataSet1TableAdapters.Table_NotTableAdapter();
        private void FormSinavNotlari_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * From Table_Ders", baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            comboBoxders.DisplayMember = "dersad";
            comboBoxders.ValueMember = "dersid";
            comboBoxders.DataSource = dt;
            baglanti.Close();
        }
        int notid;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            notid =int.Parse( dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
           // comboBoxders.SelectedValue = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            textBoxoid.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            textBoxsınav1.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            textBoxsınav2.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            textBoxsınav3.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            textBoxproje.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            textBoxortalama.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
            textBoxdurum.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
        }

        private void buttonara_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.ntotlistesi(int.Parse(textBoxoid.Text));

        }
        int sınav1, sınav2, sınav3, proje;
        double ortalama;
        private void buttonhesapla_Click(object sender, EventArgs e)
        {
           
           // string durum;

            sınav1 = Convert.ToInt16(textBoxsınav1.Text);
            sınav2 = Convert.ToInt16(textBoxsınav2.Text);
            sınav3 = Convert.ToInt16(textBoxsınav3.Text);
            proje = Convert.ToInt16(textBoxproje.Text);


            ortalama = (sınav1 + sınav2 + sınav3 + proje) / 4;

            textBoxortalama.Text = ortalama.ToString();
            if (ortalama >= 50)
            {
                textBoxdurum.Text = "True";
            }
            else
            {
                textBoxdurum.Text = "False";

            }

        }

        private void buttonguncelle_Click(object sender, EventArgs e)
        {
            ds.guncellemenot(byte.Parse(comboBoxders.SelectedValue.ToString()), int.Parse(textBoxoid.Text), byte.Parse(textBoxsınav1.Text), byte.Parse(textBoxsınav2.Text), byte.Parse(textBoxsınav3.Text), byte.Parse(textBoxproje.Text), byte.Parse(textBoxortalama.Text), bool.Parse(textBoxdurum.Text), notid);
        }
    }
}
