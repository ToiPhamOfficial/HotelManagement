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
        DataContext db = new DataContext();
        bool AddNew = false;
        private readonly bool isDialog;

        public frmKhachHang() : this(false)
        {
        }

        public frmKhachHang(bool isDialog)
        {
            this.isDialog = isDialog;
            InitializeComponent();
        }

        // ── setContol: bật/tắt điều khiển theo trạng thái ─────────
        private void setContol(bool check)
        {
            txtMaKH.Enabled = false;   // Mã KH luôn chỉ đọc
            txtHoTen.Enabled = check;
            txtCCCD.Enabled = check;
            txtSDT.Enabled = check;
            txtEmail.Enabled = check;
            txtDiaChi.Enabled = check;
            cboGioiTinh.Enabled = check;
            dtpNgaySinh.Enabled = check;

            btnSave.Enabled = check;
            btnCancel.Enabled = check;
            btnAdd.Enabled = !check;
            btnEdit.Enabled = !check;
            btnDelete.Enabled = !check;
            btnExcel.Enabled = !check;
            btnExit.Enabled = !check;
            dgv.Enabled = !check;
            txtTimKiem.Enabled = !check;
        }

        // ── LoadGridData: nạp dữ liệu lên lưới bằng LINQ ──────────
        private void LoadGridData()
        {
            var data = from kh in db.KhachHangs
                       where kh.TrangThai
                       orderby kh.HoTen
                       select kh;
            dgv.DataSource = data.ToList();
            setContol(false);
        }

        // ── Load form ──────────────────────────────────────────────
        private void frmKhachHang_Load(object sender, EventArgs e)
        {
            dgv.AutoGenerateColumns = false;
            dgv.AllowUserToAddRows = false;
            LoadGridData();
        }

        // ── CellEnter: hiển thị dòng được chọn sang các TextBox ───
        private void dgv_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            if (i < 0) return;

            txtMaKH.Text = dgv.Rows[i].Cells["MaKhachHang"].Value?.ToString();
            txtHoTen.Text = dgv.Rows[i].Cells["HoTen"].Value?.ToString();
            txtCCCD.Text = dgv.Rows[i].Cells["CCCD"].Value?.ToString();
            txtSDT.Text = dgv.Rows[i].Cells["SoDienThoai"].Value?.ToString();
            txtEmail.Text = dgv.Rows[i].Cells["Email"].Value?.ToString();
            txtDiaChi.Text = dgv.Rows[i].Cells["DiaChi"].Value?.ToString();
            cboGioiTinh.Text = dgv.Rows[i].Cells["GioiTinh"].Value?.ToString();

            if (DateTime.TryParse(dgv.Rows[i].Cells["NgaySinh"].Value?.ToString(), out DateTime ns))
                dtpNgaySinh.Value = ns;
        }

        //private bool ValidateData()
        //{
        //    // 1. Kiểm tra rỗng
        //    if (string.IsNullOrWhiteSpace(txtHoTen.Text))
        //    {
        //        MessageBox.Show("Họ tên khách hàng không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        txtHoTen.Focus();
        //        return false;
        //    }

        //    if (string.IsNullOrWhiteSpace(txtCCCD.Text))
        //    {
        //        MessageBox.Show("CCCD/Hộ chiếu không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        txtCCCD.Focus();
        //        return false;
        //    }

        //    if (string.IsNullOrWhiteSpace(txtSDT.Text))
        //    {
        //        MessageBox.Show("Số điện thoại không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        txtSDT.Focus();
        //        return false;
        //    }

        //    // 2. Kiểm tra định dạng bằng Regex
        //    // CCCD phải là 9 hoặc 12 số (chỉ chứa chữ số)
        //    if (!Regex.IsMatch(txtCCCD.Text.Trim(), @"^\d{9}$|^\d{12}$"))
        //    {
        //        MessageBox.Show("CCCD phải bao gồm đúng 9 hoặc 12 chữ số!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        txtCCCD.Focus();
        //        return false;
        //    }

        //    // SĐT chuẩn Việt Nam (Bắt đầu bằng 03, 05, 07, 08, 09 và có 10 số)
        //    if (!Regex.IsMatch(txtSDT.Text.Trim(), @"^(0[3|5|7|8|9])+([0-9]{8})$"))
        //    {
        //        MessageBox.Show("Số điện thoại không đúng định dạng mạng Việt Nam!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        txtSDT.Focus();
        //        return false;
        //    }

        //    // Email (Cho phép rỗng, nhưng nếu đã nhập thì phải đúng chuẩn ten@domain.com)
        //    if (!string.IsNullOrWhiteSpace(txtEmail.Text) && !Regex.IsMatch(txtEmail.Text.Trim(), @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$"))
        //    {
        //        MessageBox.Show("Email không đúng định dạng (VD: ten@gmail.com)!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        txtEmail.Focus();
        //        return false;
        //    }

        //    return true; // Nếu vượt qua mọi bài kiểm tra trên thì trả về hợp lệ
        //}

        
        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddNew = true;
            setContol(true);
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtHoTen.Text))
            { MessageBox.Show("Họ tên không được để trống!", "Thông báo"); txtHoTen.Focus(); return; }
            if (string.IsNullOrWhiteSpace(txtCCCD.Text))
            { MessageBox.Show("CCCD không được để trống!", "Thông báo"); txtCCCD.Focus(); return; }
            if (string.IsNullOrWhiteSpace(txtSDT.Text))
            { MessageBox.Show("Số điện thoại không được để trống!", "Thông báo"); txtSDT.Focus(); return; }

            if (AddNew) // Nếu trước đó bấm Thêm mới
            {
                bool cccdTonTai = db.KhachHangs.Any(kh => kh.CCCD == txtCCCD.Text.Trim() && kh.TrangThai);
                if (cccdTonTai)
                {
                    MessageBox.Show("CCCD này đã tồn tại! Vui lòng chọn CCCD khác.",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCCCD.Focus();
                    return;
                }

                KhachHang newKH = new KhachHang
                {
                    HoTen = txtHoTen.Text.Trim(),
                    CCCD = txtCCCD.Text.Trim(),
                    SoDienThoai = txtSDT.Text.Trim(),
                    Email = txtEmail.Text.Trim(),
                    DiaChi = txtDiaChi.Text.Trim(),
                    GioiTinh = cboGioiTinh.SelectedItem?.ToString(),
                    NgaySinh = dtpNgaySinh.Value,
                    QuocTich = "Việt Nam",
                    TrangThai = true,
                    NgayTao = DateTime.Now
                };

                db.KhachHangs.Add(newKH);
                db.SaveChanges();
                MessageBox.Show("Thêm khách hàng thành công!", "Thành công",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadGridData();
                if (isDialog) { DialogResult = DialogResult.OK; Close(); }
            }
            else // Nếu trước đó bấm Sửa
            {
                if (dgv.CurrentRow == null) return;
                int id = int.Parse(txtMaKH.Text);
                KhachHang kh = db.KhachHangs.SingleOrDefault(x => x.MaKhachHang == id);

                if (kh != null)
                {
                    kh.HoTen = txtHoTen.Text.Trim();
                    kh.CCCD = txtCCCD.Text.Trim();
                    kh.SoDienThoai = txtSDT.Text.Trim();
                    kh.Email = txtEmail.Text.Trim();
                    kh.DiaChi = txtDiaChi.Text.Trim();
                    kh.GioiTinh = cboGioiTinh.SelectedItem?.ToString();
                    kh.NgaySinh = dtpNgaySinh.Value;

                    db.SaveChanges();
                    MessageBox.Show("Cập nhật khách hàng thành công!", "Thành công",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadGridData();
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            setContol(false);
            // Lấy lại thông tin từ lưới lên các TextBox
            if (dgv.CurrentRow != null)
            {
                int rowIndex = dgv.CurrentRow.Index;
                int colIndex = dgv.CurrentCell.ColumnIndex;
                DataGridViewCellEventArgs args = new DataGridViewCellEventArgs(colIndex, rowIndex);
                dgv_CellEnter(dgv, args);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            AddNew = false;
            setContol(true);
            txtHoTen.Focus();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn muốn xóa bản ghi này không?", "Thông báo",
                MessageBoxButtons.YesNo, MessageBoxIcon.Stop) == DialogResult.Yes)
            {
                int id = int.Parse(txtMaKH.Text);

                bool coDatPhong = db.DatPhongs.Any(dp =>
                    dp.MaKhachHang == id &&
                    dp.TrangThai != "Đã trả" && dp.TrangThai != "Hủy");
                if (coDatPhong)
                {
                    MessageBox.Show("Không thể xóa! Khách hàng đang có đặt phòng.", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                KhachHang kh = db.KhachHangs.SingleOrDefault(x => x.MaKhachHang == id);
                if (kh != null)
                {
                    kh.TrangThai = false;
                    db.SaveChanges();
                    LoadGridData();
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn muốn thoát không?", "Thông báo",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                this.Close();
        }

        // ── Tìm kiếm realtime ─────────────────────────────────────
        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            string kw = txtTimKiem.Text.Trim();
            var data = from kh in db.KhachHangs
                       where kh.TrangThai &&
                             (kh.HoTen.Contains(kw) || kh.CCCD.Contains(kw) || kh.SoDienThoai.Contains(kw))
                       orderby kh.HoTen
                       select kh;
            dgv.DataSource = data.ToList();
        }
    }
}
