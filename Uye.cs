//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace _025_Kutuphane
{
    using System;
    using System.Collections.Generic;
    
    public partial class Uye
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Uye()
        {
            this.Oduncs = new HashSet<Odunc>();
        }
    
        public int uyeID { get; set; }
        public string uyeAdi { get; set; }
        public string uyeSoyadi { get; set; }
        public string uyeAdresi { get; set; }
        public Nullable<bool> aktifMi { get; set; }
        public string kullaniciAdi { get; set; }
        public string sifre { get; set; }
        public string email { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Odunc> Oduncs { get; set; }
    }
}
