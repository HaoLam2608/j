create database QLCF;
go
use QLCF
go
CREATE TABLE ChiNhanh (
    MaChiNhanh NCHAR(20) PRIMARY KEY,
    TenChiNhanh NVARCHAR(100) Unique,
    DiaChi NVARCHAR(255) Default 'Không xác định',
    SoDienThoai VARCHAR(10) CHECK (len(SoDienThoai) =10),
    NgayThanhLap DATETIME
);
go

-----------------------QL KHACH HANG----------------------
CREATE TABLE LOAIKH
(
	MALOAI INT IDENTITY(1,1) PRIMARY KEY,
	TENLOAI NVARCHAR(100) --Thân thiết, VIP, THÀNH VIÊN
)
go
CREATE TABLE KHACHHANG (
    MaKH NCHAR(20) PRIMARY KEY,
    TenKH NVARCHAR(50) NOT NULL,
	MALOAI INT FOREIGN KEY REFERENCES LOAIKH(MALOAI),
    SDT NCHAR(10),
	SODIEMTHUONG INT, --KHÁCH HÀNG MUA MỘT LY NƯỚC ĐƯỢC CỘNG 5 ĐIỂM
)
GO

-----------------------QL SAN PHAM----------------------
CREATE TABLE LOAISP
(
	MALOAI INT IDENTITY(1,1) PRIMARY KEY,
	TENLOAI NVARCHAR(100) --cà phê, trà, đá xay, banhs
)
GO
CREATE TABLE SanPham (
    MaSanPham NCHAR(20) PRIMARY KEY,
	MALOAI INT FOREIGN KEY REFERENCES LOAISP(MALOAI),
    TenSanPham NVARCHAR(100) UNIQUE,
    DonGia DECIMAL(10,2) CHECK (DonGia > 0),
    MoTa NVARCHAR(200)
);
go

CREATE TABLE HoaDon (
    MaHoaDon NCHAR(20) PRIMARY KEY,
    NgayTao DATE DEFAULT getdate(),
	GIAMGIA FLOAT,
    TongTien DECIMAL(10,2) CHECK (TongTien > 0),
	THANHTIEN FLOAT,
    MaChiNhanh NCHAR(20)  FOREIGN KEY REFERENCES ChiNhanh(MaChiNhanh),
	MAKH NCHAR(20) FOREIGN KEY REFERENCES KHACHHANG(MAKH) 
); 
go

CREATE TABLE ChiTietHoaDon (
    MaHoaDon NCHAR(20),
    MaSanPham NCHAR(20),
    SoLuong INT CHECK (SoLuong > 0),
    DonGia DECIMAL(10,2) CHECK (DonGia > 0),
    PRIMARY KEY (MaHoaDon, MaSanPham),
    FOREIGN KEY (MaHoaDon) REFERENCES HoaDon(MaHoaDon),
    FOREIGN KEY (MaSanPham) REFERENCES SanPham(MaSanPham)
);
go

--------------------------------QL KHO----------------------------------------
CREATE TABLE LOAINL
(
	MALOAI INT IDENTITY(1,1) PRIMARY KEY,
	TENLOAI NVARCHAR(100) --hạt cà phê,	trà, siro, topping, bột 											
)

CREATE TABLE DONVITINH
(
	MADVT INT IDENTITY(1,1) PRIMARY KEY,
	TENDVT NVARCHAR(100)	--kg, túi, bao, chai, thùng, hộp
)

CREATE TABLE NguyenLieu (
    MaNguyenLieu NCHAR(20) PRIMARY KEY,
	MALOAI INT FOREIGN KEY REFERENCES LOAINL(MALOAI),
    TenNguyenLieu NVARCHAR(100) UNIQUE,
    MADVT INT FOREIGN KEY REFERENCES DONVITINH(MADVT),
	SOLUONGTON INT
);
go


CREATE TABLE NhaCungCap (
    MaNhaCungCap NCHAR(20) PRIMARY KEY,
    TenNhaCungCap NVARCHAR(100),
    DiaChi NVARCHAR(255),
    SoDienThoai VARCHAR(15) UNIQUE CHECK (LEN(SoDienThoai) =10),
    Email VARCHAR(100) UNIQUE CHECK (Email LIKE '%@%')
);
go

CREATE TABLE CUNGUNG
(
	 MaNhaCungCap NCHAR(20) FOREIGN KEY REFERENCES NhaCungCap(MaNhaCungCap),
	 MaNguyenLieu NCHAR(20) FOREIGN KEY REFERENCES NguyenLieu(MaNguyenLieu),
	 PRIMARY KEY(MaNhaCungCap,MaNguyenLieu)
)
GO

CREATE TABLE PhieuNhap(
    MaPhieuNhap NCHAR(20) PRIMARY KEY,
    MaNhaCungCap NCHAR(20),
    NgayNhap DATETIME DEFAULT getdate(),
    TongTien DECIMAL(10,2) CHECK (TongTien > 0),
    MaChiNhanh NCHAR(20),
    FOREIGN KEY (MaNhaCungCap) REFERENCES NhaCungCap(MaNhaCungCap),
    FOREIGN KEY (MaChiNhanh) REFERENCES ChiNhanh(MaChiNhanh)
);
go

