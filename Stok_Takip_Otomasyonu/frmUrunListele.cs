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
namespace Stok_Takip_Otomasyonu
{
    public partial class frmUrunListele : Form
    {
        public frmUrunListele()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-I62Q8KU;Initial Catalog=Stok_takip_otomasyonu;Integrated Security=True");  // bağlantı tanımlama
        DataSet daset = new DataSet();

        private void kategoriGetir()
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select *from kategoribilgileri", baglanti);
            SqlDataReader read = komut.ExecuteReader();

            while (read.Read()) // kayıtlar okunduğu sürece döngü gerçekleşecek.
            {
                comboKategori.Items.Add(read["kategori"].ToString());
            }
            baglanti.Close();
        }

        private void frmUrunListele_Load(object sender, EventArgs e)
        {
            UrunListele();
            kategoriGetir();

        }

        private void UrunListele()
        {
            baglanti.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("select *from urun", baglanti);  // kayıtları tuttuğumuz geçici tablo
            adtr.Fill(daset, "urun");
            dataGridView1.DataSource = daset.Tables["urun"];
            baglanti.Close();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)  // datagridview çift tıkladığımızda ürünleri getirmek için:
        {
            Barkodnotxt.Text = dataGridView1.CurrentRow.Cells["barkodno"].Value.ToString();
            Kategoritxt.Text = dataGridView1.CurrentRow.Cells["kategori"].Value.ToString();
            Markatxt.Text = dataGridView1.CurrentRow.Cells["marka"].Value.ToString();
            Urunaditxt.Text = dataGridView1.CurrentRow.Cells["urunadi"].Value.ToString();
            Miktartxt.Text = dataGridView1.CurrentRow.Cells["miktarı"].Value.ToString();
            AlisFiyatitxt.Text = dataGridView1.CurrentRow.Cells["alisfiyati"].Value.ToString();
            SatisFiyatitxt.Text = dataGridView1.CurrentRow.Cells["satisfiyati"].Value.ToString();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("update urun set urunadi=@urunadi,miktarı=@miktarı,alisfiyati=@alisfiyati,satisfiyati=@satisfiyati where barkodno=@barkodno",baglanti);  // değişen ürünleri belirleyip bunları barkodnoya göre düzenlicez
            komut.Parameters.AddWithValue("@barkodno", Barkodnotxt.Text);
            komut.Parameters.AddWithValue("@urunadi", Urunaditxt.Text);
            komut.Parameters.AddWithValue("@miktarı",int.Parse( Miktartxt.Text));
            komut.Parameters.AddWithValue("@alisfiyati",double.Parse( AlisFiyatitxt.Text));
            komut.Parameters.AddWithValue("@satisfiyati",double.Parse( SatisFiyatitxt.Text));
            komut.ExecuteNonQuery();
            baglanti.Close();
            daset.Tables["urun"].Clear();  // tabloyu temizliyor
            UrunListele();   // listeliyor
            MessageBox.Show("Güncelleme Gerçekleşti");
            foreach (Control item in this.Controls)  // formdaki kontrolleri dolaş
            {
                if (item is TextBox)  // eğer kontroller textBox ise temizle
                {
                    item.Text = "";
                }
            }
        }

        private void btnKatMarkaGuncelle_Click(object sender, EventArgs e)
        {
              
            if (Barkodnotxt.Text!="")  // barkodno texti boş değilse işlemleri yap
            {
                baglanti.Open();
                SqlCommand komut = new SqlCommand("update urun set kategori=@kategori,marka=@marka where barkodno=@barkodno", baglanti);  // değişen ürünleri belirleyip bunları barkodnoya göre düzenlicez
                komut.Parameters.AddWithValue("@barkodno", Barkodnotxt.Text);
                komut.Parameters.AddWithValue("@kategori", comboKategori.Text);
                komut.Parameters.AddWithValue("@marka", comboMarka.Text);

                komut.ExecuteNonQuery();
                baglanti.Close();

                MessageBox.Show("Güncelleme Gerçekleşti");
                daset.Tables["urun"].Clear();  // tabloyu temizliyor
                UrunListele();   // listeliyor
            }
            else
            {
                MessageBox.Show("Barkodno Seçilmedi");
            }
           
            foreach (Control item in this.Controls)  // formdaki kontrolleri dolaş
            {
                if (item is ComboBox)  // eğer kontroller ComboBox ise temizle
                {
                    item.Text = "";
                }
            }
        }

        private void comboKategori_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboMarka.Items.Clear(); // combobox içeriğini silsin
            comboMarka.Text = "";   // comboBox textini de temizlesin.
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select *from markabilgileri where kategori='" + comboKategori.SelectedItem + "'", baglanti);
            SqlDataReader read = komut.ExecuteReader();

            while (read.Read()) // kayıtlar okunduğu sürece döngü gerçekleşecek.
            {
                comboMarka.Items.Add(read["marka"].ToString());
            }
            baglanti.Close();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("delete from urun where barkodno='" + dataGridView1.CurrentRow.Cells["barkodno"].Value.ToString() + "'", baglanti);

            komut.ExecuteNonQuery();

            baglanti.Close();
            daset.Tables["urun"].Clear();   // Tabloyu temizler
            UrunListele();  // Kayıt Göster methodu çağrılıyor
            MessageBox.Show("Kayıtlar Silindi.");
        }

        private void txtBarkodNoAra_TextChanged(object sender, EventArgs e)
        {
            DataTable tablo = new DataTable();  // geçici tablo tanımlıyoruz
            baglanti.Open(); // bağlantıyı açar
            SqlDataAdapter adtr = new SqlDataAdapter("select *from urun where barkodno like '%" + txtBarkodNoAra.Text + "'", baglanti); // % koyduğumuz için tabloda kaç tane aradığımız kelime varsa başta ve sonda bakacak
            adtr.Fill(tablo);  // kayıtları tabloya aktaracağız
            dataGridView1.DataSource = tablo;  // datagridViewde gösteriyoruz
            baglanti.Close();
        }
    }
}
