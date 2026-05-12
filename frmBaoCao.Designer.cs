using System;
using System.Drawing;
using System.Windows.Forms;

namespace HotelManagement
{
    public partial class frmBaoCao
    {
        private System.ComponentModel.IContainer components = null;

        private DataGridView dgv;
        private NumericUpDown numNam;
        private ComboBox cboThang;
        private Label lblTongDoanhThu;

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
            var lblNam = new Label();
            var lblThang = new Label();
            var btnXemBaoCao = new Button();
            var btnInBaoCao = new Button();

            SuspendLayout();

            AutoScaleDimensions = new SizeF(7F, 15F);
            this.Text = "Báo Cáo Thống Kê Doanh Thu";
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(900, 600);
            Name = "frmBaoCao";

            pnlTop.BackColor = Color.White;
            pnlTop.Dock = DockStyle.Top;
            pnlTop.Height = 60;
            pnlTop.Padding = new Padding(10);

            lblNam.AutoSize = true;
            lblNam.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblNam.Location = new Point(10, 18);
            lblNam.Text = "Năm:";

            numNam = new NumericUpDown();
            numNam.Font = new Font("Segoe UI", 10F);
            numNam.Location = new Point(55, 15);
            numNam.Maximum = 2030;
            numNam.Minimum = 2020;
            numNam.Size = new Size(80, 25);
            numNam.Value = DateTime.Now.Year;

            lblThang.AutoSize = true;
            lblThang.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblThang.Location = new Point(150, 18);
            lblThang.Text = "Tháng:";

            cboThang = new ComboBox();
            cboThang.DropDownStyle = ComboBoxStyle.DropDownList;
            cboThang.Font = new Font("Segoe UI", 10F);
            cboThang.Location = new Point(202, 15);
            cboThang.Size = new Size(100, 25);
            cboThang.Items.AddRange(new object[]
            {
                "Cả năm",
                "Tháng 1",
                "Tháng 2",
                "Tháng 3",
                "Tháng 4",
                "Tháng 5",
                "Tháng 6",
                "Tháng 7",
                "Tháng 8",
                "Tháng 9",
                "Tháng 10",
                "Tháng 11",
                "Tháng 12"
            });
            cboThang.SelectedIndex = 0;

            btnXemBaoCao.BackColor = Color.FromArgb(0, 120, 212);
            btnXemBaoCao.Cursor = Cursors.Hand;
            btnXemBaoCao.FlatStyle = FlatStyle.Flat;
            btnXemBaoCao.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnXemBaoCao.ForeColor = Color.White;
            btnXemBaoCao.Location = new Point(315, 12);
            btnXemBaoCao.Size = new Size(150, 35);
            btnXemBaoCao.Text = "Xem Báo Cáo";
            btnXemBaoCao.AutoSize = true;
            btnXemBaoCao.Click += btnXemBaoCao_Click;

            btnInBaoCao.BackColor = Color.FromArgb(39, 174, 96);
            btnInBaoCao.Cursor = Cursors.Hand;
            btnInBaoCao.FlatStyle = FlatStyle.Flat;
            btnInBaoCao.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnInBaoCao.ForeColor = Color.White;
            btnInBaoCao.Location = new Point(475, 12);
            btnInBaoCao.Size = new Size(140, 35);
            btnInBaoCao.Text = "In Báo Cáo";
            btnInBaoCao.AutoSize = true;
            btnInBaoCao.Click += btnInBaoCao_Click;

            lblTongDoanhThu = new Label();
            lblTongDoanhThu.AutoSize = true;
            lblTongDoanhThu.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblTongDoanhThu.ForeColor = Color.FromArgb(231, 76, 60);
            lblTongDoanhThu.Location = new Point(630, 18);

            pnlTop.Controls.Add(lblNam);
            pnlTop.Controls.Add(numNam);
            pnlTop.Controls.Add(lblThang);
            pnlTop.Controls.Add(cboThang);
            pnlTop.Controls.Add(btnXemBaoCao);
            pnlTop.Controls.Add(btnInBaoCao);
            pnlTop.Controls.Add(lblTongDoanhThu);

            dgv = new DataGridView();
            dgv.AllowUserToAddRows = false;
            dgv.BackgroundColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 120, 212);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            dgv.ColumnHeadersHeight = 35;
            dgv.Dock = DockStyle.Fill;
            dgv.Font = new Font("Segoe UI", 11F);
            dgv.ReadOnly = true;
            dgv.RowHeadersVisible = false;

            Controls.Add(dgv);
            Controls.Add(pnlTop);

            ResumeLayout(false);
        }
    }
}
