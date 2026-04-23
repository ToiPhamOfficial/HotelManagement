using System;
using System.Drawing;
using System.Windows.Forms;

namespace HotelManagement
{
    public partial class frmHoaDon
    {
        private System.ComponentModel.IContainer components = null;

        private Panel pnlTop;
        private Label lblTuNgay;
        private DateTimePicker dtpTuNgay;
        private Label lblDenNgay;
        private DateTimePicker dtpDenNgay;
        private Label lblTimKiem;
        private TextBox txtTimKiem;
        private Button btnLoc;
        private Button btnLamMoi;

        private Panel pnlFill;
        private DataGridView dgvHoaDon;

        private Panel pnlBottom;
        private Label lblTongDoanhThu;

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
            this.pnlTop = new Panel();
            this.lblTuNgay = new Label();
            this.dtpTuNgay = new DateTimePicker();
            this.lblDenNgay = new Label();
            this.dtpDenNgay = new DateTimePicker();
            this.lblTimKiem = new Label();
            this.txtTimKiem = new TextBox();
            this.btnLoc = new Button();
            this.btnLamMoi = new Button();
            this.pnlFill = new Panel();
            this.dgvHoaDon = new DataGridView();
            this.pnlBottom = new Panel();
            this.lblTongDoanhThu = new Label();

