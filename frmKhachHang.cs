using System;
using System.Linq;
using System.Windows.Forms;
using HotelManagement.Database;
using HotelManagement.Models;

namespace HotelManagement
{
    public partial class frmKhachHang : Form
    {

        DataContext db = new DataContext();
        bool AddNew = false;

        public frmKhachHang()
        {
            InitializeComponent();
            dgv.AutoGenerateColumns = false;
            dgv.AllowUserToAddRows = false;
            this.Load += frmKhachHang_Load;
        }

        // Bật/tắt các control khi ở chế độ thêm/sửa
        private void setControl(bool check)
        {
            txtHoTen.Enabled = check;
            txtCCCD.Enabled = check;
            txtSDT.Enabled = check;
            txtEmail.Enabled = check;
            txtDiaChi.Enabled = check;
            cboGioiTinh.Enabled = check;
            dtpNgaySinh.Enabled = check;
            btnLuu.Enabled = check;
            btnHuy.Enabled = check;
            btnThem.Enabled = !check;
            btnCapNhat.Enabled = !check;
            btnXoa.Enabled = !check;
            dgv.Enabled = !check;
        }

        // Load dữ liệu khách hàng lên lưới
        private void LoadGridData()
        {
            var data = from kh in db.KhachHangs
                       where kh.TrangThai == true
                       orderby kh.HoTen
                       select new
                       {
                           kh.MaKhachHang,
                           kh.HoTen,
                           kh.CCCD,
                           kh.SoDienThoai,
                           kh.Email,
                           kh.GioiTinh,
                           kh.NgaySinh,
                           kh.DiaChi,
                           kh.TrangThai,
                           kh.NgayTao
                       };
            dgv.DataSource = data.ToList();
        }

        private void frmKhachHang_Load(object sender, EventArgs e)
        {
            setControl(false);
            cboGioiTinh.Items.Clear();
            cboGioiTinh.Items.AddRange(new object[] { "Nam", "Nữ", "Khác" });
            LoadGridData();
        }

        // Sự kiện khi click vào ô trong lưới → đọc dữ liệu lên form
        private void dgv_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            if (i < 0) return;

            txtMaKH.Text = dgv.Rows[i].Cells["MaKhachHang"].Value.ToString();
            txtHoTen.Text = dgv.Rows[i].Cells["HoTen"].Value.ToString();
            txtCCCD.Text = dgv.Rows[i].Cells["CCCD"].Value.ToString();
            txtSDT.Text = dgv.Rows[i].Cells["SoDienThoai"].Value.ToString();
            txtEmail.Text = dgv.Rows[i].Cells["Email"].Value != null ? dgv.Rows[i].Cells["Email"].Value.ToString() : "";
            txtDiaChi.Text = dgv.Rows[i].Cells["DiaChi"].Value != null ? dgv.Rows[i].Cells["DiaChi"].Value.ToString() : "";
            cboGioiTinh.Text = dgv.Rows[i].Cells["GioiTinh"].Value != null ? dgv.Rows[i].Cells["GioiTinh"].Value.ToString() : "";

            if (dgv.Rows[i].Cells["NgaySinh"].Value != null && dgv.Rows[i].Cells["NgaySinh"].Value != DBNull.Value)
            {
                dtpNgaySinh.Value = Convert.ToDateTime(dgv.Rows[i].Cells["NgaySinh"].Value);
            }
        }

        // Nút Thêm mới → bật chế độ thêm
        private void btnThem_Click(object sender, EventArgs e)
        {
            AddNew = true;
            setControl(true);
            txtMaKH.Clear();
            txtHoTen.Clear();
            txtCCCD.Clear();
            txtSDT.Clear();
            txtEmail.Clear();
            txtDiaChi.Clear();
            cboGioiTinh.SelectedIndex = 0;
            dtpNgaySinh.Value = DateTime.Now;
            txtHoTen.Focus();
        }

