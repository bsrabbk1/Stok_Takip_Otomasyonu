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
    public partial class frmMarka : Form
    {
        public frmMarka()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-I62Q8KU;Initial Catalog=Stok_takip_otomasyonu;Integrated Security=True");  // bağlantı tanımlama

        bool durum;
        private void markaKontrol()
        {
            durum = true;   /// durumu istemediğimiz işlemlerde false olarak tanımlıyoruz
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select *from markabilgileri", baglanti);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                if (comboBox1.Text==read["kategori"].ToString()&& textBox1.Text == read["marka"].ToString() ||comboBox1.Text==""|| textBox1.Text == "")   // textBox boşsa durumu false yapsın işlemi yapmasın
                {
                    durum = false;
                }
            }

            baglanti.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            markaKontrol();
            if (durum==true)
            {
                baglanti.Open();
                SqlCommand komut = new SqlCommand("insert into markabilgileri(kategori,marka) values('" + comboBox1.Text + "','" + textBox1.Text + "')", baglanti);  // komutu tanımlayıp neler yapacağımızı tanımlıyoruz.

                komut.ExecuteNonQuery();  // işlemi onaylıyoruz
                baglanti.Close();
                MessageBox.Show("Marka Eklendi.");
            }
            else
            {
                MessageBox.Show("Böyle bir kategori ve marka mevcut");
            }
            textBox1.Text = ""; // textBox içini boş yapıp temizlemiş oluyoruz.
            comboBox1.Text = "";// comboBox temizlendi.
          

        }

        private void frmMarka_Load(object sender, EventArgs e)
        {
            kategoriGetir();
        }

        private void kategoriGetir()
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select *from kategoribilgileri", baglanti);
            SqlDataReader read = komut.ExecuteReader();

            while (read.Read()) // kayıtlar okunduğu sürece döngü gerçekleşecek.
            {
                comboBox1.Items.Add(read["kategori"].ToString());
            }
            baglanti.Close();
        }
    }
}