CREATE TABLE ChiTietPhieuNhap (
    MaPhieuNhap NCHAR(20),
    MaNguyenLieu NCHAR(20),
    SoLuong INT CHECK (SoLuong > 0),
    DonGia DECIMAL(10,2) CHECK (DonGia > 0),
    PRIMARY KEY (MaPhieuNhap, MaNguyenLieu),
    FOREIGN KEY (MaPhieuNhap) REFERENCES PhieuNhap(MaPhieuNhap),
    FOREIGN KEY (MaNguyenLieu) REFERENCES NguyenLieu(MaNguyenLieu)
);
go

------------------------------------QL NHAN VIEN-------------------------------
CREATE TABLE CHUCVU
(
	MACV INT IDENTITY(1,1) PRIMARY KEY,
	TENCHUCVU NVARCHAR(100)
)
CREATE TABLE NHOMQUYEN
(
MANHOM NCHAR(12) PRIMARY KEY,
TENNHOM NVARCHAR(100),
)

CREATE TABLE NhanVien (
    MaNhanVien NCHAR(12) PRIMARY KEY,
    TenNhanVien NVARCHAR(100),
    MACV INT FOREIGN KEY REFERENCES CHUCVU(MACV),
    SoDienThoai NVARCHAR(15) UNIQUE CHECK (LEN(SoDienThoai) = 10),
	DIACHI NVARCHAR(200),
    MaChiNhanh NCHAR(20),
	MANHOM NCHAR(12) NOT NULL FOREIGN KEY REFERENCES NHOMQUYEN(MANHOM),
    FOREIGN KEY (MaChiNhanh) REFERENCES ChiNhanh(MaChiNhanh),
	PASSWORD nchar(50),
	username nchar(50)
);

CREATE TABLE THONGTINNHANVIEN(
	MaNhanVien NCHAR(12) FOREIGN KEY REFERENCES NhanVien(MaNhanVien),
	PRIMARY KEY (MaNhanVien),
	QUEQUAN NVARCHAR(100),
	NGAYSINH DATE,
	CCCD NVARCHAR(15),
	GIOITINH NVARCHAR(5) CHECK (GIOITINH IN ('Nam',N'Nữ')),
	BANGCAP NVARCHAR(40) 
)

CREATE TABLE PHIEUXUAT
(
	MAPX NCHAR(20) PRIMARY KEY,
	MaNhanVien NCHAR(12) FOREIGN KEY REFERENCES NhanVien(MaNhanVien), --NHAN VIEN NÀO LẤY NGUYÊN LIỆU
	MaChiNhanh NCHAR(20) FOREIGN KEY REFERENCES ChiNhanh(MaChiNhanh),
	NGAYTAO DATETIME,
	GHICHU NVARCHAR(200)
)
GO
CREATE TABLE CHITIETPX
(
	MAPX NCHAR(20) FOREIGN KEY REFERENCES PHIEUXUAT(MAPX),
	MaNguyenLieu NCHAR(20) FOREIGN KEY REFERENCES NguyenLieu(MaNguyenLieu),
	SOLUONGXUAT INT
	PRIMARY KEY(MAPX, MaNguyenLieu)
)

------------------------------THEM DU LIEU----------------------


INSERT INTO ChiNhanh (MaChiNhanh, TenChiNhanh, DiaChi, SoDienThoai, NgayThanhLap)
VALUES 
(1, N'Chi nhánh Phú Nhuận', N'123 Đường Phú Nhuận, Quận Phú Nhuận, TP.HCM', '0901234567', '2021-05-10'),
(2, N'Chi nhánh Bến Thành', N'456 Đường Lê Lợi, Quận 1, TP.HCM', '0907654321', '2020-12-15'),
(3, N'Chi nhánh Thủ Đức', N'789 Đường Kha Vạn Cân, Quận Thủ Đức, TP.HCM', '0912345678', '2022-03-20'),
(4, N'Chi nhánh Quận 7', N'321 Đường Nguyễn Thị Thập, Quận 7, TP.HCM', '0923456789', '2021-01-25'),
(5, N'Chi nhánh Gò Vấp', N'654 Đường Nguyễn Văn Lượng, Quận Gò Vấp, TP.HCM', '0934567890', '2020-11-05')
---Thêm dữ liệu cho nhóm nhân viên
INSERT INTO NhomQuyen 
values
('NHOM01','Quanly'),
('NHOM02' , 'ThuNgan'),
('NHOM03' , 'NVKho'),
('NHOM04' , 'NhanVien')


INSERT INTO CHUCVU
VALUES
(N'Quản lý'),
(N'Nhân Viên Kho'),
(N'Nhân Viên Thu Ngân'),
(N'Nhân Viên Phục vụ'),
(N'Nhân Viên Pha Chế'),
(N'Nhân Viên Bảo Vệ')

