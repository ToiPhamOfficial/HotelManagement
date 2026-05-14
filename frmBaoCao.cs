using System;
using System.Linq;
using System.Windows.Forms;
using HotelManagement.Database;

namespace HotelManagement
{
    public partial class frmBaoCao : Form
    {
        DataContext db = new DataContext();

        public frmBaoCao()
        {
            InitializeComponent();
            dgv.AutoGenerateColumns = false;
            dgv.AllowUserToAddRows = false;
            DoThongKe();
        }

        // Lớp ánh xạ kết quả từ stored procedure SP_ThongKeDoanhThu
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
            int thang = cboThang.SelectedIndex; // 0 = Cả năm, 1-12 = tháng cụ thể

            var ketQua = db.Database.SqlQuery<ThongKeResult>(
                "EXEC SP_ThongKeDoanhThu {0}, {1}", nam, thang
            ).ToList();

            dgv.DataSource = ketQua;

            decimal tongDoanhThu = ketQua.Sum(r => r.TongDoanhThu);
            lblTongDoanhThu.Text = $"Tổng doanh thu năm {nam}: {tongDoanhThu:N0} đ";
        }

        private void btnXemBaoCao_Click(object sender, EventArgs e)
        {
            DoThongKe();
        }
    }
}
