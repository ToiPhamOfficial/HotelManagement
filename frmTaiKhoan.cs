using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using HotelManagement.Database;
using HotelManagement.Models;

namespace HotelManagement
{
    public partial class frmTaiKhoan : Form
    {

        DataContext db = new DataContext();
        bool AddNew = false;

        public frmTaiKhoan()
        {
            InitializeComponent();
            dgvTaiKhoan.AutoGenerateColumns = false;
            dgvTaiKhoan.AllowUserToAddRows = false;
            this.Load += frmTaiKhoan_Load;
        }


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

        // Bật/tắt các control khi ở chế độ thêm/sửa
        private void setControl(bool check)
        {
            txtTenDangNhap.Enabled = check;
            txtMatKhau.Enabled = check;
            cboNhanVien.Enabled = check;
            cboVaiTro.Enabled = check;
            chkTrangThai.Enabled = check;
            btnLuu.Enabled = check;
            btnHuy.Enabled = check;
            btnThem.Enabled = !check;
            btnCapNhat.Enabled = !check;
            btnXoa.Enabled = !check;
            dgvTaiKhoan.Enabled = !check;
        }

        // Load dữ liệu tài khoản lên lưới
        private void LoadGridData()
        {
            var data = from tk in db.TaiKhoans
                       join nv in db.NhanViens on tk.MaNhanVien equals nv.MaNhanVien
                       select new
                       {
                           tk.MaTaiKhoan,
                           tk.TenDangNhap,
                           HoTen = nv.HoTen,
                           tk.VaiTro,
                           tk.TrangThai,
                           tk.LanDangNhapCuoi,
                           tk.NgayTao
                       };
            dgvTaiKhoan.DataSource = data.ToList();
        }

        // Load danh sách nhân viên vào combobox
        private void LoadNhanVien()
        {
            var dsNV = from nv in db.NhanViens
                       where nv.TrangThai == true
                       orderby nv.HoTen
                       select nv;
            cboNhanVien.DataSource = dsNV.ToList();
            cboNhanVien.DisplayMember = "HoTen";
            cboNhanVien.ValueMember = "MaNhanVien";
        }

        private void frmTaiKhoan_Load(object sender, EventArgs e)
        {
            setControl(false);
            LoadNhanVien();
            cboVaiTro.SelectedIndex = 2; // Nhân Viên
            LoadGridData();
        }

        // Sự kiện khi click vào ô trong lưới → đọc dữ liệu lên form
        private void dgvTaiKhoan_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            if (i < 0) return;

            txtMaTaiKhoan.Text = dgvTaiKhoan.Rows[i].Cells["MaTaiKhoan"].Value.ToString();
            txtTenDangNhap.Text = dgvTaiKhoan.Rows[i].Cells["TenDangNhap"].Value.ToString();
            txtMatKhau.Text = ""; // Không hiện mật khẩu

            cboNhanVien.Text = dgvTaiKhoan.Rows[i].Cells["HoTen"].Value.ToString();
            cboVaiTro.Text = dgvTaiKhoan.Rows[i].Cells["VaiTro"].Value.ToString();

            if (dgvTaiKhoan.Rows[i].Cells["TrangThai"].Value != null)
            {
                chkTrangThai.Checked = (bool)dgvTaiKhoan.Rows[i].Cells["TrangThai"].Value;
                chkTrangThai.Text = chkTrangThai.Checked ? "Tài khoản đang mở" : "Tài khoản đã đóng";
            }
        }

        // Nút Thêm mới → bật chế độ thêm
        private void btnThem_Click(object sender, EventArgs e)
        {
            AddNew = true;
            setControl(true);
            txtMaTaiKhoan.Clear();
            txtTenDangNhap.Clear();
            txtMatKhau.Clear();
            cboVaiTro.SelectedIndex = 2;
            chkTrangThai.Checked = true;
            chkTrangThai.Text = "Tài khoản đang mở";
            txtTenDangNhap.Focus();
        }

