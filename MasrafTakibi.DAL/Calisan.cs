//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MasrafTakibi.DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class Calisan
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Calisan()
        {
            this.ToplamMasraf = new HashSet<ToplamMasraf>();
        }
    
        public int CalisanID { get; set; }
        public string CalisanAdi { get; set; }
        public string CalisanSoyadi { get; set; }
        public string CalisanBirimi { get; set; }
        public string CalisanSifre { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ToplamMasraf> ToplamMasraf { get; set; }
    }
}
