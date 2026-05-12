using System.Drawing;
using System.Windows.Forms;

namespace HotelManagement
{
    public partial class frmNhanVien
    {
        private System.ComponentModel.IContainer components = null;

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
            AutoScaleDimensions = new SizeF(7F, 15F);
            this.Text = "Quản Lý Nhân Viên";
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(900, 600);
            Name = "frmNhanVien";
        }
    }
}
