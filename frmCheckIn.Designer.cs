using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace HotelManagement
{
    partial class frmCheckIn
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.lbl = new System.Windows.Forms.Label();
            this.pnlBot = new System.Windows.Forms.Panel();
            this.btnCheckIn = new System.Windows.Forms.Button();
            this.dgv = new System.Windows.Forms.DataGridView();
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
            this.pnlTop.SuspendLayout();
            this.pnlBot.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(212)))));
            this.pnlTop.Controls.Add(this.lbl);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1256, 43);
            this.pnlTop.TabIndex = 2;
            // 
            // lbl
            // 
            this.lbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lbl.ForeColor = System.Drawing.Color.White;
            this.lbl.Location = new System.Drawing.Point(0, 0);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(1256, 43);
            this.lbl.TabIndex = 0;
            this.lbl.Text = "✅ CHECK-IN - Danh sách phòng đã đặt, chờ nhận";
            this.lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlBot
            // 
            this.pnlBot.Controls.Add(this.btnCheckIn);
            this.pnlBot.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBot.Location = new System.Drawing.Point(0, 626);
            this.pnlBot.Name = "pnlBot";
            this.pnlBot.Padding = new System.Windows.Forms.Padding(8);
            this.pnlBot.Size = new System.Drawing.Size(1256, 55);
            this.pnlBot.TabIndex = 0;
            // 
            // btnCheckIn
            // 
            this.btnCheckIn.AutoSize = true;
            this.btnCheckIn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.btnCheckIn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCheckIn.FlatAppearance.BorderSize = 0;
            this.btnCheckIn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCheckIn.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnCheckIn.ForeColor = System.Drawing.Color.White;
            this.btnCheckIn.Location = new System.Drawing.Point(8, 8);
            this.btnCheckIn.Name = "btnCheckIn";
            this.btnCheckIn.Size = new System.Drawing.Size(220, 39);
            this.btnCheckIn.TabIndex = 0;
            this.btnCheckIn.Text = "✅  XÁC NHẬN CHECK-IN";
            this.btnCheckIn.UseVisualStyleBackColor = false;
            this.btnCheckIn.Click += new System.EventHandler(this.btnCheckIn_Click);
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.BackgroundColor = System.Drawing.Color.White;
            this.dgv.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(212)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 10F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv.ColumnHeadersHeight = 40;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
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
            this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv.EnableHeadersVisualStyles = false;
            this.dgv.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dgv.Location = new System.Drawing.Point(0, 43);
            this.dgv.MultiSelect = false;
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.RowHeadersVisible = false;
            this.dgv.RowTemplate.Height = 30;
            this.dgv.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(1256, 583);
            this.dgv.TabIndex = 1;
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
            this.SoPhong.Width = 95;
            // 
            // TenLoaiPhong
            // 
            this.TenLoaiPhong.DataPropertyName = "TenLoaiPhong";
            this.TenLoaiPhong.HeaderText = "Loại Phòng";
            this.TenLoaiPhong.Name = "TenLoaiPhong";
            this.TenLoaiPhong.ReadOnly = true;
            this.TenLoaiPhong.Width = 150;
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
            this.NgayNhanPhong.Width = 150;
            // 
            // NgayTraPhong
            // 
            this.NgayTraPhong.DataPropertyName = "NgayTraPhong";
            this.NgayTraPhong.HeaderText = "Ngày Trả";
            this.NgayTraPhong.Name = "NgayTraPhong";
            this.NgayTraPhong.ReadOnly = true;
            this.NgayTraPhong.Width = 150;
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
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N0";
            this.GiaPhong.DefaultCellStyle = dataGridViewCellStyle2;
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
            // frmCheckIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(1256, 681);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.pnlBot);
            this.Controls.Add(this.pnlTop);
            this.Name = "frmCheckIn";
            this.Text = "✅ Check-In";
            this.pnlTop.ResumeLayout(false);
            this.pnlBot.ResumeLayout(false);
            this.pnlBot.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lbl;
        private System.Windows.Forms.Panel pnlBot;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.Button btnCheckIn;
        private DataGridViewTextBoxColumn MaDatPhong;
        private DataGridViewTextBoxColumn MaPhong;
        private DataGridViewTextBoxColumn SoPhong;
        private DataGridViewTextBoxColumn TenLoaiPhong;
        private DataGridViewTextBoxColumn TenKhachHang;
        private DataGridViewTextBoxColumn SoDienThoai;
        private DataGridViewTextBoxColumn NgayNhanPhong;
        private DataGridViewTextBoxColumn NgayTraPhong;
        private DataGridViewTextBoxColumn LoaiDat;
        private DataGridViewTextBoxColumn GiaPhong;
        private DataGridViewTextBoxColumn TrangThai;
        private DataGridViewTextBoxColumn TenNhanVien;
    }
}
