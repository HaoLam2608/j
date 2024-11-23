USE QLCF
GO

---------------BACKUP DATABASE----------------
Alter Database QLCF
Set Recovery full



---------------PROCEDURE----------------------
--1/ Thêm khách hàng
CREATE PROCEDURE ThemKhachHang
    @MaKH NCHAR(20),
    @TenKH NVARCHAR(50),
    @MALOAI INT,
    @SDT NCHAR(10),
    @SoDiemThuong INT
AS
BEGIN
    -- Kiểm tra nếu khách hàng đã tồn tại
    IF EXISTS (SELECT 1 FROM KHACHHANG WHERE MaKH = @MaKH)
    BEGIN
        PRINT N'Khách hàng đã tồn tại.'
        RETURN
    END

    -- Kiểm tra nếu loại khách hàng không tồn tại
    IF NOT EXISTS (SELECT 1 FROM LOAIKH WHERE MALOAI = @MALOAI)
    BEGIN
        PRINT N'Loại khách hàng không hợp lệ.'
        RETURN
    END

    -- Thêm khách hàng mới vào bảng KHACHHANG
    INSERT INTO KHACHHANG (MaKH, TenKH, MALOAI, SDT, SoDiemThuong)
    VALUES (@MaKH, @TenKH, @MALOAI, @SDT, @SoDiemThuong)

    PRINT N'Thêm khách hàng thành công.'
END
GO
---Test procedure
EXEC ThemKhachHang @MaKH = 'KH001', @TenKH = N'Nguyễn Văn A', @MALOAI = 1, @SDT = '0901234567', @SoDiemThuong = 10

go

--2/ Update thông tin khách hàng
CREATE PROCEDURE SuaKhachHang
    @MaKH NCHAR(20),
    @TenKH NVARCHAR(50),
    @MALOAI INT,
    @SDT NCHAR(10),
    @SoDiemThuong INT
AS
BEGIN
    -- Kiểm tra xem mã khách hàng có tồn tại không
    IF EXISTS (SELECT 1 FROM KHACHHANG WHERE MaKH = @MaKH)
    BEGIN
        -- Cập nhật thông tin khách hàng
        UPDATE KHACHHANG
        SET TenKH = @TenKH,
            MALOAI = @MALOAI,
            SDT = @SDT,
            SODIEMTHUONG = @SoDiemThuong
        WHERE MaKH = @MaKH;

        -- Trả về thông báo thành công
        PRINT N'Cập nhật khách hàng thành công.';
    END
    ELSE
    BEGIN
        -- Nếu không tìm thấy mã khách hàng, thông báo lỗi
        PRINT N'Khách hàng không tồn tại.';
    END
END
GO

--3/ Xóa 1 khách hàng
CREATE PROCEDURE XoaKhachHang
    @MaKH NCHAR(20)
AS
BEGIN
    -- Xóa tất cả các hóa đơn của khách hàng trước
    DELETE FROM HoaDon WHERE MaKH = @MaKH;

    -- Sau đó xóa khách hàng
    DELETE FROM KHACHHANG WHERE MaKH = @MaKH;
END

GO

--4/ Lấy số điện thoại của khách hàng
CREATE PROCEDURE sp_GetCustomerInfoByPhone
    @SDT NVARCHAR(15) -- Tham số đầu vào là số điện thoại
AS
BEGIN
    -- Truy vấn lấy TenKH và TenLoaiKH từ bảng KhachHang và LOAIKH dựa trên SDT
    SELECT KH.TenKH, L.TenLoai, KH.MaKH 
    FROM KhachHang KH
    JOIN LOAIKH L ON KH.MaLoai = L.MaLoai
    WHERE KH.SDT = @SDT;
END

---5/ Thêm phiếu xuất 
CREATE PROC INSERTPX @maPX NCHAR(20), @maNV NCHAR(20), @maCN NCHAR(20), @ngayTaoPX DATETIME, @moTa NVARCHAR(500)
AS
BEGIN
	INSERT INTO PHIEUXUAT VALUES
	(@maPX, @maNV, @maCN, @ngayTaoPX, @moTa)
