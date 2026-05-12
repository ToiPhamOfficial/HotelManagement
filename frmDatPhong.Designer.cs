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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblNgayNhan = new System.Windows.Forms.Label();
            this.dtpNgayNhan = new System.Windows.Forms.DateTimePicker();
            this.lblNgayTra = new System.Windows.Forms.Label();
            this.dtpNgayTra = new System.Windows.Forms.DateTimePicker();
            this.rdoTheoNgay = new System.Windows.Forms.RadioButton();
            this.rdoTheoGio = new System.Windows.Forms.RadioButton();
            this.btnTimPhong = new System.Windows.Forms.Button();
            this.lblSoNgay = new System.Windows.Forms.Label();
            this.pnlMid = new System.Windows.Forms.Panel();
            this.dgvPhongTrong = new System.Windows.Forms.DataGridView();
            this.lblPhong = new System.Windows.Forms.Label();
            this.pnlBot = new System.Windows.Forms.Panel();
            this.lblTimKH = new System.Windows.Forms.Label();
            this.txtTimKH = new System.Windows.Forms.TextBox();
            this.btnTimKH = new System.Windows.Forms.Button();
            this.btnThemKH = new System.Windows.Forms.Button();
            this.txtMaKH = new System.Windows.Forms.TextBox();
            this.lblTenKH = new System.Windows.Forms.Label();
            this.txtTenKH = new System.Windows.Forms.TextBox();
            this.lblCCCD = new System.Windows.Forms.Label();
            this.txtCCCD = new System.Windows.Forms.TextBox();
            this.lblSDT = new System.Windows.Forms.Label();
            this.txtSDT = new System.Windows.Forms.TextBox();
            this.lblTongTien = new System.Windows.Forms.Label();
            this.btnDatPhong = new System.Windows.Forms.Button();
            this.pnlTop.SuspendLayout();
            this.pnlMid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhongTrong)).BeginInit();
            this.pnlBot.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.White;
            this.pnlTop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTop.Controls.Add(this.lblTitle);
            this.pnlTop.Controls.Add(this.lblNgayNhan);
            this.pnlTop.Controls.Add(this.dtpNgayNhan);
            this.pnlTop.Controls.Add(this.lblNgayTra);
            this.pnlTop.Controls.Add(this.dtpNgayTra);
            this.pnlTop.Controls.Add(this.rdoTheoNgay);
            this.pnlTop.Controls.Add(this.rdoTheoGio);
            this.pnlTop.Controls.Add(this.btnTimPhong);
            this.pnlTop.Controls.Add(this.lblSoNgay);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Padding = new System.Windows.Forms.Padding(9, 9, 9, 9);
            this.pnlTop.Size = new System.Drawing.Size(857, 96);
            this.pnlTop.TabIndex = 2;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(212)))));
            this.lblTitle.Location = new System.Drawing.Point(9, 4);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(196, 21);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "THÔNG TIN ĐẶT PHÒNG";
            // 
            // lblNgayNhan
            // 
            this.lblNgayNhan.AutoSize = true;
            this.lblNgayNhan.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblNgayNhan.Location = new System.Drawing.Point(9, 30);
            this.lblNgayNhan.Name = "lblNgayNhan";
            this.lblNgayNhan.Size = new System.Drawing.Size(68, 15);
            this.lblNgayNhan.TabIndex = 1;
            this.lblNgayNhan.Text = "Ngày nhận:";
            // 
            // dtpNgayNhan
            // 
            this.dtpNgayNhan.CustomFormat = "dd/MM/yyyy HH:mm";
            this.dtpNgayNhan.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNgayNhan.Location = new System.Drawing.Point(77, 28);
            this.dtpNgayNhan.MinDate = new System.DateTime(2026, 5, 11, 0, 0, 0, 0);
            this.dtpNgayNhan.Name = "dtpNgayNhan";
            this.dtpNgayNhan.Size = new System.Drawing.Size(155, 20);
            this.dtpNgayNhan.TabIndex = 2;
            this.dtpNgayNhan.Value = new System.DateTime(2026, 5, 11, 22, 47, 53, 176);
            this.dtpNgayNhan.ValueChanged += new System.EventHandler(this.dtpNgayNhan_ValueChanged);
            // 
            // lblNgayTra
            // 
            this.lblNgayTra.AutoSize = true;
            this.lblNgayTra.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblNgayTra.Location = new System.Drawing.Point(249, 30);
            this.lblNgayTra.Name = "lblNgayTra";
            this.lblNgayTra.Size = new System.Drawing.Size(57, 15);
            this.lblNgayTra.TabIndex = 3;
            this.lblNgayTra.Text = "Ngày trả:";
            // 
            // dtpNgayTra
            // 
            this.dtpNgayTra.CustomFormat = "dd/MM/yyyy HH:mm";
            this.dtpNgayTra.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNgayTra.Location = new System.Drawing.Point(313, 28);
            this.dtpNgayTra.Name = "dtpNgayTra";
            this.dtpNgayTra.Size = new System.Drawing.Size(155, 20);
            this.dtpNgayTra.TabIndex = 4;
            this.dtpNgayTra.Value = new System.DateTime(2026, 5, 12, 22, 47, 53, 179);
            this.dtpNgayTra.ValueChanged += new System.EventHandler(this.dtpNgayTra_ValueChanged);
            // 
            // rdoTheoNgay
            // 
            this.rdoTheoNgay.AutoSize = true;
            this.rdoTheoNgay.Checked = true;
            this.rdoTheoNgay.Location = new System.Drawing.Point(480, 30);
            this.rdoTheoNgay.Name = "rdoTheoNgay";
            this.rdoTheoNgay.Size = new System.Drawing.Size(78, 17);
            this.rdoTheoNgay.TabIndex = 5;
            this.rdoTheoNgay.TabStop = true;
            this.rdoTheoNgay.Text = "Theo Ngày";
            this.rdoTheoNgay.CheckedChanged += new System.EventHandler(this.rdoTheoNgay_CheckedChanged);
            // 
            // rdoTheoGio
            // 
            this.rdoTheoGio.AutoSize = true;
            this.rdoTheoGio.Location = new System.Drawing.Point(557, 30);
            this.rdoTheoGio.Name = "rdoTheoGio";
            this.rdoTheoGio.Size = new System.Drawing.Size(69, 17);
            this.rdoTheoGio.TabIndex = 6;
            this.rdoTheoGio.Text = "Theo Giờ";
            this.rdoTheoGio.CheckedChanged += new System.EventHandler(this.rdoTheoGio_CheckedChanged);
            // 
            // btnTimPhong
            // 
            this.btnTimPhong.AutoSize = true;
            this.btnTimPhong.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnTimPhong.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTimPhong.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTimPhong.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnTimPhong.ForeColor = System.Drawing.Color.White;
            this.btnTimPhong.Location = new System.Drawing.Point(643, 24);
            this.btnTimPhong.Name = "btnTimPhong";
            this.btnTimPhong.Size = new System.Drawing.Size(160, 31);
            this.btnTimPhong.TabIndex = 7;
            this.btnTimPhong.Text = "🔍 Tìm Phòng Trống";
            this.btnTimPhong.UseVisualStyleBackColor = false;
            this.btnTimPhong.Click += new System.EventHandler(this.btnTimPhong_Click);
            // 
            // lblSoNgay
            // 
            this.lblSoNgay.AutoSize = true;
            this.lblSoNgay.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSoNgay.ForeColor = System.Drawing.Color.Gray;
            this.lblSoNgay.Location = new System.Drawing.Point(9, 68);
            this.lblSoNgay.Name = "lblSoNgay";
            this.lblSoNgay.Size = new System.Drawing.Size(0, 15);
            this.lblSoNgay.TabIndex = 8;
            // 
            // pnlMid
            // 
            this.pnlMid.Controls.Add(this.dgvPhongTrong);
            this.pnlMid.Controls.Add(this.lblPhong);
            this.pnlMid.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlMid.Location = new System.Drawing.Point(0, 96);
            this.pnlMid.Name = "pnlMid";
            this.pnlMid.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlMid.Size = new System.Drawing.Size(857, 191);
            this.pnlMid.TabIndex = 1;
            // 
            // dgvPhongTrong
            // 
            this.dgvPhongTrong.AllowUserToAddRows = false;
            this.dgvPhongTrong.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(212)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPhongTrong.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvPhongTrong.ColumnHeadersHeight = 30;
            this.dgvPhongTrong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPhongTrong.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dgvPhongTrong.Location = new System.Drawing.Point(4, 28);
            this.dgvPhongTrong.Name = "dgvPhongTrong";
            this.dgvPhongTrong.ReadOnly = true;
            this.dgvPhongTrong.RowHeadersVisible = false;
            this.dgvPhongTrong.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPhongTrong.Size = new System.Drawing.Size(849, 159);
            this.dgvPhongTrong.TabIndex = 0;
            this.dgvPhongTrong.SelectionChanged += new System.EventHandler(this.dgvPhongTrong_SelectionChanged);
            // 
            // lblPhong
            // 
            this.lblPhong.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblPhong.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblPhong.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(212)))));
            this.lblPhong.Location = new System.Drawing.Point(4, 4);
            this.lblPhong.Name = "lblPhong";
            this.lblPhong.Size = new System.Drawing.Size(849, 24);
            this.lblPhong.TabIndex = 1;
            this.lblPhong.Text = "DANH SÁCH PHÒNG TRỐNG";
            // 
            // pnlBot
            // 
            this.pnlBot.Controls.Add(this.lblTimKH);
            this.pnlBot.Controls.Add(this.txtTimKH);
            this.pnlBot.Controls.Add(this.btnTimKH);
            this.pnlBot.Controls.Add(this.btnThemKH);
            this.pnlBot.Controls.Add(this.txtMaKH);
            this.pnlBot.Controls.Add(this.lblTenKH);
            this.pnlBot.Controls.Add(this.txtTenKH);
            this.pnlBot.Controls.Add(this.lblCCCD);
            this.pnlBot.Controls.Add(this.txtCCCD);
            this.pnlBot.Controls.Add(this.lblSDT);
            this.pnlBot.Controls.Add(this.txtSDT);
            this.pnlBot.Controls.Add(this.lblTongTien);
            this.pnlBot.Controls.Add(this.btnDatPhong);
            this.pnlBot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBot.Location = new System.Drawing.Point(0, 287);
            this.pnlBot.Name = "pnlBot";
            this.pnlBot.Padding = new System.Windows.Forms.Padding(9, 9, 9, 9);
            this.pnlBot.Size = new System.Drawing.Size(857, 276);
            this.pnlBot.TabIndex = 0;
            // 
            // lblTimKH
            // 
            this.lblTimKH.AutoSize = true;
            this.lblTimKH.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTimKH.Location = new System.Drawing.Point(4, 4);
            this.lblTimKH.Name = "lblTimKH";
            this.lblTimKH.Size = new System.Drawing.Size(137, 15);
            this.lblTimKH.TabIndex = 0;
            this.lblTimKH.Text = "CCCD/SĐT Khách Hàng:";
            // 
            // txtTimKH
            // 
            this.txtTimKH.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtTimKH.Location = new System.Drawing.Point(4, 22);
            this.txtTimKH.Name = "txtTimKH";
            this.txtTimKH.Size = new System.Drawing.Size(189, 25);
            this.txtTimKH.TabIndex = 1;
            // 
            // btnTimKH
            // 
            this.btnTimKH.AutoSize = true;
            this.btnTimKH.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnTimKH.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTimKH.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTimKH.ForeColor = System.Drawing.Color.White;
            this.btnTimKH.Location = new System.Drawing.Point(201, 20);
            this.btnTimKH.Name = "btnTimKH";
            this.btnTimKH.Size = new System.Drawing.Size(69, 26);
            this.btnTimKH.TabIndex = 2;
            this.btnTimKH.Text = "🔍 Tìm";
            this.btnTimKH.UseVisualStyleBackColor = false;
            this.btnTimKH.Click += new System.EventHandler(this.btnTimKH_Click);
            // 
            // btnThemKH
            // 
            this.btnThemKH.AutoSize = true;
            this.btnThemKH.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.btnThemKH.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThemKH.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThemKH.ForeColor = System.Drawing.Color.White;
            this.btnThemKH.Location = new System.Drawing.Point(279, 20);
            this.btnThemKH.Name = "btnThemKH";
            this.btnThemKH.Size = new System.Drawing.Size(77, 26);
            this.btnThemKH.TabIndex = 3;
            this.btnThemKH.Text = "➕ KH Mới";
            this.btnThemKH.UseVisualStyleBackColor = false;
            this.btnThemKH.Click += new System.EventHandler(this.btnThemKH_Click);
            // 
            // txtMaKH
            // 
            this.txtMaKH.Location = new System.Drawing.Point(4, 56);
            this.txtMaKH.Name = "txtMaKH";
            this.txtMaKH.Size = new System.Drawing.Size(86, 20);
            this.txtMaKH.TabIndex = 4;
            this.txtMaKH.Visible = false;
            // 
            // lblTenKH
            // 
            this.lblTenKH.AutoSize = true;
            this.lblTenKH.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTenKH.Location = new System.Drawing.Point(4, 59);
            this.lblTenKH.Name = "lblTenKH";
            this.lblTenKH.Size = new System.Drawing.Size(49, 15);
            this.lblTenKH.TabIndex = 5;
            this.lblTenKH.Text = "Họ Tên:";
            // 
            // txtTenKH
            // 
            this.txtTenKH.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.txtTenKH.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtTenKH.Location = new System.Drawing.Point(51, 56);
            this.txtTenKH.Name = "txtTenKH";
            this.txtTenKH.ReadOnly = true;
            this.txtTenKH.Size = new System.Drawing.Size(172, 25);
            this.txtTenKH.TabIndex = 6;
            // 
            // lblCCCD
            // 
            this.lblCCCD.AutoSize = true;
            this.lblCCCD.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblCCCD.Location = new System.Drawing.Point(236, 59);
            this.lblCCCD.Name = "lblCCCD";
            this.lblCCCD.Size = new System.Drawing.Size(40, 15);
            this.lblCCCD.TabIndex = 7;
            this.lblCCCD.Text = "CCCD:";
            // 
            // txtCCCD
            // 
            this.txtCCCD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.txtCCCD.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtCCCD.Location = new System.Drawing.Point(270, 56);
            this.txtCCCD.Name = "txtCCCD";
            this.txtCCCD.ReadOnly = true;
            this.txtCCCD.Size = new System.Drawing.Size(138, 25);
            this.txtCCCD.TabIndex = 8;
            // 
            // lblSDT
            // 
            this.lblSDT.AutoSize = true;
            this.lblSDT.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblSDT.Location = new System.Drawing.Point(420, 59);
            this.lblSDT.Name = "lblSDT";
            this.lblSDT.Size = new System.Drawing.Size(33, 15);
            this.lblSDT.TabIndex = 9;
            this.lblSDT.Text = "SĐT:";
            // 
            // txtSDT
            // 
            this.txtSDT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.txtSDT.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtSDT.Location = new System.Drawing.Point(446, 56);
            this.txtSDT.Name = "txtSDT";
            this.txtSDT.ReadOnly = true;
            this.txtSDT.Size = new System.Drawing.Size(112, 25);
            this.txtSDT.TabIndex = 10;
            // 
            // lblTongTien
            // 
            this.lblTongTien.AutoSize = true;
            this.lblTongTien.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblTongTien.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.lblTongTien.Location = new System.Drawing.Point(4, 95);
            this.lblTongTien.Name = "lblTongTien";
            this.lblTongTien.Size = new System.Drawing.Size(194, 25);
            this.lblTongTien.TabIndex = 11;
            this.lblTongTien.Text = "Tổng tiền dự kiến: ---";
            // 
            // btnDatPhong
            // 
            this.btnDatPhong.AutoSize = true;
            this.btnDatPhong.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.btnDatPhong.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDatPhong.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDatPhong.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnDatPhong.ForeColor = System.Drawing.Color.White;
            this.btnDatPhong.Location = new System.Drawing.Point(4, 128);
            this.btnDatPhong.Name = "btnDatPhong";
            this.btnDatPhong.Size = new System.Drawing.Size(235, 39);
            this.btnDatPhong.TabIndex = 12;
            this.btnDatPhong.Text = "✅  XÁC NHẬN ĐẶT PHÒNG";
            this.btnDatPhong.UseVisualStyleBackColor = false;
            this.btnDatPhong.Click += new System.EventHandler(this.btnDatPhong_Click);
            // 
            // frmDatPhong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(857, 563);
            this.Controls.Add(this.pnlBot);
            this.Controls.Add(this.pnlMid);
            this.Controls.Add(this.pnlTop);
            this.Name = "frmDatPhong";
            this.Text = "📥 Đặt Phòng Mới";
            this.Load += new System.EventHandler(this.frmDatPhong_Load);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlMid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhongTrong)).EndInit();
            this.pnlBot.ResumeLayout(false);
            this.pnlBot.PerformLayout();
            this.ResumeLayout(false);

        }

        private Panel pnlTop;
        private Label lblTitle;
        private Label lblNgayNhan;
        private Label lblNgayTra;
        private Panel pnlMid;
        private Label lblPhong;
        private Panel pnlBot;
        private Label lblTimKH;
        private Label lblTenKH;
        private Label lblCCCD;
        private Label lblSDT;
    }
}
