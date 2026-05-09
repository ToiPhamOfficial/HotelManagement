# BÀI THỰC HÀNH CÔNG NGHỆ .NET

## (ĐỒ ÁN: XÂY DỰNG PHẦN MỀM QUẢN LÝ CHO THUÊ SÁCH)

### BÀI THỰC HÀNH #3: LẬP TRÌNH HIỂN THỊ THÊM/SỬA/XÓA TRÊN GIAO DIỆN QUẢN LÝ NGƯỜI DÙNG SỬ DỤNG CÔNG NGHỆ LINQ

## 1. Nội dung chuẩn bị

* Các tệp cơ sở dữ liệu: Bài TH01 (bảng tblUsers)

* Giao diện frmUsers: Bài TH02

`[Hình ảnh: Giao diện Quản lý người dùng frmUsers với các trường thông tin và nút chức năng]`

## 2. Lập trình Hiển thị/Thêm/Sửa/Xóa sử dụng LINQ (Language Integrated Query - Truy vấn tích hợp ngôn ngữ)

**Mục đích:**

* Hiển thị thông tin trong bảng tblUsers lên dgvUser.

* Thực hiện việc Thêm/Sửa/Xóa thông tin trong bảng tblUsers.

**Cài đặt gói thư viện EntityFramework (chỉ làm 1 lần cho toàn bộ project):**

* Vào Tools, Chọn NuGet Package Manager, chọn Package Manager Console.

`[Hình ảnh: Menu Tools -> NuGet Package Manager -> Package Manager Console]`

* Gõ lệnh `Install-Package EntityFramework` trong khung PM>.

`[Hình ảnh: Giao diện Package Manager Console chạy lệnh cài đặt EntityFramework]`

* Thực hiện xong đóng khung.

### 2.1. Tạo lớp tblUser.cs

* **Mục đích:** Lớp này chứa các thuộc tính để lưu trữ dữ liệu trong bảng tblUsers (trong bài thực hành TH01).

* **Thực hiện:**

  * Vào Project, Chọn Add Class...

`[Hình ảnh: Menu Project -> Add Class...]`

* Gõ `tblUsers.cs` trong hộp Name.

`[Hình ảnh: Hộp thoại Add New Item gõ tên tblUsers.cs]`

* Gõ nội dung sau vào trong tệp `tblUsers.cs`:

```csharp
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookRental
{
    [Table("tblUsers")]
    internal class tblUsers
    {
        [Key] // Khai báo Khóa chính
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Tự động tăng
        public int UserID { get; set; }

        [Required]
        [StringLength(50)]
        public string Username { get; set; }

        [Required]
        [StringLength(255)]
        public string Password { get; set; }

        [StringLength(100)]
        public string FullName { get; set; }

        [StringLength(20)]
        public string Phone { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        [StringLength(20)]
        public string Role { get; set; }

        public bool Status { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
```

### 2.2. Cấu hình Chuỗi kết nối (App.config)

* Mở tệp App.config, thêm các dòng sau vào sau thẻ `</configSections>`, có thể copy nội dung ở dưới rồi chỉnh sửa tên phù hợp (tương tự như làm ADO.NET ở bài thực hành trước).

```xml
<connectionStrings>
    <add name="MyConnectionString"
    connectionString="Data Source=SONCT\SQL2019;Initial Catalog=BOOKRENTAL; Integrated Security=True"
    providerName="System.Data.SqlClient" />
</connectionStrings>
```

### 2.3. Tạo lớp DataContext.cs (chỉ tạo 1 lần và dùng chung sau này)

* Vào Project, chọn Add Class, gõ `DataContext.cs`.

`[Hình ảnh: Hộp thoại Add New Item gõ tên DataContext.cs]`

* Gõ nội dung sau vào tệp `DataContext.cs`:

```csharp
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRental
{
    internal class DataContext : DbContext
    {
        public DataContext() : base("name=MyConnectionString")
        {
        }
        
        public DbSet<tblUsers> Users { get; set; }
    }
}
```

### 2.5. Tạo form mới frmUsersLINQ như sau

* Vào Project, Add Form, gõ `frmUsersLINQ` như sau.

`[Hình ảnh: Hộp thoại Add New Item tạo form Windows Forms tên frmUsersLINQ]`

* Mở form frmUsers đã thực hiện trước đó ở chế độ Design, ấn CTRL+A để chọn toàn bộ các điều khiển, trên form này, ấn CTRL + C để copy (nếu chưa làm frmUsers thì xem lại bài thực hành TH02).

`[Hình ảnh: Chọn toàn bộ control trên frmUsers]`

* Mở lại form frmUsersLINQ, ấn CTRL + V để dán toàn bộ giao diện vào form mới (đỡ mất công thiết kế lại), căn chỉnh phù hợp sau khi copy, ta có như sau.