END

--6/ Thêm chi tiết phiếu xuất
CREATE PROC INSERTCTPX @maPX NCHAR(20), @maNL NCHAR(20), @soLuongXuat INT
AS
BEGIN
	INSERT INTO CHITIETPX VALUES
	(@maPX, @maNL, @soLuongXuat)
END

---7/ Hiện số điểm thưởng của khách hàng
CREATE PROCEDURE sp_DisplayCustomerPoints
AS
BEGIN
    DECLARE 
        @MaKH NCHAR(20),
        @TenKH NVARCHAR(50),
        @SoDiemThuong INT;

    -- Khai báo con trỏ CURSOR để duyệt qua các khách hàng
    DECLARE CustomerCursor CURSOR FOR
    SELECT MaKH, TenKH, SoDiemThuong
    FROM KHACHHANG;

    -- Mở con trỏ
    OPEN CustomerCursor;

    -- Đọc từng dòng dữ liệu từ con trỏ và hiển thị
    FETCH NEXT FROM CustomerCursor INTO @MaKH, @TenKH, @SoDiemThuong;
    WHILE @@FETCH_STATUS = 0
    BEGIN
        PRINT N'Mã Khách Hàng: ' + @MaKH + N', Tên Khách Hàng: ' + @TenKH + N', Điểm Thưởng: ' + CAST(@SoDiemThuong AS NVARCHAR(10));

        -- Đọc dòng tiếp theo
        FETCH NEXT FROM CustomerCursor INTO @MaKH, @TenKH, @SoDiemThuong;
    END;

    -- Đóng và giải phóng con trỏ
    CLOSE CustomerCursor;
    DEALLOCATE CustomerCursor;
END;

--Test Procedure
EXEC sp_DisplayCustomerPoints;

---8/thủ tục kết hợp cursor hiển thị mã khách hàng, tên khách hàng và doanh số của khách hàng.
CREATE PROCEDURE sp_DoanhSoKhachHang
AS
BEGIN
    DECLARE @MaKH NCHAR(20),
            @TenKH NVARCHAR(50),
            @DoanhSo DECIMAL(10,2)
    DECLARE khachHang_cursor CURSOR FOR
    SELECT MaKH, TenKH
    FROM KHACHHANG
    OPEN khachHang_cursor
    FETCH NEXT FROM khachHang_cursor INTO @MaKH, @TenKH
    WHILE @@FETCH_STATUS = 0
    BEGIN
        SELECT @DoanhSo = SUM(THANHTIEN)
        FROM HoaDon hd
        JOIN ChiTietHoaDon cthd ON hd.MaHoaDon = cthd.MaHoaDon
        WHERE hd.MAKH = @MaKH
       
        PRINT N'Mã khách hàng: ' + @MaKH + N', Tên khách hàng: ' + @TenKH + N', Doanh số: ' + CAST(ISNULL(@DoanhSo, 0) AS NVARCHAR)
        FETCH NEXT FROM khachHang_cursor INTO @MaKH, @TenKH
    END
    CLOSE khachHang_cursor
    DEALLOCATE khachHang_cursor
END
GO

---Test cursor kết hợp procedure
EXEC sp_DoanhSoKhachHang;

---9/ thủ tục kết hợp cursor hiển thị mã hàng, tên hàng, tổng số lượng nhập, tổng số lượng xuất các nguyên liệu trong một khoảng thời gian từ ngày – đến ngày.
CREATE PROCEDURE sp_ThongKeNguyenLieuNhapXuat
    @NgayBatDau DATETIME,
    @NgayKetThuc DATETIME
