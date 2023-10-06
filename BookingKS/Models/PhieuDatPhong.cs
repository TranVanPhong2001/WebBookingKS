namespace BookingKS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PhieuDatPhong")]
    public partial class PhieuDatPhong
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PhieuDatPhong()
        {
            CT_PhieuDatPhong = new HashSet<CT_PhieuDatPhong>();
            PhieuThuePhongs = new HashSet<PhieuThuePhong>();
        }

        [Key]
        public int maPDP { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ngayDen { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ngayDi { get; set; }

        public decimal? tongTienCoc { get; set; }

        public int? soNguoi { get; set; }

        public int? maKH { get; set; }

        public int? maNV { get; set; }

        

        

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CT_PhieuDatPhong> CT_PhieuDatPhong { get; set; }

        public virtual KhachHang KhachHang { get; set; }

        public virtual NhanVien NhanVien { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhieuThuePhong> PhieuThuePhongs { get; set; }
    }
}