`[Hình ảnh: Dán control sang frmUsersLINQ và căn chỉnh]`

### 2.6. Lập trình Hiển thị/Thêm/Sửa/Xóa trên form frmUsersLINQ

* Nhấp đúp vào thanh tiêu đề của from sẽ xuất hiện phần code, gõ các nội dung sau.

```csharp
using System;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace BookRental
{
    public partial class frmUsersLINQ : Form
    {
        DataContext db = new DataContext();
        bool AddNew = false;

        public frmUsersLINQ()
        {
            InitializeComponent();
        }

        private void setControl(bool check)
        {
            txtUserID.Enabled = false;
            txtUsername.Enabled = check;
            txtFullName.Enabled = check;
            txtPassword.Enabled = check;
            txtPhone.Enabled = check;
            txtEmail.Enabled = check;
            txtCreatedDate.Enabled = false;
            cbbRole.Enabled = check;
            ckbStatus.Enabled = check;
            btnSave.Enabled = check;
            btnCancel.Enabled = check;
            btnAdd.Enabled = !check;
            btnEdit.Enabled = !check;
            btnDelete.Enabled = !check;
            btnExcel.Enabled = !check;
            btnExit.Enabled = !check;
            dgvUsers.Enabled = !check;
        }

        private void LoadGridData()
        {
            // Lấy toàn bộ danh sách tử bảng tblusers bằng LINQ
            var data = from u in db.Users select u;
            dgvUsers.DataSource = data.ToList();
        }

        private void frmUsersLINQ_Load(object sender, EventArgs e)
        {
            setControl(false);
            dgvUsers.AutoGenerateColumns = false;
            dgvUsers.AllowUserToAddRows = false;
            LoadGridData();
        }
    }
}
```

* Trong đó phương thức `setControl(...)`, `frmUsersLINQ_Load(...)` tương tự bài TH03.

* Lập trình nút Xóa (Thoát) (tương tự TH3), nhấp đúp vào nút Xóa, gõ lệnh.

```csharp
private void btnExit_Click(object sender, EventArgs e)
{
    if (MessageBox.Show("Bạn muốn thoát không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
    {
        this.Close();
    }
}
```

* Lập trình sự kiện `dgvUsers_CellEnter(object sender, DataGridViewCellEventArgs e)` tương tự bài TH03 (có thể copy nội dung từ bên bài TH03 sang).

* Nhấp phải chuột vào dgvUsers, chọn sự kiện, nhấp đúp vào CellEnter (chi tiết tại TH03).

```csharp
private void dgvUsers_CellEnter(object sender, DataGridViewCellEventArgs e)
{
    int i = e.RowIndex;
    if (i < 0) return;

    txtUserID.Text = dgvUsers.Rows[i].Cells["UserID"].Value.ToString();
    txtUsername.Text = dgvUsers.Rows[i].Cells["UserName"].Value.ToString();
    txtFullName.Text = dgvUsers.Rows[i].Cells["FullName"].Value.ToString();
    txtPassword.Text = dgvUsers.Rows[i].Cells["Password"].Value.ToString();
    txtPhone.Text = dgvUsers.Rows[i].Cells["Phone"].Value.ToString();
    txtEmail.Text = dgvUsers.Rows[i].Cells["Email"].Value.ToString();
    cbbRole.Text = dgvUsers.Rows[i].Cells["Role"].Value.ToString();
    txtCreatedDate.Text = Convert.ToDateTime(dgvUsers.Rows[i].Cells["CreatedDate"].Value).ToString("dd/MM/yyyy");

    if ((bool)dgvUsers.Rows[i].Cells["Status"].Value == true)
    {
        ckbStatus.Checked = true;
        ckbStatus.Text = "Tài khoản đang mở";
    }
    else
    {
        ckbStatus.Checked = false;
        ckbStatus.Text = "Tài khoản đã đóng";
    }
}
```

* Lập trình nút xóa, nhấp đúp vào nút Xóa trên giao diện, gõ nội dung như sau.

```csharp
private void btnDelete_Click(object sender, EventArgs e)
{
    if (dgvUsers.CurrentRow == null) return;
    int id = (int)dgvUsers.CurrentRow.Cells["UserID"].Value;
    
    if (MessageBox.Show("Bạn muốn xóa bản ghi này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Stop) == DialogResult.Yes)
    {
        var userDelete = db.Users.SingleOrDefault(u => u.UserID == id);
        
        if (userDelete != null)
        {
            db.Users.Remove(userDelete);
            db.SaveChanges();
            LoadGridData();
        }
    }
}
```

* Lập trình nút Thêm/Sửa/Không lưu (tương tự TH03, có thể copy), nhấp đúp nút tương ứng.