AS
BEGIN
    DECLARE @MaNguyenLieu NCHAR(20),
            @TenNguyenLieu NVARCHAR(100),
            @TongSoLuongNhap INT,
            @TongSoLuongXuat INT

    DECLARE nguyenLieu_cursor CURSOR FOR
    SELECT MaNguyenLieu, TenNguyenLieu
    FROM NguyenLieu

    OPEN nguyenLieu_cursor

    FETCH NEXT FROM nguyenLieu_cursor INTO @MaNguyenLieu, @TenNguyenLieu

    WHILE @@FETCH_STATUS = 0
    BEGIN
        SELECT @TongSoLuongNhap = SUM(ctpn.SoLuong)
        FROM ChiTietPhieuNhap ctpn
        JOIN PhieuNhap pn ON ctpn.MaPhieuNhap = pn.MaPhieuNhap
        WHERE ctpn.MaNguyenLieu = @MaNguyenLieu 
          AND pn.NgayNhap BETWEEN @NgayBatDau AND @NgayKetThuc

        SELECT @TongSoLuongXuat = SUM(ctpx.SOLUONGXUAT)
        FROM CHITIETPX ctpx
        JOIN PHIEUXUAT px ON ctpx.MAPX = px.MAPX
        WHERE ctpx.MaNguyenLieu = @MaNguyenLieu 
          AND px.NGAYTAO BETWEEN @NgayBatDau AND @NgayKetThuc

        PRINT N'Mã nguyên liệu: ' + @MaNguyenLieu + 
              N', Tên nguyên liệu: ' + @TenNguyenLieu + 
              N', Tổng số lượng nhập: ' + CAST(ISNULL(@TongSoLuongNhap, 0) AS NVARCHAR) + 
              N', Tổng số lượng xuất: ' + CAST(ISNULL(@TongSoLuongXuat, 0) AS NVARCHAR)

        FETCH NEXT FROM nguyenLieu_cursor INTO @MaNguyenLieu, @TenNguyenLieu
    END

    CLOSE nguyenLieu_cursor
    DEALLOCATE nguyenLieu_cursor
END
GO

---Test cursor
EXEC sp_ThongKeNguyenLieuNhapXuat 
    @NgayBatDau = '2024-01-01',
    @NgayKetThuc = '2024-12-31';


-------------------------------------FUNCTION-----------------------------------------
---5. Xem danh sách hóa đơn
CREATE FUNCTION dbo.fn_ViewAllInvoices()
RETURNS TABLE
AS
RETURN
(
    SELECT 
        HD.MaHoaDon,
        HD.NgayTao,
        HD.GIAMGIA,
        HD.TongTien,
        HD.THANHTIEN,
        TenChiNhanh,
        HD.MaKH
    FROM 
        HoaDon AS HD
	JOIN ChiNhanh c ON C.MaChiNhanh = HD.MaChiNhanh
);

---1. Lấy ra các mã loại mà nhà cung cấp đó cung ứng
CREATE FUNCTION LAYLOAITHEONHACC (@maNhaCC NCHAR(20))
RETURNS @tbl_LoaiTheoNhaCC TABLE (MALOAI NCHAR(20), TENLOAI NVARCHAR(100))
AS
	BEGIN
		INSERT INTO @tbl_LoaiTheoNhaCC
			SELECT l.MALOAI, TENLOAI 
			from cungung c
			join nguyenlieu nl on nl.MaNguyenLieu = c.MaNguyenLieu
			join NhaCungCap cc on cc.MaNhaCungCap = c.MaNhaCungCap
			join LOAINL l on l.MALOAI = nl.MALOAI
			where cc.MaNhaCungCap = @maNhaCC
			GROUP BY l.MALOAI, TENLOAI

			RETURN
	END

---2. Tìm nguyên liệu theo một kí tự bất kì
CREATE FUNCTION TIMKIEMNL (@KiTu Nvarchar(100))
RETURNS @TABLE TABLE (MaNguyenLieu NCHAR(20), TenNguyenLieu NVARCHAR(100)) 
AS
BEGIN
	INSERT INTO @TABLE
		select MaNguyenLieu, TenNguyenLieu 
		from nguyenlieu
		where tennguyenlieu COLLATE SQL_Latin1_General_Cp1253_CI_AI LIKE N'%'+ @KiTu +'%'
	return
