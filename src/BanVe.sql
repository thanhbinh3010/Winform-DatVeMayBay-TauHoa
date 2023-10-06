CREATE DATABASE BanVe
go

USE BanVe
go

CREATE TABLE DatVe (
masove char (10) not null,
loaive nvarchar (50) ,
ngaydat datetime ,
ngaybay datetime,
constraint DatVe1 Primary Key (masove));

CREATE TABLE MayBay (
kihieuMB int not null,
hangbay nvarchar (50),
chuyenbay nvarchar(50),
constraint MayBay1 Primary Key (kihieuMB));


CREATE TABLE ChiTietVeMB (
maghe char (10) not null ,
dayghe int ,
khoangMB nvarchar (20),
masove char (10) Foreign key (masove) References DatVe (masove),
kihieuMB int     Foreign key (kihieuMB) References MayBay (kihieuMB),
constraint ChiTietVeMB1 Primary Key (maghe));

CREATE TABLE TauLua (
kihieuTau int not null,
loaitau nvarchar (50),
constraint TauLua1 Primary Key (kihieuTau));

CREATE TABLE ChiTietVeTau (
maghe char (10) not null ,
dayghe int not null,
toatau nvarchar(50) not null,
masove char (10) Foreign key (masove) References DatVe (masove),
kihieuTau int Foreign key (kihieuTau) References TauLua (kihieuTau),
constraint ChiTietVeTau1 Primary Key (maghe));


CREATE TABLE KhachHang (
maKH char (10) not null,
tenKH nvarchar (50),
diachi nvarchar (50),
SDT int,
masove char (10) Foreign key (masove) References DatVe (masove),
constraint KhachHang1 Primary Key (maKH));

CREATE TABLE DangNhap (
taikhoan nvarchar (30) not null ,
matkhau nvarchar (30),
maKH char (10) Foreign key (makh) References KhachHang (maKH),
constraint DangNhap1 Primary Key (taikhoan));

CREATE TABLE TraTien (
mathanhtoan char (10) not null ,
ngaythanhtoan datetime ,
thanhtien int ,
constraint ThanhToan Primary Key (mathanhtoan));

CREATE TABLE HinhThucTT (
giantiep nvarchar (30) not null ,
tructiep nvarchar (30),
mathanhtoan char (10) Foreign key (mathanhtoan) References TraTien (mathanhtoan));

--CREATE TABLE DatVe (
--masove char (10) not null,
--loaive nvarchar (50) ,
---ngaydat datetime ,
--ngaybay datetime,
---constraint DatVe1 Primary Key (masove));

insert into DatVe(masove,loaive,ngaydat,ngaybay) values (1002,N'Vé vip',15/9/2020,16/9/2020)
insert into DatVe(masove,loaive,ngaydat,ngaybay) values (1004,N'Vé vip',17/9/2020,18/9/2020)

insert into TauLua(kihieuTau,loaitau) values (01 ,N'Tàu tốc hành')
insert into TauLua(kihieuTau,loaitau) values (02 ,N'Tàu bình thường')


insert into ChiTietVeTau(maghe,dayghe, toatau,masove ,kihieuTau ) values ('A01',2,N'Toa 1',1002,01)
insert into ChiTietVeTau(maghe,dayghe, toatau,masove ,kihieuTau ) values ('A07',4,N'Toa 2',1004,02)
select * from ChiTietVeTau