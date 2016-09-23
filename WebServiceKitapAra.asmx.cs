using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;

namespace _025_Kutuphane
{
    /// <summary>
    /// Summary description for WebServiceKitapAra
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class WebServiceKitapAra : System.Web.Services.WebService
    {
        KutuphaneEntities db = new KutuphaneEntities();
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string[] KitapGetir(string prefix)
        {
            List<string> list = new List<string>();
            List<Kitap> kitap = db.Kitaps.Where(o => o.kitapAdi.Contains(prefix)).ToList();
            foreach (Kitap item in kitap)
            {
                list.Add(string.Format("{0}-{1}", (item.kitapAdi), item.kitapID));
            }
            return list.ToArray();
        }
    }
}
