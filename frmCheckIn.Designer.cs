using System.Drawing;
using System.Windows.Forms;

namespace HotelManagement
{
    public partial class frmCheckIn
    {
        private System.ComponentModel.IContainer components = null;
        private DataGridView dgv;
        private Button btnCheckIn;

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
            var lbl = new Label();
            var pnlBot = new Panel();

            SuspendLayout();

            AutoScaleDimensions = new SizeF(7F, 15F);
            this.Text = "✅ Check-In";
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(900, 550);
            Name = "frmCheckIn";

            pnlTop.BackColor = Color.FromArgb(0, 120, 212);
            pnlTop.Dock = DockStyle.Top;
            pnlTop.Height = 50;

            lbl.Dock = DockStyle.Fill;
            lbl.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lbl.ForeColor = Color.White;
            lbl.Text = "CHECK-IN - Danh sách phòng đã đặt, chờ nhận";
            lbl.TextAlign = ContentAlignment.MiddleCenter;
            pnlTop.Controls.Add(lbl);

            dgv = new DataGridView();
            dgv.AllowUserToAddRows = false;
            dgv.BackgroundColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 120, 212);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersHeight = 30;
            dgv.Dock = DockStyle.Fill;
            dgv.Font = new Font("Segoe UI", 10F);
            dgv.ReadOnly = true;
            dgv.RowHeadersVisible = false;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            pnlBot.Dock = DockStyle.Bottom;
            pnlBot.Height = 55;

            btnCheckIn = new Button();
            btnCheckIn.BackColor = Color.FromArgb(39, 174, 96);
            btnCheckIn.Cursor = Cursors.Hand;
            btnCheckIn.Dock = DockStyle.Left;
            btnCheckIn.FlatStyle = FlatStyle.Flat;
            btnCheckIn.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnCheckIn.ForeColor = Color.White;
            btnCheckIn.Width = 220;
            btnCheckIn.Text = "✅  XÁC NHẬN CHECK-IN";
            btnCheckIn.AutoSize = true;
            btnCheckIn.Click += btnCheckIn_Click;
            pnlBot.Controls.Add(btnCheckIn);

            Controls.Add(pnlBot);
            Controls.Add(dgv);
            Controls.Add(pnlTop);

            ResumeLayout(false);
        }
    }
}