END

---3. Thống kê doanh thu của quán 
CREATE FUNCTION TINHTONGDOANHTHU(@Thang int , @Nam int)
RETURNS table
AS
	RETURN SELECT month(HoaDon.NgayTao) as 'Tháng', year(HoaDon.NgayTao) as 'Năm', SUM(HoaDon.THANHTIEN) as 'Tổng doanh thu'
	FROM HoaDon
	WHERE (@Thang IS NULL OR MONTH(HoaDon.NgayTao) = @thang) and (@Nam IS NULL OR YEAR(HoaDon.NgayTao) = @Nam) 
	group by month(HoaDon.NgayTao),year(HoaDon.NgayTao)
	
select * from dbo.TINHTONGDOANHTHU(null , null)

---4. Tạo mã nhân viên
CREATE FUNCTION dbo.fn_CreateMaNhanVien()
RETURNS NCHAR(12)
AS
BEGIN
    DECLARE @NewMa NVARCHAR(12)
    DECLARE @MaxMa NVARCHAR(12)
    SELECT @MaxMa = MAX(MaNhanVien) FROM NhanVien
    IF @MaxMa IS NULL
    BEGIN
        SET @NewMa = 'NV00001'
    END
    ELSE
    BEGIN
        SET @NewMa = 'NV' + RIGHT('00000' + CAST(CAST(SUBSTRING(@MaxMa, 3, 5) AS INT) + 1 AS NVARCHAR(5)), 5)
    END
    RETURN @NewMa
END

------------------------------------TRIGGER--------------------------------
---1. Cập nhật lại số điểm thưởng khi khách hàng order một hóa đơn mới 
------và loại khách hàng khi khách đó đạt đủ số điểm thưởng
CREATE TRIGGER trg_UpdateRewardPoints
ON HoaDon
AFTER INSERT
AS
BEGIN
    DECLARE @MaKH NCHAR(20), @DiemThuong INT, @TongDiem INT;

    -- Lấy thông tin MaKH và THANHTIEN từ hóa đơn vừa thêm
    SELECT @MaKH = MaKH, @DiemThuong = (THANHTIEN / 1000)
    FROM inserted;

    -- Kiểm tra nếu MaKH là "KHVL" thì không cộng điểm thưởng
    IF @MaKH = 'KHVL'
        RETURN;

    -- Cập nhật điểm thưởng cho khách hàng
    UPDATE KHACHHANG
    SET SODIEMTHUONG = SODIEMTHUONG + @DiemThuong
    WHERE MaKH = @MaKH;

    -- Lấy tổng điểm thưởng sau khi cập nhật
    SELECT @TongDiem = SODIEMTHUONG
    FROM KHACHHANG
    WHERE MaKH = @MaKH;

    -- Cập nhật MALOAI dựa trên điểm thưởng
    UPDATE KHACHHANG
    SET MALOAI = CASE 
                    WHEN @TongDiem >= 1000 THEN 1 -- VIP
                    WHEN @TongDiem >= 500 THEN 2  -- Thân Thiết
                    WHEN @TongDiem >=1 THEN 3	  -- Thành Viên
					ELSE 4                        -- Vãng lai
                 END
    WHERE MaKH = @MaKH;
END;

---2. Cập nhật lại số lượng tồn kho của một nguyên liệu khi nhập mới
CREATE TRIGGER UPDATESOLLUONGTON ON ChiTietPhieuNhap
FOR INSERT
AS
	BEGIN
		DECLARE @soLuong INT
		SET @soLuong = (SELECT SOLUONG FROM inserted)
		UPDATE NGUYENLIEU
		SET SOLUONGTON = SOLUONGTON + @soLuong
		WHERE MaNguyenLieu = (SELECT MaNguyenLieu FROM inserted)
	END

