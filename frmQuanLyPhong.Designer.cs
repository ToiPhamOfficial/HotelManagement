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
        private Label lblTongPhong;

        private DataGridView dgvPhong;
        private TextBox txtMaPhong;
        private TextBox txtSoPhong;
        private TextBox txtMoTa;
        private TextBox txtTimKiem;
        private ComboBox cboLoaiPhong;
        private ComboBox cboTrangThai;
        private ComboBox cboLocTrangThai;
        private NumericUpDown numTang;

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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.lblMoTa = new System.Windows.Forms.Label();
            this.txtMoTa = new System.Windows.Forms.TextBox();
            this.pnlRight = new System.Windows.Forms.Panel();
            this.grpFunction = new System.Windows.Forms.GroupBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnExcel = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.dgvPhong = new System.Windows.Forms.DataGridView();
            this.MaPhong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoPhong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaLoaiPhong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenLoai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GiaMoiDem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GiaMoiGio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoNguoiToiDa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TrangThai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MoTa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlToolbar = new System.Windows.Forms.Panel();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.cboLocTrangThai = new System.Windows.Forms.ComboBox();
            this.lblTongPhong = new System.Windows.Forms.Label();
            this.pnlLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTang)).BeginInit();
            this.pnlRight.SuspendLayout();
            this.grpFunction.SuspendLayout();
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
            this.pnlLeft.Controls.Add(this.lblMoTa);
            this.pnlLeft.Controls.Add(this.txtMoTa);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Padding = new System.Windows.Forms.Padding(11);
            this.pnlLeft.Size = new System.Drawing.Size(343, 725);
            this.pnlLeft.TabIndex = 1;
            // 
            // lblHeader
            // 
            this.lblHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblHeader.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(212)))));
            this.lblHeader.Location = new System.Drawing.Point(11, 11);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(319, 37);
            this.lblHeader.TabIndex = 0;
            this.lblHeader.Text = "THÔNG TIN PHÒNG";
            this.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMaPhong
            // 
            this.txtMaPhong.Location = new System.Drawing.Point(0, 0);
            this.txtMaPhong.Name = "txtMaPhong";
            this.txtMaPhong.Size = new System.Drawing.Size(114, 22);
            this.txtMaPhong.TabIndex = 1;
            this.txtMaPhong.Visible = false;
            // 
            // lblSoPhong
            // 
            this.lblSoPhong.AutoSize = true;
            this.lblSoPhong.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblSoPhong.Location = new System.Drawing.Point(11, 48);
            this.lblSoPhong.Name = "lblSoPhong";
            this.lblSoPhong.Size = new System.Drawing.Size(86, 20);
            this.lblSoPhong.TabIndex = 2;
            this.lblSoPhong.Text = "Số Phòng *";
            // 
            // txtSoPhong
            // 
            this.txtSoPhong.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtSoPhong.Location = new System.Drawing.Point(11, 71);
            this.txtSoPhong.Name = "txtSoPhong";
            this.txtSoPhong.Size = new System.Drawing.Size(308, 30);
            this.txtSoPhong.TabIndex = 3;
            // 
            // lblLoaiPhong
            // 
            this.lblLoaiPhong.AutoSize = true;
            this.lblLoaiPhong.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblLoaiPhong.Location = new System.Drawing.Point(11, 112);
            this.lblLoaiPhong.Name = "lblLoaiPhong";
            this.lblLoaiPhong.Size = new System.Drawing.Size(98, 20);
            this.lblLoaiPhong.TabIndex = 4;
            this.lblLoaiPhong.Text = "Loại Phòng *";
            // 
            // cboLoaiPhong
            // 
            this.cboLoaiPhong.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLoaiPhong.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboLoaiPhong.Location = new System.Drawing.Point(11, 135);
            this.cboLoaiPhong.Name = "cboLoaiPhong";
            this.cboLoaiPhong.Size = new System.Drawing.Size(308, 31);
            this.cboLoaiPhong.TabIndex = 5;
            // 
            // lblTang
            // 
            this.lblTang.AutoSize = true;
            this.lblTang.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTang.Location = new System.Drawing.Point(11, 176);
            this.lblTang.Name = "lblTang";
            this.lblTang.Size = new System.Drawing.Size(44, 20);
            this.lblTang.TabIndex = 6;
            this.lblTang.Text = "Tầng";
            // 
            // numTang
            // 
            this.numTang.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.numTang.Location = new System.Drawing.Point(11, 199);
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
            this.numTang.Size = new System.Drawing.Size(114, 30);
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
            this.lblTrangThai.Location = new System.Drawing.Point(11, 240);
            this.lblTrangThai.Name = "lblTrangThai";
            this.lblTrangThai.Size = new System.Drawing.Size(83, 20);
            this.lblTrangThai.TabIndex = 8;
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
            this.cboTrangThai.Location = new System.Drawing.Point(11, 263);
            this.cboTrangThai.Name = "cboTrangThai";
            this.cboTrangThai.Size = new System.Drawing.Size(308, 31);
            this.cboTrangThai.TabIndex = 9;
            // 
            // lblMoTa
            // 
            this.lblMoTa.AutoSize = true;
            this.lblMoTa.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblMoTa.Location = new System.Drawing.Point(11, 304);
            this.lblMoTa.Name = "lblMoTa";
            this.lblMoTa.Size = new System.Drawing.Size(53, 20);
            this.lblMoTa.TabIndex = 10;
            this.lblMoTa.Text = "Mô Tả";
            // 
            // txtMoTa
            // 
            this.txtMoTa.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtMoTa.Location = new System.Drawing.Point(11, 327);
            this.txtMoTa.Multiline = true;
            this.txtMoTa.Name = "txtMoTa";
            this.txtMoTa.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMoTa.Size = new System.Drawing.Size(308, 74);
            this.txtMoTa.TabIndex = 11;
            // 
            // pnlRight
            // 
            this.pnlRight.Controls.Add(this.grpFunction);
            this.pnlRight.Controls.Add(this.dgvPhong);
            this.pnlRight.Controls.Add(this.pnlToolbar);
            this.pnlRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRight.Location = new System.Drawing.Point(343, 0);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Padding = new System.Windows.Forms.Padding(11);
            this.pnlRight.Size = new System.Drawing.Size(914, 725);
            this.pnlRight.TabIndex = 0;
            // 
            // grpFunction
            // 
            this.grpFunction.Controls.Add(this.btnAdd);
            this.grpFunction.Controls.Add(this.btnSave);
            this.grpFunction.Controls.Add(this.btnCancel);
            this.grpFunction.Controls.Add(this.btnEdit);
            this.grpFunction.Controls.Add(this.btnDelete);
            this.grpFunction.Controls.Add(this.btnExcel);
            this.grpFunction.Controls.Add(this.btnExit);
            this.grpFunction.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grpFunction.Location = new System.Drawing.Point(11, 655);
            this.grpFunction.Name = "grpFunction";
            this.grpFunction.Size = new System.Drawing.Size(892, 59);
            this.grpFunction.TabIndex = 3;
            this.grpFunction.TabStop = false;
            this.grpFunction.Text = "Chức năng";
            // 
            // btnAdd
            // 
            this.btnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdd.Location = new System.Drawing.Point(11, 19);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(114, 30);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "Thêm mới";
            this.btnAdd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnSave
            // 
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(137, 19);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(91, 30);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Lưu";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(240, 19);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(114, 30);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Không lưu";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEdit.Location = new System.Drawing.Point(366, 19);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(91, 30);
            this.btnEdit.TabIndex = 3;
            this.btnEdit.Text = "Sửa";
            this.btnEdit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.Location = new System.Drawing.Point(469, 19);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(91, 30);
            this.btnDelete.TabIndex = 4;
            this.btnDelete.Text = "Xóa";
            this.btnDelete.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnExcel
            // 
            this.btnExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExcel.Location = new System.Drawing.Point(571, 19);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(126, 30);
            this.btnExcel.TabIndex = 5;
            this.btnExcel.Text = "Xuất Excel";
            this.btnExcel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExcel.UseVisualStyleBackColor = true;
            // 
            // btnExit
            // 
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExit.Location = new System.Drawing.Point(709, 19);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(91, 30);
            this.btnExit.TabIndex = 6;
            this.btnExit.Text = "Thoát";
            this.btnExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // dgvPhong
            // 
            this.dgvPhong.AllowUserToAddRows = false;
            this.dgvPhong.BackgroundColor = System.Drawing.Color.White;
            this.dgvPhong.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(212)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 10F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPhong.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPhong.ColumnHeadersHeight = 35;
            this.dgvPhong.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaPhong,
            this.SoPhong,
            this.Tang,
            this.MaLoaiPhong,
            this.TenLoai,
            this.GiaMoiDem,
            this.GiaMoiGio,
            this.SoNguoiToiDa,
            this.TrangThai,
            this.MoTa});
            this.dgvPhong.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvPhong.EnableHeadersVisualStyles = false;
            this.dgvPhong.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dgvPhong.Location = new System.Drawing.Point(11, 59);
            this.dgvPhong.MultiSelect = false;
            this.dgvPhong.Name = "dgvPhong";
            this.dgvPhong.ReadOnly = true;
            this.dgvPhong.RowHeadersVisible = false;
            this.dgvPhong.RowHeadersWidth = 51;
            this.dgvPhong.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPhong.Size = new System.Drawing.Size(892, 609);
            this.dgvPhong.TabIndex = 0;
            this.dgvPhong.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPhong_CellEnter);
            // 
            // MaPhong
            // 
            this.MaPhong.DataPropertyName = "MaPhong";
            dataGridViewCellStyle2.Format = "N0";
            this.MaPhong.DefaultCellStyle = dataGridViewCellStyle2;
            this.MaPhong.HeaderText = "Mã Phòng";
            this.MaPhong.MinimumWidth = 6;
            this.MaPhong.Name = "MaPhong";
            this.MaPhong.ReadOnly = true;
            this.MaPhong.Visible = false;
            this.MaPhong.Width = 125;
            // 
            // SoPhong
            // 
            this.SoPhong.DataPropertyName = "SoPhong";
            this.SoPhong.HeaderText = "Số Phòng";
            this.SoPhong.MinimumWidth = 6;
            this.SoPhong.Name = "SoPhong";
            this.SoPhong.ReadOnly = true;
            this.SoPhong.Width = 80;
            // 
            // Tang
            // 
            this.Tang.DataPropertyName = "Tang";
            this.Tang.HeaderText = "Tầng";
            this.Tang.MinimumWidth = 6;
            this.Tang.Name = "Tang";
            this.Tang.ReadOnly = true;
            this.Tang.Width = 60;
            // 
            // MaLoaiPhong
            // 
            this.MaLoaiPhong.DataPropertyName = "MaLoaiPhong";
            this.MaLoaiPhong.HeaderText = "Mã Loại Phòng";
            this.MaLoaiPhong.MinimumWidth = 6;
            this.MaLoaiPhong.Name = "MaLoaiPhong";
            this.MaLoaiPhong.ReadOnly = true;
            this.MaLoaiPhong.Visible = false;
            this.MaLoaiPhong.Width = 150;
            // 
            // TenLoai
            // 
            this.TenLoai.DataPropertyName = "TenLoai";
            this.TenLoai.HeaderText = "Loại Phòng";
            this.TenLoai.MinimumWidth = 6;
            this.TenLoai.Name = "TenLoai";
            this.TenLoai.ReadOnly = true;
            this.TenLoai.Width = 150;
            // 
            // GiaMoiDem
            // 
            this.GiaMoiDem.DataPropertyName = "GiaMoiDem";
            dataGridViewCellStyle3.Format = "N0";
            dataGridViewCellStyle3.NullValue = null;
            this.GiaMoiDem.DefaultCellStyle = dataGridViewCellStyle3;
            this.GiaMoiDem.HeaderText = "Giá/Đêm";
            this.GiaMoiDem.MinimumWidth = 6;
            this.GiaMoiDem.Name = "GiaMoiDem";
            this.GiaMoiDem.ReadOnly = true;
            this.GiaMoiDem.Width = 110;
            // 
            // GiaMoiGio
            // 
            this.GiaMoiGio.DataPropertyName = "GiaMoiGio";
            dataGridViewCellStyle4.Format = "N0";
            this.GiaMoiGio.DefaultCellStyle = dataGridViewCellStyle4;
            this.GiaMoiGio.HeaderText = "Giá/Giờ";
            this.GiaMoiGio.MinimumWidth = 6;
            this.GiaMoiGio.Name = "GiaMoiGio";
            this.GiaMoiGio.ReadOnly = true;
            this.GiaMoiGio.Width = 125;
            // 
            // SoNguoiToiDa
            // 
            this.SoNguoiToiDa.DataPropertyName = "SoNguoiToiDa";
            this.SoNguoiToiDa.HeaderText = "Sức Chứa";
            this.SoNguoiToiDa.MinimumWidth = 6;
            this.SoNguoiToiDa.Name = "SoNguoiToiDa";
            this.SoNguoiToiDa.ReadOnly = true;
            this.SoNguoiToiDa.Width = 80;
            // 
            // TrangThai
            // 
            this.TrangThai.DataPropertyName = "TrangThai";
            this.TrangThai.HeaderText = "Trạng Thái";
            this.TrangThai.MinimumWidth = 6;
            this.TrangThai.Name = "TrangThai";
            this.TrangThai.ReadOnly = true;
            this.TrangThai.Width = 120;
            // 
            // MoTa
            // 
            this.MoTa.DataPropertyName = "MoTa";
            this.MoTa.HeaderText = "Mô tả";
            this.MoTa.MinimumWidth = 6;
            this.MoTa.Name = "MoTa";
            this.MoTa.ReadOnly = true;
            this.MoTa.Width = 200;
            // 
            // pnlToolbar
            // 
            this.pnlToolbar.BackColor = System.Drawing.Color.White;
            this.pnlToolbar.Controls.Add(this.txtTimKiem);
            this.pnlToolbar.Controls.Add(this.cboLocTrangThai);
            this.pnlToolbar.Controls.Add(this.lblTongPhong);
            this.pnlToolbar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlToolbar.Location = new System.Drawing.Point(11, 11);
            this.pnlToolbar.Name = "pnlToolbar";
            this.pnlToolbar.Size = new System.Drawing.Size(892, 48);
            this.pnlToolbar.TabIndex = 1;
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtTimKiem.Location = new System.Drawing.Point(6, 11);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(228, 30);
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
            this.cboLocTrangThai.Location = new System.Drawing.Point(246, 11);
            this.cboLocTrangThai.Name = "cboLocTrangThai";
            this.cboLocTrangThai.Size = new System.Drawing.Size(171, 31);
            this.cboLocTrangThai.TabIndex = 1;
            this.cboLocTrangThai.SelectedIndexChanged += new System.EventHandler(this.cboLocTrangThai_SelectedIndexChanged);
            // 
            // lblTongPhong
            // 
            this.lblTongPhong.AutoSize = true;
            this.lblTongPhong.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTongPhong.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(212)))));
            this.lblTongPhong.Location = new System.Drawing.Point(434, 14);
            this.lblTongPhong.Name = "lblTongPhong";
            this.lblTongPhong.Size = new System.Drawing.Size(0, 23);
            this.lblTongPhong.TabIndex = 2;
            // 
            // frmQuanLyPhong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(1257, 725);
            this.Controls.Add(this.pnlRight);
            this.Controls.Add(this.pnlLeft);
            this.Name = "frmQuanLyPhong";
            this.Text = "🏠 Quản Lý Phòng";
            this.Load += new System.EventHandler(this.frmQuanLyPhong_Load);
            this.pnlLeft.ResumeLayout(false);
            this.pnlLeft.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTang)).EndInit();
            this.pnlRight.ResumeLayout(false);
            this.grpFunction.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhong)).EndInit();
            this.pnlToolbar.ResumeLayout(false);
            this.pnlToolbar.PerformLayout();
            this.ResumeLayout(false);

        }

        private GroupBox grpFunction;
        private Button btnAdd;
        private Button btnSave;
        private Button btnCancel;
        private Button btnEdit;
        private Button btnDelete;
        private Button btnExcel;
        private Button btnExit;
        private DataGridViewTextBoxColumn MaPhong;
        private DataGridViewTextBoxColumn SoPhong;
        private DataGridViewTextBoxColumn Tang;
        private DataGridViewTextBoxColumn MaLoaiPhong;
        private DataGridViewTextBoxColumn TenLoai;
        private DataGridViewTextBoxColumn GiaMoiDem;
        private DataGridViewTextBoxColumn GiaMoiGio;
        private DataGridViewTextBoxColumn SoNguoiToiDa;
        private DataGridViewTextBoxColumn TrangThai;
        private DataGridViewTextBoxColumn MoTa;
    }
}