            this.pnlTop.SuspendLayout();
            this.pnlFill.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoaDon)).BeginInit();
            this.pnlBottom.SuspendLayout();
            this.SuspendLayout();

            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = Color.White;
            this.pnlTop.Controls.Add(this.lblTuNgay);
            this.pnlTop.Controls.Add(this.dtpTuNgay);
            this.pnlTop.Controls.Add(this.lblDenNgay);
            this.pnlTop.Controls.Add(this.dtpDenNgay);
            this.pnlTop.Controls.Add(this.lblTimKiem);
            this.pnlTop.Controls.Add(this.txtTimKiem);
            this.pnlTop.Controls.Add(this.btnLoc);
            this.pnlTop.Controls.Add(this.btnLamMoi);
            this.pnlTop.Dock = DockStyle.Top;
            this.pnlTop.Location = new Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new Size(1000, 70);
            this.pnlTop.TabIndex = 0;

            // 
            // lblTuNgay
            // 
            this.lblTuNgay.AutoSize = true;
            this.lblTuNgay.Location = new Point(12, 28);
            this.lblTuNgay.Name = "lblTuNgay";
            this.lblTuNgay.Size = new Size(53, 15);
            this.lblTuNgay.Text = "Từ ngày:";

            // 
            // dtpTuNgay
            // 
            this.dtpTuNgay.Format = DateTimePickerFormat.Short;
            this.dtpTuNgay.Location = new Point(70, 24);
            this.dtpTuNgay.Name = "dtpTuNgay";
            this.dtpTuNgay.Size = new Size(120, 23);

            // 
            // lblDenNgay
            // 
            this.lblDenNgay.AutoSize = true;
            this.lblDenNgay.Location = new Point(205, 28);
            this.lblDenNgay.Name = "lblDenNgay";
            this.lblDenNgay.Size = new Size(60, 15);
            this.lblDenNgay.Text = "Đến ngày:";

            // 
            // dtpDenNgay
            // 
            this.dtpDenNgay.Format = DateTimePickerFormat.Short;
            this.dtpDenNgay.Location = new Point(270, 24);
            this.dtpDenNgay.Name = "dtpDenNgay";
            this.dtpDenNgay.Size = new Size(120, 23);

            // 
            // lblTimKiem
            // 
            this.lblTimKiem.AutoSize = true;
            this.lblTimKiem.Location = new Point(410, 28);
            this.lblTimKiem.Name = "lblTimKiem";
            this.lblTimKiem.Size = new Size(59, 15);
            this.lblTimKiem.Text = "Tìm kiếm:";

            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Location = new Point(475, 24);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new Size(200, 23);

            // 
            // btnLoc
            // 
            this.btnLoc.BackColor = Color.FromArgb(52, 152, 219);
            this.btnLoc.Cursor = Cursors.Hand;
            this.btnLoc.FlatStyle = FlatStyle.Flat;
            this.btnLoc.ForeColor = Color.White;
            this.btnLoc.Location = new Point(690, 21);
            this.btnLoc.Name = "btnLoc";
            this.btnLoc.Size = new Size(80, 30);
            this.btnLoc.Text = "🔍 Lọc";
            this.btnLoc.AutoSize = true;
            this.btnLoc.UseVisualStyleBackColor = false;
            //this.btnLoc.Click += new EventHandler(this.btnLoc_Click);

            // 
            // btnLamMoi
            // 
            this.btnLamMoi.BackColor = Color.Gray;
            this.btnLamMoi.Cursor = Cursors.Hand;
            this.btnLamMoi.FlatStyle = FlatStyle.Flat;
            this.btnLamMoi.ForeColor = Color.White;
            this.btnLamMoi.Location = new Point(780, 21);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new Size(90, 30);
            this.btnLamMoi.Text = "🔃 Làm Mới";
            this.btnLamMoi.AutoSize = true;
            this.btnLamMoi.UseVisualStyleBackColor = false;
            //this.btnLamMoi.Click += new EventHandler(this.btnLamMoi_Click);

            // 
            // pnlFill
            // 
            this.pnlFill.Controls.Add(this.dgvHoaDon);
            this.pnlFill.Dock = DockStyle.Fill;
            this.pnlFill.Location = new Point(0, 70);
            this.pnlFill.Name = "pnlFill";
            this.pnlFill.Padding = new Padding(10);
            this.pnlFill.Size = new Size(1000, 480);
            this.pnlFill.TabIndex = 1;

            // 
            // dgvHoaDon
            // 
            this.dgvHoaDon.AllowUserToAddRows = false;
            this.dgvHoaDon.BackgroundColor = Color.White;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(0, 120, 212);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            this.dgvHoaDon.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvHoaDon.Dock = DockStyle.Fill;
            this.dgvHoaDon.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            this.dgvHoaDon.Location = new Point(10, 10);
            this.dgvHoaDon.Name = "dgvHoaDon";
            this.dgvHoaDon.ReadOnly = true;
            this.dgvHoaDon.RowHeadersVisible = false;
            this.dgvHoaDon.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvHoaDon.Size = new Size(980, 460);
            this.dgvHoaDon.TabIndex = 0;

            // 
            // pnlBottom
            // 
            this.pnlBottom.BackColor = Color.FromArgb(240, 240, 240);
            this.pnlBottom.Controls.Add(this.lblTongDoanhThu);
            this.pnlBottom.Dock = DockStyle.Bottom;
            this.pnlBottom.Location = new Point(0, 550);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new Size(1000, 50);
            this.pnlBottom.TabIndex = 2;

            // 
            // lblTongDoanhThu
            // 
            this.lblTongDoanhThu.AutoSize = true;
            this.lblTongDoanhThu.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            this.lblTongDoanhThu.ForeColor = Color.FromArgb(192, 57, 43);
            this.lblTongDoanhThu.Location = new Point(12, 12);
            this.lblTongDoanhThu.Name = "lblTongDoanhThu";
            this.lblTongDoanhThu.Size = new Size(165, 25);
            this.lblTongDoanhThu.Text = "Tổng Doanh Thu: 0 VNĐ";

            // 
            // frmHoaDon
            // 
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(1000, 600);
            this.Controls.Add(this.pnlFill);
            this.Controls.Add(this.pnlTop);
            this.Controls.Add(this.pnlBottom);
            this.Name = "frmHoaDon";
            this.Text = "🧾 Quản Lý Hóa Đơn";
            //this.Load += new EventHandler(this.frmHoaDon_Load);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlFill.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoaDon)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            this.pnlBottom.PerformLayout();
            this.ResumeLayout(false);
        }
    }
}
