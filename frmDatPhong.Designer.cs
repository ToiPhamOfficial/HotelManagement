using System;
using System.Drawing;
using System.Windows.Forms;

namespace HotelManagement
{
    public partial class frmDatPhong
    {
        private System.ComponentModel.IContainer components = null;

        private DataGridView dgvPhongTrong;
        private DateTimePicker dtpNgayNhan;
        private DateTimePicker dtpNgayTra;
        private RadioButton rdoTheoNgay;
        private RadioButton rdoTheoGio;
        private TextBox txtTimKH;
        private TextBox txtMaKH;
        private TextBox txtTenKH;
        private TextBox txtCCCD;
        private TextBox txtSDT;
        private Button btnTimPhong;
        private Button btnTimKH;
        private Button btnDatPhong;
        private Button btnThemKH;
        private Label lblTongTien;
        private Label lblSoNgay;

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
            var pnlTop = new Panel();
            var lblTitle = new Label();
            var lblNgayNhan = new Label();
            var lblNgayTra = new Label();

            var pnlMid = new Panel();
            var lblPhong = new Label();

            var pnlBot = new Panel();
            var lblTimKH = new Label();
            var lblTenKH = new Label();
            var lblCCCD = new Label();
            var lblSDT = new Label();

            SuspendLayout();

            AutoScaleDimensions = new SizeF(7F, 15F);
            this.Text = "📥 Đặt Phòng Mới";
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 247, 250);
            ClientSize = new Size(1000, 650);
            Name = "frmDatPhong";
            Load += frmDatPhong_Load;

            pnlTop.BackColor = Color.White;
            pnlTop.BorderStyle = BorderStyle.FixedSingle;
            pnlTop.Dock = DockStyle.Top;
            pnlTop.Height = 110;
            pnlTop.Padding = new Padding(10);

            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(0, 120, 212);
            lblTitle.Location = new Point(10, 5);
            lblTitle.Text = "THÔNG TIN ĐẶT PHÒNG";

            lblNgayNhan.AutoSize = true;
            lblNgayNhan.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblNgayNhan.Location = new Point(10, 35);
            lblNgayNhan.Text = "Ngày nhận:";

            dtpNgayNhan = new DateTimePicker();
            dtpNgayNhan.CustomFormat = "dd/MM/yyyy HH:mm";
            dtpNgayNhan.Format = DateTimePickerFormat.Custom;
            dtpNgayNhan.Location = new Point(90, 32);
            dtpNgayNhan.MinDate = DateTime.Today;
            dtpNgayNhan.ShowUpDown = false;
            dtpNgayNhan.Size = new Size(180, 23);
            dtpNgayNhan.Value = DateTime.Now;
            dtpNgayNhan.ValueChanged += dtpNgayNhan_ValueChanged;

            lblNgayTra.AutoSize = true;
            lblNgayTra.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblNgayTra.Location = new Point(290, 35);
            lblNgayTra.Text = "Ngày trả:";

            dtpNgayTra = new DateTimePicker();
            dtpNgayTra.CustomFormat = "dd/MM/yyyy HH:mm";
            dtpNgayTra.Format = DateTimePickerFormat.Custom;
            dtpNgayTra.Location = new Point(365, 32);
            dtpNgayTra.Size = new Size(180, 23);
            dtpNgayTra.Value = DateTime.Now.AddDays(1);
            dtpNgayTra.ValueChanged += dtpNgayTra_ValueChanged;

            rdoTheoNgay = new RadioButton();
            rdoTheoNgay.AutoSize = true;
            rdoTheoNgay.Checked = true;
            rdoTheoNgay.Location = new Point(560, 35);
            rdoTheoNgay.Text = "Theo Ngày";
            rdoTheoNgay.CheckedChanged += rdoTheoNgay_CheckedChanged;

