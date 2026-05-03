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

        DataContext db = new DataContext();
        bool AddNew = false;

        public frmQuanLyPhong()
        {
            InitializeComponent();
        }

        // ── setContol: bật/tắt điều khiển theo trạng thái ─────────
        private void setContol(bool check)
        {
            txtMaPhong.Enabled = false;   // Mã phòng luôn chỉ đọc
            txtSoPhong.Enabled = check;
            numTang.Enabled = check;
            cboLoaiPhong.Enabled = check;
            cboTrangThai.Enabled = check;
            txtMoTa.Enabled = check;

            btnSave.Enabled = check;
            btnCancel.Enabled = check;
            btnAdd.Enabled = !check;
            btnEdit.Enabled = !check;
            btnDelete.Enabled = !check;
            btnExcel.Enabled = !check;
            btnExit.Enabled = !check;
            dgvPhong.Enabled = !check;
            txtTimKiem.Enabled = !check;
            cboLocTrangThai.Enabled = !check;
        }

        // ── LoadGridData: nạp dữ liệu lên lưới bằng LINQ ──────────
        private void LoadGridData()
        {
            var data = from p in db.Phongs
                       join lp in db.LoaiPhongs on p.MaLoaiPhong equals lp.MaLoaiPhong
                       orderby p.Tang, p.SoPhong
                       select new
                       {
                           p.MaPhong,
                           p.SoPhong,
                           p.Tang,
                           p.MaLoaiPhong,
                           TenLoai = lp.TenLoai,
                           lp.GiaMoiDem,
                           lp.GiaMoiGio,
                           lp.SoNguoiToiDa,
                           p.TrangThai,
                           p.MoTa
                       };
            dgvPhong.DataSource = data.ToList();
            setContol(false);
            //FormatGrid();
            lblTongPhong.Text = $"Tổng: {dgvPhong.Rows.Count} phòng";
        }

        // ── Load form ──────────────────────────────────────────────
        private void frmQuanLyPhong_Load(object sender, EventArgs e)
        {
            dgvPhong.AutoGenerateColumns = false;
            dgvPhong.AllowUserToAddRows = false;
            LoadLoaiPhong();
            LoadGridData();
        }

        // ── Nạp ComboBox loại phòng ────────────────────────────────
        private void LoadLoaiPhong()
        {
            var lstLoaiPhong = db.LoaiPhongs
                .Where(lp => lp.TrangThai)
                .OrderBy(lp => lp.TenLoai)
                .ToList();

            cboLoaiPhong.DataSource = null;
            cboLoaiPhong.DataSource = lstLoaiPhong;
            cboLoaiPhong.DisplayMember = "TenLoai";
            cboLoaiPhong.ValueMember = "MaLoaiPhong";
            cboLoaiPhong.SelectedIndex = -1;
        }

        // ── CellEnter: hiển thị dòng được chọn sang các điều khiển
        private void dgvPhong_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            if (i < 0) return;

            txtMaPhong.Text = dgvPhong.Rows[i].Cells["MaPhong"].Value?.ToString();
            txtSoPhong.Text = dgvPhong.Rows[i].Cells["SoPhong"].Value?.ToString();
            txtMoTa.Text = dgvPhong.Rows[i].Cells["MoTa"].Value?.ToString();
            cboTrangThai.Text = dgvPhong.Rows[i].Cells["TrangThai"].Value?.ToString();

            if (int.TryParse(dgvPhong.Rows[i].Cells["Tang"].Value?.ToString(), out int tang))
                numTang.Value = Math.Max(numTang.Minimum, Math.Min(numTang.Maximum, tang));

            // Chọn loại phòng theo MaLoaiPhong
            if (int.TryParse(dgvPhong.Rows[i].Cells["MaLoaiPhong"].Value?.ToString(), out int maLoai))
                cboLoaiPhong.SelectedValue = maLoai;
        }

        // ── btnAdd: chuyển sang chế độ Thêm mới ─────────────────
        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddNew = true;
            setContol(true);
            txtMaPhong.Clear();
            txtSoPhong.Clear();
            txtMoTa.Clear();
            numTang.Value = 1;
            cboLoaiPhong.SelectedIndex = -1;
            cboTrangThai.SelectedIndex = 0;
            txtSoPhong.Focus();
        }

        // ── btnSave: lưu  ────────────────
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSoPhong.Text))
            { MessageBox.Show("Số phòng không được để trống!", "Thông báo"); txtSoPhong.Focus(); return; }
            if (cboLoaiPhong.SelectedValue == null)
            { MessageBox.Show("Vui lòng chọn loại phòng!", "Thông báo"); cboLoaiPhong.Focus(); return; }

            int maLoai = (int)cboLoaiPhong.SelectedValue;

            if (AddNew) // Nếu trước đó bấm Thêm mới
            {
                bool soPhongTonTai = db.Phongs.Any(p => p.SoPhong == txtSoPhong.Text.Trim().ToUpper());
                if (soPhongTonTai)
                {
                    MessageBox.Show("Số phòng này đã tồn tại! Vui lòng chọn số phòng khác.",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSoPhong.Focus(); return;
                }

                Phong newPhong = new Phong
                {
                    SoPhong = txtSoPhong.Text.Trim().ToUpper(),
                    MaLoaiPhong = maLoai,
                    Tang = Convert.ToInt32(numTang.Value),
                    TrangThai = cboTrangThai.SelectedItem?.ToString() ?? "Trống",
                    MoTa = txtMoTa.Text.Trim(),
                    NgayTao = DateTime.Now
                };

                db.Phongs.Add(newPhong);
                db.SaveChanges();
                MessageBox.Show($"Thêm phòng {newPhong.SoPhong} thành công!", "Thành công",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadGridData();
            }
            else // Nếu trước đó bấm Sửa
            {
                if (dgvPhong.CurrentRow == null) return;
                int id = int.Parse(txtMaPhong.Text);
                Phong p = db.Phongs.SingleOrDefault(x => x.MaPhong == id);

                if (p != null)
                {
                    p.SoPhong = txtSoPhong.Text.Trim().ToUpper();
                    p.MaLoaiPhong = maLoai;
                    p.Tang = Convert.ToInt32(numTang.Value);
                    p.TrangThai = cboTrangThai.SelectedItem?.ToString() ?? p.TrangThai;
                    p.MoTa = txtMoTa.Text.Trim();

                    db.SaveChanges();
                    MessageBox.Show("Cập nhật phòng thành công!", "Thành công",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadGridData();
                }
            }
        }

        // ── btnXoa: xóa phòng ─────────────────────────────────────
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvPhong.CurrentRow == null) return;
            if (string.IsNullOrEmpty(txtMaPhong.Text)) return;

            if (MessageBox.Show($"Bạn muốn xóa phòng {txtSoPhong.Text} không?", "Thông báo",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                int id = int.Parse(txtMaPhong.Text);

                bool dangSuDung = db.DatPhongs.Any(dp =>
                    dp.MaPhong == id &&
                    dp.TrangThai != "Đã trả" && dp.TrangThai != "Hủy");
                if (dangSuDung)
                {
                    MessageBox.Show("Không thể xóa! Phòng đang có đặt phòng chưa hoàn thành.", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Phong p = db.Phongs.SingleOrDefault(x => x.MaPhong == id);
                if (p != null)
                {
                    db.Phongs.Remove(p);
                    db.SaveChanges();
                    LoadGridData();
                }
            }
        }

        // ── btnCancel (= Không lưu) ──────────────
        private void btnCancel_Click(object sender, EventArgs e)
        {
            setContol(false);
            if (dgvPhong.CurrentRow != null)
            {
                int rowIndex = dgvPhong.CurrentRow.Index;
                int colIndex = dgvPhong.CurrentCell.ColumnIndex;
                DataGridViewCellEventArgs args = new DataGridViewCellEventArgs(colIndex, rowIndex);
                dgvPhong_CellEnter(dgvPhong, args);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            AddNew = false;
            setContol(true);
            txtSoPhong.Enabled = false;
            numTang.Focus();
        }

        // ── btnCapNhatTT: cập nhật nhanh trạng thái phòng ─────────
        private void btnCapNhatTT_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaPhong.Text)) return;
            int id = int.Parse(txtMaPhong.Text);
            Phong p = db.Phongs.SingleOrDefault(x => x.MaPhong == id);
            if (p != null)
            {
                p.TrangThai = cboTrangThai.SelectedItem?.ToString() ?? p.TrangThai;
                db.SaveChanges();
                LoadGridData();
                MessageBox.Show("Cập nhật trạng thái thành công!", "Thành công",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // ── cboLocTrangThai: lọc phòng theo trạng thái ────────────
        private void cboLocTrangThai_SelectedIndexChanged(object sender, EventArgs e)
        {
            string loc = cboLocTrangThai.SelectedIndex == 0 ? null : cboLocTrangThai.SelectedItem?.ToString();

            var data = from p in db.Phongs
                       join lp in db.LoaiPhongs on p.MaLoaiPhong equals lp.MaLoaiPhong
                       where loc == null || p.TrangThai == loc
                       orderby p.Tang, p.SoPhong
                       select new
                       {
                           p.MaPhong,
                           p.SoPhong,
                           p.Tang,
                           p.MaLoaiPhong,
                           TenLoai = lp.TenLoai,
                           lp.GiaMoiDem,
                           lp.GiaMoiGio,
                           lp.SoNguoiToiDa,
                           p.TrangThai,
                           p.MoTa
                       };

            dgvPhong.DataSource = data.ToList();
            //FormatGrid();
            lblTongPhong.Text = $"Tổng: {dgvPhong.Rows.Count} phòng";
        }

        // ── Tìm kiếm realtime ─────────────────────────────────────
        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            string kw = txtTimKiem.Text.Trim().ToLower();
            foreach (DataGridViewRow row in dgvPhong.Rows)
            {
                string soPhong = row.Cells["SoPhong"].Value?.ToString().ToLower() ?? "";
                string tenLoai = row.Cells["TenLoai"].Value?.ToString().ToLower() ?? "";
                row.Visible = soPhong.Contains(kw) || tenLoai.Contains(kw);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn muốn thoát không?", "Thông báo",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                this.Close();
        }

        // ── Định dạng cột DataGridView ─────────────────────────────
        //private void FormatGrid()
        //{
        //    if (dgvPhong.Columns.Count == 0) return;

        //    if (dgvPhong.Columns.Contains("MaPhong")) dgvPhong.Columns["MaPhong"].Visible = false;
        //    if (dgvPhong.Columns.Contains("MaLoaiPhong")) dgvPhong.Columns["MaLoaiPhong"].Visible = false;

        //    SetColHeader("SoPhong", "Số Phòng", 80);
        //    SetColHeader("Tang", "Tầng", 60);
        //    SetColHeader("TenLoai", "Loại Phòng", 150);
        //    SetColHeader("GiaMoiDem", "Giá/Đêm", 110);
        //    SetColHeader("GiaMoiGio", "Giá/Giờ", 100);
        //    SetColHeader("SoNguoiToiDa", "Sức Chứa", 80);
        //    SetColHeader("TrangThai", "Trạng Thái", 120);
        //    SetColHeader("MoTa", "Mô Tả", 200);

        //    if (dgvPhong.Columns.Contains("GiaMoiDem"))
        //        dgvPhong.Columns["GiaMoiDem"].DefaultCellStyle.Format = "N0";
        //    if (dgvPhong.Columns.Contains("GiaMoiGio"))
        //        dgvPhong.Columns["GiaMoiGio"].DefaultCellStyle.Format = "N0";

        //    foreach (DataGridViewRow row in dgvPhong.Rows)
        //    {
        //        string tt = row.Cells["TrangThai"].Value?.ToString();
        //        switch (tt)
        //        {
        //            case "Trống": row.DefaultCellStyle.BackColor = Color.FromArgb(220, 255, 220); break;
        //            case "Đang sử dụng": row.DefaultCellStyle.BackColor = Color.FromArgb(255, 220, 220); break;
        //            case "Đang dọn": row.DefaultCellStyle.BackColor = Color.FromArgb(255, 255, 200); break;
        //            case "Bảo trì": row.DefaultCellStyle.BackColor = Color.FromArgb(255, 230, 200); break;
        //            default: row.DefaultCellStyle.BackColor = Color.White; break;
        //        }
        //    }
        //}

        //private void SetColHeader(string name, string header, int width)
        //{
        //    if (!dgvPhong.Columns.Contains(name)) return;
        //    dgvPhong.Columns[name].HeaderText = header;
        //    dgvPhong.Columns[name].Width = width;
        //}
    }
}