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
    public partial class YazarGuncelle : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            object admin = Session["admin"];
            if (admin == null)
                Response.Redirect("Admin.aspx");
            if (!IsPostBack){
                //YazarListele();
                YazarListeleEntity();
            }
        }
        private void YazarListeleEntity()
        {
            KutuphaneEntities ke = new KutuphaneEntities();
            var sorgu = ke.Yazars.ToList();
            listYazar.DataSource=sorgu;
            listYazar.DataBind();
        }
        public void YazarListele()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings[0].ConnectionString);
            string cmdstring;
            SqlCommand cmd;
            cmdstring = "select yazarID, yazarAdi from Yazar";
            cmd = new SqlCommand(cmdstring, con);
            con.Open();
            try{
                SqlDataReader dr = cmd.ExecuteReader();
                listYazar.DataSource = dr;
                listYazar.DataBind();
                con.Close();
            }catch (Exception){ throw;}
        }
    }
}