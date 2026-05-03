using HotelManagement.Database;
using HotelManagement.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelManagement
{
    public partial class frmTaiKhoan : Form
    {
        DataContext db = new DataContext();
        bool AddNew = false;
        public frmTaiKhoan()
        {
            InitializeComponent();
        }

        // ── Mã hóa mật khẩu MD5 (tương tự GetMD5 trong TH04) ─────
        public string GetMD5(string password)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(password);
                byte[] hashBytes = md5.ComputeHash(inputBytes);
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                    sb.Append(hashBytes[i].ToString("x2"));
                return sb.ToString();
            }
        }

        // ── setContol: bật/tắt điều khiển theo trạng thái ─────────
        private void setContol(bool check)
        {
            txtMaTaiKhoan.Enabled = false;   // Mã TK luôn chỉ đọc
            txtTenDangNhap.Enabled = check;
            txtMatKhau.Enabled = check;
            cboNhanVien.Enabled = check;
            cboVaiTro.Enabled = check;
            chkTrangThai.Enabled = check;

            btnSave.Enabled = check;
            btnCancel.Enabled = check;
            btnAdd.Enabled = !check;
            btnEdit.Enabled = !check;
            btnDelete.Enabled = !check;
            btnExcel.Enabled = !check;
            btnExit.Enabled = !check;
            dgvTaiKhoan.Enabled = !check;
            txtTimKiem.Enabled = !check;
        }

        // ── LoadGridData: nạp dữ liệu lên lưới bằng LINQ ──────────
        private void LoadGridData()
        {
            var data = from tk in db.TaiKhoans
                       join nv in db.NhanViens on tk.MaNhanVien equals nv.MaNhanVien
                       orderby tk.TenDangNhap
                       select new
                       {
                           tk.MaTaiKhoan,
                           tk.TenDangNhap,
                           TenNhanVien = nv.HoTen,
                           nv.ChucVu,
                           tk.VaiTro,
                           tk.TrangThai,
                           tk.LanDangNhapCuoi,
                           tk.NgayTao
                       };
            dgvTaiKhoan.DataSource = data.ToList();
            setContol(false);
            //FormatGrid();
        }

        // ── Load form ──────────────────────────────────────────────
        private void frmTaiKhoan_Load(object sender, EventArgs e)
        {
            dgvTaiKhoan.AutoGenerateColumns = false;
            dgvTaiKhoan.AllowUserToAddRows = false;
            LoadNhanVien();
            LoadGridData();
        }

        // ── Nạp ComboBox nhân viên ─────────────────────────────────
        private void LoadNhanVien()
        {
            var lstNV = db.NhanViens
                .Where(nv => nv.TrangThai)
                .OrderBy(nv => nv.HoTen)
                .ToList();

            cboNhanVien.DataSource = null;
            cboNhanVien.DataSource = lstNV;
            cboNhanVien.DisplayMember = "HoTen";
            cboNhanVien.ValueMember = "MaNhanVien";
            cboNhanVien.SelectedIndex = -1;
        }

        // ── CellEnter: hiển thị dòng được chọn sang các điều khiển
        private void dgvTaiKhoan_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            if (i < 0) return;

            txtMaTaiKhoan.Text = dgvTaiKhoan.Rows[i].Cells["MaTaiKhoan"].Value?.ToString();
            txtTenDangNhap.Text = dgvTaiKhoan.Rows[i].Cells["TenDangNhap"].Value?.ToString();
            txtMatKhau.Text = "";  // Không hiển thị mật khẩu đã hash

            cboVaiTro.Text = dgvTaiKhoan.Rows[i].Cells["VaiTro"].Value?.ToString();

            bool trangThai = false;
            if (bool.TryParse(dgvTaiKhoan.Rows[i].Cells["TrangThai"].Value?.ToString(), out trangThai))
                chkTrangThai.Checked = trangThai;

            // Chọn nhân viên tương ứng
            int maTK = int.Parse(dgvTaiKhoan.Rows[i].Cells["MaTaiKhoan"].Value?.ToString() ?? "0");
            TaiKhoan tk = db.TaiKhoans.SingleOrDefault(x => x.MaTaiKhoan == maTK);
            if (tk != null) cboNhanVien.SelectedValue = tk.MaNhanVien;
        }

        // ── btnThem: chuyển sang chế độ Thêm mới ─────────────────
        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddNew = true;
            setContol(true);
            txtMaTaiKhoan.Clear();
            txtTenDangNhap.Clear();
            txtMatKhau.Clear();
            cboNhanVien.SelectedIndex = -1;
            cboVaiTro.SelectedIndex = 0;
            chkTrangThai.Checked = true;
            txtTenDangNhap.Focus();
        }

        // ── btnCapNhat (= Lưu): lưu Thêm hoặc Sửa ────────────────
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTenDangNhap.Text))
            {
                MessageBox.Show("Tên đăng nhập không được để trống!", "Thông báo");
                txtTenDangNhap.Focus(); return;
            }
            if (AddNew && string.IsNullOrWhiteSpace(txtMatKhau.Text))
            {
                MessageBox.Show("Mật khẩu không được để trống!", "Thông báo");
                txtMatKhau.Focus(); return;
            }
            if (cboNhanVien.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn nhân viên!", "Thông báo");
                cboNhanVien.Focus(); return;
            }

            if (AddNew) // Nếu trước đó bấm Thêm mới
            {
                // Kiểm tra trùng tên đăng nhập
                bool tenDNTonTai = db.TaiKhoans.Any(tk => tk.TenDangNhap == txtTenDangNhap.Text.Trim());
                if (tenDNTonTai)
                {
                    MessageBox.Show("Tên đăng nhập này đã tồn tại! Vui lòng chọn tên khác.",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTenDangNhap.Focus(); return;
                }

                TaiKhoan newTK = new TaiKhoan
                {
                    TenDangNhap = txtTenDangNhap.Text.Trim(),
                    MatKhau = GetMD5(txtMatKhau.Text.Trim()),
                    MaNhanVien = (int)cboNhanVien.SelectedValue,
                    VaiTro = cboVaiTro.SelectedItem?.ToString() ?? "NhanVien",
                    TrangThai = chkTrangThai.Checked,
                    NgayTao = DateTime.Now
                };

                db.TaiKhoans.Add(newTK);
                db.SaveChanges();
                MessageBox.Show("Thêm tài khoản thành công!", "Thành công",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadGridData();
            }
            else // Nếu trước đó bấm Sửa
            {
                if (dgvTaiKhoan.CurrentRow == null) return;
                int id = int.Parse(txtMaTaiKhoan.Text);
                TaiKhoan tk = db.TaiKhoans.SingleOrDefault(x => x.MaTaiKhoan == id);

                if (tk != null)
                {
                    tk.MaNhanVien = (int)cboNhanVien.SelectedValue;
                    tk.VaiTro = cboVaiTro.SelectedItem?.ToString() ?? tk.VaiTro;
                    tk.TrangThai = chkTrangThai.Checked;

                    // Chỉ đổi mật khẩu nếu có nhập
                    if (!string.IsNullOrWhiteSpace(txtMatKhau.Text))
                        tk.MatKhau = GetMD5(txtMatKhau.Text.Trim());

                    db.SaveChanges();
                    MessageBox.Show("Cập nhật tài khoản thành công!", "Thành công",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadGridData();
                }
            }
        }

        // ── btnSua: chuyển sang chế độ Sửa ───────────────────────────
        private void btnEdit_Click(object sender, EventArgs e)
        {
            AddNew = false;
            setContol(true);
            txtTenDangNhap.Focus();
        }

        // ── btnXoa: xóa tài khoản ─────────────────────────────────
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvTaiKhoan.CurrentRow == null) return;

            if (MessageBox.Show("Bạn muốn xóa bản ghi này không?", "Thông báo",
                MessageBoxButtons.YesNo, MessageBoxIcon.Stop) == DialogResult.Yes)
            {
                int id = int.Parse(txtMaTaiKhoan.Text);
                TaiKhoan tk = db.TaiKhoans.SingleOrDefault(x => x.MaTaiKhoan == id);

                if (tk != null)
                {
                    db.TaiKhoans.Remove(tk);
                    db.SaveChanges();
                    LoadGridData();
                }
            }
        }
        // ── btnkhongluu (= Không lưu): hủy, khôi phục ──────────────
        private void btnCancel_Click(object sender, EventArgs e)
        {
            setContol(false);
            if (dgvTaiKhoan.CurrentRow != null)
            {
                int rowIndex = dgvTaiKhoan.CurrentRow.Index;
                int colIndex = dgvTaiKhoan.CurrentCell.ColumnIndex;
                dgvTaiKhoan_CellEnter(dgvTaiKhoan, new DataGridViewCellEventArgs(colIndex, rowIndex));
            }
        }

        // ── Tìm kiếm realtime ─────────────────────────────────────
        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            string kw = txtTimKiem.Text.Trim();
            var data = from tk in db.TaiKhoans
                       join nv in db.NhanViens on tk.MaNhanVien equals nv.MaNhanVien
                       where tk.TenDangNhap.Contains(kw) || nv.HoTen.Contains(kw)
                       orderby tk.TenDangNhap
                       select new
                       {
                           tk.MaTaiKhoan,
                           tk.TenDangNhap,
                           TenNhanVien = nv.HoTen,
                           nv.ChucVu,
                           tk.VaiTro,
                           tk.TrangThai,
                           tk.LanDangNhapCuoi,
                           tk.NgayTao
                       };
            dgvTaiKhoan.DataSource = data.ToList();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn muốn thoát không?", "Thông báo",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                this.Close();
        }

        //// ── Định dạng cột DataGridView ─────────────────────────────
        //private void FormatGrid()
        //{
        //    if (dgvTaiKhoan.Columns.Count == 0) return;
        //    if (dgvTaiKhoan.Columns.Contains("MaTaiKhoan")) dgvTaiKhoan.Columns["MaTaiKhoan"].Visible = false;

        //    SetColHeader("TenDangNhap", "Tên đăng nhập", 140);
        //    SetColHeader("TenNhanVien", "Nhân viên", 160);
        //    SetColHeader("ChucVu", "Chức vụ", 120);
        //    SetColHeader("VaiTro", "Vai trò", 100);
        //    SetColHeader("TrangThai", "Trạng thái", 90);
        //    SetColHeader("LanDangNhapCuoi", "Đăng nhập cuối", 140);
        //    SetColHeader("NgayTao", "Ngày tạo", 120);
        //}

        //private void SetColHeader(string name, string header, int width)
        //{
        //    if (!dgvTaiKhoan.Columns.Contains(name)) return;
        //    dgvTaiKhoan.Columns[name].HeaderText = header;
        //    dgvTaiKhoan.Columns[name].Width = width;
        //}
    }
}
