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
    public partial class Yazar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                YazarListele();
                //YazarListeleEntity();
            }
        }
        private void YazarListeleEntity()
        {
            if (!string.IsNullOrEmpty(Request.QueryString["yazarID"]))
            {
                int yazarID = Convert.ToInt32(Request.QueryString["yazarID"]);
                KutuphaneEntities ke = new KutuphaneEntities();
                var sorgu = (from yazar in ke.Yazars
                             where yazar.yazarID == yazarID
                             select yazar).FirstOrDefault();
                lblBaslik.Text = "Yazar Hakkında";
                lblOzet.Text = sorgu.hayatOzeti;
                lblYazarAdi.Text = sorgu.yazarAdi;
                lblYazarDogum.Text = Convert.ToDateTime
                    (sorgu.yazarDogum).ToShortDateString();
                imgKitap.ImageUrl = sorgu.yazarResim;
            }
        }
        public void YazarListele()
        {
            if (!string.IsNullOrEmpty(Request.QueryString["yazarID"]))
            {
                SqlConnection con = new SqlConnection
                (ConfigurationManager.ConnectionStrings[0].ConnectionString);
                string cmdstring = "select * from Yazar "+
                    "where yazarID=@yazarID";
                SqlCommand cmd = new SqlCommand(cmdstring, con);
                cmd.Parameters.AddWithValue("@yazarID",
                    Request.QueryString["yazarID"].ToString());
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    imgKitap.ImageUrl = dr["yazarResim"].ToString();
                    lblYazarAdi.Text = dr["yazarAdi"].ToString();
                    //lblKitapSayfa.Text = dr["SayfaSayisi"].ToString();
                    lblYazarDogum.Text = Convert.ToDateTime
                        (dr["yazarDogum"]).ToShortDateString();
                    lblOzet.Text = dr["hayatOzeti"].ToString();
                    lblBaslik.Text = "Yazar Hakkında";
                }
                con.Close();
            }
        }
    }
}