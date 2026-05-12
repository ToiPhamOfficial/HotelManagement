using System;
using System.Drawing;
using System.Windows.Forms;

namespace HotelManagement
{
    public partial class frmKhachHang
    {
        private System.ComponentModel.IContainer components = null;

        private DataGridView dgv;
        private TextBox txtHoTen;
        private TextBox txtCCCD;
        private TextBox txtSDT;
        private TextBox txtEmail;
        private TextBox txtDiaChi;
        private TextBox txtTimKiem;
        private ComboBox cboGioiTinh;
        private DateTimePicker dtpNgaySinh;
        private Button btnThem;
        private Button btnCapNhat;
        private Button btnXoa;
        private Button btnLuu;
        private Button btnHuy;
        private Button btnLamMoi;
        private Label lblMaKH;

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
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            pnlLeft = new Panel();
            lblMaKH = new Label();
            txtMaKH = new TextBox();
            lblHoTen = new Label();
            txtHoTen = new TextBox();
            lblCCCD = new Label();
            txtCCCD = new TextBox();
            lblSDT = new Label();
            txtSDT = new TextBox();
            lblEmail = new Label();
            txtEmail = new TextBox();
            lblDiaChi = new Label();
            txtDiaChi = new TextBox();
            lblGioiTinh = new Label();
            cboGioiTinh = new ComboBox();
            lblNgaySinh = new Label();
            dtpNgaySinh = new DateTimePicker();
            btnThem = new Button();
            btnCapNhat = new Button();
            btnXoa = new Button();
            btnLuu = new Button();
            btnHuy = new Button();
            btnLamMoi = new Button();
            pnlRight = new Panel();
            dgv = new DataGridView();
            txtTimKiem = new TextBox();
            pnlLeft.SuspendLayout();
            pnlRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgv).BeginInit();
            SuspendLayout();
            // 
            // pnlLeft
            // 
            pnlLeft.BackColor = Color.White;
            pnlLeft.BorderStyle = BorderStyle.FixedSingle;
            pnlLeft.Controls.Add(lblMaKH);
            pnlLeft.Controls.Add(txtMaKH);
            pnlLeft.Controls.Add(lblHoTen);
            pnlLeft.Controls.Add(txtHoTen);
            pnlLeft.Controls.Add(lblCCCD);
            pnlLeft.Controls.Add(txtCCCD);
            pnlLeft.Controls.Add(lblSDT);
            pnlLeft.Controls.Add(txtSDT);
            pnlLeft.Controls.Add(lblEmail);
            pnlLeft.Controls.Add(txtEmail);
            pnlLeft.Controls.Add(lblDiaChi);
            pnlLeft.Controls.Add(txtDiaChi);
            pnlLeft.Controls.Add(lblGioiTinh);
            pnlLeft.Controls.Add(cboGioiTinh);
            pnlLeft.Controls.Add(lblNgaySinh);
            pnlLeft.Controls.Add(dtpNgaySinh);
            pnlLeft.Controls.Add(btnThem);
            pnlLeft.Controls.Add(btnCapNhat);
            pnlLeft.Controls.Add(btnXoa);
            pnlLeft.Controls.Add(btnLuu);
            pnlLeft.Controls.Add(btnHuy);
            pnlLeft.Controls.Add(btnLamMoi);
            pnlLeft.Dock = DockStyle.Left;
            pnlLeft.Location = new Point(0, 0);
            pnlLeft.Name = "pnlLeft";
            pnlLeft.Padding = new Padding(10);
            pnlLeft.Size = new Size(280, 600);
            pnlLeft.TabIndex = 1;
            // 
            // lblMaKH
            // 
            lblMaKH.AutoSize = true;
            lblMaKH.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblMaKH.Location = new Point(5, 10);
            lblMaKH.Name = "lblMaKH";
            lblMaKH.Size = new Size(100, 15);
            lblMaKH.TabIndex = 0;
            lblMaKH.Text = "Mã Khách Hàng";
            // 
            // txtMaKH
            // 
            txtMaKH.Font = new Font("Segoe UI", 10F);
            txtMaKH.Location = new Point(5, 28);
            txtMaKH.Name = "txtMaKH";
            txtMaKH.Enabled = false;
            txtMaKH.Size = new Size(255, 25);
            txtMaKH.TabIndex = 1;
            // 
            // lblHoTen
            // 
            lblHoTen.AutoSize = true;
            lblHoTen.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblHoTen.Location = new Point(5, 68);
            lblHoTen.Name = "lblHoTen";
            lblHoTen.Size = new Size(54, 15);
            lblHoTen.TabIndex = 2;
            lblHoTen.Text = "Họ Tên *";
            // 
            // txtHoTen
            // 
            txtHoTen.Font = new Font("Segoe UI", 10F);
            txtHoTen.Location = new Point(5, 86);
            txtHoTen.Name = "txtHoTen";
            txtHoTen.Size = new Size(255, 25);
            txtHoTen.TabIndex = 3;
            // 
            // lblCCCD
            // 
            lblCCCD.AutoSize = true;
            lblCCCD.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblCCCD.Location = new Point(5, 126);
            lblCCCD.Name = "lblCCCD";
            lblCCCD.Size = new Size(100, 15);
            lblCCCD.TabIndex = 4;
            lblCCCD.Text = "CCCD/Hộ Chiếu *";
            // 
            // txtCCCD
            // 
            txtCCCD.Font = new Font("Segoe UI", 10F);
            txtCCCD.Location = new Point(5, 144);
            txtCCCD.Name = "txtCCCD";
            txtCCCD.Size = new Size(255, 25);
            txtCCCD.TabIndex = 5;
            // 
            // lblSDT
            // 
            lblSDT.AutoSize = true;
            lblSDT.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblSDT.Location = new Point(5, 184);
            lblSDT.Name = "lblSDT";
            lblSDT.Size = new Size(91, 15);
            lblSDT.TabIndex = 6;
            lblSDT.Text = "Số Điện Thoại *";
            // 
            // txtSDT
            // 
            txtSDT.Font = new Font("Segoe UI", 10F);
            txtSDT.Location = new Point(5, 202);
            txtSDT.Name = "txtSDT";
            txtSDT.Size = new Size(255, 25);
            txtSDT.TabIndex = 7;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblEmail.Location = new Point(5, 242);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(36, 15);
            lblEmail.TabIndex = 8;
            lblEmail.Text = "Email";
            // 
            // txtEmail
            // 
            txtEmail.Font = new Font("Segoe UI", 10F);
            txtEmail.Location = new Point(5, 260);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(255, 25);
            txtEmail.TabIndex = 9;
            // 
            // lblDiaChi
            // 
            lblDiaChi.AutoSize = true;
            lblDiaChi.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblDiaChi.Location = new Point(5, 300);
            lblDiaChi.Name = "lblDiaChi";
            lblDiaChi.Size = new Size(45, 15);
            lblDiaChi.TabIndex = 10;
            lblDiaChi.Text = "Địa Chỉ";
            // 
            // txtDiaChi
            // 
            txtDiaChi.Font = new Font("Segoe UI", 10F);
            txtDiaChi.Location = new Point(5, 318);
            txtDiaChi.Name = "txtDiaChi";
            txtDiaChi.Size = new Size(255, 25);
            txtDiaChi.TabIndex = 11;
            // 
            // lblGioiTinh
            // 
            lblGioiTinh.AutoSize = true;
            lblGioiTinh.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblGioiTinh.Location = new Point(5, 358);
            lblGioiTinh.Name = "lblGioiTinh";
            lblGioiTinh.Size = new Size(57, 15);
            lblGioiTinh.TabIndex = 12;
            lblGioiTinh.Text = "Giới Tính";
            // 
            // cboGioiTinh
            // 
            cboGioiTinh.DropDownStyle = ComboBoxStyle.DropDownList;
            cboGioiTinh.Font = new Font("Segoe UI", 10F);
            cboGioiTinh.Items.AddRange(new object[] { "Nam", "Nữ", "Khác" });
            cboGioiTinh.Location = new Point(5, 376);
            cboGioiTinh.Name = "cboGioiTinh";
            cboGioiTinh.Size = new Size(255, 25);
            cboGioiTinh.TabIndex = 13;
            // 
            // lblNgaySinh
            // 
            lblNgaySinh.AutoSize = true;
            lblNgaySinh.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblNgaySinh.Location = new Point(5, 416);
            lblNgaySinh.Name = "lblNgaySinh";
            lblNgaySinh.Size = new Size(62, 15);
            lblNgaySinh.TabIndex = 14;
            lblNgaySinh.Text = "Ngày Sinh";
            // 
            // dtpNgaySinh
            // 
            dtpNgaySinh.Format = DateTimePickerFormat.Short;
            dtpNgaySinh.Location = new Point(5, 434);
            dtpNgaySinh.Name = "dtpNgaySinh";
            dtpNgaySinh.Size = new Size(255, 23);
            dtpNgaySinh.TabIndex = 15;
            // 
            // btnThem
            // 
            btnThem.BackColor = Color.FromArgb(39, 174, 96);
            btnThem.Cursor = Cursors.Hand;
            btnThem.FlatStyle = FlatStyle.Flat;
            btnThem.Font = new Font("Segoe UI", 9F);
            btnThem.ForeColor = Color.White;
            btnThem.Location = new Point(5, 473);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(120, 33);
            btnThem.TabIndex = 16;
            btnThem.Text = "Thêm";
            btnThem.AutoSize = true;
            btnThem.UseVisualStyleBackColor = false;
            btnThem.Click += btnThem_Click;
            // 
            // btnCapNhat
            // 
            btnCapNhat.BackColor = Color.FromArgb(52, 152, 219);
            btnCapNhat.Cursor = Cursors.Hand;
            btnCapNhat.FlatStyle = FlatStyle.Flat;
            btnCapNhat.Font = new Font("Segoe UI", 9F);
            btnCapNhat.ForeColor = Color.White;
            btnCapNhat.Location = new Point(133, 473);
            btnCapNhat.Name = "btnCapNhat";
            btnCapNhat.Size = new Size(120, 33);
            btnCapNhat.TabIndex = 17;
            btnCapNhat.Text = "Sửa";
            btnCapNhat.AutoSize = true;
            btnCapNhat.UseVisualStyleBackColor = false;
            btnCapNhat.Click += btnCapNhat_Click;
            // 
            // btnXoa
            // 
            btnXoa.BackColor = Color.FromArgb(231, 76, 60);
            btnXoa.Cursor = Cursors.Hand;
            btnXoa.FlatStyle = FlatStyle.Flat;
            btnXoa.Font = new Font("Segoe UI", 9F);
            btnXoa.ForeColor = Color.White;
            btnXoa.Location = new Point(5, 515);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(120, 33);
            btnXoa.TabIndex = 18;
            btnXoa.Text = "Xóa";
            btnXoa.AutoSize = true;
            btnXoa.UseVisualStyleBackColor = false;
            btnXoa.Click += btnXoa_Click;
            // 
            // btnLuu
            //
            btnLuu.BackColor = Color.FromArgb(39, 174, 96);
            btnLuu.Cursor = Cursors.Hand;
            btnLuu.FlatStyle = FlatStyle.Flat;
            btnLuu.Font = new Font("Segoe UI", 9F);
            btnLuu.ForeColor = Color.White;
            btnLuu.Location = new Point(5, 557);
            btnLuu.Name = "btnLuu";
            btnLuu.Size = new Size(120, 33);
            btnLuu.TabIndex = 20;
            btnLuu.Text = "Lưu";
            btnLuu.AutoSize = true;
            btnLuu.Enabled = false;
            btnLuu.UseVisualStyleBackColor = false;
            btnLuu.Click += btnLuu_Click;
            // 
            // btnHuy
            //
            btnHuy.BackColor = Color.Gray;
            btnHuy.Cursor = Cursors.Hand;
            btnHuy.FlatStyle = FlatStyle.Flat;
            btnHuy.Font = new Font("Segoe UI", 9F);
            btnHuy.ForeColor = Color.White;
            btnHuy.Location = new Point(133, 557);
            btnHuy.Name = "btnHuy";
            btnHuy.Size = new Size(120, 33);
            btnHuy.TabIndex = 21;
            btnHuy.Text = "Không lưu";
            btnHuy.AutoSize = true;
            btnHuy.Enabled = false;
            btnHuy.UseVisualStyleBackColor = false;
            btnHuy.Click += btnHuy_Click;
            // 
            // btnLamMoi
            // 
            btnLamMoi.BackColor = Color.Gray;
            btnLamMoi.Cursor = Cursors.Hand;
            btnLamMoi.FlatStyle = FlatStyle.Flat;
            btnLamMoi.Font = new Font("Segoe UI", 9F);
            btnLamMoi.ForeColor = Color.White;
            btnLamMoi.Location = new Point(133, 515);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(120, 33);
            btnLamMoi.TabIndex = 19;
            btnLamMoi.Text = "Làm Mới";
            btnLamMoi.AutoSize = true;
            btnLamMoi.UseVisualStyleBackColor = false;
            btnLamMoi.Click += btnLamMoi_Click;
            // 
            // pnlRight
            // 
            pnlRight.Controls.Add(dgv);
            pnlRight.Controls.Add(txtTimKiem);
            pnlRight.Dock = DockStyle.Fill;
            pnlRight.Location = new Point(280, 0);
            pnlRight.Name = "pnlRight";
            pnlRight.Padding = new Padding(5);
            pnlRight.Size = new Size(720, 600);
            pnlRight.TabIndex = 0;
            // 
            // dgv
            // 
            dgv.AllowUserToAddRows = false;
            dgv.BackgroundColor = Color.White;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(0, 120, 212);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 10F);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgv.Dock = DockStyle.Fill;
            dgv.Font = new Font("Segoe UI", 10F);
            dgv.Location = new Point(5, 30);
            dgv.Name = "dgv";
            dgv.ReadOnly = true;
            dgv.RowHeadersVisible = false;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.CellEnter += dgv_CellEnter;
            dgv.Size = new Size(710, 565);
            dgv.TabIndex = 0;
            // 
            // txtTimKiem
            // 
            txtTimKiem.Dock = DockStyle.Top;
            txtTimKiem.Font = new Font("Segoe UI", 10F);
            txtTimKiem.Location = new Point(5, 5);
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.Size = new Size(710, 25);
            txtTimKiem.TabIndex = 1;
            txtTimKiem.TextChanged += txtTimKiem_TextChanged;
            // 
            // frmKhachHang
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            this.Text = "Quản Lý Khách Hàng";
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1000, 600);
            Controls.Add(pnlRight);
            Controls.Add(pnlLeft);
            Name = "frmKhachHang";
            this.Load += new System.EventHandler(this.frmKhachHang_Load);
            pnlLeft.ResumeLayout(false);
            pnlLeft.PerformLayout();
            pnlRight.ResumeLayout(false);
            pnlRight.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgv).EndInit();
            ResumeLayout(false);
        }

        private Panel pnlLeft;
        private Label lblHoTen;
        private Label lblCCCD;
        private Label lblSDT;
        private Label lblEmail;
        private Label lblDiaChi;
        private Label lblGioiTinh;
        private Label lblNgaySinh;
        private Panel pnlRight;
        private TextBox txtMaKH;
    }
}
