using System;
using System.Linq;
using System.Windows.Forms;
using HotelManagement.Database;

namespace HotelManagement
{
    public partial class frmHoaDon : Form
    {
        DataContext db = new DataContext();

        public frmHoaDon()
        {
            InitializeComponent();
        }

        private void frmHoaDon_Load(object sender, EventArgs e)
        {
            dtpTuNgay.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtpDenNgay.Value = DateTime.Now;
            LoadData();
        }

        private void LoadData()
        {
            var tuNgay = dtpTuNgay.Value.Date;
            var denNgay = dtpDenNgay.Value.Date.AddDays(1).AddTicks(-1);
            string keyword = txtTimKiem.Text.Trim().ToLower();

            var data = from hd in db.HoaDons
                       join dp in db.DatPhongs on hd.MaDatPhong equals dp.MaDatPhong
                       join kh in db.KhachHangs on dp.MaKhachHang equals kh.MaKhachHang
                       join nv in db.NhanViens on hd.MaNhanVienTao equals nv.MaNhanVien
                       join p in db.Phongs on dp.MaPhong equals p.MaPhong
                       where hd.NgayLap >= tuNgay && hd.NgayLap <= denNgay
                          && (string.IsNullOrEmpty(keyword) || kh.HoTen.ToLower().Contains(keyword) || kh.CCCD.Contains(keyword))
                       orderby hd.NgayLap descending
                       select new
                       {
                           hd.MaHoaDon,
                           hd.MaDatPhong,
                           SoPhong = p.SoPhong,
                           TenKhachHang = kh.HoTen,
                           NhanVienTao = nv.HoTen,
                           hd.TienPhong,
                           hd.TienDichVu,
                           hd.GiamGia,
                           TongTien = (hd.TienPhong + hd.TienDichVu - hd.GiamGia),
                           hd.PhuongThucTT,
                           hd.TrangThai,
                           hd.NgayLap
                       };

            var list = data.ToList();
            dgvHoaDon.DataSource = list;

            FormatGrid();

            decimal tongDoanhThu = 0;
            foreach (var hd in list)
            {
                if (hd.TrangThai == "Đã thanh toán")
                {
                    tongDoanhThu += hd.TongTien;
                }
            }
            lblTongDoanhThu.Text = $"Tổng Doanh Thu: {tongDoanhThu:N0} VNĐ";
        }

        private void FormatGrid()
        {
            if (dgvHoaDon.Columns.Count == 0) return;
            if (dgvHoaDon.Columns.Contains("MaHoaDon")) { dgvHoaDon.Columns["MaHoaDon"].HeaderText = "Mã HĐ"; dgvHoaDon.Columns["MaHoaDon"].Width = 60; }
            if (dgvHoaDon.Columns.Contains("MaDatPhong")) { dgvHoaDon.Columns["MaDatPhong"].HeaderText = "Mã ĐP"; dgvHoaDon.Columns["MaDatPhong"].Width = 60; }
            if (dgvHoaDon.Columns.Contains("SoPhong")) { dgvHoaDon.Columns["SoPhong"].HeaderText = "Phòng"; dgvHoaDon.Columns["SoPhong"].Width = 60; }
            if (dgvHoaDon.Columns.Contains("TenKhachHang")) { dgvHoaDon.Columns["TenKhachHang"].HeaderText = "Khách Hàng"; dgvHoaDon.Columns["TenKhachHang"].Width = 150; }
            if (dgvHoaDon.Columns.Contains("NhanVienTao")) { dgvHoaDon.Columns["NhanVienTao"].HeaderText = "Nhân Viên"; dgvHoaDon.Columns["NhanVienTao"].Width = 120; }
            if (dgvHoaDon.Columns.Contains("TienPhong")) { dgvHoaDon.Columns["TienPhong"].HeaderText = "Tiền Phòng"; dgvHoaDon.Columns["TienPhong"].Width = 100; dgvHoaDon.Columns["TienPhong"].DefaultCellStyle.Format = "N0"; }
            if (dgvHoaDon.Columns.Contains("TienDichVu")) { dgvHoaDon.Columns["TienDichVu"].HeaderText = "Tiền Dịch Vụ"; dgvHoaDon.Columns["TienDichVu"].Width = 100; dgvHoaDon.Columns["TienDichVu"].DefaultCellStyle.Format = "N0"; }
            if (dgvHoaDon.Columns.Contains("GiamGia")) { dgvHoaDon.Columns["GiamGia"].HeaderText = "Giảm Giá"; dgvHoaDon.Columns["GiamGia"].Width = 80; dgvHoaDon.Columns["GiamGia"].DefaultCellStyle.Format = "N0"; }
            if (dgvHoaDon.Columns.Contains("TongTien")) { dgvHoaDon.Columns["TongTien"].HeaderText = "Tổng Tiền"; dgvHoaDon.Columns["TongTien"].Width = 120; dgvHoaDon.Columns["TongTien"].DefaultCellStyle.Format = "N0"; }
            if (dgvHoaDon.Columns.Contains("PhuongThucTT")) { dgvHoaDon.Columns["PhuongThucTT"].HeaderText = "Phương Thức"; dgvHoaDon.Columns["PhuongThucTT"].Width = 100; }
            if (dgvHoaDon.Columns.Contains("TrangThai")) { dgvHoaDon.Columns["TrangThai"].HeaderText = "Trạng Thái"; dgvHoaDon.Columns["TrangThai"].Width = 120; }
            if (dgvHoaDon.Columns.Contains("NgayLap")) { dgvHoaDon.Columns["NgayLap"].HeaderText = "Ngày Lập"; dgvHoaDon.Columns["NgayLap"].Width = 120; dgvHoaDon.Columns["NgayLap"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm"; }
        }

        private void btnLoc_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtTimKiem.Clear();
            dtpTuNgay.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtpDenNgay.Value = DateTime.Now;
            LoadData();
        }
    }
}
