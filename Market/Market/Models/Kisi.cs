namespace Market.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Kisi")]
    public partial class Kisi
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Kisi()
        {
            Adres = new HashSet<Adres>();
            Kitap = new HashSet<Kitap>();
        }

        public int KisiID { get; set; }

        public int? SepetID { get; set; }

        [Required]
        [StringLength(25)]
        public string Ad { get; set; }

        [Required]
        [StringLength(25)]
        public string Soyad { get; set; }

        [Required]
        [StringLength(50)]
        public string Eposta { get; set; }

        [StringLength(11)]
        public string TelNo { get; set; }

        [StringLength(50)]
        public string Cinsiyet { get; set; }

        [Required]
        [StringLength(16)]
        public string Parola { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Adres> Adres { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Kitap> Kitap { get; set; }
    }
}
