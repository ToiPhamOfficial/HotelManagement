-- ============================================================
-- HỆ THỐNG QUẢN LÝ KHÁCH SẠN
-- Database: HotelManagementDB
-- Tác giả: [Tên sinh viên]
-- Phiên bản: 1.0
-- ============================================================

USE master;
GO

IF EXISTS (SELECT name FROM sys.databases WHERE name = 'HotelManagementDB')
    DROP DATABASE HotelManagementDB;
GO

CREATE DATABASE HotelManagementDB;
GO

USE HotelManagementDB;
GO

-- ============================================================
-- BẢNG LOẠI PHÒNG
-- ============================================================
CREATE TABLE LoaiPhong (
    MaLoaiPhong     INT IDENTITY(1,1) PRIMARY KEY,
    TenLoai         NVARCHAR(100)   NOT NULL,
    GiaMoiGio       DECIMAL(18,2)   NOT NULL DEFAULT 0,
    GiaMoiDem       DECIMAL(18,2)   NOT NULL DEFAULT 0,
    MoTa            NVARCHAR(500),
    SoNguoiToiDa    INT             NOT NULL DEFAULT 2,
    TrangThai       BIT             NOT NULL DEFAULT 1  -- 1: Đang dùng, 0: Ngừng
);
GO

-- ============================================================
-- BẢNG PHÒNG
-- ============================================================
CREATE TABLE Phong (
    MaPhong         INT IDENTITY(1,1) PRIMARY KEY,
    SoPhong         NVARCHAR(10)    NOT NULL UNIQUE,
    MaLoaiPhong     INT             NOT NULL,
    Tang            INT             NOT NULL DEFAULT 1,
    TrangThai       NVARCHAR(20)    NOT NULL DEFAULT N'Trống',
                                    -- Trống / Đang sử dụng / Đang dọn / Bảo trì
    MoTa            NVARCHAR(500),
    HinhAnh         NVARCHAR(500),
    NgayTao         DATETIME        NOT NULL DEFAULT GETDATE(),
    CONSTRAINT FK_Phong_LoaiPhong FOREIGN KEY (MaLoaiPhong) REFERENCES LoaiPhong(MaLoaiPhong)
);
GO

-- ============================================================
-- BẢNG KHÁCH HÀNG
-- ============================================================
CREATE TABLE KhachHang (
    MaKhachHang     INT IDENTITY(1,1) PRIMARY KEY,
    HoTen           NVARCHAR(100)   NOT NULL,
    CCCD            NVARCHAR(20)    NOT NULL UNIQUE,
    GioiTinh        NVARCHAR(10),
    NgaySinh        DATE,
    DiaChi          NVARCHAR(300),
    SoDienThoai     NVARCHAR(15)    NOT NULL,
    Email           NVARCHAR(150),
    QuocTich        NVARCHAR(100)   DEFAULT N'Việt Nam',
    GhiChu          NVARCHAR(500),
    NgayTao         DATETIME        NOT NULL DEFAULT GETDATE(),
    TrangThai       BIT             NOT NULL DEFAULT 1
);
GO

-- ============================================================
-- BẢNG NHÂN VIÊN
-- ============================================================
CREATE TABLE NhanVien (
    MaNhanVien      INT IDENTITY(1,1) PRIMARY KEY,
    HoTen           NVARCHAR(100)   NOT NULL,
    CCCD            NVARCHAR(20)    NOT NULL UNIQUE,
    GioiTinh        NVARCHAR(10),
    NgaySinh        DATE,
    DiaChi          NVARCHAR(300),
    SoDienThoai     NVARCHAR(15)    NOT NULL,
    Email           NVARCHAR(150),
    ChucVu          NVARCHAR(100)   NOT NULL DEFAULT N'Nhân viên',
    LuongCoBan      DECIMAL(18,2)   NOT NULL DEFAULT 0,
    NgayVaoLam      DATE            NOT NULL DEFAULT GETDATE(),
    TrangThai       BIT             NOT NULL DEFAULT 1,
    GhiChu          NVARCHAR(500)
);
GO