----3. Cập nhật lại số lượng tồn kho của một nguyên liệu khi xuất kho
CREATE TRIGGER UPDATESLTONKHIXUAT ON CHITIETPX
FOR INSERT
AS
BEGIN
	DECLARE @soLuong INT
		SET @soLuong = (SELECT SOLUONGXUAT FROM inserted)

		UPDATE NGUYENLIEU
		SET SOLUONGTON = SOLUONGTON - @soLuong
		WHERE MaNguyenLieu = (SELECT MaNguyenLieu FROM inserted)
END

---4. Kiểm tra số lượng tồn của nguyên liệu không được âm
CREATE TRIGGER KTRSOLUONGTON ON NGUYENLIEU
FOR INSERT, UPDATE
AS
BEGIN
	IF EXISTS (SELECT SOLUONGTON FROM inserted WHERE SOLUONGTON < 0)
		BEGIN
			PRINT N'SỐ LƯỢNG TỒN KHÔNG ĐƯỢC ÂM'
			ROLLBACK TRAN
		END
END

---5. Kiểm tra số lượng tồn của nguyên liệu sau khi xuất nếu dưới 10 thì hiện thông báo cần nhập thêm nguyên liệu
CREATE TRIGGER KTRSLTON ON NGUYENLIEU
AFTER INSERT, UPDATE
AS
BEGIN
	IF EXISTS (SELECT SOLUONGTON FROM inserted WHERE SOLUONGTON < 10)
		BEGIN
			PRINT N'NGUYÊN LIỆU ĐÃ GẦN HẾT. HÃY NHẬP THÊM'
		END
END

---6. Kiểm tra số lượng xuất phải lớn hơn 0 và nhỏ hơn số lượng tồn
CREATE TRIGGER KTRSLXUAT ON ChiTietPX
FOR INSERT, UPDATE
AS
BEGIN
	DECLARE @SLTON INT
	SET @SLTON = (SELECT SOLUONGTON FROM NguyenLieu WHERE MaNguyenLieu = (SELECT MaNguyenLieu FROM inserted))
	IF (SELECT SOLUONGXUAT FROM inserted) < 0 OR (SELECT SOLUONGXUAT FROM inserted) >= @SLTON
		BEGIN
			PRINT N'KHÔNG ĐỦ NGUYÊN LIỆU ĐỂ XUẤT'
			ROLLBACK TRAN
		END
END

---7. Phân quyền cho 1 nhân viên khi thêm mới nhân viên đó



--------------------------------------VIEW--------------------------------------------------
---1. Tạo view xem đầy đủ thông tin nhân viên
CREATE VIEW vw_ThongTinNhanVienChiNhanh AS
SELECT NV.MaNhanVien, NV.TenNhanVien, CV.TENCHUCVU, NV.SoDienThoai, NV.DIACHI, CN.TenChiNhanh, NQ.TENNHOM
FROM NhanVien NV
JOIN CHUCVU CV ON NV.MACV = CV.MACV
JOIN ChiNhanh CN ON NV.MaChiNhanh = CN.MaChiNhanh
JOIN NHOMQUYEN NQ ON NV.MANHOM = NQ.MANHOM;

SELECT * FROM vw_ThongTinNhanVienChiNhanh

---2. Xem thông tin khách hàng, biết khách hàng đó thuộc loại nào
CREATE VIEW vw_CustomerInfo AS
SELECT 
    KH.MaKH, 
    KH.TenKH, 
    KH.SDT, 
    KH.SODIEMTHUONG, 
    LK.TENLOAI,
    LK.MALOAI
FROM 
    KHACHHANG KH
JOIN 
    LOAIKH LK ON KH.MALOAI = LK.MALOAI;


