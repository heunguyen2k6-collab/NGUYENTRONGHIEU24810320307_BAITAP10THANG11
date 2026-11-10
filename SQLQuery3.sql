CREATE DATABASE KaraokeDB;
GO
USE KaraokeDB;
GO

-- 1. Bảng Phòng Hát
CREATE TABLE PhongHat (
    MaPhong INT IDENTITY(1,1) PRIMARY KEY,
    TenPhong NVARCHAR(50) NOT NULL,
    LoaiPhong NVARCHAR(30),
    GiaTheoGio DECIMAL(18,2),
    TrangThai NVARCHAR(20) DEFAULT N'Trống'
);

-- 2. Bảng Dịch Vụ
CREATE TABLE DichVu (
    MaDV INT IDENTITY(1,1) PRIMARY KEY,
    TenDV NVARCHAR(100) NOT NULL,
    DonGia DECIMAL(18,2),
    TonKho INT
);

-- 3. Bảng Hóa Đơn
CREATE TABLE HoaDon (
    MaHD INT IDENTITY(1,1) PRIMARY KEY,
    MaPhong INT FOREIGN KEY REFERENCES PhongHat(MaPhong),
    GioVao DATETIME NOT NULL,
    GioRa DATETIME NULL,
    TongTienPhong DECIMAL(18,2) DEFAULT 0,
    TongTienDichVu DECIMAL(18,2) DEFAULT 0,
    TrangThai BIT DEFAULT 0 -- 0: Chưa thanh toán, 1: Đã thanh toán
);

-- 4. Bảng Chi Tiết Dịch Vụ
CREATE TABLE ChiTietDichVu (
    MaHD INT FOREIGN KEY REFERENCES HoaDon(MaHD),
    MaDV INT FOREIGN KEY REFERENCES DichVu(MaDV),
    SoLuong INT CHECK (SoLuong > 0),
    DonGia DECIMAL(18,2),
    PRIMARY KEY (MaHD, MaDV)
);

-- Chèn dữ liệu mẫu ban đầu
INSERT INTO PhongHat (TenPhong, LoaiPhong, GiaTheoGio, TrangThai) VALUES
(N'Phòng VIP 01', N'VIP', 200000, N'Trống'),
(N'Phòng VIP 02', N'VIP', 200000, N'Trống'),
(N'Phòng Thường 01', N'Thường', 120000, N'Trống'),
(N'Phòng Thường 02', N'Thường', 120000, N'Trống');

INSERT INTO DichVu (TenDV, DonGia, TonKho) VALUES
(N'Bia Heineken (Lon)', 25000, 100),
(N'Nước ngọt (Lon)', 15000, 150),
(N'Trái cây dĩa', 120000, 30),
(N'Hạt điều / Đậu phụng', 35000, 50);