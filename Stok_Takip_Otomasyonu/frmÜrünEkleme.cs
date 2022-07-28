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
    public partial class frmÜrünEkleme : Form
    {
        public frmÜrünEkleme()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-I62Q8KU;Initial Catalog=Stok_takip_otomasyonu;Integrated Security=True");  // bağlantı tanımlama


        bool durum;
        private void barkodKontrol()
        {
            durum = true;   /// durumu istemediğimiz işlemlerde false olarak tanımlıyoruz
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select *from urun", baglanti);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                if (txtBarkodno.Text==read["barkodno"].ToString() || txtBarkodno.Text=="" )   // barkodno varsa veya text boş geçilirse
                {
                    durum = false;
                }
            }

            baglanti.Close();
        }

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
        private void frmÜrünEkleme_Load(object sender, EventArgs e)
        {
            kategoriGetir(); // methodu çağırdık

        }

        private void comboKategori_SelectedIndexChanged(object sender, EventArgs e)
        {
            // comboBoxKategoriye göre seçtiğimiz ürünlerin markasını göstermesi ve diğerlerini silmesi için:

            comboMarka.Items.Clear(); // combobox içeriğini silsin
            comboMarka.Text = "";   // comboBox textini de temizlesin.
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select *from markabilgileri where kategori='"+comboKategori.SelectedItem+"'", baglanti);
            SqlDataReader read = komut.ExecuteReader();

            while (read.Read()) // kayıtlar okunduğu sürece döngü gerçekleşecek.
            {
                comboMarka.Items.Add(read["marka"].ToString());
            }
            baglanti.Close();
        }

        private void btnYeniEkle_Click(object sender, EventArgs e)
        {
            barkodKontrol();
            if (durum==true)
            {
                baglanti.Open();
                SqlCommand komut = new SqlCommand("insert into urun(barkodno,kategori,marka,urunadi,miktarı,alisfiyati,satisfiyati,tarih) values(@barkodno,@kategori,@marka,@urunadi,@miktarı,@alisfiyati,@satisfiyati,@tarih)", baglanti);
                komut.Parameters.AddWithValue("@barkodno", txtBarkodno.Text);
                komut.Parameters.AddWithValue("@kategori", comboKategori.Text);
                komut.Parameters.AddWithValue("@marka", comboMarka.Text);
                komut.Parameters.AddWithValue("@urunadi", txtUrunadi.Text);
                komut.Parameters.AddWithValue("@miktarı", int.Parse(txtMiktar.Text));
                komut.Parameters.AddWithValue("@alisfiyati", double.Parse(txtAlisFiyati.Text));
                komut.Parameters.AddWithValue("@satisfiyati", double.Parse(txtSatisFiyatı.Text));
                komut.Parameters.AddWithValue("@tarih", DateTime.Now.ToString());
                komut.ExecuteNonQuery();

                baglanti.Close();
                MessageBox.Show("Ürün Eklendi.");
            }
            else
            {
                MessageBox.Show("Barkodno mevcut");
            }
           
            comboMarka.Items.Clear();
            foreach (Control item in groupBox1.Controls)
            {
                if (item is TextBox)  // textBozları temzilemesi için
                {
                    item.Text = "";
                } 
                
                if (item is ComboBox)  // comboBoxları temizlesi için
                {
                    item.Text = "";
                }
            }
        
        
        }

        private void Barkodnotxt_TextChanged(object sender, EventArgs e)
        {

            if (Barkodnotxt.Text=="")  /// barkodNo texti boş ise
            {
                foreach (Control item in groupBox2.Controls)
                {
                    lblMiktar.Text = "";   // lblMiktarı temizlesin

                    if (item is TextBox)   // textBox olanları temizlesin
                    {
                        item.Text = "";
                    }
                }
            }

            baglanti.Open();
            SqlCommand komut = new SqlCommand("select *from urun where barkodno like '"+ Barkodnotxt.Text+"' ",baglanti);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                Kategoritxt.Text = read["kategori"].ToString();
                Markatxt.Text = read["marka"].ToString();
                Urunaditxt.Text = read["urunadi"].ToString();
                lblMiktar.Text = read["miktarı"].ToString();
                AlisFiyatitxt.Text = read["alisfiyati"].ToString();
                SatisFiyatitxt.Text = read["satisfiyati"].ToString();


            }
            baglanti.Close();
        }

        private void btnMevcutEkle_Click(object sender, EventArgs e)
        {
            baglanti.Open();

            SqlCommand komut = new SqlCommand("update urun set miktarı=miktarı+'"+int.Parse(Miktartxt.Text)+"'where barkodno='"+Barkodnotxt.Text+"'",baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            foreach (Control item in groupBox2.Controls)
            {
                lblMiktar.Text = "";   // lblMiktarı temizlesin

                if (item is TextBox)   // textBox olanları temizlesin
                {
                    item.Text = "";
                }
            }
            MessageBox.Show("Mevcut Ürüne Ekleme Yapıldı");
        }
    }
}
