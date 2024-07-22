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

namespace VeriTabanliSecim
{
    public partial class FrmOyGiris : Form
    {
        public FrmOyGiris()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=AHMET\SQLEXPRESS;Initial Catalog=SecimProje;Integrated Security=True");
        private void btnOyGir_Click(object sender, EventArgs e)
        {
           baglanti.Open();
            SqlCommand komut = new SqlCommand("Insert Into Ilce (IlceAd,Aparti,Bparti,Cparti,Dparti,Eparti) values (@P1,@P2,@P3,@P4,@P5,@P6)",baglanti);
            komut.Parameters.AddWithValue("@P1",textIlce.Text);
            komut.Parameters.AddWithValue("@P2", textA.Text);
            komut.Parameters.AddWithValue("@P3", textB.Text);
            komut.Parameters.AddWithValue("@P4", textC.Text);
            komut.Parameters.AddWithValue("@P5", textD.Text);
            komut.Parameters.AddWithValue("@P6", textE.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("OY GİRİŞİ BAŞARILI");
           
        }

        private void btnGrafik_Click(object sender, EventArgs e)
        {
            FrmGrafikler grafikler= new FrmGrafikler();
            grafikler.Show();  
        }

        private void btnCıkıs_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }
    }
}
