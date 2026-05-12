using System.Drawing;
using System.Windows.Forms;

namespace HotelManagement
{
    public partial class frmDoiMatKhau
    {
        private System.ComponentModel.IContainer components = null;

        private TextBox txtCu;
        private TextBox txtMoi;
        private TextBox txtXacNhan;
        private Button btnDoiMatKhau;

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
            var lblCu = new Label();
            var lblMoi = new Label();
            var lblXacNhan = new Label();

            SuspendLayout();

            AutoScaleDimensions = new SizeF(7F, 15F);
            this.Text = "Đổi Mật Khẩu";
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(360, 280);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "frmDoiMatKhau";
            StartPosition = FormStartPosition.CenterParent;

            lblCu.AutoSize = true;
            lblCu.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblCu.Location = new Point(20, 20);
            lblCu.Text = "Mật khẩu hiện tại:";

            txtCu = new TextBox();
            txtCu.Font = new Font("Segoe UI", 10F);
            txtCu.Location = new Point(20, 40);
            txtCu.Size = new Size(300, 25);
            txtCu.UseSystemPasswordChar = true;

            lblMoi.AutoSize = true;
            lblMoi.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblMoi.Location = new Point(20, 80);
            lblMoi.Text = "Mật khẩu mới (6 ký tự trở lên):";

            txtMoi = new TextBox();
            txtMoi.Font = new Font("Segoe UI", 10F);
            txtMoi.Location = new Point(20, 100);
            txtMoi.Size = new Size(300, 25);
            txtMoi.UseSystemPasswordChar = true;

            lblXacNhan.AutoSize = true;
            lblXacNhan.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblXacNhan.Location = new Point(20, 140);
            lblXacNhan.Text = "Xác nhận mật khẩu mới:";

            txtXacNhan = new TextBox();
            txtXacNhan.Font = new Font("Segoe UI", 10F);
            txtXacNhan.Location = new Point(20, 160);
            txtXacNhan.Size = new Size(300, 25);
            txtXacNhan.UseSystemPasswordChar = true;

            btnDoiMatKhau = new Button();
            btnDoiMatKhau.BackColor = Color.FromArgb(0, 120, 212);
            btnDoiMatKhau.Cursor = Cursors.Hand;
            btnDoiMatKhau.FlatStyle = FlatStyle.Flat;
            btnDoiMatKhau.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnDoiMatKhau.ForeColor = Color.White;
            btnDoiMatKhau.Location = new Point(60, 210);
            btnDoiMatKhau.Size = new Size(220, 40);
            btnDoiMatKhau.Text = "Đổi Mật Khẩu";
            btnDoiMatKhau.AutoSize = true;
            btnDoiMatKhau.Click += btnDoiMatKhau_Click;

            Controls.Add(lblCu);
            Controls.Add(txtCu);
            Controls.Add(lblMoi);
            Controls.Add(txtMoi);
            Controls.Add(lblXacNhan);
            Controls.Add(txtXacNhan);
            Controls.Add(btnDoiMatKhau);

            ResumeLayout(false);
            PerformLayout();
        }
    }
}
