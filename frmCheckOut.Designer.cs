using System.Drawing;
using System.Windows.Forms;

namespace HotelManagement
{
    partial class frmCheckOut
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.dgvPhong = new System.Windows.Forms.DataGridView();
            this.MaDatPhong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaPhong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoPhong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenLoaiPhong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenKhachHang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoDienThoai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayNhanPhong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayTraPhong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LoaiDat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GiaPhong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TrangThai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenNhanVien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblP = new System.Windows.Forms.Label();
            this.pnlMid = new System.Windows.Forms.Panel();
            this.dgvDV = new System.Windows.Forms.DataGridView();
            this.MaSuDung = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaDatPhongDV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaDichVu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenDichVu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoLuong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DonViTinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DonGia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ThoiGianSuDung = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GhiChu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaNhanVienDV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblDV = new System.Windows.Forms.Label();
            this.pnlBot = new System.Windows.Forms.Panel();
            this.lblTienPhong = new System.Windows.Forms.Label();
            this.lblTienDV = new System.Windows.Forms.Label();
            this.lblGiamGia = new System.Windows.Forms.Label();
            this.numGiamGia = new System.Windows.Forms.NumericUpDown();
            this.lblTongCong = new System.Windows.Forms.Label();
            this.lblPT = new System.Windows.Forms.Label();
            this.cboPhuongThuc = new System.Windows.Forms.ComboBox();
            this.btnCheckOut = new System.Windows.Forms.Button();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhong)).BeginInit();
            this.pnlMid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDV)).BeginInit();
            this.pnlBot.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numGiamGia)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.dgvPhong);
            this.pnlTop.Controls.Add(this.lblP);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(943, 217);
            this.pnlTop.TabIndex = 0;
            // 
            // dgvPhong
            // 
            this.dgvPhong.AllowUserToAddRows = false;
            this.dgvPhong.BackgroundColor = System.Drawing.Color.White;
            this.dgvPhong.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(212)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 10F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPhong.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvPhong.ColumnHeadersHeight = 40;
            this.dgvPhong.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvPhong.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaDatPhong,
            this.MaPhong,
            this.SoPhong,
            this.TenLoaiPhong,
            this.TenKhachHang,
            this.SoDienThoai,
            this.NgayNhanPhong,
            this.NgayTraPhong,
            this.LoaiDat,
            this.GiaPhong,
            this.TrangThai,
            this.TenNhanVien});
            this.dgvPhong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPhong.EnableHeadersVisualStyles = false;
            this.dgvPhong.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dgvPhong.Location = new System.Drawing.Point(0, 26);
            this.dgvPhong.MultiSelect = false;
            this.dgvPhong.Name = "dgvPhong";
            this.dgvPhong.ReadOnly = true;
            this.dgvPhong.RowHeadersVisible = false;
            this.dgvPhong.RowTemplate.Height = 30;
            this.dgvPhong.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPhong.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPhong.Size = new System.Drawing.Size(943, 191);
            this.dgvPhong.TabIndex = 1;
            this.dgvPhong.SelectionChanged += new System.EventHandler(this.dgvPhong_SelectionChanged);
            // 
            // MaDatPhong
            // 
            this.MaDatPhong.DataPropertyName = "MaDatPhong";
            this.MaDatPhong.HeaderText = "Mã ĐP";
            this.MaDatPhong.Name = "MaDatPhong";
            this.MaDatPhong.ReadOnly = true;
            this.MaDatPhong.Width = 60;
            // 
            // MaPhong
            // 
            this.MaPhong.DataPropertyName = "MaPhong";
            this.MaPhong.HeaderText = "Mã Phòng";
            this.MaPhong.Name = "MaPhong";
            this.MaPhong.ReadOnly = true;
            this.MaPhong.Visible = false;
            this.MaPhong.Width = 70;
            // 
            // SoPhong
            // 
            this.SoPhong.DataPropertyName = "SoPhong";
            this.SoPhong.HeaderText = "Số Phòng";
            this.SoPhong.Name = "SoPhong";
            this.SoPhong.ReadOnly = true;
            this.SoPhong.Width = 80;
            // 
            // TenLoaiPhong
            // 
            this.TenLoaiPhong.DataPropertyName = "TenLoaiPhong";
            this.TenLoaiPhong.HeaderText = "Loại Phòng";
            this.TenLoaiPhong.Name = "TenLoaiPhong";
            this.TenLoaiPhong.ReadOnly = true;
            this.TenLoaiPhong.Width = 120;
            // 
            // TenKhachHang
            // 
            this.TenKhachHang.DataPropertyName = "TenKhachHang";
            this.TenKhachHang.HeaderText = "Tên Khách Hàng";
            this.TenKhachHang.Name = "TenKhachHang";
            this.TenKhachHang.ReadOnly = true;
            this.TenKhachHang.Width = 150;
            // 
            // SoDienThoai
            // 
            this.SoDienThoai.DataPropertyName = "SoDienThoai";
            this.SoDienThoai.HeaderText = "Số Điện Thoại";
            this.SoDienThoai.Name = "SoDienThoai";
            this.SoDienThoai.ReadOnly = true;
            this.SoDienThoai.Width = 110;
            // 
            // NgayNhanPhong
            // 
            this.NgayNhanPhong.DataPropertyName = "NgayNhanPhong";
            this.NgayNhanPhong.HeaderText = "Ngày Nhận";
            this.NgayNhanPhong.Name = "NgayNhanPhong";
            this.NgayNhanPhong.ReadOnly = true;
            this.NgayNhanPhong.Width = 120;
            // 
            // NgayTraPhong
            // 
            this.NgayTraPhong.DataPropertyName = "NgayTraPhong";
            this.NgayTraPhong.HeaderText = "Ngày Trả";
            this.NgayTraPhong.Name = "NgayTraPhong";
            this.NgayTraPhong.ReadOnly = true;
            this.NgayTraPhong.Width = 120;
            // 
            // LoaiDat
            // 
            this.LoaiDat.DataPropertyName = "LoaiDat";
            this.LoaiDat.HeaderText = "Loại Đặt";
            this.LoaiDat.Name = "LoaiDat";
            this.LoaiDat.ReadOnly = true;
            this.LoaiDat.Width = 80;
            // 
            // GiaPhong
            // 
            this.GiaPhong.DataPropertyName = "GiaPhong";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N0";
            this.GiaPhong.DefaultCellStyle = dataGridViewCellStyle6;
            this.GiaPhong.HeaderText = "Giá Phòng";
            this.GiaPhong.Name = "GiaPhong";
            this.GiaPhong.ReadOnly = true;
            // 
            // TrangThai
            // 
            this.TrangThai.DataPropertyName = "TrangThai";
            this.TrangThai.HeaderText = "Trạng Thái";
            this.TrangThai.Name = "TrangThai";
            this.TrangThai.ReadOnly = true;
            this.TrangThai.Width = 90;
            // 
            // TenNhanVien
            // 
            this.TenNhanVien.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.TenNhanVien.DataPropertyName = "TenNhanVien";
            this.TenNhanVien.HeaderText = "Nhân Viên Tạo";
            this.TenNhanVien.Name = "TenNhanVien";
            this.TenNhanVien.ReadOnly = true;
            // 
            // lblP
            // 
            this.lblP.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblP.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblP.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(212)))));
            this.lblP.Location = new System.Drawing.Point(0, 0);
            this.lblP.Name = "lblP";
            this.lblP.Size = new System.Drawing.Size(943, 26);
            this.lblP.TabIndex = 0;
            this.lblP.Text = "PHÒNG ĐANG SỬ DỤNG";
            this.lblP.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlMid
            // 
            this.pnlMid.Controls.Add(this.dgvDV);
            this.pnlMid.Controls.Add(this.lblDV);
            this.pnlMid.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlMid.Location = new System.Drawing.Point(0, 217);
            this.pnlMid.Name = "pnlMid";
            this.pnlMid.Size = new System.Drawing.Size(943, 173);
            this.pnlMid.TabIndex = 1;
            // 
            // dgvDV
            // 
            this.dgvDV.AllowUserToAddRows = false;
            this.dgvDV.BackgroundColor = System.Drawing.Color.White;
            this.dgvDV.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Segoe UI", 10F);
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDV.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvDV.ColumnHeadersHeight = 40;
            this.dgvDV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvDV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaSuDung,
            this.MaDatPhongDV,
            this.MaDichVu,
            this.TenDichVu,
            this.SoLuong,
            this.DonViTinh,
            this.DonGia,
            this.ThoiGianSuDung,
            this.GhiChu,
            this.MaNhanVienDV});
            this.dgvDV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDV.EnableHeadersVisualStyles = false;
            this.dgvDV.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dgvDV.Location = new System.Drawing.Point(0, 24);
            this.dgvDV.MultiSelect = false;
            this.dgvDV.Name = "dgvDV";
            this.dgvDV.ReadOnly = true;
            this.dgvDV.RowHeadersVisible = false;
            this.dgvDV.RowTemplate.Height = 30;
            this.dgvDV.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDV.Size = new System.Drawing.Size(943, 149);
            this.dgvDV.TabIndex = 1;
            // 
            // MaSuDung
            // 
            this.MaSuDung.DataPropertyName = "MaSuDung";
            this.MaSuDung.HeaderText = "Mã Sử Dụng";
            this.MaSuDung.Name = "MaSuDung";
            this.MaSuDung.ReadOnly = true;
            this.MaSuDung.Visible = false;
            // 
            // MaDatPhongDV
            // 
            this.MaDatPhongDV.DataPropertyName = "MaDatPhong";
            this.MaDatPhongDV.HeaderText = "Mã ĐP";
            this.MaDatPhongDV.Name = "MaDatPhongDV";
            this.MaDatPhongDV.ReadOnly = true;
            this.MaDatPhongDV.Visible = false;
            // 
            // MaDichVu
            // 
            this.MaDichVu.DataPropertyName = "MaDichVu";
            this.MaDichVu.HeaderText = "Mã DV";
            this.MaDichVu.Name = "MaDichVu";
            this.MaDichVu.ReadOnly = true;
            this.MaDichVu.Visible = false;
            // 
            // TenDichVu
            // 
            this.TenDichVu.DataPropertyName = "TenDichVu";
            this.TenDichVu.HeaderText = "Tên Dịch Vụ";
            this.TenDichVu.Name = "TenDichVu";
            this.TenDichVu.ReadOnly = true;
            this.TenDichVu.Width = 200;
            // 
            // SoLuong
            // 
            this.SoLuong.DataPropertyName = "SoLuong";
            this.SoLuong.HeaderText = "Số Lượng";
            this.SoLuong.Name = "SoLuong";
            this.SoLuong.ReadOnly = true;
            this.SoLuong.Width = 90;
            // 
            // DonViTinh
            // 
            this.DonViTinh.DataPropertyName = "DonViTinh";
            this.DonViTinh.HeaderText = "Đơn Vị Tính";
            this.DonViTinh.Name = "DonViTinh";
            this.DonViTinh.ReadOnly = true;
            // 
            // DonGia
            // 
            this.DonGia.DataPropertyName = "DonGia";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.Format = "N0";
            this.DonGia.DefaultCellStyle = dataGridViewCellStyle8;
            this.DonGia.HeaderText = "Đơn Giá";
            this.DonGia.Name = "DonGia";
            this.DonGia.ReadOnly = true;
            this.DonGia.Width = 120;
            // 
            // ThoiGianSuDung
            // 
            this.ThoiGianSuDung.DataPropertyName = "ThoiGianSuDung";
            this.ThoiGianSuDung.HeaderText = "Thời Gian SD";
            this.ThoiGianSuDung.Name = "ThoiGianSuDung";
            this.ThoiGianSuDung.ReadOnly = true;
            this.ThoiGianSuDung.Width = 150;
            // 
            // GhiChu
            // 
            this.GhiChu.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.GhiChu.DataPropertyName = "GhiChu";
            this.GhiChu.HeaderText = "Ghi Chú";
            this.GhiChu.Name = "GhiChu";
            this.GhiChu.ReadOnly = true;
            // 
            // MaNhanVienDV
            // 
            this.MaNhanVienDV.DataPropertyName = "MaNhanVien";
            this.MaNhanVienDV.HeaderText = "Mã NV";
            this.MaNhanVienDV.Name = "MaNhanVienDV";
            this.MaNhanVienDV.ReadOnly = true;
            this.MaNhanVienDV.Visible = false;
            // 
            // lblDV
            // 
            this.lblDV.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblDV.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblDV.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.lblDV.Location = new System.Drawing.Point(0, 0);
            this.lblDV.Name = "lblDV";
            this.lblDV.Size = new System.Drawing.Size(943, 24);
            this.lblDV.TabIndex = 0;
            this.lblDV.Text = "DỊCH VỤ ĐÃ SỬ DỤNG";
            this.lblDV.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlBot
            // 
            this.pnlBot.BackColor = System.Drawing.Color.White;
            this.pnlBot.Controls.Add(this.lblTienPhong);
            this.pnlBot.Controls.Add(this.lblTienDV);
            this.pnlBot.Controls.Add(this.lblGiamGia);
            this.pnlBot.Controls.Add(this.numGiamGia);
            this.pnlBot.Controls.Add(this.lblTongCong);
            this.pnlBot.Controls.Add(this.lblPT);
            this.pnlBot.Controls.Add(this.cboPhuongThuc);
            this.pnlBot.Controls.Add(this.btnCheckOut);
            this.pnlBot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBot.Location = new System.Drawing.Point(0, 390);
            this.pnlBot.Name = "pnlBot";
            this.pnlBot.Padding = new System.Windows.Forms.Padding(9);
            this.pnlBot.Size = new System.Drawing.Size(943, 199);
            this.pnlBot.TabIndex = 2;
            // 
            // lblTienPhong
            // 
            this.lblTienPhong.AutoSize = true;
            this.lblTienPhong.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblTienPhong.Location = new System.Drawing.Point(9, 9);
            this.lblTienPhong.Name = "lblTienPhong";
            this.lblTienPhong.Size = new System.Drawing.Size(128, 20);
            this.lblTienPhong.TabIndex = 0;
            this.lblTienPhong.Text = "Tiền phòng:      0đ";
            // 
            // lblTienDV
            // 
            this.lblTienDV.AutoSize = true;
            this.lblTienDV.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblTienDV.Location = new System.Drawing.Point(9, 33);
            this.lblTienDV.Name = "lblTienDV";
            this.lblTienDV.Size = new System.Drawing.Size(124, 20);
            this.lblTienDV.TabIndex = 1;
            this.lblTienDV.Text = "Tiền dịch vụ:    0đ";
            // 
            // lblGiamGia
            // 
            this.lblGiamGia.AutoSize = true;
            this.lblGiamGia.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblGiamGia.Location = new System.Drawing.Point(9, 62);
            this.lblGiamGia.Name = "lblGiamGia";
            this.lblGiamGia.Size = new System.Drawing.Size(96, 19);
            this.lblGiamGia.TabIndex = 2;
            this.lblGiamGia.Text = "Giảm giá (đ):";
            // 
            // numGiamGia
            // 
            this.numGiamGia.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.numGiamGia.Location = new System.Drawing.Point(120, 59);
            this.numGiamGia.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.numGiamGia.Name = "numGiamGia";
            this.numGiamGia.Size = new System.Drawing.Size(111, 25);
            this.numGiamGia.TabIndex = 3;
            this.numGiamGia.ThousandsSeparator = true;
            this.numGiamGia.ValueChanged += new System.EventHandler(this.numGiamGia_ValueChanged);
            // 
            // lblTongCong
            // 
            this.lblTongCong.AutoSize = true;
            this.lblTongCong.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTongCong.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.lblTongCong.Location = new System.Drawing.Point(9, 124);
            this.lblTongCong.Name = "lblTongCong";
            this.lblTongCong.Size = new System.Drawing.Size(159, 25);
            this.lblTongCong.TabIndex = 4;
            this.lblTongCong.Text = "TỔNG CỘNG: 0đ";
            // 
            // lblPT
            // 
            this.lblPT.AutoSize = true;
            this.lblPT.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblPT.Location = new System.Drawing.Point(9, 97);
            this.lblPT.Name = "lblPT";
            this.lblPT.Size = new System.Drawing.Size(118, 19);
            this.lblPT.TabIndex = 5;
            this.lblPT.Text = "Phương thức TT:";
            // 
            // cboPhuongThuc
            // 
            this.cboPhuongThuc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPhuongThuc.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboPhuongThuc.FormattingEnabled = true;
            this.cboPhuongThuc.Items.AddRange(new object[] {
            "Tiền mặt",
            "Chuyển khoản",
            "Thẻ tín dụng"});
            this.cboPhuongThuc.Location = new System.Drawing.Point(141, 94);
            this.cboPhuongThuc.Name = "cboPhuongThuc";
            this.cboPhuongThuc.Size = new System.Drawing.Size(138, 25);
            this.cboPhuongThuc.TabIndex = 6;
            // 
            // btnCheckOut
            // 
            this.btnCheckOut.AutoSize = true;
            this.btnCheckOut.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnCheckOut.FlatAppearance.BorderSize = 0;
            this.btnCheckOut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCheckOut.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnCheckOut.ForeColor = System.Drawing.Color.White;
            this.btnCheckOut.Location = new System.Drawing.Point(9, 154);
            this.btnCheckOut.Name = "btnCheckOut";
            this.btnCheckOut.Size = new System.Drawing.Size(268, 43);
            this.btnCheckOut.TabIndex = 7;
            this.btnCheckOut.Text = "🚪  CHECK-OUT && THANH TOÁN";
            this.btnCheckOut.UseVisualStyleBackColor = false;
            this.btnCheckOut.Click += new System.EventHandler(this.btnCheckOut_Click);
            // 
            // frmCheckOut
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(943, 589);
            this.Controls.Add(this.pnlBot);
            this.Controls.Add(this.pnlMid);
            this.Controls.Add(this.pnlTop);
            this.Name = "frmCheckOut";
            this.Text = "🚪 Check-Out & Thanh Toán";
            this.pnlTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhong)).EndInit();
            this.pnlMid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDV)).EndInit();
            this.pnlBot.ResumeLayout(false);
            this.pnlBot.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numGiamGia)).EndInit();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.DataGridView dgvPhong;
        private System.Windows.Forms.Label lblP;
        private System.Windows.Forms.Panel pnlMid;
        private System.Windows.Forms.DataGridView dgvDV;
        private System.Windows.Forms.Label lblDV;
        private System.Windows.Forms.Panel pnlBot;
        private System.Windows.Forms.Label lblTienPhong;
        private System.Windows.Forms.Label lblTienDV;
        private System.Windows.Forms.Label lblGiamGia;
        private System.Windows.Forms.NumericUpDown numGiamGia;
        private System.Windows.Forms.Label lblTongCong;
        private System.Windows.Forms.Label lblPT;
        private System.Windows.Forms.ComboBox cboPhuongThuc;
        private System.Windows.Forms.Button btnCheckOut;

        private System.Windows.Forms.DataGridViewTextBoxColumn MaDatPhong;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaPhong;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoPhong;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenLoaiPhong;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenKhachHang;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoDienThoai;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayNhanPhong;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayTraPhong;
        private System.Windows.Forms.DataGridViewTextBoxColumn LoaiDat;
        private System.Windows.Forms.DataGridViewTextBoxColumn GiaPhong;
        private System.Windows.Forms.DataGridViewTextBoxColumn TrangThai;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenNhanVien;

        private System.Windows.Forms.DataGridViewTextBoxColumn MaSuDung;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaDatPhongDV;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaDichVu;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenDichVu;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoLuong;
        private System.Windows.Forms.DataGridViewTextBoxColumn DonGia;
        private System.Windows.Forms.DataGridViewTextBoxColumn DonViTinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn ThoiGianSuDung;
        private System.Windows.Forms.DataGridViewTextBoxColumn GhiChu;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaNhanVienDV;
    }
}
