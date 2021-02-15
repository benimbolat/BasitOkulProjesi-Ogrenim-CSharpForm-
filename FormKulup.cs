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
    public partial class FormKulup : Form
    {
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-HKI8OF4;Initial Catalog=OkulProjesi;Integrated Security=True");

        public FormKulup()
        {
            InitializeComponent();
        }
        public void liste ()
        {
            SqlDataAdapter da = new SqlDataAdapter("Select * Form Table_Kulup", baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        private void FormKulup_Load(object sender, EventArgs e)
        {
            liste();
        }

        private void buttonListele_Click(object sender, EventArgs e)
        {
            liste();

        }

        private void buttonekle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into Table_Kulup (kulupad) Values (@p1)", baglanti);
            komut.Parameters.AddWithValue("@p1", textBoxad.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kulüp Listeye Eklendi","Bilgi");



        }
    }
}
