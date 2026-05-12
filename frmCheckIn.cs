using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using HotelManagement.Database;

namespace HotelManagement
{
    public partial class frmCheckIn : Form
    {
        DataContext db = new DataContext();

        public frmCheckIn()
        {
            InitializeComponent();
            Shown += frmCheckIn_Shown;
            Activated += frmCheckIn_Activated;
        }

        private void frmCheckIn_Shown(object sender, EventArgs e)
        {
            LoadData();
        }

        private void frmCheckIn_Activated(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                var danhSachDatPhong = (from dp in db.DatPhongs
                                        join p in db.Phongs on dp.MaPhong equals p.MaPhong
                                        join lp in db.LoaiPhongs on p.MaLoaiPhong equals lp.MaLoaiPhong
                                        join kh in db.KhachHangs on dp.MaKhachHang equals kh.MaKhachHang
                                        join nv in db.NhanViens on dp.MaNhanVienTao equals nv.MaNhanVien
                                        where dp.TrangThai == "Đã đặt"
                                        orderby dp.NgayNhanPhong
                                        select new
                                        {
                                            dp.MaDatPhong,
                                            dp.MaPhong,
                                            dp.MaKhachHang,
                                            dp.MaNhanVienTao,
                                            dp.NgayDat,
                                            dp.NgayNhanPhong,
                                            dp.NgayTraPhong,
                                            dp.LoaiDat,
                                            dp.GiaPhong,
                                            dp.TrangThai,
                                            dp.GhiChu,
                                            SoPhong = p.SoPhong,
                                            TenLoaiPhong = lp.TenLoai,
                                            TenKhachHang = kh.HoTen,
                                            SoDienThoai = kh.SoDienThoai,
                                            TenNhanVien = nv.HoTen
                                        }).ToList();

                dgv.DataSource = danhSachDatPhong;
                if (dgv.Columns.Contains("MaDatPhong")) dgv.Columns["MaDatPhong"].Width = 60;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không tải được dữ liệu check-in: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DoCheckIn()
        {
            if (dgv.CurrentRow == null) return;
            int id = Convert.ToInt32(dgv.CurrentRow.Cells["MaDatPhong"].Value);

            bool ok = false;
            using (var tran = db.Database.BeginTransaction())
            {
                try
                {
                    var datPhong = db.DatPhongs.Find(id);
                    if (datPhong != null)
                    {
                        datPhong.TrangThai = "Đang ở";
                        var phong = db.Phongs.Find(datPhong.MaPhong);
                        if (phong != null) phong.TrangThai = "Đang sử dụng";

                        db.SaveChanges();
                        tran.Commit();
                        ok = true;
                    }
                    else
                    {
                        tran.Rollback();
                        ok = false;
                    }
                }
                catch
                {
                    tran.Rollback();
                    ok = false;
                }
            }

            if (ok)
            {
                MessageBox.Show("Check-in thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
            }
            else
            {
                MessageBox.Show("Check-in thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCheckIn_Click(object sender, EventArgs e)
        {
            DoCheckIn();
        }
    }
}
