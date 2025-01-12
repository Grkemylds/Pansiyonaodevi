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
    public partial class sifreGuncelle : Form
    {
        public sifreGuncelle()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=PHILIPS\\SQLEXPRESS;Initial Catalog=Pansiyon;Integrated Security=True;Encrypt=False");

        private void sifreGuncelle_Load(object sender, EventArgs e)
        {

        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
             baglanti.Open();

            string sorgu = "update AdminGiris set KullaniciAdi='" + TxtKullaniciAdi.Text +
            "', Sifre='" + txtSifre.Text +"'";

            SqlCommand komut = new SqlCommand(sorgu, baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            
            MessageBox.Show("Şifre Güncellendi");

        }
    }
}
