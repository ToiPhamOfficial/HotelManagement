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
            dgvHoaDon.AutoGenerateColumns = false;
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
