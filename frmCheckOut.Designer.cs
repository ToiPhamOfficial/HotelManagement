using System.Drawing;
using System.Windows.Forms;

namespace HotelManagement
{
    public partial class frmCheckOut
    {
        private System.ComponentModel.IContainer components = null;

        private DataGridView dgvPhong;
        private DataGridView dgvDV;
        private Label lblTienPhong;
        private Label lblTienDV;
        private Label lblTongCong;
        private ComboBox cboPhuongThuc;
        private NumericUpDown numGiamGia;

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
            var lblP = new Label();
            var pnlMid = new Panel();
            var lblDV = new Label();
            var pnlBot = new Panel();
            var lblGiamGia = new Label();
            var lblPT = new Label();
            var btnCheckOut = new Button();

            SuspendLayout();

            AutoScaleDimensions = new SizeF(7F, 15F);
            this.Text = "Check-Out & Thanh Toán";
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1100, 680);
            Name = "frmCheckOut";

            pnlTop.Dock = DockStyle.Top;
            pnlTop.Height = 250;

            lblP.Dock = DockStyle.Top;
            lblP.Height = 30;
            lblP.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblP.ForeColor = Color.FromArgb(0, 120, 212);
            lblP.Text = "PHÒNG ĐANG SỬ DỤNG (chọn để check-out)";
            lblP.TextAlign = ContentAlignment.MiddleLeft;

            dgvPhong = new DataGridView();
            dgvPhong.AllowUserToAddRows = false;
            dgvPhong.BackgroundColor = Color.White;
            dgvPhong.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 120, 212);
            dgvPhong.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvPhong.Dock = DockStyle.Fill;
            dgvPhong.Font = new Font("Segoe UI", 10F);
            dgvPhong.ReadOnly = true;
            dgvPhong.RowHeadersVisible = false;
            dgvPhong.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPhong.SelectionChanged += dgvPhong_SelectionChanged;

            pnlTop.Controls.Add(dgvPhong);
            pnlTop.Controls.Add(lblP);

            pnlMid.Dock = DockStyle.Top;
            pnlMid.Height = 200;

            lblDV.Dock = DockStyle.Top;
            lblDV.Height = 28;
            lblDV.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblDV.ForeColor = Color.FromArgb(39, 174, 96);
            lblDV.Text = "DỊCH VỤ ĐÃ SỬ DỤNG";
            lblDV.TextAlign = ContentAlignment.MiddleLeft;

            dgvDV = new DataGridView();
            dgvDV.AllowUserToAddRows = false;
            dgvDV.BackgroundColor = Color.White;
            dgvDV.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(39, 174, 96);
            dgvDV.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvDV.Dock = DockStyle.Fill;
            dgvDV.Font = new Font("Segoe UI", 10F);
            dgvDV.ReadOnly = true;
            dgvDV.RowHeadersVisible = false;

            pnlMid.Controls.Add(dgvDV);
            pnlMid.Controls.Add(lblDV);

            pnlBot.BackColor = Color.White;
            pnlBot.Dock = DockStyle.Fill;
            pnlBot.Padding = new Padding(10);

            lblTienPhong = new Label();
            lblTienPhong.AutoSize = true;
            lblTienPhong.Font = new Font("Segoe UI", 11F);
            lblTienPhong.Location = new Point(10, 10);
            lblTienPhong.Text = "Tiền phòng:      0 đ";

            lblTienDV = new Label();
            lblTienDV.AutoSize = true;
            lblTienDV.Font = new Font("Segoe UI", 11F);
            lblTienDV.Location = new Point(10, 38);
            lblTienDV.Text = "Tiền dịch vụ:    0 đ";

            lblGiamGia.AutoSize = true;
            lblGiamGia.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblGiamGia.Location = new Point(10, 72);
            lblGiamGia.Text = "Giảm giá (đ):";

            numGiamGia = new NumericUpDown();
            numGiamGia.Font = new Font("Segoe UI", 10F);
            numGiamGia.Location = new Point(140, 68);
            numGiamGia.Maximum = 99999999;
            numGiamGia.Size = new Size(130, 25);
            numGiamGia.ThousandsSeparator = true;
            numGiamGia.ValueChanged += numGiamGia_ValueChanged;

            lblTongCong = new Label();
            lblTongCong.AutoSize = true;
            lblTongCong.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTongCong.ForeColor = Color.FromArgb(231, 76, 60);
            lblTongCong.Location = new Point(10, 105);
            lblTongCong.Text = "TỔNG CỘNG: 0 đ";

            lblPT.AutoSize = true;
            lblPT.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblPT.Location = new Point(10, 140);
            lblPT.Text = "Phương thức TT:";

            cboPhuongThuc = new ComboBox();
            cboPhuongThuc.DropDownStyle = ComboBoxStyle.DropDownList;
            cboPhuongThuc.Font = new Font("Segoe UI", 10F);
            cboPhuongThuc.Location = new Point(145, 136);
            cboPhuongThuc.Size = new Size(160, 25);
            cboPhuongThuc.Items.AddRange(new object[] { "Tiền mặt", "Chuyển khoản", "Thẻ tín dụng" });
            cboPhuongThuc.SelectedIndex = 0;

            btnCheckOut.BackColor = Color.FromArgb(231, 76, 60);
            btnCheckOut.Cursor = Cursors.Hand;
            btnCheckOut.FlatStyle = FlatStyle.Flat;
            btnCheckOut.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnCheckOut.ForeColor = Color.White;
            btnCheckOut.Location = new Point(10, 178);
            btnCheckOut.Size = new Size(280, 50);
            btnCheckOut.Text = "CHECK-OUT & THANH TOÁN";
            btnCheckOut.AutoSize = true;
            btnCheckOut.Click += btnCheckOut_Click;

            pnlBot.Controls.Add(lblTienPhong);
            pnlBot.Controls.Add(lblTienDV);
            pnlBot.Controls.Add(lblGiamGia);
            pnlBot.Controls.Add(numGiamGia);
            pnlBot.Controls.Add(lblTongCong);
            pnlBot.Controls.Add(lblPT);
            pnlBot.Controls.Add(cboPhuongThuc);
            pnlBot.Controls.Add(btnCheckOut);

            Controls.Add(pnlBot);
            Controls.Add(pnlMid);
            Controls.Add(pnlTop);

            ResumeLayout(false);
        }
    }
}
