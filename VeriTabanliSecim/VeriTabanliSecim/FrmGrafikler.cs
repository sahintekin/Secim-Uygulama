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
    public partial class FrmGrafikler : Form
    {
        public FrmGrafikler()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=AHMET\SQLEXPRESS;Initial Catalog=SecimProje;Integrated Security=True");

        private void FrmGrafikler_Load(object sender, EventArgs e)
        {

            // ilçe adlarını comboya çekme
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select IlceAd From Ilce", baglanti);
            SqlDataReader dr= komut.ExecuteReader();
            while (dr.Read()) 
            {
                comboBox1.Items.Add(dr[0]);
            }
            baglanti.Close();

            // Grafiğe toplam sonucları getirme;
            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("Select SUM(Aparti),SUM(Bparti),SUM(Cparti),SUM(Dparti),SUM(Eparti) from Ilce ", baglanti);
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                chart1.Series["Partiler"].Points.AddXY("A Parti", dr2[0]);
                chart1.Series["Partiler"].Points.AddXY("B Parti", dr2[1]);
                chart1.Series["Partiler"].Points.AddXY("C Parti", dr2[2]);
                chart1.Series["Partiler"].Points.AddXY("D Parti", dr2[3]);
                chart1.Series["Partiler"].Points.AddXY("E Parti", dr2[4]);
              
            }
            baglanti.Close();


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * From Ilce Where IlceAd=@P1", baglanti);
            komut.Parameters.AddWithValue("@P1", comboBox1.Text);
            komut.ExecuteNonQuery();
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                progressBarA.Value = int.Parse(dr[2].ToString());
                progressBarB.Value = int.Parse(dr[3].ToString());
                progressBarC.Value = int.Parse(dr[4].ToString());
                progressBarD.Value = int.Parse(dr[5].ToString());
                progressBarE.Value = int.Parse(dr[6].ToString());

                lblA.Text = dr[2].ToString();
                lblB.Text = dr[3].ToString();
                lblC.Text = dr[4].ToString();
                lblD.Text = dr[5].ToString();
                lblE.Text = dr[6].ToString();
            }
            baglanti.Close();
        }
    }
}
