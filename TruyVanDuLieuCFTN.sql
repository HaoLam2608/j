---------------PROCEDURE-------------------
go
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
EXEC ThemKhachHang @MaKH = 'KH001', @TenKH = N'Nguyễn Văn A', @MALOAI = 1, @SDT = '0901234567', @SoDiemThuong = 10

go
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

CREATE PROC INSERTPX @maPX NCHAR(20), @maNV NCHAR(20), @maCN NCHAR(20), @ngayTaoPX DATETIME, @moTa NVARCHAR(500)
AS
BEGIN
	INSERT INTO PHIEUXUAT VALUES
	(@maPX, @maNV, @maCN, @ngayTaoPX, @moTa)
END

CREATE PROC INSERTCTPX @maPX NCHAR(20), @maNL NCHAR(20), @soLuongXuat INT
AS
BEGIN
	INSERT INTO CHITIETPX VALUES
	(@maPX, @maNL, @soLuongXuat)
END

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
EXEC sp_DisplayCustomerPoints;

CREATE PROC ThemNguoiDung @username nchar(20) , @pass nchar(20)
as
begin
IF EXISTS(SELECT 1 FROM SYS.server_principals WHERE NAME = @username AND type_desc='SQL_LOGIN')
	RETURN;
ELSE
	BEGIN
		DECLARE @Sql nvarchar(MAX)
		SET @Sql = 'CREATE LOGIN ['+@username+'] WITH PASSWORD = ''' + @pass + '''';
		EXEC(@Sql)
		exec sp_adduser @username , @username
		EXEC sp_addrolemember 'ThuNgan', @username
	END
end
-----------------FUNCTION---------------------
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
        HD.MaChiNhanh,
        HD.MaKH,
        CT.MaSanPham,
        CT.SoLuong,
        CT.DonGia
    FROM 
        HoaDon AS HD
    JOIN 
        ChiTietHoaDon AS CT ON HD.MaHoaDon = CT.MaHoaDon
);
SELECT * FROM dbo.fn_ViewAllInvoices();

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

CREATE FUNCTION TINHTONGDOANHTHU(@Thang int , @Nam int)
RETURNS table
AS
	RETURN SELECT month(HoaDon.NgayTao) as 'Tháng', year(HoaDon.NgayTao) as 'Năm', SUM(HoaDon.THANHTIEN) as 'Tổng doanh thu'
	FROM HoaDon
	WHERE (@Thang IS NULL OR MONTH(HoaDon.NgayTao) = @thang) and (@Nam IS NULL OR YEAR(HoaDon.NgayTao) = @Nam) 
	group by month(HoaDon.NgayTao),year(HoaDon.NgayTao)
	
select * from dbo.TINHTONGDOANHTHU(null , null)
-----------------TRIGGER-------------------------
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

--------------------VIEW------------------------
CREATE VIEW vw_ThongTinNhanVienChiNhanh AS
SELECT NV.MaNhanVien, NV.TenNhanVien, CV.TENCHUCVU, NV.SoDienThoai, NV.DIACHI, CN.TenChiNhanh, NQ.TENNHOM
FROM NhanVien NV
JOIN CHUCVU CV ON NV.MACV = CV.MACV
JOIN ChiNhanh CN ON NV.MaChiNhanh = CN.MaChiNhanh
JOIN NHOMQUYEN NQ ON NV.MANHOM = NQ.MANHOM;

SELECT * FROM vw_ThongTinNhanVienChiNhanh

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

CREATE VIEW DSNGUYENLIEU
AS
	SELECT nl.MaNguyenLieu, l.MALOAI, TENLOAI, TenNguyenLieu, SOLUONGTON, TENDVT, TenNhaCungCap, n.MaNhaCungCap 
	FROM NguyenLieu nl 
	join LOAINL l on l.MALOAI = nl.MALOAI 
	join DONVITINH d on d.MADVT = nl.MADVT 
	join CUNGUNG c on c.MaNguyenLieu = nl.MaNguyenLieu
	join NhaCungCap n on n.MaNhaCungCap = c.MaNhaCungCap


----------------------ROLE--------------------
CREATE ROLE Kho
CREATE ROLE ThuNgan
CREATE ROLE QuanLy

GRANT SELECT ON SanPham TO ThuNgan

GRANT SELECT, INSERT, UPDATE, DELETE ON NguyenLieu TO Kho;
GRANT SELECT, INSERT, UPDATE, DELETE ON PhieuNhap TO Kho;
GRANT SELECT, INSERT, UPDATE, DELETE ON ChiTietPhieuNhap TO Kho;
GRANT SELECT, INSERT, UPDATE, DELETE ON PHIEUXUAT TO Kho;
GRANT SELECT, INSERT, UPDATE, DELETE ON CHITIETPX TO Kho;

GRANT SELECT, INSERT, UPDATE ON KHACHHANG TO ThuNgan;
GRANT SELECT, INSERT, UPDATE ON HoaDon TO ThuNgan;
GRANT SELECT, INSERT, UPDATE ON ChiTietHoaDon TO ThuNgan;

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