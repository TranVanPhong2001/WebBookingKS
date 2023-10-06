namespace BookingKS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CT_PhieuThuePhong
    {
        [Key]
        public int Id_CTTP { get; set; }

        public int? maPTP { get; set; }

        public int? maPhong { get; set; }

        public DateTime? ngaySuDung { get; set; }

        public int? maDV { get; set; }

        public virtual DichVu DichVu { get; set; }

        public virtual PhieuThuePhong PhieuThuePhong { get; set; }

        public virtual Phong Phong { get; set; }
    }
}
