using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelManagement.Models
{
    // Loại phòng
    [Table("LoaiPhong")]
    public class LoaiPhong
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaLoaiPhong { get; set; }

        [Required]
        [StringLength(100)]
        public string TenLoai { get; set; }

        public decimal GiaMoiGio { get; set; }
        public decimal GiaMoiDem { get; set; }

        [StringLength(500)]
        public string MoTa { get; set; }

        public int SoNguoiToiDa { get; set; }
        public bool TrangThai { get; set; } = true;

        public override string ToString()
        {
            return TenLoai;
        }
    }

    // Phòng
    [Table("Phong")]
    public class Phong
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaPhong { get; set; }

        [Required]
        [StringLength(20)]
        public string SoPhong { get; set; }

        public int MaLoaiPhong { get; set; }
        public int Tang { get; set; }

        [Required]
        [StringLength(50)]
        public string TrangThai { get; set; } = "Trống";

        [StringLength(500)]
        public string MoTa { get; set; }

        [StringLength(255)]
        public string HinhAnh { get; set; }

        public DateTime NgayTao { get; set; } = DateTime.Now;

        // Thông tin hiển thị thêm
        [NotMapped]
        [StringLength(100)]
        public string TenLoai { get; set; }

        [NotMapped]
        public decimal GiaMoiGio { get; set; }

        [NotMapped]
        public decimal GiaMoiDem { get; set; }

        [NotMapped]
        public int SoNguoiToiDa { get; set; }

        public override string ToString()
        {
            return "Phòng " + SoPhong + " - " + TenLoai;
        }
    }

    // Khách hàng
    [Table("KhachHang")]
    public class KhachHang
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaKhachHang { get; set; }

        [Required]
        [StringLength(100)]
        public string HoTen { get; set; }

        [Required]
        [StringLength(20)]
        public string CCCD { get; set; }

        [StringLength(10)]
        public string GioiTinh { get; set; }

        public DateTime? NgaySinh { get; set; }

        [StringLength(255)]
        public string DiaChi { get; set; }

        [Required]
        [StringLength(20)]
        public string SoDienThoai { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        [StringLength(50)]
        public string QuocTich { get; set; } = "Việt Nam";

        [StringLength(500)]
        public string GhiChu { get; set; }

        public DateTime NgayTao { get; set; } = DateTime.Now;
        public bool TrangThai { get; set; } = true;

        public override string ToString() => HoTen;
    }

    // Nhân viên
    [Table("NhanVien")]
    public class NhanVien
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaNhanVien { get; set; }

        [Required]
        [StringLength(100)]
        public string HoTen { get; set; }

        [Required]
        [StringLength(20)]
        public string CCCD { get; set; }

        [StringLength(10)]
        public string GioiTinh { get; set; }

        public DateTime? NgaySinh { get; set; }

        [StringLength(255)]
        public string DiaChi { get; set; }

        [Required]
        [StringLength(20)]
        public string SoDienThoai { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        [Required]
        [StringLength(50)]
        public string ChucVu { get; set; }

        public decimal LuongCoBan { get; set; }
        public DateTime NgayVaoLam { get; set; } = DateTime.Now;
        public bool TrangThai { get; set; } = true;

        [StringLength(500)]
        public string GhiChu { get; set; }

        public override string ToString() => HoTen;
    }

    // Tài khoản
    [Table("TaiKhoan")]
    public class TaiKhoan
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaTaiKhoan { get; set; }

        [Required]
        [StringLength(50)]
        public string TenDangNhap { get; set; }

        [Required]
        [StringLength(255)]
        public string MatKhau { get; set; }

        public int MaNhanVien { get; set; }

        [Required]
        [StringLength(20)]
        public string VaiTro { get; set; } = "NhanVien"; // Admin/QuanLy/NhanVien

        public bool TrangThai { get; set; } = true;
        public DateTime? LanDangNhapCuoi { get; set; }
        public DateTime NgayTao { get; set; } = DateTime.Now;

        // Thông tin hiển thị thêm
        [NotMapped]
        [StringLength(100)]
        public string TenNhanVien { get; set; }

        [NotMapped]
        [StringLength(50)]
        public string ChucVu { get; set; }
    }

    // Đặt phòng
    [Table("DatPhong")]
    public class DatPhong
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaDatPhong { get; set; }

        public int MaPhong { get; set; }
        public int MaKhachHang { get; set; }
        public int MaNhanVienTao { get; set; }
        public DateTime NgayDat { get; set; } = DateTime.Now;
        public DateTime NgayNhanPhong { get; set; }
        public DateTime NgayTraPhong { get; set; }

        [Required]
        [StringLength(20)]
        public string LoaiDat { get; set; } = "Ngày"; // Ngày/Giờ

        public decimal GiaPhong { get; set; }

        [Required]
        [StringLength(50)]
        public string TrangThai { get; set; } = "Đã đặt";

        [StringLength(500)]
        public string GhiChu { get; set; }

        // Thông tin hiển thị thêm
        [NotMapped]
        [StringLength(20)]
        public string SoPhong { get; set; }

        [NotMapped]
        [StringLength(100)]
        public string TenLoaiPhong { get; set; }

        [NotMapped]
        [StringLength(100)]
        public string TenKhachHang { get; set; }

        [NotMapped]
        [StringLength(20)]
        public string SoDienThoai { get; set; }

        [NotMapped]
        [StringLength(100)]
        public string TenNhanVien { get; set; }
    }

    // Dịch vụ
    [Table("DichVu")]
    public class DichVu
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaDichVu { get; set; }

        [Required]
        [StringLength(100)]
        public string TenDichVu { get; set; }

        [StringLength(20)]
        public string DonViTinh { get; set; }

        public decimal DonGia { get; set; }

        [StringLength(50)]
        public string LoaiDichVu { get; set; }

        [StringLength(500)]
        public string MoTa { get; set; }

        public bool TrangThai { get; set; } = true;

        public override string ToString() => TenDichVu;
    }

    // Sử dụng dịch vụ
    [Table("SuDungDichVu")]
    public class SuDungDichVu
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaSuDung { get; set; }

        public int MaDatPhong { get; set; }
        public int MaDichVu { get; set; }
        public int SoLuong { get; set; } = 1;
        public decimal DonGia { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public decimal ThanhTien { get; set; }

        public DateTime ThoiGianSuDung { get; set; } = DateTime.Now;

        [StringLength(500)]
        public string GhiChu { get; set; }

        public int? MaNhanVien { get; set; }

        // Thông tin hiển thị thêm
        [NotMapped]
        [StringLength(100)]
        public string TenDichVu { get; set; }

        [NotMapped]
        [StringLength(20)]
        public string DonViTinh { get; set; }
    }

    // Hóa đơn
    [Table("HoaDon")]
    public class HoaDon
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaHoaDon { get; set; }

        public int MaDatPhong { get; set; }
        public int MaNhanVienTao { get; set; }
        public DateTime NgayLap { get; set; } = DateTime.Now;
        public decimal TienPhong { get; set; }
        public decimal TienDichVu { get; set; }
        public decimal GiamGia { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public decimal TongTien { get; set; }

        [Required]
        [StringLength(50)]
        public string PhuongThucTT { get; set; } = "Tiền mặt";

        [Required]
        [StringLength(50)]
        public string TrangThai { get; set; } = "Chưa thanh toán";

        [StringLength(500)]
        public string GhiChu { get; set; }

        // Thông tin hiển thị thêm
        [NotMapped]
        [StringLength(20)]
        public string SoPhong { get; set; }

        [NotMapped]
        [StringLength(100)]
        public string TenKhachHang { get; set; }

        [NotMapped]
        [StringLength(100)]
        public string TenNhanVien { get; set; }
    }

    // Thông tin đăng nhập hiện tại
    public static class SessionManager
    {
        public static int MaTaiKhoan { get; set; }
        public static string TenDangNhap { get; set; }
        public static string VaiTro { get; set; }
        public static string TenNhanVien { get; set; }
        public static int MaNhanVien { get; set; }
        public static string ChucVu { get; set; }

        public static bool IsAdmin
        {
            get { return VaiTro == "Admin"; }
        }

        public static bool IsQuanLy
        {
            get { return VaiTro == "Admin" || VaiTro == "QuanLy"; }
        }

        public static void Clear()
        {
            MaTaiKhoan = 0; TenDangNhap = null; VaiTro = null;
            TenNhanVien = null; MaNhanVien = 0; ChucVu = null;
        }
    }
}