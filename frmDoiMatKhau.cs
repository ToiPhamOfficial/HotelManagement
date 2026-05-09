using System;
using System.Security.Cryptography;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using HotelManagement.Database;
using HotelManagement.Models;

namespace HotelManagement
{
    public partial class frmDoiMatKhau : Form
    {
        DataContext db = new DataContext();

        public frmDoiMatKhau()
        {
            InitializeComponent();
        }

        private void btnDoiMatKhau_Click(object sender, EventArgs e)
        {
            bool ok = DoiMatKhau(SessionManager.MaTaiKhoan, txtCu.Text, txtMoi.Text, txtXacNhan.Text);
            if (ok) Close();
        }

        private bool DoiMatKhau(int maTK, string matKhauCu, string matKhauMoi, string xacNhan)
        {
            if (string.IsNullOrWhiteSpace(matKhauMoi) || matKhauMoi.Length < 6)
            {
                MessageBox.Show("Mật khẩu mới phải có ít nhất 6 ký tự!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (matKhauMoi != xacNhan)
            {
                MessageBox.Show("Mật khẩu xác nhận không khớp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            try
            {
                var taiKhoan = db.TaiKhoans.FirstOrDefault(t => t.MaTaiKhoan == maTK);
                if (taiKhoan == null)
                {
                    MessageBox.Show("Tài khoản không tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                taiKhoan.MatKhau = GetMD5(matKhauMoi);
                db.SaveChanges();
                MessageBox.Show("Đổi mật khẩu thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đổi mật khẩu thất bại: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private static string GetMD5(string input)
        {
            using (var md5 = MD5.Create())
            {
                byte[] bytes = md5.ComputeHash(Encoding.UTF8.GetBytes(input));
                var sb = new StringBuilder();
                foreach (byte b in bytes) sb.Append(b.ToString("X2")); // or "x2" based on previous convention
                return sb.ToString().ToLower(); // Teacher's MD5 usually lowercase, let's keep lowercase x2
            }
        }
    }
}
