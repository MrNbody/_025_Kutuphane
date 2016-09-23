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
    public partial class Kitaplar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //KitaplarListeleEntity();
            KitaplarListele();
        }
        private void KitaplarListeleEntity()
        {
            KutuphaneEntities ke = new _025_Kutuphane.KutuphaneEntities();
            List<viewKitap> kitaplar;
            string kitapAdi = Request.QueryString["kitapAdi"];
            if (!string.IsNullOrEmpty(Request.QueryString["kitapAdi"]))
            {
                kitaplar = (from kitap in ke.viewKitaps where kitap.kitapAdi.Contains(kitapAdi) select kitap).ToList();
                repKitaplar.DataSource = kitaplar;
                repKitaplar.DataBind();
            }
            else
            {
                kitaplar = ke.viewKitaps.ToList();
                repKitaplar.DataSource = kitaplar;
                repKitaplar.DataBind();
            }

        }
        public void KitaplarListele()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings[0].ConnectionString);
            string cmdstring;
            SqlCommand cmd;
            if (!string.IsNullOrEmpty(Request.QueryString["kitapAdi"]))
            {
                cmdstring = "select * from viewKitap where kitapAdi like '%" + (Request.QueryString["kitapAdi"]) + "%'";
                cmd = new SqlCommand(cmdstring, con);
            }
            else
            {
                cmdstring = "select * from viewKitap";
                cmd = new SqlCommand(cmdstring, con);
            }
            con.Open();

            try
            {
                SqlDataReader dr = cmd.ExecuteReader();
                repKitaplar.DataSource = dr;
                repKitaplar.DataBind();
                con.Close();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}