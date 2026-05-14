using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using HotelManagement.Database;
using HotelManagement.Models;

namespace HotelManagement
{
    public partial class frmGoiDichVu : Form
    {
        DataContext db = new DataContext();

        public frmGoiDichVu()
        {
            InitializeComponent();
            dgv.AutoGenerateColumns = false;
        }

        private void frmGoiDichVu_Load(object sender, EventArgs e)
        {
            LoadPhongs();
            LoadDichVus();
        }

        private void LoadPhongs()
        {
            var danhSachPhong = (from dp in db.DatPhongs
                                 join p in db.Phongs on dp.MaPhong equals p.MaPhong
                                 where dp.TrangThai == "Đang ở"
                                 orderby p.SoPhong
                                 select new
                                 {
                                     MaDatPhong = dp.MaDatPhong,
                                     TenHienThi = "Phòng " + p.SoPhong + " (MĐP: " + dp.MaDatPhong + ")"
                                 }).ToList();

            cboPhong.DataSource = danhSachPhong;
            cboPhong.DisplayMember = "TenHienThi";
            cboPhong.ValueMember = "MaDatPhong";
            cboPhong.SelectedIndex = -1;
        }

        private void LoadDichVus()
        {
            var dsDichVu = db.DichVus.Where(dv => dv.TrangThai == true).ToList();
            cboDichVu.DataSource = dsDichVu;
            cboDichVu.DisplayMember = "TenDichVu";
            cboDichVu.ValueMember = "MaDichVu";
            cboDichVu.SelectedIndex = -1;
            txtDonGia.Clear();
        }

        private void LoadGrid()
        {
            if (cboPhong.SelectedValue == null)
            {
                dgv.DataSource = null;
                lblTongTien.Text = "Tổng tiền dịch vụ: 0đ";
                return;
            }

            int maDatPhong;
            if (int.TryParse(cboPhong.SelectedValue.ToString(), out maDatPhong))
            {
                var dsGoiDichVu = (from sd in db.SuDungDichVus
                                   join dv in db.DichVus on sd.MaDichVu equals dv.MaDichVu
                                   where sd.MaDatPhong == maDatPhong
                                   orderby sd.ThoiGianSuDung descending
                                   select new
                                   {
                                       sd.MaSuDung,
                                       TenDichVu = dv.TenDichVu,
                                       sd.DonGia,
                                       sd.SoLuong,
                                       ThanhTien = (decimal)sd.SoLuong * sd.DonGia,
                                       sd.ThoiGianSuDung,
                                       sd.GhiChu
                                   }).ToList();

                dgv.DataSource = dsGoiDichVu;

                decimal tongTien = dsGoiDichVu.Sum(x => x.ThanhTien);
                lblTongTien.Text = $"Tổng tiền dịch vụ: {tongTien:N0}đ";
            }
        }

        private void cboPhong_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadGrid();
        }

        private void cboDichVu_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboDichVu.SelectedValue != null && cboDichVu.SelectedItem is DichVu dv)
            {
                txtDonGia.Text = dv.DonGia.ToString("N0");
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (cboPhong.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn phòng đang ở!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cboDichVu.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn dịch vụ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int maDatPhong = (int)cboPhong.SelectedValue;
            int maDichVu = (int)cboDichVu.SelectedValue;
            int soLuong = (int)numSoLuong.Value;
            decimal donGia = ((DichVu)cboDichVu.SelectedItem).DonGia;
            string ghiChu = txtGhiChu.Text.Trim();

            int maNhanVien = SessionManager.MaNhanVien;

            try
            {
                SuDungDichVu sd = new SuDungDichVu
                {
                    MaDatPhong = maDatPhong,
                    MaDichVu = maDichVu,
                    SoLuong = soLuong,
                    DonGia = donGia,
                    ThoiGianSuDung = DateTime.Now,
                    GhiChu = ghiChu,
                    MaNhanVien = maNhanVien
                };

                db.SuDungDichVus.Add(sd);
                db.SaveChanges();

                MessageBox.Show("Thêm dịch vụ thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                numSoLuong.Value = 1;
                txtGhiChu.Clear();
                LoadGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgv.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn dịch vụ đã gọi để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Bạn có chắc chắn muốn hủy dịch vụ này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int maSuDung = (int)dgv.CurrentRow.Cells["MaSuDung"].Value;
                var sd = db.SuDungDichVus.FirstOrDefault(x => x.MaSuDung == maSuDung);
                
                if (sd != null)
                {
                    db.SuDungDichVus.Remove(sd);
                    db.SaveChanges();
                    LoadGrid();
                }
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