```csharp
// Nút Thêm mới
private void btnAdd_Click(object sender, EventArgs e)
{
    AddNew = true;
    setControl(true);
    txtUserID.Clear();
    txtUsername.Clear();
    txtFullName.Clear();
    txtPassword.Clear();
    txtPhone.Clear();
    txtEmail.Clear();
    cbbRole.Text = "Staff";
    txtCreatedDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
    ckbStatus.Checked = true;
    txtUsername.Focus();
}

// Nút Sửa
private void btnEdit_Click(object sender, EventArgs e)
{
    AddNew = false;
    setControl(true);
    txtUsername.Enabled = false;
    txtUsername.Focus();
}

// Nút Không lưu
private void btnCancel_Click(object sender, EventArgs e)
{
    setControl(false);
    //Lấy lại thông tin từ lưới lên các TextBox
    if (dgvUsers.CurrentRow != null)
    {
        int rowIndex = dgvUsers.CurrentRow.Index;
        int colIndex = dgvUsers.CurrentCell.ColumnIndex;
        DataGridViewCellEventArgs args = new DataGridViewCellEventArgs(colIndex, rowIndex);
        dgvUsers_CellEnter(dgvUsers, args);
    }
}
```

* Thêm phương thức `GetMD5(....)` (tương tự TH03, có thể copy).

```csharp
public string GetMD5(string password)
{
    using (MD5 md5 = MD5.Create())
    {
        byte[] inputBytes = Encoding.UTF8.GetBytes(password);
        byte[] hashBytes = md5.ComputeHash(inputBytes);
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < hashBytes.Length; i++)
        {
            sb.Append(hashBytes[i].ToString("x2"));
        }
        return sb.ToString();
    }
}
```

* Lập trình nút Lưu, có kiểm tra trùng dữ liệu (Username).

```csharp
private void btnSave_Click(object sender, EventArgs e)
{
    if (txtUsername.Text.Trim() == "")
    {
        MessageBox.Show("Thông tin tên sử dụng không được để trống!", "Thông báo");
        txtUsername.Focus();
        return;
    }

    // Tương tự kiểm tra các thông tin khác

    if (AddNew) //Nếu trước đó ấn vào nút thêm mới thì đoạn này sẽ thực hiện
    {
        //Kiểm tra trùng Username
        string inputUsername = txtUsername.Text.Trim();
        bool isExisted = db.Users.Any(u => u.Username == inputUsername);

        if (isExisted)
        {
            MessageBox.Show("Tên đăng nhập này đã tồn tại! Vui lòng chọn tên khác.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtUsername.Focus();
            return;
        }

        // Nếu không trùng thì tiến hành thêm mới
        tblUsers newUser = new tblUsers
        {
            Username = txtUsername.Text.Trim(),
            Password = GetMD5(txtPassword.Text.Trim()),
            FullName = txtFullName.Text.Trim(),
            Phone = txtPhone.Text.Trim(),
            Email = txtEmail.Text.Trim(),
            Role = cbbRole.Text.Trim(),
            Status = ckbStatus.Checked,
            CreatedDate = DateTime.Now
        };
        db.Users.Add(newUser);
        db.SaveChanges();
        LoadGridData();
    }
    else // Nếu trước đó ấn vào nút sửa thì đoạn này sẽ thực hiện
    {
        if (dgvUsers.CurrentRow == null) return;
        int id = int.Parse(txtUserID.Text);
        
        // Tìm đối tượng cần sửa bằng LINQ
        tblUsers userUpdate = db.Users.SingleOrDefault(u => u.UserID == id);

        if (userUpdate != null)
        {
            userUpdate.FullName = txtFullName.Text.Trim();
            userUpdate.Phone = txtPhone.Text.Trim();
            userUpdate.Email = txtEmail.Text.Trim();
            userUpdate.Role = cbbRole.Text.Trim();
            userUpdate.Status = ckbStatus.Checked;
            userUpdate.CreatedDate = DateTime.ParseExact(txtCreatedDate.Text, "dd/MM/yyyy", null);

            db.SaveChanges();
            LoadGridData();
        }
    }
}
```

## Lưu ý:

* Sau này khi làm việc với các form khác thì bước 2.2 không cần thực hiện.

* Tạo một lớp tương ứng như bước 2.1.

* Thêm một dòng tương ứng trong bước 2.3.

* Ví dụ: Tạo form để kết nối với bảng `tblCategories` thì tạo lớp `tblCategories.cs` tương ứng.

* Trong `DataContext.cs` thêm dòng:
  `public DbSet<tblCategories> Categories { get; set; }`

```csharp
internal class DataContext: DbContext
{
    public DataContext(): base("name=MyConnectionString")
    {
    }
    public DbSet<tblUsers> Users { get; set; }
    public DbSet<tblCategories> Categories { get; set; }
}
```
    