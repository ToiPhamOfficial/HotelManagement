using System;
using System.Linq;
using System.Windows.Forms;
using HotelManagement.Database;
using HotelManagement.Models;

namespace HotelManagement
{
    public partial class frmNhanVien : Form
    {
        DataContext db = new DataContext();
        bool AddNew = false;

        public frmNhanVien()
        {
            InitializeComponent();
            dgv.AutoGenerateColumns = false;
            dgv.AllowUserToAddRows = false;
        }

        private void setControl(bool check)
        {
            txtHoTen.Enabled = check;
            txtCCCD.Enabled = check;
            txtSoDienThoai.Enabled = check;
            cboGioiTinh.Enabled = check;
            dtpNgaySinh.Enabled = check;
            txtEmail.Enabled = check;
            txtDiaChi.Enabled = check;
            cboChucVu.Enabled = check;
            dtpNgayVaoLam.Enabled = check;
            txtLuongCoBan.Enabled = check;
            txtGhiChu.Enabled = check;

            btnLuu.Enabled = check;
            btnHuy.Enabled = check;
            btnThem.Enabled = !check;
            btnCapNhat.Enabled = !check;
            btnXoa.Enabled = !check;
            dgv.Enabled = !check;
        }

        private void LoadGridData()
        {
            var data = from nv in db.NhanViens
                       where nv.TrangThai == true
                       orderby nv.HoTen
                       select new
                       {
                           nv.MaNhanVien,
                           nv.HoTen,
                           nv.CCCD,
                           nv.GioiTinh,
                           nv.NgaySinh,
                           nv.SoDienThoai,
                           nv.Email,
                           nv.DiaChi,
                           nv.ChucVu,
                           nv.LuongCoBan,
                           nv.NgayVaoLam,
                           nv.GhiChu,
                           nv.TrangThai
                       };
            dgv.DataSource = data.ToList();
        }

        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            setControl(false);
            
            cboGioiTinh.Items.Clear();
            cboGioiTinh.Items.AddRange(new object[] { "Nam", "Nữ", "Khác" });
            
            cboChucVu.Items.Clear();
            cboChucVu.Items.AddRange(new object[] { "Nhân viên", "Lễ tân", "Kế toán", "Quản lý" });
            
            LoadGridData();
        }

        private void dgv_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            if (i < 0) return;

            txtMaNV.Text = dgv.Rows[i].Cells["MaNhanVien"].Value.ToString();
            txtHoTen.Text = dgv.Rows[i].Cells["HoTen"].Value.ToString();
            txtCCCD.Text = dgv.Rows[i].Cells["CCCD"].Value.ToString();
            cboGioiTinh.Text = dgv.Rows[i].Cells["GioiTinh"].Value != null ? dgv.Rows[i].Cells["GioiTinh"].Value.ToString() : "";
            txtSoDienThoai.Text = dgv.Rows[i].Cells["SoDienThoai"].Value.ToString();
            txtEmail.Text = dgv.Rows[i].Cells["Email"].Value != null ? dgv.Rows[i].Cells["Email"].Value.ToString() : "";
            txtDiaChi.Text = dgv.Rows[i].Cells["DiaChi"].Value != null ? dgv.Rows[i].Cells["DiaChi"].Value.ToString() : "";
            cboChucVu.Text = dgv.Rows[i].Cells["ChucVu"].Value != null ? dgv.Rows[i].Cells["ChucVu"].Value.ToString() : "";
            txtGhiChu.Text = dgv.Rows[i].Cells["GhiChu"]?.Value != null ? dgv.Rows[i].Cells["GhiChu"].Value.ToString() : "";

            if (dgv.Rows[i].Cells["NgaySinh"].Value != null && dgv.Rows[i].Cells["NgaySinh"].Value != DBNull.Value)
            {
                dtpNgaySinh.Value = Convert.ToDateTime(dgv.Rows[i].Cells["NgaySinh"].Value);
            }

            if (dgv.Rows[i].Cells["NgayVaoLam"].Value != null && dgv.Rows[i].Cells["NgayVaoLam"].Value != DBNull.Value)
            {
                dtpNgayVaoLam.Value = Convert.ToDateTime(dgv.Rows[i].Cells["NgayVaoLam"].Value);
            }

