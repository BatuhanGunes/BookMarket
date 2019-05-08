namespace Market.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KitapTuru")]
    public partial class KitapTuru
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KitapTuru()
        {
            Kitap = new HashSet<Kitap>();
        }

        [Key]
        public int KitapTurID { get; set; }

        [Required]
        [StringLength(20)]
        public string KitapTurIsmi { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Kitap> Kitap { get; set; }
    }
}
