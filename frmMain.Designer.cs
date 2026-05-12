using System;
using System.Drawing;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace HotelManagement
{
    public partial class frmMain
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                timerTrangChu?.Stop();
                components?.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            menuStripMain = new MenuStrip();
            mnuQuanLyPhong = new ToolStripMenuItem();
            mnuDatPhong = new ToolStripMenuItem();
            mnuCheckIn = new ToolStripMenuItem();
            mnuCheckOut = new ToolStripMenuItem();
            mnuKhachHang = new ToolStripMenuItem();
            mnuDichVu = new ToolStripMenuItem();
            mnuHoaDon = new ToolStripMenuItem();
            mnuNhanVien = new ToolStripMenuItem();
            mnuTaiKhoan = new ToolStripMenuItem();
            mnuBaoCao = new ToolStripMenuItem();
            pnlHeader = new Panel();
            lblChaoMung = new Label();
            lblCapNhat = new Label();
            btnRefresh = new Button();
            pnlDashboard = new Panel();
            pnlPhongTrong = new Panel();
            lblTitlePhongTrong = new Label();
            lblValuePhongTrong = new Label();
            pnlPhongDung = new Panel();
            lblTitlePhongDung = new Label();
            lblValuePhongDung = new Label();
            pnlPhongBaoTri = new Panel();
            lblTitlePhongBaoTri = new Label();
            lblValuePhongBaoTri = new Label();
            pnlCheckIn = new Panel();
            lblTitleCheckIn = new Label();
            lblValueCheckIn = new Label();
            pnlCheckOut = new Panel();
            lblTitleCheckOut = new Label();
            lblValueCheckOut = new Label();
            pnlDoanhThu = new Panel();
            lblTitleDoanhThu = new Label();
            lblValueDoanhThu = new Label();
            pnlHeader.SuspendLayout();
            menuStripMain.SuspendLayout();
            pnlDashboard.SuspendLayout();
            pnlPhongTrong.SuspendLayout();
            pnlPhongDung.SuspendLayout();
            pnlPhongBaoTri.SuspendLayout();
            pnlCheckIn.SuspendLayout();
            pnlCheckOut.SuspendLayout();
            pnlDoanhThu.SuspendLayout();
            SuspendLayout();
            // 
            // menuStripMain
            // 
            menuStripMain.BackColor = Color.FromArgb(0, 120, 212);
            menuStripMain.Font = new Font("Segoe UI", 10F);
            menuStripMain.ForeColor = Color.White;
            menuStripMain.ImageScalingSize = new Size(20, 20);
            menuStripMain.Items.AddRange(new ToolStripItem[] { mnuQuanLyPhong, mnuKhachHang, mnuDichVu, mnuHoaDon, mnuNhanVien, mnuTaiKhoan, mnuBaoCao });
            menuStripMain.Dock = DockStyle.Top;
            menuStripMain.Location = new Point(0, 130);
            menuStripMain.Name = "menuStripMain";
            menuStripMain.Size = new Size(1280, 27);
            menuStripMain.TabIndex = 1;
            menuStripMain.Text = "menuStripMain";
            // 
            // mnuQuanLyPhong
            // 
            mnuQuanLyPhong.ForeColor = Color.White;
            mnuQuanLyPhong.Text = "Quản Lý Phòng";
            mnuQuanLyPhong.DropDownItems.Add("Danh Sách Phòng", null, mnuQuanLyPhong_Click);
            mnuDatPhong.Text = "Đặt Phòng Mới";
            mnuDatPhong.Click += mnuDatPhong_Click;
            mnuCheckIn.Text = "Check-In";
            mnuCheckIn.Click += mnuCheckIn_Click;
            mnuCheckOut.Text = "Check-Out";
            mnuCheckOut.Click += mnuCheckOut_Click;
            mnuQuanLyPhong.DropDownItems.AddRange(new ToolStripItem[] { mnuDatPhong, mnuCheckIn, mnuCheckOut });
            // 
            // mnuKhachHang
            // 
            mnuKhachHang.ForeColor = Color.White;
            mnuKhachHang.Text = "Khách Hàng";
            mnuKhachHang.DropDownItems.Add("Danh Sách Khách Hàng", null, mnuKhachHang_Click);
            // 
            // mnuDichVu
            // 
            mnuDichVu.ForeColor = Color.White;
            mnuDichVu.Text = "Dịch Vụ";
            mnuDichVu.DropDownItems.Add("Quản Lý Dịch Vụ", null, mnuDichVu_Click);
            // 
            // mnuHoaDon
            // 
            mnuHoaDon.ForeColor = Color.White;
            mnuHoaDon.Text = "Hóa Đơn";
            mnuHoaDon.DropDownItems.Add("Quản Lý Hóa Đơn", null, mnuHoaDon_Click);
            // 
            // mnuNhanVien
            // 
            mnuNhanVien.ForeColor = Color.White;
            mnuNhanVien.Text = "Nhân Viên";
            mnuNhanVien.DropDownItems.Add("Danh Sách Nhân Viên", null, mnuNhanVien_Click);
            // 
            // mnuTaiKhoan
            // 
            mnuTaiKhoan.ForeColor = Color.White;
            mnuTaiKhoan.Text = "Tài Khoản";
            mnuTaiKhoan.DropDownItems.Add("Quản Lý Tài Khoản", null, mnuTaiKhoan_Click);
            mnuTaiKhoan.DropDownItems.Add(new ToolStripSeparator());
            mnuTaiKhoan.DropDownItems.Add("Đổi Mật Khẩu", null, mnuDoiMatKhau_Click);
            mnuTaiKhoan.DropDownItems.Add("Đăng Xuất", null, mnuDangXuat_Click);
            // 
            // mnuBaoCao
            // 
            mnuBaoCao.ForeColor = Color.White;
            mnuBaoCao.Text = "Báo Cáo";
            mnuBaoCao.DropDownItems.Add("Thống Kê Doanh Thu", null, mnuBaoCao_Click);
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.FromArgb(0, 90, 170);
            pnlHeader.Controls.Add(lblChaoMung);
            pnlHeader.Controls.Add(lblCapNhat);
            pnlHeader.Controls.Add(btnRefresh);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 157);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(1280, 50);
            pnlHeader.TabIndex = 3;
            // 
            // lblChaoMung
            // 
            lblChaoMung.AutoSize = true;
            lblChaoMung.Font = new Font("Segoe UI", 11F);
            lblChaoMung.ForeColor = Color.White;
            lblChaoMung.Location = new Point(15, 14);
            lblChaoMung.Name = "lblChaoMung";
            lblChaoMung.Size = new Size(324, 20);
            lblChaoMung.TabIndex = 0;
            lblChaoMung.Text = "Xin chào, Nhân viên!  |  Thứ Bảy, 18/04/2026";
            // 
            // lblCapNhat
            // 
            lblCapNhat.AutoSize = true;
            lblCapNhat.Font = new Font("Segoe UI", 9F);
            lblCapNhat.ForeColor = Color.FromArgb(180, 210, 255);
            lblCapNhat.Location = new Point(700, 16);
            lblCapNhat.Name = "lblCapNhat";
            lblCapNhat.Size = new Size(122, 15);
            lblCapNhat.TabIndex = 1;
            lblCapNhat.Text = "Cập nhật lúc: 13:02:19";
            // 
            // btnRefresh
            // 
            btnRefresh.BackColor = Color.FromArgb(0, 70, 140);
            btnRefresh.Cursor = Cursors.Hand;
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.Font = new Font("Segoe UI", 12F);
            btnRefresh.ForeColor = Color.White;
            btnRefresh.Location = new Point(1000, 10);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(35, 30);
            btnRefresh.TabIndex = 2;
            btnRefresh.Text = "Làm mới";
            btnRefresh.AutoSize = true;
            btnRefresh.UseVisualStyleBackColor = false;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // pnlDashboard
            // 
            pnlDashboard.BackColor = Color.FromArgb(245, 247, 250);
            pnlDashboard.Controls.Add(pnlPhongTrong);
            pnlDashboard.Controls.Add(pnlPhongDung);
            pnlDashboard.Controls.Add(pnlPhongBaoTri);
            pnlDashboard.Controls.Add(pnlCheckIn);
            pnlDashboard.Controls.Add(pnlCheckOut);
            pnlDashboard.Controls.Add(pnlDoanhThu);
            pnlDashboard.Dock = DockStyle.Top;
            pnlDashboard.Location = new Point(0, 0);
            pnlDashboard.Name = "pnlDashboard";
            pnlDashboard.Padding = new Padding(10);
            pnlDashboard.Size = new Size(1280, 130);
            pnlDashboard.TabIndex = 0;
            // 
            // pnlPhongTrong
            // 
            pnlPhongTrong.BackColor = Color.FromArgb(39, 174, 96);
            pnlPhongTrong.Controls.Add(lblTitlePhongTrong);
            pnlPhongTrong.Controls.Add(lblValuePhongTrong);
            pnlPhongTrong.Location = new Point(10, 10);
            pnlPhongTrong.Name = "pnlPhongTrong";
            pnlPhongTrong.Size = new Size(190, 100);
            // 
            // lblTitlePhongTrong
            // 
            lblTitlePhongTrong.AutoSize = true;
            lblTitlePhongTrong.ForeColor = Color.FromArgb(220, 240, 255);
            lblTitlePhongTrong.Font = new Font("Segoe UI", 9F);
            lblTitlePhongTrong.Location = new Point(10, 12);
            lblTitlePhongTrong.Text = "Phòng Trống";
            // 
            // lblValuePhongTrong
            // 
            lblValuePhongTrong.AutoSize = true;
            lblValuePhongTrong.ForeColor = Color.White;
            lblValuePhongTrong.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblValuePhongTrong.Location = new Point(10, 50);
            lblValuePhongTrong.Text = "11";
            // 
            // pnlPhongDung
            // 
            pnlPhongDung.BackColor = Color.FromArgb(231, 76, 60);
            pnlPhongDung.Controls.Add(lblTitlePhongDung);
            pnlPhongDung.Controls.Add(lblValuePhongDung);
            pnlPhongDung.Location = new Point(210, 10);
            pnlPhongDung.Name = "pnlPhongDung";
            pnlPhongDung.Size = new Size(190, 100);
            // 
            // lblTitlePhongDung
            // 
            lblTitlePhongDung.AutoSize = true;
            lblTitlePhongDung.ForeColor = Color.FromArgb(220, 240, 255);
            lblTitlePhongDung.Font = new Font("Segoe UI", 9F);
            lblTitlePhongDung.Location = new Point(10, 12);
            lblTitlePhongDung.Text = "Đang Sử Dụng";
            // 
            // lblValuePhongDung
            // 
            lblValuePhongDung.AutoSize = true;
            lblValuePhongDung.ForeColor = Color.White;
            lblValuePhongDung.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblValuePhongDung.Location = new Point(10, 50);
            lblValuePhongDung.Text = "2";
            // 
            // pnlPhongBaoTri
            // 
            pnlPhongBaoTri.BackColor = Color.FromArgb(243, 156, 18);
            pnlPhongBaoTri.Controls.Add(lblTitlePhongBaoTri);
            pnlPhongBaoTri.Controls.Add(lblValuePhongBaoTri);
            pnlPhongBaoTri.Location = new Point(410, 10);
            pnlPhongBaoTri.Name = "pnlPhongBaoTri";
            pnlPhongBaoTri.Size = new Size(190, 100);
            // 
            // lblTitlePhongBaoTri
            // 
            lblTitlePhongBaoTri.AutoSize = true;
            lblTitlePhongBaoTri.ForeColor = Color.FromArgb(220, 240, 255);
            lblTitlePhongBaoTri.Font = new Font("Segoe UI", 9F);
            lblTitlePhongBaoTri.Location = new Point(10, 12);
            lblTitlePhongBaoTri.Text = "Bảo Trì / Dọn Dẹp";
            // 
            // lblValuePhongBaoTri
            // 
            lblValuePhongBaoTri.AutoSize = true;
            lblValuePhongBaoTri.ForeColor = Color.White;
            lblValuePhongBaoTri.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblValuePhongBaoTri.Location = new Point(10, 50);
            lblValuePhongBaoTri.Text = "1";
            // 
            // pnlCheckIn
            // 
            pnlCheckIn.BackColor = Color.FromArgb(52, 152, 219);
            pnlCheckIn.Controls.Add(lblTitleCheckIn);
            pnlCheckIn.Controls.Add(lblValueCheckIn);
            pnlCheckIn.Location = new Point(610, 10);
            pnlCheckIn.Name = "pnlCheckIn";
            pnlCheckIn.Size = new Size(190, 100);
            // 
            // lblTitleCheckIn
            // 
            lblTitleCheckIn.AutoSize = true;
            lblTitleCheckIn.ForeColor = Color.FromArgb(220, 240, 255);
            lblTitleCheckIn.Font = new Font("Segoe UI", 9F);
            lblTitleCheckIn.Location = new Point(10, 12);
            lblTitleCheckIn.Text = "Check-In Hôm Nay";
            // 
            // lblValueCheckIn
            // 
            lblValueCheckIn.AutoSize = true;
            lblValueCheckIn.ForeColor = Color.White;
            lblValueCheckIn.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblValueCheckIn.Location = new Point(10, 50);
            lblValueCheckIn.Text = "0";
            // 
            // pnlCheckOut
            // 
            pnlCheckOut.BackColor = Color.FromArgb(155, 89, 182);
            pnlCheckOut.Controls.Add(lblTitleCheckOut);
            pnlCheckOut.Controls.Add(lblValueCheckOut);
            pnlCheckOut.Location = new Point(810, 10);
            pnlCheckOut.Name = "pnlCheckOut";
            pnlCheckOut.Size = new Size(190, 100);
            // 
            // lblTitleCheckOut
            // 
            lblTitleCheckOut.AutoSize = true;
            lblTitleCheckOut.ForeColor = Color.FromArgb(220, 240, 255);
            lblTitleCheckOut.Font = new Font("Segoe UI", 9F);
            lblTitleCheckOut.Location = new Point(10, 12);
            lblTitleCheckOut.Text = "Check-Out Hôm Nay";
            // 
            // lblValueCheckOut
            // 
            lblValueCheckOut.AutoSize = true;
            lblValueCheckOut.ForeColor = Color.White;
            lblValueCheckOut.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblValueCheckOut.Location = new Point(10, 50);
            lblValueCheckOut.Text = "0";
            // 
            // pnlDoanhThu
            // 
            pnlDoanhThu.BackColor = Color.FromArgb(0, 120, 212);
            pnlDoanhThu.Controls.Add(lblTitleDoanhThu);
            pnlDoanhThu.Controls.Add(lblValueDoanhThu);
            pnlDoanhThu.Location = new Point(1010, 10);
            pnlDoanhThu.Name = "pnlDoanhThu";
            pnlDoanhThu.Size = new Size(190, 100);
            // 
            // lblTitleDoanhThu
            // 
            lblTitleDoanhThu.AutoSize = true;
            lblTitleDoanhThu.ForeColor = Color.FromArgb(220, 240, 255);
            lblTitleDoanhThu.Font = new Font("Segoe UI", 9F);
            lblTitleDoanhThu.Location = new Point(10, 12);
            lblTitleDoanhThu.Text = "Doanh Thu Hôm Nay";
            // 
            // lblValueDoanhThu
            // 
            lblValueDoanhThu.AutoSize = true;
            lblValueDoanhThu.ForeColor = Color.White;
            lblValueDoanhThu.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblValueDoanhThu.Location = new Point(10, 50);
            lblValueDoanhThu.Text = "0 đ";
            // 
            // frmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 247, 250);
            ClientSize = new Size(1280, 720);
            Controls.Add(pnlHeader);
            Controls.Add(menuStripMain);
            Controls.Add(pnlDashboard);
            MainMenuStrip = menuStripMain;
            Name = "frmMain";
            Text = "Hotel Manager - Admin";
            IsMdiContainer = true;
            Load += frmMain_Load;
            menuStripMain.ResumeLayout(false);
            menuStripMain.PerformLayout();
            pnlDoanhThu.ResumeLayout(false);
            pnlDoanhThu.PerformLayout();
            pnlCheckOut.ResumeLayout(false);
            pnlCheckOut.PerformLayout();
            pnlCheckIn.ResumeLayout(false);
            pnlCheckIn.PerformLayout();
            pnlPhongBaoTri.ResumeLayout(false);
            pnlPhongBaoTri.PerformLayout();
            pnlPhongDung.ResumeLayout(false);
            pnlPhongDung.PerformLayout();
            pnlPhongTrong.ResumeLayout(false);
            pnlPhongTrong.PerformLayout();
            pnlDashboard.ResumeLayout(false);
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }
        private MenuStrip menuStripMain;
        private Panel pnlHeader;
        private Panel pnlDashboard;
        private Button btnRefresh;

        private Label lblTitlePhongTrong;
        private Label lblValuePhongTrong;
        private Label lblTitlePhongDung;
        private Label lblValuePhongDung;
        private Label lblTitlePhongBaoTri;
        private Label lblValuePhongBaoTri;
        private Label lblTitleCheckIn;
        private Label lblValueCheckIn;
        private Label lblTitleCheckOut;
        private Label lblValueCheckOut;
        private Label lblTitleDoanhThu;
        private Label lblValueDoanhThu;

        private Panel pnlPhongTrong;
        private Panel pnlPhongDung;
        private Panel pnlPhongBaoTri;
        private Panel pnlCheckIn;
        private Panel pnlCheckOut;
        private Panel pnlDoanhThu;

        private Label lblChaoMung;
        private Label lblCapNhat;

        private ToolStripMenuItem mnuQuanLyPhong;
        private ToolStripMenuItem mnuKhachHang;
        private ToolStripMenuItem mnuNhanVien;
        private ToolStripMenuItem mnuTaiKhoan;
        private ToolStripMenuItem mnuBaoCao;

        private ToolStripMenuItem mnuDatPhong;
        private ToolStripMenuItem mnuCheckIn;
        private ToolStripMenuItem mnuCheckOut;
        private ToolStripMenuItem mnuDichVu;
        private ToolStripMenuItem mnuHoaDon;
    }
}
