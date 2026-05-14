using System;
using System.Linq;
using System.Windows.Forms;
using HotelManagement.Database;
using HotelManagement.Models;

namespace HotelManagement
{
    public partial class frmDichVu : Form
    {
        DataContext db = new DataContext();
        bool AddNew = false;

        public frmDichVu()
        {
            InitializeComponent();
            dgv.AutoGenerateColumns = false;
            dgv.AllowUserToAddRows = false;
        }

        // Bật/tắt các control khi ở chế độ thêm/sửa
        private void setControl(bool check)
        {
            txtTenDichVu.Enabled = check;
            cboDonViTinh.Enabled = check;
            txtDonGia.Enabled = check;
            cboLoaiDichVu.Enabled = check;
            txtMoTa.Enabled = check;
            btnLuu.Enabled = check;
            btnHuy.Enabled = check;
            btnThem.Enabled = !check;
            btnCapNhat.Enabled = !check;
            btnXoa.Enabled = !check;
            dgv.Enabled = !check;
        }

        // Load dữ liệu dịch vụ lên lưới
        private void LoadGridData()
        {
            var data = from dv in db.DichVus
                       where dv.TrangThai == true
                       orderby dv.TenDichVu
                       select new
                       {
                           dv.MaDichVu,
                           dv.TenDichVu,
                           dv.DonViTinh,
                           dv.DonGia,
                           dv.LoaiDichVu,
                           dv.MoTa,
                           dv.TrangThai
                       };
            dgv.DataSource = data.ToList();
        }

        private void frmDichVu_Load(object sender, EventArgs e)
        {
            setControl(false);
            
            cboDonViTinh.Items.Clear();
            cboDonViTinh.Items.AddRange(new object[] { "Lần", "Người", "Chai", "Kg", "Cái", "Ngày", "Giờ", "Lượt" });
            
            cboLoaiDichVu.Items.Clear();
            cboLoaiDichVu.Items.AddRange(new object[] { "Ăn uống", "Giặt ủi", "Spa", "Vận chuyển", "Tiện ích", "Khác" });
            
            LoadGridData();
        }

        // Sự kiện khi click vào ô trong lưới → đọc dữ liệu lên form
        private void dgv_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            if (i < 0) return;

            txtMaDV.Text = dgv.Rows[i].Cells["MaDichVu"].Value.ToString();
            txtTenDichVu.Text = dgv.Rows[i].Cells["TenDichVu"].Value.ToString();
            cboDonViTinh.Text = dgv.Rows[i].Cells["DonViTinh"].Value != null ? dgv.Rows[i].Cells["DonViTinh"].Value.ToString() : "";
            
            // Format Đơn giá
            decimal donGia = 0;
            if (dgv.Rows[i].Cells["DonGia"].Value != null && decimal.TryParse(dgv.Rows[i].Cells["DonGia"].Value.ToString(), out donGia))
            {
                txtDonGia.Text = donGia.ToString("N0");
            }
            else
            {
                txtDonGia.Text = "0";
            }
            
            cboLoaiDichVu.Text = dgv.Rows[i].Cells["LoaiDichVu"].Value != null ? dgv.Rows[i].Cells["LoaiDichVu"].Value.ToString() : "";
            txtMoTa.Text = dgv.Rows[i].Cells["MoTa"].Value != null ? dgv.Rows[i].Cells["MoTa"].Value.ToString() : "";
        }

        // Nút Thêm mới → bật chế độ thêm
        private void btnThem_Click(object sender, EventArgs e)
        {
            AddNew = true;
            setControl(true);
            txtMaDV.Clear();
            txtTenDichVu.Clear();
            cboDonViTinh.SelectedIndex = 0;
            txtDonGia.Clear();
            cboLoaiDichVu.SelectedIndex = 0;
            txtMoTa.Clear();
            txtTenDichVu.Focus();
        }