        // Nút Sửa → bật chế độ sửa
        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (txtMaTaiKhoan.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng chọn tài khoản cần sửa!", "Thông báo");
                return;
            }
            AddNew = false;
            setControl(true);
            txtTenDangNhap.Enabled = false; // Không cho sửa tên đăng nhập
            txtMatKhau.Focus();
        }

        // Nút Không lưu → hủy chế độ thêm/sửa
        private void btnHuy_Click(object sender, EventArgs e)
        {
            setControl(false);
            // Lấy lại thông tin từ lưới lên các TextBox
            if (dgvTaiKhoan.CurrentRow != null)
            {
                int rowIndex = dgvTaiKhoan.CurrentRow.Index;
                int colIndex = dgvTaiKhoan.CurrentCell.ColumnIndex;
                DataGridViewCellEventArgs args = new DataGridViewCellEventArgs(colIndex, rowIndex);
                dgvTaiKhoan_CellEnter(dgvTaiKhoan, args);
            }
        }

        // Nút Lưu → lưu thêm mới hoặc sửa
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtTenDangNhap.Text.Trim() == "")
            {
                MessageBox.Show("Thông tin tên sử dụng không được để trống!", "Thông báo");
                txtTenDangNhap.Focus();
                return;
            }

            if (AddNew) // Trường hợp thêm mới
            {
                if (txtMatKhau.Text.Trim() == "")
                {
                    MessageBox.Show("Mật khẩu không được để trống!", "Thông báo");
                    txtMatKhau.Focus();
                    return;
                }

                // Kiểm tra trùng tên đăng nhập
                string inputUsername = txtTenDangNhap.Text.Trim();
                bool isExisted = db.TaiKhoans.Any(t => t.TenDangNhap == inputUsername);
                if (isExisted)
                {
                    MessageBox.Show("Tên đăng nhập này đã tồn tại! Vui lòng chọn tên khác.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTenDangNhap.Focus();
                    return;
                }

                // Thêm mới
                TaiKhoan newTK = new TaiKhoan
                {
                    MaNhanVien = (int)cboNhanVien.SelectedValue,
                    TenDangNhap = inputUsername,
                    MatKhau = GetMD5(txtMatKhau.Text.Trim()),
                    VaiTro = cboVaiTro.SelectedItem.ToString(),
                    TrangThai = chkTrangThai.Checked,
                    NgayTao = DateTime.Now
                };
                db.TaiKhoans.Add(newTK);
                db.SaveChanges();
                MessageBox.Show("Thêm tài khoản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadGridData();
            }
            else // Trường hợp sửa
            {
                if (txtMaTaiKhoan.Text == "") return;
                int id = int.Parse(txtMaTaiKhoan.Text);

                // Tìm đối tượng cần sửa bằng LINQ
                TaiKhoan tkUpdate = db.TaiKhoans.SingleOrDefault(t => t.MaTaiKhoan == id);
                if (tkUpdate != null)
                {
                    tkUpdate.MaNhanVien = (int)cboNhanVien.SelectedValue;
                    tkUpdate.VaiTro = cboVaiTro.SelectedItem.ToString();
                    tkUpdate.TrangThai = chkTrangThai.Checked;

                    // Chỉ đổi mật khẩu nếu có nhập
                    if (txtMatKhau.Text.Trim() != "")
                    {
                        tkUpdate.MatKhau = GetMD5(txtMatKhau.Text.Trim());
                    }

                    db.SaveChanges();
                    MessageBox.Show("Cập nhật tài khoản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadGridData();
                }
            }

            setControl(false);
        }

        // Nút Xóa (Khóa tài khoản)
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvTaiKhoan.CurrentRow == null) return;
            if (txtMaTaiKhoan.Text == "") return;
            int id = int.Parse(txtMaTaiKhoan.Text);

            if (MessageBox.Show("Bạn muốn xóa bản ghi này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Stop) == DialogResult.Yes)
            {
                TaiKhoan tkDelete = db.TaiKhoans.SingleOrDefault(t => t.MaTaiKhoan == id);
                if (tkDelete != null)
                {
                    tkDelete.TrangThai = false; // Khóa tài khoản thay vì xóa
                    db.SaveChanges();
                    LoadGridData();
                    ClearForm();
                }
            }
        }

        // Tìm kiếm
        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtTimKiem.Text.Trim().ToLower();
            if (keyword == "")
            {
                LoadGridData();
                return;
            }

            var data = from tk in db.TaiKhoans
                       join nv in db.NhanViens on tk.MaNhanVien equals nv.MaNhanVien
                       where tk.TenDangNhap.ToLower().Contains(keyword) || nv.HoTen.ToLower().Contains(keyword)
                       select new
                       {
                           tk.MaTaiKhoan,
                           tk.TenDangNhap,
                           HoTen = nv.HoTen,
                           tk.VaiTro,
                           tk.TrangThai,
                           tk.LanDangNhapCuoi,
                           tk.NgayTao
                       };
            dgvTaiKhoan.DataSource = data.ToList();
        }

        private void ClearForm()
        {
            txtMaTaiKhoan.Text = "";
            txtTenDangNhap.Text = "";
            txtMatKhau.Text = "";
            cboVaiTro.SelectedIndex = 2;
            chkTrangThai.Checked = true;
            chkTrangThai.Text = "Tài khoản đang mở";
            dgvTaiKhoan.ClearSelection();
        }
    }
}
