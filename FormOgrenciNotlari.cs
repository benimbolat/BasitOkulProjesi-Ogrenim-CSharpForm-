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
    public partial class FormOgrenciNotlari : Form
    {
        public FormOgrenciNotlari()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-HKI8OF4;Initial Catalog=OkulProjesi;Integrated Security=True");
        public string numara;
        private void FormOgrenciNotlari_Load(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Select dersad,sınav1,sınav2,sınav3,proje,ortlama,durum From Table_Not inner join table_ders on table_not.dersid=table_ders.dersid where ogrenciiid=1", baglanti);
            komut.Parameters.AddWithValue("@p1", numara);
            // this.Text.ToString();

            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt ;
        }
    }
}