        // Nút Sửa → bật chế độ sửa
        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (txtMaDV.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng chọn dịch vụ cần sửa!", "Thông báo");
                return;
            }
            AddNew = false;
            setControl(true);
            txtTenDichVu.Focus();
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
            if (txtTenDichVu.Text.Trim() == "")
            {
                MessageBox.Show("Tên dịch vụ không được để trống!", "Thông báo");
                txtTenDichVu.Focus();
                return;
            }

            string inputTen = txtTenDichVu.Text.Trim();

            // Kiểm tra trùng tên dịch vụ
            if (AddNew)
            {
                bool isExisted = db.DichVus.Any(dv => dv.TenDichVu.ToLower() == inputTen.ToLower() && dv.TrangThai == true);
                if (isExisted)
                {
                    MessageBox.Show("Tên dịch vụ này đã tồn tại! Vui lòng chọn tên khác.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTenDichVu.Focus();
                    return;
                }
            }
            else
            {
                int ma = int.Parse(txtMaDV.Text);
                bool isExisted = db.DichVus.Any(dv => dv.TenDichVu.ToLower() == inputTen.ToLower() && dv.MaDichVu != ma && dv.TrangThai == true);
                if (isExisted)
                {
                    MessageBox.Show("Tên dịch vụ này đã tồn tại! Vui lòng chọn tên khác.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTenDichVu.Focus();
                    return;
                }
            }
            
            decimal donGia = 0;
            if (!decimal.TryParse(txtDonGia.Text.Replace(",", "").Replace(".", ""), out donGia) || donGia < 0)
            {
                MessageBox.Show("Đơn giá không hợp lệ!", "Thông báo");
                txtDonGia.Focus();
                return;
            }

            try
            {
                if (AddNew)
                {
                    // Thêm mới
                    DichVu dv = new DichVu();
                    dv.TenDichVu = txtTenDichVu.Text.Trim();
                    dv.DonViTinh = cboDonViTinh.Text;
                    dv.DonGia = donGia;
                    dv.LoaiDichVu = cboLoaiDichVu.Text;
                    dv.MoTa = txtMoTa.Text.Trim();
                    dv.TrangThai = true;

                    db.DichVus.Add(dv);
                }
                else
                {
                    // Cập nhật
                    int ma = int.Parse(txtMaDV.Text);
                    DichVu dv = db.DichVus.FirstOrDefault(x => x.MaDichVu == ma);
                    if (dv != null)
                    {
                        dv.TenDichVu = txtTenDichVu.Text.Trim();
                        dv.DonViTinh = cboDonViTinh.Text;
                        dv.DonGia = donGia;
                        dv.LoaiDichVu = cboLoaiDichVu.Text;
                        dv.MoTa = txtMoTa.Text.Trim();
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

        // Nút Xóa → xóa (ẩn trạng thái)
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtMaDV.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng chọn dịch vụ cần xóa!", "Thông báo");
                return;
            }

            if (MessageBox.Show("Bạn có chắc chắn muốn xóa dịch vụ này không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    int ma = int.Parse(txtMaDV.Text);
                    DichVu dv = db.DichVus.FirstOrDefault(x => x.MaDichVu == ma);
                    if (dv != null)
                    {
                        // Xóa mềm: đổi trạng thái
                        dv.TrangThai = false;
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

        // Tìm kiếm nhanh
        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtTimKiem.Text.ToLower().Trim();
            var data = from dv in db.DichVus
                       where dv.TrangThai == true &&
                             (dv.TenDichVu.ToLower().Contains(keyword) || 
                              dv.LoaiDichVu.ToLower().Contains(keyword))
                       orderby dv.TenDichVu
                       select new
                       {
                           dv.MaDichVu,
                           dv.TenDichVu,
                           dv.DonViTinh,
                           dv.DonGia,
                           dv.LoaiDichVu,
                           dv.MoTa,
                           dv.TrangThai
                       };
            dgv.DataSource = data.ToList();
        }
    }
}
