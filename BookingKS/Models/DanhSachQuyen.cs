namespace BookingKS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DanhSachQuyen")]
    public partial class DanhSachQuyen
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(20)]
        public string IDNhom { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string IDQuyen { get; set; }

        [StringLength(50)]
        public string GhiChu { get; set; }

        public virtual NhomNhanSu NhomNhanSu { get; set; }

        public virtual Quyen Quyen { get; set; }
    }
}