---3. Tạo view để xem danh sách nguyên liệu, cho biết nguyên liệu thuộc loại nào, ai cung cấp, đơn vị của nguyên liệu
CREATE VIEW DSNGUYENLIEU
AS
	SELECT nl.MaNguyenLieu, l.MALOAI, TENLOAI, TenNguyenLieu, SOLUONGTON, TENDVT, TenNhaCungCap, n.MaNhaCungCap 
	FROM NguyenLieu nl 
	join LOAINL l on l.MALOAI = nl.MALOAI 
	join DONVITINH d on d.MADVT = nl.MADVT 
	join CUNGUNG c on c.MaNguyenLieu = nl.MaNguyenLieu
	join NhaCungCap n on n.MaNhaCungCap = c.MaNhaCungCap


---4. Xem tổng số lượng nguyên liệu mà từng nhà cung cấp cung ứng
CREATE VIEW VIEW_4
AS
	SELECT TenNhaCungCap, COUNT(c.MaNguyenLieu) AS 'SỐ LƯỢNG NGUYÊN LIỆU'
	FROM CUNGUNG c
	JOIN NhaCungCap nc ON nc.MaNhaCungCap = c.MaNhaCungCap
	GROUP BY nc.TenNhaCungCap

---5. Xem các nguyên liệu của từng nhà cung cấp đó có cung ứng
CREATE VIEW VIEW_5
AS
	SELECT c.MaNhaCungCap, TenNhaCungCap, TenNguyenLieu
	FROM CUNGUNG c
	JOIN NguyenLieu nl ON nl.MaNguyenLieu = c.MaNguyenLieu
	JOIN NhaCungCap nc ON nc.MaNhaCungCap = c.MaNhaCungCap

---6. Xem danh sách nhân viên
CREATE VIEW XEMDSNV AS
SELECT 
    MaNhanVien,
    TenNhanVien,
	Lk.TENCHUCVU,
    SoDienThoai,
    DIACHI,
    MaChiNhanh,
    MANHOM,
	PASSWORD,
	username
FROM 
    NhanVien NV
JOIN 
    CHUCVU LK ON NV.MACV= LK.MACV;



-----------------------------------CURSOR-----------------------------------------
---1/ Tìm ra 3 sản phẩm bán chạy nhất
DECLARE @MaSanPham NCHAR(20),
        @TenSanPham NVARCHAR(100),
        @TongSoLuong INT
DECLARE sanpham_cursor CURSOR FOR
SELECT 
    sp.MaSanPham,
    sp.TenSanPham,
    SUM(cthd.SoLuong) AS TongSoLuong
FROM 
    ChiTietHoaDon cthd
JOIN 
    SanPham sp ON cthd.MaSanPham = sp.MaSanPham
GROUP BY 
    sp.MaSanPham, sp.TenSanPham
ORDER BY 
    TongSoLuong DESC
OPEN sanpham_cursor
FETCH NEXT FROM sanpham_cursor INTO @MaSanPham, @TenSanPham, @TongSoLuong

DECLARE @Counter INT = 1
WHILE @@FETCH_STATUS = 0 AND @Counter <= 3
BEGIN
    PRINT N'Sản phẩm: ' + @TenSanPham + N', Mã sản phẩm: ' + @MaSanPham + N', Tổng số lượng bán: ' + CAST(@TongSoLuong AS NVARCHAR(10))
    SET @Counter = @Counter + 1
    FETCH NEXT FROM sanpham_cursor INTO @MaSanPham, @TenSanPham, @TongSoLuong
END
CLOSE sanpham_cursor
DEALLOCATE sanpham_cursor


---2/ Tìm 3 khách hàng có doanh số cao nhất
DECLARE @MaKH NCHAR(20),
        @TenKH NVARCHAR(50),
        @DoanhThu DECIMAL(18, 2)

CREATE TABLE #DoanhThuKhachHang (
    MaKH NCHAR(20),
    TenKH NVARCHAR(50),
    DoanhThu DECIMAL(18, 2)
)

INSERT INTO #DoanhThuKhachHang (MaKH, TenKH, DoanhThu)
SELECT 
    kh.MaKH,
    kh.TenKH,
    SUM(hd.THANHTIEN) AS DoanhThu
FROM 
    KHACHHANG kh
JOIN 
    HoaDon hd ON kh.MaKH = hd.MAKH
