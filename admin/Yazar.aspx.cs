using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _025_Kutuphane.admin
{
    public partial class Yazar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            object admin = Session["admin"];
            if (admin == null)
            {
                Response.Redirect("Admin.aspx");
            }
            if (!IsPostBack){
                if (!string.IsNullOrEmpty(Request.QueryString["yazarID"])){
                    pnlEkle.Visible = false;
                    pnlGuncelle.Visible = true;
                    YazarDoldurEntity();
                    //YazarDoldur();
                }
            }
        }
        private void YazarDoldurEntity()
        {
            int yazarID = Convert.ToInt32
                (Request.QueryString["yazarID"]);
            KutuphaneEntities ke = new KutuphaneEntities();
            var sorgu = (from yazar in ke.Yazars
                         where yazar.yazarID == yazarID
                         select yazar).FirstOrDefault();
            txtYazarAdi.Text = sorgu.yazarAdi;
            txtYazarDogum.Text = Convert.ToDateTime
                (sorgu.yazarDogum).ToShortDateString();
            txtYazarOzet.Text = sorgu.hayatOzeti;
            txtYazarResim.Text = sorgu.yazarResim;
        }
        public void YazarDoldur()
        {
            SqlConnection con = new SqlConnection
            (ConfigurationManager.ConnectionStrings[0].ConnectionString);
            string sorgu = "SELECT * FROM Yazar WHERE yazarID=@yazarID";
            SqlCommand cmd = new SqlCommand(sorgu, con);
            cmd.Parameters.AddWithValue("yazarId", 
                Request.QueryString["yazarID"].ToString());
            if (con.State == System.Data.ConnectionState.Closed)
                con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            txtYazarAdi.Text = dr["yazarAdi"].ToString();
            txtYazarDogum.Text = Convert.ToDateTime
                (dr["yazarDogum"]).ToShortDateString();
            txtYazarOzet.Text = dr["hayatOzeti"].ToString();
            txtYazarResim.Text = dr["yazarResim"].ToString();
            dr.Close();
            con.Close();
        }
        protected void btnekle_Click(object sender, EventArgs e)
        {
            YazarEkleEntity();
            //YazarEkle();
        }
        private void YazarEkleEntity()
        {
            KutuphaneEntities ke = new KutuphaneEntities();
            _025_Kutuphane.Yazar yazar = new _025_Kutuphane.Yazar();
            yazar.yazarAdi = txtYazarAdi.Text.ToString();
            yazar.yazarDogum = Convert.ToDateTime(txtYazarDogum.Text);
            yazar.hayatOzeti = txtYazarOzet.Text.ToString();
            yazar.yazarResim = txtYazarResim.Text.ToString();
            ke.Yazars.Add(yazar);
            ke.SaveChanges();
            lblSonuc.Text = "Eklendi";
        }
        private void YazarEkle()
        {
            SqlConnection con = new SqlConnection
            (ConfigurationManager.ConnectionStrings[0].ConnectionString);
            string sorgu = "INSERT INTO Yazar (yazarAdi, " +
                "yazarDogum, hayatOzeti, yazarResim) VALUES" +
                "(@yazarAdi, @yazarDogum, @hayatOzeti, @yazarResim)";
            SqlCommand cmd = new SqlCommand(sorgu, con);
            cmd.Parameters.AddWithValue("yazarAdi", txtYazarAdi.Text);
            cmd.Parameters.AddWithValue("yazarDogum", txtYazarDogum.Text);
            cmd.Parameters.AddWithValue("hayatOzeti", txtYazarOzet.Text);
            cmd.Parameters.AddWithValue("yazarResim", txtYazarResim.Text);
            con.Open();
            cmd.ExecuteNonQuery();
            lblSonuc.Text = "Eklendi";
        }

        protected void btnGuncelle_Click(object sender, EventArgs e)
        {
            YazarGuncelleEntity();
            //YazarGuncelle();
        }
        private void YazarGuncelleEntity()
        {
            int yazarID = Convert.ToInt32
                (Request.QueryString["yazarID"]);
            KutuphaneEntities ke = new KutuphaneEntities();
            var sorgu = (from yazar in ke.Yazars
                         where yazar.yazarID == yazarID
                         select yazar).FirstOrDefault();
            sorgu.yazarAdi = txtYazarAdi.Text.ToString();
            sorgu.yazarDogum = Convert.ToDateTime(txtYazarDogum.Text);
            sorgu.hayatOzeti = txtYazarOzet.Text.ToString();
            sorgu.yazarResim = txtYazarResim.Text.ToString();
            ke.SaveChanges();
            lblSonuc.Text = "Guncellendi";
        }
        private void YazarGuncelle()
        {
            SqlConnection con = new SqlConnection
            (ConfigurationManager.ConnectionStrings[0].ConnectionString);
            string sorgu = "UPDATE Yazar SET yazarAdi=@yazarAdi," +
                "yazarDogum=@yazarDogum, hayatOzeti=@hayatOzeti," +
                "yazarResim=@yazarResim WHERE yazarID=@yazarID";
            SqlCommand cmd = new SqlCommand(sorgu, con);
            cmd.Parameters.AddWithValue("yazarAdi", txtYazarAdi.Text);
            cmd.Parameters.AddWithValue("yazarDogum",
                Convert.ToDateTime(txtYazarDogum.Text));
            cmd.Parameters.AddWithValue("hayatOzeti", txtYazarOzet.Text);
            cmd.Parameters.AddWithValue("yazarResim", txtYazarResim.Text);
            cmd.Parameters.AddWithValue("yazarID", Request.QueryString["yazarID"]);
            con.Open();
            cmd.ExecuteNonQuery();
            lblSonuc.Text = "Guncellendi";
        }
    }
}