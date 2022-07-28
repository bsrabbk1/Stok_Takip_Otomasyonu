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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-I62Q8KU;Initial Catalog=Stok_takip_otomasyonu;Integrated Security=True");  // bağlantı tanımlama
        DataSet daset = new DataSet();

        private void sepetListele()
        {
            baglanti.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("select *from sepet",baglanti);   // tüm kayıtları göster
            adtr.Fill(daset, "sepet");
            dataGridView1.DataSource = daset.Tables["sepet"]; // kayıtları dataGridViewe getiriyoruz
            dataGridView1.Columns[0].Visible = false;  // birinci sütunu gizledik
            dataGridView1.Columns[1].Visible = false;  // ikinci sütunu gizledik
            dataGridView1.Columns[2].Visible = false;  // üçüncü sütunu gizledik
            baglanti.Close();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            sepetListele();
        }

        private void btnMusteriEkle_Click(object sender, EventArgs e)
        {
            frmMusteriEkle ekle = new frmMusteriEkle();
            ekle.Show();
        }

        private void btnMusteri_Click(object sender, EventArgs e)
        {
            frmMusteriListele listele = new frmMusteriListele();
            listele.Show();
        }

        private void btnUrunEkle_Click(object sender, EventArgs e)
        {
            frmÜrünEkleme ekle = new frmÜrünEkleme();
            ekle.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmKategori kategori = new frmKategori();
            kategori.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmMarka marka = new frmMarka();
            marka.Show();
        }

        private void btnUrunListele_Click(object sender, EventArgs e)
        {
            frmUrunListele listele = new frmUrunListele();
            listele.Show();
        }
        private void hesapla()
        {
            try
            {
                baglanti.Open();
                SqlCommand komut = new SqlCommand("select sum(toplamfiyati) from sepet",baglanti);
                lblGenelToplam.Text = komut.ExecuteScalar()+"TL";
                baglanti.Close();
            }
            catch (Exception)
            {

                ;
            }
        }

        private void txtTC_TextChanged(object sender, EventArgs e)
        {
            if (txtTC.Text=="")  // txtTC boş olursa
            {
                txtAdSoyad.Text = "";
                txtTelefon.Text = "";
            }

            baglanti.Open();
            SqlCommand komut = new SqlCommand("select *from musteri where tc like '"+txtTC.Text+"' ",baglanti);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                txtAdSoyad.Text = read["adsoyad"].ToString();
                txtTelefon.Text = read["telefon"].ToString();
            }
            baglanti.Close();
        }

        private void txtBarkodNo_TextChanged(object sender, EventArgs e)
        {
            Temizle();

            baglanti.Open();
            SqlCommand komut = new SqlCommand("select *from urun where barkodno like '" + txtBarkodNo.Text + "' ", baglanti);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                txtUrunAdi.Text = read["urunadi"].ToString();
                txtSatisFiyat.Text = read["satisfiyati"].ToString();
            }
            baglanti.Close();
        }

        private void Temizle()
        {
            if (txtBarkodNo.Text == "")
            {
                foreach (Control item in groupBox2.Controls)
                {
                    if (item is TextBox)  // itemlar textbox ise
                    {
                        if (item != txtMiktar)
                        {
                            item.Text = "";
                        }
                    }

                }
            }
        }

        bool durum;
        private void barkodKontrol()
        {
            durum = true;
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select *from sepet",baglanti);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                if (txtBarkodNo.Text==read["barkodno"].ToString())  // yani aynı barkodlu ürün sepette varsa miktar olarak üzerine ekleyelim.
                {
                    durum = false;
                }
            }
            baglanti.Close();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            barkodKontrol();
            if (durum==true)
            {
                baglanti.Open();
                SqlCommand komut = new SqlCommand("insert into sepet(tc,adsoyad,telefon,barkodno,urunadi,miktari,satisfiyati,toplamfiyati,tarih) values(@tc,@adsoyad,@telefon,@barkodno,@urunadi,@miktari,@satisfiyati,@toplamfiyati,@tarih)", baglanti);
                komut.Parameters.AddWithValue("@tc", txtTC.Text);
                komut.Parameters.AddWithValue("@adsoyad", txtAdSoyad.Text);
                komut.Parameters.AddWithValue("@telefon", txtTelefon.Text);
                komut.Parameters.AddWithValue("@barkodno", txtBarkodNo.Text);
                komut.Parameters.AddWithValue("@urunadi", txtUrunAdi.Text);
                komut.Parameters.AddWithValue("@miktari", int.Parse(txtMiktar.Text));
                komut.Parameters.AddWithValue("@satisfiyati", double.Parse(txtSatisFiyat.Text));
                komut.Parameters.AddWithValue("@toplamfiyati", double.Parse(txtToplamFiyat.Text));
                komut.Parameters.AddWithValue("@tarih", DateTime.Now.ToString());
                komut.ExecuteNonQuery();
                baglanti.Close();
            }
            else
            {
                baglanti.Open();
                SqlCommand komut2 = new SqlCommand("update sepet miktari=miktari+'"+int.Parse(txtMiktar.Text)+ "'where barkodno='" + txtBarkodNo.Text + "'", baglanti);
                komut2.ExecuteNonQuery();


                SqlCommand komut3 = new SqlCommand("update sepet toplamfiyati=miktari*satisfiyati where barkodno='"+txtBarkodNo.Text+"'", baglanti);
                komut3.ExecuteNonQuery();

                baglanti.Close();
            }

            txtMiktar.Text = "1";
            daset.Tables["sepet"].Clear();
            sepetListele();
            hesapla();
            foreach (Control item in groupBox2.Controls)
            {
                if (item is TextBox)  // itemlar textbox ise
                {
                    if (item != txtMiktar)
                    {
                        item.Text = "";
                    }
                }

            }
        }

        private void txtMiktar_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtToplamFiyat.Text =(double.Parse (txtMiktar.Text) * double.Parse(txtSatisFiyat.Text)).ToString();
            }
            catch (Exception)
            {


                ;
            }
        }

        private void txtSatisFiyat_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtToplamFiyat.Text = (double.Parse(txtMiktar.Text) * double.Parse(txtSatisFiyat.Text)).ToString();
            }
            catch (Exception)
            {


                ;
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("delete from sepet where barkodno='"+dataGridView1.CurrentRow.Cells["barkodno"].Value.ToString()+"'",baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
           
            MessageBox.Show("Ürün Sepetten Çıkarıldı.");
            daset.Tables["sepet"].Clear();   // kaydı yeniliyoruz
            sepetListele();
             hesapla();
        }

        private void btnSatisIptal_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("delete from sepet ", baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
           
            MessageBox.Show("Ürünler Sepetten Çıkarıldı.");
            daset.Tables["sepet"].Clear();   // kaydı yeniliyoruz
            
            sepetListele();
            hesapla();
        }

        private void btnSatislariListele_Click(object sender, EventArgs e)
        {
            frmSatisListele listele = new frmSatisListele();
            listele.Show();
        }

        private void btnSatisYap_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.Rows.Count-1; i++)  // kaçtane kayıt varsa
            {
                baglanti.Open();
                SqlCommand komut = new SqlCommand("insert into satis(tc,adsoyad,telefon,barkodno,urunadi,miktari,satisfiyati,toplamfiyati,tarih) values(@tc,@adsoyad,@telefon,@barkodno,@urunadi,@miktari,@satisfiyati,@toplamfiyati,@tarih)", baglanti);
                komut.Parameters.AddWithValue("@tc", txtTC.Text);
                komut.Parameters.AddWithValue("@adsoyad", txtAdSoyad.Text);
                komut.Parameters.AddWithValue("@telefon", txtTelefon.Text);
                komut.Parameters.AddWithValue("@barkodno", dataGridView1.Rows[i].Cells["barkodno"].Value.ToString());   // kaçtane kayıt varsa barkodno sütununa aktarıyoruz
                komut.Parameters.AddWithValue("@urunadi", dataGridView1.Rows[i].Cells["urunadi"].Value.ToString());
                komut.Parameters.AddWithValue("@miktari", int.Parse(dataGridView1.Rows[i].Cells["miktari"].Value.ToString()));
                komut.Parameters.AddWithValue("@satisfiyati", double.Parse(dataGridView1.Rows[i].Cells["satisfiyati"].Value.ToString()));
                komut.Parameters.AddWithValue("@toplamfiyati", double.Parse(dataGridView1.Rows[i].Cells["toplamfiyati"].Value.ToString()));
                komut.Parameters.AddWithValue("@tarih", DateTime.Now.ToString());
                komut.ExecuteNonQuery();

                SqlCommand komut2 = new SqlCommand("update urun set miktarı=miktarı-'" + int.Parse(dataGridView1.Rows[i].Cells["miktari"].Value.ToString()) + "'where barkodno='" + dataGridView1.Rows[i].Cells["barkodno"].Value.ToString() + "'", baglanti);
                komut2.ExecuteNonQuery();
                baglanti.Close();

            }
            baglanti.Open();
            SqlCommand komut3 = new SqlCommand("delete from sepet ", baglanti);
            komut3.ExecuteNonQuery();
            baglanti.Close();

            daset.Tables["sepet"].Clear();
            sepetListele();
            hesapla();
        }
    }
}
