using System;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using HotelManagement.Database;
using HotelManagement.Models;

namespace HotelManagement
{
    public partial class frmKhachHang : Form
    {
        private readonly bool isDialog;

        public frmKhachHang() : this(false)
        {
        }

        public frmKhachHang(bool isDialog)
        {
            this.isDialog = isDialog;
            InitializeComponent();
            LoadData();
        }

        private void LoadData(string kw = "")
        {
            using (var db = new DataContext())
            {
                if (string.IsNullOrEmpty(kw))
                {
                    dgv.DataSource = db.KhachHangs.Where(x => x.TrangThai).OrderBy(x => x.HoTen).ToList();
                }
                else
                {
                    dgv.DataSource = db.KhachHangs
                        .Where(x => x.TrangThai && (x.HoTen.Contains(kw) || x.CCCD.Contains(kw) || x.SoDienThoai.Contains(kw)))
                        .OrderBy(x => x.HoTen).ToList();
                }
            }
        }

        private void ThemKH()
        {
            var kh = GetForm();
            if (kh == null) return;
            bool ok = ThemKhachHang(kh);
            if (ok)
            {
                ClearForm();
                LoadData();
                if (isDialog)
                {
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
        }

        private void CapNhatKH()
        {
            if (string.IsNullOrEmpty(txtMaKH.Text))
            {
                MessageBox.Show("Chọn khách hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var kh = GetForm();
            if (kh == null) return;
            kh.MaKhachHang = int.Parse(txtMaKH.Text);
            bool ok = CapNhatKhachHang(kh);
            if (ok) LoadData();
        }

        private void XoaKH()
        {
            if (string.IsNullOrEmpty(txtMaKH.Text)) return;
            if (MessageBox.Show("Xóa khách hàng này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
            bool ok = XoaKhachHang(int.Parse(txtMaKH.Text));
            if (ok)
            {
                ClearForm();
                LoadData();
            }
        }

        private KhachHang GetForm()
        {
            return new KhachHang
            {
                HoTen = txtHoTen.Text.Trim(),
                CCCD = txtCCCD.Text.Trim(),
                SoDienThoai = txtSDT.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                DiaChi = txtDiaChi.Text.Trim(),
                GioiTinh = cboGioiTinh.SelectedItem?.ToString(),
                NgaySinh = dtpNgaySinh.Value
            };
        }

        private bool ThemKhachHang(KhachHang kh)
        {
            if (!ValidateKhachHang(kh)) return false;

            try
            {
                using (var db = new DataContext())
                {
                    if (string.IsNullOrWhiteSpace(kh.QuocTich)) kh.QuocTich = "Việt Nam";
                    db.KhachHangs.Add(kh);
                    db.SaveChanges();
                    MessageBox.Show("Thêm khách hàng thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private bool CapNhatKhachHang(KhachHang kh)
        {
            if (!ValidateKhachHang(kh)) return false;

            try
            {
                using (var db = new DataContext())
                {
                    var exist = db.KhachHangs.Find(kh.MaKhachHang);
                    if (exist == null)
                    {
                        MessageBox.Show("Lỗi: Không tìm thấy khách hàng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }

                    exist.HoTen = kh.HoTen;
                    exist.GioiTinh = kh.GioiTinh;
                    exist.NgaySinh = kh.NgaySinh;
                    exist.DiaChi = kh.DiaChi;
                    exist.SoDienThoai = kh.SoDienThoai;
                    exist.Email = kh.Email;
                    exist.QuocTich = string.IsNullOrWhiteSpace(kh.QuocTich) ? "Việt Nam" : kh.QuocTich;
                    exist.GhiChu = kh.GhiChu;

                    db.SaveChanges();
                    MessageBox.Show("Cập nhật khách hàng thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private bool XoaKhachHang(int maKH)
        {
            try
            {
                using (var db = new DataContext())
                {
                    bool hasDatPhong = db.DatPhongs.Any(dp => dp.MaKhachHang == maKH && dp.TrangThai != "Đã trả" && dp.TrangThai != "Hủy");
                    if (hasDatPhong)
                    {
                        MessageBox.Show("Không thể xóa! Khách hàng đang có đặt phòng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }

                    var exist = db.KhachHangs.Find(maKH);
                    if (exist != null)
                    {
                        exist.TrangThai = false;
                        db.SaveChanges();
                    }

                    MessageBox.Show("Xóa khách hàng thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private bool ValidateKhachHang(KhachHang kh)
        {
            if (string.IsNullOrWhiteSpace(kh.HoTen))
            {
                MessageBox.Show("Họ tên khách hàng không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrWhiteSpace(kh.CCCD))
            {
                MessageBox.Show("CCCD/Hộ chiếu không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (!Regex.IsMatch(kh.CCCD, @"^\d{9}$|^\d{12}$"))
            {
                MessageBox.Show("CCCD phải có 9 hoặc 12 chữ số!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrWhiteSpace(kh.SoDienThoai))
            {
                MessageBox.Show("Số điện thoại không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (!Regex.IsMatch(kh.SoDienThoai, @"^(0[3|5|7|8|9])+([0-9]{8})$"))
            {
                MessageBox.Show("Số điện thoại không đúng định dạng Việt Nam!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (!string.IsNullOrWhiteSpace(kh.Email) && !Regex.IsMatch(kh.Email, @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$"))
            {
                MessageBox.Show("Email không đúng định dạng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void DgvSelectionChanged(object sender, EventArgs e)
        {
            if (dgv.CurrentRow == null) return;
            var row = dgv.CurrentRow;
            txtMaKH.Text = row.Cells["MaKhachHang"].Value?.ToString();
            txtHoTen.Text = row.Cells["HoTen"].Value?.ToString();
            txtCCCD.Text = row.Cells["CCCD"].Value?.ToString();
            txtSDT.Text = row.Cells["SoDienThoai"].Value?.ToString();
            txtEmail.Text = row.Cells["Email"].Value?.ToString();
            txtDiaChi.Text = row.Cells["DiaChi"].Value?.ToString();
            cboGioiTinh.Text = row.Cells["GioiTinh"].Value?.ToString();
        }

        private void ClearForm()
        {
            txtMaKH.Text = txtHoTen.Text = txtCCCD.Text = txtSDT.Text = txtEmail.Text = txtDiaChi.Text = "";
            dgv.ClearSelection();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            ThemKH();
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            CapNhatKH();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            XoaKH();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ClearForm();
            LoadData();
        }
        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            if (txtTimKiem.Text.Length != 1) LoadData(txtTimKiem.Text);
        }
    }
}
