namespace BookingKS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Phong")]
    public partial class Phong
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Phong()
        {
            CT_PhieuDatPhong = new HashSet<CT_PhieuDatPhong>();
            CT_PhieuThuePhong = new HashSet<CT_PhieuThuePhong>();
        }

        [Key]
        public int maPhong { get; set; }

        [StringLength(50)]
        public string tenPhong { get; set; }

        public int? maLP { get; set; }

        [StringLength(250)]
        public string Image { get; set; }

        public int? sucChua { get; set; }

        public decimal? donGia { get; set; }

        [StringLength(500)]
        public string moTa { get; set; }

        [StringLength(50)]
        public string tinhTrang { get; set; }

        public int? Luot { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CT_PhieuDatPhong> CT_PhieuDatPhong { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CT_PhieuThuePhong> CT_PhieuThuePhong { get; set; }

        public virtual LoaiPhong LoaiPhong { get; set; }
    }
}