            decimal luongCB = 0;
            if (dgv.Rows[i].Cells["LuongCoBan"].Value != null && decimal.TryParse(dgv.Rows[i].Cells["LuongCoBan"].Value.ToString(), out luongCB))
            {
                txtLuongCoBan.Text = luongCB.ToString("N0");
            }
            else
            {
                txtLuongCoBan.Text = "0";
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            AddNew = true;
            setControl(true);
            txtMaNV.Clear();
            txtHoTen.Clear();
            txtCCCD.Clear();
            txtSoDienThoai.Clear();
            cboGioiTinh.SelectedIndex = 0;
            dtpNgaySinh.Value = DateTime.Now.AddYears(-18);
            txtEmail.Clear();
            txtDiaChi.Clear();
            cboChucVu.SelectedIndex = 0;
            dtpNgayVaoLam.Value = DateTime.Now;
            txtLuongCoBan.Clear();
            txtGhiChu.Clear();
            
            txtHoTen.Focus();
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (txtMaNV.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần sửa!", "Thông báo");
                return;
            }
            AddNew = false;
            setControl(true);
            txtCCCD.Enabled = false; // Không cho sửa CCCD
            txtHoTen.Focus();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            setControl(false);
            if (dgv.CurrentRow != null)
            {
                int rowIndex = dgv.CurrentRow.Index;
                int colIndex = dgv.CurrentCell.ColumnIndex;
                DataGridViewCellEventArgs args = new DataGridViewCellEventArgs(colIndex, rowIndex);
                dgv_CellEnter(dgv, args);
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtHoTen.Text.Trim() == "")
            {
                MessageBox.Show("Họ tên không được để trống!", "Thông báo");
                txtHoTen.Focus();
                return;
            }
            if (txtCCCD.Text.Trim() == "")
            {
                MessageBox.Show("CCCD không được để trống!", "Thông báo");
                txtCCCD.Focus();
                return;
            }
            if (txtSoDienThoai.Text.Trim() == "")
            {
                MessageBox.Show("Số điện thoại không được để trống!", "Thông báo");
                txtSoDienThoai.Focus();
                return;
            }

            decimal luongCB = 0;
            if (!string.IsNullOrEmpty(txtLuongCoBan.Text))
            {
                if (!decimal.TryParse(txtLuongCoBan.Text.Replace(",", "").Replace(".", ""), out luongCB) || luongCB < 0)
                {
                    MessageBox.Show("Lương cơ bản không hợp lệ!", "Thông báo");
                    txtLuongCoBan.Focus();
                    return;
                }
            }

            try
            {
                if (AddNew)
                {
                    // Check duplicate CCCD
                    string cccd = txtCCCD.Text.Trim();
                    if (db.NhanViens.Any(x => x.CCCD == cccd))
                    {
                        MessageBox.Show("CCCD này đã tồn tại trong hệ thống!", "Thông báo");
                        txtCCCD.Focus();
                        return;
                    }

                    NhanVien nv = new NhanVien();
                    nv.HoTen = txtHoTen.Text.Trim();
                    nv.CCCD = cccd;
                    nv.SoDienThoai = txtSoDienThoai.Text.Trim();
                    nv.GioiTinh = cboGioiTinh.Text;
                    nv.NgaySinh = dtpNgaySinh.Value.Date;
                    nv.Email = txtEmail.Text.Trim();
                    nv.DiaChi = txtDiaChi.Text.Trim();
                    nv.ChucVu = cboChucVu.Text;
                    nv.NgayVaoLam = dtpNgayVaoLam.Value.Date;
                    nv.LuongCoBan = luongCB;
                    nv.GhiChu = txtGhiChu.Text.Trim();
                    nv.TrangThai = true;

                    db.NhanViens.Add(nv);
                }
                else
                {
                    int ma = int.Parse(txtMaNV.Text);
                    NhanVien nv = db.NhanViens.FirstOrDefault(x => x.MaNhanVien == ma);
                    if (nv != null)
                    {
                        nv.HoTen = txtHoTen.Text.Trim();
                        nv.SoDienThoai = txtSoDienThoai.Text.Trim();
                        nv.GioiTinh = cboGioiTinh.Text;
                        nv.NgaySinh = dtpNgaySinh.Value.Date;
                        nv.Email = txtEmail.Text.Trim();
                        nv.DiaChi = txtDiaChi.Text.Trim();
                        nv.ChucVu = cboChucVu.Text;
                        nv.NgayVaoLam = dtpNgayVaoLam.Value.Date;
                        nv.LuongCoBan = luongCB;
                        nv.GhiChu = txtGhiChu.Text.Trim();
                    }
                }

                db.SaveChanges();
                MessageBox.Show("Lưu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadGridData();
                setControl(false);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtMaNV.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần xóa!", "Thông báo");
                return;
            }

            if (MessageBox.Show("Bạn có chắc chắn muốn xóa nhân viên này không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    int ma = int.Parse(txtMaNV.Text);
                    NhanVien nv = db.NhanViens.FirstOrDefault(x => x.MaNhanVien == ma);
                    if (nv != null)
                    {
                        // Soft delete
                        nv.TrangThai = false;
                        db.SaveChanges();
                        MessageBox.Show("Xóa thành công!", "Thông báo");
                        LoadGridData();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Thông báo");
                }
            }
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtTimKiem.Text.ToLower().Trim();
            var data = from nv in db.NhanViens
                       where nv.TrangThai == true &&
                             (nv.HoTen.ToLower().Contains(keyword) || 
                              nv.CCCD.Contains(keyword) || 
                              nv.SoDienThoai.Contains(keyword))
                       orderby nv.HoTen
                       select new
                       {
                           nv.MaNhanVien,
                           nv.HoTen,
                           nv.CCCD,
                           nv.GioiTinh,
                           nv.NgaySinh,
                           nv.SoDienThoai,
                           nv.Email,
                           nv.DiaChi,
                           nv.ChucVu,
                           nv.LuongCoBan,
                           nv.NgayVaoLam,
                           nv.GhiChu,
                           nv.TrangThai
                       };
            dgv.DataSource = data.ToList();
        }
    }
}
