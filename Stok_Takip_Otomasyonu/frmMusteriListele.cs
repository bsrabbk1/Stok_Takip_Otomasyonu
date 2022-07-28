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
    public partial class frmMusteriListele : Form
    {
        public frmMusteriListele()
        {
            InitializeComponent();
        }
       SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-I62Q8KU;Initial Catalog=Stok_takip_otomasyonu;Integrated Security=True");
        DataSet daset = new DataSet();
        private void frmMusteriListele_Load(object sender, EventArgs e)
        {
            Kayit_Goster();
        }

        private void Kayit_Goster()
        {
            baglanti.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("select *from musteri", baglanti);
            adtr.Fill(daset, "musteri");
            dataGridView1.DataSource = daset.Tables["musteri"];
            baglanti.Close();
        }


        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtTc.Text = dataGridView1.CurrentRow.Cells["tc"].Value.ToString();
            txtAdSoyad.Text = dataGridView1.CurrentRow.Cells["adsoyad"].Value.ToString();
            txtTelefon.Text = dataGridView1.CurrentRow.Cells["telefon"].Value.ToString();
            txtAdres.Text = dataGridView1.CurrentRow.Cells["adres"].Value.ToString();
            txtEmail.Text = dataGridView1.CurrentRow.Cells["email"].Value.ToString();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("update musteri set adsoyad=@adsoyad,telefon=@telefon,adres=@adres,email=@email where tc=@tc",baglanti);

            komut.Parameters.AddWithValue("@tc", txtTc.Text);
            komut.Parameters.AddWithValue("@adsoyad", txtAdSoyad.Text);
            komut.Parameters.AddWithValue("@telefon", txtTelefon.Text);
            komut.Parameters.AddWithValue("@adres", txtAdres.Text);
            komut.Parameters.AddWithValue("@email", txtEmail.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            daset.Tables["musteri"].Clear();   // Tabloyu temizler
            Kayit_Goster();  // Kayıt Göster methodu çağrılıyor
            MessageBox.Show("Müşteri Kayıtları Güncellendi.");
            foreach (Control item in this.Controls)
            {
                if (item is TextBox)
                {
                    item.Text = "";
                }
            }

        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("delete from musteri where tc='"+dataGridView1.CurrentRow.Cells["tc"].Value.ToString() +"'",baglanti);

            komut.ExecuteNonQuery();

            baglanti.Close();
            daset.Tables["musteri"].Clear();   // Tabloyu temizler
            Kayit_Goster();  // Kayıt Göster methodu çağrılıyor
            MessageBox.Show("Kayıtlar Silindi.");
        }

        private void txtTcAra_TextChanged(object sender, EventArgs e)
        {
            DataTable tablo = new DataTable();
            baglanti.Open(); // bağlantıyı açar
            SqlDataAdapter adtr = new SqlDataAdapter("select *from musteri where tc like '%" +txtTcAra.Text+"'",baglanti); // % koyduğumuz için tabloda kaç tane aradığımız kelime varsa başta ve sonda bakacak
            adtr.Fill(tablo);  // kayıtları tabloya aktaracağız
            dataGridView1.DataSource = tablo;  // datagridViewde gösteriyoruz
            baglanti.Close();
        
        }
       
    }
}
