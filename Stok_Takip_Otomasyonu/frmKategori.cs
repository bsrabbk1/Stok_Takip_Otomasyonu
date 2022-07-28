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
    public partial class frmKategori : Form
    {
        public frmKategori()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-I62Q8KU;Initial Catalog=Stok_takip_otomasyonu;Integrated Security=True");  // bağlantı tanımlama

        bool durum;
        private void kategoriKontrol()
        {
            durum = true;   /// durumu istemediğimiz işlemlerde false olarak tanımlıyoruz
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select *from kategoribilgileri",baglanti);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                if (textBox1.Text==read["kategori"].ToString() || textBox1.Text=="")   // textBox boşsa durumu false yapsın işlemi yapmasın
                {
                    durum = false;
                }
            }

            baglanti.Close();
        }
        private void frmKategori_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            kategoriKontrol();
            if (durum==true)  // durum true ise işlemleri yap
            {
                baglanti.Open();
                SqlCommand komut = new SqlCommand("insert into kategoribilgileri(kategori) values('" + textBox1.Text + "')", baglanti);  // komutu tanımlayıp neler yapacağımızı tanımlıyoruz.

                komut.ExecuteNonQuery();  // işlemi onaylıyoruz
                baglanti.Close();
               
                MessageBox.Show("Kategori Eklendi.");
            }
            else
            {
                MessageBox.Show("Bu Kategori Mevcut");
            }
            textBox1.Text = ""; // textBox içini boş yapıp temizlemiş oluyoruz.


        }
    }
}
