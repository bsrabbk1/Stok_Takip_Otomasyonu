using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Stok_Takip_Otomasyonu
{
    public partial class frmSatisListele : Form
    {
        public frmSatisListele()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-I62Q8KU;Initial Catalog=Stok_takip_otomasyonu;Integrated Security=True");  // bağlantı tanımlama
        DataSet daset = new DataSet();
        private void satisListele()
        {
            baglanti.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("select *from satis", baglanti);   // tüm kayıtları göster
            adtr.Fill(daset, "satis");
            dataGridView1.DataSource = daset.Tables["satis"]; // kayıtları dataGridViewe getiriyoruz

            baglanti.Close();
        }

        private void frmSatisListele_Load(object sender, EventArgs e)
        {
            satisListele();
        }
    }
}
