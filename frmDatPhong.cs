using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using HotelManagement.Database;
using HotelManagement.Models;

namespace HotelManagement
{
    public partial class frmDatPhong : Form
    {
        public frmDatPhong()
        {
            InitializeComponent();
        }

        private void frmDatPhong_Load(object sender, EventArgs e)
        {
            TinhTien();
        }

        private void TimPhongTrong()
        {
            if (dtpNgayNhan.Value >= dtpNgayTra.Value)
            {
                MessageBox.Show("Ngày nhận phải trước ngày trả!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var ngayNhan = dtpNgayNhan.Value;
            var ngayTra = dtpNgayTra.Value;

            using (var db = new DataContext())
            {
                var occupiedPhongIds = db.DatPhongs
                    .Where(dp => dp.TrangThai != "Đã trả" && dp.TrangThai != "Hủy")
                    .Where(dp => !(ngayTra <= dp.NgayNhanPhong || ngayNhan >= dp.NgayTraPhong))
                    .Select(dp => dp.MaPhong)
                    .ToList();

                var danhSachPhong = (from p in db.Phongs
                              join lp in db.LoaiPhongs on p.MaLoaiPhong equals lp.MaLoaiPhong
                              where p.TrangThai == "Trống" && !occupiedPhongIds.Contains(p.MaPhong)
                              orderby p.Tang, p.SoPhong
                              select new
                              {
                                  p.MaPhong,
                                  p.SoPhong,
                                  p.Tang,
                                  lp.TenLoai,
                                  lp.GiaMoiDem,
                                  lp.GiaMoiGio
                              }).ToList();

                dgvPhongTrong.DataSource = danhSachPhong;
                int soNgay = (int)(ngayTra - ngayNhan).TotalDays;
                lblSoNgay.Text = $"Số đêm: {soNgay} | Số phòng trống: {danhSachPhong.Count}";
            }
        }

        private void BtnTimKH_Click(object sender, EventArgs e)
        {
            var keyword = txtTimKH.Text.Trim();
            if (string.IsNullOrWhiteSpace(keyword))
            {
                MessageBox.Show("Vui lòng nhập CCCD hoặc SĐT!", "Thông báo");
                return;
            }

            using (var db = new DataContext())
            {
                var kh = db.KhachHangs.FirstOrDefault(k => k.TrangThai && (k.CCCD == keyword || k.SoDienThoai == keyword));

                if (kh == null)
                {
                    MessageBox.Show("Không tìm thấy khách hàng!", "Thông báo");
                    return;
                }

                txtMaKH.Text = kh.MaKhachHang.ToString();
                txtTenKH.Text = kh.HoTen;
                txtCCCD.Text = kh.CCCD;
                txtSDT.Text = kh.SoDienThoai;
            }
        }

        private void TinhTien()
        {
            if (dgvPhongTrong.CurrentRow == null)
            {
                lblTongTien.Text = "Tổng tiền dự kiến: ---";
                return;
            }

            try
            {
                decimal gia = 0;
                if (rdoTheoNgay.Checked)
                {
                    gia = Convert.ToDecimal(dgvPhongTrong.CurrentRow.Cells["GiaMoiDem"].Value);
                }
                else
                {
                    gia = Convert.ToDecimal(dgvPhongTrong.CurrentRow.Cells["GiaMoiGio"].Value);
                }

                double soLuong = 0;
                if (rdoTheoNgay.Checked)
                {
                    soLuong = (dtpNgayTra.Value - dtpNgayNhan.Value).TotalDays;
                }
                else
                {
                    soLuong = (dtpNgayTra.Value - dtpNgayNhan.Value).TotalHours;
                }

                if (soLuong < 1)
                {
                    soLuong = 1;
                }

                decimal tong = gia * (decimal)soLuong;
                lblTongTien.Text = "Tổng tiền dự kiến: " + tong.ToString("N0") + " VNĐ";
            }
            catch
            {
            }
        }

        private void BtnDatPhong_Click(object sender, EventArgs e)
        {
            if (dgvPhongTrong.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn phòng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(txtMaKH.Text))
            {
                MessageBox.Show("Vui lòng nhập khách hàng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal gia = rdoTheoNgay.Checked
                ? Convert.ToDecimal(dgvPhongTrong.CurrentRow.Cells["GiaMoiDem"].Value)
                : Convert.ToDecimal(dgvPhongTrong.CurrentRow.Cells["GiaMoiGio"].Value);

            var dp = new DatPhong
            {
                MaPhong = Convert.ToInt32(dgvPhongTrong.CurrentRow.Cells["MaPhong"].Value),
                MaKhachHang = int.Parse(txtMaKH.Text),
                MaNhanVienTao = SessionManager.MaNhanVien,
                NgayNhanPhong = dtpNgayNhan.Value,
                NgayTraPhong = dtpNgayTra.Value,
                LoaiDat = rdoTheoNgay.Checked ? "Ngày" : "Giờ",
                GiaPhong = gia
            };

            bool ok = DatPhong(dp);
            if (ok) TimPhongTrong();
        }

        private void btnTimPhong_Click(object sender, EventArgs e) { TimPhongTrong(); }
        private void dtpNgayNhan_ValueChanged(object sender, EventArgs e) { TinhTien(); }
        private void dtpNgayTra_ValueChanged(object sender, EventArgs e) { TinhTien(); }
        private void rdoTheoNgay_CheckedChanged(object sender, EventArgs e) { TinhTien(); }
        private void rdoTheoGio_CheckedChanged(object sender, EventArgs e) { TinhTien(); }
        private void dgvPhongTrong_SelectionChanged(object sender, EventArgs e) { TinhTien(); }
        private void btnDatPhong_Click(object sender, EventArgs e) { BtnDatPhong_Click(sender, e); }
        private void btnTimKH_Click(object sender, EventArgs e) { BtnTimKH_Click(sender, e); }

        private void btnThemKH_Click(object sender, EventArgs e)
        {
            using (var f = new frmKhachHang(true))
            {
                if (f.ShowDialog() == DialogResult.OK)
                {
                }
            }
        }

        private bool DatPhong(DatPhong dp)
        {
            if (dp.MaPhong <= 0) 
            {
                MessageBox.Show("Vui lòng chọn phòng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (dp.MaKhachHang <= 0) 
            {
                MessageBox.Show("Vui lòng chọn khách hàng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (dp.NgayNhanPhong >= dp.NgayTraPhong)
            {
                MessageBox.Show("Ngày nhận phòng phải trước ngày trả phòng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (dp.NgayNhanPhong < DateTime.Now.AddMinutes(-5))
            {
                MessageBox.Show("Ngày nhận phòng không thể là quá khứ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            try
            {
                using (var db = new DataContext())
                {
                    bool isConflict = db.DatPhongs.Any(d =>
                        d.MaPhong == dp.MaPhong &&
                        d.TrangThai != "Đã trả" && d.TrangThai != "Hủy" &&
                        !(dp.NgayTraPhong <= d.NgayNhanPhong || dp.NgayNhanPhong >= d.NgayTraPhong));

                    if (isConflict)
                    {
                        MessageBox.Show("Phòng đã được đặt trong khoảng thời gian này!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }

                    db.DatPhongs.Add(dp);
                    db.SaveChanges();
                    MessageBox.Show("Đặt phòng thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