INSERT INTO NhanVien (MaNhanVien, TenNhanVien, MACV, SoDienThoai, DIACHI, MaChiNhanh, MANHOM, password, username)
VALUES 
('NV00001', N'Nguyễn Văn An', 1, '0912345678', N'123 Đường Lý Tự Trọng, Quận 1, TP.HCM', 1, 'NHOM01', '123456', 'nv00001'),
('NV00002', N'Nguyễn Thị Bình', 2, '0923456789', N'456 Đường Nguyễn Văn Trỗi, Quận Phú Nhuận, TP.HCM', 1, 'NHOM02', '123456', 'nv00002'),
('NV00003', N'Trần Văn Cường', 1, '0934567890', N'789 Đường Hai Bà Trưng, Quận 3, TP.HCM', 2, 'NHOM03', '123456', 'nv00003'),
('NV00004', N'Nguyễn Y Bin', 2, '0945678901', N'12 Đường Hoàng Sa, Quận 1, TP.HCM', 2, 'NHOM01', '123456', 'nv00004'),
('NV00005', N'Lê Văn Định', 3, '0956789012', N'34 Đường Điện Biên Phủ, Quận Bình Thạnh, TP.HCM', 3, 'NHOM02', '123456', 'nv00005'),
('NV00006', N'Phạm Thị Yến', 4, '0967890123', N'56 Đường Nguyễn Thị Minh Khai, Quận 3, TP.HCM', 3, 'NHOM04', '123456', 'nv00006'),
('NV00007', N'Nguyễn Văn Phú', 2, '0978901234', N'78 Đường Phan Xích Long, Quận Phú Nhuận, TP.HCM', 1, 'NHOM01', '123456', 'nv00007'),
('NV00008', N'Huỳnh Minh An', 3, '0989012345', N'90 Đường Võ Văn Kiệt, Quận 5, TP.HCM', 2, 'NHOM02', '123456', 'nv00008'),
('NV00009', N'Trần Thị Giang', 1, '0990123456', N'12 Đường Phạm Văn Đồng, Quận Thủ Đức, TP.HCM', 3, 'NHOM03', '123456', 'nv00009'),
('NV00010', N'Nguyễn Văn Hiến', 2, '0912345670', N'34 Đường Lê Lợi, Quận 1, TP.HCM', 1, 'NHOM01', '123456', 'nv00010'),
('NV00011', N'Nguyễn Thị Lan', 3, '0923456701', N'56 Đường Trần Hưng Đạo, Quận 5, TP.HCM', 2, 'NHOM02', '123456', 'nv00011'),
('NV00012', N'Lê Văn Khiêm', 5, '0934567012', N'78 Đường Cách Mạng Tháng 8, Quận 10, TP.HCM', 3, 'NHOM04', '123456', 'nv00012'),
('NV00013', N'Nguyễn Văn Tuấn', 2, '0945670123', N'90 Đường Nguyễn Hữu Cảnh, Quận Bình Thạnh, TP.HCM', 1, 'NHOM01', '123456', 'nv00013'),
('NV00014', N'Trần Minh Tâm', 3, '0956781234', N'12 Đường Võ Thị Sáu, Quận 3, TP.HCM', 2, 'NHOM02', '123456', 'nv00014'),
('NV00015', N'Huỳnh Thị Ngân', 5, '0967892345', N'34 Đường Lê Quang Định, Quận Bình Thạnh, TP.HCM', 3, 'NHOM04', '123456', 'nv00015'),
('NV00016', N'Lê Trương Công Hiếu', 2, '0978903456', N'56 Đường Nguyễn Văn Linh, Quận 7, TP.HCM', 1, 'NHOM01', '123456', 'nv00016'),
('NV00017', N'Nguyễn Công An', 3, '0989014567', N'78 Đường Nam Kỳ Khởi Nghĩa, Quận 1, TP.HCM', 2, 'NHOM02', '123456', 'nv00017'),
('NV00018', N'Nguyễn Minh Chiến', 1, '0990125678', N'90 Đường Dương Bá Trạc, Quận 8, TP.HCM', 3, 'NHOM03', '123456', 'nv00018'),
('NV00019', N'Nguyễn Công Tiến', 2, '0912346789', N'12 Đường Trường Chinh, Quận Tân Bình, TP.HCM', 1, 'NHOM01', '123456', 'nv00019')

INSERT INTO THONGTINNHANVIEN (MaNhanVien, QUEQUAN, NGAYSINH, CCCD, GIOITINH, BANGCAP)
VALUES
('NV00001', N'Hà Nội', '1990-01-15', '012345678901', N'Nam', N'Cử nhân Kinh tế'),
('NV00002', N'Đà Nẵng', '1992-02-20', '012345678902', N'Nữ', N'Thạc sĩ Quản trị Kinh doanh'),
('NV00003', N'Hải Phòng', '1988-03-25', '012345678903', N'Nam', N'Cử nhân Công nghệ Thông tin'),
('NV00004', N'Hồ Chí Minh', '1995-04-10', '012345678904', N'Nữ', N'Cử nhân Marketing'),
('NV00005', N'Quảng Ninh', '1987-05-15', '012345678905', N'Nam', N'Thạc sĩ Tài chính Ngân hàng'),
('NV00006', N'Cần Thơ', '1990-06-18', '012345678906', N'Nữ', N'Cử nhân Quản lý Chuỗi Cung ứng'),
('NV00007', N'Hà Nội', '1993-07-22', '012345678907', N'Nam', N'Cử nhân Kỹ thuật'),
('NV00008', N'Nghệ An', '1994-08-05', '012345678908', N'Nữ', N'Cử nhân Kế toán'),
('NV00009', N'Huế', '1989-09-12', '012345678909', N'Nữ', N'Cử nhân Nhân sự'),
('NV00010', N'Hà Nội', '1991-10-17', '012345678910', N'Nam', N'Cử nhân Luật'),
('NV00011', N'Bình Dương', '1990-11-25', '012345678911', N'Nữ', N'Cử nhân Giáo dục'),
('NV00012', N'Tây Ninh', '1988-12-30', '012345678912', N'Nam', N'Cử nhân Quản trị Du lịch'),
('NV00013', N'Vũng Tàu', '1987-01-10', '012345678913', N'Nam', N'Cử nhân Ngoại thương'),
('NV00014', N'Bến Tre', '1992-02-18', '012345678914', N'Nam', N'Cử nhân Xây dựng'),
('NV00015', N'Hậu Giang', '1993-03-22', '012345678915', N'Nữ', N'Cử nhân Quản lý Công nghiệp'),
('NV00016', N'Đồng Nai', '1989-04-28', '012345678916', N'Nam', N'Cử nhân Sinh học'),
('NV00017', N'Hà Giang', '1994-05-05', '012345678917', N'Nam', N'Cử nhân Vật lý'),
('NV00018', N'Kiên Giang', '1988-06-10', '012345678918', N'Nam', N'Cử nhân Hóa học'),
('NV00019', N'Lâm Đồng', '1990-07-15', '012345678919', N'Nữ', N'Cử nhân Nông nghiệp');


