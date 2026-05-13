using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using HotelManagement.Database;
using HotelManagement.Models;

namespace HotelManagement
{
    public partial class frmDangNhap : Form
    {
        DataContext db = new DataContext();

        public frmDangNhap()
        {
            InitializeComponent();
        }

        // Hàm mã hóa mật khẩu MD5 (theo hướng dẫn thầy)
        public string GetMD5(string password)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(password);
                byte[] hashBytes = md5.ComputeHash(inputBytes);
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("x2"));
                }
                return sb.ToString();
            }
        }

        // Nút Đăng nhập (logic theo hướng dẫn thầy, dùng LINQ query syntax)
        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string user = txtTenDangNhap.Text.Trim();
            string matKhauGoc = txtMatKhau.Text.Trim();

            if (string.IsNullOrEmpty(user) || string.IsNullOrEmpty(matKhauGoc))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string pass = GetMD5(matKhauGoc);

            // Truy vấn tài khoản bằng LINQ (theo hướng dẫn thầy)
            var account = db.TaiKhoans.FirstOrDefault(
                tk => tk.TenDangNhap == user && tk.MatKhau == pass && tk.TrangThai == true
            );

            if (account != null)
            {
                // Kiểm tra nhân viên còn hoạt động không
                var nhanVien = db.NhanViens.SingleOrDefault(nv => nv.MaNhanVien == account.MaNhanVien);
                if (nhanVien == null || nhanVien.TrangThai == false)
                {
                    MessageBox.Show("Tài khoản của bạn đang bị khóa!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Lưu thông tin đăng nhập vào SessionManager
                SessionManager.MaTaiKhoan = account.MaTaiKhoan;
                SessionManager.TenDangNhap = account.TenDangNhap;
                SessionManager.VaiTro = account.VaiTro;
                SessionManager.MaNhanVien = nhanVien.MaNhanVien;
                SessionManager.TenNhanVien = nhanVien.HoTen;
                SessionManager.ChucVu = nhanVien.ChucVu;

                // Cập nhật lần đăng nhập cuối
                account.LanDangNhapCuoi = DateTime.Now;
                db.SaveChanges();

                frmMain fMain = new frmMain();
                fMain.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMatKhau.Clear();
                txtMatKhau.Focus();
            }
        }

        // Nút Thoát
        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // Nhấn Enter ở bất kỳ ô nhập nào để đăng nhập
        private void txt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnDangNhap_Click(sender, e);
            }
        }
    }
}
