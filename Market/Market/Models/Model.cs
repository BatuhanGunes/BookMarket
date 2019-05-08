namespace Market.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model : DbContext
    {
        public Model()
            : base("name=Model11")
        {
        }

        public virtual DbSet<Adres> Adres { get; set; }
        public virtual DbSet<Kisi> Kisi { get; set; }
        public virtual DbSet<Kitap> Kitap { get; set; }
        public virtual DbSet<KitapTuru> KitapTuru { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Kisi>()
                .HasMany(e => e.Adres)
                .WithRequired(e => e.Kisi)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Kisi>()
                .HasMany(e => e.Kitap)
                .WithRequired(e => e.Kisi)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KitapTuru>()
                .Property(e => e.KitapTurIsmi)
                .IsFixedLength();

            modelBuilder.Entity<KitapTuru>()
                .HasMany(e => e.Kitap)
                .WithRequired(e => e.KitapTuru)
                .WillCascadeOnDelete(false);
        }
    }
}