-- ============================================================
-- BẢNG TÀI KHOẢN (PHÂN QUYỀN)
-- ============================================================
CREATE TABLE TaiKhoan (
    MaTaiKhoan      INT IDENTITY(1,1) PRIMARY KEY,
    TenDangNhap     NVARCHAR(50)    NOT NULL UNIQUE,
    MatKhau         NVARCHAR(256)   NOT NULL,  -- Lưu hash MD5
    MaNhanVien      INT             NOT NULL,
    VaiTro          NVARCHAR(20)    NOT NULL DEFAULT 'NhanVien',
                                    -- Admin / QuanLy / NhanVien
    TrangThai       BIT             NOT NULL DEFAULT 1,
    LanDangNhapCuoi DATETIME,
    NgayTao         DATETIME        NOT NULL DEFAULT GETDATE(),
    CONSTRAINT FK_TaiKhoan_NhanVien FOREIGN KEY (MaNhanVien) REFERENCES NhanVien(MaNhanVien)
);
GO

-- ============================================================
-- BẢNG ĐẶT PHÒNG
-- ============================================================
CREATE TABLE DatPhong (
    MaDatPhong      INT IDENTITY(1,1) PRIMARY KEY,
    MaPhong         INT             NOT NULL,
    MaKhachHang     INT             NOT NULL,
    MaNhanVienTao   INT             NOT NULL,
    NgayDat         DATETIME        NOT NULL DEFAULT GETDATE(),
    NgayNhanPhong   DATETIME        NOT NULL,
    NgayTraPhong    DATETIME        NOT NULL,
    LoaiDat         NVARCHAR(10)    NOT NULL DEFAULT N'Ngày',  -- Ngày / Giờ
    GiaPhong        DECIMAL(18,2)   NOT NULL,
    TrangThai       NVARCHAR(30)    NOT NULL DEFAULT N'Đã đặt',
                                    -- Đã đặt / Đang ở / Đã trả / Hủy
    GhiChu          NVARCHAR(500),
    CONSTRAINT FK_DatPhong_Phong    FOREIGN KEY (MaPhong)       REFERENCES Phong(MaPhong),
    CONSTRAINT FK_DatPhong_KH       FOREIGN KEY (MaKhachHang)   REFERENCES KhachHang(MaKhachHang),
    CONSTRAINT FK_DatPhong_NV       FOREIGN KEY (MaNhanVienTao) REFERENCES NhanVien(MaNhanVien)
);
GO

-- ============================================================
-- BẢNG DỊCH VỤ
-- ============================================================
CREATE TABLE DichVu (
    MaDichVu        INT IDENTITY(1,1) PRIMARY KEY,
    TenDichVu       NVARCHAR(150)   NOT NULL,
    DonViTinh       NVARCHAR(50)    NOT NULL DEFAULT N'Lần',
    DonGia          DECIMAL(18,2)   NOT NULL DEFAULT 0,
    LoaiDichVu      NVARCHAR(100),  -- Ăn uống / Giặt ủi / Spa / Vận chuyển / Khác
    MoTa            NVARCHAR(500),
    TrangThai       BIT             NOT NULL DEFAULT 1
);
GO

-- ============================================================
-- BẢNG SỬ DỤNG DỊCH VỤ
-- ============================================================
CREATE TABLE SuDungDichVu (
    MaSuDung        INT IDENTITY(1,1) PRIMARY KEY,
    MaDatPhong      INT             NOT NULL,
    MaDichVu        INT             NOT NULL,
    SoLuong         INT             NOT NULL DEFAULT 1,
    DonGia          DECIMAL(18,2)   NOT NULL,
    ThanhTien       AS (SoLuong * DonGia) PERSISTED,
    ThoiGianSuDung  DATETIME        NOT NULL DEFAULT GETDATE(),
    GhiChu          NVARCHAR(500),
    MaNhanVien      INT,
    CONSTRAINT FK_SDDV_DatPhong FOREIGN KEY (MaDatPhong)  REFERENCES DatPhong(MaDatPhong),
    CONSTRAINT FK_SDDV_DichVu   FOREIGN KEY (MaDichVu)    REFERENCES DichVu(MaDichVu),
    CONSTRAINT FK_SDDV_NV       FOREIGN KEY (MaNhanVien)  REFERENCES NhanVien(MaNhanVien)
);
GO

