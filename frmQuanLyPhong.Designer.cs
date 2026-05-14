using System;
using System.Drawing;
using System.Windows.Forms;

namespace HotelManagement
{
    public partial class frmQuanLyPhong
    {
        private System.ComponentModel.IContainer components = null;

        private Panel pnlLeft;
        private Panel pnlRight;
        private Panel pnlToolbar;
        private Label lblHeader;
        private Label lblSoPhong;
        private Label lblLoaiPhong;
        private Label lblTang;
        private Label lblTrangThai;
        private Label lblMoTa;
        private Label lblGiaMoiGio;
        private Label lblGiaMoiDem;
        private Label lblTongPhong;

        private DataGridView dgvPhong;
        private TextBox txtMaPhong;
        private TextBox txtSoPhong;
        private TextBox txtMoTa;
        private TextBox txtGiaMoiGio;
        private TextBox txtGiaMoiDem;
        private TextBox txtTimKiem;
        private ComboBox cboLoaiPhong;
        private ComboBox cboTrangThai;
        private ComboBox cboLocTrangThai;
        private NumericUpDown numTang;
        private Button btnThem;
        private Button btnCapNhat;
        private Button btnXoa;
        private Button btnLuu;
        private Button btnHuy;

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                components?.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.lblHeader = new System.Windows.Forms.Label();
            this.txtMaPhong = new System.Windows.Forms.TextBox();
            this.lblSoPhong = new System.Windows.Forms.Label();
            this.txtSoPhong = new System.Windows.Forms.TextBox();
            this.lblLoaiPhong = new System.Windows.Forms.Label();
            this.cboLoaiPhong = new System.Windows.Forms.ComboBox();
            this.lblTang = new System.Windows.Forms.Label();
            this.numTang = new System.Windows.Forms.NumericUpDown();
            this.lblTrangThai = new System.Windows.Forms.Label();
            this.cboTrangThai = new System.Windows.Forms.ComboBox();
            this.lblGiaMoiGio = new System.Windows.Forms.Label();
            this.txtGiaMoiGio = new System.Windows.Forms.TextBox();
            this.lblGiaMoiDem = new System.Windows.Forms.Label();
            this.txtGiaMoiDem = new System.Windows.Forms.TextBox();
            this.lblMoTa = new System.Windows.Forms.Label();
            this.txtMoTa = new System.Windows.Forms.TextBox();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnCapNhat = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnHuy = new System.Windows.Forms.Button();
            this.pnlRight = new System.Windows.Forms.Panel();
            this.dgvPhong = new System.Windows.Forms.DataGridView();
            this.MaPhong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoPhong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaLoaiPhong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenLoai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GiaMoiGio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GiaMoiDem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TrangThai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MoTa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlToolbar = new System.Windows.Forms.Panel();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.cboLocTrangThai = new System.Windows.Forms.ComboBox();
            this.lblTongPhong = new System.Windows.Forms.Label();
            this.pnlLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTang)).BeginInit();
            this.pnlRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhong)).BeginInit();
            this.pnlToolbar.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlLeft
            // 
            this.pnlLeft.BackColor = System.Drawing.Color.White;
            this.pnlLeft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlLeft.Controls.Add(this.lblHeader);
            this.pnlLeft.Controls.Add(this.txtMaPhong);
            this.pnlLeft.Controls.Add(this.lblSoPhong);
            this.pnlLeft.Controls.Add(this.txtSoPhong);
            this.pnlLeft.Controls.Add(this.lblLoaiPhong);
            this.pnlLeft.Controls.Add(this.cboLoaiPhong);
            this.pnlLeft.Controls.Add(this.lblTang);
            this.pnlLeft.Controls.Add(this.numTang);
            this.pnlLeft.Controls.Add(this.lblTrangThai);
            this.pnlLeft.Controls.Add(this.cboTrangThai);
            this.pnlLeft.Controls.Add(this.lblGiaMoiGio);
            this.pnlLeft.Controls.Add(this.txtGiaMoiGio);
            this.pnlLeft.Controls.Add(this.lblGiaMoiDem);
            this.pnlLeft.Controls.Add(this.txtGiaMoiDem);
            this.pnlLeft.Controls.Add(this.lblMoTa);
            this.pnlLeft.Controls.Add(this.txtMoTa);
            this.pnlLeft.Controls.Add(this.btnThem);
            this.pnlLeft.Controls.Add(this.btnCapNhat);
            this.pnlLeft.Controls.Add(this.btnXoa);
            this.pnlLeft.Controls.Add(this.btnLuu);
            this.pnlLeft.Controls.Add(this.btnHuy);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Padding = new System.Windows.Forms.Padding(9);
            this.pnlLeft.Size = new System.Drawing.Size(257, 566);
            this.pnlLeft.TabIndex = 1;
            // 
            // lblHeader
            // 
            this.lblHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblHeader.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(212)))));
            this.lblHeader.Location = new System.Drawing.Point(9, 9);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(237, 30);
            this.lblHeader.TabIndex = 0;
            this.lblHeader.Text = "THÔNG TIN PHÒNG";
            this.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMaPhong
            // 
            this.txtMaPhong.Location = new System.Drawing.Point(0, 0);
            this.txtMaPhong.Name = "txtMaPhong";
            this.txtMaPhong.Size = new System.Drawing.Size(86, 20);
            this.txtMaPhong.TabIndex = 1;
            this.txtMaPhong.Visible = false;
            // 
            // lblSoPhong
            // 
            this.lblSoPhong.AutoSize = true;
            this.lblSoPhong.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblSoPhong.Location = new System.Drawing.Point(9, 39);
            this.lblSoPhong.Name = "lblSoPhong";
            this.lblSoPhong.Size = new System.Drawing.Size(67, 15);
            this.lblSoPhong.TabIndex = 2;
            this.lblSoPhong.Text = "Số Phòng *";
            // 
            // txtSoPhong
            // 
            this.txtSoPhong.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtSoPhong.Location = new System.Drawing.Point(9, 58);
            this.txtSoPhong.Name = "txtSoPhong";
            this.txtSoPhong.Size = new System.Drawing.Size(232, 25);
            this.txtSoPhong.TabIndex = 3;
            // 
            // lblLoaiPhong
            // 
            this.lblLoaiPhong.AutoSize = true;
            this.lblLoaiPhong.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblLoaiPhong.Location = new System.Drawing.Point(9, 91);
            this.lblLoaiPhong.Name = "lblLoaiPhong";
            this.lblLoaiPhong.Size = new System.Drawing.Size(75, 15);
            this.lblLoaiPhong.TabIndex = 4;
            this.lblLoaiPhong.Text = "Loại Phòng *";
            // 
            // cboLoaiPhong
            // 
            this.cboLoaiPhong.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLoaiPhong.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboLoaiPhong.Location = new System.Drawing.Point(9, 110);
            this.cboLoaiPhong.Name = "cboLoaiPhong";
            this.cboLoaiPhong.Size = new System.Drawing.Size(232, 25);
            this.cboLoaiPhong.TabIndex = 5;
            this.cboLoaiPhong.SelectedIndexChanged += new System.EventHandler(this.cboLoaiPhong_SelectedIndexChanged);
            // 
            // lblTang
            // 
            this.lblTang.AutoSize = true;
            this.lblTang.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTang.Location = new System.Drawing.Point(9, 143);
            this.lblTang.Name = "lblTang";
            this.lblTang.Size = new System.Drawing.Size(34, 15);
            this.lblTang.TabIndex = 6;
            this.lblTang.Text = "Tầng";
            // 
            // numTang
            // 
            this.numTang.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.numTang.Location = new System.Drawing.Point(9, 162);
            this.numTang.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numTang.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numTang.Name = "numTang";
            this.numTang.Size = new System.Drawing.Size(86, 25);
            this.numTang.TabIndex = 7;
            this.numTang.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblTrangThai
            // 
            this.lblTrangThai.AutoSize = true;
            this.lblTrangThai.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTrangThai.Location = new System.Drawing.Point(9, 299);
            this.lblTrangThai.Name = "lblTrangThai";
            this.lblTrangThai.Size = new System.Drawing.Size(64, 15);
            this.lblTrangThai.TabIndex = 12;
            this.lblTrangThai.Text = "Trạng Thái";
            // 
            // cboTrangThai
            // 
            this.cboTrangThai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTrangThai.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboTrangThai.Items.AddRange(new object[] {
            "Trống",
            "Đang sử dụng",
            "Đang dọn",
            "Bảo trì"});
            this.cboTrangThai.Location = new System.Drawing.Point(9, 318);
            this.cboTrangThai.Name = "cboTrangThai";
            this.cboTrangThai.Size = new System.Drawing.Size(232, 25);
            this.cboTrangThai.TabIndex = 13;
            // 
            // lblGiaMoiGio
            // 
            this.lblGiaMoiGio.AutoSize = true;
            this.lblGiaMoiGio.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblGiaMoiGio.Location = new System.Drawing.Point(9, 195);
            this.lblGiaMoiGio.Name = "lblGiaMoiGio";
            this.lblGiaMoiGio.Size = new System.Drawing.Size(70, 15);
            this.lblGiaMoiGio.TabIndex = 8;
            this.lblGiaMoiGio.Text = "Giá mỗi giờ";
            // 
            // txtGiaMoiGio
            // 
            this.txtGiaMoiGio.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtGiaMoiGio.Location = new System.Drawing.Point(9, 214);
            this.txtGiaMoiGio.Name = "txtGiaMoiGio";
            this.txtGiaMoiGio.Size = new System.Drawing.Size(232, 25);
            this.txtGiaMoiGio.TabIndex = 9;
            // 
            // lblGiaMoiDem
            // 
            this.lblGiaMoiDem.AutoSize = true;
            this.lblGiaMoiDem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblGiaMoiDem.Location = new System.Drawing.Point(9, 247);
            this.lblGiaMoiDem.Name = "lblGiaMoiDem";
            this.lblGiaMoiDem.Size = new System.Drawing.Size(78, 15);
            this.lblGiaMoiDem.TabIndex = 10;
            this.lblGiaMoiDem.Text = "Giá mỗi đêm";
            // 
            // txtGiaMoiDem
            // 
            this.txtGiaMoiDem.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtGiaMoiDem.Location = new System.Drawing.Point(9, 266);
            this.txtGiaMoiDem.Name = "txtGiaMoiDem";
            this.txtGiaMoiDem.Size = new System.Drawing.Size(232, 25);
            this.txtGiaMoiDem.TabIndex = 11;
            // 
            // lblMoTa
            // 
            this.lblMoTa.AutoSize = true;
            this.lblMoTa.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblMoTa.Location = new System.Drawing.Point(9, 351);
            this.lblMoTa.Name = "lblMoTa";
            this.lblMoTa.Size = new System.Drawing.Size(41, 15);
            this.lblMoTa.TabIndex = 14;
            this.lblMoTa.Text = "Mô Tả";
            // 
            // txtMoTa
            // 
            this.txtMoTa.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtMoTa.Location = new System.Drawing.Point(9, 370);
            this.txtMoTa.Multiline = true;
            this.txtMoTa.Name = "txtMoTa";
            this.txtMoTa.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMoTa.Size = new System.Drawing.Size(232, 61);
            this.txtMoTa.TabIndex = 15;
            // 
            // btnThem
            // 
            this.btnThem.AutoSize = true;
            this.btnThem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.btnThem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThem.FlatAppearance.BorderSize = 0;
            this.btnThem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnThem.ForeColor = System.Drawing.Color.White;
            this.btnThem.Location = new System.Drawing.Point(9, 442);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(107, 30);
            this.btnThem.TabIndex = 16;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = false;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnCapNhat
            // 
            this.btnCapNhat.AutoSize = true;
            this.btnCapNhat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnCapNhat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCapNhat.FlatAppearance.BorderSize = 0;
            this.btnCapNhat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCapNhat.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnCapNhat.ForeColor = System.Drawing.Color.White;
            this.btnCapNhat.Location = new System.Drawing.Point(124, 442);
            this.btnCapNhat.Name = "btnCapNhat";
            this.btnCapNhat.Size = new System.Drawing.Size(107, 30);
            this.btnCapNhat.TabIndex = 17;
            this.btnCapNhat.Text = "Sửa";
            this.btnCapNhat.UseVisualStyleBackColor = false;
            this.btnCapNhat.Click += new System.EventHandler(this.btnCapNhat_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.AutoSize = true;
            this.btnXoa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnXoa.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXoa.FlatAppearance.BorderSize = 0;
            this.btnXoa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoa.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnXoa.ForeColor = System.Drawing.Color.White;
            this.btnXoa.Location = new System.Drawing.Point(9, 481);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(107, 30);
            this.btnXoa.TabIndex = 18;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = false;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.AutoSize = true;
            this.btnLuu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.btnLuu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLuu.Enabled = false;
            this.btnLuu.FlatAppearance.BorderSize = 0;
            this.btnLuu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLuu.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnLuu.ForeColor = System.Drawing.Color.White;
            this.btnLuu.Location = new System.Drawing.Point(124, 481);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(107, 30);
            this.btnLuu.TabIndex = 20;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = false;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnHuy
            // 
            this.btnHuy.AutoSize = true;
            this.btnHuy.BackColor = System.Drawing.Color.Gray;
            this.btnHuy.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHuy.Enabled = false;
            this.btnHuy.FlatAppearance.BorderSize = 0;
            this.btnHuy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHuy.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnHuy.ForeColor = System.Drawing.Color.White;
            this.btnHuy.Location = new System.Drawing.Point(9, 520);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(222, 30);
            this.btnHuy.TabIndex = 21;
            this.btnHuy.Text = "Không lưu";
            this.btnHuy.UseVisualStyleBackColor = false;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // pnlRight
            // 
            this.pnlRight.Controls.Add(this.dgvPhong);
            this.pnlRight.Controls.Add(this.pnlToolbar);
            this.pnlRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRight.Location = new System.Drawing.Point(257, 0);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Padding = new System.Windows.Forms.Padding(9);
            this.pnlRight.Size = new System.Drawing.Size(924, 566);
            this.pnlRight.TabIndex = 0;
            // 
            // dgvPhong
            // 
            this.dgvPhong.BackgroundColor = System.Drawing.Color.White;
            this.dgvPhong.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvPhong.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(212)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 10F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPhong.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPhong.ColumnHeadersHeight = 40;
            this.dgvPhong.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvPhong.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaPhong,
            this.SoPhong,
            this.Tang,
            this.MaLoaiPhong,
            this.TenLoai,
            this.GiaMoiGio,
            this.GiaMoiDem,
            this.TrangThai,
            this.MoTa});
            this.dgvPhong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPhong.EnableHeadersVisualStyles = false;
            this.dgvPhong.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dgvPhong.Location = new System.Drawing.Point(9, 48);
            this.dgvPhong.MultiSelect = false;
            this.dgvPhong.Name = "dgvPhong";
            this.dgvPhong.ReadOnly = true;
            this.dgvPhong.RowHeadersVisible = false;
            this.dgvPhong.RowTemplate.Height = 30;
            this.dgvPhong.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPhong.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPhong.Size = new System.Drawing.Size(906, 509);
            this.dgvPhong.TabIndex = 0;
            this.dgvPhong.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPhong_CellEnter);
            // 
            // MaPhong
            // 
            this.MaPhong.DataPropertyName = "MaPhong";
            this.MaPhong.HeaderText = "Mã Phòng";
            this.MaPhong.Name = "MaPhong";
            this.MaPhong.ReadOnly = true;
            this.MaPhong.Visible = false;
            this.MaPhong.Width = 95;
            // 
            // SoPhong
            // 
            this.SoPhong.DataPropertyName = "SoPhong";
            this.SoPhong.HeaderText = "Số Phòng";
            this.SoPhong.Name = "SoPhong";
            this.SoPhong.ReadOnly = true;
            this.SoPhong.Width = 95;
            // 
            // Tang
            // 
            this.Tang.DataPropertyName = "Tang";
            this.Tang.HeaderText = "Tầng";
            this.Tang.Name = "Tang";
            this.Tang.ReadOnly = true;
            this.Tang.Width = 65;
            // 
            // MaLoaiPhong
            // 
            this.MaLoaiPhong.DataPropertyName = "MaLoaiPhong";
            this.MaLoaiPhong.HeaderText = "Mã Loại";
            this.MaLoaiPhong.Name = "MaLoaiPhong";
            this.MaLoaiPhong.ReadOnly = true;
            this.MaLoaiPhong.Visible = false;
            this.MaLoaiPhong.Width = 70;
            // 
            // TenLoai
            // 
            this.TenLoai.DataPropertyName = "TenLoai";
            this.TenLoai.HeaderText = "Loại Phòng";
            this.TenLoai.Name = "TenLoai";
            this.TenLoai.ReadOnly = true;
            this.TenLoai.Width = 150;
            // 
            // GiaMoiGio
            // 
            this.GiaMoiGio.DataPropertyName = "GiaMoiGio";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N0";
            this.GiaMoiGio.DefaultCellStyle = dataGridViewCellStyle2;
            this.GiaMoiGio.HeaderText = "Giá/Giờ";
            this.GiaMoiGio.Name = "GiaMoiGio";
            this.GiaMoiGio.ReadOnly = true;
            // 
            // GiaMoiDem
            // 
            this.GiaMoiDem.DataPropertyName = "GiaMoiDem";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N0";
            this.GiaMoiDem.DefaultCellStyle = dataGridViewCellStyle3;
            this.GiaMoiDem.HeaderText = "Giá/Đêm";
            this.GiaMoiDem.Name = "GiaMoiDem";
            this.GiaMoiDem.ReadOnly = true;
            // 
            // TrangThai
            // 
            this.TrangThai.DataPropertyName = "TrangThai";
            this.TrangThai.HeaderText = "Trạng Thái";
            this.TrangThai.Name = "TrangThai";
            this.TrangThai.ReadOnly = true;
            this.TrangThai.Width = 110;
            // 
            // MoTa
            // 
            this.MoTa.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.MoTa.DataPropertyName = "MoTa";
            this.MoTa.HeaderText = "Mô Tả";
            this.MoTa.Name = "MoTa";
            this.MoTa.ReadOnly = true;
            // 
            // pnlToolbar
            // 
            this.pnlToolbar.BackColor = System.Drawing.Color.White;
            this.pnlToolbar.Controls.Add(this.txtTimKiem);
            this.pnlToolbar.Controls.Add(this.cboLocTrangThai);
            this.pnlToolbar.Controls.Add(this.lblTongPhong);
            this.pnlToolbar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlToolbar.Location = new System.Drawing.Point(9, 9);
            this.pnlToolbar.Name = "pnlToolbar";
            this.pnlToolbar.Size = new System.Drawing.Size(906, 39);
            this.pnlToolbar.TabIndex = 1;
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtTimKiem.Location = new System.Drawing.Point(4, 9);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(172, 25);
            this.txtTimKiem.TabIndex = 0;
            this.txtTimKiem.TextChanged += new System.EventHandler(this.txtTimKiem_TextChanged);
            // 
            // cboLocTrangThai
            // 
            this.cboLocTrangThai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLocTrangThai.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboLocTrangThai.Items.AddRange(new object[] {
            "Tất cả",
            "Trống",
            "Đang sử dụng",
            "Đang dọn",
            "Bảo trì"});
            this.cboLocTrangThai.Location = new System.Drawing.Point(184, 9);
            this.cboLocTrangThai.Name = "cboLocTrangThai";
            this.cboLocTrangThai.Size = new System.Drawing.Size(129, 25);
            this.cboLocTrangThai.TabIndex = 1;
            this.cboLocTrangThai.SelectedIndexChanged += new System.EventHandler(this.cboLocTrangThai_SelectedIndexChanged);
            // 
            // lblTongPhong
            // 
            this.lblTongPhong.AutoSize = true;
            this.lblTongPhong.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTongPhong.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(212)))));
            this.lblTongPhong.Location = new System.Drawing.Point(326, 11);
            this.lblTongPhong.Name = "lblTongPhong";
            this.lblTongPhong.Size = new System.Drawing.Size(106, 19);
            this.lblTongPhong.TabIndex = 2;
            this.lblTongPhong.Text = "Tổng: 0 phòng";
            // 
            // frmQuanLyPhong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(1181, 566);
            this.Controls.Add(this.pnlRight);
            this.Controls.Add(this.pnlLeft);
            this.Name = "frmQuanLyPhong";
            this.Text = "🏠 Quản Lý Phòng";
            this.Load += new System.EventHandler(this.frmQuanLyPhong_Load);
            this.pnlLeft.ResumeLayout(false);
            this.pnlLeft.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTang)).EndInit();
            this.pnlRight.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhong)).EndInit();
            this.pnlToolbar.ResumeLayout(false);
            this.pnlToolbar.PerformLayout();
            this.ResumeLayout(false);

        }

        private DataGridViewTextBoxColumn MaPhong;
        private DataGridViewTextBoxColumn SoPhong;
        private DataGridViewTextBoxColumn Tang;
        private DataGridViewTextBoxColumn MaLoaiPhong;
        private DataGridViewTextBoxColumn TenLoai;
        private DataGridViewTextBoxColumn GiaMoiGio;
        private DataGridViewTextBoxColumn GiaMoiDem;
        private DataGridViewTextBoxColumn TrangThai;
        private DataGridViewTextBoxColumn MoTa;
    }
}