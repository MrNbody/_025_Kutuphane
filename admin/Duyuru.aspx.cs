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
    public partial class Duyuru : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            object admin = Session["admin"];
            if (admin == null)
            {
                Response.Redirect("Admin.aspx");
            }
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.QueryString["duyuruID"]))
                {
                    pnlEkle.Visible = false;
                    pnlGuncelle.Visible = true;
                    DuyuruDoldurEntity();
                }
                else
                {
                    pnlGuncelle.Visible = false;
                    pnlEkle.Visible = true;
                }
                DuyuruGetirEntity();
            }
        }

        protected void btnekle_Click(object sender, EventArgs e)
        {
            // DuyuruEkle();
            DuyuruEkleEntity();
        }
        public void DuyuruEkleEntity()
        {
            KutuphaneEntities ke = new KutuphaneEntities();
            _025_Kutuphane.Duyuru duyuru = new _025_Kutuphane.Duyuru();
            duyuru.duyuruAciklama = txtDuyuru.Text;
            ke.Duyurus.Add(duyuru);
            ke.SaveChanges();
        }
        private void DuyuruEkle()
        {
            SqlConnection con = new SqlConnection
            (ConfigurationManager.ConnectionStrings[0].ConnectionString);
            string sorgu = "INSERT Duyuru (duyuruAciklama)" +
                "VALUES (@duyuruAciklama)";
            SqlCommand cmd = new SqlCommand(sorgu, con);
            cmd.Parameters.AddWithValue("duyuruAciklama",
                txtDuyuru.Text.ToString());
            if (con.State == System.Data.ConnectionState.Closed)
                con.Open();
            cmd.ExecuteNonQuery();
            lblSonuc.Text = "Eklendi";
            con.Close();
        }
        private void DuyuruDoldurEntity()
        {
            int duyuruID = Convert.ToInt32(Request.QueryString["duyuruID"]);
            KutuphaneEntities ke = new KutuphaneEntities();
            var sorgu = ke.Duyurus.Where
                (k => k.duyuruID == duyuruID).ToList();
            foreach (var item in sorgu)
            {
                txtDuyuru.Text = item.duyuruAciklama;
            }
        }
        public void DuyuruDoldur()
        {
            SqlConnection con = new SqlConnection
            (ConfigurationManager.ConnectionStrings[0].ConnectionString);
            string sorgu = "SELECT * FROM Duyuru " +
                "WHERE duyuruID=@duyuruID";
            SqlCommand cmd = new SqlCommand(sorgu, con);
            cmd.Parameters.AddWithValue("duyuruID",
                Request.QueryString["duyuruID"].ToString());
            if (con.State == System.Data.ConnectionState.Closed)
                con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            txtDuyuru.Text = dr["duyuruAciklama"].ToString();
            dr.Close();
            con.Close();
        }
        private void DuyuruGetirEntity()
        {
            KutuphaneEntities ke = new KutuphaneEntities();
            var sorgu = (from duyuru in ke.Duyurus
                         orderby duyuru.duyuruID
                         descending
                         select duyuru).ToList();
            listDuyuru.DataSource = sorgu;
            listDuyuru.DataBind();
        }
        private void DuyuruGetir()
        {
            SqlConnection con = new SqlConnection
            (ConfigurationManager.ConnectionStrings[0].ConnectionString);
            string cmdstring = "select * from Duyuru" +
                "order by duyuruID desc";
            SqlCommand cmd = new SqlCommand(cmdstring, con);
            if (con.State == System.Data.ConnectionState.Closed)
                con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            listDuyuru.DataSource = dr;
            listDuyuru.DataBind();
            con.Close();
        }

        protected void btnGuncelle_Click(object sender, EventArgs e)
        {
            DuyuruGuncelleEntity();
        }
        private void DuyuruGuncelleEntity()
        {
            KutuphaneEntities ke = new KutuphaneEntities();
            int duyuruID = Convert.ToInt32
                (Request.QueryString["duyuruID"]);
            var sorgu = (from duyuru in ke.Duyurus
                         where duyuru.duyuruID == duyuruID
                         select duyuru).FirstOrDefault();
            sorgu.duyuruAciklama = txtDuyuru.Text.ToString();
            ke.SaveChanges();
        }
        private void DuyuruGuncelle()
        {
            SqlConnection con = new SqlConnection
            (ConfigurationManager.ConnectionStrings[0].ConnectionString);
            string sorgu = "UPDATE Duyuru SET duyuruAciklama=@duyuruAciklama"+
                "WHERE duyuruID=@duyuruID";
            SqlCommand cmd = new SqlCommand(sorgu, con);
            cmd.Parameters.AddWithValue("duyuruAciklama",
                txtDuyuru.Text.ToString());
            cmd.Parameters.AddWithValue("duyuruID",
                Request.QueryString["duyuruID"].ToString());
            if (con.State == System.Data.ConnectionState.Closed)
                con.Open();
            cmd.ExecuteNonQuery();
            lblSonuc.Text = "GUNCELLENDİ";
            con.Close();
        }
    }
}