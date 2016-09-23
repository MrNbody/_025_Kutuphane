using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _025_Kutuphane.admin
{
    public partial class Kitap : System.Web.UI.Page
    {
        string yazar, tur;
        protected void Page_Load(object sender, EventArgs e)
        {
            object admin = Session["admin"];
            if (admin == null)
            {
                Response.Redirect("Admin.aspx");
            }
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.QueryString["kitapID"]))
                {
                    pnlGunceller.Visible = true;
                    pnlEkle.Visible = false;
                    //TurDoldurEntity();
                    //YazarDoldurEntity();
                    //KitapDoldurEntity();
                    TurDoldur();
                    YazarDoldur();
                    KitapDoldur();
                }
                else
                {
                    pnlGunceller.Visible = false;
                    pnlEkle.Visible = true;
                    //TurDoldurEntity();
                    //YazarDoldurEntity();
                    TurDoldur();
                    YazarDoldur();
                }
            }
        }
        private void KitapDoldurEntity()
        {
            int kitapID = Convert.ToInt32(Request.QueryString["kitapID"]);
            KutuphaneEntities ke = new KutuphaneEntities();
            var sorgu = (from kitap in ke.viewKitaps
                         where kitap.kitapID == kitapID
                         select kitap).FirstOrDefault();
            txtISBN.Text = sorgu.ISBN;
            txtKitapAdi.Text = sorgu.kitapAdi;
            txtKitapSayisi.Text = sorgu.kitapSayisi.ToString();
            txtSayfa.Text = sorgu.sayfaSayisi.ToString();
            txtOzet.Text = sorgu.ozet;
            listboxTur.SelectedValue = sorgu.turAciklama;
            txtResim.Text = sorgu.kitapResim;
            listboxYazar.SelectedValue = sorgu.yazarAdi;
        }
        public void KitapDoldur()
        {
            SqlConnection con = new SqlConnection
                (ConfigurationManager.ConnectionStrings[0].ConnectionString);
            string sorgu = "SELECT * FROM viewKitap " +
                "WHERE kitapID=@kitapID";
            SqlCommand cmd = new SqlCommand(sorgu, con);
            cmd.Parameters.AddWithValue("kitapID",
                Request.QueryString["kitapID"].ToString());
            if (con.State == ConnectionState.Closed)
                con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            txtISBN.Text = dr["ISBN"].ToString();
            txtKitapAdi.Text = dr["kitapAdi"].ToString();
            txtKitapSayisi.Text = dr["kitapSayisi"].ToString();
            txtSayfa.Text = dr["sayfaSayisi"].ToString();
            txtOzet.Text = dr["ozet"].ToString();
            listboxTur.SelectedValue = dr["turAciklama"].ToString();
            txtResim.Text = dr["kitapResim"].ToString();
            listboxYazar.SelectedValue = dr["yazarAdi"].ToString();
            dr.Close();
        }
        private void KitapGuncelleEntity()
        {
            int kitapID = Convert.ToInt32(Request.QueryString["kitapID"]);
            KutuphaneEntities ke = new KutuphaneEntities();
            var sorgu = (from kitap in ke.Kitaps
                         where kitap.kitapID == kitapID
                         select kitap).FirstOrDefault();
            sorgu.kitapAdi = txtKitapAdi.Text.ToString();
            sorgu.ISBN = txtISBN.Text.ToString();
            sorgu.kitapSayisi = Convert.ToInt32(txtKitapSayisi.Text);
            sorgu.sayfaSayisi = txtSayfa.Text;
            sorgu.ozet = txtOzet.Text.ToString();
            sorgu.kitapResim = txtResim.Text.ToString();
            ke.SaveChanges();
            lblSonuc.Text = "Güncellendi";
        }
        public void KitapGuncelle(SqlConnection con)
        {
            string sorgu = "UPDATE Kitap SET kitapAdi=@kitapAdi," +
                "ISBN=@isbn, sayfaSayisi=@sayfa," +
                "ozet=@ozet, kitapResim=@kitapResim " +
                "WHERE kitapID=@kitapID kitapSayisi=@kitapSayisi";
            SqlCommand cmd = new SqlCommand(sorgu, con);
            cmd.Parameters.AddWithValue("kitapAdi", txtKitapAdi.Text.ToString());
            cmd.Parameters.AddWithValue("isbn", txtISBN.Text.ToString());
            cmd.Parameters.AddWithValue("kitapSayisi", txtKitapSayisi.Text);
            cmd.Parameters.AddWithValue("sayfa", txtSayfa.Text.ToString());
            cmd.Parameters.AddWithValue("ozet", txtOzet.Text.ToString());
            cmd.Parameters.AddWithValue("kitapResim", txtResim.Text.ToString());
            cmd.Parameters.AddWithValue("kitapID",
                Request.QueryString["kitapID"].ToString());
            cmd.ExecuteNonQuery();
        }
        private void YazarGuncelleEntity()
        {
            int kitapID = Convert.ToInt32
                (Request.QueryString["kitapID"].ToString());
            KutuphaneEntities ke = new KutuphaneEntities();
            KitapYazar ky = new _025_Kutuphane.KitapYazar();
            ky.yazarID = YazarIDGetirEntity();
            ky.kitapID = kitapID;
            ke.SaveChanges();
        }
        public void YazarGuncelle(SqlConnection con)
        {
            string sorgu = "UPDATE KitapYazar SET " +
                "yazarID=@yazarID WHERE kitapID=@kitapID";
            SqlCommand cmd = new SqlCommand(sorgu, con);
            cmd.Parameters.AddWithValue("yazarID", YazarIDGetir(con));
            cmd.Parameters.AddWithValue("kitapID",
                Request.QueryString["kitapID"].ToString());
            cmd.ExecuteNonQuery();
        }
        private int YazarIDGetirEntity()
        {
            KutuphaneEntities ke = new KutuphaneEntities();
            string yazarAdi = listboxYazar.Items
                [listboxYazar.SelectedIndex].ToString();
            var sorgu = ke.Yazars.Where
            (y => y.yazarAdi == yazarAdi).FirstOrDefault();
            return sorgu.yazarID;
        }
        public string YazarIDGetir(SqlConnection con)
        {
            string sorgu = "SELECT yazarID FROM Yazar" +
            "WHERE yazarAdi=@yazarAdi";
            SqlCommand cmd = new SqlCommand(sorgu, con);
            cmd.Parameters.AddWithValue("yazarAdi",
            listboxYazar.Items[listboxYazar.SelectedIndex].ToString());
            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            string yazarID = dr["yazarID"].ToString();
            dr.Close();
            return yazarID;
        }
        private void TurGuncelleEntity()
        {
            int kitapID = Convert.ToInt32
                (Request.QueryString["kitapID"].ToString());
            KutuphaneEntities ke = new KutuphaneEntities();
            KitapTur kt = new KitapTur();
            kt.turID = TurIDGetirEntity();
            kt.kitapID = kitapID;
            ke.SaveChanges();
        }
        public void TurGuncelle(SqlConnection con)
        {
            string sorgu = "UPDATE KitapTur SET turID=@turID" +
                "WHERE kitapID=@kitapID";
            SqlCommand cmd = new SqlCommand(sorgu, con);
            cmd.Parameters.AddWithValue("turID", TurIDGetir(con));
            cmd.Parameters.AddWithValue("kitapID",
                Request.QueryString["kitapID"].ToString());
            cmd.ExecuteNonQuery();
        }
        private int TurIDGetirEntity()
        {
            string turAciklama = listboxTur.Items
                [listboxTur.SelectedIndex].ToString();
            KutuphaneEntities ke = new KutuphaneEntities();
            var sorgu = ke.Turs.Where
            (t => t.turAciklama == turAciklama).FirstOrDefault();
            return sorgu.turID;
        }
        public string TurIDGetir(SqlConnection con)
        {
            string sorgu = "SELECT turID FROM Tur" +
            "WHERE turAciklama=@turAciklama";
            SqlCommand cmd = new SqlCommand(sorgu, con);
            cmd.Parameters.AddWithValue("turAciklama",
            listboxTur.Items[listboxTur.SelectedIndex].ToString());
            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            string turID = dr["turID"].ToString();
            dr.Close();
            return turID;
        }
        private void TurDoldurEntity()
        {
            KutuphaneEntities ke = new KutuphaneEntities();
            var sorgu = (from tur in ke.Turs
                         select tur.turAciklama).ToList();
            listboxTur.DataSource = sorgu;
            listboxTur.DataBind();
        }
        public void TurDoldur()
        {
            SqlConnection con = new SqlConnection
            (ConfigurationManager.ConnectionStrings[0].ConnectionString);
            string sorgu = "SELECT turAciklama FROM Tur";
            SqlCommand cmd = new SqlCommand(sorgu, con);
            con.Open();
            SqlDataReader rd = cmd.ExecuteReader();
            listboxTur.DataSource = rd;
            listboxTur.DataTextField = "turAciklama";
            if (!IsPostBack)
                listboxTur.DataBind();
        }
        private void YazarDoldurEntity()
        {
            KutuphaneEntities ke = new KutuphaneEntities();
            var sorgu = (from yazar in ke.Yazars
                         select yazar.yazarAdi).ToList();
            listboxYazar.DataSource = sorgu;
            listboxYazar.DataBind();
        }
        public void YazarDoldur()
        {
            SqlConnection con = new SqlConnection
            (ConfigurationManager.ConnectionStrings[0].ConnectionString);
            string sorgu = "SELECT yazarAdi FROM Yazar";
            SqlCommand cmd = new SqlCommand(sorgu, con);
            con.Open();
            SqlDataReader rd = cmd.ExecuteReader();
            listboxYazar.DataSource = rd;
            listboxYazar.DataTextField = "yazarAdi";
            if (!IsPostBack)
                listboxYazar.DataBind();
        }
        private int VTKontrolEntity()
        {
            string isbn = txtISBN.Text.ToString();
            KutuphaneEntities ke = new KutuphaneEntities();
            var sorgu = ke.Kitaps.Where
            (k => k.ISBN == isbn).Count();
            return sorgu;
        }
        public int VTKontrol()
        {
            SqlConnection con = new SqlConnection
            (ConfigurationManager.ConnectionStrings[0].ConnectionString);
            con.Open();
            string sorgu = "SELECT COUNT(ISBN) FROM Kitap WHERE ISBN=@isbn";
            SqlCommand cmd = new SqlCommand(sorgu, con);
            cmd.Parameters.AddWithValue("isbn", txtISBN.Text.ToString());
            return Convert.ToInt32(cmd.ExecuteScalar());
        }

        protected void btnekle_Click(object sender, EventArgs e)
        {
            //KitapEkle();
            KitapEkleEntity();
        }
        private void KitapEkleEntity()
        {
            if (VTKontrolEntity() != 0)
                lblSonuc.Text = "KAYIT ZATEN VAR";
            else
            {
                KutuphaneEntities ke = new KutuphaneEntities();
                _025_Kutuphane.Kitap kitap = new _025_Kutuphane.Kitap();
                kitap.kitapAdi = txtKitapAdi.Text.ToString();
                kitap.ISBN = txtISBN.Text.ToString();
                kitap.kitapSayisi = Convert.ToInt32(txtKitapSayisi.Text);
                kitap.sayfaSayisi = txtSayfa.Text;
                kitap.ozet = txtOzet.Text.ToString();
                kitap.kitapResim = txtResim.Text.ToString();
                ke.Kitaps.Add(kitap);
                ke.SaveChanges();
                triggerYazarEntity(kitap.kitapID);
            }
        }
        private void KitapEkle()
        {
            if (VTKontrol() != 0)
                lblSonuc.Text = "KAYIT ZATEN VAR";
            else
            {
                SqlConnection con = new SqlConnection
                (ConfigurationManager.ConnectionStrings[0].ConnectionString);
                string sorgu = "INSERT INTO Kitap (kitapAdi, ISBN, sayfaSayisi," +
                    "ozet, kitapResim, kitapSayisi) VALUES " +
                    "(@kitapadi, @isbn, @sayfa, @ozet, @resim, @kitapSayisi);" +
                    "SELECT SCOPE_IDENTITY()";
                SqlCommand cmd = new SqlCommand(sorgu, con);
                cmd.Parameters.AddWithValue("kitapadi", txtKitapAdi.Text.ToString());
                cmd.Parameters.AddWithValue("isbn", txtISBN.Text.ToString());
                cmd.Parameters.AddWithValue("kitapSayisi", txtKitapSayisi.Text);
                cmd.Parameters.AddWithValue("sayfa", txtSayfa.Text.ToString());
                cmd.Parameters.AddWithValue("ozet", txtOzet.Text.ToString());
                cmd.Parameters.AddWithValue("resim", txtResim.Text.ToString());
                if (con.State == ConnectionState.Closed)
                    con.Open();
                string kitapID = cmd.ExecuteScalar().ToString();
                //cmd.ExecuteNonQuery();
                lblSonuc.Text = "Eklendi";
                triggerYazar(con, kitapID);
                con.Close();
            }
        }
        private void triggerYazarEntity(int kitapID)
        {
            KitapYazarEntity(kitapID);
            KitapTurEntity(kitapID);
        }
        public void triggerYazar(SqlConnection con, string kitapID)
        {
            KitapYazar(con, kitapID);
            KitapTur(con, kitapID);
        }
        private void KitapYazarEntity(int kitapID)
        {
            KutuphaneEntities ke = new KutuphaneEntities();
            KitapYazar ky = new _025_Kutuphane.KitapYazar();
            ky.kitapID = kitapID;
            ky.yazarID = YazarIDEntity();
            ke.KitapYazars.Add(ky);
            ke.SaveChanges();
        }
        public void KitapYazar(SqlConnection con, string kitapID)
        {
            string sorgu = "INSERT INTO KitapYazar " +
            "(kitapID, yazarID) VALUES (@kitapID, @yazarID)";
            SqlCommand cmd = new SqlCommand(sorgu, con);
            cmd.Parameters.AddWithValue("kitapID", kitapID);
            cmd.Parameters.AddWithValue("yazarID", YazarID(con));
            cmd.ExecuteNonQuery();
        }
        private void KitapTurEntity(int kitapID)
        {
            KutuphaneEntities ke = new KutuphaneEntities();
            KitapTur kt = new _025_Kutuphane.KitapTur();
            kt.kitapID = kitapID;
            kt.turID = TurIDEntity();
            ke.KitapTurs.Add(kt);
            ke.SaveChanges();
        }
        public void KitapTur(SqlConnection con, string kitapID)
        {
            string sorgu = "INSERT INTO KitapTur " +
            "(kitapID, turID) VALUES (@kitapID, @turID)";
            SqlCommand cmd = new SqlCommand(sorgu, con);
            cmd.Parameters.AddWithValue("kitapID", kitapID);
            cmd.Parameters.AddWithValue("turID", TurID(con));
            cmd.ExecuteNonQuery();
        }
        private int YazarIDEntity()
        {
            KutuphaneEntities ke = new KutuphaneEntities();
            var sorgu = ke.Yazars.
            Where(y => y.yazarAdi == yazar).FirstOrDefault();
            return sorgu.yazarID;
        }
        public string YazarID(SqlConnection con)
        {
            string sorgu = "Select yazarID from Yazar" +
            "where yazarAdi=@yazarAdi";
            SqlCommand cmd = new SqlCommand(sorgu, con);
            cmd.Parameters.AddWithValue("yazarAdi",
                yazar.ToString());
            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            string yazarID = dr["yazarID"].ToString();
            dr.Close();
            return yazarID;
        }
        private int TurIDEntity()
        {
            KutuphaneEntities ke = new KutuphaneEntities();
            var sorgu = ke.Turs.
            Where(t => t.turAciklama == tur).FirstOrDefault();
            return sorgu.turID;
        }
        public string TurID(SqlConnection con)
        {
            string sorgu = "Select turID from Tur" +
            "where turAciklama=@turAciklama";
            SqlCommand cmd = new SqlCommand(sorgu, con);
            cmd.Parameters.AddWithValue("turAciklama",
                tur.ToString());
            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            string turID = dr["turID"].ToString();
            dr.Close();
            return turID;
        }

        protected void listboxTur_SelectedIndexChanged(object sender, EventArgs e)
        {
            yazar = listboxTur.SelectedIndex.ToString();
            yazar = listboxYazar.Items[listboxYazar.SelectedIndex].ToString();
        }

        protected void listboxYazar_SelectedIndexChanged(object sender, EventArgs e)
        {
            tur = listboxTur.SelectedIndex.ToString();
            tur = listboxTur.Items[listboxTur.SelectedIndex].ToString();
        }

        protected void btnGuncelle_Click(object sender, EventArgs e)
        {
            GuncelleEntity();
            //Guncelle();
        }
        private void GuncelleEntity()
        {
            KitapGuncelleEntity();
            YazarGuncelleEntity();
            TurGuncelleEntity();
            lblSonuc.Text = "Guncellendi";
        }
        private void Guncelle()
        {
            SqlConnection con = new SqlConnection
            (ConfigurationManager.ConnectionStrings[0].ConnectionString);
            con.Open();
            KitapGuncelle(con);
            YazarGuncelle(con);
            TurGuncelle(con);
            lblSonuc.Text = "Guncellendi";
            con.Close();
        }
    }
}