namespace BookingKS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;

    [Table("Phong")]
    public partial class Phong
    {
        [Key]
        public int maPhong { get; set; }

        [StringLength(50)]
        public string tenPhong { get; set; }

        public int ?maLP { get; set; }

        [StringLength(250)]
        public string Image { get; set; }

        public int sucChua { get; set; }

        public decimal donGia { get; set; }

        [StringLength(500)]
        public string moTa { get; set; }

        [StringLength(50)]
        public string tinhTrang { get; set; }

        public int Luot { get; set; }
      
        public virtual LoaiPhong LoaiPhong { get; set; }

        public static List<Phong> GetAll(string searchKey)
        {
            HotelContext context = new HotelContext();
            searchKey = searchKey + "";
            return context.Phongs.Where(p => p.LoaiPhong.tenLP.Contains(searchKey)).ToList();
        }
    }
}