            rdoTheoGio = new RadioButton();
            rdoTheoGio.AutoSize = true;
            rdoTheoGio.Location = new Point(650, 35);
            rdoTheoGio.Text = "Theo Giờ";
            rdoTheoGio.CheckedChanged += rdoTheoGio_CheckedChanged;

            btnTimPhong = new Button();
            btnTimPhong.BackColor = Color.FromArgb(52, 152, 219);
            btnTimPhong.Cursor = Cursors.Hand;
            btnTimPhong.FlatStyle = FlatStyle.Flat;
            btnTimPhong.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnTimPhong.ForeColor = Color.White;
            btnTimPhong.Location = new Point(750, 28);
            btnTimPhong.Size = new Size(160, 35);
            btnTimPhong.Text = "🔍 Tìm Phòng Trống";
            btnTimPhong.AutoSize = true;
            btnTimPhong.Click += btnTimPhong_Click;

            lblSoNgay = new Label();
            lblSoNgay.AutoSize = true;
            lblSoNgay.Font = new Font("Segoe UI", 9F);
            lblSoNgay.ForeColor = Color.Gray;
            lblSoNgay.Location = new Point(10, 78);

            pnlTop.Controls.Add(lblTitle);
            pnlTop.Controls.Add(lblNgayNhan);
            pnlTop.Controls.Add(dtpNgayNhan);
            pnlTop.Controls.Add(lblNgayTra);
            pnlTop.Controls.Add(dtpNgayTra);
            pnlTop.Controls.Add(rdoTheoNgay);
            pnlTop.Controls.Add(rdoTheoGio);
            pnlTop.Controls.Add(btnTimPhong);
            pnlTop.Controls.Add(lblSoNgay);

            pnlMid.Dock = DockStyle.Top;
            pnlMid.Height = 220;
            pnlMid.Padding = new Padding(5);

            lblPhong.Dock = DockStyle.Top;
            lblPhong.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblPhong.ForeColor = Color.FromArgb(0, 120, 212);
            lblPhong.Height = 28;
            lblPhong.Text = "DANH SÁCH PHÒNG TRỐNG";

