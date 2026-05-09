using System;
using System.Linq;
using System.Windows.Forms;
using HotelManagement.Database;
using HotelManagement.Models;

namespace HotelManagement
{
    public partial class frmQuanLyPhong : Form
    {

        DataContext db = new DataContext();
        bool AddNew = false;

        public frmQuanLyPhong()
        {
            InitializeComponent();
            this.Load += frmQuanLyPhong_Load;
        }

        // Bật/tắt các control khi ở chế độ thêm/sửa
        private void setControl(bool check)
        {
            txtSoPhong.Enabled = check;
            cboLoaiPhong.Enabled = check;
            numTang.Enabled = check;
            cboTrangThai.Enabled = check;
            txtMoTa.Enabled = check;
            btnLuu.Enabled = check;
            btnHuy.Enabled = check;
            btnThem.Enabled = !check;
            btnCapNhat.Enabled = !check;
            btnXoa.Enabled = !check;
            btnCapNhatTT.Enabled = !check;
            dgvPhong.Enabled = !check;
        }

        // Load dữ liệu danh sách phòng lên lưới
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
                           p.TrangThai,
                           p.MoTa,
                           TenLoai = lp.TenLoai,
                           lp.GiaMoiDem,
                           lp.GiaMoiGio
                       };
            dgvPhong.DataSource = data.ToList();
            FormatGrid();
            lblTongPhong.Text = "Tổng: " + dgvPhong.RowCount + " phòng";
        }

        // Load danh sách loại phòng vào combobox
        private void LoadLoaiPhong()
        {
            var dsLoai = from lp in db.LoaiPhongs
                         where lp.TrangThai == true
                         orderby lp.TenLoai
                         select lp;
            cboLoaiPhong.DataSource = dsLoai.ToList();
            cboLoaiPhong.DisplayMember = "TenLoai";
            cboLoaiPhong.ValueMember = "MaLoaiPhong";
            cboLoaiPhong.SelectedIndex = -1;
        }

        private void frmQuanLyPhong_Load(object sender, EventArgs e)
        {
            setControl(false);
            LoadLoaiPhong();
            LoadGridData();
        }

        // Sự kiện khi click vào ô trong lưới → đọc dữ liệu lên form
        private void dgvPhong_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            if (i < 0) return;

            txtMaPhong.Text = dgvPhong.Rows[i].Cells["MaPhong"].Value.ToString();
            txtSoPhong.Text = dgvPhong.Rows[i].Cells["SoPhong"].Value.ToString();

            int tang = 1;
            int.TryParse(dgvPhong.Rows[i].Cells["Tang"].Value.ToString(), out tang);
            numTang.Value = tang;

            txtMoTa.Text = dgvPhong.Rows[i].Cells["MoTa"].Value != null
                ? dgvPhong.Rows[i].Cells["MoTa"].Value.ToString()
                : "";

            // Chọn loại phòng
            object maLoai = dgvPhong.Rows[i].Cells["MaLoaiPhong"].Value;
            if (maLoai != null)
            {
                cboLoaiPhong.SelectedValue = (int)maLoai;
            }

            // Chọn trạng thái
            cboTrangThai.Text = dgvPhong.Rows[i].Cells["TrangThai"].Value.ToString();
        }

        // Nút Thêm mới → bật chế độ thêm
        private void btnThem_Click(object sender, EventArgs e)
        {
            AddNew = true;
            setControl(true);
            txtMaPhong.Clear();
            txtSoPhong.Clear();
            numTang.Value = 1;
            txtMoTa.Clear();
            cboLoaiPhong.SelectedIndex = 0;
            cboTrangThai.SelectedIndex = 0;
            txtSoPhong.Focus();
        }

        // Nút Sửa → bật chế độ sửa
        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (txtMaPhong.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng chọn phòng cần sửa!", "Thông báo");
                return;
            }
            AddNew = false;
            setControl(true);
            txtSoPhong.Enabled = false; // Không cho sửa số phòng
            cboLoaiPhong.Focus();
        }

        // Nút Không lưu → hủy chế độ thêm/sửa
        private void btnHuy_Click(object sender, EventArgs e)
        {
            setControl(false);
            // Lấy lại thông tin từ lưới lên các TextBox
            if (dgvPhong.CurrentRow != null)
            {
                int rowIndex = dgvPhong.CurrentRow.Index;
                int colIndex = dgvPhong.CurrentCell.ColumnIndex;
                DataGridViewCellEventArgs args = new DataGridViewCellEventArgs(colIndex, rowIndex);
                dgvPhong_CellEnter(dgvPhong, args);
            }
        }

        // Nút Lưu → lưu thêm mới hoặc sửa
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtSoPhong.Text.Trim() == "")
            {
                MessageBox.Show("Số phòng không được để trống!", "Thông báo");
                txtSoPhong.Focus();
                return;
            }
            if (cboLoaiPhong.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn loại phòng!", "Thông báo");
                cboLoaiPhong.Focus();
                return;
            }

            if (AddNew) // Trường hợp thêm mới
            {
                // Kiểm tra trùng số phòng
                string soPhong = txtSoPhong.Text.Trim().ToUpper();
                bool isExisted = db.Phongs.Any(p => p.SoPhong == soPhong);
                if (isExisted)
                {
                    MessageBox.Show("Số phòng này đã tồn tại! Vui lòng nhập số phòng khác.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSoPhong.Focus();
                    return;
                }

                // Thêm mới
                Phong newPhong = new Phong
                {
                    SoPhong = soPhong,
                    MaLoaiPhong = (int)cboLoaiPhong.SelectedValue,
                    Tang = Convert.ToInt32(numTang.Value),
                    TrangThai = cboTrangThai.SelectedItem != null ? cboTrangThai.SelectedItem.ToString() : "Trống",
                    MoTa = txtMoTa.Text.Trim(),
                    NgayTao = DateTime.Now
                };
                db.Phongs.Add(newPhong);
                db.SaveChanges();
                MessageBox.Show("Thêm phòng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadGridData();
            }
            else // Trường hợp sửa
            {
                if (txtMaPhong.Text == "") return;
                int id = int.Parse(txtMaPhong.Text);

                // Tìm đối tượng cần sửa bằng LINQ
                Phong phongUpdate = db.Phongs.SingleOrDefault(p => p.MaPhong == id);
                if (phongUpdate != null)
                {
                    phongUpdate.MaLoaiPhong = (int)cboLoaiPhong.SelectedValue;
                    phongUpdate.Tang = Convert.ToInt32(numTang.Value);
                    phongUpdate.TrangThai = cboTrangThai.SelectedItem != null ? cboTrangThai.SelectedItem.ToString() : "Trống";
                    phongUpdate.MoTa = txtMoTa.Text.Trim();

                    db.SaveChanges();
                    MessageBox.Show("Cập nhật phòng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadGridData();
                }
            }

            setControl(false);
        }

        // Nút Xóa
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvPhong.CurrentRow == null) return;
            if (txtMaPhong.Text == "") return;
            int id = int.Parse(txtMaPhong.Text);

            if (MessageBox.Show("Bạn muốn xóa phòng này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Stop) == DialogResult.Yes)
            {
                // Kiểm tra phòng có đang sử dụng không
                bool inUse = db.DatPhongs.Any(dp => dp.MaPhong == id && dp.TrangThai != "Đã trả" && dp.TrangThai != "Hủy");
                if (inUse)
                {
                    MessageBox.Show("Không thể xóa! Phòng đang có đặt phòng chưa hoàn thành.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Phong phongDelete = db.Phongs.SingleOrDefault(p => p.MaPhong == id);
                if (phongDelete != null)
                {
                    db.Phongs.Remove(phongDelete);
                    db.SaveChanges();
                    LoadGridData();
                    ClearForm();
                }
            }
        }

        // Nút Cập nhật trạng thái nhanh
        private void btnCapNhatTT_Click(object sender, EventArgs e)
        {
            if (txtMaPhong.Text == "") return;
            int id = int.Parse(txtMaPhong.Text);

            Phong p = db.Phongs.SingleOrDefault(x => x.MaPhong == id);
            if (p != null)
            {
                p.TrangThai = cboTrangThai.SelectedItem != null ? cboTrangThai.SelectedItem.ToString() : p.TrangThai;
                db.SaveChanges();
                LoadGridData();
                MessageBox.Show("Cập nhật trạng thái thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Nút Làm mới
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ClearForm();
            cboLocTrangThai.SelectedIndex = 0;
            LoadGridData();
        }

        // Lọc theo trạng thái
        private void cboLocTrangThai_SelectedIndexChanged(object sender, EventArgs e)
        {
            string loc = cboLocTrangThai.SelectedIndex == 0 ? null : cboLocTrangThai.SelectedItem.ToString();
            var data = from p in db.Phongs
                       join lp in db.LoaiPhongs on p.MaLoaiPhong equals lp.MaLoaiPhong
                       where (loc == null || p.TrangThai == loc)
                       orderby p.Tang, p.SoPhong
                       select new
                       {
                           p.MaPhong,
                           p.SoPhong,
                           p.Tang,
                           p.MaLoaiPhong,
                           p.TrangThai,
                           p.MoTa,
                           TenLoai = lp.TenLoai,
                           lp.GiaMoiDem,
                           lp.GiaMoiGio
                       };
            dgvPhong.DataSource = data.ToList();
            FormatGrid();
            lblTongPhong.Text = "Tổng: " + dgvPhong.RowCount + " phòng";
        }

        // Tìm kiếm
        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtTimKiem.Text.Trim().ToLower();
            foreach (DataGridViewRow row in dgvPhong.Rows)
            {
                string soPhong = row.Cells["SoPhong"].Value != null ? row.Cells["SoPhong"].Value.ToString().ToLower() : "";
                string tenLoai = row.Cells["TenLoai"].Value != null ? row.Cells["TenLoai"].Value.ToString().ToLower() : "";
                row.Visible = soPhong.Contains(keyword) || tenLoai.Contains(keyword);
            }
        }

        // Định dạng lưới
        private void FormatGrid()
        {
            if (dgvPhong.Columns.Count == 0) return;
            if (dgvPhong.Columns.Contains("MaPhong")) dgvPhong.Columns["MaPhong"].Visible = false;
            if (dgvPhong.Columns.Contains("MaLoaiPhong")) dgvPhong.Columns["MaLoaiPhong"].Visible = false;
            if (dgvPhong.Columns.Contains("SoPhong")) { dgvPhong.Columns["SoPhong"].HeaderText = "Số Phòng"; dgvPhong.Columns["SoPhong"].Width = 80; }
            if (dgvPhong.Columns.Contains("Tang")) { dgvPhong.Columns["Tang"].HeaderText = "Tầng"; dgvPhong.Columns["Tang"].Width = 60; }
            if (dgvPhong.Columns.Contains("TenLoai")) { dgvPhong.Columns["TenLoai"].HeaderText = "Loại Phòng"; dgvPhong.Columns["TenLoai"].Width = 150; }
            if (dgvPhong.Columns.Contains("GiaMoiDem")) { dgvPhong.Columns["GiaMoiDem"].HeaderText = "Giá/Đêm"; dgvPhong.Columns["GiaMoiDem"].Width = 110; dgvPhong.Columns["GiaMoiDem"].DefaultCellStyle.Format = "N0"; }
            if (dgvPhong.Columns.Contains("GiaMoiGio")) { dgvPhong.Columns["GiaMoiGio"].HeaderText = "Giá/Giờ"; dgvPhong.Columns["GiaMoiGio"].Width = 100; dgvPhong.Columns["GiaMoiGio"].DefaultCellStyle.Format = "N0"; }
            if (dgvPhong.Columns.Contains("TrangThai")) { dgvPhong.Columns["TrangThai"].HeaderText = "Trạng Thái"; dgvPhong.Columns["TrangThai"].Width = 120; }
            if (dgvPhong.Columns.Contains("MoTa")) { dgvPhong.Columns["MoTa"].HeaderText = "Mô Tả"; dgvPhong.Columns["MoTa"].Width = 200; }
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
