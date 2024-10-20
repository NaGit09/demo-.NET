CREATE DATABASE Shop
USE Shop
Go
CREATE TABLE HANGHOA (
    MaHang INT PRIMARY KEY IDENTITY(1,1),  -- Mã hàng tự tăng
    TenHang NVARCHAR(255) NOT NULL,        -- Tên hàng
    DonGia DECIMAL(18, 2) NOT NULL,        -- Đơn giá
    SoLuongTon INT NOT NULL                -- Số lượng tồn
);
CREATE TABLE GIOHANG (
    MaGioHang INT PRIMARY KEY IDENTITY(1,1),   -- Mã giỏ hàng tự tăng
    KhachHangId INT NOT NULL,                  -- Mã khách hàng
    NgayTao DATE NOT NULL                      -- Ngày tạo giỏ hàng
);

CREATE TABLE DONHANG (
    MaDonHang INT PRIMARY KEY IDENTITY(1,1),  -- Mã đơn hàng tự tăng
    MaGioHang INT FOREIGN KEY REFERENCES GIOHANG(MaGioHang), -- Mã giỏ hàng liên kết
    TongTien DECIMAL(18, 2) NOT NULL                         -- Tổng tiền đơn hàng
);

CREATE TABLE CHITIETGIOHANG (
    MaChiTiet INT PRIMARY KEY IDENTITY(1,1),  -- Mã chi tiết tự tăng
    MaGioHang INT FOREIGN KEY REFERENCES GIOHANG(MaGioHang), -- Mã giỏ hàng liên kết
    MaHang INT FOREIGN KEY REFERENCES HANGHOA(MaHang),       -- Mã hàng liên kết
    SoLuong INT NOT NULL                                     -- Số lượng hàng hóa trong giỏ
);
CREATE TABLE CHITIETDONHANG (
    MaChiTiet INT PRIMARY KEY IDENTITY(1,1),  -- Mã chi tiết tự tăng
    MaDonHang INT FOREIGN KEY REFERENCES DONHANG(MaDonHang), -- Mã đơn hàng liên kết
    MaHang INT FOREIGN KEY REFERENCES HANGHOA(MaHang),       -- Mã hàng liên kết
    SoLuong INT NOT NULL,                                    -- Số lượng hàng hóa
    DonGia DECIMAL(18, 2) NOT NULL                           -- Đơn giá tại thời điểm đặt
);

-- Thêm sản phẩm vào bảng HANGHOA
INSERT INTO HANGHOA (TenHang, DonGia, SoLuongTon)
VALUES (N'Bánh ngọt 1', 20000, 50), (N'Bánh ngọt 2', 25000, 30), 
       (N'Bánh ngọt 3', 22000, 20), (N'Bánh ngọt 4', 21000, 40);

INSERT INTO HANGHOA (TenHang, DonGia, SoLuongTon)
VALUES (N'Bánh mặn 1', 30000, 50), (N'Bánh mặn 2', 35000, 30), 
       (N'Bánh mặn 3', 32000, 20), (N'Bánh mặn 4', 31000, 40);

INSERT INTO HANGHOA (TenHang, DonGia, SoLuongTon)
VALUES (N'Bánh chay 1', 18000, 50), (N'Bánh chay 2', 20000, 30), 
       (N'Bánh chay 3', 22000, 20), (N'Bánh chay 4', 24000, 40);

CREATE TABLE TAIKHOAN (
        KhachHangId INT PRIMARY KEY NOT NULL,
		MatKhau varchar(25) NOT NUll
);
ALTER TABLE GIOHANG
ADD CONSTRAINT fk_id
FOREIGN KEY (KhachHangId) REFERENCES TAIKHOAN(KhachHangId);

alter table chitietgiohang 
alter column mahang int not null 

alter table chitietgiohang 
alter column magiohang int not null 