namespace BookingKS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KhachSan")]
    public partial class KhachSan
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KhachSan()
        {
            LoaiPhongs = new HashSet<LoaiPhong>();
            Phongs = new HashSet<Phong>();
        }

        [Key]
        public int ma_KS { get; set; }

        [Required]
        [StringLength(50)]
        public string ten_KS { get; set; }

        [Required]
        [StringLength(50)]
        public string diaChi { get; set; }

        [Required]
        [StringLength(15)]
        public string sdt { get; set; }

        [Required]
        [StringLength(250)]
        public string hinhAnh { get; set; }

        [StringLength(50)]
        public string moTa { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LoaiPhong> LoaiPhongs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Phong> Phongs { get; set; }
    }
}
