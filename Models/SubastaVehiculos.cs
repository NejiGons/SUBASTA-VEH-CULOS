namespace subasta.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SubastaVehiculos
    {
        [Key]
        public int idSubastaVehiculos { get; set; }

        public int idTipoVehiculo { get; set; }

        [ForeignKey("idTipoVehiculo")]
        public virtual TipoVehiculo TipoVehiculo { get; set; }

        [Required]
        [StringLength(50)]
        public string Vehiculo { get; set; }

        [Required]
        [StringLength(80)]
        public string Vendedor { get; set; }

        [Required]
        [StringLength(80)]
        public string Comprador { get; set; }

        public float ValorVenta { get; set; }

        [Required]
        [StringLength(8)]
        public string PlacaVehiculo { get; set; }

        public float ValorComision { get; set; }

        [Required]
        [StringLength(50)]
        public string CiudadEntrega { get; set; }
    }
}
