using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _025_Kutuphane.admin
{
    public partial class Anasayfa : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            object admin = Session["admin"];
            if (admin==null)
            {
                Response.Redirect("Admin.aspx");
            }
        }
    }
}