GROUP BY 
    kh.MaKH, kh.TenKH

DECLARE top3_cursor CURSOR FOR
SELECT TOP 3 
    MaKH,
    TenKH,
    DoanhThu
FROM 
    #DoanhThuKhachHang
ORDER BY 
    DoanhThu DESC

OPEN top3_cursor

FETCH NEXT FROM top3_cursor INTO @MaKH, @TenKH, @DoanhThu

WHILE @@FETCH_STATUS = 0
BEGIN
    PRINT 'Mã khách hàng: ' + @MaKH + 
          ', Tên khách hàng: ' + @TenKH + 
          ', Doanh số: ' + CAST(@DoanhThu AS NVARCHAR)

    FETCH NEXT FROM top3_cursor INTO @MaKH, @TenKH, @DoanhThu
END

CLOSE top3_cursor
DEALLOCATE top3_cursor

DROP TABLE #DoanhThuKhachHang

GO
---------------------------------------ROLE--------------------------------------
CREATE ROLE Kho
CREATE ROLE ThuNgan
CREATE ROLE QuanLy

-----------Quyền nhân viên kho-------
GRANT SELECT, INSERT, UPDATE, DELETE ON NguyenLieu TO Kho;
GRANT SELECT, INSERT, UPDATE, DELETE ON PhieuNhap TO Kho;
GRANT SELECT, INSERT, UPDATE, DELETE ON ChiTietPhieuNhap TO Kho;
GRANT SELECT, INSERT, UPDATE, DELETE ON PHIEUXUAT TO Kho;
GRANT SELECT, INSERT, UPDATE, DELETE ON CHITIETPX TO Kho;

----------Quyền nhân viên thu ngân-------
GRANT SELECT ON SanPham TO ThuNgan
GRANT SELECT, INSERT, UPDATE ON KHACHHANG TO ThuNgan;
GRANT SELECT, INSERT, UPDATE ON HoaDon TO ThuNgan;
GRANT SELECT, INSERT, UPDATE ON ChiTietHoaDon TO ThuNgan;

-------------Quyền quản lý----------------
GRANT SELECT, INSERT, UPDATE, DELETE ON ChiNhanh TO QuanLy;
GRANT SELECT, INSERT, UPDATE, DELETE ON LOAIKH TO QuanLy;
GRANT SELECT, INSERT, UPDATE, DELETE ON KHACHHANG TO QuanLy;
GRANT SELECT, INSERT, UPDATE, DELETE ON LOAISP TO QuanLy;
GRANT SELECT, INSERT, UPDATE, DELETE ON SanPham TO QuanLy;
GRANT SELECT, INSERT, UPDATE, DELETE ON HoaDon TO QuanLy;
GRANT SELECT, INSERT, UPDATE, DELETE ON ChiTietHoaDon TO QuanLy;
GRANT SELECT, INSERT, UPDATE, DELETE ON LOAINL TO QuanLy;
GRANT SELECT, INSERT, UPDATE, DELETE ON DONVITINH TO QuanLy;
GRANT SELECT, INSERT, UPDATE, DELETE ON NguyenLieu TO QuanLy;
GRANT SELECT, INSERT, UPDATE, DELETE ON NhaCungCap TO QuanLy;
GRANT SELECT, INSERT, UPDATE, DELETE ON CUNGUNG TO QuanLy;
GRANT SELECT, INSERT, UPDATE, DELETE ON PhieuNhap TO QuanLy;
GRANT SELECT, INSERT, UPDATE, DELETE ON ChiTietPhieuNhap TO QuanLy;
GRANT SELECT, INSERT, UPDATE, DELETE ON NhanVien TO QuanLy;
GRANT SELECT, INSERT, UPDATE, DELETE ON LUONG TO QuanLy;
GRANT SELECT, INSERT, UPDATE, DELETE ON PHIEUXUAT TO QuanLy;
GRANT SELECT, INSERT, UPDATE, DELETE ON CHITIETPX TO QuanLy;