using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using HotelManagement.Database;
using HotelManagement.Models;

namespace HotelManagement
{
    // Form quản lý phòng và loại phòng
    public partial class frmQuanLyPhong : Form
    {
        private string _locTrangThai = null;
        private List<LoaiPhong> _lstLoaiPhong;
        private bool _isBindingGrid;

        public frmQuanLyPhong()
        {
            InitializeComponent();
        }

        private void frmQuanLyPhong_Load(object sender, EventArgs e)
        {
            LoadLoaiPhong();
            LoadDanhSachPhong();
            SetupPermission();
        }

        private void SetupPermission()
        {
            // Chỉ Admin/QuanLy mới được thêm/xóa
            bool canEdit = SessionManager.IsQuanLy;
            btnThem.Enabled = canEdit;
            btnXoa.Enabled = canEdit;
        }

        // Load dữ liệu
        private void LoadLoaiPhong()
        {
            using (var db = new DataContext())
            {
                cboLoaiPhong.DataSource = null;
                _lstLoaiPhong = db.LoaiPhongs.Where(lp => lp.TrangThai).OrderBy(lp => lp.TenLoai).ToList();
                cboLoaiPhong.DataSource = _lstLoaiPhong;
                cboLoaiPhong.DisplayMember = "TenLoai";
                cboLoaiPhong.ValueMember = "MaLoaiPhong";
                cboLoaiPhong.SelectedIndex = -1;
            }
        }

        private void LoadDanhSachPhong()
        {
            using (var db = new DataContext())
            {
                var query = from p in db.Phongs
                            join lp in db.LoaiPhongs on p.MaLoaiPhong equals lp.MaLoaiPhong
                            where string.IsNullOrEmpty(_locTrangThai) || p.TrangThai == _locTrangThai
                            orderby p.Tang, p.SoPhong
                            select new
                            {
                                p.MaPhong,
                                p.SoPhong,
                                p.Tang,
                                p.MaLoaiPhong,
                                p.TrangThai,
                                p.MoTa,
                                p.HinhAnh,
                                TenLoai = lp.TenLoai,
                                lp.GiaMoiDem,
                                lp.GiaMoiGio,
                                lp.SoNguoiToiDa
                            };

                var list = query.ToList();
                _isBindingGrid = true;
                dgvPhong.DataSource = list;
                _isBindingGrid = false;
                FormatGrid();
                lblTongPhong.Text = $"Tổng: {list.Count} phòng";
            }
        }

        private void FormatGrid()
        {
            if (dgvPhong.Columns.Count == 0) return;

            if (dgvPhong.Columns.Contains("MaPhong")) dgvPhong.Columns["MaPhong"].Visible = false;
            if (dgvPhong.Columns.Contains("MaLoaiPhong")) dgvPhong.Columns["MaLoaiPhong"].Visible = false;
            if (dgvPhong.Columns.Contains("HinhAnh")) dgvPhong.Columns["HinhAnh"].Visible = false;

            SetColHeader("SoPhong", "Số Phòng", 80);
            SetColHeader("Tang", "Tầng", 60);
            SetColHeader("TenLoai", "Loại Phòng", 150);
            SetColHeader("GiaMoiDem", "Giá/Đêm", 110);
            SetColHeader("GiaMoiGio", "Giá/Giờ", 100);
            SetColHeader("SoNguoiToiDa", "Sức Chứa", 80);
            SetColHeader("TrangThai", "Trạng Thái", 120);
            SetColHeader("MoTa", "Mô Tả", 200);

            // Format tiền
            if (dgvPhong.Columns.Contains("GiaMoiDem")) dgvPhong.Columns["GiaMoiDem"].DefaultCellStyle.Format = "N0";
            if (dgvPhong.Columns.Contains("GiaMoiGio")) dgvPhong.Columns["GiaMoiGio"].DefaultCellStyle.Format = "N0";

            // Màu theo trạng thái
            foreach (DataGridViewRow row in dgvPhong.Rows)
            {
                string tt = dgvPhong.Columns.Contains("TrangThai")
                    ? row.Cells["TrangThai"].Value?.ToString()
                    : null;
                switch (tt)
                {
                    case "Trống": row.DefaultCellStyle.BackColor = Color.FromArgb(220, 255, 220); break;
                    case "Đang sử dụng": row.DefaultCellStyle.BackColor = Color.FromArgb(255, 220, 220); break;
                    case "Đang dọn": row.DefaultCellStyle.BackColor = Color.FromArgb(255, 255, 200); break;
                    case "Bảo trì": row.DefaultCellStyle.BackColor = Color.FromArgb(255, 230, 200); break;
                    default: row.DefaultCellStyle.BackColor = Color.White; break;
                }
            }
        }

