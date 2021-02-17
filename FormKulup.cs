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
            SqlDataAdapter da = new SqlDataAdapter("Select * From Table_Kulup", baglanti);
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
            liste();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBoxid.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            textBoxad.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
        }

        private void buttonsil_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Delete From Table_Kulup where kulupid=@p1",baglanti);
            komut.Parameters.AddWithValue("@p1", textBoxid.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kulup silme işlemi başarıyla gerçekleşti.","Başarılı işlem");
            liste();
        }

        private void buttonguncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Update Table_Kulup set kulupad=@p1 where kulupid=@p2", baglanti);
            komut.Parameters.AddWithValue("@p1", textBoxad.Text);
            komut.Parameters.AddWithValue("@p2", textBoxid.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kulup güncelleme işlemi başarıyla gerçekleşti.", "Başarılı işlem");
            liste();
        }
    }
}
