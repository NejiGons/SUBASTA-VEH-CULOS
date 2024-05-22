namespace subasta.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TipoVehiculo")]
    public partial class TipoVehiculo
    {
        [Key]
        public int idTipoVehiculo { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }
    }
}
