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
    
    public partial class Yazar
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Yazar()
        {
            this.KitapYazars = new HashSet<KitapYazar>();
        }
    
        public int yazarID { get; set; }
        public string yazarAdi { get; set; }
        public System.DateTime yazarDogum { get; set; }
        public string hayatOzeti { get; set; }
        public string yazarResim { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KitapYazar> KitapYazars { get; set; }
    }
}