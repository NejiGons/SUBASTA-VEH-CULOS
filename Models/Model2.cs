using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace subasta.Models
{
    public partial class Model2 : DbContext
    {
        public Model2()
            : base("name=Model2")
        {
        }

        public virtual DbSet<SubastaVehiculos> SubastaVehiculos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SubastaVehiculos>()
                .Property(e => e.Vehiculo)
                .IsUnicode(false);

            modelBuilder.Entity<SubastaVehiculos>()
                .Property(e => e.Vendedor)
                .IsUnicode(false);

            modelBuilder.Entity<SubastaVehiculos>()
                .Property(e => e.Comprador)
                .IsUnicode(false);

            modelBuilder.Entity<SubastaVehiculos>()
                .Property(e => e.PlacaVehiculo)
                .IsUnicode(false);

            modelBuilder.Entity<SubastaVehiculos>()
                .Property(e => e.CiudadEntrega)
                .IsUnicode(false);
        }
    }
}
