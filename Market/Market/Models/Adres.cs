namespace Market.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Adres
    {
        public int AdresID { get; set; }

        [Required]
        [StringLength(20)]
        public string Ilce { get; set; }

        [Required]
        [StringLength(300)]
        public string AdresAciklamasi { get; set; }

        public int KisiID { get; set; }

        public virtual Kisi Kisi { get; set; }
    }
}
