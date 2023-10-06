namespace BookingKS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PhieuThuePhong")]
    public partial class PhieuThuePhong
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PhieuThuePhong()
        {
            CT_PhieuThuePhong = new HashSet<CT_PhieuThuePhong>();
            HoaDons = new HashSet<HoaDon>();
        }

        [Key]
        public int maPTP { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ngayThue { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ngayTra { get; set; }

        public int? maPDP { get; set; }

        public int? maKH { get; set; }

        public int? maNV { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CT_PhieuThuePhong> CT_PhieuThuePhong { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HoaDon> HoaDons { get; set; }

        public virtual KhachHang KhachHang { get; set; }

        public virtual NhanVien NhanVien { get; set; }

        public virtual PhieuDatPhong PhieuDatPhong { get; set; }
    }
}
