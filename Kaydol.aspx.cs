using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _025_Kutuphane
{
    public partial class Kaydol : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            pnlDurum.Visible = false;
        }

        protected void btnkayit_Click(object sender, EventArgs e)
        {
            //Kayit();
            KayitEntity();
        }
        private void KayitEntity()
        {
            if (txtKullaniciAdi.Text != "" &&
                txtSifre.Text != "" &&
                txtEmail.Text != "" &&
                txtAd.Text != "" &&
                txtSoyad.Text != "" &&
                txtAdres.Text != "")
            {
                if (KullaniciAdiKontrolEntity())
                {
                    if (EmailKontrolEntity())
                    {
                        KutuphaneEntities ke = new KutuphaneEntities();
                        Uye uye = new Uye();
                        uye.kullaniciAdi = txtKullaniciAdi.Text;
                        uye.email = txtEmail.Text;
                        uye.sifre = txtSifre.Text;
                        uye.uyeAdi = txtAd.Text;
                        uye.uyeSoyadi = txtSoyad.Text;
                        uye.uyeAdresi = txtAdres.Text;
                        ke.Uyes.Add(uye);
                        ke.SaveChanges();

                        pnlKayit.Visible = false;
                        pnlDurum.Visible = true;
                        Session.Add("kullaniciadi", txtKullaniciAdi.Text);
                        lblDurum.Text = "Başarı ile Kayıt Yapılmıştır";
                        Session.Add("uyeID", uye.uyeID);
                    }
                }
            }
        }
        private void Kayit()
        {
            if (txtKullaniciAdi.Text != "" &&
                txtSifre.Text != "" &&
                txtEmail.Text != "" &&
                txtAd.Text != "" &&
                txtSoyad.Text != "" &&
                txtAdres.Text != "")
            {
                SqlConnection con = new SqlConnection(
                ConfigurationManager.ConnectionStrings[0].ConnectionString);
                if (KullaniciAdiKontrol(con))
                {
                    if (EmailKontrol(con))
                    {
                        string cmdstring = "insert into Uye (kullaniciAdi," +
                            "sifre, email, uyeAdi, uyeSoyadi, uyeAdresi)" +
                            "values (@kullaniciadi, @sifre, @email, @adi," +
                            "@soyadi, @adres); SELECT SCOPE_IDENTITY()";
                        SqlCommand cmd = new SqlCommand(cmdstring, con);
                        if (con.State == ConnectionState.Closed)
                            con.Open();
                        cmd.Parameters.AddWithValue("@kullaniciadi", txtKullaniciAdi.Text);
                        cmd.Parameters.AddWithValue("@sifre", txtSifre.Text);
                        cmd.Parameters.AddWithValue("@email", txtEmail.Text);
                        cmd.Parameters.AddWithValue("@adi", txtAd.Text);
                        cmd.Parameters.AddWithValue("@soyadi", txtSoyad.Text);
                        cmd.Parameters.AddWithValue("@adres", txtAdres.Text);
                        string kitapID = cmd.ExecuteScalar().ToString();
                        con.Close();
                        pnlKayit.Visible = false;
                        pnlDurum.Visible = true;
                        Session.Add("kullaniciadi", txtKullaniciAdi.Text);
                        lblDurum.Text = "Başarı ile Kayıt Yapılmıştır";
                        Session.Add("uyeID", kitapID);
                    }
                }
            }
        }
        private bool KullaniciAdiKontrolEntity()
        {
            KutuphaneEntities ke = new KutuphaneEntities();
            var sorgu = (from uye in ke.Uyes
                         where uye.kullaniciAdi ==
                         txtKullaniciAdi.Text.ToString()
                         select uye).Count();
            if (sorgu != 0)
            {
                lblSonuc.Text = "Böyle bir kullanıcı adı ile zaten kayıt var";
                return false;
            }
            else
                return true;
        }
        private bool EmailKontrolEntity()
        {
            KutuphaneEntities ke = new KutuphaneEntities();
            var sorgu = (from uye in ke.Uyes
                         where uye.email ==
                         txtEmail.Text.ToString()
                         select uye).Count();
            if (sorgu != 0)
            {
                lblSonuc.Text = "Böyle bir email kaydı ile zaten kayıt var";
                return false;
            }
            else
                return true;
        }
        public bool KullaniciAdiKontrol(SqlConnection con)
        {
            string sorgu = "SELECT COUNT(kullaniciAdi)" +
            "FROM Uye WHERE kullaniciAdi=@kullaniciAdi";
            SqlCommand cmd = new SqlCommand(sorgu, con);
            cmd.Parameters.AddWithValue("kullaniciAdi",
                txtKullaniciAdi.Text.ToString());
            if (con.State == ConnectionState.Closed)
                con.Open();
            if (Convert.ToInt32(cmd.ExecuteScalar()) != 0)
            {
                lblSonuc.Text = "Böyle bir kullanıcı adı ile zaten kayıt var";
                return false;
            }
            else
                return true;
        }
        public bool EmailKontrol(SqlConnection con)
        {
            string sorgu = "SELECT COUNT(email)" +
            "FROM Uye WHERE email=@email";
            SqlCommand cmd = new SqlCommand(sorgu, con);
            cmd.Parameters.AddWithValue("email",
                txtEmail.Text.ToString());
            if (con.State == ConnectionState.Closed)
                con.Open();
            if (Convert.ToInt32(cmd.ExecuteScalar()) != 0)
            {
                lblSonuc.Text = "Böyle bir email kaydı ile zaten kayıt var";
                return false;
            }
            else
                return true;
        }
    }
}