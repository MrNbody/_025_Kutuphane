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
    public partial class Admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btngiris_Click(object sender, EventArgs e)
        {
            if (txtKullaniciAdi.Text == "halitak" && txtSifre.Text == "636363")
            {
                Session.Add("admin", txtKullaniciAdi.Text);
                Response.Redirect("Anasayfa.aspx");
            }
        }
    }
}