----------------Thêm dữ liệu nhóm Khách hàng----------------
INSERT INTO LOAIKH 
values
(N'VIP'),
( N'Thân thiết'),
( N'Thành viên')

INSERT INTO KHACHHANG (MaKH, TenKH, MALOAI, SDT, SODIEMTHUONG)
VALUES
('KH00001', N'Nguyễn Văn An', 1, '0901234567', 15),  -- VIP
('KH00002', N'Trần Thị Bích', 2, '0902345678', 10),   -- Thân thiết
('KH00003', N'Lê Minh Cường', 3, '0903456789', 5),       -- Thành viên
('KH00004', N'Nguyễn Thị Hương', 1, '0904567890', 20),  -- VIP
('KH00005', N'Trần Văn Bình', 2, '0905678901', 8),     -- Thân thiết
('KH00006', N'Lê Thị Thanh', 3, '0906789012', 12),      -- Thành viên
('KH00007', N'Nguyễn Văn Phú', 1, '0907890123', 18),  -- VIP
('KH00008', N'Trần Thị Ngọc', 2, '0908901234', 9),     -- Thân thiết
('KH00009', N'Lê Văn Minh', 3, '0909012345', 7),        -- Thành viên
('KH00010', N'Nguyễn Thị Lan', 1, '0910123456', 25),  -- VIP
('KH00011', N'Trần Văn Hoàng', 2, '0911234567', 11),     -- Thân thiết
('KH00012', N'Lê Thị Yến', 3, '0912345678', 6),        -- Thành viên
('KH00013', N'Nguyễn Văn Tuấn', 1, '0913456789', 30),  -- VIP
('KH00014', N'Trần Thị Duyên', 2, '0914567890', 14),     -- Thân thiết
('KH00015', N'Lê Văn Khải', 3, '0915678901', 2),        -- Thành viên
('KH00016', N'Nguyễn Văn Hùng', 1, '0916789012', 22),  -- VIP
('KH00017', N'Trần Thị Kim', 2, '0917890123', 4),     -- Thân thiết
('KH00018', N'Lê Văn Phúc', 3, '0918901234', 16),       -- Thành viên
('KH00019', N'Nguyễn Văn Đạt', 1, '0919012345', 21),  -- VIP
('KH00020', N'Trần Thị Mai', 2, '0920123456', 3);      -- Thân thiết

----------------Thêm dữ liệu cho nhóm sản phẩm----------------
INSERT INTO LOAISP 
values
(N'Cà phê'),
(N'Trà'),
( N'Đá xay'),
(N'Bánh ngọt')
-- Thêm sản phẩm vào bảng SanPham cho loại Cà phê
INSERT INTO SanPham (MaSanPham, MALOAI, TenSanPham, DonGia, MoTa)
VALUES
('SP00001', 1, N'Cà phê đen đá', 25000.00, N'Cà phê pha phin truyền thống'),
('SP00002', 1, N'Cà phê sữa đá', 30000.00, N'Cà phê pha phin kết hợp với sữa đặc'),
('SP00003', 1, N'Espresso', 40000.00, N'Cà phê Ý đậm đà'),
('SP00004', 1, N'Americano', 35000.00, N'Cà phê pha loãng kiểu Mỹ'),
('SP00005', 1, N'Cappuccino', 45000.00, N'Cà phê Ý với sữa và bọt sữa'),
('SP00021', 1, N'Mocha', 48000.00, N'Cà phê kết hợp socola thơm ngon'),
('SP00022', 1, N'Latte', 45000.00, N'Cà phê sữa với lớp bọt sữa mịn màng'),
('SP00023', 1, N'Macchiato', 50000.00, N'Cà phê espresso với lớp bọt sữa trên mặt');

-- Thêm sản phẩm vào bảng SanPham cho loại Trà
INSERT INTO SanPham (MaSanPham, MALOAI, TenSanPham, DonGia, MoTa)
VALUES
('SP00006', 2, N'Trà đào cam sả', 35000.00, N'Trá đào kết hợp cam sả thơm mát'),
('SP00007', 2, N'Trà xanh matcha', 40000.00, N'Trá xanh Nhật Bản hòa quyện matcha'),
('SP00008', 2, N'Trà chanh mật ong', 30000.00, N'Trá thanh mát kết hợp mật ong ngọt dịu'),
('SP00009', 2, N'Trà hoa hồng', 35000.00, N'Trá thảo mộc hương hoa hồng tinh tế'),
('SP00010', 2, N'Trà oolong', 45000.00, N'Trá oolong cao cấp với hương vị đậm đà');

