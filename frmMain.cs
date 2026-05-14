using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using HotelManagement.Database;
using HotelManagement.Models;

namespace HotelManagement
{
    public partial class frmMain : Form
    {
        DataContext db = new DataContext();
        private System.Windows.Forms.Timer timerTrangChu;

        public frmMain()
        {
            InitializeComponent();
            menuStripMain.RenderMode = ToolStripRenderMode.Professional;
            menuStripMain.Renderer = new ToolStripProfessionalRenderer(new MainMenuColorTable());
            this.Text = $"🏨 Hotel Manager - {SessionManager.TenNhanVien} ({SessionManager.VaiTro})";
            this.WindowState = FormWindowState.Maximized;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            PhanQuyenMenu();
            LoadDashboard();

            // Tải lại trang sau mỗi 1 phút
            timerTrangChu = new System.Windows.Forms.Timer { Interval = 60000 };
            timerTrangChu.Tick += new EventHandler(timerTrangChu_Tick);
            timerTrangChu.Start();

            lblChaoMung.Text = "Xin chào, " + SessionManager.TenNhanVien + "!  |  " + DateTime.Now.ToString("dddd, dd/MM/yyyy");
        }

        // Dashboard
        private void LoadDashboard()
        {
            try
            {
                int phongTrong = db.Phongs.Count(p => p.TrangThai == "Trống");
                int phongDangDung = db.Phongs.Count(p => p.TrangThai == "Đang sử dụng");
                int phongBaoTri = db.Phongs.Count(p => p.TrangThai == "Bảo trì" || p.TrangThai == "Đang dọn");

                var today = DateTime.Today;
                var tmr = today.AddDays(1);

                int checkInHomNay = db.DatPhongs.Count(dp => dp.NgayNhanPhong >= today && dp.NgayNhanPhong < tmr && dp.TrangThai == "Đang ở");
                int checkOutHomNay = db.DatPhongs.Count(dp => dp.NgayTraPhong >= today && dp.NgayTraPhong < tmr && dp.TrangThai == "Đã trả");

                decimal doanhThuHomNay = db.HoaDons
                    .Where(hd => hd.TrangThai == "Đã thanh toán" && hd.NgayLap >= today && hd.NgayLap < tmr)
                    .Select(hd => (decimal?)(hd.TienPhong + hd.TienDichVu - hd.GiamGia)).Sum() ?? 0;

                // Update các card thống kê
                SetCard(pnlPhongTrong, "🟢 Phòng Trống", phongTrong.ToString(), Color.FromArgb(39, 174, 96));
                SetCard(pnlPhongDung, "🔴 Đang Sử Dụng", phongDangDung.ToString(), Color.FromArgb(231, 76, 60));
                SetCard(pnlPhongBaoTri, "🟡 Bảo Trì / Dọn Dẹp", phongBaoTri.ToString(), Color.FromArgb(243, 156, 18));
                SetCard(pnlCheckIn, "📥 Check-In Hôm Nay", checkInHomNay.ToString(), Color.FromArgb(52, 152, 219));
                SetCard(pnlCheckOut, "📤 Check-Out Hôm Nay", checkOutHomNay.ToString(), Color.FromArgb(155, 89, 182));
                SetCard(pnlDoanhThu, "💰 Doanh Thu Hôm Nay", $"{doanhThuHomNay:N0} đ", Color.FromArgb(0, 120, 212));

                lblCapNhat.Text = $"Cập nhật lúc: {DateTime.Now:HH:mm:ss}";
            }
            catch (Exception ex)
            {
                lblCapNhat.Text = $"Lỗi load dashboard: {ex.Message}";
            }
        }

        private void SetCard(Panel panel, string title, string value, Color color)
        {
            panel.BackColor = color;
            if (panel.Controls.Count >= 2)
            {
                ((Label)panel.Controls[0]).Text = title;
                ((Label)panel.Controls[1]).Text = value;
            }
        }

        // Phân quyền menu
        private void PhanQuyenMenu()
        {
            if (mnuNhanVien != null) mnuNhanVien.Visible = true;
            if (mnuTaiKhoan != null) mnuTaiKhoan.Visible = true;
            if (mnuBaoCao != null) mnuBaoCao.Visible = true;
        }

        // Các sự kiện menu
        private void MoForm<T>() where T : Form, new()
        {
            // Xem form nào đang mở
            foreach (Form f in this.MdiChildren)
                if (f is T) { f.Activate(); return; }

            var frm = new T();
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void mnuQuanLyPhong_Click(object s, EventArgs e)
        {
            MoForm<frmQuanLyPhong>();
        }

        private void mnuDatPhong_Click(object s, EventArgs e)
        {
            MoForm<frmDatPhong>();
        }

        private void mnuCheckIn_Click(object s, EventArgs e)
        {
            MoForm<frmCheckIn>();
        }

        private void mnuCheckOut_Click(object s, EventArgs e)
        {
            MoForm<frmCheckOut>();
        }

        private void mnuKhachHang_Click(object s, EventArgs e)
        {
            MoForm<frmKhachHang>();
        }

        private void mnuDichVu_Click(object s, EventArgs e)
        {
            MoForm<frmDichVu>();
        }

        private void mnuGoiDichVu_Click(object s, EventArgs e)
        {
            MoForm<frmGoiDichVu>();
        }

        private void mnuHoaDon_Click(object s, EventArgs e)
        {
            MoForm<frmHoaDon>();
        }

        private void mnuNhanVien_Click(object s, EventArgs e)
        {
            MoForm<frmNhanVien>();
        }

        private void mnuTaiKhoan_Click(object s, EventArgs e)
        {
            MoForm<frmTaiKhoan>();
        }

        private void mnuBaoCao_Click(object s, EventArgs e)
        {
            MoForm<frmBaoCao>();
        }

        private void mnuDoiMatKhau_Click(object s, EventArgs e)
        {
            using (var frm = new frmDoiMatKhau())
            {
                frm.ShowDialog();
            }
        }

        private void mnuDangXuat_Click(object s, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn đăng xuất?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                SessionManager.Clear();
                if (timerTrangChu != null) timerTrangChu.Stop();
                this.Close();
                //new frmDangNhap().Show();
                Application.Exit();
            }
        }

        private void btnRefresh_Click(object s, EventArgs e)
        {
            LoadDashboard();
        }

        private sealed class MainMenuColorTable : ProfessionalColorTable
        {
            public override Color MenuStripGradientBegin => Color.FromArgb(0, 120, 212);
            public override Color MenuStripGradientEnd => Color.FromArgb(0, 120, 212);
            public override Color MenuItemSelected => Color.FromArgb(0, 95, 180);
            public override Color MenuItemBorder => Color.FromArgb(0, 95, 180);
            public override Color MenuItemPressedGradientBegin => Color.FromArgb(0, 95, 180);
            public override Color MenuItemPressedGradientMiddle => Color.FromArgb(0, 95, 180);
            public override Color MenuItemPressedGradientEnd => Color.FromArgb(0, 95, 180);
        }

        private void timerTrangChu_Tick(object sender, EventArgs e)
        {
            LoadDashboard();
        }
    }
}