        // Nút Sửa → bật chế độ sửa
        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (txtMaKH.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng chọn khách hàng cần sửa!", "Thông báo");
                return;
            }
            AddNew = false;
            setControl(true);
            txtCCCD.Enabled = false; // Không cho sửa CCCD
            txtHoTen.Focus();
        }

        // Nút Không lưu → hủy chế độ thêm/sửa
        private void btnHuy_Click(object sender, EventArgs e)
        {
            setControl(false);
            // Lấy lại thông tin từ lưới lên các TextBox
            if (dgv.CurrentRow != null)
            {
                int rowIndex = dgv.CurrentRow.Index;
                int colIndex = dgv.CurrentCell.ColumnIndex;
                DataGridViewCellEventArgs args = new DataGridViewCellEventArgs(colIndex, rowIndex);
                dgv_CellEnter(dgv, args);
            }
        }

        // Nút Lưu → lưu thêm mới hoặc sửa
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
            if (txtSDT.Text.Trim() == "")
            {
                MessageBox.Show("Số điện thoại không được để trống!", "Thông báo");
                txtSDT.Focus();
                return;
            }

            if (AddNew) // Trường hợp thêm mới
            {
                // Kiểm tra trùng CCCD
                string cccd = txtCCCD.Text.Trim();
                bool isExisted = db.KhachHangs.Any(kh => kh.CCCD == cccd);
                if (isExisted)
                {
                    MessageBox.Show("CCCD này đã tồn tại trong hệ thống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCCCD.Focus();
                    return;
                }

                // Thêm mới
                KhachHang newKH = new KhachHang
                {
                    HoTen = txtHoTen.Text.Trim(),
                    CCCD = cccd,
                    SoDienThoai = txtSDT.Text.Trim(),
                    Email = txtEmail.Text.Trim(),
                    DiaChi = txtDiaChi.Text.Trim(),
                    GioiTinh = cboGioiTinh.SelectedItem != null ? cboGioiTinh.SelectedItem.ToString() : "",
                    NgaySinh = dtpNgaySinh.Value,
                    NgayTao = DateTime.Now,
                    TrangThai = true
                };
                db.KhachHangs.Add(newKH);
                db.SaveChanges();
                MessageBox.Show("Thêm khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadGridData();
            }
            else // Trường hợp sửa
            {
                if (txtMaKH.Text == "") return;
                int id = int.Parse(txtMaKH.Text);

                // Tìm đối tượng cần sửa bằng LINQ
                KhachHang khUpdate = db.KhachHangs.SingleOrDefault(kh => kh.MaKhachHang == id);
                if (khUpdate != null)
                {
                    khUpdate.HoTen = txtHoTen.Text.Trim();
                    khUpdate.SoDienThoai = txtSDT.Text.Trim();
                    khUpdate.Email = txtEmail.Text.Trim();
                    khUpdate.DiaChi = txtDiaChi.Text.Trim();
                    khUpdate.GioiTinh = cboGioiTinh.SelectedItem != null ? cboGioiTinh.SelectedItem.ToString() : "";
                    khUpdate.NgaySinh = dtpNgaySinh.Value;

                    db.SaveChanges();
                    MessageBox.Show("Cập nhật khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadGridData();
                }
            }

            setControl(false);
        }

        // Nút Xóa (ẩn - đánh dấu TrangThai = false)
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgv.CurrentRow == null) return;
            if (txtMaKH.Text == "") return;
            int id = int.Parse(txtMaKH.Text);

            if (MessageBox.Show("Bạn muốn xóa bản ghi này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Stop) == DialogResult.Yes)
            {
                KhachHang khDelete = db.KhachHangs.SingleOrDefault(kh => kh.MaKhachHang == id);
                if (khDelete != null)
                {
                    khDelete.TrangThai = false;
                    db.SaveChanges();
                    LoadGridData();
                    ClearForm();
                }
            }
        }

        // Nút Làm mới
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ClearForm();
            txtTimKiem.Clear();
            LoadGridData();
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

            var data = from kh in db.KhachHangs
                       where kh.TrangThai == true &&
                             (kh.HoTen.ToLower().Contains(keyword) ||
                              kh.CCCD.Contains(keyword) ||
                              kh.SoDienThoai.Contains(keyword))
                       orderby kh.HoTen
                       select new
                       {
                           kh.MaKhachHang,
                           kh.HoTen,
                           kh.CCCD,
                           kh.SoDienThoai,
                           kh.Email,
                           kh.GioiTinh,
                           kh.NgaySinh,
                           kh.DiaChi,
                           kh.TrangThai,
                           kh.NgayTao
                       };
            dgv.DataSource = data.ToList();
        }



        private void ClearForm()
        {
            txtMaKH.Text = "";
            txtHoTen.Text = "";
            txtCCCD.Text = "";
            txtSDT.Text = "";
            txtEmail.Text = "";
            txtDiaChi.Text = "";
            cboGioiTinh.SelectedIndex = -1;
            dtpNgaySinh.Value = DateTime.Now;
            dgv.ClearSelection();
        }
    }
}
