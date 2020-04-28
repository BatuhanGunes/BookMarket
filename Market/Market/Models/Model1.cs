namespace Market.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model12")
        {
        }

        public virtual DbSet<Adre> Adres { get; set; }
        public virtual DbSet<Kisi> Kisis { get; set; }
        public virtual DbSet<Kitap> Kitaps { get; set; }
        public virtual DbSet<KitapTuru> KitapTurus { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Kisi>()
                .HasMany(e => e.Adres)
                .WithRequired(e => e.Kisi)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Kisi>()
                .HasMany(e => e.Kitaps)
                .WithRequired(e => e.Kisi)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KitapTuru>()
                .Property(e => e.KitapTurIsmi)
                .IsFixedLength();

            modelBuilder.Entity<KitapTuru>()
                .HasMany(e => e.Kitaps)
                .WithRequired(e => e.KitapTuru)
                .WillCascadeOnDelete(false);
        }
    }
}