-- Thêm sản phẩm vào bảng SanPham cho loại Đá xay
INSERT INTO SanPham (MaSanPham, MALOAI, TenSanPham, DonGia, MoTa)
VALUES
('SP00011', 3, N'Caramel đá xay', 50000.00, N'Thức uống đá xay hương caramel thơm ngon'),
('SP00012', 3, N'Socola đá xay', 50000.00, N'Socola đậm đà hòa quyện đá xay mát lạnh'),
('SP00013', 3, N'Bạc hà đá xay', 45000.00, N'Đá xay mát lạnh hương bạc hà tươi mới'),
('SP00014', 3, N'Dâu tây đá xay', 48000.00, N'Hương dâu tây tươi ngon kết hợp đá xay'),
('SP00015', 3, N'Trá xanh đá xay', 50000.00, N'Trá xanh matcha với đá xay mát lạnh');

-- Thêm sản phẩm vào bảng SanPham cho loại Bánh ngọt
INSERT INTO SanPham (MaSanPham, MALOAI, TenSanPham, DonGia, MoTa)
VALUES
('SP00016', 4, N'Bánh tiramisu', 60000.00, N'Bánh ngọt Ý hương vị cà phê và rượu rum'),
('SP00017', 4, N'Bánh phô mai chanh dây', 55000.00, N'Bánh phô mai ngọt ngào kết hợp chanh dây'),
('SP00018', 4, N'Bánh sừng bò', 40000.00, N'Bánh sừng bò thơm ngon, mềm mịn'),
('SP00019', 4, N'Bánh brownie', 50000.00, N'Bánh socola đậm vị, mềm mịn'),
('SP00020', 4, N'Bánh muffin việt quất', 45000.00, N'Bánh muffin xốp nhẹ kết hợp việt quất tươi');


INSERT INTO HoaDon (MaHoaDon, NgayTao, GIAMGIA, TongTien, THANHTIEN, MaChiNhanh, MAKH)
VALUES
('HD00001', '2024-10-01', 0, 200000, 200000, 1, 'KH00001'),
('HD00002', '2024-09-02', 5000, 150000, 145000, 1, 'KH00002'),
('HD00003', '2024-01-03', 0, 300000, 300000, 2, 'KH00003'),
('HD00004', '2024-05-04', 10000, 400000, 390000, 3, 'KH00004'),
('HD00005', '2024-10-05', 0, 250000, 250000, 2, 'KH00005');

INSERT INTO ChiTietHoaDon (MaHoaDon, MaSanPham, SoLuong, DonGia)
VALUES
('HD00001', 'SP00001', 2, 50000),  -- 2 sản phẩm loại Cà phê
('HD00001', 'SP00002', 1, 45000),  -- 1 sản phẩm loại Cà phê
('HD00002', 'SP00003', 3, 30000),  -- 3 sản phẩm loại Trà
('HD00003', 'SP00005', 1, 48000),  -- 1 sản phẩm loại Cà phê
('HD00004', 'SP00004', 4, 25000);  -- 4 sản phẩm loại Bánh ngọt


---------------Thêm dữ liệu cho quản lý kho--------------
INSERT INTO DONVITINH 
values
(N'Kg'),
(N'Túi'),
( N'Bao'),
(N'Chai'),
(N'Thùng'),
(N'Hộp')

INSERT INTO LOAINL
VALUES
(N'Hạt cafe'),
(N'Trà'),
(N'Siro'),
(N'Topping'),
(N'Bột')

INSERT INTO NguyenLieu (MaNguyenLieu, MALOAI, TenNguyenLieu, MADVT, SOLUONGTON) VALUES
-- Hạt cà phê
('NL00001', 1, N'Hạt cà phê Arabica', 1, 100),  -- Kg
('NL00002', 1, N'Hạt cà phê Robusta', 1, 60),  -- Kg

-- Trà
('NL00007', 2, N'Trà xanh', 1, 30),              -- Kg
('NL00008', 2, N'Trà đen', 1, 40),               -- Kg
('NL00009', 2, N'Trà oolong', 2, 35),            -- Túi
('NL00010', 2, N'Trà hoa nhài', 2, 36),          -- Túi
('NL00011', 2, N'Trà gừng', 3, 10),              -- Bao
('NL00012', 2, N'Trà bạc hà', 3, 7),            -- Bao

-- Siro
('NL00013', 3, N'Siro dâu', 4, 300),               -- Chai
('NL00014', 3, N'Siro chanh', 4, 450),             -- Chai
('NL00015', 3, N'Siro mâm xôi', 5, 10),           -- Thùng
('NL00016', 3, N'Siro táo', 5, 7),                -- Thùng
('NL00017', 3, N'Siro gừng', 6, 130),              -- Hộp
('NL00018', 3, N'Siro bạc hà', 6, 600),            -- Hộp