            dgvPhongTrong = new DataGridView();
            dgvPhongTrong.AllowUserToAddRows = false;
            dgvPhongTrong.BackgroundColor = Color.White;
            dgvPhongTrong.ColumnHeadersHeight = 30;
            dgvPhongTrong.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 120, 212);
            dgvPhongTrong.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvPhongTrong.Dock = DockStyle.Fill;
            dgvPhongTrong.Font = new Font("Segoe UI", 10F);
            dgvPhongTrong.ReadOnly = true;
            dgvPhongTrong.RowHeadersVisible = false;
            dgvPhongTrong.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPhongTrong.SelectionChanged += dgvPhongTrong_SelectionChanged;

            pnlMid.Controls.Add(dgvPhongTrong);
            pnlMid.Controls.Add(lblPhong);

            pnlBot.Dock = DockStyle.Fill;
            pnlBot.Padding = new Padding(10);

            lblTimKH.AutoSize = true;
            lblTimKH.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTimKH.Location = new Point(5, 5);
            lblTimKH.Text = "CCCD/SĐT Khách Hàng:";

            txtTimKH = new TextBox();
            txtTimKH.Font = new Font("Segoe UI", 10F);
            txtTimKH.Location = new Point(5, 25);
            txtTimKH.Size = new Size(220, 25);

            btnTimKH = new Button();
            btnTimKH.BackColor = Color.FromArgb(52, 152, 219);
            btnTimKH.Cursor = Cursors.Hand;
            btnTimKH.FlatStyle = FlatStyle.Flat;
            btnTimKH.ForeColor = Color.White;
            btnTimKH.Location = new Point(235, 23);
            btnTimKH.Size = new Size(80, 30);
            btnTimKH.Text = "🔍 Tìm";
            btnTimKH.AutoSize = true;
            btnTimKH.Click += btnTimKH_Click;

            btnThemKH = new Button();
            btnThemKH.BackColor = Color.FromArgb(39, 174, 96);
            btnThemKH.Cursor = Cursors.Hand;
            btnThemKH.FlatStyle = FlatStyle.Flat;
            btnThemKH.ForeColor = Color.White;
            btnThemKH.Location = new Point(325, 23);
            btnThemKH.Size = new Size(90, 30);
            btnThemKH.Text = "➕ KH Mới";
            btnThemKH.AutoSize = true;
            btnThemKH.Click += btnThemKH_Click;

            txtMaKH = new TextBox();
            txtMaKH.Location = new Point(5, 65);
            txtMaKH.Visible = false;

            lblTenKH.AutoSize = true;
            lblTenKH.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTenKH.Location = new Point(5, 68);
            lblTenKH.Text = "Họ Tên:";

            txtTenKH = new TextBox();
            txtTenKH.BackColor = Color.FromArgb(240, 240, 240);
            txtTenKH.Font = new Font("Segoe UI", 10F);
            txtTenKH.Location = new Point(60, 65);
            txtTenKH.ReadOnly = true;
            txtTenKH.Size = new Size(200, 25);

            lblCCCD.AutoSize = true;
            lblCCCD.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblCCCD.Location = new Point(275, 68);
            lblCCCD.Text = "CCCD:";

            txtCCCD = new TextBox();
            txtCCCD.BackColor = Color.FromArgb(240, 240, 240);
            txtCCCD.Font = new Font("Segoe UI", 10F);
            txtCCCD.Location = new Point(315, 65);
            txtCCCD.ReadOnly = true;
            txtCCCD.Size = new Size(160, 25);

            lblSDT.AutoSize = true;
            lblSDT.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblSDT.Location = new Point(490, 68);
            lblSDT.Text = "SĐT:";

            txtSDT = new TextBox();
            txtSDT.BackColor = Color.FromArgb(240, 240, 240);
            txtSDT.Font = new Font("Segoe UI", 10F);
            txtSDT.Location = new Point(520, 65);
            txtSDT.ReadOnly = true;
            txtSDT.Size = new Size(130, 25);

            lblTongTien = new Label();
            lblTongTien.AutoSize = true;
            lblTongTien.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblTongTien.ForeColor = Color.FromArgb(231, 76, 60);
            lblTongTien.Location = new Point(5, 110);
            lblTongTien.Text = "Tổng tiền dự kiến: ---";

            btnDatPhong = new Button();
            btnDatPhong.BackColor = Color.FromArgb(39, 174, 96);
            btnDatPhong.Cursor = Cursors.Hand;
            btnDatPhong.FlatStyle = FlatStyle.Flat;
            btnDatPhong.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnDatPhong.ForeColor = Color.White;
            btnDatPhong.Location = new Point(5, 148);
            btnDatPhong.Size = new Size(250, 45);
            btnDatPhong.Text = "✅  XÁC NHẬN ĐẶT PHÒNG";
            btnDatPhong.AutoSize = true;
            btnDatPhong.Click += btnDatPhong_Click;

            pnlBot.Controls.Add(lblTimKH);
            pnlBot.Controls.Add(txtTimKH);
            pnlBot.Controls.Add(btnTimKH);
            pnlBot.Controls.Add(btnThemKH);
            pnlBot.Controls.Add(txtMaKH);
            pnlBot.Controls.Add(lblTenKH);
            pnlBot.Controls.Add(txtTenKH);
            pnlBot.Controls.Add(lblCCCD);
            pnlBot.Controls.Add(txtCCCD);
            pnlBot.Controls.Add(lblSDT);
            pnlBot.Controls.Add(txtSDT);
            pnlBot.Controls.Add(lblTongTien);
            pnlBot.Controls.Add(btnDatPhong);

            Controls.Add(pnlBot);
            Controls.Add(pnlMid);
            Controls.Add(pnlTop);

            ResumeLayout(false);
        }
    }
}
