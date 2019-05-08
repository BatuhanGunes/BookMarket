namespace Market.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Kitap")]
    public partial class Kitap
    {
        public int KitapID { get; set; }

        [Required]
        [StringLength(25)]
        public string KitapAdi { get; set; }

        [StringLength(25)]
        public string YazarAdi { get; set; }

        [StringLength(25)]
        public string YayinEvi { get; set; }

        public int? SayfaSayisi { get; set; }

        [Column(TypeName = "date")]
        public DateTime? BasimYili { get; set; }

        public double Fiyat { get; set; }

        [StringLength(1000)]
        public string Aciklama { get; set; }

        [StringLength(10)]
        public string Resim { get; set; }

        public int KitapTurID { get; set; }

        public int KisiID { get; set; }

        public bool Durum { get; set; }

        public virtual Kisi Kisi { get; set; }

        public virtual KitapTuru KitapTuru { get; set; }
    }
}
