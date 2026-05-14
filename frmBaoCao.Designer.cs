using System;
using System.Drawing;
using System.Windows.Forms;

namespace HotelManagement
{
    public partial class frmBaoCao
    {
        private System.ComponentModel.IContainer components = null;

        // Controls
        private Panel pnlTop;
        private Label lblHeader;
        private Label lblNam;
        private NumericUpDown numNam;
        private Label lblThang;
        private ComboBox cboThang;
        private Button btnXemBaoCao;
        private Label lblTongDoanhThu;

        private DataGridView dgv;
        private DataGridViewTextBoxColumn colThang;
        private DataGridViewTextBoxColumn colSoHoaDon;
        private DataGridViewTextBoxColumn colTienPhong;
        private DataGridViewTextBoxColumn colTienDV;
        private DataGridViewTextBoxColumn colTongDoanhThu;

        private Panel pnlBottom;

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
            System.Windows.Forms.DataGridViewCellStyle headerStyle = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle currencyStyle = new System.Windows.Forms.DataGridViewCellStyle();

            this.pnlTop = new System.Windows.Forms.Panel();
            this.lblHeader = new System.Windows.Forms.Label();
            this.lblNam = new System.Windows.Forms.Label();
            this.numNam = new System.Windows.Forms.NumericUpDown();
            this.lblThang = new System.Windows.Forms.Label();
            this.cboThang = new System.Windows.Forms.ComboBox();
            this.btnXemBaoCao = new System.Windows.Forms.Button();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.lblTongDoanhThu = new System.Windows.Forms.Label();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.colThang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSoHoaDon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTienPhong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTienDV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTongDoanhThu = new System.Windows.Forms.DataGridViewTextBoxColumn();

            this.pnlTop.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numNam)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();

            // ──────────────────────────────────────────
            // pnlTop
            // ──────────────────────────────────────────
            this.pnlTop.BackColor = System.Drawing.Color.White;
            this.pnlTop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTop.Controls.Add(this.lblHeader);
            this.pnlTop.Controls.Add(this.lblNam);
            this.pnlTop.Controls.Add(this.numNam);
            this.pnlTop.Controls.Add(this.lblThang);
            this.pnlTop.Controls.Add(this.cboThang);
            this.pnlTop.Controls.Add(this.btnXemBaoCao);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Padding = new System.Windows.Forms.Padding(10);
            this.pnlTop.Size = new System.Drawing.Size(1000, 70);
            this.pnlTop.TabIndex = 0;

