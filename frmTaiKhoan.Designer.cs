using System;
using System.Drawing;
using System.Windows.Forms;

namespace HotelManagement
{
    public partial class frmTaiKhoan
    {
        private System.ComponentModel.IContainer components = null;

        private Panel pnlLeft;
        private Label lblMaTaiKhoan;
        private Label lblTenDangNhap;
        private TextBox txtTenDangNhap;
        private Label lblMatKhau;
        private TextBox txtMatKhau;
        private Label lblNhanVien;
        private ComboBox cboNhanVien;
        private Label lblVaiTro;
        private ComboBox cboVaiTro;
        private CheckBox chkTrangThai;
        private TextBox txtMaTaiKhoan;

        private Button btnThem;
        private Button btnCapNhat;
        private Button btnXoa;
        private Button btnLuu;
        private Button btnHuy;
        private Button btnLamMoi;

        private Panel pnlRight;
        private DataGridView dgvTaiKhoan;
        private TextBox txtTimKiem;

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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            this.pnlLeft = new Panel();
            this.lblMaTaiKhoan = new Label();
            this.txtMaTaiKhoan = new TextBox();
            this.lblTenDangNhap = new Label();
            this.txtTenDangNhap = new TextBox();
            this.lblMatKhau = new Label();
            this.txtMatKhau = new TextBox();
            this.lblNhanVien = new Label();
            this.cboNhanVien = new ComboBox();
            this.lblVaiTro = new Label();
            this.cboVaiTro = new ComboBox();
            this.chkTrangThai = new CheckBox();
            this.btnThem = new Button();
            this.btnCapNhat = new Button();
            this.btnXoa = new Button();
            this.btnLuu = new Button();
            this.btnHuy = new Button();
            this.btnLamMoi = new Button();
            this.pnlRight = new Panel();
            this.txtTimKiem = new TextBox();
            this.dgvTaiKhoan = new DataGridView();
            this.pnlLeft.SuspendLayout();
            this.pnlRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTaiKhoan)).BeginInit();
            this.SuspendLayout();

            // 
            // pnlLeft
            // 
            this.pnlLeft.BackColor = Color.White;
            this.pnlLeft.BorderStyle = BorderStyle.FixedSingle;
            this.pnlLeft.Controls.Add(this.lblMaTaiKhoan);
            this.pnlLeft.Controls.Add(this.txtMaTaiKhoan);
            this.pnlLeft.Controls.Add(this.lblTenDangNhap);
            this.pnlLeft.Controls.Add(this.txtTenDangNhap);
            this.pnlLeft.Controls.Add(this.lblMatKhau);
            this.pnlLeft.Controls.Add(this.txtMatKhau);
            this.pnlLeft.Controls.Add(this.lblNhanVien);
            this.pnlLeft.Controls.Add(this.cboNhanVien);
            this.pnlLeft.Controls.Add(this.lblVaiTro);
            this.pnlLeft.Controls.Add(this.cboVaiTro);
            this.pnlLeft.Controls.Add(this.chkTrangThai);
            this.pnlLeft.Controls.Add(this.btnThem);
            this.pnlLeft.Controls.Add(this.btnCapNhat);
            this.pnlLeft.Controls.Add(this.btnXoa);
            this.pnlLeft.Controls.Add(this.btnLuu);
            this.pnlLeft.Controls.Add(this.btnHuy);
            this.pnlLeft.Controls.Add(this.btnLamMoi);
            this.pnlLeft.Dock = DockStyle.Left;
            this.pnlLeft.Location = new Point(0, 0);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Padding = new Padding(10);
            this.pnlLeft.Size = new Size(280, 600);
            this.pnlLeft.TabIndex = 0;

            // 
            // lblMaTaiKhoan
            // 
            this.lblMaTaiKhoan.AutoSize = true;
            this.lblMaTaiKhoan.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.lblMaTaiKhoan.Location = new Point(13, 10);
            this.lblMaTaiKhoan.Name = "lblMaTaiKhoan";
            this.lblMaTaiKhoan.Size = new Size(100, 15);
            this.lblMaTaiKhoan.TabIndex = 0;
            this.lblMaTaiKhoan.Text = "Mã Tài Khoản";

            // 
            // txtMaTaiKhoan
            // 
            this.txtMaTaiKhoan.Font = new Font("Segoe UI", 10F);
            this.txtMaTaiKhoan.Location = new Point(13, 28);
            this.txtMaTaiKhoan.Name = "txtMaTaiKhoan";
            this.txtMaTaiKhoan.Enabled = false;
            this.txtMaTaiKhoan.Size = new Size(250, 25);
            this.txtMaTaiKhoan.TabIndex = 1;

            // 
            // lblNhanVien
            // 
            this.lblNhanVien.AutoSize = true;
            this.lblNhanVien.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.lblNhanVien.Location = new Point(13, 66);
            this.lblNhanVien.Name = "lblNhanVien";
            this.lblNhanVien.Size = new Size(74, 15);
            this.lblNhanVien.Text = "Nhân Viên *";
            this.lblNhanVien.TabIndex = 2;

            // 
            // cboNhanVien
            // 
            this.cboNhanVien.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cboNhanVien.Font = new Font("Segoe UI", 10F);
            this.cboNhanVien.Location = new Point(13, 84);
            this.cboNhanVien.Name = "cboNhanVien";
            this.cboNhanVien.Size = new Size(250, 25);
            this.cboNhanVien.TabIndex = 3;

            // 
            // lblTenDangNhap
            // 
            this.lblTenDangNhap.AutoSize = true;
            this.lblTenDangNhap.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.lblTenDangNhap.Location = new Point(13, 122);
            this.lblTenDangNhap.Name = "lblTenDangNhap";
            this.lblTenDangNhap.Size = new Size(100, 15);
            this.lblTenDangNhap.Text = "Tên Đăng Nhập *";
            this.lblTenDangNhap.TabIndex = 4;

            // 
            // txtTenDangNhap
            // 
            this.txtTenDangNhap.Font = new Font("Segoe UI", 10F);
            this.txtTenDangNhap.Location = new Point(13, 140);
            this.txtTenDangNhap.Name = "txtTenDangNhap";
            this.txtTenDangNhap.Size = new Size(250, 25);
            this.txtTenDangNhap.TabIndex = 5;

            // 
            // lblMatKhau
            // 
            this.lblMatKhau.AutoSize = true;
            this.lblMatKhau.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.lblMatKhau.Location = new Point(13, 178);
            this.lblMatKhau.Name = "lblMatKhau";
            this.lblMatKhau.Size = new Size(183, 15);
            this.lblMatKhau.Text = "Mật Khẩu (Chỉ khi thêm/reset) *";
            this.lblMatKhau.TabIndex = 6;

            // 
            // txtMatKhau
            // 
            this.txtMatKhau.Font = new Font("Segoe UI", 10F);
            this.txtMatKhau.Location = new Point(13, 196);
            this.txtMatKhau.Name = "txtMatKhau";
            this.txtMatKhau.PasswordChar = '*';
            this.txtMatKhau.Size = new Size(250, 25);
            this.txtMatKhau.TabIndex = 7;

            // 
            // lblVaiTro
            // 
            this.lblVaiTro.AutoSize = true;
            this.lblVaiTro.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.lblVaiTro.Location = new Point(13, 234);
            this.lblVaiTro.Name = "lblVaiTro";
            this.lblVaiTro.Size = new Size(54, 15);
            this.lblVaiTro.Text = "Vai Trò *";
            this.lblVaiTro.TabIndex = 8;

            // 
            // cboVaiTro
            // 
            this.cboVaiTro.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cboVaiTro.Font = new Font("Segoe UI", 10F);
            this.cboVaiTro.Items.AddRange(new object[] { "Admin", "Quản Lý", "Nhân Viên" });
            this.cboVaiTro.Location = new Point(13, 252);
            this.cboVaiTro.Name = "cboVaiTro";
            this.cboVaiTro.Size = new Size(250, 25);
            this.cboVaiTro.TabIndex = 9;

            // 
            // chkTrangThai
            // 
            this.chkTrangThai.AutoSize = true;
            this.chkTrangThai.Checked = true;
            this.chkTrangThai.CheckState = CheckState.Checked;
            this.chkTrangThai.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.chkTrangThai.Location = new Point(13, 296);
            this.chkTrangThai.Name = "chkTrangThai";
            this.chkTrangThai.Size = new Size(153, 19);
            this.chkTrangThai.Text = "Đang hoạt động (Khóa)";
            this.chkTrangThai.TabIndex = 10;

            // 
            // btnThem
            // 
            this.btnThem.BackColor = Color.FromArgb(39, 174, 96);
            this.btnThem.Cursor = Cursors.Hand;
            this.btnThem.FlatStyle = FlatStyle.Flat;
            this.btnThem.ForeColor = Color.White;
            this.btnThem.Location = new Point(13, 336);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new Size(120, 33);
            this.btnThem.Text = "Thêm";
            this.btnThem.AutoSize = true;
            this.btnThem.TabIndex = 11;
            this.btnThem.UseVisualStyleBackColor = false;
            this.btnThem.Click += new EventHandler(this.btnThem_Click);

            this.btnCapNhat.BackColor = Color.FromArgb(52, 152, 219);
            this.btnCapNhat.Cursor = Cursors.Hand;
            this.btnCapNhat.FlatStyle = FlatStyle.Flat;
            this.btnCapNhat.ForeColor = Color.White;
            this.btnCapNhat.Location = new Point(143, 336);
            this.btnCapNhat.Name = "btnCapNhat";
            this.btnCapNhat.Size = new Size(120, 33);
            this.btnCapNhat.Text = "Sửa";
            this.btnCapNhat.AutoSize = true;
            this.btnCapNhat.TabIndex = 12;
            this.btnCapNhat.UseVisualStyleBackColor = false;
            this.btnCapNhat.Click += new EventHandler(this.btnCapNhat_Click);

            this.btnXoa.BackColor = Color.FromArgb(231, 76, 60);
            this.btnXoa.Cursor = Cursors.Hand;
            this.btnXoa.FlatStyle = FlatStyle.Flat;
            this.btnXoa.ForeColor = Color.White;
            this.btnXoa.Location = new Point(13, 381);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new Size(120, 33);
            this.btnXoa.Text = "Xóa/Khóa";
            this.btnXoa.AutoSize = true;
            this.btnXoa.TabIndex = 13;
            this.btnXoa.UseVisualStyleBackColor = false;
            this.btnXoa.Click += new EventHandler(this.btnXoa_Click);

            this.btnLuu.BackColor = Color.FromArgb(39, 174, 96);
            this.btnLuu.Cursor = Cursors.Hand;
            this.btnLuu.FlatStyle = FlatStyle.Flat;
            this.btnLuu.ForeColor = Color.White;
            this.btnLuu.Location = new Point(13, 426);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new Size(120, 33);
            this.btnLuu.Text = "Lưu";
            this.btnLuu.AutoSize = true;
            this.btnLuu.Enabled = false;
            this.btnLuu.TabIndex = 14;
            this.btnLuu.UseVisualStyleBackColor = false;
            this.btnLuu.Click += new EventHandler(this.btnLuu_Click);

            this.btnHuy.BackColor = Color.Gray;
            this.btnHuy.Cursor = Cursors.Hand;
            this.btnHuy.FlatStyle = FlatStyle.Flat;
            this.btnHuy.ForeColor = Color.White;
            this.btnHuy.Location = new Point(143, 426);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new Size(120, 33);
            this.btnHuy.Text = "Không lưu";
            this.btnHuy.AutoSize = true;
            this.btnHuy.Enabled = false;
            this.btnHuy.TabIndex = 15;
            this.btnHuy.UseVisualStyleBackColor = false;
            this.btnHuy.Click += new EventHandler(this.btnHuy_Click);

            this.btnLamMoi.BackColor = Color.Gray;
            this.btnLamMoi.Cursor = Cursors.Hand;
            this.btnLamMoi.FlatStyle = FlatStyle.Flat;
            this.btnLamMoi.ForeColor = Color.White;
            this.btnLamMoi.Location = new Point(143, 381);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new Size(120, 33);
            this.btnLamMoi.Text = "Làm Mới";
            this.btnLamMoi.AutoSize = true;
            this.btnLamMoi.TabIndex = 16;
            this.btnLamMoi.UseVisualStyleBackColor = false;
            this.btnLamMoi.Click += new EventHandler(this.btnLamMoi_Click);

            // 
            // pnlRight
            // 
            this.pnlRight.Controls.Add(this.dgvTaiKhoan);
            this.pnlRight.Controls.Add(this.txtTimKiem);
            this.pnlRight.Dock = DockStyle.Fill;
            this.pnlRight.Location = new Point(280, 0);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Padding = new Padding(10);
            this.pnlRight.Size = new Size(720, 600);
            this.pnlRight.TabIndex = 1;

            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Dock = DockStyle.Top;
            this.txtTimKiem.Font = new Font("Segoe UI", 10F);
            this.txtTimKiem.Location = new Point(10, 10);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new Size(700, 25);
            this.txtTimKiem.TabIndex = 0;
            this.txtTimKiem.TextChanged += new EventHandler(this.txtTimKiem_TextChanged);

            // 
            // dgvTaiKhoan
            // 
            this.dgvTaiKhoan.AllowUserToAddRows = false;
            this.dgvTaiKhoan.BackgroundColor = Color.White;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(0, 120, 212);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            this.dgvTaiKhoan.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvTaiKhoan.Dock = DockStyle.Fill;
            this.dgvTaiKhoan.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            this.dgvTaiKhoan.Location = new Point(10, 45);
            this.dgvTaiKhoan.Name = "dgvTaiKhoan";
            this.dgvTaiKhoan.ReadOnly = true;
            this.dgvTaiKhoan.RowHeadersVisible = false;
            this.dgvTaiKhoan.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvTaiKhoan.Size = new Size(700, 545);
            this.dgvTaiKhoan.TabIndex = 1;
            this.dgvTaiKhoan.CellEnter += new DataGridViewCellEventHandler(this.dgvTaiKhoan_CellEnter);

            // 
            // frmTaiKhoan
            // 
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(1000, 600);
            this.Controls.Add(this.pnlRight);
            this.Controls.Add(this.pnlLeft);
            this.Name = "frmTaiKhoan";
            this.Text = "Quan Ly Tai Khoan";
            this.Load += new EventHandler(this.frmTaiKhoan_Load);
            this.pnlLeft.ResumeLayout(false);
            this.pnlLeft.PerformLayout();
            this.pnlRight.ResumeLayout(false);
            this.pnlRight.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTaiKhoan)).EndInit();
            this.ResumeLayout(false);
        }
    }
}
