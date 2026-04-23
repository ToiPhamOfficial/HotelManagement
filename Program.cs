using System;
using System.Windows.Forms;
using HotelManagement.Models;
// using HotelManagement.UI;

namespace HotelManagement
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Đăng nhập với quyền Admin
            SessionManager.MaTaiKhoan = 1;
            SessionManager.TenDangNhap = "admin";
            SessionManager.VaiTro = "Admin";
            SessionManager.TenNhanVien = "Administrator";
            SessionManager.MaNhanVien = 1;
            SessionManager.ChucVu = "Quản trị viên";

            Application.Run(new frmMain());
        }
    }
}
