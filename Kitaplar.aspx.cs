using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

namespace _025_Kutuphane
{
    public partial class Kitaplar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            KitaplarListele();
            //KitapListeleEntity();
        }
        private void KitapListeleEntity()
        {
            KutuphaneEntities ke = new KutuphaneEntities();
            List<viewKitap> kitaplar;
            string kitapAdi, turAciklama;
            if (!string.IsNullOrEmpty(Request.QueryString["turAciklama"]))
            {
                turAciklama = Request.QueryString["turAciklama"];
                kitaplar = ke.viewKitaps.Where
                    (k => k.turAciklama == turAciklama).ToList();
            }
            else if (!string.IsNullOrEmpty(Request.QueryString["kitapAdi"]))
            {
                kitapAdi = Request.QueryString["kitapAdi"];
                kitaplar = ke.viewKitaps.Where
                    (k => k.kitapAdi == kitapAdi).ToList();
            }
            else
                kitaplar = ke.viewKitaps.ToList();
            repKitaplar.DataSource = kitaplar;
            repKitaplar.DataBind();
        }
        private void KitapListeleEntitySorgulu()
        {
            KutuphaneEntities ke = new KutuphaneEntities();
            List<viewKitap> kitaplar;
            string kitapAdi, turAciklama;
            if (!string.IsNullOrEmpty(Request.QueryString["turAciklama"]))
            {
                turAciklama = Request.QueryString["turAciklama"];
                kitaplar = (from kitap in ke.viewKitaps where kitap.turAciklama == turAciklama select kitap).ToList();
            }
            else if (!string.IsNullOrEmpty(Request.QueryString["kitapAdi"]))
            {
                kitapAdi = Request.QueryString["kitapAdi"];
                kitaplar = (from kitap in ke.viewKitaps where kitap.kitapAdi.Contains(kitapAdi) select kitap).ToList();
            }
            else
            {
                kitaplar = (from kitap in ke.viewKitaps select kitap).ToList();
            }
            repKitaplar.DataSource = kitaplar;
            repKitaplar.DataBind();
        }
        public void KitaplarListele()
        {
            SqlConnection con = new SqlConnection
            (ConfigurationManager.ConnectionStrings[0].ConnectionString);
            string cmdstring;
            SqlCommand cmd;
            if (!string.IsNullOrEmpty(Request.QueryString["turAciklama"])){
                cmdstring = "select * from viewKitap "+
                    "where turAciklama=@turAciklama";
                cmd = new SqlCommand(cmdstring, con);
                cmd.Parameters.AddWithValue("turAciklama", 
                    (Request.QueryString["turAciklama"]));
            }
            else if (!string.IsNullOrEmpty(Request.QueryString["kitapAdi"])){
                cmdstring = "select * from viewKitap "+
                    "where kitapAdi like '%" + 
                    (Request.QueryString["kitapAdi"]) + "%'";
                cmd = new SqlCommand(cmdstring, con);
            }
            else{
                cmdstring = "select * from viewKitap";
                cmd = new SqlCommand(cmdstring, con);
            }
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            repKitaplar.DataSource = dr;
            repKitaplar.DataBind();
            con.Close();
        }
    }
}