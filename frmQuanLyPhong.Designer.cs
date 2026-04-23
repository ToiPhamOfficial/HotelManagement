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
        private Button btnThem;
        private Button btnCapNhat;
        private Button btnXoa;
        private Button btnCapNhatTT;
        private Button btnLamMoi;

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
            pnlLeft = new Panel();
            lblHeader = new Label();
            txtMaPhong = new TextBox();
            lblSoPhong = new Label();
            txtSoPhong = new TextBox();
            lblLoaiPhong = new Label();
            cboLoaiPhong = new ComboBox();
            lblTang = new Label();
            numTang = new NumericUpDown();
            lblTrangThai = new Label();
            cboTrangThai = new ComboBox();
            lblMoTa = new Label();
            txtMoTa = new TextBox();
            btnThem = new Button();
            btnCapNhat = new Button();
            btnXoa = new Button();
            btnCapNhatTT = new Button();
            btnLamMoi = new Button();
            pnlRight = new Panel();
            dgvPhong = new DataGridView();
            pnlToolbar = new Panel();
            txtTimKiem = new TextBox();
            cboLocTrangThai = new ComboBox();
            lblTongPhong = new Label();
            ((System.ComponentModel.ISupportInitialize)numTang).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvPhong).BeginInit();
            pnlToolbar.SuspendLayout();
            pnlRight.SuspendLayout();
            pnlLeft.SuspendLayout();
            SuspendLayout();

            AutoScaleDimensions = new SizeF(7F, 15F);
            this.Text = "🏠 Quản Lý Phòng";
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 247, 250);
            ClientSize = new Size(1100, 680);
            Name = "frmQuanLyPhong";
            Text = "🏠 Quản Lý Phòng";

            pnlLeft.BackColor = Color.White;
            pnlLeft.BorderStyle = BorderStyle.FixedSingle;
            pnlLeft.Dock = DockStyle.Left;
            pnlLeft.Padding = new Padding(10);
            pnlLeft.Size = new Size(300, 680);

            lblHeader.Dock = DockStyle.Top;
            lblHeader.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblHeader.ForeColor = Color.FromArgb(0, 120, 212);
            lblHeader.Height = 35;
            lblHeader.Text = "THÔNG TIN PHÒNG";
            lblHeader.TextAlign = ContentAlignment.MiddleLeft;

            txtMaPhong.Visible = false;

            lblSoPhong.AutoSize = true;
            lblSoPhong.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblSoPhong.Location = new Point(10, 45);
            lblSoPhong.Text = "Số Phòng *";

            txtSoPhong.Font = new Font("Segoe UI", 10F);
            txtSoPhong.Location = new Point(10, 67);
            txtSoPhong.Size = new Size(270, 25);

            lblLoaiPhong.AutoSize = true;
            lblLoaiPhong.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblLoaiPhong.Location = new Point(10, 105);
            lblLoaiPhong.Text = "Loại Phòng *";

            cboLoaiPhong.DropDownStyle = ComboBoxStyle.DropDownList;
            cboLoaiPhong.Font = new Font("Segoe UI", 10F);
            cboLoaiPhong.Location = new Point(10, 127);
            cboLoaiPhong.Size = new Size(270, 25);

            lblTang.AutoSize = true;
            lblTang.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTang.Location = new Point(10, 165);
            lblTang.Text = "Tầng";

            numTang.Font = new Font("Segoe UI", 10F);
            numTang.Location = new Point(10, 187);
            numTang.Maximum = new decimal(new int[] { 50, 0, 0, 0 });
            numTang.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numTang.Size = new Size(100, 25);
            numTang.Value = new decimal(new int[] { 1, 0, 0, 0 });

            lblTrangThai.AutoSize = true;
            lblTrangThai.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTrangThai.Location = new Point(10, 225);
            lblTrangThai.Text = "Trạng Thái";

            cboTrangThai.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTrangThai.Font = new Font("Segoe UI", 10F);
            cboTrangThai.Items.AddRange(new object[] { "Trống", "Đang sử dụng", "Đang dọn", "Bảo trì" });
            cboTrangThai.Location = new Point(10, 247);
            cboTrangThai.Size = new Size(270, 25);
            cboTrangThai.SelectedIndex = 0;

            lblMoTa.AutoSize = true;
            lblMoTa.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblMoTa.Location = new Point(10, 285);
            lblMoTa.Text = "Mô Tả";

            txtMoTa.Font = new Font("Segoe UI", 10F);
            txtMoTa.Location = new Point(10, 307);
            txtMoTa.Multiline = true;
            txtMoTa.ScrollBars = ScrollBars.Vertical;
            txtMoTa.Size = new Size(270, 70);

            btnThem.BackColor = Color.FromArgb(39, 174, 96);
            btnThem.Cursor = Cursors.Hand;
            btnThem.FlatStyle = FlatStyle.Flat;
            btnThem.FlatAppearance.BorderSize = 0;
            btnThem.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnThem.ForeColor = Color.White;
            btnThem.Location = new Point(10, 407);
            btnThem.Size = new Size(125, 35);
            btnThem.Text = "➕ Thêm";
            btnThem.AutoSize = true;
            btnThem.Click += btnThem_Click;

            btnCapNhat.BackColor = Color.FromArgb(52, 152, 219);
            btnCapNhat.Cursor = Cursors.Hand;
            btnCapNhat.FlatStyle = FlatStyle.Flat;
            btnCapNhat.FlatAppearance.BorderSize = 0;
            btnCapNhat.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnCapNhat.ForeColor = Color.White;
            btnCapNhat.Location = new Point(145, 407);
            btnCapNhat.Size = new Size(125, 35);
            btnCapNhat.Text = "✏️ Cập Nhật";
            btnCapNhat.AutoSize = true;
            btnCapNhat.Click += btnCapNhat_Click;

            btnXoa.BackColor = Color.FromArgb(231, 76, 60);
            btnXoa.Cursor = Cursors.Hand;
            btnXoa.FlatStyle = FlatStyle.Flat;
            btnXoa.FlatAppearance.BorderSize = 0;
            btnXoa.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnXoa.ForeColor = Color.White;
            btnXoa.Location = new Point(10, 457);
            btnXoa.Size = new Size(125, 35);
            btnXoa.Text = "🗑️ Xóa";
            btnXoa.AutoSize = true;
            btnXoa.Click += btnXoa_Click;

            btnCapNhatTT.BackColor = Color.FromArgb(243, 156, 18);
            btnCapNhatTT.Cursor = Cursors.Hand;
            btnCapNhatTT.FlatStyle = FlatStyle.Flat;
            btnCapNhatTT.FlatAppearance.BorderSize = 0;
            btnCapNhatTT.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnCapNhatTT.ForeColor = Color.White;
            btnCapNhatTT.Location = new Point(145, 457);
            btnCapNhatTT.Size = new Size(125, 35);
            btnCapNhatTT.Text = "🔄 C.Nhật TT";
            btnCapNhatTT.AutoSize = true;
            btnCapNhatTT.Click += btnCapNhatTT_Click;

            btnLamMoi.BackColor = Color.Gray;
            btnLamMoi.Cursor = Cursors.Hand;
            btnLamMoi.FlatStyle = FlatStyle.Flat;
            btnLamMoi.FlatAppearance.BorderSize = 0;
            btnLamMoi.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnLamMoi.ForeColor = Color.White;
            btnLamMoi.Location = new Point(10, 507);
            btnLamMoi.Size = new Size(125, 35);
            btnLamMoi.Text = "🔃 Làm Mới";
            btnLamMoi.AutoSize = true;
            btnLamMoi.Click += btnLamMoi_Click;

            pnlLeft.Controls.Add(lblHeader);
            pnlLeft.Controls.Add(txtMaPhong);
            pnlLeft.Controls.Add(lblSoPhong);
            pnlLeft.Controls.Add(txtSoPhong);
            pnlLeft.Controls.Add(lblLoaiPhong);
            pnlLeft.Controls.Add(cboLoaiPhong);
            pnlLeft.Controls.Add(lblTang);
            pnlLeft.Controls.Add(numTang);
            pnlLeft.Controls.Add(lblTrangThai);
            pnlLeft.Controls.Add(cboTrangThai);
            pnlLeft.Controls.Add(lblMoTa);
            pnlLeft.Controls.Add(txtMoTa);
            pnlLeft.Controls.Add(btnThem);
            pnlLeft.Controls.Add(btnCapNhat);
            pnlLeft.Controls.Add(btnXoa);
            pnlLeft.Controls.Add(btnCapNhatTT);
            pnlLeft.Controls.Add(btnLamMoi);

            pnlRight.Dock = DockStyle.Fill;
            pnlRight.Padding = new Padding(10);

            pnlToolbar.BackColor = Color.White;
            pnlToolbar.Dock = DockStyle.Top;
            pnlToolbar.Height = 45;

            txtTimKiem.Font = new Font("Segoe UI", 10F);
            txtTimKiem.Location = new Point(5, 10);

            txtTimKiem.Size = new Size(200, 25);
            txtTimKiem.TextChanged += txtTimKiem_TextChanged;

            cboLocTrangThai.DropDownStyle = ComboBoxStyle.DropDownList;
            cboLocTrangThai.Font = new Font("Segoe UI", 10F);
            cboLocTrangThai.Items.AddRange(new object[] { "Tất cả", "Trống", "Đang sử dụng", "Đang dọn", "Bảo trì" });
            cboLocTrangThai.Location = new Point(215, 10);
            cboLocTrangThai.Size = new Size(150, 25);
            cboLocTrangThai.SelectedIndex = 0;
            cboLocTrangThai.SelectedIndexChanged += cboLocTrangThai_SelectedIndexChanged;

            lblTongPhong.AutoSize = true;
            lblTongPhong.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblTongPhong.ForeColor = Color.FromArgb(0, 120, 212);
            lblTongPhong.Location = new Point(380, 13);

            pnlToolbar.Controls.Add(txtTimKiem);
            pnlToolbar.Controls.Add(cboLocTrangThai);
            pnlToolbar.Controls.Add(lblTongPhong);

            dgvPhong.AllowUserToAddRows = false;
            dgvPhong.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dgvPhong.BackgroundColor = Color.White;
            dgvPhong.BorderStyle = BorderStyle.None;
            dgvPhong.ColumnHeadersHeight = 35;
            dgvPhong.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgvPhong.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 120, 212);
            dgvPhong.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvPhong.Dock = DockStyle.Fill;
            dgvPhong.EnableHeadersVisualStyles = false;
            dgvPhong.Font = new Font("Segoe UI", 10F);
            dgvPhong.MultiSelect = false;
            dgvPhong.ReadOnly = true;
            dgvPhong.RowHeadersVisible = false;
            dgvPhong.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPhong.SelectionChanged += dgvPhong_SelectionChanged;

            pnlRight.Controls.Add(dgvPhong);
            pnlRight.Controls.Add(pnlToolbar);

            Controls.Add(pnlRight);
            Controls.Add(pnlLeft);
            Load += frmQuanLyPhong_Load;

            ((System.ComponentModel.ISupportInitialize)numTang).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvPhong).EndInit();
            pnlToolbar.ResumeLayout(false);
            pnlToolbar.PerformLayout();
            pnlRight.ResumeLayout(false);
            pnlLeft.ResumeLayout(false);
            pnlLeft.PerformLayout();
            ResumeLayout(false);
        }
    }
}
