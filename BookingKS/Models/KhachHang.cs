namespace BookingKS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KhachHang")]
    public partial class KhachHang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KhachHang()
        {
            PhieuDatPhongs = new HashSet<PhieuDatPhong>();
            PhieuThuePhongs = new HashSet<PhieuThuePhong>();
        }

        [Key]
        public int maKH { get; set; }

        [StringLength(50)]
        public string tenKH { get; set; }

        [StringLength(10)]
        public string gioiTinh { get; set; }

        [StringLength(12)]
        public string CCCD { get; set; }

        [StringLength(50)]
        public string diaChi { get; set; }

        [StringLength(12)]
        public string sdt { get; set; }

        [StringLength(50)]
        public string email { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhieuDatPhong> PhieuDatPhongs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhieuThuePhong> PhieuThuePhongs { get; set; }
    }
}
