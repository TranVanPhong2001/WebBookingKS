namespace BookingKS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LienHe")]
    public partial class LienHe
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string hoTen { get; set; }

        [StringLength(12)]
        public string sdt { get; set; }

        [StringLength(50)]
        public string email { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ngayGui { get; set; }

        [StringLength(500)]
        public string noiDung { get; set; }
    }
}