-- Topping
('NL00019', 4, N'Topping kem', 1, 10),            -- Kg
('NL00020', 4, N'Topping trân châu', 1, 9),      -- Kg
('NL00021', 4, N'Topping bột cacao', 2, 8),      -- Túi
('NL00022', 4, N'Topping bột trà xanh', 2, 80),   -- Túi
('NL00023', 4, N'Topping thạch', 2, 90),          -- túi
('NL00024', 4, N'Topping sữa đặc', 6, 150),        -- hộp

-- Bột
('NL00025', 5, N'Bột cà phê', 2, 30),             -- túi
('NL00026', 5, N'Bột trà xanh', 2, 80),           -- túi
('NL00027', 5, N'Bột cacao', 5, 6),               -- Thùng
('NL00028', 5, N'Bột ngũ cốc', 5, 9),             -- Thùng
('NL00029', 5, N'Bột bắp', 6, 100),              -- Hộp
('NL00030', 5, N'Bột năng', 6, 200);                -- Hộp

-- Thêm dữ liệu cho bảng NhaCungCap
INSERT INTO NhaCungCap (MaNhaCungCap, TenNhaCungCap, DiaChi, SoDienThoai, Email) VALUES
('NCC0001', N'Công ty cà phê Việt Nam', N'123 Đường Nguyễn Trãi, Quận 1, TP.HCM', '0901123456', 'contact@coffeevietnam.vn'),
('NCC0002', N'Trá Việt', N'456 Đường Lê Lợi, Quận 3, TP.HCM', '0902234567', 'sales@traviet.vn'),
('NCC0003', N'Siro Hưng Thịnh', N'789 Đường Trần Hưng Đạo, Quận 5, TP.HCM', '0903345678', 'info@sirohungthinh.vn'),
('NCC0004', N'Topping Gia Phát', N'135 Đường Nguyễn Huệ, Quận 1, TP.HCM', '0904456789', 'order@toppinggiaphat.vn'),
('NCC0005', N'Bột Thực Phẩm An Bình', N'246 Đường Điện Biên Phủ, Quận Bình Thạnh, TP.HCM', '0905567890', 'info@botanbinh.vn');


-- Thêm dữ liệu cho bảng CUNGUNG
INSERT INTO CUNGUNG (MaNhaCungCap, MaNguyenLieu) VALUES
-- Các nhà cung cấp cung cấp các loại nguyên liệu tương ứng
('NCC0001', 'NL00001'), -- Công ty cà phê Việt Nam cung cấp Hạt cà phê Arabica
('NCC0001', 'NL00002'), -- Công ty cà phê Việt Nam cung cấp Hạt cà phê Robusta

('NCC0002', 'NL00007'), -- Trà Việt cung cấp Trà xanh
('NCC0002', 'NL00008'), -- Trà Việt cung cấp Trà đen
('NCC0002', 'NL00009'), -- Trà Việt cung cấp Trà oolong
('NCC0002', 'NL00010'), -- Trà Việt cung cấp Trà hoa nhài
('NCC0002', 'NL00011'), -- Trà Việt cung cấp Trà gừng
('NCC0002', 'NL00012'), -- Trà Việt cung cấp Trà bạc hà

('NCC0003', 'NL00013'), -- Siro Hưng Thịnh cung cấp Siro dâu
('NCC0003', 'NL00014'), -- Siro Hưng Thịnh cung cấp Siro chanh
('NCC0003', 'NL00015'), -- Siro Hưng Thịnh cung cấp Siro mâm xôi
('NCC0003', 'NL00016'), -- Siro Hưng Thịnh cung cấp Siro táo
('NCC0003', 'NL00017'), -- Siro Hưng Thịnh cung cấp Siro gừng
('NCC0003', 'NL00018'), -- Siro Hưng Thịnh cung cấp Siro bạc hà

('NCC0004', 'NL00019'), -- Topping Gia Phát cung cấp Topping kem
('NCC0004', 'NL00020'), -- Topping Gia Phát cung cấp Topping trân châu
('NCC0004', 'NL00021'), -- Topping Gia Phát cung cấp Topping bột cacao
('NCC0004', 'NL00022'), -- Topping Gia Phát cung cấp Topping bột trà xanh
('NCC0004', 'NL00023'), -- Topping Gia Phát cung cấp Topping thạch
('NCC0004', 'NL00024'), -- Topping Gia Phát cung cấp Topping sữa đặc

('NCC0005', 'NL00025'), -- Bột Thực Phẩm An Bình cung cấp Bột cà phê
('NCC0005', 'NL00026'), -- Bột Thực Phẩm An Bình cung cấp Bột trà xanh
('NCC0005', 'NL00027'), -- Bột Thực Phẩm An Bình cung cấp Bột cacao
('NCC0005', 'NL00028'), -- Bột Thực Phẩm An Bình cung cấp Bột ngũ cốc
('NCC0005', 'NL00029'), -- Bột Thực Phẩm An Bình cung cấp Bột gia vị
('NCC0005', 'NL00030'); -- Bột Thực Phẩm An Bình cung cấp Bột năng


