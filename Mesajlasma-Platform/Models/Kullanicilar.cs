//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Mesajlasma_Platform.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Kullanicilar
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Kullanicilar()
        {
            this.Gruplar = new HashSet<Gruplar>();
            this.GrupUyeleri = new HashSet<GrupUyeleri>();
            this.Mesajlar = new HashSet<Mesajlar>();
            this.Mesajlar1 = new HashSet<Mesajlar>();
            this.TopluMesajAlicilar = new HashSet<TopluMesajAlicilar>();
        }
    
        public int kullaniciId { get; set; }
        public string kullaniciAdi { get; set; }
        public string adSoyad { get; set; }
        public string sifre { get; set; }
        public string eposta { get; set; }
        public string telefon { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Gruplar> Gruplar { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GrupUyeleri> GrupUyeleri { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Mesajlar> Mesajlar { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Mesajlar> Mesajlar1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TopluMesajAlicilar> TopluMesajAlicilar { get; set; }
    }
}