namespace BookingKS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("QuanTri")]
    public partial class QuanTri
    {
        [Key]
        [StringLength(20)]
        public string username { get; set; }

        [Required]
        [StringLength(50)]
        public string password { get; set; }

        public bool tinhTrang { get; set; }

        public int maNV { get; set; }

        [Required]
        [StringLength(20)]
        public string IDNhom { get; set; }

        public virtual NhomNhanSu NhomNhanSu { get; set; }

        public virtual NhanVien NhanVien { get; set; }
    }
}