-- Thêm dữ liệu cho bảng PhieuNhap
INSERT INTO PhieuNhap (MaPhieuNhap, MaNhaCungCap, NgayNhap, TongTien, MaChiNhanh) VALUES
('PN00001', 'NCC0001', '2024-01-10', 1500000, 1), -- Nhập hàng từ nhà cung cấp NCC0001 vào ngày 10/01/2024
('PN00002', 'NCC0002', '2024-01-15', 2000000, 2), -- Nhập hàng từ nhà cung cấp NCC0002 vào ngày 15/01/2024
('PN00003', 'NCC0003', '2024-02-05', 2500000, 3), -- Nhập hàng từ nhà cung cấp NCC0003 vào ngày 05/02/2024
('PN00004', 'NCC0004', '2024-03-12', 1750000, 4), -- Nhập hàng từ nhà cung cấp NCC0004 vào ngày 12/03/2024
('PN00005', 'NCC0005', '2024-03-20', 2250000, 5), -- Nhập hàng từ nhà cung cấp NCC0005 vào ngày 20/03/2024
('PN00006', 'NCC0001', '2024-04-08', 1800000, 2), -- Nhập hàng từ nhà cung cấp NCC0001 vào ngày 08/04/2024
('PN00007', 'NCC0002', '2024-04-15', 2400000, 3), -- Nhập hàng từ nhà cung cấp NCC0002 vào ngày 15/04/2024
('PN00008', 'NCC0003', '2024-05-01', 3000000, 4), -- Nhập hàng từ nhà cung cấp NCC0003 vào ngày 01/05/2024
('PN00009', 'NCC0004', '2024-06-18', 2600000, 5), -- Nhập hàng từ nhà cung cấp NCC0004 vào ngày 18/06/2024
('PN00010', 'NCC0005', '2024-07-10', 3200000, 4); -- Nhập hàng từ nhà cung cấp NCC0005 vào ngày 10/07/2024

-- Thêm dữ liệu cho bảng ChiTietPhieuNhap
INSERT INTO ChiTietPhieuNhap (MaPhieuNhap, MaNguyenLieu, SoLuong, DonGia) VALUES
-- Chi tiết phiếu nhập PN00001
('PN00001', 'NL00001', 100, 15000)
INSERT INTO ChiTietPhieuNhap (MaPhieuNhap, MaNguyenLieu, SoLuong, DonGia) VALUES-- 100 kg hạt cà phê Arabica với đơn giá 15,000 VND/kg
('PN00001', 'NL00007', 50, 20000) -- 50 kg trà xanh với đơn giá 20,000 VND/kg

-- Chi tiết phiếu nhập PN00002
INSERT INTO ChiTietPhieuNhap (MaPhieuNhap, MaNguyenLieu, SoLuong, DonGia) VALUES
('PN00002', 'NL00002', 80, 14000)
INSERT INTO ChiTietPhieuNhap (MaPhieuNhap, MaNguyenLieu, SoLuong, DonGia) VALUES-- 80 kg hạt cà phê Robusta với đơn giá 14,000 VND/kg
('PN00002', 'NL00008', 40, 22000)   -- 40 kg trà đen với đơn giá 22,000 VND/kg

-- Chi tiết phiếu nhập PN00003
INSERT INTO ChiTietPhieuNhap (MaPhieuNhap, MaNguyenLieu, SoLuong, DonGia) VALUES
('PN00003', 'NL00013', 60, 30000)
INSERT INTO ChiTietPhieuNhap (MaPhieuNhap, MaNguyenLieu, SoLuong, DonGia) VALUES-- 60 chai siro dâu với đơn giá 30,000 VND/chai
('PN00003', 'NL00019', 70, 25000)   -- 70 kg topping kem với đơn giá 25,000 VND/kg

-- Chi tiết phiếu nhập PN00004
INSERT INTO ChiTietPhieuNhap (MaPhieuNhap, MaNguyenLieu, SoLuong, DonGia) VALUES
('PN00004', 'NL00020', 90, 18000)
INSERT INTO ChiTietPhieuNhap (MaPhieuNhap, MaNguyenLieu, SoLuong, DonGia) VALUES-- 90 kg topping trân châu với đơn giá 18,000 VND/kg
('PN00004', 'NL00026', 30, 35000)  -- 30 chai bột trà xanh với đơn giá 35,000 VND/chai

-- Chi tiết phiếu nhập PN00005
INSERT INTO ChiTietPhieuNhap (MaPhieuNhap, MaNguyenLieu, SoLuong, DonGia) VALUES
('PN00005', 'NL00027', 50, 40000)
INSERT INTO ChiTietPhieuNhap (MaPhieuNhap, MaNguyenLieu, SoLuong, DonGia) VALUES-- 50 thùng bột cacao với đơn giá 40,000 VND/thùng
('PN00005', 'NL00011', 100, 15000) -- 100 bao trà gừng với đơn giá 15,000 VND/bao

-- Chi tiết phiếu nhập PN00006
INSERT INTO ChiTietPhieuNhap (MaPhieuNhap, MaNguyenLieu, SoLuong, DonGia) VALUES
('PN00006', 'NL00012', 120, 16000)
INSERT INTO ChiTietPhieuNhap (MaPhieuNhap, MaNguyenLieu, SoLuong, DonGia) VALUES-- 120 bao trà bạc hà với đơn giá 16,000 VND/bao
('PN00006', 'NL00014', 80, 27000)-- 80 chai siro chanh với đơn giá 27,000 VND/chai