-- ============================================================
-- BẢNG HÓA ĐƠN
-- ============================================================
CREATE TABLE HoaDon (
    MaHoaDon        INT IDENTITY(1,1) PRIMARY KEY,
    MaDatPhong      INT             NOT NULL UNIQUE,
    MaNhanVienTao   INT             NOT NULL,
    NgayLap         DATETIME        NOT NULL DEFAULT GETDATE(),
    TienPhong       DECIMAL(18,2)   NOT NULL DEFAULT 0,
    TienDichVu      DECIMAL(18,2)   NOT NULL DEFAULT 0,
    GiamGia         DECIMAL(18,2)   NOT NULL DEFAULT 0,
    TongTien        AS (TienPhong + TienDichVu - GiamGia) PERSISTED,
    PhuongThucTT    NVARCHAR(50)    DEFAULT N'Tiền mặt',  -- Tiền mặt / Chuyển khoản / Thẻ
    TrangThai       NVARCHAR(20)    NOT NULL DEFAULT N'Chưa thanh toán',
                                    -- Chưa thanh toán / Đã thanh toán
    GhiChu          NVARCHAR(500),
    CONSTRAINT FK_HoaDon_DatPhong   FOREIGN KEY (MaDatPhong)    REFERENCES DatPhong(MaDatPhong),
    CONSTRAINT FK_HoaDon_NV         FOREIGN KEY (MaNhanVienTao) REFERENCES NhanVien(MaNhanVien)
);
GO

-- ============================================================
-- STORED PROCEDURES
-- ============================================================

-- SP: Đăng nhập
CREATE PROCEDURE SP_DangNhap
    @TenDangNhap    NVARCHAR(50),
    @MatKhau        NVARCHAR(256)
AS
BEGIN
    SELECT tk.MaTaiKhoan, tk.TenDangNhap, tk.VaiTro,
           nv.HoTen, nv.MaNhanVien, nv.ChucVu
    FROM TaiKhoan tk
    INNER JOIN NhanVien nv ON tk.MaNhanVien = nv.MaNhanVien
    WHERE tk.TenDangNhap = @TenDangNhap
      AND tk.MatKhau = @MatKhau
      AND tk.TrangThai = 1
      AND nv.TrangThai = 1;

    IF @@ROWCOUNT > 0
        UPDATE TaiKhoan SET LanDangNhapCuoi = GETDATE()
        WHERE TenDangNhap = @TenDangNhap;
END
GO

-- SP: Lấy danh sách phòng kèm loại phòng
CREATE PROCEDURE SP_GetDanhSachPhong
    @TrangThai NVARCHAR(20) = NULL
AS
BEGIN
    SELECT p.MaPhong, p.SoPhong, p.Tang, p.TrangThai,
           lp.TenLoai, lp.GiaMoiGio, lp.GiaMoiDem, lp.SoNguoiToiDa,
           p.MoTa, p.HinhAnh
    FROM Phong p
    INNER JOIN LoaiPhong lp ON p.MaLoaiPhong = lp.MaLoaiPhong
    WHERE (@TrangThai IS NULL OR p.TrangThai = @TrangThai)
    ORDER BY p.Tang, p.SoPhong;
END
GO

-- SP: Kiểm tra phòng có trống không
CREATE PROCEDURE SP_KiemTraPhongTrong
    @MaPhong        INT,
    @NgayNhan       DATETIME,
    @NgayTra        DATETIME,
    @MaDatPhong     INT = 0  -- 0 = đặt mới
AS
BEGIN
    SELECT COUNT(*) AS SoConflict
    FROM DatPhong
    WHERE MaPhong = @MaPhong
      AND MaDatPhong != @MaDatPhong
      AND TrangThai NOT IN (N'Đã trả', N'Hủy')
      AND NOT (@NgayTra <= NgayNhanPhong OR @NgayNhan >= NgayTraPhong);
END
GO

-- SP: Thống kê doanh thu theo tháng
CREATE PROCEDURE SP_ThongKeDoanhThu
    @Nam    INT,
    @Thang  INT = 0  -- 0 = cả năm
AS
BEGIN
    SELECT
        MONTH(hd.NgayLap)   AS Thang,
        COUNT(hd.MaHoaDon)  AS SoHoaDon,
        SUM(hd.TienPhong)   AS TongTienPhong,
        SUM(hd.TienDichVu)  AS TongTienDichVu,
        SUM(hd.TongTien)    AS TongDoanhThu
    FROM HoaDon hd
    WHERE YEAR(hd.NgayLap) = @Nam
      AND hd.TrangThai = N'Đã thanh toán'
      AND (@Thang = 0 OR MONTH(hd.NgayLap) = @Thang)
    GROUP BY MONTH(hd.NgayLap)
    ORDER BY MONTH(hd.NgayLap);
