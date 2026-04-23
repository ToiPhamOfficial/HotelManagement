using HotelManagement.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Runtime.Remoting.Contexts;

namespace HotelManagement.Database
{
    public class DataContext : DbContext
    {
        public DataContext() : base("name=HotelDB")
        {
        }

        public DbSet<LoaiPhong> LoaiPhongs { get; set; }
        public DbSet<Phong> Phongs { get; set; }
        public DbSet<KhachHang> KhachHangs { get; set; }
        public DbSet<NhanVien> NhanViens { get; set; }
        public DbSet<TaiKhoan> TaiKhoans { get; set; }
        public DbSet<DatPhong> DatPhongs { get; set; }
        public DbSet<DichVu> DichVus { get; set; }
        public DbSet<SuDungDichVu> SuDungDichVus { get; set; }
        public DbSet<HoaDon> HoaDons { get; set; }
    }
}
