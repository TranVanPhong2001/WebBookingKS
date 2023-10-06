namespace BookingKS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CT_PhieuDatPhong
    {
        [Key]
        public int Id_CTDT { get; set; }

        public int? maPhong { get; set; }

        public int? maPDP { get; set; }

        public decimal? tienCoc { get; set; }

        public virtual PhieuDatPhong PhieuDatPhong { get; set; }

        public virtual Phong Phong { get; set; }
    }
}