END
GO

-- SP: Dashboard - Tổng quan hệ thống
CREATE PROCEDURE SP_Dashboard
AS
BEGIN
    SELECT
        (SELECT COUNT(*) FROM Phong WHERE TrangThai = N'Trống')         AS PhongTrong,
        (SELECT COUNT(*) FROM Phong WHERE TrangThai = N'Đang sử dụng') AS PhongDangDung,
        (SELECT COUNT(*) FROM Phong WHERE TrangThai = N'Bảo trì')       AS PhongBaoTri,
        (SELECT COUNT(*) FROM DatPhong WHERE TrangThai = N'Đang ở'
            AND CAST(NgayNhanPhong AS DATE) = CAST(GETDATE() AS DATE))  AS CheckInHomNay,
        (SELECT COUNT(*) FROM DatPhong WHERE TrangThai = N'Đang ở'
            AND CAST(NgayTraPhong AS DATE) = CAST(GETDATE() AS DATE))   AS CheckOutHomNay,
        (SELECT ISNULL(SUM(TongTien), 0) FROM HoaDon
            WHERE TrangThai = N'Đã thanh toán'
            AND CAST(NgayLap AS DATE) = CAST(GETDATE() AS DATE))        AS DoanhThuHomNay;
END
GO

-- SP: Tính tiền phòng
CREATE PROCEDURE SP_TinhTienPhong
    @MaDatPhong INT
AS
BEGIN
    DECLARE @NgayNhan DATETIME, @NgayTra DATETIME, @GiaPhong DECIMAL(18,2), @LoaiDat NVARCHAR(10)
    SELECT @NgayNhan = NgayNhanPhong, @NgayTra = NgayTraPhong,
           @GiaPhong = GiaPhong, @LoaiDat = LoaiDat
    FROM DatPhong WHERE MaDatPhong = @MaDatPhong;

    DECLARE @TongTienPhong DECIMAL(18,2)
    IF @LoaiDat = N'Ngày'
        SET @TongTienPhong = DATEDIFF(DAY, @NgayNhan, @NgayTra) * @GiaPhong
    ELSE
        SET @TongTienPhong = DATEDIFF(HOUR, @NgayNhan, @NgayTra) * @GiaPhong

    DECLARE @TongTienDV DECIMAL(18,2)
    SELECT @TongTienDV = ISNULL(SUM(ThanhTien), 0)
    FROM SuDungDichVu WHERE MaDatPhong = @MaDatPhong;

    SELECT @TongTienPhong AS TienPhong, @TongTienDV AS TienDichVu,
           (@TongTienPhong + @TongTienDV) AS TongCong;
END
GO

-- ============================================================
-- DỮ LIỆU MẪU
-- ============================================================

-- Loại phòng
INSERT INTO LoaiPhong (TenLoai, GiaMoiGio, GiaMoiDem, SoNguoiToiDa, MoTa) VALUES
(N'Phòng Standard',     80000,   300000, 2, N'Phòng tiêu chuẩn, 1 giường đôi, điều hòa, TV'),
(N'Phòng Deluxe',      120000,   500000, 2, N'Phòng cao cấp, view đẹp, minibar, bathtub'),
(N'Phòng Suite',       200000,   900000, 3, N'Phòng hạng sang, phòng khách riêng, jacuzzi'),
(N'Phòng VIP',         350000,  1500000, 4, N'Phòng VIP tầng thượng, butler service'),
(N'Phòng Family',      150000,   700000, 5, N'Phòng gia đình, 2 phòng ngủ, bếp nhỏ');

-- Phòng
INSERT INTO Phong (SoPhong, MaLoaiPhong, Tang, TrangThai) VALUES
('101', 1, 1, N'Trống'), ('102', 1, 1, N'Đang sử dụng'), ('103', 1, 1, N'Trống'),
('104', 2, 1, N'Trống'), ('105', 2, 1, N'Bảo trì'),
('201', 1, 2, N'Trống'), ('202', 2, 2, N'Đang sử dụng'), ('203', 3, 2, N'Trống'),
('204', 1, 2, N'Trống'), ('205', 2, 2, N'Trống'),
('301', 3, 3, N'Trống'), ('302', 4, 3, N'Trống'), ('303', 5, 3, N'Trống'),
('401', 4, 4, N'Trống'), ('402', 4, 4, N'Đang sử dụng');

