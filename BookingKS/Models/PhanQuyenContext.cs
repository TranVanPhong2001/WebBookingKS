using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace BookingKS.Models
{
    public partial class PhanQuyenContext : DbContext
    {
        public PhanQuyenContext()
            : base("name=PhanQuyenContext")
        {
        }

        public virtual DbSet<DanhSachQuyen> DanhSachQuyens { get; set; }
        public virtual DbSet<KhachSan> KhachSans { get; set; }
        public virtual DbSet<LoaiPhong> LoaiPhongs { get; set; }
        public virtual DbSet<NhomNhanSu> NhomNhanSus { get; set; }
        public virtual DbSet<Phong> Phongs { get; set; }
        public virtual DbSet<QuanTri> QuanTris { get; set; }
        public virtual DbSet<Quyen> Quyens { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DanhSachQuyen>()
                .Property(e => e.IDNhom)
                .IsUnicode(false);

            modelBuilder.Entity<DanhSachQuyen>()
                .Property(e => e.IDQuyen)
                .IsUnicode(false);

            modelBuilder.Entity<KhachSan>()
                .HasMany(e => e.LoaiPhongs)
                .WithRequired(e => e.KhachSan)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KhachSan>()
                .HasMany(e => e.Phongs)
                .WithRequired(e => e.KhachSan)
                .WillCascadeOnDelete(false);

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
