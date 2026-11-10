-- 1. Bảng KhachHang
CREATE TABLE KhachHang (
    MaKH INT IDENTITY(1,1) PRIMARY KEY,
    TenKH NVARCHAR(100) NOT NULL,
    DienThoai VARCHAR(15) UNIQUE,
    DiaChi NVARCHAR(200)
);

-- 2. Bảng Xe
CREATE TABLE Xe (
    BienSo VARCHAR(20) PRIMARY KEY,
    MaKH INT FOREIGN KEY REFERENCES KhachHang(MaKH) ON DELETE CASCADE,
    HieuXe NVARCHAR(50),
    NamSanXuat INT
);

-- 3. Bảng PhuTung
CREATE TABLE PhuTung (
    MaPhuTung INT IDENTITY(1,1) PRIMARY KEY,
    TenPhuTung NVARCHAR(150) NOT NULL,
    DonGia DECIMAL(18,2) DEFAULT 0,
    SoLuongTon INT CHECK (SoLuongTon >= 0)
);

-- 4. Bảng PhieuSuaChua
CREATE TABLE PhieuSuaChua (
    MaPhieu INT IDENTITY(1,1) PRIMARY KEY,
    BienSo VARCHAR(20) FOREIGN KEY REFERENCES Xe(BienSo),
    NgayNhan DATETIME DEFAULT GETDATE(),
    NoiDungSua NVARCHAR(MAX),
    TongTien DECIMAL(18,2) DEFAULT 0,
    TrangThai NVARCHAR(30) DEFAULT N'Đang sửa'
);

-- 5. Bảng ChiTietSuaChua
CREATE TABLE ChiTietSuaChua (
    MaPhieu INT FOREIGN KEY REFERENCES PhieuSuaChua(MaPhieu),
    MaPhuTung INT FOREIGN KEY REFERENCES PhuTung(MaPhuTung),
    SoLuong INT CHECK (SoLuong > 0),
    TienCong DECIMAL(18,2) DEFAULT 0,
    PRIMARY KEY (MaPhieu, MaPhuTung)
);

-- Thêm dữ liệu mẫu ban đầu
INSERT INTO KhachHang (TenKH, DienThoai, DiaChi) VALUES
(N'Nguyễn Văn A', '0901234567', N'Hà Nội'),
(N'Trần Thị B', '0987654321', N'TP. Hồ Chí Minh');

INSERT INTO Xe (BienSo, MaKH, HieuXe, NamSanXuat) VALUES
('30A-12345', 1, 'Toyota', 2020),
('51H-99999', 2, 'VinFast', 2022);

INSERT INTO PhuTung (TenPhuTung, DonGia, SoLuongTon) VALUES
(N'Lọc nhớt', 150000, 20),
(N'Má phanh trước', 850000, 10),
(N'Gạt mưa', 200000, 15),
(N'Lốp xe 205/55R16', 1800000, 8);