-- Chi tiết phiếu nhập PN00007
INSERT INTO ChiTietPhieuNhap (MaPhieuNhap, MaNguyenLieu, SoLuong, DonGia) VALUES
('PN00007', 'NL00017', 100, 30000)
INSERT INTO ChiTietPhieuNhap (MaPhieuNhap, MaNguyenLieu, SoLuong, DonGia) VALUES-- 100 hộp siro gừng với đơn giá 30,000 VND/hộp
('PN00007', 'NL00028', 60, 42000)  -- 60 thùng bột ngũ cốc với đơn giá 42,000 VND/thùng

-- Chi tiết phiếu nhập PN00008
INSERT INTO ChiTietPhieuNhap (MaPhieuNhap, MaNguyenLieu, SoLuong, DonGia) VALUES
('PN00008', 'NL00010', 90, 25000)
INSERT INTO ChiTietPhieuNhap (MaPhieuNhap, MaNguyenLieu, SoLuong, DonGia) VALUES-- 90 túi trà hoa nhài với đơn giá 25,000 VND/túi
('PN00008', 'NL00021', 110, 20000)  -- 110 túi topping bột cacao với đơn giá 20,000 VND/túi

-- Chi tiết phiếu nhập PN00009
INSERT INTO ChiTietPhieuNhap (MaPhieuNhap, MaNguyenLieu, SoLuong, DonGia) VALUES
('PN00009', 'NL00015', 70, 32000)-- 70 thùng siro mâm xôi với đơn giá 32,000 VND/thùng
INSERT INTO ChiTietPhieuNhap (MaPhieuNhap, MaNguyenLieu, SoLuong, DonGia) VALUES
('PN00009', 'NL00024', 130, 17000)  -- 130 bao topping sữa đặc với đơn giá 17,000 VND/bao

-- Chi tiết phiếu nhập PN00010
INSERT INTO ChiTietPhieuNhap (MaPhieuNhap, MaNguyenLieu, SoLuong, DonGia) VALUES
('PN00010', 'NL00030', 100, 21000)
INSERT INTO ChiTietPhieuNhap (MaPhieuNhap, MaNguyenLieu, SoLuong, DonGia) VALUES-- 100 hộp bột năng với đơn giá 21,000 VND/hộp
('PN00010', 'NL00009', 50, 26000);   -- 50 túi trà oolong với đơn giá 26,000 VND/túi


-- Thêm dữ liệu cho bảng PhieuXuat
INSERT INTO PhieuXuat (MaPX, MaNhanVien, MaChiNhanh, NgayTao, GhiChu) VALUES
('PX00001', 'NV00001', 1, '2024-10-01 09:00:00', N'Xuất nguyên liệu cho chi nhánh 1'),
('PX00002', 'NV00002', 1, '2024-10-02 14:30:00', N'Xuất nguyên liệu cho chi nhánh 1'),
('PX00003', 'NV00003', 2, '2024-10-03 11:00:00', N'Xuất nguyên liệu cho chi nhánh 2'),
('PX00004', 'NV00005', 3, '2024-10-04 16:00:00', N'Xuất nguyên liệu cho chi nhánh 3'),
('PX00005', 'NV00004', 2, '2024-10-05 13:00:00', N'Xuất nguyên liệu cho chi nhánh 2');

-- Thêm dữ liệu cho bảng ChiTietPX
INSERT INTO ChiTietPX (MAPX, MaNguyenLieu, SOLUONGXUAT) VALUES
-- Chi tiết phiếu xuất PX00001
('PX00001', 'NL00001', 20)-- 20 kg hạt cà phê Arabica
INSERT INTO ChiTietPX (MAPX, MaNguyenLieu, SOLUONGXUAT) VALUES
('PX00001', 'NL00007', 10)  -- 10 kg trà xanh

-- Chi tiết phiếu xuất PX00002
INSERT INTO ChiTietPX (MAPX, MaNguyenLieu, SOLUONGXUAT) VALUES
('PX00002', 'NL00002', 15)  -- 15 kg hạt cà phê Robusta
INSERT INTO ChiTietPX (MAPX, MaNguyenLieu, SOLUONGXUAT) VALUES
('PX00002', 'NL00008', 5)   -- 5 kg trà đen

-- Chi tiết phiếu xuất PX00003
INSERT INTO ChiTietPX (MAPX, MaNguyenLieu, SOLUONGXUAT) VALUES
('PX00003', 'NL00013', 30)  -- 30 chai siro dâu
INSERT INTO ChiTietPX (MAPX, MaNguyenLieu, SOLUONGXUAT) VALUES
('PX00003', 'NL00019', 25)  -- 25 kg topping kem

-- Chi tiết phiếu xuất PX00004
INSERT INTO ChiTietPX (MAPX, MaNguyenLieu, SOLUONGXUAT) VALUES
('PX00004', 'NL00020', 40)  -- 40 kg topping trân châu
INSERT INTO ChiTietPX (MAPX, MaNguyenLieu, SOLUONGXUAT) VALUES
('PX00004', 'NL00026', 20)  -- 20 chai bột trà xanh

-- Chi tiết phiếu xuất PX00005
INSERT INTO ChiTietPX (MAPX, MaNguyenLieu, SOLUONGXUAT) VALUES
('PX00005', 'NL00027', 50)  -- 50 thùng bột cacao
INSERT INTO ChiTietPX (MAPX, MaNguyenLieu, SOLUONGXUAT) VALUES
('PX00005', 'NL00011', 30);  -- 30 bao trà gừng

