using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace _025_Kutuphane
{
    public partial class Kitap : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                KitapListele();
                //KitapListeleEntity();
            }
        }
        private void KitapListeleEntity()
        {
            int kitapID = Convert.ToInt32(Request.QueryString["kitapID"]);
            KutuphaneEntities ke = new KutuphaneEntities();
            viewKitap sorgu = ke.viewKitaps.Where
                (k => k.kitapID == kitapID).FirstOrDefault();
            lblisbn.Text = sorgu.ISBN;
            lblKitapAdi.Text = sorgu.kitapAdi;
            lblkitapYazar.Text = sorgu.yazarAdi;
            lblOzetSag.Text = sorgu.ozet;
            lblsayfa.Text = sorgu.sayfaSayisi.ToString();
            imgKitap.ImageUrl = sorgu.kitapResim;
            ke.SaveChanges();
        }
        public void KitapListele()
        {
            if (!string.IsNullOrEmpty(Request.QueryString["kitapID"]))
            {
                SqlConnection con = new SqlConnection
                (ConfigurationManager.ConnectionStrings[0].ConnectionString);
                string cmdstring = "SELECT * FROM viewKitap" +
                    "where kitapID=@kitapID";
                SqlCommand cmd = new SqlCommand(cmdstring, con);
                cmd.Parameters.AddWithValue("@kitapID",
                    Request.QueryString["kitapID"].ToString());
                if (con.State == ConnectionState.Closed)
                    con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    imgKitap.ImageUrl = dr["kitapResim"].ToString();
                    lblKitapAdi.Text = dr["kitapAdi"].ToString();
                    //lblKitapSayfa.Text = dr["SayfaSayisi"].ToString();
                    lblkitapYazar.Text = dr["yazarAdi"].ToString();
                    lblOzetSag.Text = dr["ozet"].ToString();
                    lblisbn.Text = "ISBN numarası: " + dr["ISBN"].ToString();
                    lblsayfa.Text = "Sayfa Sayısı: " + dr["sayfaSayisi"].ToString();
                }
                con.Close();
            }
        }
        protected void btnAl_Click(object sender, EventArgs e)
        {
            object kullanici = Session["uyeID"];
            if (kullanici != null)
            {
                //KitapAl();
                KitapAlEntity();
            }
            else
                lblMesaj.Text = "Önce giriş yapmalısınız";
        }
        private void KitapAlEntity()
        {
            KutuphaneEntities ke = new KutuphaneEntities();
            Odunc odunc = new Odunc();
            odunc.kitapID = Convert.ToInt32(Request.QueryString["kitapID"]);
            odunc.uyeID = Convert.ToInt32(Session["uyeID"]);
            DateTime dt = DateTime.Today.Date;
            odunc.vermeTarihi = Convert.ToDateTime(dt.ToShortDateString());
            odunc.vermeSuresi = Convert.ToInt32(listSure.Text);
            ke.Oduncs.Add(odunc);
            ke.SaveChanges();
            triggerStokEntity();
            lblMesaj.Text = "Kitabı aldınız";
        }
        private void triggerStokEntity()
        {
            KutuphaneEntities ke = new KutuphaneEntities();
            int id = Convert.ToInt32(Request.QueryString["kitapID"]);
            var Kitap = ke.Kitaps.SingleOrDefault(k => k.kitapID == id);
            Kitap.kitapSayisi = Kitap.kitapSayisi - 1;
            ke.SaveChanges();
        }
        public void KitapAl()
        {
            if (!string.IsNullOrEmpty(Request.QueryString["kitapID"]))
            {
                SqlConnection con = new SqlConnection
                (ConfigurationManager.ConnectionStrings[0].ConnectionString);
                string cmdstring = "INSERT INTO Odunc " +
                    "(kitapID, uyeID, vermeTarihi, vermeSuresi)" +
                    "VALUES (@kitapID, @uyeID, @VermeTarihi, @VermeSuresi);" +
                    "SELECT SCOPE_IDENTITY()";
                SqlCommand cmd = new SqlCommand(cmdstring, con);
                DateTime dt = DateTime.Today.Date;
                cmd.Parameters.AddWithValue("@uyeID", Session["uyeID"]);
                cmd.Parameters.AddWithValue("@KitapID", Request.QueryString["kitapID"]);
                cmd.Parameters.AddWithValue("@VermeTarihi", dt.ToShortDateString());
                cmd.Parameters.AddWithValue("@VermeSuresi", listSure.Text);
                if (con.State == ConnectionState.Closed)
                    con.Open();
                string oduncID = cmd.ExecuteScalar().ToString();
                lblMesaj.Text = "Kitabı aldınız";
                triggerStok(con);
                con.Close();
            }
        }
        public void triggerStok(SqlConnection con)
        {
            string sorgu = "UPDATE Kitap SET kitapSayisi=kitapSayisi-1" +
                "WHERE kitapID=@kitapID";
            SqlCommand cmd = new SqlCommand(sorgu, con);
            cmd.Parameters.AddWithValue("kitapID",
                Request.QueryString["kitapID"].ToString());
            if (con.State == ConnectionState.Closed)
                con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}