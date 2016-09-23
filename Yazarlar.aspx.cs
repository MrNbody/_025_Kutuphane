using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _025_Kutuphane
{
    public partial class Yazarlar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            YazarListele();
            //YazarListeleEntity();
        }
        public void YazarListeleEntity()
        {
            KutuphaneEntities ke = new KutuphaneEntities();
            var sorgu = (from yazar in ke.Yazars
                         select yazar).ToList();
            listYazar.DataSource = sorgu;
            listYazar.DataBind();
        }
        public void YazarListele()
        {
            SqlConnection con = new SqlConnection
            (ConfigurationManager.ConnectionStrings[0].ConnectionString);
            string cmdstring;
            SqlCommand cmd;
            cmdstring = "select yazarID, yazarAdi from Yazar";
            cmd = new SqlCommand(cmdstring, con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            listYazar.DataSource = dr;
            listYazar.DataBind();
            con.Close();
        }

        /*protected void btnYazarAra_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings[0].ConnectionString);
            SqlCommand komut;

            if (txtYazarAra.Text.Contains(' '))
            {
                string sorgu = "Select ID From Yazarlar where Adi=@YazarAdi and Soyadi=@YazarSoyadi";
                komut = new SqlCommand(sorgu, con);
                string[] adSoyad;
                adSoyad = txtYazarAra.Text.Split(' ');
                komut.Parameters.AddWithValue("YazarAdi", adSoyad[0]);
                komut.Parameters.AddWithValue("YazarSoyadi", adSoyad[1]);
                con.Open();
            }
            else
            {
                string sorgu = "Select ID From Yazarlar where Adi=@YazarAdi or Soyadi=@YazarAdi";
                komut = new SqlCommand(sorgu, con);
                komut.Parameters.AddWithValue("YazarAdi", txtYazarAra.Text);
                con.Open();
            }

            SqlDataReader rd = komut.ExecuteReader();
            if (rd.Read())
            {
                //Session.Add("kitapID", rd["ID"].ToString());
                Response.Redirect(("Yazar.aspx?id=" + rd["ID"].ToString()));// post işlemi
            }
        }*/
    }
}