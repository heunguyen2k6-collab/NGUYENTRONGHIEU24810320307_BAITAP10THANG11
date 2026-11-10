CREATE DATABASE ProjectTaskDB;
GO

USE ProjectTaskDB;
GO

-- 1. Bảng Dự án
CREATE TABLE DuAn (
    MaDuAn INT IDENTITY(1,1) PRIMARY KEY,
    TenDuAn NVARCHAR(150) NOT NULL,
    NgayBatDau DATETIME,
    NgayKetThuc DATETIME,
    TrangThai NVARCHAR(50)
);

-- 2. Bảng Thành viên
CREATE TABLE ThanhVien (
    MaThanhVien INT IDENTITY(1,1) PRIMARY KEY,
    HoTen NVARCHAR(100) NOT NULL,
    Email VARCHAR(100) UNIQUE,
    ChuyenMon NVARCHAR(100)
);

-- 3. Bảng Công việc (Task)
CREATE TABLE CongViec (
    MaTask INT IDENTITY(1,1) PRIMARY KEY,
    MaDuAn INT FOREIGN KEY REFERENCES DuAn(MaDuAn) ON DELETE CASCADE,
    TenTask NVARCHAR(200) NOT NULL,
    MoTa NVARCHAR(MAX),
    HanNop DATETIME,
    DoUuTien NVARCHAR(20),
    TrangThai NVARCHAR(50) -- "To Do", "In Progress", "Review", "Done"
);

-- 4. Bảng Phân công
CREATE TABLE PhanCong (
    MaTask INT FOREIGN KEY REFERENCES CongViec(MaTask) ON DELETE CASCADE,
    MaThanhVien INT FOREIGN KEY REFERENCES ThanhVien(MaThanhVien) ON DELETE CASCADE,
    NgayGiao DATETIME DEFAULT GETDATE(),
    PRIMARY KEY (MaTask, MaThanhVien)
);

-- Thêm dữ liệu mẫu thử nghiệm
INSERT INTO DuAn (TenDuAn, NgayBatDau, NgayKetThuc, TrangThai) 
VALUES (N'Quản lý bán hàng', GETDATE(), GETDATE()+30, N'Đang chạy');

INSERT INTO ThanhVien (HoTen, Email, ChuyenMon) 
VALUES (N'Nguyễn Văn A', 'a@gmail.com', 'Backend'),
       (N'Trần Thị B', 'b@gmail.com', 'Frontend');

INSERT INTO CongViec (MaDuAn, TenTask, MoTa, HanNop, DoUuTien, TrangThai)
VALUES (1, N'Thiết kế CSDL', N'Tạo các bảng trong SQL', GETDATE()-1, N'Cao', N'In Progress'),
       (1, N'Viết GUI Windows Forms', N'Thiết kế giao diện', GETDATE()+5, N'Trung bình', N'To Do');

INSERT INTO PhanCong (MaTask, MaThanhVien) VALUES (1, 1), (1, 2);