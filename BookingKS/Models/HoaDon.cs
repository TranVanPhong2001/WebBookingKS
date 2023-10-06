namespace BookingKS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HoaDon")]
    public partial class HoaDon
    {
        [Key]
        public int maHD { get; set; }

        public decimal? tongTien { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ngayThanhToan { get; set; }

        public int? maNV { get; set; }

        public int? maPTP { get; set; }

        public virtual NhanVien NhanVien { get; set; }

        public virtual PhieuThuePhong PhieuThuePhong { get; set; }
    }
}
