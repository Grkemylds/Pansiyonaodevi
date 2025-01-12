using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;

namespace Pansiyon_Uygulaması
{
    public partial class FrmGelirGider : Form
    {
        public FrmGelirGider()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=PHILIPS\\SQLEXPRESS;Initial Catalog=Pansiyon;Integrated Security=True;Encrypt=False");

        private void button1_Click(object sender, EventArgs e)
        {
            int personel;
            personel = Convert.ToInt16(textBox1.Text);
            lblPersonelMaas.Text = (personel * 20000).ToString();
            int sonuc;
            sonuc = Convert.ToInt32(lblKasaToplamTutar.Text) - (Convert.ToInt32(lblPersonelMaas.Text) +
                Convert.ToInt32(lblAlinanUrinler1.Text) + Convert.ToInt32(lblAlinanUrinler2.Text) +
                Convert.ToInt32(lblAlinanUrinler3.Text) + Convert.ToInt32(lblFaturalar1.Text) +
                Convert.ToInt32(lblFaturalar2.Text) + Convert.ToInt32(lblFaturalar3.Text));
            LblSonuc.Text = sonuc.ToString();
        }

        private void FrmGelirGider_Load(object sender, EventArgs e)
        {
            //Kasadaki Toplam Tutar
            baglanti.Open();
            string toplam_tutar = "Select  sum(Ucret) as toplam from MusteriEkle";
            SqlCommand komut = new SqlCommand(toplam_tutar, baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                lblKasaToplamTutar.Text = oku["toplam"].ToString();
            }
            baglanti.Close();

            //Gıda
            baglanti.Open();
            string toplam_tutar2 = "Select  sum(Gida) as toplam1 from Stoklar";
            SqlCommand komut2 = new SqlCommand(toplam_tutar2, baglanti);
            SqlDataReader oku2 = komut2.ExecuteReader();
            while (oku2.Read())
            {
                lblAlinanUrinler1.Text = oku2["toplam1"].ToString();
            }
            baglanti.Close();
            //İçecekler
            baglanti.Open();
            string toplam_tutar3 = "Select  sum(Icecek) as toplam2 from Stoklar";
            SqlCommand komut3 = new SqlCommand(toplam_tutar3, baglanti);
            SqlDataReader oku3 = komut3.ExecuteReader();
            while (oku3.Read())
            {
                lblAlinanUrinler2.Text = oku3["toplam2"].ToString();
            }
            baglanti.Close();

            //Çerezler
            baglanti.Open();
            string toplam_tutar4 = "Select  sum(Cerezler) as toplam3 from Stoklar";
            SqlCommand komut4 = new SqlCommand(toplam_tutar4, baglanti);
            SqlDataReader oku4 = komut4.ExecuteReader();
            while (oku4.Read())
            {
                lblAlinanUrinler3.Text = oku4["toplam3"].ToString();
            }
            baglanti.Close();

            //Elektirik
            baglanti.Open();
            string toplam_tutar5 = "Select  sum(Elektirik) as toplam4 from Faturalar";
            SqlCommand komut5 = new SqlCommand(toplam_tutar5, baglanti);
            SqlDataReader oku5 = komut5.ExecuteReader();
            while (oku5.Read())
            {
                lblFaturalar1.Text = oku5["toplam4"].ToString();
            }
            baglanti.Close();

            //Su
            baglanti.Open();
            string toplam_tutar6 = "Select  sum(Su) as toplam5 from Faturalar";
            SqlCommand komut6 = new SqlCommand(toplam_tutar6, baglanti);
            SqlDataReader oku6 = komut6.ExecuteReader();
            while (oku6.Read())
            {
                lblFaturalar2.Text = oku6["toplam5"].ToString();
            }
            baglanti.Close();

            //İnternet
            baglanti.Open();
            string toplam_tutar7 = "Select  sum(Internet) as toplam6 from Faturalar";
            SqlCommand komut7 = new SqlCommand(toplam_tutar7, baglanti);
            SqlDataReader oku7 = komut7.ExecuteReader();
            while (oku7.Read())
            {
                lblFaturalar3.Text = oku7["toplam6"].ToString();
            }
            baglanti.Close();


        }
    }
}
