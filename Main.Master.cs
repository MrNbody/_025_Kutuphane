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
    public partial class Main : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DuyuruGetirEntitySorgulu();
            PanelKontrol();
        }
        public void PanelKontrol()
        {
            object kullanici = Session["kullaniciAdi"];
            if (kullanici != null)
            {
                pnlGiris.Visible = false;
                pnlKullanici.Visible = true;
                lblKullaniciAdi.Text = kullanici.ToString();
            }
            else
            {
                pnlKullanici.Visible = false;
                pnlGiris.Visible = true;
            }
        }
        private void DuyuruGetirEntitySorgulu()
        {
            KutuphaneEntities ke = new KutuphaneEntities();
            var sorgu = (from duyuru in ke.Duyurus orderby duyuru.duyuruID descending select duyuru).ToList();
            listDuyuru.DataSource = sorgu;
            listDuyuru.DataBind();
        }
        private void DuyuruGetirEntity()
        {
            KutuphaneEntities ke = new KutuphaneEntities();
            var duyuru = ke.Duyurus.ToList();
            listDuyuru.DataSource = duyuru;
            listDuyuru.DataBind();
        }
        private void DuyuruGetir()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings[0].ConnectionString);

            string cmdstring = "select * from Duyuru order by duyuruID desc";
            SqlCommand cmd = new SqlCommand(cmdstring, con);
            con.Open();

            SqlDataReader dr = cmd.ExecuteReader();
            listDuyuru.DataSource = dr;
            listDuyuru.DataBind();
            con.Close();
        }
        protected void btngiris_Click(object sender, EventArgs e)
        {
            GirisEntitySorgulu();
        }
        private void GirisEntitySorgulu()
        {
            KutuphaneEntities ke = new KutuphaneEntities();
            var sorgu = (from uye in ke.Uyes where uye.kullaniciAdi == txtKullaniciAdi.Text && uye.sifre == txtSifre.Text select uye).FirstOrDefault();
            if (sorgu != null)
            {
                Session.Timeout = 300;
                Session.Add("kullaniciAdi", sorgu.kullaniciAdi);
                Session.Add("uyeID", sorgu.uyeID);
                Response.Redirect(Request.RawUrl);
            }
            else
                lblSonuc.Text = "Kullanıcı girişi sağlanamadı";
        }
        private void GirisEntity()
        {
            KutuphaneEntities ke = new KutuphaneEntities();
            var uye = ke.Uyes.Where(u => u.kullaniciAdi == txtKullaniciAdi.Text && u.sifre == txtSifre.Text).FirstOrDefault();
            if (uye!=null)
            {
                Session.Timeout = 300;
                Session.Add("kullaniciAdi", uye.kullaniciAdi);
                Session.Add("uyeID", uye.uyeID);
                Response.Redirect(Request.RawUrl);
            }
            else
                lblSonuc.Text = "Kullanıcı girişi sağlanamadı";
        }
        private void Giris()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings[0].ConnectionString);

            string sorgu = "Select * from Uye where kullaniciAdi=@kullaniciAdi and sifre=@sifre";
            SqlCommand cmd = new SqlCommand(sorgu, con);
            cmd.Parameters.AddWithValue("@kullaniciAdi", txtKullaniciAdi.Text);
            cmd.Parameters.AddWithValue("@sifre", txtSifre.Text);

            con.Open();

            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                Session.Timeout = 300;
                Session.Add("kullaniciAdi", dr["kullaniciAdi"].ToString());
                Session.Add("uyeID", dr["uyeID"].ToString());
                Response.Redirect(Request.RawUrl);
            }
            else
                lblSonuc.Text = "Kullanıcı girişi sağlanamadı";
            con.Close();
        }

        protected void cikis_Click(object sender, EventArgs e)
        {
            Session.Abandon();// sesion veriler silindi
            Response.Redirect(Request.RawUrl);// sayfayı yenileme
        }

        protected void btnArama_Click(object sender, EventArgs e)
        {
            /*SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings[0].ConnectionString);

            string sorgu = "Select ID From Kitaplar where KitapAdi=@kitapAdi";
            SqlCommand komut = new SqlCommand(sorgu, con);
            komut.Parameters.AddWithValue("kitapAdi", txtArama.Text);
            con.Open();

            SqlDataReader rd = komut.ExecuteReader();
            if (rd.Read())
            {*/
            //Session.Add("kitapID", rd["ID"].ToString());
            Response.Redirect(("Kitaplar.aspx?kitapAdi=" + txtArama.Text));// post işlemi
           // }
        }
    }
}