-- Nhân viên
INSERT INTO NhanVien (HoTen, CCCD, GioiTinh, NgaySinh, DiaChi, SoDienThoai, Email, ChucVu, LuongCoBan) VALUES
(N'Nguyễn Văn An',   '001234567890', N'Nam',  '1990-05-15', N'Hà Nội',   '0901234567', 'an.nv@hotel.com',    N'Quản lý',    15000000),
(N'Trần Thị Bình',   '002345678901', N'Nữ',   '1995-08-20', N'TP.HCM',   '0912345678', 'binh.tt@hotel.com',  N'Lễ tân',      8000000),
(N'Lê Văn Cường',    '003456789012', N'Nam',  '1998-03-10', N'Đà Nẵng',  '0923456789', 'cuong.lv@hotel.com', N'Lễ tân',      8000000),
(N'Phạm Thị Dung',   '004567890123', N'Nữ',   '1993-11-25', N'Huế',      '0934567890', 'dung.pt@hotel.com',  N'Kế toán',    10000000),
(N'Hoàng Văn Em',    '005678901234', N'Nam',  '2000-07-05', N'Vinh',     '0945678901', 'em.hv@hotel.com',    N'Nhân viên',   6000000);

-- Tài khoản (mật khẩu: Admin@123 → hash MD5)
INSERT INTO TaiKhoan (TenDangNhap, MatKhau, MaNhanVien, VaiTro) VALUES
('admin',    '8a35a57e0481b02e9e71dd48c1f40e0e', 1, 'Admin'),
('quanly',   '8a35a57e0481b02e9e71dd48c1f40e0e', 1, 'QuanLy'),
('letan1',   '8a35a57e0481b02e9e71dd48c1f40e0e', 2, 'NhanVien'),
('letan2',   '8a35a57e0481b02e9e71dd48c1f40e0e', 3, 'NhanVien'),
('ketoan',   '8a35a57e0481b02e9e71dd48c1f40e0e', 4, 'NhanVien');

-- Khách hàng
INSERT INTO KhachHang (HoTen, CCCD, GioiTinh, NgaySinh, DiaChi, SoDienThoai, Email, QuocTich) VALUES
(N'Nguyễn Thị Mai',  '011111111111', N'Nữ',  '1988-04-12', N'Hà Nội',  '0911111111', 'mai@gmail.com',   N'Việt Nam'),
(N'Trần Văn Hùng',   '022222222222', N'Nam', '1985-09-30', N'TP.HCM',  '0922222222', 'hung@gmail.com',  N'Việt Nam'),
(N'John Smith',       '033333333333', N'Nam', '1990-01-15', N'New York', '0933333333', 'john@gmail.com',  N'Mỹ'),
(N'Lê Thị Hoa',      '044444444444', N'Nữ',  '1992-07-22', N'Đà Nẵng', '0944444444', 'hoa@gmail.com',   N'Việt Nam'),
(N'Phạm Văn Khoa',   '055555555555', N'Nam', '1995-12-08', N'Vinh',    '0955555555', 'khoa@gmail.com',  N'Việt Nam');

-- Dịch vụ
INSERT INTO DichVu (TenDichVu, DonViTinh, DonGia, LoaiDichVu) VALUES
(N'Ăn sáng buffet',    N'Người',    150000, N'Ăn uống'),
(N'Ăn tối theo menu',  N'Người',    250000, N'Ăn uống'),
(N'Nước uống minibar', N'Chai',      30000, N'Ăn uống'),
(N'Giặt quần áo',      N'Kg',        50000, N'Giặt ủi'),
(N'Ủi quần áo',        N'Cái',       20000, N'Giặt ủi'),
(N'Massage body',      N'Lần',      300000, N'Spa'),
(N'Thuê xe đưa đón',   N'Lượt',     200000, N'Vận chuyển'),
(N'Internet tốc độ cao',N'Ngày',     50000, N'Tiện ích'),
(N'Bãi đậu xe ô tô',   N'Ngày',     80000, N'Tiện ích'),
(N'Phòng họp (nhỏ)',   N'Giờ',      200000, N'Tiện ích');

PRINT N'✅ Database HotelManagementDB đã được tạo thành công!';
GO