        private void SetColHeader(string name, string header, int width)
        {
            if (!dgvPhong.Columns.Contains(name)) return;
            dgvPhong.Columns[name].HeaderText = header;
            dgvPhong.Columns[name].Width = width;
        }

        // Các sự kiện
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!ValidateInput(out Phong p)) return;

            bool ok = ThemPhong(p);
            if (ok) 
            { 
                ClearForm(); 
                LoadDanhSachPhong(); 
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (txtMaPhong.Text == "") { MessageBox.Show("Chọn phòng cần cập nhật!", "Thông báo"); return; }
            if (!ValidateInput(out Phong p)) return;

            p.MaPhong = int.Parse(txtMaPhong.Text);
            bool ok = CapNhatPhong(p);
            if (ok) LoadDanhSachPhong();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtMaPhong.Text == "") { MessageBox.Show("Chọn phòng cần xóa!", "Thông báo"); return; }
            if (MessageBox.Show($"Xóa phòng {txtSoPhong.Text}?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes) return;

            bool ok = XoaPhong(int.Parse(txtMaPhong.Text));
            if (ok) 
            { 
                ClearForm(); 
                LoadDanhSachPhong(); 
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ClearForm();
            cboLocTrangThai.SelectedIndex = 0;
            _locTrangThai = null;
            LoadDanhSachPhong();
        }

        private void cboLocTrangThai_SelectedIndexChanged(object sender, EventArgs e)
        {
            _locTrangThai = cboLocTrangThai.SelectedIndex == 0 ? null : cboLocTrangThai.SelectedItem?.ToString();
            LoadDanhSachPhong();
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtTimKiem.Text.Trim().ToLower();
            if (!dgvPhong.Columns.Contains("SoPhong") && !dgvPhong.Columns.Contains("TenLoai")) return;

            foreach (DataGridViewRow row in dgvPhong.Rows)
            {
                string soPhong = dgvPhong.Columns.Contains("SoPhong")
                    ? row.Cells["SoPhong"].Value?.ToString().ToLower() ?? ""
                    : "";
                string tenLoai = dgvPhong.Columns.Contains("TenLoai")
                    ? row.Cells["TenLoai"].Value?.ToString().ToLower() ?? ""
                    : "";
                row.Visible = soPhong.Contains(keyword) || tenLoai.Contains(keyword);
            }
        }

        private void dgvPhong_SelectionChanged(object sender, EventArgs e)
        {
            if (_isBindingGrid || dgvPhong.CurrentRow == null || dgvPhong.CurrentRow.IsNewRow) return;
            var row = dgvPhong.CurrentRow;

            txtMaPhong.Text = dgvPhong.Columns.Contains("MaPhong") ? row.Cells["MaPhong"].Value?.ToString() : "";
            txtSoPhong.Text = dgvPhong.Columns.Contains("SoPhong") ? row.Cells["SoPhong"].Value?.ToString() : "";

            int tang = 1;
            if (dgvPhong.Columns.Contains("Tang"))
                int.TryParse(row.Cells["Tang"].Value?.ToString(), out tang);
            tang = Math.Max((int)numTang.Minimum, Math.Min((int)numTang.Maximum, tang));
            numTang.Value = tang;

            txtMoTa.Text = dgvPhong.Columns.Contains("MoTa") ? row.Cells["MoTa"].Value?.ToString() : "";

            // Chọn loại phòng
            if (cboLoaiPhong.DataSource is System.Collections.IList list)
            {
                if (dgvPhong.Columns.Contains("MaLoaiPhong"))
                {
                    string maLoai = row.Cells["MaLoaiPhong"].Value?.ToString();
                    cboLoaiPhong.SelectedValue = int.TryParse(maLoai, out int id) ? id : 0;
                }
            }

            // Chọn trạng thái
            if (dgvPhong.Columns.Contains("TrangThai"))
                cboTrangThai.Text = row.Cells["TrangThai"].Value?.ToString();
        }

        private void btnCapNhatTT_Click(object sender, EventArgs e)
        {
            if (txtMaPhong.Text == "") return;
            bool ok = CapNhatTrangThaiPhong(
                int.Parse(txtMaPhong.Text),
                cboTrangThai.SelectedItem?.ToString());
            if (ok) 
            { 
                LoadDanhSachPhong(); 
                MessageBox.Show("Cập nhật trạng thái thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information); 
            }
        }

        private bool ThemPhong(Phong p)
        {
            try
            {
                using (var db = new DataContext())
                {
                    db.Phongs.Add(p);
                    db.SaveChanges();
                    MessageBox.Show($"Thêm phòng {p.SoPhong} thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private bool CapNhatPhong(Phong p)
        {
            try
            {
                using (var db = new DataContext())
                {
                    var exist = db.Phongs.Find(p.MaPhong);
                    if (exist != null)
                    {
                        exist.SoPhong = p.SoPhong;
                        exist.MaLoaiPhong = p.MaLoaiPhong;
                        exist.Tang = p.Tang;
                        exist.TrangThai = p.TrangThai;
                        exist.MoTa = p.MoTa;

                        db.SaveChanges();
                        MessageBox.Show("Cập nhật phòng thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return true;
                    }
                    MessageBox.Show("Không tìm thấy phòng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private bool XoaPhong(int maPhong)
        {
            try
            {
                using (var db = new DataContext())
                {
                    bool inUse = db.DatPhongs.Any(dp => dp.MaPhong == maPhong && dp.TrangThai != "Đã trả" && dp.TrangThai != "Hủy");
                    if (inUse)
                    {
                        MessageBox.Show("Không thể xóa! Phòng đang có đặt phòng chưa hoàn thành.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }

                    var p = db.Phongs.Find(maPhong);
                    if (p != null)
                    {
                        db.Phongs.Remove(p); // Actually remove
                        db.SaveChanges();
                        MessageBox.Show("Xóa phòng thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return true;
                    }
                    MessageBox.Show("Không tìm thấy phòng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private bool CapNhatTrangThaiPhong(int maPhong, string trangThai)
        {
            if (trangThai == null) return false;
            try
            {
                using (var db = new DataContext())
                {
                    var p = db.Phongs.Find(maPhong);
                    if (p != null)
                    {
                        p.TrangThai = trangThai;
                        db.SaveChanges();
                        return true;
                    }
                    return false;
                }
            }
            catch { return false; }
        }

        // Các hàm hỗ trợ
        private bool ValidateInput(out Phong p)
        {
            p = null;
            if (string.IsNullOrWhiteSpace(txtSoPhong.Text))
            { MessageBox.Show("Số phòng không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning); return false; }
            if (!TryGetSelectedMaLoaiPhong(out int maLoaiPhong))
            { MessageBox.Show("Vui lòng chọn loại phòng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning); return false; }

            p = new Phong
            {
                SoPhong = txtSoPhong.Text.Trim().ToUpper(),
                MaLoaiPhong = maLoaiPhong,
                Tang = Convert.ToInt32(numTang.Value),
                TrangThai = cboTrangThai.SelectedItem?.ToString() ?? "Trống",
                MoTa = txtMoTa.Text.Trim()
            };
            return true;
        }

        private bool TryGetSelectedMaLoaiPhong(out int maLoaiPhong)
        {
            maLoaiPhong = 0;

            if (cboLoaiPhong.SelectedValue != null && int.TryParse(cboLoaiPhong.SelectedValue.ToString(), out maLoaiPhong))
                return maLoaiPhong > 0;

            var tenLoai = cboLoaiPhong.Text?.Trim();
            if (string.IsNullOrWhiteSpace(tenLoai) || _lstLoaiPhong == null) return false;

            var match = _lstLoaiPhong.FirstOrDefault(lp => string.Equals(lp.TenLoai?.Trim(), tenLoai, StringComparison.OrdinalIgnoreCase));
            if (match != null)
            {
                maLoaiPhong = match.MaLoaiPhong;
                return true;
            }

            return false;
        }

        private void ClearForm()
        {
            txtMaPhong.Text = "";
            txtSoPhong.Text = "";
            numTang.Value = 1;
            txtMoTa.Text = "";
            cboLoaiPhong.SelectedIndex = -1;
            cboTrangThai.SelectedIndex = 0;
            dgvPhong.ClearSelection();
        }
    }
}
