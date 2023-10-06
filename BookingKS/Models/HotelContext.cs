using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace BookingKS.Models
{
    public partial class HotelContext : DbContext
    {
        public HotelContext()
            : base("name=HotelContext")
        {
        }

        public virtual DbSet<CT_PhieuDatPhong> CT_PhieuDatPhong { get; set; }
        public virtual DbSet<CT_PhieuThuePhong> CT_PhieuThuePhong { get; set; }
        public virtual DbSet<DichVu> DichVus { get; set; }
        public virtual DbSet<HoaDon> HoaDons { get; set; }
        public virtual DbSet<KhachHang> KhachHangs { get; set; }
        public virtual DbSet<LienHe> LienHes { get; set; }
        public virtual DbSet<LoaiPhong> LoaiPhongs { get; set; }
        public virtual DbSet<NhanVien> NhanViens { get; set; }
       
        public virtual DbSet<PhieuThuePhong> PhieuThuePhongs { get; set; }
        public virtual DbSet<Phong> Phongs { get; set; }

        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<PhieuDatPhong> PhieuDatPhongs { get; set; }
       

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CT_PhieuDatPhong>()
                .Property(e => e.tienCoc)
                .HasPrecision(18, 0);

            modelBuilder.Entity<DichVu>()
                .Property(e => e.donGia)
                .HasPrecision(18, 0);

            modelBuilder.Entity<HoaDon>()
                .Property(e => e.tongTien)
                .HasPrecision(18, 0);

            modelBuilder.Entity<KhachHang>()
                .Property(e => e.CCCD)
                .IsUnicode(false);

            modelBuilder.Entity<KhachHang>()
                .Property(e => e.sdt)
                .IsUnicode(false);

            modelBuilder.Entity<LienHe>()
                .Property(e => e.sdt)
                .IsUnicode(false);

            modelBuilder.Entity<LoaiPhong>()
                .Property(e => e.tenLP)
                .IsFixedLength();

            modelBuilder.Entity<LoaiPhong>()
                .Property(e => e.DG)
                .HasPrecision(18, 0);

            modelBuilder.Entity<LoaiPhong>()
                .HasMany(e => e.Phongs)
                .WithOptional(e => e.LoaiPhong)
                .HasForeignKey(e => e.maLP);

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.sdt)
                .IsUnicode(false);

            modelBuilder.Entity<PhieuDatPhong>()
                .Property(e => e.tongTienCoc)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Phong>()
                .Property(e => e.donGia)
                .HasPrecision(18, 0);

           
        }
    }
}
