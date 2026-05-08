using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using HotelManagement.Database;
using HotelManagement.Models;

namespace HotelManagement
{
    public partial class frmCheckOut : Form
    {
        DataContext db = new DataContext();

        public frmCheckOut()
        {
            InitializeComponent();
            LoadData();
        }

        private class TienResult
        {
            public decimal TienPhong { get; set; }
            public decimal TienDichVu { get; set; }
        }

        private void LoadData()
        {
            var danhSachDatPhong = (from dp in db.DatPhongs
                                join p in db.Phongs on dp.MaPhong equals p.MaPhong
                                join lp in db.LoaiPhongs on p.MaLoaiPhong equals lp.MaLoaiPhong
                                join kh in db.KhachHangs on dp.MaKhachHang equals kh.MaKhachHang
                                join nv in db.NhanViens on dp.MaNhanVienTao equals nv.MaNhanVien
                                where dp.TrangThai == "Đang ở"
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

            dgvPhong.DataSource = danhSachDatPhong;
        }

        private void LoadDichVuVaTinh()
        {
            if (dgvPhong.CurrentRow == null) return;
            int maDatPhong = Convert.ToInt32(dgvPhong.CurrentRow.Cells["MaDatPhong"].Value);

            var danhSachDichVu = (from sddv in db.SuDungDichVus
                            join dv in db.DichVus on sddv.MaDichVu equals dv.MaDichVu
                            where sddv.MaDatPhong == maDatPhong
                            orderby sddv.ThoiGianSuDung descending
                            select new
                            {
                                sddv.MaSuDung,
                                sddv.MaDatPhong,
                                sddv.MaDichVu,
                                sddv.SoLuong,
                                sddv.DonGia,
                                sddv.ThoiGianSuDung,
                                sddv.GhiChu,
                                sddv.MaNhanVien,
                                TenDichVu = dv.TenDichVu,
                                DonViTinh = dv.DonViTinh
                            }).ToList();

            dgvDV.DataSource = danhSachDichVu;

            var tien = db.Database.SqlQuery<TienResult>("EXEC SP_TinhTienPhong {0}", maDatPhong).FirstOrDefault();

            if (tien != null)
            {
                lblTienPhong.Text = $"Tiền phòng:      {tien.TienPhong:N0} đ";
                lblTienDV.Text = $"Tiền dịch vụ:    {tien.TienDichVu:N0} đ";
                TinhTong();
            }
        }

        private void TinhTong()
        {
            try
            {
                string sp = lblTienPhong.Text.Replace("Tiền phòng:      ", "").Replace(" đ", "").Replace(",", "");
                string sv = lblTienDV.Text.Replace("Tiền dịch vụ:    ", "").Replace(" đ", "").Replace(",", "");
                decimal tp = decimal.Parse(sp.Trim());
                decimal tdv = decimal.Parse(sv.Trim());
                decimal tong = tp + tdv - numGiamGia.Value;
                lblTongCong.Text = $"TỔNG CỘNG: {Math.Max(0, tong):N0} đ";
            }
            catch
            {
            }
        }

        private void DoCheckOut()
        {
            if (dgvPhong.CurrentRow == null)
            {
                MessageBox.Show("Chọn phòng cần check-out!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int maDatPhong = Convert.ToInt32(dgvPhong.CurrentRow.Cells["MaDatPhong"].Value);

            int maHD = TaoHoaDon(maDatPhong, (decimal)numGiamGia.Value);
            if (maHD == 0) return;

            string phuongThuc = "";
            if (cboPhuongThuc.SelectedItem != null)
            {
                phuongThuc = cboPhuongThuc.SelectedItem.ToString();
            }

            bool thanhToanXong = ThanhToan(maHD, phuongThuc);
            if (!thanhToanXong) return;

            bool checkOutXong = CheckOutDatPhong(maDatPhong);
            if (checkOutXong)
            {
                MessageBox.Show("Check-out và thanh toán thành công!\nMã hóa đơn: " + maHD, "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
            }
            else
            {
                MessageBox.Show("Check-out thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int TaoHoaDon(int maDatPhong, decimal giamGia)
        {
            try
            {
                var tien = db.Database.SqlQuery<TienResult>("EXEC SP_TinhTienPhong {0}", maDatPhong).FirstOrDefault();

                if (tien == null)
                {
                    MessageBox.Show("Không tìm thấy đặt phòng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return 0;
                }

                var hd = new HoaDon
                {
                    MaDatPhong = maDatPhong,
                    MaNhanVienTao = SessionManager.MaNhanVien,
                    TienPhong = tien.TienPhong,
                    TienDichVu = tien.TienDichVu,
                    GiamGia = giamGia,
                    PhuongThucTT = "Tiền mặt",
                    TrangThai = "Chưa thanh toán"
                };

                db.HoaDons.Add(hd);
                db.SaveChanges();

                return hd.MaHoaDon;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tạo hóa đơn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

        private bool ThanhToan(int maHoaDon, string phuongThuc)
        {
            if (string.IsNullOrWhiteSpace(phuongThuc))
            {
                MessageBox.Show("Vui lòng chọn phương thức thanh toán!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            try
            {
                var hd = db.HoaDons.Find(maHoaDon);
                if (hd == null)
                {
                    MessageBox.Show("Hóa đơn không tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                hd.TrangThai = "Đã thanh toán";
                hd.PhuongThucTT = phuongThuc;
                db.SaveChanges();
                return true;
            }
            catch
            {
                MessageBox.Show("Thanh toán thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private bool CheckOutDatPhong(int maDatPhong)
        {
            using (var tran = db.Database.BeginTransaction())
            {
                try
                {
                    var dp = db.DatPhongs.Find(maDatPhong);
                    if (dp != null)
                    {
                        dp.TrangThai = "Đã trả";
                        dp.NgayTraPhong = DateTime.Now;

                        var p = db.Phongs.Find(dp.MaPhong);
                        if (p != null) p.TrangThai = "Đang dọn";

                        db.SaveChanges();
                        tran.Commit();
                        return true;
                    }
                    return false;
                }
                catch
                {
                    tran.Rollback();
                    return false;
                }
            }
        }

        private void dgvPhong_SelectionChanged(object sender, EventArgs e)
        {
            LoadDichVuVaTinh();
        }

        private void numGiamGia_ValueChanged(object sender, EventArgs e)
        {
            TinhTong();
        }

        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            DoCheckOut();
        }
    }
}