            // lblHeader
            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(212)))));
            this.lblHeader.Location = new System.Drawing.Point(10, 18);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.TabIndex = 0;
            this.lblHeader.Text = "THỐNG KÊ DOANH THU";

            // lblNam
            this.lblNam.AutoSize = true;
            this.lblNam.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblNam.Location = new System.Drawing.Point(230, 22);
            this.lblNam.Name = "lblNam";
            this.lblNam.TabIndex = 1;
            this.lblNam.Text = "Năm:";

            // numNam
            this.numNam.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.numNam.Location = new System.Drawing.Point(272, 18);
            this.numNam.Maximum = new decimal(new int[] { 2035, 0, 0, 0 });
            this.numNam.Minimum = new decimal(new int[] { 2020, 0, 0, 0 });
            this.numNam.Name = "numNam";
            this.numNam.Size = new System.Drawing.Size(80, 25);
            this.numNam.TabIndex = 2;
            this.numNam.Value = new decimal(new int[] { System.DateTime.Now.Year, 0, 0, 0 });

            // lblThang
            this.lblThang.AutoSize = true;
            this.lblThang.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblThang.Location = new System.Drawing.Point(365, 22);
            this.lblThang.Name = "lblThang";
            this.lblThang.TabIndex = 3;
            this.lblThang.Text = "Tháng:";

            // cboThang
            this.cboThang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboThang.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboThang.Location = new System.Drawing.Point(413, 18);
            this.cboThang.Name = "cboThang";
            this.cboThang.Size = new System.Drawing.Size(120, 25);
            this.cboThang.TabIndex = 4;
            this.cboThang.Items.AddRange(new object[] {
                "Cả năm", "Tháng 1", "Tháng 2", "Tháng 3",
                "Tháng 4", "Tháng 5", "Tháng 6", "Tháng 7",
                "Tháng 8", "Tháng 9", "Tháng 10", "Tháng 11", "Tháng 12"
            });
            this.cboThang.SelectedIndex = 0;

            // btnXemBaoCao
            this.btnXemBaoCao.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(212)))));
            this.btnXemBaoCao.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXemBaoCao.FlatAppearance.BorderSize = 0;
            this.btnXemBaoCao.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXemBaoCao.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnXemBaoCao.ForeColor = System.Drawing.Color.White;
            this.btnXemBaoCao.Location = new System.Drawing.Point(546, 14);
            this.btnXemBaoCao.Name = "btnXemBaoCao";
            this.btnXemBaoCao.Size = new System.Drawing.Size(140, 32);
            this.btnXemBaoCao.TabIndex = 5;
            this.btnXemBaoCao.Text = "📊 Xem Báo Cáo";
            this.btnXemBaoCao.UseVisualStyleBackColor = false;
            this.btnXemBaoCao.Click += new System.EventHandler(this.btnXemBaoCao_Click);

            // ──────────────────────────────────────────
            // pnlBottom
            // ──────────────────────────────────────────
            this.pnlBottom.BackColor = System.Drawing.Color.White;
            this.pnlBottom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlBottom.Controls.Add(this.lblTongDoanhThu);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 540);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Padding = new System.Windows.Forms.Padding(10);
            this.pnlBottom.Size = new System.Drawing.Size(1000, 40);
            this.pnlBottom.TabIndex = 2;

            // lblTongDoanhThu
            this.lblTongDoanhThu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTongDoanhThu.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblTongDoanhThu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.lblTongDoanhThu.Location = new System.Drawing.Point(10, 10);
            this.lblTongDoanhThu.Name = "lblTongDoanhThu";
            this.lblTongDoanhThu.Size = new System.Drawing.Size(978, 18);
            this.lblTongDoanhThu.TabIndex = 0;
            this.lblTongDoanhThu.Text = "Tổng doanh thu: 0 đ";
            this.lblTongDoanhThu.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            // ──────────────────────────────────────────
            // dgv
            // ──────────────────────────────────────────
            this.dgv.AllowUserToAddRows = false;
            this.dgv.BackgroundColor = System.Drawing.Color.White;
            this.dgv.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;

            headerStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            headerStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(212)))));
            headerStyle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            headerStyle.ForeColor = System.Drawing.Color.White;
            headerStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv.ColumnHeadersDefaultCellStyle = headerStyle;
            this.dgv.ColumnHeadersHeight = 40;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgv.EnableHeadersVisualStyles = false;

            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.colThang,
                this.colSoHoaDon,
                this.colTienPhong,
                this.colTienDV,
                this.colTongDoanhThu
            });

            this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dgv.Location = new System.Drawing.Point(0, 70);
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.RowHeadersVisible = false;
            this.dgv.RowTemplate.Height = 30;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.TabIndex = 1;

            // colThang
            this.colThang.DataPropertyName = "Thang";
            this.colThang.HeaderText = "Tháng";
            this.colThang.Name = "colThang";
            this.colThang.ReadOnly = true;
            this.colThang.Width = 80;

            // colSoHoaDon
            this.colSoHoaDon.DataPropertyName = "SoHoaDon";
            this.colSoHoaDon.HeaderText = "Số Hóa Đơn";
            this.colSoHoaDon.Name = "colSoHoaDon";
            this.colSoHoaDon.ReadOnly = true;
            this.colSoHoaDon.Width = 120;

            // colTienPhong
            currencyStyle = new System.Windows.Forms.DataGridViewCellStyle();
            currencyStyle.Format = "N0";
            this.colTienPhong.DataPropertyName = "TongTienPhong";
            this.colTienPhong.DefaultCellStyle = currencyStyle;
            this.colTienPhong.HeaderText = "Tiền Phòng (đ)";
            this.colTienPhong.Name = "colTienPhong";
            this.colTienPhong.ReadOnly = true;
            this.colTienPhong.Width = 180;

            // colTienDV
            currencyStyle = new System.Windows.Forms.DataGridViewCellStyle();
            currencyStyle.Format = "N0";
            this.colTienDV.DataPropertyName = "TongTienDichVu";
            this.colTienDV.DefaultCellStyle = currencyStyle;
            this.colTienDV.HeaderText = "Tiền Dịch Vụ (đ)";
            this.colTienDV.Name = "colTienDV";
            this.colTienDV.ReadOnly = true;
            this.colTienDV.Width = 180;

            // colTongDoanhThu
            currencyStyle = new System.Windows.Forms.DataGridViewCellStyle();
            currencyStyle.Format = "N0";
            currencyStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            currencyStyle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.colTongDoanhThu.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colTongDoanhThu.DataPropertyName = "TongDoanhThu";
            this.colTongDoanhThu.DefaultCellStyle = currencyStyle;
            this.colTongDoanhThu.HeaderText = "Tổng Doanh Thu (đ)";
            this.colTongDoanhThu.Name = "colTongDoanhThu";
            this.colTongDoanhThu.ReadOnly = true;

            // ──────────────────────────────────────────
            // frmBaoCao
            // ──────────────────────────────────────────
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 580);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlTop);
            this.Name = "frmBaoCao";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "📊 Thống Kê Doanh Thu";

            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numNam)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);
        }
    }
}
