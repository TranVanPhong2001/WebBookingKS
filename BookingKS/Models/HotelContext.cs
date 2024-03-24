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

        //public virtual DbSet<CT_PhieuDatPhong> CT_PhieuDatPhong { get; set; }
        //public virtual DbSet<CT_PhieuThuePhong> CT_PhieuThuePhong { get; set; }
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
        public virtual DbSet<DanhSachQuyen> DanhSachQuyens { get; set; }     
        public virtual DbSet<NhomNhanSu> NhomNhanSus { get; set; }      
        public virtual DbSet<QuanTri> QuanTris { get; set; }
        public virtual DbSet<Quyen> Quyens { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<CT_PhieuDatPhong>()
            //    .Property(e => e.tienCoc)
            //    .HasPrecision(18, 0);

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

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.sdt)
                .IsUnicode(false);

            modelBuilder.Entity<NhanVien>()
                .HasMany(e => e.QuanTris)
                .WithRequired(e => e.NhanVien)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PhieuDatPhong>()
                .Property(e => e.tongTienCoc)
                .HasPrecision(18, 0);           

            modelBuilder.Entity<DanhSachQuyen>()
               .Property(e => e.IDNhom)
               .IsUnicode(false);

            modelBuilder.Entity<DanhSachQuyen>()
                .Property(e => e.IDQuyen)
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

            modelBuilder.Entity<NhomNhanSu>()
                .Property(e => e.IDNhom)
                .IsUnicode(false);

            modelBuilder.Entity<NhomNhanSu>()
                .HasMany(e => e.DanhSachQuyens)
                .WithRequired(e => e.NhomNhanSu)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NhomNhanSu>()
                .HasMany(e => e.QuanTris)
                .WithRequired(e => e.NhomNhanSu)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Phong>()
                .Property(e => e.donGia)
                .HasPrecision(18, 0);

            modelBuilder.Entity<QuanTri>()
                .Property(e => e.username)
                .IsUnicode(false);

            modelBuilder.Entity<QuanTri>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<QuanTri>()
                .Property(e => e.IDNhom)
                .IsUnicode(false);

            modelBuilder.Entity<Quyen>()
                .Property(e => e.IDQuyen)
                .IsUnicode(false);

            modelBuilder.Entity<Quyen>()
                .HasMany(e => e.DanhSachQuyens)
                .WithRequired(e => e.Quyen)
                .WillCascadeOnDelete(false);

        }
    }
}
