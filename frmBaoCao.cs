using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Windows.Forms;
using HotelManagement.Database;

namespace HotelManagement
{
    public partial class frmBaoCao : Form
    {
        public frmBaoCao()
        {
            InitializeComponent();
            DoThongKe();
        }

        private class ThongKeResult
        {
            public int Thang { get; set; }
            public int SoHoaDon { get; set; }
            public decimal TongTienPhong { get; set; }
            public decimal TongTienDichVu { get; set; }
            public decimal TongDoanhThu { get; set; }
        }

        private void DoThongKe()
        {
            int nam = (int)numNam.Value;
            int thang = cboThang.SelectedIndex;

            using (var db = new DataContext())
            {
                var dt = db.Database.SqlQuery<ThongKeResult>("EXEC SP_ThongKeDoanhThu {0}, {1}", nam, thang).ToList();
                dgv.DataSource = dt;

                if (dgv.Columns.Contains("Thang")) dgv.Columns["Thang"].HeaderText = "Tháng";
                if (dgv.Columns.Contains("SoHoaDon")) dgv.Columns["SoHoaDon"].HeaderText = "Số Hóa Đơn";
                if (dgv.Columns.Contains("TongTienPhong")) dgv.Columns["TongTienPhong"].HeaderText = "Tiền Phòng (đ)";
                if (dgv.Columns.Contains("TongTienDichVu")) dgv.Columns["TongTienDichVu"].HeaderText = "Tiền DV (đ)";
                if (dgv.Columns.Contains("TongDoanhThu")) dgv.Columns["TongDoanhThu"].HeaderText = "Tổng Doanh Thu (đ)";

                foreach (DataGridViewColumn col in dgv.Columns)
                {
                    if (col.Name.StartsWith("Tong") || col.Name.StartsWith("Tien"))
                        col.DefaultCellStyle.Format = "N0";
                }

                decimal tong = 0;
                foreach (var r in dt)
                {
                    tong += r.TongDoanhThu;
                }
                lblTongDoanhThu.Text = $"Tổng: {tong:N0} đ";
            }
        }

        private void InBaoCao()
        {
            var pd = new PrintDocument();
            pd.PrintPage += new PrintPageEventHandler(pd_PrintPage);

            using (var preview = new PrintPreviewDialog { Document = pd })
            {
                preview.ShowDialog();
            }
        }

        private void pd_PrintPage(object sender, PrintPageEventArgs e)
        {
            var font = new Font("Arial", 10);
            var fontBold = new Font("Arial", 12, FontStyle.Bold);
            int y = 30;

            e.Graphics.DrawString($"BÁO CÁO DOANH THU NĂM {numNam.Value}", fontBold, Brushes.Black, 200, y);
            y += 30;
            e.Graphics.DrawString($"Ngày in: {DateTime.Now:dd/MM/yyyy HH:mm}", font, Brushes.Gray, 200, y);
            y += 30;

            foreach (DataGridViewRow row in dgv.Rows)
            {
                string line = $"Tháng {row.Cells[0].Value} | HD: {row.Cells[1].Value} | DT: {row.Cells[4].Value:N0} đ";
                e.Graphics.DrawString(line, font, Brushes.Black, 50, y);
                y += 22;
            }
        }

        private void btnXemBaoCao_Click(object sender, EventArgs e)
        {
            DoThongKe();
        }

        private void btnInBaoCao_Click(object sender, EventArgs e)
        {
            InBaoCao();
        }
    }
}
