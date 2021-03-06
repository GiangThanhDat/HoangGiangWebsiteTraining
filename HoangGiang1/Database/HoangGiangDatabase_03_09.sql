USE [HoangGiangDatabase]
GO
/****** Object:  Table [dbo].[ApplicationGroups]    Script Date: 9/3/2020 5:38:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ApplicationGroups](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](250) NULL,
	[Description] [nvarchar](250) NULL,
 CONSTRAINT [PK_dbo.ApplicationGroups] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ApplicationRoleGroups]    Script Date: 9/3/2020 5:38:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ApplicationRoleGroups](
	[GroupId] [int] NOT NULL,
	[RoleId] [nvarchar](128) NOT NULL,
	[Note] [nvarchar](100) NULL,
 CONSTRAINT [PK_dbo.ApplicationRoleGroups] PRIMARY KEY CLUSTERED 
(
	[GroupId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ApplicationRoles]    Script Date: 9/3/2020 5:38:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ApplicationRoles](
	[Id] [nvarchar](128) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Description] [nvarchar](250) NULL,
	[Discriminator] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.ApplicationRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ApplicationUserClaims]    Script Date: 9/3/2020 5:38:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ApplicationUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
	[ApplicationUser_Id] [nvarchar](128) NULL,
 CONSTRAINT [PK_dbo.ApplicationUserClaims] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ApplicationUserGroups]    Script Date: 9/3/2020 5:38:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ApplicationUserGroups](
	[UserId] [nvarchar](128) NOT NULL,
	[GroupId] [int] NOT NULL,
	[Note] [nvarchar](100) NULL,
 CONSTRAINT [PK_dbo.ApplicationUserGroups] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[GroupId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ApplicationUserLogins]    Script Date: 9/3/2020 5:38:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ApplicationUserLogins](
	[UserId] [nvarchar](128) NOT NULL,
	[LoginProvider] [nvarchar](max) NULL,
	[ProviderKey] [nvarchar](max) NULL,
	[ApplicationUser_Id] [nvarchar](128) NULL,
 CONSTRAINT [PK_dbo.ApplicationUserLogins] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ApplicationUserRoles]    Script Date: 9/3/2020 5:38:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ApplicationUserRoles](
	[UserId] [nvarchar](128) NOT NULL,
	[RoleId] [nvarchar](128) NOT NULL,
	[IdentityRole_Id] [nvarchar](128) NULL,
	[ApplicationUser_Id] [nvarchar](128) NULL,
 CONSTRAINT [PK_dbo.ApplicationUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ApplicationUsers]    Script Date: 9/3/2020 5:38:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ApplicationUsers](
	[Id] [nvarchar](128) NOT NULL,
	[FullName] [nvarchar](256) NULL,
	[Address] [nvarchar](256) NULL,
	[BirthDay] [datetime] NULL,
	[Email] [nvarchar](max) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEndDateUtc] [datetime] NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[UserName] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.ApplicationUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BaoGia]    Script Date: 9/3/2020 5:38:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BaoGia](
	[MaSoBaoGia] [nvarchar](50) NOT NULL,
	[MaKhachHang] [nvarchar](50) NULL,
	[GhiChu] [nvarchar](250) NULL,
	[MaSoNhanVien] [nvarchar](10) NULL,
	[NgayBaoGia] [date] NULL,
	[HieuLucDen] [date] NULL,
	[MaLoaiTien] [int] NULL,
	[TyGia] [float] NULL,
	[TienHang] [float] NULL,
	[TienThueGTGT] [float] NULL,
	[TienChietKhau] [float] NULL,
	[TongTien] [float] NULL,
 CONSTRAINT [PK_BaoGia] PRIMARY KEY CLUSTERED 
(
	[MaSoBaoGia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChiTietBaoGia]    Script Date: 9/3/2020 5:38:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietBaoGia](
	[MaChiTietBaoGia] [int] IDENTITY(1,1) NOT NULL,
	[MaSoBaoGia] [nvarchar](50) NULL,
	[MaHang] [nvarchar](50) NULL,
	[SoLuong] [int] NULL,
	[ThanhTien] [float] NULL,
	[TienChietKhau] [float] NULL,
	[TienThueGTGT] [float] NULL,
 CONSTRAINT [PK_ChiTietBaoGia] PRIMARY KEY CLUSTERED 
(
	[MaChiTietBaoGia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChiTietChungTuBanHang]    Script Date: 9/3/2020 5:38:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietChungTuBanHang](
	[MaChiTietChungTuBanHang] [int] IDENTITY(1,1) NOT NULL,
	[MaChungTuBanHang] [nvarchar](50) NULL,
	[MaHang] [nvarchar](50) NULL,
	[TKCongNo_ChiPhi] [nvarchar](250) NULL,
	[TKDoanhThu] [nvarchar](250) NULL,
	[SoLuong] [int] NULL,
	[ThanhTien] [float] NULL,
	[TienChietKhau] [float] NULL,
	[TienThueGTGT] [float] NULL,
 CONSTRAINT [PK_ChiTietChungTuBanHang] PRIMARY KEY CLUSTERED 
(
	[MaChiTietChungTuBanHang] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChiTietChungTuMuaDichVu]    Script Date: 9/3/2020 5:38:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietChungTuMuaDichVu](
	[MaChiTietChungTuMuaDichVu] [int] IDENTITY(1,1) NOT NULL,
	[MaChungTuMuaDichVu] [nvarchar](50) NULL,
	[MaDichVu] [nvarchar](50) NULL,
	[TKChiPhi_TKKho] [nvarchar](250) NULL,
	[TKCongNo] [nvarchar](250) NULL,
	[DoiTuong] [nvarchar](250) NULL,
	[TenDoiTuong] [nvarchar](250) NULL,
	[SoLuong] [int] NULL,
	[ThanhTien] [float] NULL,
 CONSTRAINT [PK_ChiTietChungTuMuaDichVu] PRIMARY KEY CLUSTERED 
(
	[MaChiTietChungTuMuaDichVu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChiTietChungTuMuaHang]    Script Date: 9/3/2020 5:38:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietChungTuMuaHang](
	[MaChiTietChungTuMuaHang] [int] IDENTITY(1,1) NOT NULL,
	[MaChungTuMuaHang] [nvarchar](50) NULL,
	[MaHang] [nvarchar](50) NULL,
	[Kho] [nvarchar](250) NULL,
	[TKKho] [nvarchar](250) NULL,
	[TKCongNo] [nvarchar](250) NULL,
	[SoLuong] [int] NULL,
	[ThanhTien] [float] NULL,
	[TienChietKhau] [float] NULL,
	[ChiPhiMuaHang] [nvarchar](250) NULL,
	[GiaTriNhapKho] [nvarchar](250) NULL,
	[SoLo] [nvarchar](250) NULL,
	[DoiTuongDHCP] [nvarchar](250) NULL,
	[CongTrinh] [nvarchar](250) NULL,
	[MaHopDongMua] [nvarchar](50) NULL,
	[MaDonMuaHang] [nvarchar](10) NULL,
	[MaThongKe] [nvarchar](250) NULL,
 CONSTRAINT [PK_ChiTietChungTuMuaHang] PRIMARY KEY CLUSTERED 
(
	[MaChiTietChungTuMuaHang] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChiTietDonDatHang]    Script Date: 9/3/2020 5:38:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietDonDatHang](
	[MaChiTietDonDatHang] [int] IDENTITY(1,1) NOT NULL,
	[MaDonDatHang] [nvarchar](50) NULL,
	[MaHang] [nvarchar](50) NULL,
	[SoLuong] [int] NULL,
	[SoLuongDaGiao] [float] NULL,
	[ThanhTien] [float] NULL,
	[TienThueGTGT] [float] NULL,
 CONSTRAINT [PK_ChiTietDonDatHang] PRIMARY KEY CLUSTERED 
(
	[MaChiTietDonDatHang] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChiTietDonMuaHang]    Script Date: 9/3/2020 5:38:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietDonMuaHang](
	[MaCTDMH] [int] IDENTITY(1,1) NOT NULL,
	[MaDonMuaHang] [nvarchar](10) NULL,
	[MaHang] [nvarchar](50) NULL,
	[SoLuong] [int] NULL,
	[SoLuongNhan] [int] NULL,
	[DonGia] [float] NULL,
	[ThanhTien] [float] NULL,
	[ThueGTGT] [float] NULL,
	[TienThueGTGT] [float] NULL,
	[LenhSanXuat] [nvarchar](250) NULL,
	[ThanhPham] [nvarchar](250) NULL,
 CONSTRAINT [PK_ChiTietDonMuaHang] PRIMARY KEY CLUSTERED 
(
	[MaCTDMH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChiTietGiamGiaHangBan]    Script Date: 9/3/2020 5:38:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietGiamGiaHangBan](
	[MaChiTietGiamGiaHangBan] [int] IDENTITY(1,1) NOT NULL,
	[MaGiamGiaHangBan] [nvarchar](50) NULL,
	[MaHang] [nvarchar](50) NULL,
	[TKGiamGia] [nvarchar](250) NULL,
	[TKTien] [nvarchar](250) NULL,
	[SoLuong] [int] NULL,
	[ThanhTien] [float] NULL,
	[TienChietKhau] [float] NULL,
	[TienThueGTGT] [float] NULL,
 CONSTRAINT [PK_ChiTietGiamGiaHangBan] PRIMARY KEY CLUSTERED 
(
	[MaChiTietGiamGiaHangBan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChiTietGiamGiaHangMua]    Script Date: 9/3/2020 5:38:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietGiamGiaHangMua](
	[MaChiTietGiamGiaHangMua] [int] IDENTITY(1,1) NOT NULL,
	[MaGiamGiaHangMua] [nvarchar](50) NULL,
	[MaHang] [nvarchar](50) NULL,
	[Kho] [nvarchar](250) NULL,
	[TKKho] [nvarchar](250) NULL,
	[TKCongNo] [nvarchar](250) NULL,
	[SoLuong] [int] NULL,
	[ThanhTien] [float] NULL,
	[DienGiaiThue] [nvarchar](250) NULL,
	[TienThueGTGT] [float] NULL,
	[TKThueGTGT] [nvarchar](250) NULL,
	[NhomHHDVMuaVao] [nvarchar](250) NULL,
	[SoLo] [nvarchar](250) NULL,
	[SoCTMuaHang] [nvarchar](250) NULL,
	[SoHDMuaHang] [nvarchar](250) NULL,
	[NgayHDMuaHang] [nvarchar](250) NULL,
	[MaHopDongMua] [nvarchar](50) NULL,
	[MaThongKe] [nvarchar](250) NULL,
 CONSTRAINT [PK_ChiTietGiamGiaHangMua] PRIMARY KEY CLUSTERED 
(
	[MaChiTietGiamGiaHangMua] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChiTietHoaDon_BanHang]    Script Date: 9/3/2020 5:38:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietHoaDon_BanHang](
	[MaChiTietHoaDonBanHang] [int] IDENTITY(1,1) NOT NULL,
	[MaHoaDon] [nvarchar](50) NULL,
	[MaHang] [nvarchar](50) NULL,
	[TKCongNo_ChiPhi] [nvarchar](250) NULL,
	[TKDoanhThu] [nvarchar](250) NULL,
	[SoLuong] [int] NULL,
	[ThanhTien] [float] NULL,
	[TienChietKhau] [float] NULL,
	[TienThueGTGT] [float] NULL,
 CONSTRAINT [PK_ChiTietHoaDon_BanHang] PRIMARY KEY CLUSTERED 
(
	[MaChiTietHoaDonBanHang] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChiTietHopDongMua]    Script Date: 9/3/2020 5:38:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietHopDongMua](
	[MaChiTietHopDongMua] [int] IDENTITY(1,1) NOT NULL,
	[MaHopDongMua] [nvarchar](50) NOT NULL,
	[MaHang] [nvarchar](50) NULL,
	[SoLuong] [int] NULL,
	[TienChietKhau] [float] NULL,
	[TienThueGTGT] [float] NULL,
	[ThanhTien] [float] NULL,
 CONSTRAINT [PK_ChiTietHopDongMua] PRIMARY KEY CLUSTERED 
(
	[MaChiTietHopDongMua] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChiTietLapRapThaoDo]    Script Date: 9/3/2020 5:38:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietLapRapThaoDo](
	[MaChiTietLapRapThaoDo] [int] IDENTITY(1,1) NOT NULL,
	[MaLapRapThaoDo] [nvarchar](50) NULL,
	[MaHang] [nvarchar](50) NULL,
	[SoLuong] [int] NULL,
	[ThanhTien] [float] NULL,
 CONSTRAINT [PK_ChiTietLapRapThaoDo] PRIMARY KEY CLUSTERED 
(
	[MaChiTietLapRapThaoDo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChiTietPhieuChi]    Script Date: 9/3/2020 5:38:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietPhieuChi](
	[MaCTPC] [int] IDENTITY(1,1) NOT NULL,
	[MaPhieuChi] [nvarchar](50) NULL,
	[MaHang] [nvarchar](50) NULL,
	[SoLuong] [int] NULL,
	[SoTien] [float] NULL,
	[DienGiai] [nvarchar](250) NULL,
	[SoTaiKhoanCo] [nvarchar](250) NULL,
	[SoTaiKhoanNo] [nvarchar](250) NULL,
	[MaNhaCungCap] [nvarchar](6) NULL,
	[TenNhaCungCap] [nvarchar](250) NULL,
	[TaiKhoanNganHang] [nvarchar](250) NULL,
	[MucThuChi] [nvarchar](250) NULL,
	[DonVi] [nvarchar](250) NULL,
	[CongTrinh] [nvarchar](250) NULL,
	[HopDongBan] [nvarchar](250) NULL,
	[MaThongKe] [nvarchar](250) NULL,
	[KhoanMucCP] [nvarchar](250) NULL,
	[DoiTuongDHCP] [nvarchar](250) NULL,
	[DonDatHang] [nvarchar](250) NULL,
	[DonMuaHang] [nvarchar](250) NULL,
 CONSTRAINT [PK_ChiTietPhieuChi] PRIMARY KEY CLUSTERED 
(
	[MaCTPC] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChiTietPhieuNhapKho]    Script Date: 9/3/2020 5:38:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietPhieuNhapKho](
	[MaChiTietPhieuNhapKho] [int] IDENTITY(1,1) NOT NULL,
	[MaPhieuNhapKho] [nvarchar](50) NULL,
	[MaHang] [nvarchar](50) NULL,
	[Kho] [nvarchar](250) NULL,
	[TKNo] [nvarchar](250) NULL,
	[TKCo] [nvarchar](250) NULL,
	[ThanhTien] [float] NULL,
	[MaLenhSanXuat] [nvarchar](50) NULL,
 CONSTRAINT [PK_ChiTietPhieuNhapKho] PRIMARY KEY CLUSTERED 
(
	[MaChiTietPhieuNhapKho] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChiTietPhieuThu]    Script Date: 9/3/2020 5:38:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietPhieuThu](
	[MaCTPT] [int] IDENTITY(1,1) NOT NULL,
	[MaPhieuThu] [nvarchar](50) NULL,
	[MaHang] [nvarchar](50) NULL,
	[SoLuong] [int] NOT NULL,
	[SoTien] [float] NULL,
	[DienGiai] [nvarchar](250) NULL,
	[SoTaiKhoanCo] [nvarchar](250) NULL,
	[SoTaiKhoanNo] [nvarchar](250) NULL,
	[MaKhachHang] [nvarchar](6) NULL,
	[TenKhachHang] [nvarchar](250) NULL,
	[TaiKhoanNganHang] [nvarchar](250) NULL,
	[MucThuChi] [nvarchar](250) NULL,
	[DonVi] [nvarchar](250) NULL,
	[CongTrinh] [nvarchar](250) NULL,
	[HopDongBan] [nvarchar](250) NULL,
	[MaThongKe] [nvarchar](250) NULL,
 CONSTRAINT [PK_ChiTietThu] PRIMARY KEY CLUSTERED 
(
	[MaCTPT] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChiTietPhieuXuatKho]    Script Date: 9/3/2020 5:38:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietPhieuXuatKho](
	[MaChiTietPhieuXuat] [int] IDENTITY(1,1) NOT NULL,
	[MaPhieuXuat] [nvarchar](50) NULL,
	[MaHang] [nvarchar](50) NULL,
	[TKCongNo_ChiPhi] [nvarchar](250) NULL,
	[TKDoanhThu] [nvarchar](250) NULL,
	[SoLuong] [int] NULL,
	[ThanhTien] [float] NULL,
	[TienChietKhau] [float] NULL,
	[TienThueGTGT] [float] NULL,
	[Kho] [nvarchar](250) NULL,
	[TKNo] [nvarchar](250) NULL,
	[TKCo] [nvarchar](250) NULL,
 CONSTRAINT [PK_ChiTietPhieuXuat_BanHang] PRIMARY KEY CLUSTERED 
(
	[MaChiTietPhieuXuat] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChiTietTraLaiHangBan]    Script Date: 9/3/2020 5:38:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietTraLaiHangBan](
	[MaChiTietTraLaiHangBan] [int] IDENTITY(1,1) NOT NULL,
	[MaTraLaiHangBan] [nvarchar](50) NOT NULL,
	[MaHang] [nvarchar](50) NULL,
	[TKTraLai] [nvarchar](250) NULL,
	[TKTien] [nvarchar](250) NULL,
	[SoLuong] [int] NULL,
	[ThanhTien] [float] NULL,
	[TienChietKhau] [float] NULL,
	[MucThuChi] [nvarchar](250) NULL,
 CONSTRAINT [PK_ChiTietTraLaiHangBan] PRIMARY KEY CLUSTERED 
(
	[MaChiTietTraLaiHangBan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChiTietTraLaiHangMua]    Script Date: 9/3/2020 5:38:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietTraLaiHangMua](
	[MaChiTietTraLaiHangMua] [int] IDENTITY(1,1) NOT NULL,
	[MaTraLaiHangMua] [nvarchar](50) NULL,
	[MaHang] [nvarchar](50) NULL,
	[Kho] [nvarchar](250) NULL,
	[TKKho] [nvarchar](250) NULL,
	[TKCongNo] [nvarchar](250) NULL,
	[SoLuong] [int] NULL,
	[ThanhTien] [float] NULL,
	[DienGiaiThue] [nvarchar](250) NULL,
	[TienThueGTGT] [float] NULL,
	[TKThueGTGT] [nvarchar](250) NULL,
	[NhomHHDVMuaVao] [nvarchar](250) NULL,
	[SoLo] [nvarchar](250) NULL,
	[SoCTMuaHang] [nvarchar](250) NULL,
	[SoHDMuaHang] [nvarchar](250) NULL,
	[NgayHDMuaHang] [nvarchar](250) NULL,
	[MaHopDongMua] [nvarchar](50) NULL,
	[MaThongKe] [nvarchar](250) NULL,
 CONSTRAINT [PK_ChiTietTraLaiHangMua] PRIMARY KEY CLUSTERED 
(
	[MaChiTietTraLaiHangMua] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChucVu]    Script Date: 9/3/2020 5:38:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChucVu](
	[MaChucVu] [nvarchar](2) NOT NULL,
	[TenChucVu] [nvarchar](250) NULL,
 CONSTRAINT [PK_ChucVu] PRIMARY KEY CLUSTERED 
(
	[MaChucVu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChungTuBanHang]    Script Date: 9/3/2020 5:38:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChungTuBanHang](
	[MaChungTuBanHang] [nvarchar](50) NOT NULL,
	[MaKhachHang] [nvarchar](50) NULL,
	[DienGiai] [nvarchar](250) NULL,
	[MaSoNhanVien] [nvarchar](10) NULL,
	[NgayHoachToan] [datetime] NULL,
	[NgayChungTu] [datetime] NULL,
	[MaDieuKhoan] [int] NULL,
	[SoNgayDuocNo] [float] NULL,
	[HanThanhToan] [date] NULL,
	[MaLoaiTien] [int] NULL,
	[TyGia] [float] NULL,
	[TongTienHang] [float] NULL,
	[TienThueGTGT] [float] NULL,
	[TienChietKhau] [float] NULL,
	[TongTienThanhToan] [float] NULL,
	[DaGhiSo] [bit] NULL,
	[MaSoBaoGia] [nvarchar](50) NULL,
	[MaPhieuGoc] [nvarchar](50) NULL,
	[DaThayDoi] [bit] NULL,
	[MaPhieuMoi] [nvarchar](50) NULL,
	[NgayThayDoi] [datetime] NULL,
	[NhanVienThayDoi] [nvarchar](10) NULL,
	[CoSoThayDoi] [nvarchar](10) NULL,
 CONSTRAINT [PK_ChungTuBanHang] PRIMARY KEY CLUSTERED 
(
	[MaChungTuBanHang] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChungTuMuaDichVu]    Script Date: 9/3/2020 5:38:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChungTuMuaDichVu](
	[MaChungTuMuaDichVu] [nvarchar](50) NOT NULL,
	[MaNhaCungCap] [nvarchar](6) NULL,
	[DienGiai] [nvarchar](250) NULL,
	[MaSoNhanVien] [nvarchar](10) NULL,
	[MaDieuKhoan] [int] NULL,
	[SoNgayDuocNo] [float] NULL,
	[HanThanhToan] [date] NULL,
	[MaLoaiTien] [int] NULL,
	[TyGia] [float] NULL,
	[NgayHoachToan] [date] NULL,
	[NgayChungTu] [date] NULL,
	[TienDichVu] [float] NULL,
	[TienThueGTGT] [float] NULL,
	[TienChietKhau] [float] NULL,
	[TongTienThanhToan] [float] NULL,
	[DaGhiSo] [bit] NULL,
 CONSTRAINT [PK_ChungTuMuaDichVu] PRIMARY KEY CLUSTERED 
(
	[MaChungTuMuaDichVu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChungTuMuaHang]    Script Date: 9/3/2020 5:38:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChungTuMuaHang](
	[MaChungTuMuaHang] [nvarchar](50) NOT NULL,
	[MaNhaCungCap] [nvarchar](6) NULL,
	[NguoiGiaoHang] [nvarchar](250) NULL,
	[DienGiai] [nvarchar](250) NULL,
	[MaSoNhanVien] [nvarchar](10) NULL,
	[ChungTuGoc] [int] NULL,
	[DieuKhoanTT] [nvarchar](250) NULL,
	[SoNgayDuocNo] [float] NULL,
	[HanThanhToan] [date] NULL,
	[MaLoaiTien] [int] NULL,
	[TyGia] [float] NULL,
	[NgayHoachToan] [date] NULL,
	[NgayChungTu] [date] NULL,
	[TongTienHang] [float] NULL,
	[ChiPhiGiaoHang] [float] NULL,
	[TienChietKhau] [float] NULL,
	[GiaTriNhapKho] [float] NULL,
	[TongTienThanhToan] [float] NULL,
 CONSTRAINT [PK_ChungTuMuaHang] PRIMARY KEY CLUSTERED 
(
	[MaChungTuMuaHang] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CoCauToChuc]    Script Date: 9/3/2020 5:38:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CoCauToChuc](
	[MaDonVi] [nvarchar](10) NOT NULL,
	[TenDonVi] [nvarchar](50) NULL,
	[DiaChi] [nvarchar](250) NULL,
	[CapToChuc] [nvarchar](50) NULL,
 CONSTRAINT [PK_CoCauToChuc] PRIMARY KEY CLUSTERED 
(
	[MaDonVi] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CoSo]    Script Date: 9/3/2020 5:38:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CoSo](
	[MaCoSo] [nvarchar](10) NOT NULL,
	[DiaChi] [nvarchar](250) NOT NULL,
	[TenCoSo] [nvarchar](250) NULL,
	[CapToChuc] [nvarchar](250) NULL,
 CONSTRAINT [PK_CoSo] PRIMARY KEY CLUSTERED 
(
	[MaCoSo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DichVu]    Script Date: 9/3/2020 5:38:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DichVu](
	[MaDichVu] [nvarchar](50) NOT NULL,
	[TenDichVu] [nvarchar](250) NULL,
	[DonViTinh] [nvarchar](50) NULL,
	[DonGia] [float] NULL,
	[VAT] [float] NULL,
	[ChietKhau] [float] NULL,
 CONSTRAINT [PK_DichVu] PRIMARY KEY CLUSTERED 
(
	[MaDichVu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DieuKhoanThanhToan]    Script Date: 9/3/2020 5:38:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DieuKhoanThanhToan](
	[MaDieuKhoan] [int] IDENTITY(1,1) NOT NULL,
	[TenDieuKhoan] [nvarchar](250) NULL,
 CONSTRAINT [PK_DieuKhoanTT] PRIMARY KEY CLUSTERED 
(
	[MaDieuKhoan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DinhKhoanTuDong]    Script Date: 9/3/2020 5:38:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DinhKhoanTuDong](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[LoaiChungTu] [nvarchar](50) NULL,
	[TenDinhKhoan] [nvarchar](50) NULL,
	[SoTaiKhoanCo] [nvarchar](250) NULL,
	[SoTaiKhoanNo] [nvarchar](250) NULL,
 CONSTRAINT [PK_DinhKhoanTuDong] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DonDatHang]    Script Date: 9/3/2020 5:38:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DonDatHang](
	[MaDonDatHang] [nvarchar](50) NOT NULL,
	[MaKhachHang] [nvarchar](50) NULL,
	[NguoiNhanHang] [nvarchar](250) NULL,
	[DienGiai] [nvarchar](250) NULL,
	[MaSoNhanVien] [nvarchar](10) NULL,
	[MaDieuKhoan] [int] NULL,
	[SoNgayDuocNo] [float] NULL,
	[NgayDonHang] [date] NULL,
	[MaTinhTrang] [int] NULL,
	[NgayGiaoHang] [date] NULL,
	[MaLoaiTien] [int] NULL,
	[TyGia] [float] NULL,
	[TongTienHang] [float] NULL,
	[TienThueGTGT] [float] NULL,
	[TongChietKhau] [float] NULL,
	[TongTienThanhToan] [float] NULL,
 CONSTRAINT [PK_DonDatHang] PRIMARY KEY CLUSTERED 
(
	[MaDonDatHang] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DonMuaHang]    Script Date: 9/3/2020 5:38:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DonMuaHang](
	[MaDonMuaHang] [nvarchar](10) NOT NULL,
	[MaNhaCungCap] [nvarchar](6) NOT NULL,
	[DienGiai] [nvarchar](250) NULL,
	[MaSoNhanVien] [nvarchar](10) NULL,
	[MaDieuKhoan] [int] NULL,
	[SoNgayDuocNo] [float] NULL,
	[NgayDonHang] [date] NULL,
	[MaTinhTrang] [int] NOT NULL,
	[NgayGiaoHang] [date] NULL,
	[MaLoaiTien] [int] NULL,
	[TyGia] [float] NULL,
	[TongTienHang] [float] NULL,
	[TienThue] [float] NULL,
	[TienChietKhau] [float] NULL,
	[TongTienThanhToan] [float] NULL,
 CONSTRAINT [PK_DonMuaHang] PRIMARY KEY CLUSTERED 
(
	[MaDonMuaHang] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DonVi]    Script Date: 9/3/2020 5:38:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DonVi](
	[MaDonVi] [nvarchar](50) NOT NULL,
	[TenDonVi] [nvarchar](250) NULL,
 CONSTRAINT [PK_DonVi] PRIMARY KEY CLUSTERED 
(
	[MaDonVi] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DonViTinh]    Script Date: 9/3/2020 5:38:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DonViTinh](
	[MaDonViTinh] [int] IDENTITY(1,1) NOT NULL,
	[TenDonViTinh] [nvarchar](250) NULL,
 CONSTRAINT [PK_DonViTinh] PRIMARY KEY CLUSTERED 
(
	[MaDonViTinh] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GiamGiaHangBan]    Script Date: 9/3/2020 5:38:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GiamGiaHangBan](
	[MaGiamGiaHangBan] [nvarchar](50) NOT NULL,
	[MaKhachHang] [nvarchar](50) NULL,
	[DienGiai] [nvarchar](250) NULL,
	[MaSoNhanVien] [nvarchar](10) NULL,
	[NgayHoachToan] [date] NULL,
	[NgayChungTu] [date] NULL,
	[TongTienHang] [float] NULL,
	[TienThueGTGT] [float] NULL,
	[TienChietKhau] [float] NULL,
	[TongTienThanhToan] [float] NULL,
	[MaLoaiTien] [int] NOT NULL,
	[TyGia] [float] NULL,
	[DaGhiSo] [bit] NULL,
 CONSTRAINT [PK_GiamGiaHangBan] PRIMARY KEY CLUSTERED 
(
	[MaGiamGiaHangBan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GiamGiaHangMua]    Script Date: 9/3/2020 5:38:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GiamGiaHangMua](
	[MaGiamGiaHangMua] [nvarchar](50) NOT NULL,
	[MaNhaCungCap] [nvarchar](6) NULL,
	[DienGiai] [nvarchar](250) NULL,
	[MaSoNhanVien] [nvarchar](10) NULL,
	[ChungTuGoc] [int] NULL,
	[MaLoaiTien] [int] NULL,
	[TyGia] [float] NULL,
	[NgayHoachToan] [date] NULL,
	[NgayChungTu] [date] NULL,
	[TongTienHang] [float] NULL,
	[TienThueGTGT] [float] NULL,
	[TongTienThanhToan] [float] NULL,
	[DaGhiSo] [bit] NULL,
 CONSTRAINT [PK_GiamGiaHangMua] PRIMARY KEY CLUSTERED 
(
	[MaGiamGiaHangMua] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HangHoa]    Script Date: 9/3/2020 5:38:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HangHoa](
	[MaHang] [nvarchar](50) NOT NULL,
	[TenHang] [nvarchar](250) NULL,
	[MaNhomHH] [int] NULL,
	[MaTinhChat] [int] NULL,
	[DonViTinh] [nvarchar](50) NULL,
	[BaoHanh] [nvarchar](250) NULL,
	[NguonGoc] [nvarchar](250) NULL,
	[MoTa] [nvarchar](250) NULL,
	[GiaNhap] [float] NULL,
	[GiaBan] [float] NULL,
	[GiaKhuyenMai] [float] NULL,
	[VAT] [float] NULL,
	[ChietKhau] [float] NULL,
	[HanSuDung] [nvarchar](250) NULL,
	[ThanhPham] [nvarchar](250) NULL,
	[SoLo] [nvarchar](250) NULL,
	[HinhAnh] [nvarchar](250) NULL,
	[NguoiSua] [nvarchar](250) NULL,
	[NgaySua] [datetime] NULL,
 CONSTRAINT [PK_HangHoa] PRIMARY KEY CLUSTERED 
(
	[MaHang] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HangHoa_DonViTinh]    Script Date: 9/3/2020 5:38:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HangHoa_DonViTinh](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[MaDonViTinh] [int] NULL,
	[MaHang] [nvarchar](50) NULL,
	[DonGia] [float] NULL,
 CONSTRAINT [PK_HangHoa_DonViTinh] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HeThongTaiKhoan]    Script Date: 9/3/2020 5:38:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HeThongTaiKhoan](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SoTaiKhoan] [nvarchar](50) NULL,
	[TenTaiKhoan] [nvarchar](50) NULL,
	[TinhChat] [nvarchar](50) NULL,
	[TenTiengAnh] [nvarchar](250) NULL,
	[DienGiai] [nvarchar](250) NULL,
	[NgungTheoDoi] [bit] NULL,
 CONSTRAINT [PK_HeThongTaiKhoan] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HoaDon_BanHang]    Script Date: 9/3/2020 5:38:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HoaDon_BanHang](
	[MaHoaDon] [nvarchar](50) NOT NULL,
	[MaKhachHang] [nvarchar](50) NULL,
	[TKNganHang] [nvarchar](250) NULL,
	[NguoiMuaHang] [nvarchar](250) NULL,
	[HinhThucTT] [nvarchar](250) NULL,
	[MauSoHD] [nvarchar](250) NULL,
	[KyHieuHD] [nvarchar](250) NULL,
	[NgayHoaDon] [date] NULL,
	[MaDieuKhoan] [int] NULL,
	[SoNgayDuocNo] [float] NULL,
	[HanThanhToan] [date] NULL,
	[TyGia] [float] NULL,
	[TongTienHang] [float] NULL,
	[TienThueGTGT] [float] NULL,
	[TienChietKhau] [float] NULL,
	[TongTienThanhToan] [float] NULL,
	[MaLoaiTien] [int] NULL,
	[MaChungTuBanHang] [nvarchar](50) NULL,
	[MaSoNhanVien] [nvarchar](10) NULL,
 CONSTRAINT [PK_HoaDon_BanHang] PRIMARY KEY CLUSTERED 
(
	[MaHoaDon] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HoanThanhCongViec]    Script Date: 9/3/2020 5:38:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HoanThanhCongViec](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[MaSoNhanVien] [nvarchar](10) NULL,
	[LoaiDanhGia] [nvarchar](250) NULL,
	[NgayBatDau] [date] NULL,
	[NgayKetThuc] [date] NULL,
	[XepLoai] [nvarchar](250) NULL,
 CONSTRAINT [PK_HoanThanhCongViec] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HopDongMua]    Script Date: 9/3/2020 5:38:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HopDongMua](
	[MaHopDongMua] [nvarchar](50) NOT NULL,
	[TrichYeu] [nvarchar](250) NULL,
	[MaNhaCungCap] [nvarchar](6) NULL,
	[MaLoaiTien] [int] NULL,
	[TyGia] [float] NULL,
	[GiaTriHopDong] [nvarchar](250) NULL,
	[NguoiLienHe] [nvarchar](250) NULL,
	[GiaTriHopDongQuyDoi] [nvarchar](250) NULL,
	[HanGiaoHang] [date] NULL,
	[MaTinhTrang] [int] NULL,
	[DiaChiGiaoHang] [nvarchar](250) NULL,
	[GiaTriThanhLy] [nvarchar](250) NULL,
	[GiaTriThanhLyQuyDoi] [nvarchar](250) NULL,
	[HanThanhToan] [date] NULL,
	[NgayThanhLy_HuyBo] [nvarchar](250) NULL,
	[MaSoNhanVien] [nvarchar](10) NULL,
	[LyDo] [nvarchar](250) NULL,
	[DieuKhoanKhac] [nvarchar](250) NULL,
	[LaHopDongPhatSinh] [bit] NULL,
	[TienChietKhau] [float] NULL,
	[TienThueGTGT] [float] NULL,
	[TongTienThanhToan] [float] NULL,
	[NgayKy] [date] NULL,
 CONSTRAINT [PK_HopDongMua] PRIMARY KEY CLUSTERED 
(
	[MaHopDongMua] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KhachHang]    Script Date: 9/3/2020 5:38:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KhachHang](
	[MaKhachHang] [nvarchar](50) NOT NULL,
	[NhomKH_NCC] [nvarchar](250) NULL,
	[PhanLoai] [nvarchar](250) NULL,
	[XungHo] [nvarchar](50) NULL,
	[TenKhachHang] [nvarchar](250) NULL,
	[ChiNhanh] [nvarchar](250) NULL,
	[DiaChi] [nvarchar](250) NULL,
	[SoDienThoai] [nvarchar](250) NULL,
	[Fax] [nvarchar](250) NULL,
	[Email] [nvarchar](250) NULL,
	[Website] [nvarchar](250) NULL,
	[MaSoThue] [nvarchar](250) NULL,
	[SoTaiKhoanNganHang] [nvarchar](250) NULL,
	[TenNganHang] [nvarchar](250) NULL,
	[NguoiLienHe] [nvarchar](250) NULL,
	[DaXoa] [bit] NULL,
	[NguoiXoa] [nvarchar](250) NULL,
	[NgayXoa] [date] NULL,
	[NVBanHang] [nvarchar](10) NULL,
	[DienGiai] [nvarchar](250) NULL,
	[DieuKhoanTT] [nvarchar](50) NULL,
	[SoNgayDuocNo] [float] NULL,
	[SoNoToiDa] [float] NULL,
	[QuocGia] [nvarchar](250) NULL,
	[Quan_Huyen] [nvarchar](250) NULL,
	[Tinh_TP] [nvarchar](250) NULL,
	[Xa_Phuong] [nvarchar](250) NULL,
	[DienThoaiCoDinh_LH] [nvarchar](250) NULL,
	[HoVaTen_LH] [nvarchar](250) NULL,
	[Email_LH] [nvarchar](250) NULL,
	[ChucDanh_LH] [nvarchar](250) NULL,
	[DiaChi_LH] [nvarchar](250) NULL,
	[DTdidong_LH] [nvarchar](250) NULL,
	[DTKhac_LH] [nvarchar](250) NULL,
	[DaiDienTheoPL_LH] [nvarchar](250) NULL,
	[TenNguoiNhan] [nvarchar](250) NULL,
	[DienThoaiNguoiNhan] [nvarchar](250) NULL,
	[DiaChiNguoiNhan] [nvarchar](250) NULL,
	[EmailNguoiNhan] [nvarchar](250) NULL,
	[DiaDiemGiaoHang] [nvarchar](250) NULL,
	[NgayCap] [date] NULL,
	[NoiCap] [nvarchar](250) NULL,
	[CMND] [nvarchar](250) NULL,
 CONSTRAINT [PK_KhachHang] PRIMARY KEY CLUSTERED 
(
	[MaKhachHang] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KhachHang_TaiKhoan]    Script Date: 9/3/2020 5:38:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KhachHang_TaiKhoan](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[MaKhachHang] [nvarchar](50) NOT NULL,
	[MaTaiKhoan] [nvarchar](250) NOT NULL,
	[GhiChu] [nvarchar](250) NULL,
 CONSTRAINT [PK_KhachHang_TaiKhoan] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KhungGio]    Script Date: 9/3/2020 5:38:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KhungGio](
	[MaKhungGio] [int] NOT NULL,
	[MaSoNhanVien] [nvarchar](10) NOT NULL,
	[GioBatDauCaSang] [nchar](10) NULL,
	[GioKetThucCaSang] [nchar](10) NULL,
	[GiobatDauCaChieu] [nchar](10) NULL,
	[GioKetThucCaChieu] [nchar](10) NULL,
	[GioBatDauCaToi] [nchar](10) NULL,
	[GioKetThucCaToi] [nchar](10) NULL,
 CONSTRAINT [PK_KhungGio] PRIMARY KEY CLUSTERED 
(
	[MaKhungGio] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LapRapThaoDo]    Script Date: 9/3/2020 5:38:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LapRapThaoDo](
	[MaLapRapThaoDo] [nvarchar](50) NOT NULL,
	[MaHang] [nvarchar](50) NULL,
	[MaThanhPham] [nvarchar](50) NULL,
	[SoLuong] [int] NULL,
	[Ngay] [date] NULL,
	[DienGiai] [nvarchar](250) NULL,
	[DonGia] [float] NULL,
	[ThanhTien] [float] NULL,
 CONSTRAINT [PK_LapRapThaoDo] PRIMARY KEY CLUSTERED 
(
	[MaLapRapThaoDo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LenhSanXuat]    Script Date: 9/3/2020 5:38:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LenhSanXuat](
	[MaLenhSanXuat] [nvarchar](50) NOT NULL,
	[DienGiai] [nvarchar](250) NULL,
	[Ngay] [date] NULL,
	[MaTinhTrang] [int] NULL,
	[DaGhiSo] [bit] NULL,
 CONSTRAINT [PK_LenhSanXuat] PRIMARY KEY CLUSTERED 
(
	[MaLenhSanXuat] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LenhSanXuat_NVL]    Script Date: 9/3/2020 5:38:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LenhSanXuat_NVL](
	[MaLenhSanXuat_NVL] [int] IDENTITY(1,1) NOT NULL,
	[MaLenhSanXuat] [nvarchar](50) NULL,
	[MaHang] [nvarchar](50) NULL,
	[SoLuong_1DonVi] [int] NULL,
	[SoLuong] [int] NULL,
	[DoiTuongDHCP] [nchar](10) NULL,
	[KhoanMucCP] [nchar](10) NULL,
	[MaThongKe] [nchar](10) NULL,
 CONSTRAINT [PK_LenhSanXuat_NVL] PRIMARY KEY CLUSTERED 
(
	[MaLenhSanXuat_NVL] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LenhSanXuat_ThanhPham]    Script Date: 9/3/2020 5:38:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LenhSanXuat_ThanhPham](
	[MaLenhSanXuat_ThanhPham] [int] IDENTITY(1,1) NOT NULL,
	[MaLenhSanXuat] [nvarchar](50) NULL,
	[SoLuong] [int] NULL,
	[MaThanhPham] [nvarchar](50) NULL,
 CONSTRAINT [PK_LenhSanXuat_ThanhPham] PRIMARY KEY CLUSTERED 
(
	[MaLenhSanXuat_ThanhPham] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LichSuLamViec]    Script Date: 9/3/2020 5:38:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LichSuLamViec](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[MaSoNhanVien] [nvarchar](10) NULL,
	[NgayBatDau] [date] NULL,
	[NgayKetThuc] [date] NULL,
	[TenCongTy] [nvarchar](250) NULL,
	[ViTriLamViec] [nvarchar](100) NULL,
	[NoiDungCongViec] [nvarchar](250) NULL,
 CONSTRAINT [PK_LichSuLamViec] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LoaiChi]    Script Date: 9/3/2020 5:38:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoaiChi](
	[MaLoaiChi] [int] IDENTITY(1,1) NOT NULL,
	[TenLoaiChi] [nvarchar](250) NULL,
	[GhiChu] [nvarchar](250) NULL,
 CONSTRAINT [PK_LoaiChi] PRIMARY KEY CLUSTERED 
(
	[MaLoaiChi] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LoaiCongCuDungCu]    Script Date: 9/3/2020 5:38:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoaiCongCuDungCu](
	[MaLoaiCCDC] [nvarchar](10) NOT NULL,
	[TenLoaiCCDC] [nvarchar](50) NULL,
	[DienGiai] [nvarchar](250) NULL,
	[SoTaiKhoanCo] [nvarchar](250) NULL,
 CONSTRAINT [PK_LoaiCongCuDungCu] PRIMARY KEY CLUSTERED 
(
	[MaLoaiCCDC] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LoaiTaiSanCoDinh]    Script Date: 9/3/2020 5:38:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoaiTaiSanCoDinh](
	[MaLoaiTSCD] [nvarchar](50) NOT NULL,
	[TenLoaiTSCD] [nvarchar](250) NULL,
	[SoTaiKhoanCo] [nvarchar](250) NULL,
	[SoTaiKhoanNo] [nvarchar](250) NULL,
	[Thuoc] [nvarchar](250) NULL,
 CONSTRAINT [PK_LoaiTaiSanCoDinh] PRIMARY KEY CLUSTERED 
(
	[MaLoaiTSCD] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LoaiThu]    Script Date: 9/3/2020 5:38:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoaiThu](
	[MaLoaiThu] [int] IDENTITY(1,1) NOT NULL,
	[TenLoaiThu] [nvarchar](250) NULL,
	[GhiChu] [nvarchar](250) NULL,
 CONSTRAINT [PK_LoaiThu] PRIMARY KEY CLUSTERED 
(
	[MaLoaiThu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LoaiTien]    Script Date: 9/3/2020 5:38:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoaiTien](
	[MaLoaiTien] [int] NOT NULL,
	[TenLoaiTien] [nvarchar](250) NULL,
	[VietTat] [nvarchar](250) NULL,
	[MenhGia] [nvarchar](250) NULL,
	[TyGia_VND] [float] NULL,
 CONSTRAINT [PK_LoaiTien] PRIMARY KEY CLUSTERED 
(
	[MaLoaiTien] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NgonNgu]    Script Date: 9/3/2020 5:38:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NgonNgu](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[MaSoNhanVien] [nvarchar](10) NULL,
	[TenNgonNgu] [nvarchar](250) NULL,
	[Nghe] [nvarchar](50) NULL,
	[Noi] [nvarchar](50) NULL,
	[Doc] [nvarchar](50) NULL,
	[Viet] [nvarchar](50) NULL,
 CONSTRAINT [PK_NgonNgu] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NguoiQuanLy]    Script Date: 9/3/2020 5:38:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NguoiQuanLy](
	[MaSoNhanVien] [nvarchar](10) NOT NULL,
	[QuanLyN1] [nvarchar](10) NOT NULL,
	[QuanLyN2] [nvarchar](10) NOT NULL,
 CONSTRAINT [PK_NguoiQuanLy] PRIMARY KEY CLUSTERED 
(
	[MaSoNhanVien] ASC,
	[QuanLyN1] ASC,
	[QuanLyN2] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NhaCungCap]    Script Date: 9/3/2020 5:38:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhaCungCap](
	[MaNhaCungCap] [nvarchar](6) NOT NULL,
	[NhomKH_NCC] [nvarchar](250) NULL,
	[PhanLoai] [nvarchar](250) NULL,
	[TenNhaCungCap] [nvarchar](250) NULL,
	[ChiNhanh] [nvarchar](250) NULL,
	[DiaChi] [nvarchar](250) NULL,
	[SoDienThoai] [nvarchar](250) NULL,
	[Fax] [nvarchar](250) NULL,
	[Email] [nvarchar](250) NULL,
	[Website] [nvarchar](250) NULL,
	[MaSoThue] [nvarchar](250) NULL,
	[SoTaiKhoanNganHang] [nvarchar](250) NULL,
	[TenNganHang] [nvarchar](250) NULL,
	[NguoiLienHe] [nvarchar](250) NULL,
	[DaXoa] [bit] NULL,
	[NguoiXoa] [nvarchar](250) NULL,
	[NgayXoa] [date] NULL,
	[XungHo] [nvarchar](50) NULL,
	[NVBanHang] [nvarchar](10) NULL,
	[DienGiai] [nvarchar](250) NULL,
	[DieuKhoanTT] [nvarchar](50) NULL,
	[SoNgayDuocNo] [float] NULL,
	[SoNoToiDa] [float] NULL,
	[QuocGia] [nvarchar](250) NULL,
	[Quan_Huyen] [nvarchar](250) NULL,
	[Tinh_TP] [nvarchar](250) NULL,
	[Xa_Phuong] [nvarchar](250) NULL,
	[DienThoaiCoDinh_LH] [nvarchar](250) NULL,
	[HoVaTen_LH] [nvarchar](250) NULL,
	[Email_LH] [nvarchar](250) NULL,
	[ChucDanh_LH] [nvarchar](250) NULL,
	[DiaChi_LH] [nvarchar](250) NULL,
	[DTdidong_LH] [nvarchar](250) NULL,
	[DTKhac_LH] [nvarchar](250) NULL,
	[DaiDienTheoPL_LH] [nvarchar](250) NULL,
	[TenNguoiNhan] [nvarchar](250) NULL,
	[DienThoaiNguoiNhan] [nvarchar](250) NULL,
	[DiaChiNguoiNhan] [nvarchar](250) NULL,
	[EmailNguoiNhan] [nvarchar](250) NULL,
	[DiaDiemGiaoHang] [nvarchar](250) NULL,
	[NgayCap] [date] NULL,
	[NoiCap] [nvarchar](250) NULL,
	[CMND] [nvarchar](250) NULL,
 CONSTRAINT [PK_NhaCungCap] PRIMARY KEY CLUSTERED 
(
	[MaNhaCungCap] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NhaCungCap_TaiKhoan]    Script Date: 9/3/2020 5:38:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhaCungCap_TaiKhoan](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[MaNhaCungCap] [nvarchar](6) NOT NULL,
	[MaTaiKhoan] [nvarchar](250) NOT NULL,
	[GhiChu] [nvarchar](250) NULL,
 CONSTRAINT [PK_NhaCungCap_TaiKhoan] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NhanVien]    Script Date: 9/3/2020 5:38:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhanVien](
	[MaSoNhanVien] [nvarchar](10) NOT NULL,
	[HoVaTen] [nvarchar](250) NULL,
	[GioiTinh] [nvarchar](50) NULL,
	[SoCMND] [nvarchar](20) NULL,
	[NgayCapCMND] [date] NULL,
	[NoiCapCMND] [nvarchar](250) NULL,
	[NgaySinh] [date] NULL,
	[TinhTrangHonNhan] [nvarchar](250) NULL,
	[QuocTich] [nvarchar](50) NULL,
	[DiaChi] [nvarchar](250) NULL,
	[SoDienThoai] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[HoTenLienHeKhanCap] [nvarchar](250) NULL,
	[QuanHeLienHeKhanCap] [nvarchar](100) NULL,
	[DiaChiLienHeKhanCap] [nvarchar](250) NULL,
	[SDTLienHeKhanCap] [nvarchar](50) NULL,
	[Hinh] [nvarchar](250) NULL,
	[Bac] [int] NULL,
	[TrangThai] [nvarchar](250) NULL,
	[MaCoSo] [nvarchar](10) NULL,
	[MaChucVu] [nvarchar](2) NULL,
	[MaSoThue] [nvarchar](250) NULL,
	[SoTaiKhoanNganHang] [nvarchar](250) NULL,
	[TenNganHang] [nvarchar](250) NULL,
	[ChiNhanh] [nvarchar](250) NULL,
	[MaDonVi] [nvarchar](50) NULL,
 CONSTRAINT [PK_NhanVien] PRIMARY KEY CLUSTERED 
(
	[MaSoNhanVien] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NhomHangHoa]    Script Date: 9/3/2020 5:38:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhomHangHoa](
	[MaNhomHH] [int] IDENTITY(1,1) NOT NULL,
	[TenNhom] [nvarchar](250) NULL,
	[GhiChu] [nvarchar](250) NULL,
 CONSTRAINT [PK_NhomHangHoa] PRIMARY KEY CLUSTERED 
(
	[MaNhomHH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NhomKH_NCC]    Script Date: 9/3/2020 5:38:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhomKH_NCC](
	[NhomKH_NCC] [nvarchar](250) NOT NULL,
	[TenNhomKH_NCC] [nvarchar](250) NULL,
	[DienGiai] [nvarchar](250) NULL,
 CONSTRAINT [PK_NhomKH_NCC] PRIMARY KEY CLUSTERED 
(
	[NhomKH_NCC] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PhieuChi]    Script Date: 9/3/2020 5:38:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhieuChi](
	[MaPhieuChi] [nvarchar](50) NOT NULL,
	[MaSoNhanVien] [nvarchar](10) NULL,
	[MaNhaCungCap] [nvarchar](6) NULL,
	[MaLoaiChi] [int] NULL,
	[MaTinhTrang] [int] NULL,
	[LyDoChi] [nvarchar](250) NULL,
	[DienGiai] [nvarchar](250) NULL,
	[NgayHoachToan] [date] NULL,
	[NgayChungTu] [date] NULL,
	[TongTienDichVu] [float] NULL,
	[TienChietKhau] [float] NULL,
	[TienThueGTGT] [float] NULL,
	[TongTienThanhToan] [float] NULL,
	[ChungTuGoc] [int] NULL,
	[MaLoaiTien] [int] NULL,
	[TyGia] [float] NULL,
	[NguoiNop] [nvarchar](50) NULL,
	[DaGhiSo] [bit] NULL,
 CONSTRAINT [PK_PhieuChi] PRIMARY KEY CLUSTERED 
(
	[MaPhieuChi] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PhieuNhapKho]    Script Date: 9/3/2020 5:38:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhieuNhapKho](
	[MaPhieuNhapKho] [nvarchar](50) NOT NULL,
	[MaKhachHang] [nvarchar](50) NULL,
	[NguoiGiaoHang] [nvarchar](250) NULL,
	[DienGiai] [nvarchar](250) NULL,
	[ChungTuGoc] [int] NULL,
	[NgayHoachToan] [date] NULL,
	[NgayChungTu] [date] NULL,
	[ChungTuThamChieu] [nvarchar](50) NULL,
	[LyDoNhap] [nvarchar](250) NULL,
	[TongTienThanhToan] [float] NULL,
	[DaGhiSo] [bit] NULL,
 CONSTRAINT [PK_PhieuNhapKho] PRIMARY KEY CLUSTERED 
(
	[MaPhieuNhapKho] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PhieuThu]    Script Date: 9/3/2020 5:38:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhieuThu](
	[MaPhieuThu] [nvarchar](50) NOT NULL,
	[MaKhachHang] [nvarchar](50) NULL,
	[MaSoNhanVien] [nvarchar](10) NULL,
	[MaLoaiThu] [int] NULL,
	[MaTinhTrang] [int] NULL,
	[LyDoNop] [nvarchar](50) NULL,
	[DienGiai] [nvarchar](250) NULL,
	[NgayHoachToan] [date] NULL,
	[NgayChungTu] [date] NULL,
	[TongTienHang] [float] NULL,
	[TienChietKhau] [float] NULL,
	[TienThueGTGT] [float] NULL,
	[TongTienThanhToan] [float] NULL,
	[DaGhiSo] [bit] NULL,
	[ChungTuGoc] [int] NULL,
	[MaLoaiTien] [int] NULL,
	[TyGia] [float] NULL,
	[ChungTuThamChieu] [nchar](10) NULL,
	[NguoiNop] [nvarchar](50) NULL,
 CONSTRAINT [PK_PhieuThu] PRIMARY KEY CLUSTERED 
(
	[MaPhieuThu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PhieuXuatKho]    Script Date: 9/3/2020 5:38:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhieuXuatKho](
	[MaPhieuXuat] [nvarchar](50) NOT NULL,
	[MaKhachHang] [nvarchar](50) NULL,
	[NguoiNhan] [nvarchar](250) NULL,
	[LyDoXuat] [nvarchar](250) NULL,
	[MaSoNhanVien] [nvarchar](10) NULL,
	[ChungTuGoc] [int] NULL,
	[NgayHoachToan] [date] NULL,
	[NgayChungTu] [date] NULL,
	[MaDieuKhoan] [int] NULL,
	[SoNgayDuocNo] [float] NULL,
	[HanThanhToan] [date] NULL,
	[MaLoaiTien] [int] NULL,
	[TyGia] [float] NULL,
	[TongTienHang] [float] NULL,
	[TienThueGTGT] [float] NULL,
	[TienChietKhau] [float] NULL,
	[TongTienThanhToan] [float] NULL,
	[MaChungTuBanHang] [nvarchar](50) NULL,
	[MaTraLaiHangBan] [nvarchar](50) NULL,
	[DienGiai] [nvarchar](250) NULL,
	[DaGhiSo] [bit] NULL,
	[Kho] [nchar](10) NULL,
 CONSTRAINT [PK_PhieuXuat_BanHang] PRIMARY KEY CLUSTERED 
(
	[MaPhieuXuat] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[QuanLyCongTac]    Script Date: 9/3/2020 5:38:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QuanLyCongTac](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[MaSoNhanVien] [nvarchar](10) NULL,
	[GioBatDau] [nvarchar](50) NULL,
	[NgayBatDau] [date] NULL,
	[GioKetThuc] [nvarchar](50) NULL,
	[NgayKetThuc] [date] NULL,
	[TongGio] [int] NULL,
	[TongNgayLamViec] [int] NULL,
	[TongNgay] [int] NULL,
	[DiaDiem] [nvarchar](250) NULL,
	[NoiDung] [nvarchar](250) NULL,
 CONSTRAINT [PK_QuanLyCongTac] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[QuanLyNgayNghi]    Script Date: 9/3/2020 5:38:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QuanLyNgayNghi](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[MaSoNhanVien] [nvarchar](10) NULL,
	[GioBatDau] [nvarchar](50) NULL,
	[NgayBatDau] [date] NULL,
	[GioKetThuc] [nvarchar](50) NULL,
	[NgayKetThuc] [date] NULL,
	[LoaiNghi] [nvarchar](100) NULL,
	[TongGio] [int] NULL,
	[TongNgayLamViecNghi] [int] NULL,
	[TongNgayNghi] [int] NULL,
 CONSTRAINT [PK_QuanLyNgayNghi] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[QuanLyQuaGio]    Script Date: 9/3/2020 5:38:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QuanLyQuaGio](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[MaSoNhanVien] [nvarchar](10) NOT NULL,
	[SoGio] [int] NULL,
	[PhanLoai] [nvarchar](250) NULL,
 CONSTRAINT [PK_QuanLyQuaGio_1] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[QuanLyTaiSan]    Script Date: 9/3/2020 5:38:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QuanLyTaiSan](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[MaSoNhanVien] [nvarchar](10) NULL,
	[MaTaiSan] [nvarchar](10) NULL,
 CONSTRAINT [PK_QuanLyTaiSan] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[QuanLyVangMat]    Script Date: 9/3/2020 5:38:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QuanLyVangMat](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[MaSoNhanVien] [nvarchar](10) NULL,
	[NgayVangMat] [date] NULL,
	[GioVao] [nvarchar](50) NULL,
	[GioRa] [nvarchar](50) NULL,
	[TrangThai] [nvarchar](50) NULL,
 CONSTRAINT [PK_QuanLyVangMat] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[QuaTrinhDaoTao]    Script Date: 9/3/2020 5:38:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QuaTrinhDaoTao](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[MaSoNhanVien] [nvarchar](10) NULL,
	[NgayBatDau] [date] NULL,
	[NgayKetThuc] [date] NULL,
	[TenTruong] [nvarchar](250) NULL,
	[LoaiBang] [nvarchar](100) NULL,
	[ChuyenNganh] [nvarchar](100) NULL,
	[XepLoai] [nvarchar](50) NULL,
 CONSTRAINT [PK_QuaTrinhDaoTao] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[QuetThe]    Script Date: 9/3/2020 5:38:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QuetThe](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[MaSoNhanVien] [nvarchar](10) NULL,
	[GioQuetThe] [nvarchar](10) NULL,
	[NgayQuetThe] [date] NULL,
 CONSTRAINT [PK_QuetThe] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[QuetTheTheoNgay]    Script Date: 9/3/2020 5:38:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QuetTheTheoNgay](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[MaSoNhanVien] [nvarchar](10) NULL,
	[GioQuetThe] [nvarchar](10) NULL,
	[NgayQuetThe] [date] NULL,
 CONSTRAINT [PK_QuetTheTheoNgay] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TaiKhoanCo]    Script Date: 9/3/2020 5:38:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TaiKhoanCo](
	[SoTaiKhoanCo] [nvarchar](250) NOT NULL,
	[TenTaiKhoan] [nvarchar](250) NULL,
 CONSTRAINT [PK_TaiKhoanCo] PRIMARY KEY CLUSTERED 
(
	[SoTaiKhoanCo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TaiKhoanKetChuyen]    Script Date: 9/3/2020 5:38:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TaiKhoanKetChuyen](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ThuTuKetChuyen] [int] NULL,
	[MaKetChuyen] [nvarchar](50) NULL,
	[KetChuyenTu] [nvarchar](50) NULL,
	[KetChuyenDen] [nvarchar](50) NULL,
	[BenKetChuyen] [nvarchar](50) NULL,
	[DienGiai] [nvarchar](250) NULL,
	[LoaiKetChuyen] [nvarchar](250) NULL,
	[NgungTheoDoi] [bit] NULL,
 CONSTRAINT [PK_TaiKhoanKetChuyen] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TaiKhoanNganHang]    Script Date: 9/3/2020 5:38:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TaiKhoanNganHang](
	[MaTaiKhoan] [nvarchar](250) NOT NULL,
	[TenNganHang] [nvarchar](250) NULL,
	[ChiNhanh] [nvarchar](250) NULL,
	[TinhTP] [nvarchar](250) NULL,
 CONSTRAINT [PK_TaiKhoanNganHang] PRIMARY KEY CLUSTERED 
(
	[MaTaiKhoan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TaiKhoanNo]    Script Date: 9/3/2020 5:38:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TaiKhoanNo](
	[SoTaiKhoanNo] [nvarchar](250) NOT NULL,
	[TenTaiKhoan] [nvarchar](250) NULL,
 CONSTRAINT [PK_TaiKhoanNo] PRIMARY KEY CLUSTERED 
(
	[SoTaiKhoanNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TaiSan]    Script Date: 9/3/2020 5:38:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TaiSan](
	[MaTaiSan] [nvarchar](10) NOT NULL,
	[NgayNhap] [date] NULL,
	[NgayBatDauSuDung] [date] NULL,
	[NgayHetHan] [date] NULL,
	[MaCoSo] [nvarchar](10) NULL,
	[KieuTaiSan] [nvarchar](250) NULL,
	[MoTaChiTiet] [nvarchar](250) NULL,
	[TinhTrang] [nvarchar](250) NULL,
	[NgayNhapLieu] [date] NULL,
	[NguoiNhap] [nvarchar](250) NULL,
 CONSTRAINT [PK_TaiSan] PRIMARY KEY CLUSTERED 
(
	[MaTaiSan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ThanhPham]    Script Date: 9/3/2020 5:38:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ThanhPham](
	[MaThanhPham] [nvarchar](50) NOT NULL,
	[TenThanhPham] [nvarchar](250) NULL,
	[DonViTinh] [nvarchar](250) NULL,
	[HopDongBan] [nvarchar](250) NULL,
	[DoiTuongDHCP] [nvarchar](250) NULL,
	[MaThongKe] [nvarchar](250) NULL,
	[DonDatHang] [nvarchar](250) NULL,
 CONSTRAINT [PK_ThanhPham] PRIMARY KEY CLUSTERED 
(
	[MaThanhPham] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[The]    Script Date: 9/3/2020 5:38:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[The](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[MaSoNhanVien] [nvarchar](10) NULL,
	[MaThe] [nvarchar](250) NULL,
	[LoaiThe] [nvarchar](250) NULL,
	[NgayYeuCau] [date] NULL,
	[NgayCap] [date] NULL,
	[NgayHetHan] [date] NULL,
	[TrangThai] [nvarchar](250) NULL,
 CONSTRAINT [PK_The] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ThongBao]    Script Date: 9/3/2020 5:38:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ThongBao](
	[MaSoTB] [bigint] NOT NULL,
	[TieuDe] [nvarchar](100) NULL,
	[NoiDung] [nvarchar](max) NULL,
	[GhiChu] [nvarchar](100) NULL,
	[NgayTao] [datetime] NULL,
	[NgayThongBao] [datetime] NULL,
	[DaXoa] [bit] NULL,
	[NguoiXoa] [nvarchar](100) NULL,
	[ThoiGianXoa] [datetime] NULL,
 CONSTRAINT [PK_ThongBao] PRIMARY KEY CLUSTERED 
(
	[MaSoTB] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ThongTinCaNhan]    Script Date: 9/3/2020 5:38:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ThongTinCaNhan](
	[MaSoVC] [nvarchar](50) NOT NULL,
	[HoTen] [nvarchar](250) NULL,
	[NgaySinh] [date] NULL,
	[DiaChi] [nvarchar](250) NULL,
	[DienThoai] [nvarchar](50) NULL,
	[Email] [nvarchar](250) NULL,
	[NghiViec] [bit] NULL,
	[DaXoa] [bit] NULL,
	[NguoiXoa] [nvarchar](100) NULL,
	[ThoiGianXoa] [datetime] NULL,
	[MaPK] [nvarchar](50) NULL,
	[Phai] [nvarchar](10) NULL,
	[SHCC] [nchar](10) NULL,
	[CMND] [nvarchar](20) NULL,
	[NgayCap] [date] NULL,
	[NoiCap] [nvarchar](50) NULL,
	[MST] [nchar](10) NULL,
	[QuocTich] [nvarchar](50) NULL,
	[DanToc] [nvarchar](50) NULL,
	[SoTaiKhoan] [nvarchar](50) NULL,
	[NganHang] [nvarchar](50) NULL,
	[ChiNhanh] [nvarchar](100) NULL,
	[ChucVu] [nvarchar](50) NULL,
	[CQCongTac] [nvarchar](50) NULL,
	[DiaChiCQ] [nvarchar](50) NULL,
	[WebsiteCQ] [nvarchar](50) NULL,
	[LanhDaoCQ] [nvarchar](50) NULL,
	[DienThoaiCQ] [nvarchar](50) NULL,
	[DienThoaiLanhDao] [nvarchar](50) NULL,
	[NamBatDauCongTac] [date] NULL,
	[NamNghiHuu] [date] NULL,
	[HocVu] [nvarchar](50) NULL,
	[NamDat] [nvarchar](10) NULL,
	[NuocTotNghiep] [nvarchar](50) NULL,
	[ChuyenNganh] [nvarchar](50) NULL,
	[ChuyenMonHienTai] [nvarchar](50) NULL,
	[HocHam] [nvarchar](50) NULL,
	[NamCongNhan] [nvarchar](10) NULL,
	[ChucDanh] [nvarchar](50) NULL,
	[Hinh] [nvarchar](250) NULL,
 CONSTRAINT [PK_VienChuc_1] PRIMARY KEY CLUSTERED 
(
	[MaSoVC] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ThongTinTuyenDung]    Script Date: 9/3/2020 5:38:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ThongTinTuyenDung](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[MaSoNhanVien] [nvarchar](10) NULL,
	[NgayTuyen] [date] NULL,
	[LoaiHopDong] [nvarchar](250) NULL,
	[DiaDiemLamViec] [nvarchar](250) NULL,
	[NgayBatDau] [date] NULL,
	[NgayKetThuc] [date] NULL,
	[HinhThucLuong] [nvarchar](250) NULL,
	[SoTienLuong] [nvarchar](250) NULL,
 CONSTRAINT [PK_ThongTinTuyenDung] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TinhChatHangHoa]    Script Date: 9/3/2020 5:38:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TinhChatHangHoa](
	[MaTinhChat] [int] IDENTITY(1,1) NOT NULL,
	[TenTinhChat] [nvarchar](250) NULL,
	[GhiChu] [nvarchar](250) NULL,
 CONSTRAINT [PK_TinhChatHangHoa] PRIMARY KEY CLUSTERED 
(
	[MaTinhChat] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TinhTrang]    Script Date: 9/3/2020 5:38:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TinhTrang](
	[MaTinhTrang] [int] IDENTITY(1,1) NOT NULL,
	[TenTinhTrang] [nvarchar](250) NULL,
	[GhiChu] [nvarchar](250) NULL,
 CONSTRAINT [PK_TinhTrang] PRIMARY KEY CLUSTERED 
(
	[MaTinhTrang] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TraLaiHangBan]    Script Date: 9/3/2020 5:38:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TraLaiHangBan](
	[MaTraLaiHangBan] [nvarchar](50) NOT NULL,
	[MaKhachHang] [nvarchar](50) NULL,
	[DienGiai] [nvarchar](250) NULL,
	[MaSoNhanVien] [nvarchar](10) NULL,
	[MaLoaiTien] [int] NULL,
	[NgayHoachToan] [date] NULL,
	[NgayChungTu] [date] NULL,
	[TyGia] [float] NULL,
	[TongTienHang] [float] NULL,
	[TienThueGTGT] [float] NULL,
	[TienChietKhau] [float] NULL,
	[TongTienThanhToan] [float] NULL,
	[DaGhiSo] [bit] NULL,
 CONSTRAINT [PK_TraLaiHangBan] PRIMARY KEY CLUSTERED 
(
	[MaTraLaiHangBan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TraLaiHangMua]    Script Date: 9/3/2020 5:38:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TraLaiHangMua](
	[MaTraLaiHangMua] [nvarchar](50) NOT NULL,
	[MaNhaCungCap] [nvarchar](6) NULL,
	[NguoiNhanHang] [nvarchar](250) NULL,
	[DienGiai] [nvarchar](250) NULL,
	[MaSoNhanVien] [nvarchar](10) NULL,
	[ChungTuGoc] [int] NULL,
	[MaLoaiTien] [int] NULL,
	[TyGia] [float] NULL,
	[NgayHoachToan] [date] NULL,
	[NgayChungTu] [date] NULL,
	[TongTienHang] [float] NULL,
	[TienThueGTGT] [float] NULL,
	[TongTienThanhToan] [float] NULL,
	[DaGhiSo] [bit] NULL,
 CONSTRAINT [PK_TraLaiHangMua] PRIMARY KEY CLUSTERED 
(
	[MaTraLaiHangMua] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[ApplicationGroups] ON 

INSERT [dbo].[ApplicationGroups] ([ID], [Name], [Description]) VALUES (1, N'Admin', N'Ban quản trị')
INSERT [dbo].[ApplicationGroups] ([ID], [Name], [Description]) VALUES (6, N'NhanVien', NULL)
INSERT [dbo].[ApplicationGroups] ([ID], [Name], [Description]) VALUES (7, N'QuanLy', NULL)
INSERT [dbo].[ApplicationGroups] ([ID], [Name], [Description]) VALUES (8, N'QuanLySeo', NULL)
INSERT [dbo].[ApplicationGroups] ([ID], [Name], [Description]) VALUES (9, N'TongGiamDoc1', NULL)
INSERT [dbo].[ApplicationGroups] ([ID], [Name], [Description]) VALUES (10, N'TongGiamDoc2', NULL)
INSERT [dbo].[ApplicationGroups] ([ID], [Name], [Description]) VALUES (11, N'Bán hàng', NULL)
INSERT [dbo].[ApplicationGroups] ([ID], [Name], [Description]) VALUES (12, N'Quản lý cửa hàng', NULL)
SET IDENTITY_INSERT [dbo].[ApplicationGroups] OFF
INSERT [dbo].[ApplicationRoleGroups] ([GroupId], [RoleId], [Note]) VALUES (1, N'03c68f75-97fe-416b-af31-7019240c7c3e', NULL)
INSERT [dbo].[ApplicationRoleGroups] ([GroupId], [RoleId], [Note]) VALUES (1, N'07be8b35-688a-4456-a43c-2c1c9feeede0', NULL)
INSERT [dbo].[ApplicationRoleGroups] ([GroupId], [RoleId], [Note]) VALUES (1, N'2ddded44-f75a-4e30-94c1-b558eee85150', NULL)
INSERT [dbo].[ApplicationRoleGroups] ([GroupId], [RoleId], [Note]) VALUES (1, N'33764621-b1f5-498e-92af-79e46675f4cc', NULL)
INSERT [dbo].[ApplicationRoleGroups] ([GroupId], [RoleId], [Note]) VALUES (1, N'3a0ec146-a428-423c-896d-bea8ea18e1d0', NULL)
INSERT [dbo].[ApplicationRoleGroups] ([GroupId], [RoleId], [Note]) VALUES (1, N'4173d74e-e3e2-4448-a648-12c88d5d4520', NULL)
INSERT [dbo].[ApplicationRoleGroups] ([GroupId], [RoleId], [Note]) VALUES (1, N'4a056641-22a4-4a3a-9f6c-23405a17a6c2', NULL)
INSERT [dbo].[ApplicationRoleGroups] ([GroupId], [RoleId], [Note]) VALUES (1, N'4c940bc9-0d22-4d0b-8f4e-58a37a925cd4', NULL)
INSERT [dbo].[ApplicationRoleGroups] ([GroupId], [RoleId], [Note]) VALUES (1, N'838cd2db-f5e3-4981-9999-c5489a145263', NULL)
INSERT [dbo].[ApplicationRoleGroups] ([GroupId], [RoleId], [Note]) VALUES (1, N'8747cd30-dc6a-4ac9-86dc-593655365122', NULL)
INSERT [dbo].[ApplicationRoleGroups] ([GroupId], [RoleId], [Note]) VALUES (1, N'abee49e4-bb3e-4aeb-96f7-171de1d83081', NULL)
INSERT [dbo].[ApplicationRoleGroups] ([GroupId], [RoleId], [Note]) VALUES (1, N'c427bb1f-4806-4131-b01b-3eecefb49400', NULL)
INSERT [dbo].[ApplicationRoleGroups] ([GroupId], [RoleId], [Note]) VALUES (1, N'c4353d29-f39c-4859-8949-d44315e74e56', NULL)
INSERT [dbo].[ApplicationRoleGroups] ([GroupId], [RoleId], [Note]) VALUES (1, N'c723ce89-e509-4f5a-8273-685f3c14c3b2', NULL)
INSERT [dbo].[ApplicationRoleGroups] ([GroupId], [RoleId], [Note]) VALUES (1, N'c900368b-e966-4a23-9723-723695a67cac', NULL)
INSERT [dbo].[ApplicationRoleGroups] ([GroupId], [RoleId], [Note]) VALUES (1, N'e9c55747-6019-488d-860f-6a36350537f1', NULL)
INSERT [dbo].[ApplicationRoleGroups] ([GroupId], [RoleId], [Note]) VALUES (1, N'f7548b8f-3c2d-48a3-a5d5-b573b177b0ed', NULL)
INSERT [dbo].[ApplicationRoleGroups] ([GroupId], [RoleId], [Note]) VALUES (1, N'fb0e2107-dcf3-48b3-9f2c-b6710dcdcd3c', NULL)
INSERT [dbo].[ApplicationRoleGroups] ([GroupId], [RoleId], [Note]) VALUES (6, N'2ddded44-f75a-4e30-94c1-b558eee85150', NULL)
INSERT [dbo].[ApplicationRoleGroups] ([GroupId], [RoleId], [Note]) VALUES (6, N'4c940bc9-0d22-4d0b-8f4e-58a37a925cd4', NULL)
INSERT [dbo].[ApplicationRoleGroups] ([GroupId], [RoleId], [Note]) VALUES (7, N'03c68f75-97fe-416b-af31-7019240c7c3e', NULL)
INSERT [dbo].[ApplicationRoleGroups] ([GroupId], [RoleId], [Note]) VALUES (7, N'2ddded44-f75a-4e30-94c1-b558eee85150', NULL)
INSERT [dbo].[ApplicationRoleGroups] ([GroupId], [RoleId], [Note]) VALUES (7, N'4a056641-22a4-4a3a-9f6c-23405a17a6c2', NULL)
INSERT [dbo].[ApplicationRoleGroups] ([GroupId], [RoleId], [Note]) VALUES (7, N'8747cd30-dc6a-4ac9-86dc-593655365122', NULL)
INSERT [dbo].[ApplicationRoleGroups] ([GroupId], [RoleId], [Note]) VALUES (7, N'c427bb1f-4806-4131-b01b-3eecefb49400', NULL)
INSERT [dbo].[ApplicationRoleGroups] ([GroupId], [RoleId], [Note]) VALUES (7, N'c4353d29-f39c-4859-8949-d44315e74e56', NULL)
INSERT [dbo].[ApplicationRoleGroups] ([GroupId], [RoleId], [Note]) VALUES (7, N'fb0e2107-dcf3-48b3-9f2c-b6710dcdcd3c', NULL)
INSERT [dbo].[ApplicationRoleGroups] ([GroupId], [RoleId], [Note]) VALUES (8, N'2ddded44-f75a-4e30-94c1-b558eee85150', NULL)
INSERT [dbo].[ApplicationRoleGroups] ([GroupId], [RoleId], [Note]) VALUES (8, N'c427bb1f-4806-4131-b01b-3eecefb49400', NULL)
INSERT [dbo].[ApplicationRoleGroups] ([GroupId], [RoleId], [Note]) VALUES (9, N'03c68f75-97fe-416b-af31-7019240c7c3e', NULL)
INSERT [dbo].[ApplicationRoleGroups] ([GroupId], [RoleId], [Note]) VALUES (9, N'0765f36e-4b97-4564-b6ac-0171e7ed4382', NULL)
INSERT [dbo].[ApplicationRoleGroups] ([GroupId], [RoleId], [Note]) VALUES (9, N'095dd76b-f3a2-4eb9-95b4-98591d803fff', NULL)
INSERT [dbo].[ApplicationRoleGroups] ([GroupId], [RoleId], [Note]) VALUES (9, N'0db0f35c-1ba7-4e3d-ba4b-3540d67708c8', NULL)
INSERT [dbo].[ApplicationRoleGroups] ([GroupId], [RoleId], [Note]) VALUES (9, N'2ddded44-f75a-4e30-94c1-b558eee85150', NULL)
INSERT [dbo].[ApplicationRoleGroups] ([GroupId], [RoleId], [Note]) VALUES (9, N'33764621-b1f5-498e-92af-79e46675f4cc', NULL)
INSERT [dbo].[ApplicationRoleGroups] ([GroupId], [RoleId], [Note]) VALUES (9, N'36206a07-6025-4492-b210-d15f8571075e', NULL)
INSERT [dbo].[ApplicationRoleGroups] ([GroupId], [RoleId], [Note]) VALUES (9, N'3a0ec146-a428-423c-896d-bea8ea18e1d0', NULL)
INSERT [dbo].[ApplicationRoleGroups] ([GroupId], [RoleId], [Note]) VALUES (9, N'4a056641-22a4-4a3a-9f6c-23405a17a6c2', NULL)
INSERT [dbo].[ApplicationRoleGroups] ([GroupId], [RoleId], [Note]) VALUES (9, N'535939b8-f52b-4846-b95b-645a6729c0da', NULL)
INSERT [dbo].[ApplicationRoleGroups] ([GroupId], [RoleId], [Note]) VALUES (9, N'838cd2db-f5e3-4981-9999-c5489a145263', NULL)
INSERT [dbo].[ApplicationRoleGroups] ([GroupId], [RoleId], [Note]) VALUES (9, N'8747cd30-dc6a-4ac9-86dc-593655365122', NULL)
INSERT [dbo].[ApplicationRoleGroups] ([GroupId], [RoleId], [Note]) VALUES (9, N'c427bb1f-4806-4131-b01b-3eecefb49400', NULL)
INSERT [dbo].[ApplicationRoleGroups] ([GroupId], [RoleId], [Note]) VALUES (9, N'c4353d29-f39c-4859-8949-d44315e74e56', NULL)
INSERT [dbo].[ApplicationRoleGroups] ([GroupId], [RoleId], [Note]) VALUES (9, N'c723ce89-e509-4f5a-8273-685f3c14c3b2', NULL)
INSERT [dbo].[ApplicationRoleGroups] ([GroupId], [RoleId], [Note]) VALUES (9, N'c900368b-e966-4a23-9723-723695a67cac', NULL)
INSERT [dbo].[ApplicationRoleGroups] ([GroupId], [RoleId], [Note]) VALUES (9, N'e9c55747-6019-488d-860f-6a36350537f1', NULL)
INSERT [dbo].[ApplicationRoleGroups] ([GroupId], [RoleId], [Note]) VALUES (9, N'f7548b8f-3c2d-48a3-a5d5-b573b177b0ed', NULL)
INSERT [dbo].[ApplicationRoleGroups] ([GroupId], [RoleId], [Note]) VALUES (9, N'fb0e2107-dcf3-48b3-9f2c-b6710dcdcd3c', NULL)
INSERT [dbo].[ApplicationRoleGroups] ([GroupId], [RoleId], [Note]) VALUES (10, N'03c68f75-97fe-416b-af31-7019240c7c3e', NULL)
INSERT [dbo].[ApplicationRoleGroups] ([GroupId], [RoleId], [Note]) VALUES (10, N'2ddded44-f75a-4e30-94c1-b558eee85150', NULL)
INSERT [dbo].[ApplicationRoleGroups] ([GroupId], [RoleId], [Note]) VALUES (10, N'33764621-b1f5-498e-92af-79e46675f4cc', NULL)
INSERT [dbo].[ApplicationRoleGroups] ([GroupId], [RoleId], [Note]) VALUES (10, N'3a0ec146-a428-423c-896d-bea8ea18e1d0', NULL)
INSERT [dbo].[ApplicationRoleGroups] ([GroupId], [RoleId], [Note]) VALUES (10, N'4a056641-22a4-4a3a-9f6c-23405a17a6c2', NULL)
INSERT [dbo].[ApplicationRoleGroups] ([GroupId], [RoleId], [Note]) VALUES (10, N'838cd2db-f5e3-4981-9999-c5489a145263', NULL)
INSERT [dbo].[ApplicationRoleGroups] ([GroupId], [RoleId], [Note]) VALUES (10, N'8747cd30-dc6a-4ac9-86dc-593655365122', NULL)
INSERT [dbo].[ApplicationRoleGroups] ([GroupId], [RoleId], [Note]) VALUES (10, N'c427bb1f-4806-4131-b01b-3eecefb49400', NULL)
INSERT [dbo].[ApplicationRoleGroups] ([GroupId], [RoleId], [Note]) VALUES (10, N'c4353d29-f39c-4859-8949-d44315e74e56', NULL)
INSERT [dbo].[ApplicationRoleGroups] ([GroupId], [RoleId], [Note]) VALUES (10, N'c723ce89-e509-4f5a-8273-685f3c14c3b2', NULL)
INSERT [dbo].[ApplicationRoleGroups] ([GroupId], [RoleId], [Note]) VALUES (10, N'e9c55747-6019-488d-860f-6a36350537f1', NULL)
INSERT [dbo].[ApplicationRoleGroups] ([GroupId], [RoleId], [Note]) VALUES (10, N'fb0e2107-dcf3-48b3-9f2c-b6710dcdcd3c', NULL)
INSERT [dbo].[ApplicationRoleGroups] ([GroupId], [RoleId], [Note]) VALUES (11, N'0db0f35c-1ba7-4e3d-ba4b-3540d67708c8', NULL)
INSERT [dbo].[ApplicationRoleGroups] ([GroupId], [RoleId], [Note]) VALUES (12, N'095dd76b-f3a2-4eb9-95b4-98591d803fff', NULL)
INSERT [dbo].[ApplicationRoles] ([Id], [Name], [Description], [Discriminator]) VALUES (N'03c68f75-97fe-416b-af31-7019240c7c3e', N'QuanLyKhachHang', N'Quản lý khách hàng', N'ApplicationRole')
INSERT [dbo].[ApplicationRoles] ([Id], [Name], [Description], [Discriminator]) VALUES (N'0765f36e-4b97-4564-b6ac-0171e7ed4382', N'TongQuan', N'Tổng quan', N'ApplicationRole')
INSERT [dbo].[ApplicationRoles] ([Id], [Name], [Description], [Discriminator]) VALUES (N'07be8b35-688a-4456-a43c-2c1c9feeede0', N'NguoiDung', N'Người dùng', N'ApplicationRole')
INSERT [dbo].[ApplicationRoles] ([Id], [Name], [Description], [Discriminator]) VALUES (N'095dd76b-f3a2-4eb9-95b4-98591d803fff', N'QuanLyCuaHang', N'Quản lý cửa hàng', N'ApplicationRole')
INSERT [dbo].[ApplicationRoles] ([Id], [Name], [Description], [Discriminator]) VALUES (N'0db0f35c-1ba7-4e3d-ba4b-3540d67708c8', N'BanHang', N'Bán hàng', N'ApplicationRole')
INSERT [dbo].[ApplicationRoles] ([Id], [Name], [Description], [Discriminator]) VALUES (N'2ddded44-f75a-4e30-94c1-b558eee85150', N'ThongTinCaNhan', N'Thông tin cá nhân', N'ApplicationRole')
INSERT [dbo].[ApplicationRoles] ([Id], [Name], [Description], [Discriminator]) VALUES (N'2e0dd04b-9ac9-49f0-bb8d-4d14adde4dbb', N'Admin', NULL, N'IdentityRole')
INSERT [dbo].[ApplicationRoles] ([Id], [Name], [Description], [Discriminator]) VALUES (N'33764621-b1f5-498e-92af-79e46675f4cc', N'DeleteUser', N'Xóa bản ghi', N'ApplicationRole')
INSERT [dbo].[ApplicationRoles] ([Id], [Name], [Description], [Discriminator]) VALUES (N'36206a07-6025-4492-b210-d15f8571075e', N'KeToan', N'Kế Toán', N'ApplicationRole')
INSERT [dbo].[ApplicationRoles] ([Id], [Name], [Description], [Discriminator]) VALUES (N'3a0ec146-a428-423c-896d-bea8ea18e1d0', N'ThongKe', N'Thống kê', N'ApplicationRole')
INSERT [dbo].[ApplicationRoles] ([Id], [Name], [Description], [Discriminator]) VALUES (N'4173d74e-e3e2-4448-a648-12c88d5d4520', N'Quyen', N'Quyền', N'ApplicationRole')
INSERT [dbo].[ApplicationRoles] ([Id], [Name], [Description], [Discriminator]) VALUES (N'4a056641-22a4-4a3a-9f6c-23405a17a6c2', N'QuanLyQuyTien', N'Quản lý quỷ tiền', N'ApplicationRole')
INSERT [dbo].[ApplicationRoles] ([Id], [Name], [Description], [Discriminator]) VALUES (N'4c940bc9-0d22-4d0b-8f4e-58a37a925cd4', N'NopDon', N'Nộp đơn', N'ApplicationRole')
INSERT [dbo].[ApplicationRoles] ([Id], [Name], [Description], [Discriminator]) VALUES (N'535939b8-f52b-4846-b95b-645a6729c0da', N'QuanLyTaiSan', N'Quản lý tài sản', N'ApplicationRole')
INSERT [dbo].[ApplicationRoles] ([Id], [Name], [Description], [Discriminator]) VALUES (N'838cd2db-f5e3-4981-9999-c5489a145263', N'ViewUser', N'Chỉ truy cập', N'ApplicationRole')
INSERT [dbo].[ApplicationRoles] ([Id], [Name], [Description], [Discriminator]) VALUES (N'8747cd30-dc6a-4ac9-86dc-593655365122', N'QuanLyKho', N'Quản Lý Kho', N'ApplicationRole')
INSERT [dbo].[ApplicationRoles] ([Id], [Name], [Description], [Discriminator]) VALUES (N'abee49e4-bb3e-4aeb-96f7-171de1d83081', N'NhomNguoiDung', N'Nhóm người dùng', N'ApplicationRole')
INSERT [dbo].[ApplicationRoles] ([Id], [Name], [Description], [Discriminator]) VALUES (N'c427bb1f-4806-4131-b01b-3eecefb49400', N'QuanLyChiPhiSeo', N'Quản lý chi phí Seo', N'ApplicationRole')
INSERT [dbo].[ApplicationRoles] ([Id], [Name], [Description], [Discriminator]) VALUES (N'c4353d29-f39c-4859-8949-d44315e74e56', N'QuanLyNhanSu', N'Quản lý nhân sự', N'ApplicationRole')
INSERT [dbo].[ApplicationRoles] ([Id], [Name], [Description], [Discriminator]) VALUES (N'c723ce89-e509-4f5a-8273-685f3c14c3b2', N'AddUser', N'Thêm bản ghi', N'ApplicationRole')
INSERT [dbo].[ApplicationRoles] ([Id], [Name], [Description], [Discriminator]) VALUES (N'c900368b-e966-4a23-9723-723695a67cac', N'QuanLyVangMat', N'Quản lý vắng mặt', N'ApplicationRole')
INSERT [dbo].[ApplicationRoles] ([Id], [Name], [Description], [Discriminator]) VALUES (N'd637e6ab-4a01-4e82-b156-86ff72e78280', N'User', NULL, N'IdentityRole')
INSERT [dbo].[ApplicationRoles] ([Id], [Name], [Description], [Discriminator]) VALUES (N'e9c55747-6019-488d-860f-6a36350537f1', N'NhapDiem', N'Nhap diem', N'ApplicationRole')
INSERT [dbo].[ApplicationRoles] ([Id], [Name], [Description], [Discriminator]) VALUES (N'f7548b8f-3c2d-48a3-a5d5-b573b177b0ed', N'QuanLyNhaCungCap', N'Quản lý nhà cung cấp', N'ApplicationRole')
INSERT [dbo].[ApplicationRoles] ([Id], [Name], [Description], [Discriminator]) VALUES (N'fb0e2107-dcf3-48b3-9f2c-b6710dcdcd3c', N'QuanLyHangHoa', N'Quản lý hàng hóa', N'ApplicationRole')
INSERT [dbo].[ApplicationUserGroups] ([UserId], [GroupId], [Note]) VALUES (N'0fd05d1f-d0ab-41d9-acd8-2a2afe672841', 9, NULL)
INSERT [dbo].[ApplicationUserGroups] ([UserId], [GroupId], [Note]) VALUES (N'48a830ea-140f-4ba4-9b70-225b1443d025', 11, NULL)
INSERT [dbo].[ApplicationUserGroups] ([UserId], [GroupId], [Note]) VALUES (N'49a05802-c34f-45b2-bff9-7c534a0b74c3', 6, NULL)
INSERT [dbo].[ApplicationUserGroups] ([UserId], [GroupId], [Note]) VALUES (N'7295329d-3045-463b-b9f8-53fe1dd34f08', 6, NULL)
INSERT [dbo].[ApplicationUserGroups] ([UserId], [GroupId], [Note]) VALUES (N'7c70f855-34e1-4057-b7c2-c68a61e510f2', 1, NULL)
INSERT [dbo].[ApplicationUserGroups] ([UserId], [GroupId], [Note]) VALUES (N'9f2d954c-1da5-49f1-a966-79dc363563ae', 6, NULL)
INSERT [dbo].[ApplicationUserGroups] ([UserId], [GroupId], [Note]) VALUES (N'a23dba00-5d88-4574-a51a-b58845a9c986', 6, NULL)
INSERT [dbo].[ApplicationUserGroups] ([UserId], [GroupId], [Note]) VALUES (N'ae9440c0-9d32-4047-841e-1dfc678ce475', 11, NULL)
INSERT [dbo].[ApplicationUserGroups] ([UserId], [GroupId], [Note]) VALUES (N'ae9440c0-9d32-4047-841e-1dfc678ce475', 12, NULL)
INSERT [dbo].[ApplicationUserGroups] ([UserId], [GroupId], [Note]) VALUES (N'bc313043-fd5a-4b65-8acc-55d0f85c4bb1', 6, NULL)
INSERT [dbo].[ApplicationUserGroups] ([UserId], [GroupId], [Note]) VALUES (N'bfe984a8-096a-4163-84da-103368d9ae5f', 9, NULL)
INSERT [dbo].[ApplicationUserGroups] ([UserId], [GroupId], [Note]) VALUES (N'c830eef4-5b76-407d-9843-e480ebead41e', 6, NULL)
INSERT [dbo].[ApplicationUserGroups] ([UserId], [GroupId], [Note]) VALUES (N'dd768b97-5ad5-41ce-a25b-c884635c1176', 11, NULL)
INSERT [dbo].[ApplicationUserGroups] ([UserId], [GroupId], [Note]) VALUES (N'dd768b97-5ad5-41ce-a25b-c884635c1176', 12, NULL)
INSERT [dbo].[ApplicationUserGroups] ([UserId], [GroupId], [Note]) VALUES (N'f70e0f93-f109-488a-b570-03a3c2a1f3ae', 10, NULL)
INSERT [dbo].[ApplicationUserGroups] ([UserId], [GroupId], [Note]) VALUES (N'f8007115-8f77-43a8-b965-a2ed7673c7a8', 6, NULL)
INSERT [dbo].[ApplicationUserGroups] ([UserId], [GroupId], [Note]) VALUES (N'fcfeac1e-e87a-45c2-8416-7d8fc44eac7e', 11, NULL)
INSERT [dbo].[ApplicationUserRoles] ([UserId], [RoleId], [IdentityRole_Id], [ApplicationUser_Id]) VALUES (N'03a39ac2-7a75-4775-9846-69ffd80169d3', N'838cd2db-f5e3-4981-9999-c5489a145263', NULL, NULL)
INSERT [dbo].[ApplicationUserRoles] ([UserId], [RoleId], [IdentityRole_Id], [ApplicationUser_Id]) VALUES (N'0d4cac2b-1d7c-4a0e-a1f1-a5d3bcdd4ab9', N'520651d6-67a6-488d-aa9c-c61900596f35', NULL, NULL)
INSERT [dbo].[ApplicationUserRoles] ([UserId], [RoleId], [IdentityRole_Id], [ApplicationUser_Id]) VALUES (N'0d4cac2b-1d7c-4a0e-a1f1-a5d3bcdd4ab9', N'838cd2db-f5e3-4981-9999-c5489a145263', NULL, NULL)
INSERT [dbo].[ApplicationUserRoles] ([UserId], [RoleId], [IdentityRole_Id], [ApplicationUser_Id]) VALUES (N'0d4cac2b-1d7c-4a0e-a1f1-a5d3bcdd4ab9', N'fb7b7b45-a892-473f-a73a-e8899f73ebf8', NULL, NULL)
INSERT [dbo].[ApplicationUserRoles] ([UserId], [RoleId], [IdentityRole_Id], [ApplicationUser_Id]) VALUES (N'0fd05d1f-d0ab-41d9-acd8-2a2afe672841', N'03c68f75-97fe-416b-af31-7019240c7c3e', NULL, NULL)
INSERT [dbo].[ApplicationUserRoles] ([UserId], [RoleId], [IdentityRole_Id], [ApplicationUser_Id]) VALUES (N'0fd05d1f-d0ab-41d9-acd8-2a2afe672841', N'0765f36e-4b97-4564-b6ac-0171e7ed4382', NULL, NULL)
INSERT [dbo].[ApplicationUserRoles] ([UserId], [RoleId], [IdentityRole_Id], [ApplicationUser_Id]) VALUES (N'0fd05d1f-d0ab-41d9-acd8-2a2afe672841', N'07be8b35-688a-4456-a43c-2c1c9feeede0', NULL, NULL)
INSERT [dbo].[ApplicationUserRoles] ([UserId], [RoleId], [IdentityRole_Id], [ApplicationUser_Id]) VALUES (N'0fd05d1f-d0ab-41d9-acd8-2a2afe672841', N'095dd76b-f3a2-4eb9-95b4-98591d803fff', NULL, NULL)
INSERT [dbo].[ApplicationUserRoles] ([UserId], [RoleId], [IdentityRole_Id], [ApplicationUser_Id]) VALUES (N'0fd05d1f-d0ab-41d9-acd8-2a2afe672841', N'0db0f35c-1ba7-4e3d-ba4b-3540d67708c8', NULL, NULL)
INSERT [dbo].[ApplicationUserRoles] ([UserId], [RoleId], [IdentityRole_Id], [ApplicationUser_Id]) VALUES (N'0fd05d1f-d0ab-41d9-acd8-2a2afe672841', N'2ddded44-f75a-4e30-94c1-b558eee85150', NULL, NULL)
INSERT [dbo].[ApplicationUserRoles] ([UserId], [RoleId], [IdentityRole_Id], [ApplicationUser_Id]) VALUES (N'0fd05d1f-d0ab-41d9-acd8-2a2afe672841', N'33764621-b1f5-498e-92af-79e46675f4cc', NULL, NULL)
INSERT [dbo].[ApplicationUserRoles] ([UserId], [RoleId], [IdentityRole_Id], [ApplicationUser_Id]) VALUES (N'0fd05d1f-d0ab-41d9-acd8-2a2afe672841', N'36206a07-6025-4492-b210-d15f8571075e', NULL, NULL)
INSERT [dbo].[ApplicationUserRoles] ([UserId], [RoleId], [IdentityRole_Id], [ApplicationUser_Id]) VALUES (N'0fd05d1f-d0ab-41d9-acd8-2a2afe672841', N'3a0ec146-a428-423c-896d-bea8ea18e1d0', NULL, NULL)
INSERT [dbo].[ApplicationUserRoles] ([UserId], [RoleId], [IdentityRole_Id], [ApplicationUser_Id]) VALUES (N'0fd05d1f-d0ab-41d9-acd8-2a2afe672841', N'4173d74e-e3e2-4448-a648-12c88d5d4520', NULL, NULL)
INSERT [dbo].[ApplicationUserRoles] ([UserId], [RoleId], [IdentityRole_Id], [ApplicationUser_Id]) VALUES (N'0fd05d1f-d0ab-41d9-acd8-2a2afe672841', N'4a056641-22a4-4a3a-9f6c-23405a17a6c2', NULL, NULL)
INSERT [dbo].[ApplicationUserRoles] ([UserId], [RoleId], [IdentityRole_Id], [ApplicationUser_Id]) VALUES (N'0fd05d1f-d0ab-41d9-acd8-2a2afe672841', N'4c940bc9-0d22-4d0b-8f4e-58a37a925cd4', NULL, NULL)
INSERT [dbo].[ApplicationUserRoles] ([UserId], [RoleId], [IdentityRole_Id], [ApplicationUser_Id]) VALUES (N'0fd05d1f-d0ab-41d9-acd8-2a2afe672841', N'535939b8-f52b-4846-b95b-645a6729c0da', NULL, NULL)
INSERT [dbo].[ApplicationUserRoles] ([UserId], [RoleId], [IdentityRole_Id], [ApplicationUser_Id]) VALUES (N'0fd05d1f-d0ab-41d9-acd8-2a2afe672841', N'838cd2db-f5e3-4981-9999-c5489a145263', NULL, NULL)
INSERT [dbo].[ApplicationUserRoles] ([UserId], [RoleId], [IdentityRole_Id], [ApplicationUser_Id]) VALUES (N'0fd05d1f-d0ab-41d9-acd8-2a2afe672841', N'8747cd30-dc6a-4ac9-86dc-593655365122', NULL, NULL)
INSERT [dbo].[ApplicationUserRoles] ([UserId], [RoleId], [IdentityRole_Id], [ApplicationUser_Id]) VALUES (N'0fd05d1f-d0ab-41d9-acd8-2a2afe672841', N'abee49e4-bb3e-4aeb-96f7-171de1d83081', NULL, NULL)
INSERT [dbo].[ApplicationUserRoles] ([UserId], [RoleId], [IdentityRole_Id], [ApplicationUser_Id]) VALUES (N'0fd05d1f-d0ab-41d9-acd8-2a2afe672841', N'c427bb1f-4806-4131-b01b-3eecefb49400', NULL, NULL)
INSERT [dbo].[ApplicationUserRoles] ([UserId], [RoleId], [IdentityRole_Id], [ApplicationUser_Id]) VALUES (N'0fd05d1f-d0ab-41d9-acd8-2a2afe672841', N'c4353d29-f39c-4859-8949-d44315e74e56', NULL, NULL)
INSERT [dbo].[ApplicationUserRoles] ([UserId], [RoleId], [IdentityRole_Id], [ApplicationUser_Id]) VALUES (N'0fd05d1f-d0ab-41d9-acd8-2a2afe672841', N'c723ce89-e509-4f5a-8273-685f3c14c3b2', NULL, NULL)
INSERT [dbo].[ApplicationUserRoles] ([UserId], [RoleId], [IdentityRole_Id], [ApplicationUser_Id]) VALUES (N'0fd05d1f-d0ab-41d9-acd8-2a2afe672841', N'c900368b-e966-4a23-9723-723695a67cac', NULL, NULL)
INSERT [dbo].[ApplicationUserRoles] ([UserId], [RoleId], [IdentityRole_Id], [ApplicationUser_Id]) VALUES (N'0fd05d1f-d0ab-41d9-acd8-2a2afe672841', N'e9c55747-6019-488d-860f-6a36350537f1', NULL, NULL)
INSERT [dbo].[ApplicationUserRoles] ([UserId], [RoleId], [IdentityRole_Id], [ApplicationUser_Id]) VALUES (N'0fd05d1f-d0ab-41d9-acd8-2a2afe672841', N'f7548b8f-3c2d-48a3-a5d5-b573b177b0ed', NULL, NULL)
INSERT [dbo].[ApplicationUserRoles] ([UserId], [RoleId], [IdentityRole_Id], [ApplicationUser_Id]) VALUES (N'0fd05d1f-d0ab-41d9-acd8-2a2afe672841', N'fb0e2107-dcf3-48b3-9f2c-b6710dcdcd3c', NULL, NULL)
INSERT [dbo].[ApplicationUserRoles] ([UserId], [RoleId], [IdentityRole_Id], [ApplicationUser_Id]) VALUES (N'10fd9511-2783-4292-a366-8415e079f63a', N'2ddded44-f75a-4e30-94c1-b558eee85150', NULL, NULL)
INSERT [dbo].[ApplicationUserRoles] ([UserId], [RoleId], [IdentityRole_Id], [ApplicationUser_Id]) VALUES (N'10fd9511-2783-4292-a366-8415e079f63a', N'33764621-b1f5-498e-92af-79e46675f4cc', NULL, NULL)
INSERT [dbo].[ApplicationUserRoles] ([UserId], [RoleId], [IdentityRole_Id], [ApplicationUser_Id]) VALUES (N'10fd9511-2783-4292-a366-8415e079f63a', N'520651d6-67a6-488d-aa9c-c61900596f35', NULL, NULL)
INSERT [dbo].[ApplicationUserRoles] ([UserId], [RoleId], [IdentityRole_Id], [ApplicationUser_Id]) VALUES (N'10fd9511-2783-4292-a366-8415e079f63a', N'838cd2db-f5e3-4981-9999-c5489a145263', NULL, NULL)
INSERT [dbo].[ApplicationUserRoles] ([UserId], [RoleId], [IdentityRole_Id], [ApplicationUser_Id]) VALUES (N'10fd9511-2783-4292-a366-8415e079f63a', N'c427bb1f-4806-4131-b01b-3eecefb49400', NULL, NULL)
INSERT [dbo].[ApplicationUserRoles] ([UserId], [RoleId], [IdentityRole_Id], [ApplicationUser_Id]) VALUES (N'10fd9511-2783-4292-a366-8415e079f63a', N'c723ce89-e509-4f5a-8273-685f3c14c3b2', NULL, NULL)
INSERT [dbo].[ApplicationUserRoles] ([UserId], [RoleId], [IdentityRole_Id], [ApplicationUser_Id]) VALUES (N'10fd9511-2783-4292-a366-8415e079f63a', N'e9c55747-6019-488d-860f-6a36350537f1', NULL, NULL)
INSERT [dbo].[ApplicationUserRoles] ([UserId], [RoleId], [IdentityRole_Id], [ApplicationUser_Id]) VALUES (N'10fd9511-2783-4292-a366-8415e079f63a', N'fb7b7b45-a892-473f-a73a-e8899f73ebf8', NULL, NULL)
INSERT [dbo].[ApplicationUserRoles] ([UserId], [RoleId], [IdentityRole_Id], [ApplicationUser_Id]) VALUES (N'27ada48c-be1d-42d9-b23c-175016b726bf', N'838cd2db-f5e3-4981-9999-c5489a145263', NULL, NULL)
INSERT [dbo].[ApplicationUserRoles] ([UserId], [RoleId], [IdentityRole_Id], [ApplicationUser_Id]) VALUES (N'2a6fd265-5c98-4a04-a02d-05870485064f', N'838cd2db-f5e3-4981-9999-c5489a145263', NULL, NULL)
INSERT [dbo].[ApplicationUserRoles] ([UserId], [RoleId], [IdentityRole_Id], [ApplicationUser_Id]) VALUES (N'2b96f56d-0725-4404-9bb6-7fa11c44e33b', N'33764621-b1f5-498e-92af-79e46675f4cc', NULL, NULL)
INSERT [dbo].[ApplicationUserRoles] ([UserId], [RoleId], [IdentityRole_Id], [ApplicationUser_Id]) VALUES (N'2b96f56d-0725-4404-9bb6-7fa11c44e33b', N'838cd2db-f5e3-4981-9999-c5489a145263', NULL, NULL)
INSERT [dbo].[ApplicationUserRoles] ([UserId], [RoleId], [IdentityRole_Id], [ApplicationUser_Id]) VALUES (N'2b96f56d-0725-4404-9bb6-7fa11c44e33b', N'c723ce89-e509-4f5a-8273-685f3c14c3b2', NULL, NULL)
INSERT [dbo].[ApplicationUserRoles] ([UserId], [RoleId], [IdentityRole_Id], [ApplicationUser_Id]) VALUES (N'2b96f56d-0725-4404-9bb6-7fa11c44e33b', N'fb7b7b45-a892-473f-a73a-e8899f73ebf8', NULL, NULL)
INSERT [dbo].[ApplicationUserRoles] ([UserId], [RoleId], [IdentityRole_Id], [ApplicationUser_Id]) VALUES (N'2f89a7ab-5947-4608-9fd0-fb7e648e9788', N'33764621-b1f5-498e-92af-79e46675f4cc', NULL, NULL)
INSERT [dbo].[ApplicationUserRoles] ([UserId], [RoleId], [IdentityRole_Id], [ApplicationUser_Id]) VALUES (N'2f89a7ab-5947-4608-9fd0-fb7e648e9788', N'c723ce89-e509-4f5a-8273-685f3c14c3b2', NULL, NULL)
INSERT [dbo].[ApplicationUserRoles] ([UserId], [RoleId], [IdentityRole_Id], [ApplicationUser_Id]) VALUES (N'369e48c4-e6af-4719-a5df-1c9753dbef14', N'838cd2db-f5e3-4981-9999-c5489a145263', NULL, NULL)
INSERT [dbo].[ApplicationUserRoles] ([UserId], [RoleId], [IdentityRole_Id], [ApplicationUser_Id]) VALUES (N'39cff308-1f7b-4992-9c78-f2b3d93fcfd6', N'838cd2db-f5e3-4981-9999-c5489a145263', NULL, NULL)
INSERT [dbo].[ApplicationUserRoles] ([UserId], [RoleId], [IdentityRole_Id], [ApplicationUser_Id]) VALUES (N'40d57515-ea41-406d-95be-7e11da437050', N'520651d6-67a6-488d-aa9c-c61900596f35', NULL, NULL)
INSERT [dbo].[ApplicationUserRoles] ([UserId], [RoleId], [IdentityRole_Id], [ApplicationUser_Id]) VALUES (N'40d57515-ea41-406d-95be-7e11da437050', N'838cd2db-f5e3-4981-9999-c5489a145263', NULL, NULL)
INSERT [dbo].[ApplicationUserRoles] ([UserId], [RoleId], [IdentityRole_Id], [ApplicationUser_Id]) VALUES (N'48a830ea-140f-4ba4-9b70-225b1443d025', N'0db0f35c-1ba7-4e3d-ba4b-3540d67708c8', NULL, NULL)
INSERT [dbo].[ApplicationUserRoles] ([UserId], [RoleId], [IdentityRole_Id], [ApplicationUser_Id]) VALUES (N'49a05802-c34f-45b2-bff9-7c534a0b74c3', N'2ddded44-f75a-4e30-94c1-b558eee85150', NULL, NULL)
INSERT [dbo].[ApplicationUserRoles] ([UserId], [RoleId], [IdentityRole_Id], [ApplicationUser_Id]) VALUES (N'49a05802-c34f-45b2-bff9-7c534a0b74c3', N'4c940bc9-0d22-4d0b-8f4e-58a37a925cd4', NULL, NULL)
INSERT [dbo].[ApplicationUserRoles] ([UserId], [RoleId], [IdentityRole_Id], [ApplicationUser_Id]) VALUES (N'49a05802-c34f-45b2-bff9-7c534a0b74c3', N'c900368b-e966-4a23-9723-723695a67cac', NULL, NULL)
INSERT [dbo].[ApplicationUserRoles] ([UserId], [RoleId], [IdentityRole_Id], [ApplicationUser_Id]) VALUES (N'56e3b624-72e2-49b9-a3d9-8a5bcf3e7c24', N'33764621-b1f5-498e-92af-79e46675f4cc', NULL, NULL)
INSERT [dbo].[ApplicationUserRoles] ([UserId], [RoleId], [IdentityRole_Id], [ApplicationUser_Id]) VALUES (N'56e3b624-72e2-49b9-a3d9-8a5bcf3e7c24', N'838cd2db-f5e3-4981-9999-c5489a145263', NULL, NULL)
INSERT [dbo].[ApplicationUserRoles] ([UserId], [RoleId], [IdentityRole_Id], [ApplicationUser_Id]) VALUES (N'56e3b624-72e2-49b9-a3d9-8a5bcf3e7c24', N'c723ce89-e509-4f5a-8273-685f3c14c3b2', NULL, NULL)
INSERT [dbo].[ApplicationUserRoles] ([UserId], [RoleId], [IdentityRole_Id], [ApplicationUser_Id]) VALUES (N'56e3b624-72e2-49b9-a3d9-8a5bcf3e7c24', N'e9c55747-6019-488d-860f-6a36350537f1', NULL, NULL)
INSERT [dbo].[ApplicationUserRoles] ([UserId], [RoleId], [IdentityRole_Id], [ApplicationUser_Id]) VALUES (N'5ffb879a-74e4-4037-bc6b-0a682138ceed', N'838cd2db-f5e3-4981-9999-c5489a145263', NULL, NULL)
INSERT [dbo].[ApplicationUserRoles] ([UserId], [RoleId], [IdentityRole_Id], [ApplicationUser_Id]) VALUES (N'69814e87-3fdf-4a45-b0df-09d9b8bd29a8', N'33764621-b1f5-498e-92af-79e46675f4cc', NULL, NULL)
INSERT [dbo].[ApplicationUserRoles] ([UserId], [RoleId], [IdentityRole_Id], [ApplicationUser_Id]) VALUES (N'69814e87-3fdf-4a45-b0df-09d9b8bd29a8', N'838cd2db-f5e3-4981-9999-c5489a145263', NULL, NULL)
INSERT [dbo].[ApplicationUserRoles] ([UserId], [RoleId], [IdentityRole_Id], [ApplicationUser_Id]) VALUES (N'69814e87-3fdf-4a45-b0df-09d9b8bd29a8', N'c723ce89-e509-4f5a-8273-685f3c14c3b2', NULL, NULL)
INSERT [dbo].[ApplicationUserRoles] ([UserId], [RoleId], [IdentityRole_Id], [ApplicationUser_Id]) VALUES (N'69814e87-3fdf-4a45-b0df-09d9b8bd29a8', N'e9c55747-6019-488d-860f-6a36350537f1', NULL, NULL)
INSERT [dbo].[ApplicationUserRoles] ([UserId], [RoleId], [IdentityRole_Id], [ApplicationUser_Id]) VALUES (N'7295329d-3045-463b-b9f8-53fe1dd34f08', N'2ddded44-f75a-4e30-94c1-b558eee85150', NULL, NULL)
INSERT [dbo].[ApplicationUserRoles] ([UserId], [RoleId], [IdentityRole_Id], [ApplicationUser_Id]) VALUES (N'7295329d-3045-463b-b9f8-53fe1dd34f08', N'4c940bc9-0d22-4d0b-8f4e-58a37a925cd4', NULL, NULL)
INSERT [dbo].[ApplicationUserRoles] ([UserId], [RoleId], [IdentityRole_Id], [ApplicationUser_Id]) VALUES (N'7295329d-3045-463b-b9f8-53fe1dd34f08', N'c900368b-e966-4a23-9723-723695a67cac', NULL, NULL)
INSERT [dbo].[ApplicationUserRoles] ([UserId], [RoleId], [IdentityRole_Id], [ApplicationUser_Id]) VALUES (N'7c70f855-34e1-4057-b7c2-c68a61e510f2', N'03c68f75-97fe-416b-af31-7019240c7c3e', NULL, NULL)
INSERT [dbo].[ApplicationUserRoles] ([UserId], [RoleId], [IdentityRole_Id], [ApplicationUser_Id]) VALUES (N'7c70f855-34e1-4057-b7c2-c68a61e510f2', N'07be8b35-688a-4456-a43c-2c1c9feeede0', NULL, NULL)
INSERT [dbo].[ApplicationUserRoles] ([UserId], [RoleId], [IdentityRole_Id], [ApplicationUser_Id]) VALUES (N'7c70f855-34e1-4057-b7c2-c68a61e510f2', N'2ddded44-f75a-4e30-94c1-b558eee85150', NULL, NULL)
INSERT [dbo].[ApplicationUserRoles] ([UserId], [RoleId], [IdentityRole_Id], [ApplicationUser_Id]) VALUES (N'7c70f855-34e1-4057-b7c2-c68a61e510f2', N'33764621-b1f5-498e-92af-79e46675f4cc', NULL, NULL)
INSERT [dbo].[ApplicationUserRoles] ([UserId], [RoleId], [IdentityRole_Id], [ApplicationUser_Id]) VALUES (N'7c70f855-34e1-4057-b7c2-c68a61e510f2', N'3a0ec146-a428-423c-896d-bea8ea18e1d0', NULL, NULL)
INSERT [dbo].[ApplicationUserRoles] ([UserId], [RoleId], [IdentityRole_Id], [ApplicationUser_Id]) VALUES (N'7c70f855-34e1-4057-b7c2-c68a61e510f2', N'4173d74e-e3e2-4448-a648-12c88d5d4520', NULL, NULL)
INSERT [dbo].[ApplicationUserRoles] ([UserId], [RoleId], [IdentityRole_Id], [ApplicationUser_Id]) VALUES (N'7c70f855-34e1-4057-b7c2-c68a61e510f2', N'4a056641-22a4-4a3a-9f6c-23405a17a6c2', NULL, NULL)
INSERT [dbo].[ApplicationUserRoles] ([UserId], [RoleId], [IdentityRole_Id], [ApplicationUser_Id]) VALUES (N'7c70f855-34e1-4057-b7c2-c68a61e510f2', N'4c940bc9-0d22-4d0b-8f4e-58a37a925cd4', NULL, NULL)
INSERT [dbo].[ApplicationUserRoles] ([UserId], [RoleId], [IdentityRole_Id], [ApplicationUser_Id]) VALUES (N'7c70f855-34e1-4057-b7c2-c68a61e510f2', N'520651d6-67a6-488d-aa9c-c61900596f35', NULL, NULL)
INSERT [dbo].[ApplicationUserRoles] ([UserId], [RoleId], [IdentityRole_Id], [ApplicationUser_Id]) VALUES (N'7c70f855-34e1-4057-b7c2-c68a61e510f2', N'838cd2db-f5e3-4981-9999-c5489a145263', NULL, NULL)
INSERT [dbo].[ApplicationUserRoles] ([UserId], [RoleId], [IdentityRole_Id], [ApplicationUser_Id]) VALUES (N'7c70f855-34e1-4057-b7c2-c68a61e510f2', N'8747cd30-dc6a-4ac9-86dc-593655365122', NULL, NULL)
INSERT [dbo].[ApplicationUserRoles] ([UserId], [RoleId], [IdentityRole_Id], [ApplicationUser_Id]) VALUES (N'7c70f855-34e1-4057-b7c2-c68a61e510f2', N'abee49e4-bb3e-4aeb-96f7-171de1d83081', NULL, NULL)
INSERT [dbo].[ApplicationUserRoles] ([UserId], [RoleId], [IdentityRole_Id], [ApplicationUser_Id]) VALUES (N'7c70f855-34e1-4057-b7c2-c68a61e510f2', N'c427bb1f-4806-4131-b01b-3eecefb49400', NULL, NULL)
INSERT [dbo].[ApplicationUserRoles] ([UserId], [RoleId], [IdentityRole_Id], [ApplicationUser_Id]) VALUES (N'7c70f855-34e1-4057-b7c2-c68a61e510f2', N'c4353d29-f39c-4859-8949-d44315e74e56', NULL, NULL)
INSERT [dbo].[ApplicationUserRoles] ([UserId], [RoleId], [IdentityRole_Id], [ApplicationUser_Id]) VALUES (N'7c70f855-34e1-4057-b7c2-c68a61e510f2', N'c723ce89-e509-4f5a-8273-685f3c14c3b2', NULL, NULL)
INSERT [dbo].[ApplicationUserRoles] ([UserId], [RoleId], [IdentityRole_Id], [ApplicationUser_Id]) VALUES (N'7c70f855-34e1-4057-b7c2-c68a61e510f2', N'c900368b-e966-4a23-9723-723695a67cac', NULL, NULL)
INSERT [dbo].[ApplicationUserRoles] ([UserId], [RoleId], [IdentityRole_Id], [ApplicationUser_Id]) VALUES (N'7c70f855-34e1-4057-b7c2-c68a61e510f2', N'e9c55747-6019-488d-860f-6a36350537f1', NULL, NULL)
INSERT [dbo].[ApplicationUserRoles] ([UserId], [RoleId], [IdentityRole_Id], [ApplicationUser_Id]) VALUES (N'7c70f855-34e1-4057-b7c2-c68a61e510f2', N'f7548b8f-3c2d-48a3-a5d5-b573b177b0ed', NULL, NULL)
INSERT [dbo].[ApplicationUserRoles] ([UserId], [RoleId], [IdentityRole_Id], [ApplicationUser_Id]) VALUES (N'7c70f855-34e1-4057-b7c2-c68a61e510f2', N'fb0e2107-dcf3-48b3-9f2c-b6710dcdcd3c', NULL, NULL)
INSERT [dbo].[ApplicationUserRoles] ([UserId], [RoleId], [IdentityRole_Id], [ApplicationUser_Id]) VALUES (N'7c70f855-34e1-4057-b7c2-c68a61e510f2', N'fb7b7b45-a892-473f-a73a-e8899f73ebf8', NULL, NULL)
INSERT [dbo].[ApplicationUserRoles] ([UserId], [RoleId], [IdentityRole_Id], [ApplicationUser_Id]) VALUES (N'814297af-e508-44cc-a349-f8655f353499', N'33764621-b1f5-498e-92af-79e46675f4cc', NULL, NULL)
INSERT [dbo].[ApplicationUserRoles] ([UserId], [RoleId], [IdentityRole_Id], [ApplicationUser_Id]) VALUES (N'814297af-e508-44cc-a349-f8655f353499', N'838cd2db-f5e3-4981-9999-c5489a145263', NULL, NULL)
INSERT [dbo].[ApplicationUserRoles] ([UserId], [RoleId], [IdentityRole_Id], [ApplicationUser_Id]) VALUES (N'814297af-e508-44cc-a349-f8655f353499', N'c723ce89-e509-4f5a-8273-685f3c14c3b2', NULL, NULL)
INSERT [dbo].[ApplicationUserRoles] ([UserId], [RoleId], [IdentityRole_Id], [ApplicationUser_Id]) VALUES (N'814297af-e508-44cc-a349-f8655f353499', N'fb7b7b45-a892-473f-a73a-e8899f73ebf8', NULL, NULL)
INSERT [dbo].[ApplicationUserRoles] ([UserId], [RoleId], [IdentityRole_Id], [ApplicationUser_Id]) VALUES (N'8c46baa5-f2f7-4b40-b171-fd51b3c103f9', N'33764621-b1f5-498e-92af-79e46675f4cc', NULL, NULL)
INSERT [dbo].[ApplicationUserRoles] ([UserId], [RoleId], [IdentityRole_Id], [ApplicationUser_Id]) VALUES (N'8c46baa5-f2f7-4b40-b171-fd51b3c103f9', N'520651d6-67a6-488d-aa9c-c61900596f35', NULL, NULL)
INSERT [dbo].[ApplicationUserRoles] ([UserId], [RoleId], [IdentityRole_Id], [ApplicationUser_Id]) VALUES (N'8c46baa5-f2f7-4b40-b171-fd51b3c103f9', N'838cd2db-f5e3-4981-9999-c5489a145263', NULL, NULL)
INSERT [dbo].[ApplicationUserRoles] ([UserId], [RoleId], [IdentityRole_Id], [ApplicationUser_Id]) VALUES (N'8c46baa5-f2f7-4b40-b171-fd51b3c103f9', N'c723ce89-e509-4f5a-8273-685f3c14c3b2', NULL, NULL)
INSERT [dbo].[ApplicationUserRoles] ([UserId], [RoleId], [IdentityRole_Id], [ApplicationUser_Id]) VALUES (N'8c46baa5-f2f7-4b40-b171-fd51b3c103f9', N'fb7b7b45-a892-473f-a73a-e8899f73ebf8', NULL, NULL)
INSERT [dbo].[ApplicationUserRoles] ([UserId], [RoleId], [IdentityRole_Id], [ApplicationUser_Id]) VALUES (N'92a1b8e5-c339-4344-991b-71e8fbfa8f8f', N'520651d6-67a6-488d-aa9c-c61900596f35', NULL, NULL)
INSERT [dbo].[ApplicationUserRoles] ([UserId], [RoleId], [IdentityRole_Id], [ApplicationUser_Id]) VALUES (N'92a1b8e5-c339-4344-991b-71e8fbfa8f8f', N'838cd2db-f5e3-4981-9999-c5489a145263', NULL, NULL)
INSERT [dbo].[ApplicationUserRoles] ([UserId], [RoleId], [IdentityRole_Id], [ApplicationUser_Id]) VALUES (N'92a1b8e5-c339-4344-991b-71e8fbfa8f8f', N'c723ce89-e509-4f5a-8273-685f3c14c3b2', NULL, NULL)
INSERT [dbo].[ApplicationUserRoles] ([UserId], [RoleId], [IdentityRole_Id], [ApplicationUser_Id]) VALUES (N'92a1b8e5-c339-4344-991b-71e8fbfa8f8f', N'fb7b7b45-a892-473f-a73a-e8899f73ebf8', NULL, NULL)
INSERT [dbo].[ApplicationUserRoles] ([UserId], [RoleId], [IdentityRole_Id], [ApplicationUser_Id]) VALUES (N'93da7613-b895-4726-8c55-4e9dba763f8e', N'838cd2db-f5e3-4981-9999-c5489a145263', NULL, NULL)
INSERT [dbo].[ApplicationUserRoles] ([UserId], [RoleId], [IdentityRole_Id], [ApplicationUser_Id]) VALUES (N'96b8adc4-4c76-4d9f-b62b-a92ef7e0eb6a', N'838cd2db-f5e3-4981-9999-c5489a145263', NULL, NULL)
INSERT [dbo].[ApplicationUserRoles] ([UserId], [RoleId], [IdentityRole_Id], [ApplicationUser_Id]) VALUES (N'99199f59-883a-4e6c-b5f5-05490482d409', N'838cd2db-f5e3-4981-9999-c5489a145263', NULL, NULL)
INSERT [dbo].[ApplicationUserRoles] ([UserId], [RoleId], [IdentityRole_Id], [ApplicationUser_Id]) VALUES (N'9c9f159a-a40d-453f-b970-fdcc7f01f70d', N'838cd2db-f5e3-4981-9999-c5489a145263', NULL, NULL)
GO
INSERT [dbo].[ApplicationUserRoles] ([UserId], [RoleId], [IdentityRole_Id], [ApplicationUser_Id]) VALUES (N'9e9a5c9d-989e-4f73-b963-029cc8fcdf4a', N'838cd2db-f5e3-4981-9999-c5489a145263', NULL, NULL)
INSERT [dbo].[ApplicationUserRoles] ([UserId], [RoleId], [IdentityRole_Id], [ApplicationUser_Id]) VALUES (N'9f2d954c-1da5-49f1-a966-79dc363563ae', N'2ddded44-f75a-4e30-94c1-b558eee85150', NULL, NULL)
INSERT [dbo].[ApplicationUserRoles] ([UserId], [RoleId], [IdentityRole_Id], [ApplicationUser_Id]) VALUES (N'9f2d954c-1da5-49f1-a966-79dc363563ae', N'4c940bc9-0d22-4d0b-8f4e-58a37a925cd4', NULL, NULL)
INSERT [dbo].[ApplicationUserRoles] ([UserId], [RoleId], [IdentityRole_Id], [ApplicationUser_Id]) VALUES (N'9f2d954c-1da5-49f1-a966-79dc363563ae', N'c900368b-e966-4a23-9723-723695a67cac', NULL, NULL)
INSERT [dbo].[ApplicationUserRoles] ([UserId], [RoleId], [IdentityRole_Id], [ApplicationUser_Id]) VALUES (N'a23dba00-5d88-4574-a51a-b58845a9c986', N'2ddded44-f75a-4e30-94c1-b558eee85150', NULL, NULL)
INSERT [dbo].[ApplicationUserRoles] ([UserId], [RoleId], [IdentityRole_Id], [ApplicationUser_Id]) VALUES (N'a23dba00-5d88-4574-a51a-b58845a9c986', N'4c940bc9-0d22-4d0b-8f4e-58a37a925cd4', NULL, NULL)
INSERT [dbo].[ApplicationUserRoles] ([UserId], [RoleId], [IdentityRole_Id], [ApplicationUser_Id]) VALUES (N'a23dba00-5d88-4574-a51a-b58845a9c986', N'c900368b-e966-4a23-9723-723695a67cac', NULL, NULL)
INSERT [dbo].[ApplicationUserRoles] ([UserId], [RoleId], [IdentityRole_Id], [ApplicationUser_Id]) VALUES (N'ad61b3f8-4662-4c9d-8699-d1fc1d087e3e', N'2e0dd04b-9ac9-49f0-bb8d-4d14adde4dbb', NULL, NULL)
INSERT [dbo].[ApplicationUserRoles] ([UserId], [RoleId], [IdentityRole_Id], [ApplicationUser_Id]) VALUES (N'ad61b3f8-4662-4c9d-8699-d1fc1d087e3e', N'33764621-b1f5-498e-92af-79e46675f4cc', NULL, NULL)
INSERT [dbo].[ApplicationUserRoles] ([UserId], [RoleId], [IdentityRole_Id], [ApplicationUser_Id]) VALUES (N'ad61b3f8-4662-4c9d-8699-d1fc1d087e3e', N'838cd2db-f5e3-4981-9999-c5489a145263', NULL, NULL)
INSERT [dbo].[ApplicationUserRoles] ([UserId], [RoleId], [IdentityRole_Id], [ApplicationUser_Id]) VALUES (N'ad61b3f8-4662-4c9d-8699-d1fc1d087e3e', N'c723ce89-e509-4f5a-8273-685f3c14c3b2', NULL, NULL)
INSERT [dbo].[ApplicationUserRoles] ([UserId], [RoleId], [IdentityRole_Id], [ApplicationUser_Id]) VALUES (N'ad61b3f8-4662-4c9d-8699-d1fc1d087e3e', N'd637e6ab-4a01-4e82-b156-86ff72e78280', NULL, NULL)
INSERT [dbo].[ApplicationUserRoles] ([UserId], [RoleId], [IdentityRole_Id], [ApplicationUser_Id]) VALUES (N'ad61b3f8-4662-4c9d-8699-d1fc1d087e3e', N'fb7b7b45-a892-473f-a73a-e8899f73ebf8', NULL, NULL)
INSERT [dbo].[ApplicationUserRoles] ([UserId], [RoleId], [IdentityRole_Id], [ApplicationUser_Id]) VALUES (N'ae9440c0-9d32-4047-841e-1dfc678ce475', N'095dd76b-f3a2-4eb9-95b4-98591d803fff', NULL, NULL)
INSERT [dbo].[ApplicationUserRoles] ([UserId], [RoleId], [IdentityRole_Id], [ApplicationUser_Id]) VALUES (N'ae9440c0-9d32-4047-841e-1dfc678ce475', N'0db0f35c-1ba7-4e3d-ba4b-3540d67708c8', NULL, NULL)
INSERT [dbo].[ApplicationUserRoles] ([UserId], [RoleId], [IdentityRole_Id], [ApplicationUser_Id]) VALUES (N'b4794d39-8d93-4459-8a28-156985e5fe64', N'520651d6-67a6-488d-aa9c-c61900596f35', NULL, NULL)
INSERT [dbo].[ApplicationUserRoles] ([UserId], [RoleId], [IdentityRole_Id], [ApplicationUser_Id]) VALUES (N'b4794d39-8d93-4459-8a28-156985e5fe64', N'838cd2db-f5e3-4981-9999-c5489a145263', NULL, NULL)
INSERT [dbo].[ApplicationUserRoles] ([UserId], [RoleId], [IdentityRole_Id], [ApplicationUser_Id]) VALUES (N'bc313043-fd5a-4b65-8acc-55d0f85c4bb1', N'2ddded44-f75a-4e30-94c1-b558eee85150', NULL, NULL)
INSERT [dbo].[ApplicationUserRoles] ([UserId], [RoleId], [IdentityRole_Id], [ApplicationUser_Id]) VALUES (N'bc313043-fd5a-4b65-8acc-55d0f85c4bb1', N'4c940bc9-0d22-4d0b-8f4e-58a37a925cd4', NULL, NULL)
INSERT [dbo].[ApplicationUserRoles] ([UserId], [RoleId], [IdentityRole_Id], [ApplicationUser_Id]) VALUES (N'bc313043-fd5a-4b65-8acc-55d0f85c4bb1', N'c900368b-e966-4a23-9723-723695a67cac', NULL, NULL)
INSERT [dbo].[ApplicationUserRoles] ([UserId], [RoleId], [IdentityRole_Id], [ApplicationUser_Id]) VALUES (N'bd041095-0ebf-460c-822b-e02e636836c7', N'33764621-b1f5-498e-92af-79e46675f4cc', NULL, NULL)
INSERT [dbo].[ApplicationUserRoles] ([UserId], [RoleId], [IdentityRole_Id], [ApplicationUser_Id]) VALUES (N'bd041095-0ebf-460c-822b-e02e636836c7', N'520651d6-67a6-488d-aa9c-c61900596f35', NULL, NULL)
INSERT [dbo].[ApplicationUserRoles] ([UserId], [RoleId], [IdentityRole_Id], [ApplicationUser_Id]) VALUES (N'bd041095-0ebf-460c-822b-e02e636836c7', N'838cd2db-f5e3-4981-9999-c5489a145263', NULL, NULL)
INSERT [dbo].[ApplicationUserRoles] ([UserId], [RoleId], [IdentityRole_Id], [ApplicationUser_Id]) VALUES (N'bd041095-0ebf-460c-822b-e02e636836c7', N'c723ce89-e509-4f5a-8273-685f3c14c3b2', NULL, NULL)
INSERT [dbo].[ApplicationUserRoles] ([UserId], [RoleId], [IdentityRole_Id], [ApplicationUser_Id]) VALUES (N'bd041095-0ebf-460c-822b-e02e636836c7', N'e9c55747-6019-488d-860f-6a36350537f1', NULL, NULL)
INSERT [dbo].[ApplicationUserRoles] ([UserId], [RoleId], [IdentityRole_Id], [ApplicationUser_Id]) VALUES (N'bd041095-0ebf-460c-822b-e02e636836c7', N'fb7b7b45-a892-473f-a73a-e8899f73ebf8', NULL, NULL)
INSERT [dbo].[ApplicationUserRoles] ([UserId], [RoleId], [IdentityRole_Id], [ApplicationUser_Id]) VALUES (N'bfe984a8-096a-4163-84da-103368d9ae5f', N'03c68f75-97fe-416b-af31-7019240c7c3e', NULL, NULL)
INSERT [dbo].[ApplicationUserRoles] ([UserId], [RoleId], [IdentityRole_Id], [ApplicationUser_Id]) VALUES (N'bfe984a8-096a-4163-84da-103368d9ae5f', N'0765f36e-4b97-4564-b6ac-0171e7ed4382', NULL, NULL)
INSERT [dbo].[ApplicationUserRoles] ([UserId], [RoleId], [IdentityRole_Id], [ApplicationUser_Id]) VALUES (N'bfe984a8-096a-4163-84da-103368d9ae5f', N'095dd76b-f3a2-4eb9-95b4-98591d803fff', NULL, NULL)
INSERT [dbo].[ApplicationUserRoles] ([UserId], [RoleId], [IdentityRole_Id], [ApplicationUser_Id]) VALUES (N'bfe984a8-096a-4163-84da-103368d9ae5f', N'0db0f35c-1ba7-4e3d-ba4b-3540d67708c8', NULL, NULL)
INSERT [dbo].[ApplicationUserRoles] ([UserId], [RoleId], [IdentityRole_Id], [ApplicationUser_Id]) VALUES (N'bfe984a8-096a-4163-84da-103368d9ae5f', N'2ddded44-f75a-4e30-94c1-b558eee85150', NULL, NULL)
INSERT [dbo].[ApplicationUserRoles] ([UserId], [RoleId], [IdentityRole_Id], [ApplicationUser_Id]) VALUES (N'bfe984a8-096a-4163-84da-103368d9ae5f', N'33764621-b1f5-498e-92af-79e46675f4cc', NULL, NULL)
INSERT [dbo].[ApplicationUserRoles] ([UserId], [RoleId], [IdentityRole_Id], [ApplicationUser_Id]) VALUES (N'bfe984a8-096a-4163-84da-103368d9ae5f', N'36206a07-6025-4492-b210-d15f8571075e', NULL, NULL)
INSERT [dbo].[ApplicationUserRoles] ([UserId], [RoleId], [IdentityRole_Id], [ApplicationUser_Id]) VALUES (N'bfe984a8-096a-4163-84da-103368d9ae5f', N'3a0ec146-a428-423c-896d-bea8ea18e1d0', NULL, NULL)
INSERT [dbo].[ApplicationUserRoles] ([UserId], [RoleId], [IdentityRole_Id], [ApplicationUser_Id]) VALUES (N'bfe984a8-096a-4163-84da-103368d9ae5f', N'4a056641-22a4-4a3a-9f6c-23405a17a6c2', NULL, NULL)
INSERT [dbo].[ApplicationUserRoles] ([UserId], [RoleId], [IdentityRole_Id], [ApplicationUser_Id]) VALUES (N'bfe984a8-096a-4163-84da-103368d9ae5f', N'4c940bc9-0d22-4d0b-8f4e-58a37a925cd4', NULL, NULL)
INSERT [dbo].[ApplicationUserRoles] ([UserId], [RoleId], [IdentityRole_Id], [ApplicationUser_Id]) VALUES (N'bfe984a8-096a-4163-84da-103368d9ae5f', N'535939b8-f52b-4846-b95b-645a6729c0da', NULL, NULL)
INSERT [dbo].[ApplicationUserRoles] ([UserId], [RoleId], [IdentityRole_Id], [ApplicationUser_Id]) VALUES (N'bfe984a8-096a-4163-84da-103368d9ae5f', N'838cd2db-f5e3-4981-9999-c5489a145263', NULL, NULL)
INSERT [dbo].[ApplicationUserRoles] ([UserId], [RoleId], [IdentityRole_Id], [ApplicationUser_Id]) VALUES (N'bfe984a8-096a-4163-84da-103368d9ae5f', N'8747cd30-dc6a-4ac9-86dc-593655365122', NULL, NULL)
INSERT [dbo].[ApplicationUserRoles] ([UserId], [RoleId], [IdentityRole_Id], [ApplicationUser_Id]) VALUES (N'bfe984a8-096a-4163-84da-103368d9ae5f', N'c427bb1f-4806-4131-b01b-3eecefb49400', NULL, NULL)
INSERT [dbo].[ApplicationUserRoles] ([UserId], [RoleId], [IdentityRole_Id], [ApplicationUser_Id]) VALUES (N'bfe984a8-096a-4163-84da-103368d9ae5f', N'c4353d29-f39c-4859-8949-d44315e74e56', NULL, NULL)
INSERT [dbo].[ApplicationUserRoles] ([UserId], [RoleId], [IdentityRole_Id], [ApplicationUser_Id]) VALUES (N'bfe984a8-096a-4163-84da-103368d9ae5f', N'c723ce89-e509-4f5a-8273-685f3c14c3b2', NULL, NULL)
INSERT [dbo].[ApplicationUserRoles] ([UserId], [RoleId], [IdentityRole_Id], [ApplicationUser_Id]) VALUES (N'bfe984a8-096a-4163-84da-103368d9ae5f', N'c900368b-e966-4a23-9723-723695a67cac', NULL, NULL)
INSERT [dbo].[ApplicationUserRoles] ([UserId], [RoleId], [IdentityRole_Id], [ApplicationUser_Id]) VALUES (N'bfe984a8-096a-4163-84da-103368d9ae5f', N'e9c55747-6019-488d-860f-6a36350537f1', NULL, NULL)
INSERT [dbo].[ApplicationUserRoles] ([UserId], [RoleId], [IdentityRole_Id], [ApplicationUser_Id]) VALUES (N'bfe984a8-096a-4163-84da-103368d9ae5f', N'f7548b8f-3c2d-48a3-a5d5-b573b177b0ed', NULL, NULL)
INSERT [dbo].[ApplicationUserRoles] ([UserId], [RoleId], [IdentityRole_Id], [ApplicationUser_Id]) VALUES (N'bfe984a8-096a-4163-84da-103368d9ae5f', N'fb0e2107-dcf3-48b3-9f2c-b6710dcdcd3c', NULL, NULL)
INSERT [dbo].[ApplicationUserRoles] ([UserId], [RoleId], [IdentityRole_Id], [ApplicationUser_Id]) VALUES (N'c786ba85-bd49-4093-a8cd-4e9d226a2351', N'520651d6-67a6-488d-aa9c-c61900596f35', NULL, NULL)
INSERT [dbo].[ApplicationUserRoles] ([UserId], [RoleId], [IdentityRole_Id], [ApplicationUser_Id]) VALUES (N'c786ba85-bd49-4093-a8cd-4e9d226a2351', N'838cd2db-f5e3-4981-9999-c5489a145263', NULL, NULL)
INSERT [dbo].[ApplicationUserRoles] ([UserId], [RoleId], [IdentityRole_Id], [ApplicationUser_Id]) VALUES (N'c786ba85-bd49-4093-a8cd-4e9d226a2351', N'fb7b7b45-a892-473f-a73a-e8899f73ebf8', NULL, NULL)
INSERT [dbo].[ApplicationUserRoles] ([UserId], [RoleId], [IdentityRole_Id], [ApplicationUser_Id]) VALUES (N'c830eef4-5b76-407d-9843-e480ebead41e', N'2ddded44-f75a-4e30-94c1-b558eee85150', NULL, NULL)
INSERT [dbo].[ApplicationUserRoles] ([UserId], [RoleId], [IdentityRole_Id], [ApplicationUser_Id]) VALUES (N'c830eef4-5b76-407d-9843-e480ebead41e', N'4c940bc9-0d22-4d0b-8f4e-58a37a925cd4', NULL, NULL)
INSERT [dbo].[ApplicationUserRoles] ([UserId], [RoleId], [IdentityRole_Id], [ApplicationUser_Id]) VALUES (N'c830eef4-5b76-407d-9843-e480ebead41e', N'c900368b-e966-4a23-9723-723695a67cac', NULL, NULL)
INSERT [dbo].[ApplicationUserRoles] ([UserId], [RoleId], [IdentityRole_Id], [ApplicationUser_Id]) VALUES (N'cba8157d-7319-4215-899b-ae8738b3e003', N'33764621-b1f5-498e-92af-79e46675f4cc', NULL, NULL)
INSERT [dbo].[ApplicationUserRoles] ([UserId], [RoleId], [IdentityRole_Id], [ApplicationUser_Id]) VALUES (N'cba8157d-7319-4215-899b-ae8738b3e003', N'838cd2db-f5e3-4981-9999-c5489a145263', NULL, NULL)
INSERT [dbo].[ApplicationUserRoles] ([UserId], [RoleId], [IdentityRole_Id], [ApplicationUser_Id]) VALUES (N'cba8157d-7319-4215-899b-ae8738b3e003', N'c723ce89-e509-4f5a-8273-685f3c14c3b2', NULL, NULL)
INSERT [dbo].[ApplicationUserRoles] ([UserId], [RoleId], [IdentityRole_Id], [ApplicationUser_Id]) VALUES (N'cba8157d-7319-4215-899b-ae8738b3e003', N'e9c55747-6019-488d-860f-6a36350537f1', NULL, NULL)
INSERT [dbo].[ApplicationUserRoles] ([UserId], [RoleId], [IdentityRole_Id], [ApplicationUser_Id]) VALUES (N'dd768b97-5ad5-41ce-a25b-c884635c1176', N'095dd76b-f3a2-4eb9-95b4-98591d803fff', NULL, NULL)
INSERT [dbo].[ApplicationUserRoles] ([UserId], [RoleId], [IdentityRole_Id], [ApplicationUser_Id]) VALUES (N'dd768b97-5ad5-41ce-a25b-c884635c1176', N'0db0f35c-1ba7-4e3d-ba4b-3540d67708c8', NULL, NULL)
INSERT [dbo].[ApplicationUserRoles] ([UserId], [RoleId], [IdentityRole_Id], [ApplicationUser_Id]) VALUES (N'e2cf1bfa-41de-4d92-ae82-8ab3b3f1be74', N'03c68f75-97fe-416b-af31-7019240c7c3e', NULL, NULL)
INSERT [dbo].[ApplicationUserRoles] ([UserId], [RoleId], [IdentityRole_Id], [ApplicationUser_Id]) VALUES (N'e2cf1bfa-41de-4d92-ae82-8ab3b3f1be74', N'2ddded44-f75a-4e30-94c1-b558eee85150', NULL, NULL)
INSERT [dbo].[ApplicationUserRoles] ([UserId], [RoleId], [IdentityRole_Id], [ApplicationUser_Id]) VALUES (N'e2cf1bfa-41de-4d92-ae82-8ab3b3f1be74', N'4a056641-22a4-4a3a-9f6c-23405a17a6c2', NULL, NULL)
INSERT [dbo].[ApplicationUserRoles] ([UserId], [RoleId], [IdentityRole_Id], [ApplicationUser_Id]) VALUES (N'e2cf1bfa-41de-4d92-ae82-8ab3b3f1be74', N'520651d6-67a6-488d-aa9c-c61900596f35', NULL, NULL)
INSERT [dbo].[ApplicationUserRoles] ([UserId], [RoleId], [IdentityRole_Id], [ApplicationUser_Id]) VALUES (N'e2cf1bfa-41de-4d92-ae82-8ab3b3f1be74', N'838cd2db-f5e3-4981-9999-c5489a145263', NULL, NULL)
INSERT [dbo].[ApplicationUserRoles] ([UserId], [RoleId], [IdentityRole_Id], [ApplicationUser_Id]) VALUES (N'e2cf1bfa-41de-4d92-ae82-8ab3b3f1be74', N'8747cd30-dc6a-4ac9-86dc-593655365122', NULL, NULL)
INSERT [dbo].[ApplicationUserRoles] ([UserId], [RoleId], [IdentityRole_Id], [ApplicationUser_Id]) VALUES (N'e2cf1bfa-41de-4d92-ae82-8ab3b3f1be74', N'c427bb1f-4806-4131-b01b-3eecefb49400', NULL, NULL)
INSERT [dbo].[ApplicationUserRoles] ([UserId], [RoleId], [IdentityRole_Id], [ApplicationUser_Id]) VALUES (N'e2cf1bfa-41de-4d92-ae82-8ab3b3f1be74', N'c4353d29-f39c-4859-8949-d44315e74e56', NULL, NULL)
INSERT [dbo].[ApplicationUserRoles] ([UserId], [RoleId], [IdentityRole_Id], [ApplicationUser_Id]) VALUES (N'e2cf1bfa-41de-4d92-ae82-8ab3b3f1be74', N'fb0e2107-dcf3-48b3-9f2c-b6710dcdcd3c', NULL, NULL)
INSERT [dbo].[ApplicationUserRoles] ([UserId], [RoleId], [IdentityRole_Id], [ApplicationUser_Id]) VALUES (N'e2cf1bfa-41de-4d92-ae82-8ab3b3f1be74', N'fb7b7b45-a892-473f-a73a-e8899f73ebf8', NULL, NULL)
INSERT [dbo].[ApplicationUserRoles] ([UserId], [RoleId], [IdentityRole_Id], [ApplicationUser_Id]) VALUES (N'e8e50678-2618-4621-af84-e3002581f901', N'838cd2db-f5e3-4981-9999-c5489a145263', NULL, NULL)
INSERT [dbo].[ApplicationUserRoles] ([UserId], [RoleId], [IdentityRole_Id], [ApplicationUser_Id]) VALUES (N'f150c01d-d64d-42e4-b99f-96ac89006f56', N'520651d6-67a6-488d-aa9c-c61900596f35', NULL, NULL)
INSERT [dbo].[ApplicationUserRoles] ([UserId], [RoleId], [IdentityRole_Id], [ApplicationUser_Id]) VALUES (N'f150c01d-d64d-42e4-b99f-96ac89006f56', N'838cd2db-f5e3-4981-9999-c5489a145263', NULL, NULL)
INSERT [dbo].[ApplicationUserRoles] ([UserId], [RoleId], [IdentityRole_Id], [ApplicationUser_Id]) VALUES (N'f70e0f93-f109-488a-b570-03a3c2a1f3ae', N'03c68f75-97fe-416b-af31-7019240c7c3e', NULL, NULL)
INSERT [dbo].[ApplicationUserRoles] ([UserId], [RoleId], [IdentityRole_Id], [ApplicationUser_Id]) VALUES (N'f70e0f93-f109-488a-b570-03a3c2a1f3ae', N'07be8b35-688a-4456-a43c-2c1c9feeede0', NULL, NULL)
INSERT [dbo].[ApplicationUserRoles] ([UserId], [RoleId], [IdentityRole_Id], [ApplicationUser_Id]) VALUES (N'f70e0f93-f109-488a-b570-03a3c2a1f3ae', N'2ddded44-f75a-4e30-94c1-b558eee85150', NULL, NULL)
INSERT [dbo].[ApplicationUserRoles] ([UserId], [RoleId], [IdentityRole_Id], [ApplicationUser_Id]) VALUES (N'f70e0f93-f109-488a-b570-03a3c2a1f3ae', N'33764621-b1f5-498e-92af-79e46675f4cc', NULL, NULL)
INSERT [dbo].[ApplicationUserRoles] ([UserId], [RoleId], [IdentityRole_Id], [ApplicationUser_Id]) VALUES (N'f70e0f93-f109-488a-b570-03a3c2a1f3ae', N'3a0ec146-a428-423c-896d-bea8ea18e1d0', NULL, NULL)
INSERT [dbo].[ApplicationUserRoles] ([UserId], [RoleId], [IdentityRole_Id], [ApplicationUser_Id]) VALUES (N'f70e0f93-f109-488a-b570-03a3c2a1f3ae', N'4173d74e-e3e2-4448-a648-12c88d5d4520', NULL, NULL)
INSERT [dbo].[ApplicationUserRoles] ([UserId], [RoleId], [IdentityRole_Id], [ApplicationUser_Id]) VALUES (N'f70e0f93-f109-488a-b570-03a3c2a1f3ae', N'4a056641-22a4-4a3a-9f6c-23405a17a6c2', NULL, NULL)
INSERT [dbo].[ApplicationUserRoles] ([UserId], [RoleId], [IdentityRole_Id], [ApplicationUser_Id]) VALUES (N'f70e0f93-f109-488a-b570-03a3c2a1f3ae', N'4c940bc9-0d22-4d0b-8f4e-58a37a925cd4', NULL, NULL)
INSERT [dbo].[ApplicationUserRoles] ([UserId], [RoleId], [IdentityRole_Id], [ApplicationUser_Id]) VALUES (N'f70e0f93-f109-488a-b570-03a3c2a1f3ae', N'838cd2db-f5e3-4981-9999-c5489a145263', NULL, NULL)
INSERT [dbo].[ApplicationUserRoles] ([UserId], [RoleId], [IdentityRole_Id], [ApplicationUser_Id]) VALUES (N'f70e0f93-f109-488a-b570-03a3c2a1f3ae', N'8747cd30-dc6a-4ac9-86dc-593655365122', NULL, NULL)
INSERT [dbo].[ApplicationUserRoles] ([UserId], [RoleId], [IdentityRole_Id], [ApplicationUser_Id]) VALUES (N'f70e0f93-f109-488a-b570-03a3c2a1f3ae', N'abee49e4-bb3e-4aeb-96f7-171de1d83081', NULL, NULL)
INSERT [dbo].[ApplicationUserRoles] ([UserId], [RoleId], [IdentityRole_Id], [ApplicationUser_Id]) VALUES (N'f70e0f93-f109-488a-b570-03a3c2a1f3ae', N'c427bb1f-4806-4131-b01b-3eecefb49400', NULL, NULL)
INSERT [dbo].[ApplicationUserRoles] ([UserId], [RoleId], [IdentityRole_Id], [ApplicationUser_Id]) VALUES (N'f70e0f93-f109-488a-b570-03a3c2a1f3ae', N'c4353d29-f39c-4859-8949-d44315e74e56', NULL, NULL)
INSERT [dbo].[ApplicationUserRoles] ([UserId], [RoleId], [IdentityRole_Id], [ApplicationUser_Id]) VALUES (N'f70e0f93-f109-488a-b570-03a3c2a1f3ae', N'c723ce89-e509-4f5a-8273-685f3c14c3b2', NULL, NULL)
INSERT [dbo].[ApplicationUserRoles] ([UserId], [RoleId], [IdentityRole_Id], [ApplicationUser_Id]) VALUES (N'f70e0f93-f109-488a-b570-03a3c2a1f3ae', N'e9c55747-6019-488d-860f-6a36350537f1', NULL, NULL)
INSERT [dbo].[ApplicationUserRoles] ([UserId], [RoleId], [IdentityRole_Id], [ApplicationUser_Id]) VALUES (N'f70e0f93-f109-488a-b570-03a3c2a1f3ae', N'fb0e2107-dcf3-48b3-9f2c-b6710dcdcd3c', NULL, NULL)
INSERT [dbo].[ApplicationUserRoles] ([UserId], [RoleId], [IdentityRole_Id], [ApplicationUser_Id]) VALUES (N'f8007115-8f77-43a8-b965-a2ed7673c7a8', N'2ddded44-f75a-4e30-94c1-b558eee85150', NULL, NULL)
INSERT [dbo].[ApplicationUserRoles] ([UserId], [RoleId], [IdentityRole_Id], [ApplicationUser_Id]) VALUES (N'f8007115-8f77-43a8-b965-a2ed7673c7a8', N'4c940bc9-0d22-4d0b-8f4e-58a37a925cd4', NULL, NULL)
INSERT [dbo].[ApplicationUserRoles] ([UserId], [RoleId], [IdentityRole_Id], [ApplicationUser_Id]) VALUES (N'f8007115-8f77-43a8-b965-a2ed7673c7a8', N'c900368b-e966-4a23-9723-723695a67cac', NULL, NULL)
INSERT [dbo].[ApplicationUserRoles] ([UserId], [RoleId], [IdentityRole_Id], [ApplicationUser_Id]) VALUES (N'fcfeac1e-e87a-45c2-8416-7d8fc44eac7e', N'0db0f35c-1ba7-4e3d-ba4b-3540d67708c8', NULL, NULL)
INSERT [dbo].[ApplicationUsers] ([Id], [FullName], [Address], [BirthDay], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'0fd05d1f-d0ab-41d9-acd8-2a2afe672841', N'Lê Trung Khoa', NULL, CAST(N'2020-07-21T17:00:00.000' AS DateTime), N'Khoa@gmail.com', 0, N'AByfg1KRt6R1ARZRTjN1vLtRbARAtznMAfreAnJOsmSL7JCegCeCSxdng2PcVvSkqQ==', N'f293edd2-3bb6-4d81-b756-26552852590e', N'01231212312', 0, 0, NULL, 0, 0, N'0001')
INSERT [dbo].[ApplicationUsers] ([Id], [FullName], [Address], [BirthDay], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'48a830ea-140f-4ba4-9b70-225b1443d025', N'Huỳnh Thanh Vân', NULL, CAST(N'2020-08-26T17:00:00.000' AS DateTime), N'ac@vlcc.edu.vn', 0, N'AE7WSyd9AVoQfK+TjuNsrgpYpOu0wAWV0pXJvRhk3ANISM6NNQ0PU/g4TES0tWdWhw==', N'927f844b-ca14-4bc9-9459-fd12e4e2aa6a', NULL, 0, 0, NULL, 0, 0, N'0013')
INSERT [dbo].[ApplicationUsers] ([Id], [FullName], [Address], [BirthDay], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'49a05802-c34f-45b2-bff9-7c534a0b74c3', N'Trần Văn Trường', NULL, CAST(N'2020-07-22T17:00:00.000' AS DateTime), N'truong@gmail.comm', 0, N'ABZD4qNbQn8wlBvFN3iFkI0AmMqrZBgfp8K9vKpeYPhaKV/7HZ/7IPXC6iMLC++ZyQ==', N'9f346a98-1f28-4814-8a96-345bd4e448c9', N'01231212312', 0, 0, NULL, 0, 0, N'0006')
INSERT [dbo].[ApplicationUsers] ([Id], [FullName], [Address], [BirthDay], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'7295329d-3045-463b-b9f8-53fe1dd34f08', N'Lê Thị Ngọc Lan', NULL, CAST(N'2020-07-15T17:00:00.000' AS DateTime), N'lan@gmail.comm', 0, N'AAGXt4mpbdWTt25Ikepz91Z2OOebyL58BXJreAt/xvFsF22OiQfX3sLWElJPzV1oLg==', N'2c2f1928-edfc-4c59-84fb-38ff75fe74ed', N'01231212312', 0, 0, NULL, 0, 0, N'0005')
INSERT [dbo].[ApplicationUsers] ([Id], [FullName], [Address], [BirthDay], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'7c70f855-34e1-4057-b7c2-c68a61e510f2', N'admin', N'ăd', CAST(N'2020-07-15T17:00:00.000' AS DateTime), N'admin@mekong-tech.com', 1, N'ANCok8mZcFu/X2bvIMFZziILalCRa+OV340TAKgzxj6frmYIJffayyd8RKq3sPgo9Q==', N'97593689-8b61-47e8-a90d-adc576fa7c39', N'21313', 0, 0, NULL, 1, 0, N'admin')
INSERT [dbo].[ApplicationUsers] ([Id], [FullName], [Address], [BirthDay], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'9f2d954c-1da5-49f1-a966-79dc363563ae', N'Lê Minh Tường', NULL, CAST(N'2020-07-29T17:00:00.000' AS DateTime), N'tuong@gmail.comm', 0, N'AAwYYc5U5gO57P6p9g6r3U8/lkUq22ie6Q0ivNcIvZ/KRGOVKOmhIxnq4vW+kbSEEg==', N'dd3b9bb0-ca1b-4980-b6da-f9c989a9582f', N'01231212312', 0, 0, NULL, 0, 0, N'0004')
INSERT [dbo].[ApplicationUsers] ([Id], [FullName], [Address], [BirthDay], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'a23dba00-5d88-4574-a51a-b58845a9c986', N'Tran Van C', NULL, CAST(N'2020-07-21T17:00:00.000' AS DateTime), N'c@gmail.com', 0, N'ACtYmW9H+2u+o5VzFl7OQIh4XWWabJglvW765cemKuDhVO2hv+LjPLRmjZ6Nh9Yzdw==', N'e2ec5dcb-afb3-496e-8e67-63a894755af9', NULL, 0, 0, NULL, 0, 0, N'0010')
INSERT [dbo].[ApplicationUsers] ([Id], [FullName], [Address], [BirthDay], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'ae9440c0-9d32-4047-841e-1dfc678ce475', N'Vương Thị Việt Mỹ', NULL, CAST(N'2020-08-23T17:00:00.000' AS DateTime), N'awd@gmail.com', 0, N'AP6kBhKuay+8VFAIKdn6rHj0+lptZd4NhCMmgpKGodN3bsSO59cipsp77TnraBJoag==', N'43bf12ee-ec91-4d66-b056-a1c3e493bbee', N'12313123', 0, 0, NULL, 0, 0, N'0014')
INSERT [dbo].[ApplicationUsers] ([Id], [FullName], [Address], [BirthDay], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'bc313043-fd5a-4b65-8acc-55d0f85c4bb1', N'Tran Van B', NULL, CAST(N'2020-06-30T17:00:00.000' AS DateTime), N'b@gmail.comm', 0, N'AFdi9QabqYas1B9MVy3x4TmstDqykPvHIwY8cq/EYcGmIKOoJ3NSXzggmsBpRNlq1w==', N'235a0946-f668-4898-b10e-772bf14daf8b', N'01231212312', 0, 0, NULL, 0, 0, N'0009')
INSERT [dbo].[ApplicationUsers] ([Id], [FullName], [Address], [BirthDay], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'bfe984a8-096a-4163-84da-103368d9ae5f', N'Diệp Minh Luận', NULL, CAST(N'2020-07-17T17:00:00.000' AS DateTime), N'luan@gmail.comm', 0, N'AEU1iHQWZHk1dU5SSg0u3/ei9jk2e7UrrIkGT0rmWtglVD2YidT+7vlz+OCD/9lagg==', N'6568e02f-398d-4e2e-b3e2-7237962910b5', N'01231212312', 0, 0, NULL, 0, 0, N'0007')
INSERT [dbo].[ApplicationUsers] ([Id], [FullName], [Address], [BirthDay], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'c830eef4-5b76-407d-9843-e480ebead41e', N'Lê Trung Nghĩa', NULL, CAST(N'2020-07-23T17:00:00.000' AS DateTime), N'nghia@gmail.comm', 0, N'AFAemfwYD7dQ8xif0+aJxd2y848psQoriNxs51U+jFQ5juQEI0zUCW94hGQL2klkmw==', N'6679d1f0-4439-4667-9f8d-217e8cf51b13', N'01231212312', 0, 0, NULL, 0, 0, N'0003')
INSERT [dbo].[ApplicationUsers] ([Id], [FullName], [Address], [BirthDay], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'dd768b97-5ad5-41ce-a25b-c884635c1176', N'Nguyễn Anh Thi', NULL, CAST(N'2020-08-20T17:00:00.000' AS DateTime), N'aaaaa@gmail.comm', 0, N'AO0Zq84zMleHNop5GQOsQRxSXDKWFCGYF+rYDAnr08+BuN8/Ttry7Sbi0b3n46O9VA==', N'3bd2bd93-f847-4801-9bcb-e44821ea01b9', N'21313123123', 0, 0, NULL, 0, 0, N'0015')
INSERT [dbo].[ApplicationUsers] ([Id], [FullName], [Address], [BirthDay], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'f70e0f93-f109-488a-b570-03a3c2a1f3ae', N'Nguyễn Vũ Lâm', NULL, CAST(N'2020-07-23T17:00:00.000' AS DateTime), N'lam@gmail.com', 0, N'AIrMF8tU64ayY+r805lLUvOC9CIRTlHVAY9m99dnv10ubkxmk1GjVA4Jp/kkJx3SZA==', N'4a1ffdba-f189-4aa2-b97f-a306e177ae0d', N'01231212312', 0, 0, NULL, 0, 0, N'0002')
INSERT [dbo].[ApplicationUsers] ([Id], [FullName], [Address], [BirthDay], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'f8007115-8f77-43a8-b965-a2ed7673c7a8', N'Nguyễn Văn A', NULL, CAST(N'2020-07-09T17:00:00.000' AS DateTime), N'a@gmail.comm', 0, N'ALv3YHocWnwewXhrPgZYbs8IJJG1YRCqntOXuJtX+d/Hj4qa2+HNtkcfLnX+G/snsQ==', N'3303bfbe-17f8-45f7-9c8d-18d35fa7fbda', N'01231212312', 0, 0, NULL, 0, 0, N'0008')
INSERT [dbo].[ApplicationUsers] ([Id], [FullName], [Address], [BirthDay], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'fcfeac1e-e87a-45c2-8416-7d8fc44eac7e', N'Lê Tấn Đạt', NULL, CAST(N'2020-08-23T17:00:00.000' AS DateTime), N'ltdat@vlcc.edu.vn', 0, N'AJ7Fg4iUuG8K3dBANCzWJypTC4ABwPdM8iS8UKQB4UtTvITj3M5tvrQdizsI30yT5A==', N'44341959-26c5-42fd-acb7-c6880526ab69', NULL, 0, 0, NULL, 0, 0, N'0012')
INSERT [dbo].[BaoGia] ([MaSoBaoGia], [MaKhachHang], [GhiChu], [MaSoNhanVien], [NgayBaoGia], [HieuLucDen], [MaLoaiTien], [TyGia], [TienHang], [TienThueGTGT], [TienChietKhau], [TongTien]) VALUES (N'BG000001', N'KH000001', N'Không ghi chú', N'0001', CAST(N'2020-08-18' AS Date), CAST(N'2020-08-19' AS Date), 1, 1000, 1225000, 245000, 0, 1470000)
INSERT [dbo].[BaoGia] ([MaSoBaoGia], [MaKhachHang], [GhiChu], [MaSoNhanVien], [NgayBaoGia], [HieuLucDen], [MaLoaiTien], [TyGia], [TienHang], [TienThueGTGT], [TienChietKhau], [TongTien]) VALUES (N'BG000002', N'KH000002', N'Ghi chú', N'0001', CAST(N'2020-08-18' AS Date), CAST(N'2020-08-14' AS Date), 1, 1000, 8700000, 2015000, 0, 10715000)
SET IDENTITY_INSERT [dbo].[ChiTietBaoGia] ON 

INSERT [dbo].[ChiTietBaoGia] ([MaChiTietBaoGia], [MaSoBaoGia], [MaHang], [SoLuong], [ThanhTien], [TienChietKhau], [TienThueGTGT]) VALUES (1, N'BG000001', N'000000000002', 3, 630000, 0, 105000)
INSERT [dbo].[ChiTietBaoGia] ([MaChiTietBaoGia], [MaSoBaoGia], [MaHang], [SoLuong], [ThanhTien], [TienChietKhau], [TienThueGTGT]) VALUES (2, N'BG000001', N'000000000003', 4, 840000, 0, 140000)
INSERT [dbo].[ChiTietBaoGia] ([MaChiTietBaoGia], [MaSoBaoGia], [MaHang], [SoLuong], [ThanhTien], [TienChietKhau], [TienThueGTGT]) VALUES (3, N'BG000002', N'000000000002', 21, 4410000, 0, 735000)
INSERT [dbo].[ChiTietBaoGia] ([MaChiTietBaoGia], [MaSoBaoGia], [MaHang], [SoLuong], [ThanhTien], [TienChietKhau], [TienThueGTGT]) VALUES (4, N'BG000002', N'000000000003', 13, 2730000, 0, 455000)
INSERT [dbo].[ChiTietBaoGia] ([MaChiTietBaoGia], [MaSoBaoGia], [MaHang], [SoLuong], [ThanhTien], [TienChietKhau], [TienThueGTGT]) VALUES (5, N'BG000002', N'000000000004', 11, 3575000, 0, 825000)
SET IDENTITY_INSERT [dbo].[ChiTietBaoGia] OFF
SET IDENTITY_INSERT [dbo].[ChiTietChungTuBanHang] ON 

INSERT [dbo].[ChiTietChungTuBanHang] ([MaChiTietChungTuBanHang], [MaChungTuBanHang], [MaHang], [TKCongNo_ChiPhi], [TKDoanhThu], [SoLuong], [ThanhTien], [TienChietKhau], [TienThueGTGT]) VALUES (159, N'BH000001', N'000000000002', N'2', N'3', 43, 9030000, 0, 1505000)
INSERT [dbo].[ChiTietChungTuBanHang] ([MaChiTietChungTuBanHang], [MaChungTuBanHang], [MaHang], [TKCongNo_ChiPhi], [TKDoanhThu], [SoLuong], [ThanhTien], [TienChietKhau], [TienThueGTGT]) VALUES (160, N'BH000001', N'000000000003', N'3', N'4', 14, 2940000, 0, 490000)
INSERT [dbo].[ChiTietChungTuBanHang] ([MaChiTietChungTuBanHang], [MaChungTuBanHang], [MaHang], [TKCongNo_ChiPhi], [TKDoanhThu], [SoLuong], [ThanhTien], [TienChietKhau], [TienThueGTGT]) VALUES (161, N'BH000001', N'000000000004', N'5', N'6', 15, 4875000, 0, 1125000)
INSERT [dbo].[ChiTietChungTuBanHang] ([MaChiTietChungTuBanHang], [MaChungTuBanHang], [MaHang], [TKCongNo_ChiPhi], [TKDoanhThu], [SoLuong], [ThanhTien], [TienChietKhau], [TienThueGTGT]) VALUES (162, N'BH000002', N'000000000003', N'2', N'3', 11, 2310000, 0, 385000)
INSERT [dbo].[ChiTietChungTuBanHang] ([MaChiTietChungTuBanHang], [MaChungTuBanHang], [MaHang], [TKCongNo_ChiPhi], [TKDoanhThu], [SoLuong], [ThanhTien], [TienChietKhau], [TienThueGTGT]) VALUES (163, N'BH000002', N'000000000002', N'2', N'3', 15, 3150000, 0, 525000)
INSERT [dbo].[ChiTietChungTuBanHang] ([MaChiTietChungTuBanHang], [MaChungTuBanHang], [MaHang], [TKCongNo_ChiPhi], [TKDoanhThu], [SoLuong], [ThanhTien], [TienChietKhau], [TienThueGTGT]) VALUES (164, N'BH000003', N'000000000002', N'2', N'2', 6, 1260000, 0, 210000)
INSERT [dbo].[ChiTietChungTuBanHang] ([MaChiTietChungTuBanHang], [MaChungTuBanHang], [MaHang], [TKCongNo_ChiPhi], [TKDoanhThu], [SoLuong], [ThanhTien], [TienChietKhau], [TienThueGTGT]) VALUES (165, N'BH000003', N'000000000003', N'2', N'3', 6, 1260000, 0, 210000)
INSERT [dbo].[ChiTietChungTuBanHang] ([MaChiTietChungTuBanHang], [MaChungTuBanHang], [MaHang], [TKCongNo_ChiPhi], [TKDoanhThu], [SoLuong], [ThanhTien], [TienChietKhau], [TienThueGTGT]) VALUES (166, N'BH000004', N'000000000002', N'2', N'4', 4, 840000, 0, 140000)
INSERT [dbo].[ChiTietChungTuBanHang] ([MaChiTietChungTuBanHang], [MaChungTuBanHang], [MaHang], [TKCongNo_ChiPhi], [TKDoanhThu], [SoLuong], [ThanhTien], [TienChietKhau], [TienThueGTGT]) VALUES (167, N'BH000029', N'000000000020', NULL, NULL, 1, 440000, NULL, NULL)
INSERT [dbo].[ChiTietChungTuBanHang] ([MaChiTietChungTuBanHang], [MaChungTuBanHang], [MaHang], [TKCongNo_ChiPhi], [TKDoanhThu], [SoLuong], [ThanhTien], [TienChietKhau], [TienThueGTGT]) VALUES (168, N'BH000029', N'000000000021', NULL, NULL, 1, 262000, NULL, NULL)
INSERT [dbo].[ChiTietChungTuBanHang] ([MaChiTietChungTuBanHang], [MaChungTuBanHang], [MaHang], [TKCongNo_ChiPhi], [TKDoanhThu], [SoLuong], [ThanhTien], [TienChietKhau], [TienThueGTGT]) VALUES (169, N'BH000029', N'000000000022', NULL, NULL, 1, 380000, NULL, NULL)
INSERT [dbo].[ChiTietChungTuBanHang] ([MaChiTietChungTuBanHang], [MaChungTuBanHang], [MaHang], [TKCongNo_ChiPhi], [TKDoanhThu], [SoLuong], [ThanhTien], [TienChietKhau], [TienThueGTGT]) VALUES (170, N'BH000029', N'000000000014', NULL, NULL, 1, 280000, NULL, NULL)
INSERT [dbo].[ChiTietChungTuBanHang] ([MaChiTietChungTuBanHang], [MaChungTuBanHang], [MaHang], [TKCongNo_ChiPhi], [TKDoanhThu], [SoLuong], [ThanhTien], [TienChietKhau], [TienThueGTGT]) VALUES (171, N'BH000030', N'000000000019', NULL, NULL, 1, 110000, NULL, NULL)
INSERT [dbo].[ChiTietChungTuBanHang] ([MaChiTietChungTuBanHang], [MaChungTuBanHang], [MaHang], [TKCongNo_ChiPhi], [TKDoanhThu], [SoLuong], [ThanhTien], [TienChietKhau], [TienThueGTGT]) VALUES (172, N'BH000030', N'000000000018', NULL, NULL, 1, 145000, NULL, NULL)
INSERT [dbo].[ChiTietChungTuBanHang] ([MaChiTietChungTuBanHang], [MaChungTuBanHang], [MaHang], [TKCongNo_ChiPhi], [TKDoanhThu], [SoLuong], [ThanhTien], [TienChietKhau], [TienThueGTGT]) VALUES (173, N'BH000030', N'000000000017', NULL, NULL, 1, 265000, NULL, NULL)
INSERT [dbo].[ChiTietChungTuBanHang] ([MaChiTietChungTuBanHang], [MaChungTuBanHang], [MaHang], [TKCongNo_ChiPhi], [TKDoanhThu], [SoLuong], [ThanhTien], [TienChietKhau], [TienThueGTGT]) VALUES (174, N'BH000031', N'000000000014', NULL, NULL, 1, 280000, NULL, NULL)
INSERT [dbo].[ChiTietChungTuBanHang] ([MaChiTietChungTuBanHang], [MaChungTuBanHang], [MaHang], [TKCongNo_ChiPhi], [TKDoanhThu], [SoLuong], [ThanhTien], [TienChietKhau], [TienThueGTGT]) VALUES (175, N'BH000031', N'000000000015', NULL, NULL, 1, 390000, NULL, NULL)
INSERT [dbo].[ChiTietChungTuBanHang] ([MaChiTietChungTuBanHang], [MaChungTuBanHang], [MaHang], [TKCongNo_ChiPhi], [TKDoanhThu], [SoLuong], [ThanhTien], [TienChietKhau], [TienThueGTGT]) VALUES (176, N'BH000031', N'000000000016', NULL, NULL, 1, 365000, NULL, NULL)
INSERT [dbo].[ChiTietChungTuBanHang] ([MaChiTietChungTuBanHang], [MaChungTuBanHang], [MaHang], [TKCongNo_ChiPhi], [TKDoanhThu], [SoLuong], [ThanhTien], [TienChietKhau], [TienThueGTGT]) VALUES (177, N'BH000031', N'000000000020', NULL, NULL, 1, 440000, NULL, NULL)
INSERT [dbo].[ChiTietChungTuBanHang] ([MaChiTietChungTuBanHang], [MaChungTuBanHang], [MaHang], [TKCongNo_ChiPhi], [TKDoanhThu], [SoLuong], [ThanhTien], [TienChietKhau], [TienThueGTGT]) VALUES (178, N'BH000031', N'000000000022', NULL, NULL, 1, 380000, NULL, NULL)
INSERT [dbo].[ChiTietChungTuBanHang] ([MaChiTietChungTuBanHang], [MaChungTuBanHang], [MaHang], [TKCongNo_ChiPhi], [TKDoanhThu], [SoLuong], [ThanhTien], [TienChietKhau], [TienThueGTGT]) VALUES (179, N'BH000032', N'000000000019', NULL, NULL, 1, 110000, NULL, NULL)
INSERT [dbo].[ChiTietChungTuBanHang] ([MaChiTietChungTuBanHang], [MaChungTuBanHang], [MaHang], [TKCongNo_ChiPhi], [TKDoanhThu], [SoLuong], [ThanhTien], [TienChietKhau], [TienThueGTGT]) VALUES (180, N'BH000032', N'000000000018', NULL, NULL, 1, 145000, NULL, NULL)
INSERT [dbo].[ChiTietChungTuBanHang] ([MaChiTietChungTuBanHang], [MaChungTuBanHang], [MaHang], [TKCongNo_ChiPhi], [TKDoanhThu], [SoLuong], [ThanhTien], [TienChietKhau], [TienThueGTGT]) VALUES (181, N'BH000032', N'000000000017', NULL, NULL, 1, 265000, NULL, NULL)
INSERT [dbo].[ChiTietChungTuBanHang] ([MaChiTietChungTuBanHang], [MaChungTuBanHang], [MaHang], [TKCongNo_ChiPhi], [TKDoanhThu], [SoLuong], [ThanhTien], [TienChietKhau], [TienThueGTGT]) VALUES (182, N'BH000032', N'000000000016', NULL, NULL, 1, 365000, NULL, NULL)
INSERT [dbo].[ChiTietChungTuBanHang] ([MaChiTietChungTuBanHang], [MaChungTuBanHang], [MaHang], [TKCongNo_ChiPhi], [TKDoanhThu], [SoLuong], [ThanhTien], [TienChietKhau], [TienThueGTGT]) VALUES (183, N'BH000032', N'000000000015', NULL, NULL, 1, 390000, NULL, NULL)
INSERT [dbo].[ChiTietChungTuBanHang] ([MaChiTietChungTuBanHang], [MaChungTuBanHang], [MaHang], [TKCongNo_ChiPhi], [TKDoanhThu], [SoLuong], [ThanhTien], [TienChietKhau], [TienThueGTGT]) VALUES (184, N'BH000032', N'000000000014', NULL, NULL, 1, 280000, NULL, NULL)
INSERT [dbo].[ChiTietChungTuBanHang] ([MaChiTietChungTuBanHang], [MaChungTuBanHang], [MaHang], [TKCongNo_ChiPhi], [TKDoanhThu], [SoLuong], [ThanhTien], [TienChietKhau], [TienThueGTGT]) VALUES (185, N'BH000032', N'000000000021', NULL, NULL, 1, 262000, NULL, NULL)
INSERT [dbo].[ChiTietChungTuBanHang] ([MaChiTietChungTuBanHang], [MaChungTuBanHang], [MaHang], [TKCongNo_ChiPhi], [TKDoanhThu], [SoLuong], [ThanhTien], [TienChietKhau], [TienThueGTGT]) VALUES (186, N'BH000033', N'000000000025', NULL, NULL, 1, 197000, NULL, NULL)
INSERT [dbo].[ChiTietChungTuBanHang] ([MaChiTietChungTuBanHang], [MaChungTuBanHang], [MaHang], [TKCongNo_ChiPhi], [TKDoanhThu], [SoLuong], [ThanhTien], [TienChietKhau], [TienThueGTGT]) VALUES (187, N'BH000033', N'000000000024', NULL, NULL, 1, 195000, NULL, NULL)
INSERT [dbo].[ChiTietChungTuBanHang] ([MaChiTietChungTuBanHang], [MaChungTuBanHang], [MaHang], [TKCongNo_ChiPhi], [TKDoanhThu], [SoLuong], [ThanhTien], [TienChietKhau], [TienThueGTGT]) VALUES (188, N'BH000033', N'000000000023', NULL, NULL, 1, 155000, NULL, NULL)
INSERT [dbo].[ChiTietChungTuBanHang] ([MaChiTietChungTuBanHang], [MaChungTuBanHang], [MaHang], [TKCongNo_ChiPhi], [TKDoanhThu], [SoLuong], [ThanhTien], [TienChietKhau], [TienThueGTGT]) VALUES (189, N'BH000033', N'000000000022', NULL, NULL, 1, 380000, NULL, NULL)
INSERT [dbo].[ChiTietChungTuBanHang] ([MaChiTietChungTuBanHang], [MaChungTuBanHang], [MaHang], [TKCongNo_ChiPhi], [TKDoanhThu], [SoLuong], [ThanhTien], [TienChietKhau], [TienThueGTGT]) VALUES (190, N'BH000033', N'000000000020', NULL, NULL, 1, 440000, NULL, NULL)
INSERT [dbo].[ChiTietChungTuBanHang] ([MaChiTietChungTuBanHang], [MaChungTuBanHang], [MaHang], [TKCongNo_ChiPhi], [TKDoanhThu], [SoLuong], [ThanhTien], [TienChietKhau], [TienThueGTGT]) VALUES (191, N'BH000033', N'000000000021', NULL, NULL, 1, 262000, NULL, NULL)
INSERT [dbo].[ChiTietChungTuBanHang] ([MaChiTietChungTuBanHang], [MaChungTuBanHang], [MaHang], [TKCongNo_ChiPhi], [TKDoanhThu], [SoLuong], [ThanhTien], [TienChietKhau], [TienThueGTGT]) VALUES (192, N'BH000034', N'000000000025', NULL, NULL, 1, 197000, NULL, NULL)
INSERT [dbo].[ChiTietChungTuBanHang] ([MaChiTietChungTuBanHang], [MaChungTuBanHang], [MaHang], [TKCongNo_ChiPhi], [TKDoanhThu], [SoLuong], [ThanhTien], [TienChietKhau], [TienThueGTGT]) VALUES (193, N'BH000035', N'000000000021', NULL, NULL, 1, 262000, NULL, NULL)
INSERT [dbo].[ChiTietChungTuBanHang] ([MaChiTietChungTuBanHang], [MaChungTuBanHang], [MaHang], [TKCongNo_ChiPhi], [TKDoanhThu], [SoLuong], [ThanhTien], [TienChietKhau], [TienThueGTGT]) VALUES (194, N'BH000035', N'000000000022', NULL, NULL, 1, 380000, NULL, NULL)
INSERT [dbo].[ChiTietChungTuBanHang] ([MaChiTietChungTuBanHang], [MaChungTuBanHang], [MaHang], [TKCongNo_ChiPhi], [TKDoanhThu], [SoLuong], [ThanhTien], [TienChietKhau], [TienThueGTGT]) VALUES (195, N'BH000036', N'000000000014', NULL, NULL, 1, 280000, NULL, NULL)
INSERT [dbo].[ChiTietChungTuBanHang] ([MaChiTietChungTuBanHang], [MaChungTuBanHang], [MaHang], [TKCongNo_ChiPhi], [TKDoanhThu], [SoLuong], [ThanhTien], [TienChietKhau], [TienThueGTGT]) VALUES (196, N'BH000036', N'000000000015', NULL, NULL, 1, 390000, NULL, NULL)
INSERT [dbo].[ChiTietChungTuBanHang] ([MaChiTietChungTuBanHang], [MaChungTuBanHang], [MaHang], [TKCongNo_ChiPhi], [TKDoanhThu], [SoLuong], [ThanhTien], [TienChietKhau], [TienThueGTGT]) VALUES (197, N'BH000036', N'000000000016', NULL, NULL, 1, 365000, NULL, NULL)
INSERT [dbo].[ChiTietChungTuBanHang] ([MaChiTietChungTuBanHang], [MaChungTuBanHang], [MaHang], [TKCongNo_ChiPhi], [TKDoanhThu], [SoLuong], [ThanhTien], [TienChietKhau], [TienThueGTGT]) VALUES (198, N'BH000037', N'000000000017', NULL, NULL, 1, 265000, NULL, NULL)
INSERT [dbo].[ChiTietChungTuBanHang] ([MaChiTietChungTuBanHang], [MaChungTuBanHang], [MaHang], [TKCongNo_ChiPhi], [TKDoanhThu], [SoLuong], [ThanhTien], [TienChietKhau], [TienThueGTGT]) VALUES (199, N'BH000037', N'000000000018', NULL, NULL, 1, 145000, NULL, NULL)
INSERT [dbo].[ChiTietChungTuBanHang] ([MaChiTietChungTuBanHang], [MaChungTuBanHang], [MaHang], [TKCongNo_ChiPhi], [TKDoanhThu], [SoLuong], [ThanhTien], [TienChietKhau], [TienThueGTGT]) VALUES (200, N'BH000037', N'000000000019', NULL, NULL, 1, 110000, NULL, NULL)
INSERT [dbo].[ChiTietChungTuBanHang] ([MaChiTietChungTuBanHang], [MaChungTuBanHang], [MaHang], [TKCongNo_ChiPhi], [TKDoanhThu], [SoLuong], [ThanhTien], [TienChietKhau], [TienThueGTGT]) VALUES (201, N'BH000037', N'000000000016', NULL, NULL, 1, 365000, NULL, NULL)
INSERT [dbo].[ChiTietChungTuBanHang] ([MaChiTietChungTuBanHang], [MaChungTuBanHang], [MaHang], [TKCongNo_ChiPhi], [TKDoanhThu], [SoLuong], [ThanhTien], [TienChietKhau], [TienThueGTGT]) VALUES (202, N'BH000038', N'000000000014', NULL, NULL, 1, 280000, NULL, NULL)
INSERT [dbo].[ChiTietChungTuBanHang] ([MaChiTietChungTuBanHang], [MaChungTuBanHang], [MaHang], [TKCongNo_ChiPhi], [TKDoanhThu], [SoLuong], [ThanhTien], [TienChietKhau], [TienThueGTGT]) VALUES (203, N'BH000038', N'000000000016', NULL, NULL, 1, 365000, NULL, NULL)
INSERT [dbo].[ChiTietChungTuBanHang] ([MaChiTietChungTuBanHang], [MaChungTuBanHang], [MaHang], [TKCongNo_ChiPhi], [TKDoanhThu], [SoLuong], [ThanhTien], [TienChietKhau], [TienThueGTGT]) VALUES (204, N'BH000038', N'000000000017', NULL, NULL, 1, 265000, NULL, NULL)
INSERT [dbo].[ChiTietChungTuBanHang] ([MaChiTietChungTuBanHang], [MaChungTuBanHang], [MaHang], [TKCongNo_ChiPhi], [TKDoanhThu], [SoLuong], [ThanhTien], [TienChietKhau], [TienThueGTGT]) VALUES (205, N'BH000038', N'000000000018', NULL, NULL, 1, 145000, NULL, NULL)
INSERT [dbo].[ChiTietChungTuBanHang] ([MaChiTietChungTuBanHang], [MaChungTuBanHang], [MaHang], [TKCongNo_ChiPhi], [TKDoanhThu], [SoLuong], [ThanhTien], [TienChietKhau], [TienThueGTGT]) VALUES (206, N'BH000039', N'000000000024', NULL, NULL, 1, 195000, NULL, NULL)
INSERT [dbo].[ChiTietChungTuBanHang] ([MaChiTietChungTuBanHang], [MaChungTuBanHang], [MaHang], [TKCongNo_ChiPhi], [TKDoanhThu], [SoLuong], [ThanhTien], [TienChietKhau], [TienThueGTGT]) VALUES (207, N'BH000039', N'000000000022', NULL, NULL, 1, 380000, NULL, NULL)
INSERT [dbo].[ChiTietChungTuBanHang] ([MaChiTietChungTuBanHang], [MaChungTuBanHang], [MaHang], [TKCongNo_ChiPhi], [TKDoanhThu], [SoLuong], [ThanhTien], [TienChietKhau], [TienThueGTGT]) VALUES (208, N'BH000039', N'000000000021', NULL, NULL, 1, 262000, NULL, NULL)
INSERT [dbo].[ChiTietChungTuBanHang] ([MaChiTietChungTuBanHang], [MaChungTuBanHang], [MaHang], [TKCongNo_ChiPhi], [TKDoanhThu], [SoLuong], [ThanhTien], [TienChietKhau], [TienThueGTGT]) VALUES (209, N'BH000039', N'000000000014', NULL, NULL, 1, 280000, NULL, NULL)
INSERT [dbo].[ChiTietChungTuBanHang] ([MaChiTietChungTuBanHang], [MaChungTuBanHang], [MaHang], [TKCongNo_ChiPhi], [TKDoanhThu], [SoLuong], [ThanhTien], [TienChietKhau], [TienThueGTGT]) VALUES (210, N'BH000039', N'000000000016', NULL, NULL, 1, 365000, NULL, NULL)
INSERT [dbo].[ChiTietChungTuBanHang] ([MaChiTietChungTuBanHang], [MaChungTuBanHang], [MaHang], [TKCongNo_ChiPhi], [TKDoanhThu], [SoLuong], [ThanhTien], [TienChietKhau], [TienThueGTGT]) VALUES (211, N'BH000040', N'000000000021', NULL, NULL, 2, 524000, NULL, NULL)
INSERT [dbo].[ChiTietChungTuBanHang] ([MaChiTietChungTuBanHang], [MaChungTuBanHang], [MaHang], [TKCongNo_ChiPhi], [TKDoanhThu], [SoLuong], [ThanhTien], [TienChietKhau], [TienThueGTGT]) VALUES (212, N'BH000040', N'000000000024', NULL, NULL, 1, 195000, NULL, NULL)
INSERT [dbo].[ChiTietChungTuBanHang] ([MaChiTietChungTuBanHang], [MaChungTuBanHang], [MaHang], [TKCongNo_ChiPhi], [TKDoanhThu], [SoLuong], [ThanhTien], [TienChietKhau], [TienThueGTGT]) VALUES (213, N'BH000040', N'000000000014', NULL, NULL, 1, 280000, NULL, NULL)
INSERT [dbo].[ChiTietChungTuBanHang] ([MaChiTietChungTuBanHang], [MaChungTuBanHang], [MaHang], [TKCongNo_ChiPhi], [TKDoanhThu], [SoLuong], [ThanhTien], [TienChietKhau], [TienThueGTGT]) VALUES (214, N'BH000040', N'000000000022', NULL, NULL, 1, 380000, NULL, NULL)
INSERT [dbo].[ChiTietChungTuBanHang] ([MaChiTietChungTuBanHang], [MaChungTuBanHang], [MaHang], [TKCongNo_ChiPhi], [TKDoanhThu], [SoLuong], [ThanhTien], [TienChietKhau], [TienThueGTGT]) VALUES (215, N'BH000040', N'000000000016', NULL, NULL, 2, 730000, NULL, NULL)
INSERT [dbo].[ChiTietChungTuBanHang] ([MaChiTietChungTuBanHang], [MaChungTuBanHang], [MaHang], [TKCongNo_ChiPhi], [TKDoanhThu], [SoLuong], [ThanhTien], [TienChietKhau], [TienThueGTGT]) VALUES (216, N'BH000046', N'000000000022', NULL, NULL, 1, 380000, NULL, NULL)
INSERT [dbo].[ChiTietChungTuBanHang] ([MaChiTietChungTuBanHang], [MaChungTuBanHang], [MaHang], [TKCongNo_ChiPhi], [TKDoanhThu], [SoLuong], [ThanhTien], [TienChietKhau], [TienThueGTGT]) VALUES (217, N'BH000046', N'000000000023', NULL, NULL, 2, 310000, NULL, NULL)
INSERT [dbo].[ChiTietChungTuBanHang] ([MaChiTietChungTuBanHang], [MaChungTuBanHang], [MaHang], [TKCongNo_ChiPhi], [TKDoanhThu], [SoLuong], [ThanhTien], [TienChietKhau], [TienThueGTGT]) VALUES (218, N'BH000046', N'000000000016', NULL, NULL, 1, 365000, NULL, NULL)
INSERT [dbo].[ChiTietChungTuBanHang] ([MaChiTietChungTuBanHang], [MaChungTuBanHang], [MaHang], [TKCongNo_ChiPhi], [TKDoanhThu], [SoLuong], [ThanhTien], [TienChietKhau], [TienThueGTGT]) VALUES (219, N'BH000046', N'000000000024', NULL, NULL, 1, 195000, NULL, NULL)
INSERT [dbo].[ChiTietChungTuBanHang] ([MaChiTietChungTuBanHang], [MaChungTuBanHang], [MaHang], [TKCongNo_ChiPhi], [TKDoanhThu], [SoLuong], [ThanhTien], [TienChietKhau], [TienThueGTGT]) VALUES (220, N'BH000047', N'000000000023', NULL, NULL, 1, 155000, NULL, NULL)
INSERT [dbo].[ChiTietChungTuBanHang] ([MaChiTietChungTuBanHang], [MaChungTuBanHang], [MaHang], [TKCongNo_ChiPhi], [TKDoanhThu], [SoLuong], [ThanhTien], [TienChietKhau], [TienThueGTGT]) VALUES (221, N'BH000047', N'000000000021', NULL, NULL, 1, 262000, NULL, NULL)
INSERT [dbo].[ChiTietChungTuBanHang] ([MaChiTietChungTuBanHang], [MaChungTuBanHang], [MaHang], [TKCongNo_ChiPhi], [TKDoanhThu], [SoLuong], [ThanhTien], [TienChietKhau], [TienThueGTGT]) VALUES (222, N'BH000048', N'000000000024', NULL, NULL, 1, 195000, NULL, NULL)
INSERT [dbo].[ChiTietChungTuBanHang] ([MaChiTietChungTuBanHang], [MaChungTuBanHang], [MaHang], [TKCongNo_ChiPhi], [TKDoanhThu], [SoLuong], [ThanhTien], [TienChietKhau], [TienThueGTGT]) VALUES (223, N'BH000048', N'000000000023', NULL, NULL, 1, 155000, NULL, NULL)
INSERT [dbo].[ChiTietChungTuBanHang] ([MaChiTietChungTuBanHang], [MaChungTuBanHang], [MaHang], [TKCongNo_ChiPhi], [TKDoanhThu], [SoLuong], [ThanhTien], [TienChietKhau], [TienThueGTGT]) VALUES (224, N'BH000048', N'000000000021', NULL, NULL, 1, 262000, NULL, NULL)
INSERT [dbo].[ChiTietChungTuBanHang] ([MaChiTietChungTuBanHang], [MaChungTuBanHang], [MaHang], [TKCongNo_ChiPhi], [TKDoanhThu], [SoLuong], [ThanhTien], [TienChietKhau], [TienThueGTGT]) VALUES (225, N'BH000048', N'000000000016', NULL, NULL, 1, 365000, NULL, NULL)
INSERT [dbo].[ChiTietChungTuBanHang] ([MaChiTietChungTuBanHang], [MaChungTuBanHang], [MaHang], [TKCongNo_ChiPhi], [TKDoanhThu], [SoLuong], [ThanhTien], [TienChietKhau], [TienThueGTGT]) VALUES (226, N'BH000049', N'000000000019', NULL, NULL, 1, 110000, NULL, NULL)
INSERT [dbo].[ChiTietChungTuBanHang] ([MaChiTietChungTuBanHang], [MaChungTuBanHang], [MaHang], [TKCongNo_ChiPhi], [TKDoanhThu], [SoLuong], [ThanhTien], [TienChietKhau], [TienThueGTGT]) VALUES (227, N'BH000049', N'000000000016', NULL, NULL, 1, 365000, NULL, NULL)
INSERT [dbo].[ChiTietChungTuBanHang] ([MaChiTietChungTuBanHang], [MaChungTuBanHang], [MaHang], [TKCongNo_ChiPhi], [TKDoanhThu], [SoLuong], [ThanhTien], [TienChietKhau], [TienThueGTGT]) VALUES (228, N'BH000049', N'000000000015', NULL, NULL, 1, 390000, NULL, NULL)
INSERT [dbo].[ChiTietChungTuBanHang] ([MaChiTietChungTuBanHang], [MaChungTuBanHang], [MaHang], [TKCongNo_ChiPhi], [TKDoanhThu], [SoLuong], [ThanhTien], [TienChietKhau], [TienThueGTGT]) VALUES (229, N'BH000049', N'000000000014', NULL, NULL, 1, 280000, NULL, NULL)
INSERT [dbo].[ChiTietChungTuBanHang] ([MaChiTietChungTuBanHang], [MaChungTuBanHang], [MaHang], [TKCongNo_ChiPhi], [TKDoanhThu], [SoLuong], [ThanhTien], [TienChietKhau], [TienThueGTGT]) VALUES (230, N'BH000050', N'000000000020', NULL, NULL, 1, 440000, NULL, NULL)
INSERT [dbo].[ChiTietChungTuBanHang] ([MaChiTietChungTuBanHang], [MaChungTuBanHang], [MaHang], [TKCongNo_ChiPhi], [TKDoanhThu], [SoLuong], [ThanhTien], [TienChietKhau], [TienThueGTGT]) VALUES (231, N'BH000050', N'000000000022', NULL, NULL, 1, 380000, NULL, NULL)
INSERT [dbo].[ChiTietChungTuBanHang] ([MaChiTietChungTuBanHang], [MaChungTuBanHang], [MaHang], [TKCongNo_ChiPhi], [TKDoanhThu], [SoLuong], [ThanhTien], [TienChietKhau], [TienThueGTGT]) VALUES (232, N'BH000050', N'000000000024', NULL, NULL, 1, 195000, NULL, NULL)
INSERT [dbo].[ChiTietChungTuBanHang] ([MaChiTietChungTuBanHang], [MaChungTuBanHang], [MaHang], [TKCongNo_ChiPhi], [TKDoanhThu], [SoLuong], [ThanhTien], [TienChietKhau], [TienThueGTGT]) VALUES (233, N'BH000050', N'000000000023', NULL, NULL, 1, 155000, NULL, NULL)
INSERT [dbo].[ChiTietChungTuBanHang] ([MaChiTietChungTuBanHang], [MaChungTuBanHang], [MaHang], [TKCongNo_ChiPhi], [TKDoanhThu], [SoLuong], [ThanhTien], [TienChietKhau], [TienThueGTGT]) VALUES (234, N'BH000052', N'000000000023', NULL, NULL, 2, 310000, NULL, NULL)
INSERT [dbo].[ChiTietChungTuBanHang] ([MaChiTietChungTuBanHang], [MaChungTuBanHang], [MaHang], [TKCongNo_ChiPhi], [TKDoanhThu], [SoLuong], [ThanhTien], [TienChietKhau], [TienThueGTGT]) VALUES (235, N'BH000052', N'000000000021', NULL, NULL, 3, 786000, NULL, NULL)
INSERT [dbo].[ChiTietChungTuBanHang] ([MaChiTietChungTuBanHang], [MaChungTuBanHang], [MaHang], [TKCongNo_ChiPhi], [TKDoanhThu], [SoLuong], [ThanhTien], [TienChietKhau], [TienThueGTGT]) VALUES (236, N'BH000052', N'000000000014', NULL, NULL, 2, 560000, NULL, NULL)
INSERT [dbo].[ChiTietChungTuBanHang] ([MaChiTietChungTuBanHang], [MaChungTuBanHang], [MaHang], [TKCongNo_ChiPhi], [TKDoanhThu], [SoLuong], [ThanhTien], [TienChietKhau], [TienThueGTGT]) VALUES (237, N'BH000052', N'000000000024', NULL, NULL, 1, 195000, NULL, NULL)
INSERT [dbo].[ChiTietChungTuBanHang] ([MaChiTietChungTuBanHang], [MaChungTuBanHang], [MaHang], [TKCongNo_ChiPhi], [TKDoanhThu], [SoLuong], [ThanhTien], [TienChietKhau], [TienThueGTGT]) VALUES (238, N'BH000053', N'000000000014', NULL, NULL, 2, 560000, NULL, NULL)
INSERT [dbo].[ChiTietChungTuBanHang] ([MaChiTietChungTuBanHang], [MaChungTuBanHang], [MaHang], [TKCongNo_ChiPhi], [TKDoanhThu], [SoLuong], [ThanhTien], [TienChietKhau], [TienThueGTGT]) VALUES (239, N'BH000053', N'000000000024', NULL, NULL, 1, 195000, NULL, NULL)
INSERT [dbo].[ChiTietChungTuBanHang] ([MaChiTietChungTuBanHang], [MaChungTuBanHang], [MaHang], [TKCongNo_ChiPhi], [TKDoanhThu], [SoLuong], [ThanhTien], [TienChietKhau], [TienThueGTGT]) VALUES (240, N'BH000054', N'000000000025', NULL, NULL, 1, 197000, NULL, NULL)
INSERT [dbo].[ChiTietChungTuBanHang] ([MaChiTietChungTuBanHang], [MaChungTuBanHang], [MaHang], [TKCongNo_ChiPhi], [TKDoanhThu], [SoLuong], [ThanhTien], [TienChietKhau], [TienThueGTGT]) VALUES (241, N'BH000054', N'000000000024', NULL, NULL, 1, 195000, NULL, NULL)
INSERT [dbo].[ChiTietChungTuBanHang] ([MaChiTietChungTuBanHang], [MaChungTuBanHang], [MaHang], [TKCongNo_ChiPhi], [TKDoanhThu], [SoLuong], [ThanhTien], [TienChietKhau], [TienThueGTGT]) VALUES (242, N'BH000055', N'000000000024', NULL, NULL, 1, 195000, NULL, NULL)
INSERT [dbo].[ChiTietChungTuBanHang] ([MaChiTietChungTuBanHang], [MaChungTuBanHang], [MaHang], [TKCongNo_ChiPhi], [TKDoanhThu], [SoLuong], [ThanhTien], [TienChietKhau], [TienThueGTGT]) VALUES (243, N'BH000056', N'000000000024', NULL, NULL, 1, 195000, NULL, NULL)
INSERT [dbo].[ChiTietChungTuBanHang] ([MaChiTietChungTuBanHang], [MaChungTuBanHang], [MaHang], [TKCongNo_ChiPhi], [TKDoanhThu], [SoLuong], [ThanhTien], [TienChietKhau], [TienThueGTGT]) VALUES (244, N'BH000056', N'000000000021', NULL, NULL, 2, 524000, NULL, NULL)
INSERT [dbo].[ChiTietChungTuBanHang] ([MaChiTietChungTuBanHang], [MaChungTuBanHang], [MaHang], [TKCongNo_ChiPhi], [TKDoanhThu], [SoLuong], [ThanhTien], [TienChietKhau], [TienThueGTGT]) VALUES (245, N'BH000056', N'000000000015', NULL, NULL, 1, 390000, NULL, NULL)
SET IDENTITY_INSERT [dbo].[ChiTietChungTuBanHang] OFF
SET IDENTITY_INSERT [dbo].[ChiTietChungTuMuaDichVu] ON 

INSERT [dbo].[ChiTietChungTuMuaDichVu] ([MaChiTietChungTuMuaDichVu], [MaChungTuMuaDichVu], [MaDichVu], [TKChiPhi_TKKho], [TKCongNo], [DoiTuong], [TenDoiTuong], [SoLuong], [ThanhTien]) VALUES (1, N'MDV000001', N'Dich_Vu_2', N'1', N'2', N'3', N'4', 14, 2184000)
INSERT [dbo].[ChiTietChungTuMuaDichVu] ([MaChiTietChungTuMuaDichVu], [MaChungTuMuaDichVu], [MaDichVu], [TKChiPhi_TKKho], [TKCongNo], [DoiTuong], [TenDoiTuong], [SoLuong], [ThanhTien]) VALUES (2, N'MDV000001', N'Dich_Vu_2', N'2', N'3', N'4', N'5', 17, 3315000)
INSERT [dbo].[ChiTietChungTuMuaDichVu] ([MaChiTietChungTuMuaDichVu], [MaChungTuMuaDichVu], [MaDichVu], [TKChiPhi_TKKho], [TKCongNo], [DoiTuong], [TenDoiTuong], [SoLuong], [ThanhTien]) VALUES (3, N'MDV000001', N'Dich_Vu_1', N'3', N'4', N'5', N'6', 14, 3920000)
INSERT [dbo].[ChiTietChungTuMuaDichVu] ([MaChiTietChungTuMuaDichVu], [MaChungTuMuaDichVu], [MaDichVu], [TKChiPhi_TKKho], [TKCongNo], [DoiTuong], [TenDoiTuong], [SoLuong], [ThanhTien]) VALUES (4, N'MDV000002', N'Dich_Vu_1', N'1', N'2', N'3', N'4', 25, 3900000)
INSERT [dbo].[ChiTietChungTuMuaDichVu] ([MaChiTietChungTuMuaDichVu], [MaChungTuMuaDichVu], [MaDichVu], [TKChiPhi_TKKho], [TKCongNo], [DoiTuong], [TenDoiTuong], [SoLuong], [ThanhTien]) VALUES (5, N'MDV000002', N'Dich_Vu_1', N'2', N'3', N'4', N'5', 13, 2535000)
INSERT [dbo].[ChiTietChungTuMuaDichVu] ([MaChiTietChungTuMuaDichVu], [MaChungTuMuaDichVu], [MaDichVu], [TKChiPhi_TKKho], [TKCongNo], [DoiTuong], [TenDoiTuong], [SoLuong], [ThanhTien]) VALUES (6, N'MDV000002', N'Dich_Vu_2', N'1', N'2', N'3', N'4', 16, 4480000)
INSERT [dbo].[ChiTietChungTuMuaDichVu] ([MaChiTietChungTuMuaDichVu], [MaChungTuMuaDichVu], [MaDichVu], [TKChiPhi_TKKho], [TKCongNo], [DoiTuong], [TenDoiTuong], [SoLuong], [ThanhTien]) VALUES (7, N'MDV000004', N'Dich_Vu_1', N'1', N'2', N'3', N'4', 11, 1716000)
INSERT [dbo].[ChiTietChungTuMuaDichVu] ([MaChiTietChungTuMuaDichVu], [MaChungTuMuaDichVu], [MaDichVu], [TKChiPhi_TKKho], [TKCongNo], [DoiTuong], [TenDoiTuong], [SoLuong], [ThanhTien]) VALUES (8, N'MDV000004', N'Dich_Vu_2', N'2', N'3', N'4', N'1', 13, 2535000)
SET IDENTITY_INSERT [dbo].[ChiTietChungTuMuaDichVu] OFF
SET IDENTITY_INSERT [dbo].[ChiTietChungTuMuaHang] ON 

INSERT [dbo].[ChiTietChungTuMuaHang] ([MaChiTietChungTuMuaHang], [MaChungTuMuaHang], [MaHang], [Kho], [TKKho], [TKCongNo], [SoLuong], [ThanhTien], [TienChietKhau], [ChiPhiMuaHang], [GiaTriNhapKho], [SoLo], [DoiTuongDHCP], [CongTrinh], [MaHopDongMua], [MaDonMuaHang], [MaThongKe]) VALUES (1, N'NK000001', N'000000000003', NULL, NULL, NULL, 1, 210000, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[ChiTietChungTuMuaHang] ([MaChiTietChungTuMuaHang], [MaChungTuMuaHang], [MaHang], [Kho], [TKKho], [TKCongNo], [SoLuong], [ThanhTien], [TienChietKhau], [ChiPhiMuaHang], [GiaTriNhapKho], [SoLo], [DoiTuongDHCP], [CongTrinh], [MaHopDongMua], [MaDonMuaHang], [MaThongKe]) VALUES (2, N'NK000002', N'000000000002', N'1', N'2', N'3', 1, 210000, 0, N'4', N'5', N'6', N'8', N'9', N'HĐM000002', N'ĐMH000001', N'10')
INSERT [dbo].[ChiTietChungTuMuaHang] ([MaChiTietChungTuMuaHang], [MaChungTuMuaHang], [MaHang], [Kho], [TKKho], [TKCongNo], [SoLuong], [ThanhTien], [TienChietKhau], [ChiPhiMuaHang], [GiaTriNhapKho], [SoLo], [DoiTuongDHCP], [CongTrinh], [MaHopDongMua], [MaDonMuaHang], [MaThongKe]) VALUES (3, NULL, N'000000000004', N'2', N'3', N'4', 2, 650000, 0, N'5', N'6', N'7', N'9', N'10', N'HĐM000001', N'ĐMH000002', N'11')
INSERT [dbo].[ChiTietChungTuMuaHang] ([MaChiTietChungTuMuaHang], [MaChungTuMuaHang], [MaHang], [Kho], [TKKho], [TKCongNo], [SoLuong], [ThanhTien], [TienChietKhau], [ChiPhiMuaHang], [GiaTriNhapKho], [SoLo], [DoiTuongDHCP], [CongTrinh], [MaHopDongMua], [MaDonMuaHang], [MaThongKe]) VALUES (4, NULL, N'000000000002', N'1', N'2', N'3', 14, 2940000, 0, N'5', N'6', N'7', N'9', N'10', N'HĐM000002', N'ĐMH000001', N'11')
INSERT [dbo].[ChiTietChungTuMuaHang] ([MaChiTietChungTuMuaHang], [MaChungTuMuaHang], [MaHang], [Kho], [TKKho], [TKCongNo], [SoLuong], [ThanhTien], [TienChietKhau], [ChiPhiMuaHang], [GiaTriNhapKho], [SoLo], [DoiTuongDHCP], [CongTrinh], [MaHopDongMua], [MaDonMuaHang], [MaThongKe]) VALUES (5, NULL, N'000000000003', N'23', N'3', N'4', 15, 3150000, 0, N'6', N'17', N'8', N'10', N'44', N'HĐM000001', N'ĐMH000004', N'45')
INSERT [dbo].[ChiTietChungTuMuaHang] ([MaChiTietChungTuMuaHang], [MaChungTuMuaHang], [MaHang], [Kho], [TKKho], [TKCongNo], [SoLuong], [ThanhTien], [TienChietKhau], [ChiPhiMuaHang], [GiaTriNhapKho], [SoLo], [DoiTuongDHCP], [CongTrinh], [MaHopDongMua], [MaDonMuaHang], [MaThongKe]) VALUES (6, N'NK000004', N'000000000002', N'1', N'2', N'3', 3, 630000, 0, NULL, N'0', NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[ChiTietChungTuMuaHang] ([MaChiTietChungTuMuaHang], [MaChungTuMuaHang], [MaHang], [Kho], [TKKho], [TKCongNo], [SoLuong], [ThanhTien], [TienChietKhau], [ChiPhiMuaHang], [GiaTriNhapKho], [SoLo], [DoiTuongDHCP], [CongTrinh], [MaHopDongMua], [MaDonMuaHang], [MaThongKe]) VALUES (7, N'NK000005', N'000000000002', N'1', N'1', N'1', 1, 210000, 0, N'1', N'1', N'1', N'1', N'1', N'HĐM000002', N'ĐMH000001', N'1')
SET IDENTITY_INSERT [dbo].[ChiTietChungTuMuaHang] OFF
SET IDENTITY_INSERT [dbo].[ChiTietDonDatHang] ON 

INSERT [dbo].[ChiTietDonDatHang] ([MaChiTietDonDatHang], [MaDonDatHang], [MaHang], [SoLuong], [SoLuongDaGiao], [ThanhTien], [TienThueGTGT]) VALUES (1, N'ĐH000001', N'000000000002', 3, 2, 630000, 105000)
INSERT [dbo].[ChiTietDonDatHang] ([MaChiTietDonDatHang], [MaDonDatHang], [MaHang], [SoLuong], [SoLuongDaGiao], [ThanhTien], [TienThueGTGT]) VALUES (2, N'ĐH000001', N'000000000003', 6, 4, 1260000, 210000)
INSERT [dbo].[ChiTietDonDatHang] ([MaChiTietDonDatHang], [MaDonDatHang], [MaHang], [SoLuong], [SoLuongDaGiao], [ThanhTien], [TienThueGTGT]) VALUES (3, N'ĐH000001', N'000000000004', 3, 5, 975000, 225000)
INSERT [dbo].[ChiTietDonDatHang] ([MaChiTietDonDatHang], [MaDonDatHang], [MaHang], [SoLuong], [SoLuongDaGiao], [ThanhTien], [TienThueGTGT]) VALUES (4, N'ĐH000002', N'000000000002', 12, 3, 2520000, 420000)
INSERT [dbo].[ChiTietDonDatHang] ([MaChiTietDonDatHang], [MaDonDatHang], [MaHang], [SoLuong], [SoLuongDaGiao], [ThanhTien], [TienThueGTGT]) VALUES (5, N'ĐH000002', N'000000000003', 11, 2, 2310000, 385000)
INSERT [dbo].[ChiTietDonDatHang] ([MaChiTietDonDatHang], [MaDonDatHang], [MaHang], [SoLuong], [SoLuongDaGiao], [ThanhTien], [TienThueGTGT]) VALUES (6, N'ĐH000002', N'000000000004', 12, 3, 3900000, 900000)
INSERT [dbo].[ChiTietDonDatHang] ([MaChiTietDonDatHang], [MaDonDatHang], [MaHang], [SoLuong], [SoLuongDaGiao], [ThanhTien], [TienThueGTGT]) VALUES (7, NULL, N'000000000002', 3, 1, 630000, 105000)
INSERT [dbo].[ChiTietDonDatHang] ([MaChiTietDonDatHang], [MaDonDatHang], [MaHang], [SoLuong], [SoLuongDaGiao], [ThanhTien], [TienThueGTGT]) VALUES (8, NULL, N'000000000003', 4, 2, 840000, 140000)
INSERT [dbo].[ChiTietDonDatHang] ([MaChiTietDonDatHang], [MaDonDatHang], [MaHang], [SoLuong], [SoLuongDaGiao], [ThanhTien], [TienThueGTGT]) VALUES (9, N'ĐH000004', N'000000000002', 21, 1, 4410000, 735000)
INSERT [dbo].[ChiTietDonDatHang] ([MaChiTietDonDatHang], [MaDonDatHang], [MaHang], [SoLuong], [SoLuongDaGiao], [ThanhTien], [TienThueGTGT]) VALUES (10, N'ĐH000004', N'000000000003', 13, 3, 2730000, 455000)
INSERT [dbo].[ChiTietDonDatHang] ([MaChiTietDonDatHang], [MaDonDatHang], [MaHang], [SoLuong], [SoLuongDaGiao], [ThanhTien], [TienThueGTGT]) VALUES (11, N'ĐH000004', N'000000000004', 11, 4, 3575000, 825000)
INSERT [dbo].[ChiTietDonDatHang] ([MaChiTietDonDatHang], [MaDonDatHang], [MaHang], [SoLuong], [SoLuongDaGiao], [ThanhTien], [TienThueGTGT]) VALUES (12, N'ĐH000005', N'000000000002', 25, NULL, 5250000, 875000)
INSERT [dbo].[ChiTietDonDatHang] ([MaChiTietDonDatHang], [MaDonDatHang], [MaHang], [SoLuong], [SoLuongDaGiao], [ThanhTien], [TienThueGTGT]) VALUES (13, N'ĐH000005', N'000000000003', 13, NULL, 2730000, 455000)
INSERT [dbo].[ChiTietDonDatHang] ([MaChiTietDonDatHang], [MaDonDatHang], [MaHang], [SoLuong], [SoLuongDaGiao], [ThanhTien], [TienThueGTGT]) VALUES (14, N'ĐH000005', N'000000000004', 11, NULL, 3575000, 825000)
INSERT [dbo].[ChiTietDonDatHang] ([MaChiTietDonDatHang], [MaDonDatHang], [MaHang], [SoLuong], [SoLuongDaGiao], [ThanhTien], [TienThueGTGT]) VALUES (15, N'ĐH000006', N'000000000002', 21, 20, 4410000, 735000)
INSERT [dbo].[ChiTietDonDatHang] ([MaChiTietDonDatHang], [MaDonDatHang], [MaHang], [SoLuong], [SoLuongDaGiao], [ThanhTien], [TienThueGTGT]) VALUES (16, N'ĐH000006', N'000000000003', 13, 3, 2730000, 455000)
INSERT [dbo].[ChiTietDonDatHang] ([MaChiTietDonDatHang], [MaDonDatHang], [MaHang], [SoLuong], [SoLuongDaGiao], [ThanhTien], [TienThueGTGT]) VALUES (17, N'ĐH000006', N'000000000004', 11, 4, 3575000, 825000)
INSERT [dbo].[ChiTietDonDatHang] ([MaChiTietDonDatHang], [MaDonDatHang], [MaHang], [SoLuong], [SoLuongDaGiao], [ThanhTien], [TienThueGTGT]) VALUES (18, N'ĐH000007', N'000000000002', 3, NULL, 630000, 105000)
INSERT [dbo].[ChiTietDonDatHang] ([MaChiTietDonDatHang], [MaDonDatHang], [MaHang], [SoLuong], [SoLuongDaGiao], [ThanhTien], [TienThueGTGT]) VALUES (19, N'ĐH000007', N'000000000003', 4, NULL, 840000, 140000)
INSERT [dbo].[ChiTietDonDatHang] ([MaChiTietDonDatHang], [MaDonDatHang], [MaHang], [SoLuong], [SoLuongDaGiao], [ThanhTien], [TienThueGTGT]) VALUES (20, N'ĐH000008', N'000000000002', 21, NULL, 4410000, 735000)
INSERT [dbo].[ChiTietDonDatHang] ([MaChiTietDonDatHang], [MaDonDatHang], [MaHang], [SoLuong], [SoLuongDaGiao], [ThanhTien], [TienThueGTGT]) VALUES (21, N'ĐH000008', N'000000000003', 13, NULL, 2730000, 455000)
INSERT [dbo].[ChiTietDonDatHang] ([MaChiTietDonDatHang], [MaDonDatHang], [MaHang], [SoLuong], [SoLuongDaGiao], [ThanhTien], [TienThueGTGT]) VALUES (22, N'ĐH000008', N'000000000004', 11, NULL, 3575000, 825000)
INSERT [dbo].[ChiTietDonDatHang] ([MaChiTietDonDatHang], [MaDonDatHang], [MaHang], [SoLuong], [SoLuongDaGiao], [ThanhTien], [TienThueGTGT]) VALUES (23, N'ĐH000009', N'000000000002', 21, NULL, 4410000, 735000)
INSERT [dbo].[ChiTietDonDatHang] ([MaChiTietDonDatHang], [MaDonDatHang], [MaHang], [SoLuong], [SoLuongDaGiao], [ThanhTien], [TienThueGTGT]) VALUES (24, N'ĐH000009', N'000000000003', 13, NULL, 2730000, 455000)
INSERT [dbo].[ChiTietDonDatHang] ([MaChiTietDonDatHang], [MaDonDatHang], [MaHang], [SoLuong], [SoLuongDaGiao], [ThanhTien], [TienThueGTGT]) VALUES (25, N'ĐH000009', N'000000000004', 11, NULL, 3575000, 825000)
INSERT [dbo].[ChiTietDonDatHang] ([MaChiTietDonDatHang], [MaDonDatHang], [MaHang], [SoLuong], [SoLuongDaGiao], [ThanhTien], [TienThueGTGT]) VALUES (26, N'ĐH000010', N'000000000002', 21, NULL, 4410000, 735000)
INSERT [dbo].[ChiTietDonDatHang] ([MaChiTietDonDatHang], [MaDonDatHang], [MaHang], [SoLuong], [SoLuongDaGiao], [ThanhTien], [TienThueGTGT]) VALUES (27, N'ĐH000010', N'000000000003', 13, NULL, 2730000, 455000)
INSERT [dbo].[ChiTietDonDatHang] ([MaChiTietDonDatHang], [MaDonDatHang], [MaHang], [SoLuong], [SoLuongDaGiao], [ThanhTien], [TienThueGTGT]) VALUES (28, N'ĐH000010', N'000000000004', 11, NULL, 3575000, 825000)
INSERT [dbo].[ChiTietDonDatHang] ([MaChiTietDonDatHang], [MaDonDatHang], [MaHang], [SoLuong], [SoLuongDaGiao], [ThanhTien], [TienThueGTGT]) VALUES (29, N'ĐH000011', N'000000000002', 21, NULL, 4410000, 735000)
INSERT [dbo].[ChiTietDonDatHang] ([MaChiTietDonDatHang], [MaDonDatHang], [MaHang], [SoLuong], [SoLuongDaGiao], [ThanhTien], [TienThueGTGT]) VALUES (30, N'ĐH000011', N'000000000003', 13, NULL, 2730000, 455000)
INSERT [dbo].[ChiTietDonDatHang] ([MaChiTietDonDatHang], [MaDonDatHang], [MaHang], [SoLuong], [SoLuongDaGiao], [ThanhTien], [TienThueGTGT]) VALUES (31, N'ĐH000011', N'000000000004', 11, NULL, 3575000, 825000)
SET IDENTITY_INSERT [dbo].[ChiTietDonDatHang] OFF
SET IDENTITY_INSERT [dbo].[ChiTietDonMuaHang] ON 

INSERT [dbo].[ChiTietDonMuaHang] ([MaCTDMH], [MaDonMuaHang], [MaHang], [SoLuong], [SoLuongNhan], [DonGia], [ThanhTien], [ThueGTGT], [TienThueGTGT], [LenhSanXuat], [ThanhPham]) VALUES (5, N'ĐMH000004', N'000000000002', 2, 1, 175000, 420000, 0.2, 70000, N'a', N'v')
INSERT [dbo].[ChiTietDonMuaHang] ([MaCTDMH], [MaDonMuaHang], [MaHang], [SoLuong], [SoLuongNhan], [DonGia], [ThanhTien], [ThueGTGT], [TienThueGTGT], [LenhSanXuat], [ThanhPham]) VALUES (6, N'ĐMH000004', N'000000000003', 3, NULL, 175000, 630000, 0.2, 105000, N'c', N'd')
INSERT [dbo].[ChiTietDonMuaHang] ([MaCTDMH], [MaDonMuaHang], [MaHang], [SoLuong], [SoLuongNhan], [DonGia], [ThanhTien], [ThueGTGT], [TienThueGTGT], [LenhSanXuat], [ThanhPham]) VALUES (7, N'ĐMH000005', N'000000000002', 2, 1, 175000, 420000, 0.2, 70000, N'a', N'b')
INSERT [dbo].[ChiTietDonMuaHang] ([MaCTDMH], [MaDonMuaHang], [MaHang], [SoLuong], [SoLuongNhan], [DonGia], [ThanhTien], [ThueGTGT], [TienThueGTGT], [LenhSanXuat], [ThanhPham]) VALUES (8, N'ĐMH000005', N'000000000003', 1, 1, 175000, 210000, 0.2, 35000, N'c', N'd')
INSERT [dbo].[ChiTietDonMuaHang] ([MaCTDMH], [MaDonMuaHang], [MaHang], [SoLuong], [SoLuongNhan], [DonGia], [ThanhTien], [ThueGTGT], [TienThueGTGT], [LenhSanXuat], [ThanhPham]) VALUES (9, N'ĐMH000006', N'000000000002', 3, 3, 175000, 630000, 0.2, 105000, N'lenh sx', N'Thành phẩm')
INSERT [dbo].[ChiTietDonMuaHang] ([MaCTDMH], [MaDonMuaHang], [MaHang], [SoLuong], [SoLuongNhan], [DonGia], [ThanhTien], [ThueGTGT], [TienThueGTGT], [LenhSanXuat], [ThanhPham]) VALUES (10, N'ĐMH000006', N'000000000003', 7, 5, 175000, 1470000, 0.2, 245000, N'a', N'b')
INSERT [dbo].[ChiTietDonMuaHang] ([MaCTDMH], [MaDonMuaHang], [MaHang], [SoLuong], [SoLuongNhan], [DonGia], [ThanhTien], [ThueGTGT], [TienThueGTGT], [LenhSanXuat], [ThanhPham]) VALUES (11, N'ĐMH000007', N'000000000002', 2, 3, 175000, 420000, 0.2, 70000, NULL, NULL)
INSERT [dbo].[ChiTietDonMuaHang] ([MaCTDMH], [MaDonMuaHang], [MaHang], [SoLuong], [SoLuongNhan], [DonGia], [ThanhTien], [ThueGTGT], [TienThueGTGT], [LenhSanXuat], [ThanhPham]) VALUES (12, N'ĐMH000007', N'000000000003', 1, 1, 175000, 210000, 0.2, 35000, NULL, NULL)
INSERT [dbo].[ChiTietDonMuaHang] ([MaCTDMH], [MaDonMuaHang], [MaHang], [SoLuong], [SoLuongNhan], [DonGia], [ThanhTien], [ThueGTGT], [TienThueGTGT], [LenhSanXuat], [ThanhPham]) VALUES (13, N'ĐMH000008', N'000000000002', 2, 1, 175000, 420000, 0.2, 70000, NULL, NULL)
SET IDENTITY_INSERT [dbo].[ChiTietDonMuaHang] OFF
SET IDENTITY_INSERT [dbo].[ChiTietGiamGiaHangBan] ON 

INSERT [dbo].[ChiTietGiamGiaHangBan] ([MaChiTietGiamGiaHangBan], [MaGiamGiaHangBan], [MaHang], [TKGiamGia], [TKTien], [SoLuong], [ThanhTien], [TienChietKhau], [TienThueGTGT]) VALUES (1, N'BGG000001', N'000000000002', N'2', N'3', 13, 2730000, 0, 455000)
INSERT [dbo].[ChiTietGiamGiaHangBan] ([MaChiTietGiamGiaHangBan], [MaGiamGiaHangBan], [MaHang], [TKGiamGia], [TKTien], [SoLuong], [ThanhTien], [TienChietKhau], [TienThueGTGT]) VALUES (2, N'BGG000001', N'000000000003', N'4', N'5', 15, 3150000, 0, 525000)
INSERT [dbo].[ChiTietGiamGiaHangBan] ([MaChiTietGiamGiaHangBan], [MaGiamGiaHangBan], [MaHang], [TKGiamGia], [TKTien], [SoLuong], [ThanhTien], [TienChietKhau], [TienThueGTGT]) VALUES (3, N'BGG000002', N'000000000004', N'2', N'3', 132, 42900000, 0, 9900000)
INSERT [dbo].[ChiTietGiamGiaHangBan] ([MaChiTietGiamGiaHangBan], [MaGiamGiaHangBan], [MaHang], [TKGiamGia], [TKTien], [SoLuong], [ThanhTien], [TienChietKhau], [TienThueGTGT]) VALUES (4, N'BGG000002', N'000000000002', N'231', N'32', 13, 2730000, 0, 455000)
INSERT [dbo].[ChiTietGiamGiaHangBan] ([MaChiTietGiamGiaHangBan], [MaGiamGiaHangBan], [MaHang], [TKGiamGia], [TKTien], [SoLuong], [ThanhTien], [TienChietKhau], [TienThueGTGT]) VALUES (5, N'BGG000002', N'000000000003', N'123', N'432', 134, 28140000, 0, 4690000)
INSERT [dbo].[ChiTietGiamGiaHangBan] ([MaChiTietGiamGiaHangBan], [MaGiamGiaHangBan], [MaHang], [TKGiamGia], [TKTien], [SoLuong], [ThanhTien], [TienChietKhau], [TienThueGTGT]) VALUES (6, N'BGG000003', N'000000000003', N'21231', N'12313', 123, 25830000, 0, 4305000)
INSERT [dbo].[ChiTietGiamGiaHangBan] ([MaChiTietGiamGiaHangBan], [MaGiamGiaHangBan], [MaHang], [TKGiamGia], [TKTien], [SoLuong], [ThanhTien], [TienChietKhau], [TienThueGTGT]) VALUES (7, N'BGG000003', N'000000000002', N'213', N'12313', 13, 2730000, 0, 455000)
INSERT [dbo].[ChiTietGiamGiaHangBan] ([MaChiTietGiamGiaHangBan], [MaGiamGiaHangBan], [MaHang], [TKGiamGia], [TKTien], [SoLuong], [ThanhTien], [TienChietKhau], [TienThueGTGT]) VALUES (8, N'BGG000003', N'000000000004', N'1231', N'12313', 15, 4875000, 0, 1125000)
INSERT [dbo].[ChiTietGiamGiaHangBan] ([MaChiTietGiamGiaHangBan], [MaGiamGiaHangBan], [MaHang], [TKGiamGia], [TKTien], [SoLuong], [ThanhTien], [TienChietKhau], [TienThueGTGT]) VALUES (9, N'BGG000004', N'000000000002', N'123', N'123', 22, NULL, 0, 770000)
INSERT [dbo].[ChiTietGiamGiaHangBan] ([MaChiTietGiamGiaHangBan], [MaGiamGiaHangBan], [MaHang], [TKGiamGia], [TKTien], [SoLuong], [ThanhTien], [TienChietKhau], [TienThueGTGT]) VALUES (10, N'BGG000004', N'000000000003', N'124', N'547', 12, 2520000, 0, 420000)
INSERT [dbo].[ChiTietGiamGiaHangBan] ([MaChiTietGiamGiaHangBan], [MaGiamGiaHangBan], [MaHang], [TKGiamGia], [TKTien], [SoLuong], [ThanhTien], [TienChietKhau], [TienThueGTGT]) VALUES (11, N'BGG000004', N'000000000004', N'768', N'6786', 13, 4225000, 0, 975000)
INSERT [dbo].[ChiTietGiamGiaHangBan] ([MaChiTietGiamGiaHangBan], [MaGiamGiaHangBan], [MaHang], [TKGiamGia], [TKTien], [SoLuong], [ThanhTien], [TienChietKhau], [TienThueGTGT]) VALUES (12, N'BGG000005', N'000000000002', N'2', N'3', 3, 630000, 0, 105000)
INSERT [dbo].[ChiTietGiamGiaHangBan] ([MaChiTietGiamGiaHangBan], [MaGiamGiaHangBan], [MaHang], [TKGiamGia], [TKTien], [SoLuong], [ThanhTien], [TienChietKhau], [TienThueGTGT]) VALUES (13, N'BGG000005', N'000000000003', N'4', N'5', 4, 840000, 0, 140000)
SET IDENTITY_INSERT [dbo].[ChiTietGiamGiaHangBan] OFF
SET IDENTITY_INSERT [dbo].[ChiTietGiamGiaHangMua] ON 

INSERT [dbo].[ChiTietGiamGiaHangMua] ([MaChiTietGiamGiaHangMua], [MaGiamGiaHangMua], [MaHang], [Kho], [TKKho], [TKCongNo], [SoLuong], [ThanhTien], [DienGiaiThue], [TienThueGTGT], [TKThueGTGT], [NhomHHDVMuaVao], [SoLo], [SoCTMuaHang], [SoHDMuaHang], [NgayHDMuaHang], [MaHopDongMua], [MaThongKe]) VALUES (1, N'MGG000001', N'QUAN_AU', N'1', N'2', N'3', 1, 210000, N'4', 35000, N'5', N'6', N'7', N'8', N'9', N'10', N'HĐM000001', N'11')
INSERT [dbo].[ChiTietGiamGiaHangMua] ([MaChiTietGiamGiaHangMua], [MaGiamGiaHangMua], [MaHang], [Kho], [TKKho], [TKCongNo], [SoLuong], [ThanhTien], [DienGiaiThue], [TienThueGTGT], [TKThueGTGT], [NhomHHDVMuaVao], [SoLo], [SoCTMuaHang], [SoHDMuaHang], [NgayHDMuaHang], [MaHopDongMua], [MaThongKe]) VALUES (2, N'MGG000001', N'quan-the-thao', N'2', N'3', N'4', 1, 210000, N'6', 35000, N'7', N'8', N'9', N'10', N'11', N'12', N'HĐM000002', N'13')
INSERT [dbo].[ChiTietGiamGiaHangMua] ([MaChiTietGiamGiaHangMua], [MaGiamGiaHangMua], [MaHang], [Kho], [TKKho], [TKCongNo], [SoLuong], [ThanhTien], [DienGiaiThue], [TienThueGTGT], [TKThueGTGT], [NhomHHDVMuaVao], [SoLo], [SoCTMuaHang], [SoHDMuaHang], [NgayHDMuaHang], [MaHopDongMua], [MaThongKe]) VALUES (3, N'MGG000002', N'QUAN_AU', N'1', N'2', N'3', 1, 210000, N'4', 35000, N'5', N'6', N'7', N'8', N'9', N'10', N'HĐM000001', N'11')
INSERT [dbo].[ChiTietGiamGiaHangMua] ([MaChiTietGiamGiaHangMua], [MaGiamGiaHangMua], [MaHang], [Kho], [TKKho], [TKCongNo], [SoLuong], [ThanhTien], [DienGiaiThue], [TienThueGTGT], [TKThueGTGT], [NhomHHDVMuaVao], [SoLo], [SoCTMuaHang], [SoHDMuaHang], [NgayHDMuaHang], [MaHopDongMua], [MaThongKe]) VALUES (4, N'MGG000002', N'quan-the-thao', N'2', N'3', N'4', 1, 210000, N'6', 35000, N'7', N'8', N'9', N'10', N'11', N'12', N'HĐM000002', N'13')
INSERT [dbo].[ChiTietGiamGiaHangMua] ([MaChiTietGiamGiaHangMua], [MaGiamGiaHangMua], [MaHang], [Kho], [TKKho], [TKCongNo], [SoLuong], [ThanhTien], [DienGiaiThue], [TienThueGTGT], [TKThueGTGT], [NhomHHDVMuaVao], [SoLo], [SoCTMuaHang], [SoHDMuaHang], [NgayHDMuaHang], [MaHopDongMua], [MaThongKe]) VALUES (5, N'MGG000003', N'QUAN_AU', N'1', N'2', N'3', 1, 210000, N'4', 35000, N'5', N'6', N'7', N'8', N'9', N'10', N'HĐM000001', N'11')
INSERT [dbo].[ChiTietGiamGiaHangMua] ([MaChiTietGiamGiaHangMua], [MaGiamGiaHangMua], [MaHang], [Kho], [TKKho], [TKCongNo], [SoLuong], [ThanhTien], [DienGiaiThue], [TienThueGTGT], [TKThueGTGT], [NhomHHDVMuaVao], [SoLo], [SoCTMuaHang], [SoHDMuaHang], [NgayHDMuaHang], [MaHopDongMua], [MaThongKe]) VALUES (6, N'MGG000003', N'quan-the-thao', N'2', N'3', N'4', 1, 210000, N'6', 35000, N'7', N'8', N'9', N'10', N'11', N'12', N'HĐM000002', N'13')
INSERT [dbo].[ChiTietGiamGiaHangMua] ([MaChiTietGiamGiaHangMua], [MaGiamGiaHangMua], [MaHang], [Kho], [TKKho], [TKCongNo], [SoLuong], [ThanhTien], [DienGiaiThue], [TienThueGTGT], [TKThueGTGT], [NhomHHDVMuaVao], [SoLo], [SoCTMuaHang], [SoHDMuaHang], [NgayHDMuaHang], [MaHopDongMua], [MaThongKe]) VALUES (7, N'MGG000004', N'QUAN_AU', N'1', N'2', N'3', 1, 210000, N'4', 35000, N'5', N'6', N'7', N'8', N'9', N'10', N'HĐM000001', N'11')
INSERT [dbo].[ChiTietGiamGiaHangMua] ([MaChiTietGiamGiaHangMua], [MaGiamGiaHangMua], [MaHang], [Kho], [TKKho], [TKCongNo], [SoLuong], [ThanhTien], [DienGiaiThue], [TienThueGTGT], [TKThueGTGT], [NhomHHDVMuaVao], [SoLo], [SoCTMuaHang], [SoHDMuaHang], [NgayHDMuaHang], [MaHopDongMua], [MaThongKe]) VALUES (8, N'MGG000004', N'quan-the-thao', N'2', N'3', N'4', 1, 210000, N'6', 35000, N'7', N'8', N'9', N'10', N'11', N'12', N'HĐM000002', N'13')
SET IDENTITY_INSERT [dbo].[ChiTietGiamGiaHangMua] OFF
SET IDENTITY_INSERT [dbo].[ChiTietHoaDon_BanHang] ON 

INSERT [dbo].[ChiTietHoaDon_BanHang] ([MaChiTietHoaDonBanHang], [MaHoaDon], [MaHang], [TKCongNo_ChiPhi], [TKDoanhThu], [SoLuong], [ThanhTien], [TienChietKhau], [TienThueGTGT]) VALUES (5, N'000001', N'000000000003', N'2', N'3', 144, 30240000, 0, 5040000)
INSERT [dbo].[ChiTietHoaDon_BanHang] ([MaChiTietHoaDonBanHang], [MaHoaDon], [MaHang], [TKCongNo_ChiPhi], [TKDoanhThu], [SoLuong], [ThanhTien], [TienChietKhau], [TienThueGTGT]) VALUES (6, N'000001', N'000000000004', N'3', N'7', 15, 4875000, 0, 1125000)
INSERT [dbo].[ChiTietHoaDon_BanHang] ([MaChiTietHoaDonBanHang], [MaHoaDon], [MaHang], [TKCongNo_ChiPhi], [TKDoanhThu], [SoLuong], [ThanhTien], [TienChietKhau], [TienThueGTGT]) VALUES (7, N'000002', N'000000000002', N'3', N'23', 33, 6930000, 0, 1155000)
INSERT [dbo].[ChiTietHoaDon_BanHang] ([MaChiTietHoaDonBanHang], [MaHoaDon], [MaHang], [TKCongNo_ChiPhi], [TKDoanhThu], [SoLuong], [ThanhTien], [TienChietKhau], [TienThueGTGT]) VALUES (8, N'000002', N'000000000004', N'2', N'3', 15, 4875000, 0, 1125000)
INSERT [dbo].[ChiTietHoaDon_BanHang] ([MaChiTietHoaDonBanHang], [MaHoaDon], [MaHang], [TKCongNo_ChiPhi], [TKDoanhThu], [SoLuong], [ThanhTien], [TienChietKhau], [TienThueGTGT]) VALUES (9, N'000003', N'000000000002', N'2', N'123', 1123, 235830000, 0, 39305000)
INSERT [dbo].[ChiTietHoaDon_BanHang] ([MaChiTietHoaDonBanHang], [MaHoaDon], [MaHang], [TKCongNo_ChiPhi], [TKDoanhThu], [SoLuong], [ThanhTien], [TienChietKhau], [TienThueGTGT]) VALUES (10, N'000003', N'000000000004', N'123', N'123', 1123, 364975000, 0, 84225000)
INSERT [dbo].[ChiTietHoaDon_BanHang] ([MaChiTietHoaDonBanHang], [MaHoaDon], [MaHang], [TKCongNo_ChiPhi], [TKDoanhThu], [SoLuong], [ThanhTien], [TienChietKhau], [TienThueGTGT]) VALUES (11, N'000004', N'000000000003', NULL, NULL, 123, 25830000, 0, 4305000)
INSERT [dbo].[ChiTietHoaDon_BanHang] ([MaChiTietHoaDonBanHang], [MaHoaDon], [MaHang], [TKCongNo_ChiPhi], [TKDoanhThu], [SoLuong], [ThanhTien], [TienChietKhau], [TienThueGTGT]) VALUES (12, N'000004', N'000000000004', NULL, NULL, 14, 4550000, 0, 1050000)
INSERT [dbo].[ChiTietHoaDon_BanHang] ([MaChiTietHoaDonBanHang], [MaHoaDon], [MaHang], [TKCongNo_ChiPhi], [TKDoanhThu], [SoLuong], [ThanhTien], [TienChietKhau], [TienThueGTGT]) VALUES (13, N'000005', N'000000000003', NULL, NULL, 12, 2520000, 0, 420000)
INSERT [dbo].[ChiTietHoaDon_BanHang] ([MaChiTietHoaDonBanHang], [MaHoaDon], [MaHang], [TKCongNo_ChiPhi], [TKDoanhThu], [SoLuong], [ThanhTien], [TienChietKhau], [TienThueGTGT]) VALUES (14, N'000005', N'000000000002', NULL, NULL, 14, 2940000, 0, 490000)
INSERT [dbo].[ChiTietHoaDon_BanHang] ([MaChiTietHoaDonBanHang], [MaHoaDon], [MaHang], [TKCongNo_ChiPhi], [TKDoanhThu], [SoLuong], [ThanhTien], [TienChietKhau], [TienThueGTGT]) VALUES (15, N'000006', N'000000000004', NULL, NULL, 44, 14300000, 0, 3300000)
INSERT [dbo].[ChiTietHoaDon_BanHang] ([MaChiTietHoaDonBanHang], [MaHoaDon], [MaHang], [TKCongNo_ChiPhi], [TKDoanhThu], [SoLuong], [ThanhTien], [TienChietKhau], [TienThueGTGT]) VALUES (16, N'000007', N'000000000003', NULL, NULL, 213, 44730000, 0, 7455000)
INSERT [dbo].[ChiTietHoaDon_BanHang] ([MaChiTietHoaDonBanHang], [MaHoaDon], [MaHang], [TKCongNo_ChiPhi], [TKDoanhThu], [SoLuong], [ThanhTien], [TienChietKhau], [TienThueGTGT]) VALUES (17, N'000007', N'000000000004', NULL, NULL, 11, 3575000, 0, 825000)
INSERT [dbo].[ChiTietHoaDon_BanHang] ([MaChiTietHoaDonBanHang], [MaHoaDon], [MaHang], [TKCongNo_ChiPhi], [TKDoanhThu], [SoLuong], [ThanhTien], [TienChietKhau], [TienThueGTGT]) VALUES (18, N'000008', N'000000000002', NULL, NULL, 4, 840000, 0, 140000)
INSERT [dbo].[ChiTietHoaDon_BanHang] ([MaChiTietHoaDonBanHang], [MaHoaDon], [MaHang], [TKCongNo_ChiPhi], [TKDoanhThu], [SoLuong], [ThanhTien], [TienChietKhau], [TienThueGTGT]) VALUES (19, N'000008', N'000000000003', NULL, NULL, 3, 630000, 0, 105000)
INSERT [dbo].[ChiTietHoaDon_BanHang] ([MaChiTietHoaDonBanHang], [MaHoaDon], [MaHang], [TKCongNo_ChiPhi], [TKDoanhThu], [SoLuong], [ThanhTien], [TienChietKhau], [TienThueGTGT]) VALUES (20, N'000009', N'000000000002', N'2', N'3', 43, 9030000, 0, 1505000)
INSERT [dbo].[ChiTietHoaDon_BanHang] ([MaChiTietHoaDonBanHang], [MaHoaDon], [MaHang], [TKCongNo_ChiPhi], [TKDoanhThu], [SoLuong], [ThanhTien], [TienChietKhau], [TienThueGTGT]) VALUES (21, N'000009', N'000000000003', N'3', N'4', 14, 2940000, 0, 490000)
INSERT [dbo].[ChiTietHoaDon_BanHang] ([MaChiTietHoaDonBanHang], [MaHoaDon], [MaHang], [TKCongNo_ChiPhi], [TKDoanhThu], [SoLuong], [ThanhTien], [TienChietKhau], [TienThueGTGT]) VALUES (22, N'000009', N'000000000004', N'5', N'6', 15, 4875000, 0, 1125000)
INSERT [dbo].[ChiTietHoaDon_BanHang] ([MaChiTietHoaDonBanHang], [MaHoaDon], [MaHang], [TKCongNo_ChiPhi], [TKDoanhThu], [SoLuong], [ThanhTien], [TienChietKhau], [TienThueGTGT]) VALUES (23, N'000010', N'000000000002', N'2', N'3', 16, 3360000, 0, 560000)
INSERT [dbo].[ChiTietHoaDon_BanHang] ([MaChiTietHoaDonBanHang], [MaHoaDon], [MaHang], [TKCongNo_ChiPhi], [TKDoanhThu], [SoLuong], [ThanhTien], [TienChietKhau], [TienThueGTGT]) VALUES (24, N'000010', N'000000000003', N'4', N'5', 17, 3570000, 0, 595000)
INSERT [dbo].[ChiTietHoaDon_BanHang] ([MaChiTietHoaDonBanHang], [MaHoaDon], [MaHang], [TKCongNo_ChiPhi], [TKDoanhThu], [SoLuong], [ThanhTien], [TienChietKhau], [TienThueGTGT]) VALUES (25, N'000010', N'000000000003', NULL, NULL, 123, 25830000, 0, 4305000)
INSERT [dbo].[ChiTietHoaDon_BanHang] ([MaChiTietHoaDonBanHang], [MaHoaDon], [MaHang], [TKCongNo_ChiPhi], [TKDoanhThu], [SoLuong], [ThanhTien], [TienChietKhau], [TienThueGTGT]) VALUES (26, N'000010', N'000000000002', NULL, NULL, 13, 2730000, 0, 455000)
INSERT [dbo].[ChiTietHoaDon_BanHang] ([MaChiTietHoaDonBanHang], [MaHoaDon], [MaHang], [TKCongNo_ChiPhi], [TKDoanhThu], [SoLuong], [ThanhTien], [TienChietKhau], [TienThueGTGT]) VALUES (27, N'000010', N'000000000004', NULL, NULL, 15, 4875000, 0, 1125000)
INSERT [dbo].[ChiTietHoaDon_BanHang] ([MaChiTietHoaDonBanHang], [MaHoaDon], [MaHang], [TKCongNo_ChiPhi], [TKDoanhThu], [SoLuong], [ThanhTien], [TienChietKhau], [TienThueGTGT]) VALUES (28, N'000014', N'000000000002', NULL, NULL, 22, NULL, 0, 770000)
INSERT [dbo].[ChiTietHoaDon_BanHang] ([MaChiTietHoaDonBanHang], [MaHoaDon], [MaHang], [TKCongNo_ChiPhi], [TKDoanhThu], [SoLuong], [ThanhTien], [TienChietKhau], [TienThueGTGT]) VALUES (29, N'000014', N'000000000003', NULL, NULL, 12, 2520000, 0, 420000)
INSERT [dbo].[ChiTietHoaDon_BanHang] ([MaChiTietHoaDonBanHang], [MaHoaDon], [MaHang], [TKCongNo_ChiPhi], [TKDoanhThu], [SoLuong], [ThanhTien], [TienChietKhau], [TienThueGTGT]) VALUES (30, N'000014', N'000000000004', NULL, NULL, 13, 4225000, 0, 975000)
INSERT [dbo].[ChiTietHoaDon_BanHang] ([MaChiTietHoaDonBanHang], [MaHoaDon], [MaHang], [TKCongNo_ChiPhi], [TKDoanhThu], [SoLuong], [ThanhTien], [TienChietKhau], [TienThueGTGT]) VALUES (31, N'000015', N'000000000002', NULL, NULL, 12, 2520000, 0, 420000)
INSERT [dbo].[ChiTietHoaDon_BanHang] ([MaChiTietHoaDonBanHang], [MaHoaDon], [MaHang], [TKCongNo_ChiPhi], [TKDoanhThu], [SoLuong], [ThanhTien], [TienChietKhau], [TienThueGTGT]) VALUES (32, N'000015', N'000000000004', NULL, NULL, 133, 43225000, 0, 9975000)
INSERT [dbo].[ChiTietHoaDon_BanHang] ([MaChiTietHoaDonBanHang], [MaHoaDon], [MaHang], [TKCongNo_ChiPhi], [TKDoanhThu], [SoLuong], [ThanhTien], [TienChietKhau], [TienThueGTGT]) VALUES (33, N'000016', N'000000000002', N'12313', N'12313', 21, 4410000, 0, 735000)
INSERT [dbo].[ChiTietHoaDon_BanHang] ([MaChiTietHoaDonBanHang], [MaHoaDon], [MaHang], [TKCongNo_ChiPhi], [TKDoanhThu], [SoLuong], [ThanhTien], [TienChietKhau], [TienThueGTGT]) VALUES (34, N'000016', N'000000000003', N'12312', N'123', 13, 2730000, 0, 455000)
INSERT [dbo].[ChiTietHoaDon_BanHang] ([MaChiTietHoaDonBanHang], [MaHoaDon], [MaHang], [TKCongNo_ChiPhi], [TKDoanhThu], [SoLuong], [ThanhTien], [TienChietKhau], [TienThueGTGT]) VALUES (35, N'000016', N'000000000004', N'1231', N'123123', 11, 3575000, 0, 825000)
SET IDENTITY_INSERT [dbo].[ChiTietHoaDon_BanHang] OFF
SET IDENTITY_INSERT [dbo].[ChiTietHopDongMua] ON 

INSERT [dbo].[ChiTietHopDongMua] ([MaChiTietHopDongMua], [MaHopDongMua], [MaHang], [SoLuong], [TienChietKhau], [TienThueGTGT], [ThanhTien]) VALUES (1, N'HĐM000001', N'000000000002', 2, 0, 70000, 420000)
INSERT [dbo].[ChiTietHopDongMua] ([MaChiTietHopDongMua], [MaHopDongMua], [MaHang], [SoLuong], [TienChietKhau], [TienThueGTGT], [ThanhTien]) VALUES (2, N'HĐM000001', N'000000000004', 1, 0, 75000, 325000)
INSERT [dbo].[ChiTietHopDongMua] ([MaChiTietHopDongMua], [MaHopDongMua], [MaHang], [SoLuong], [TienChietKhau], [TienThueGTGT], [ThanhTien]) VALUES (3, N'HĐM000002', N'000000000002', 7, 0, 245000, 1470000)
INSERT [dbo].[ChiTietHopDongMua] ([MaChiTietHopDongMua], [MaHopDongMua], [MaHang], [SoLuong], [TienChietKhau], [TienThueGTGT], [ThanhTien]) VALUES (4, N'HĐM000002', N'000000000004', 3, 0, 225000, 975000)
SET IDENTITY_INSERT [dbo].[ChiTietHopDongMua] OFF
SET IDENTITY_INSERT [dbo].[ChiTietLapRapThaoDo] ON 

INSERT [dbo].[ChiTietLapRapThaoDo] ([MaChiTietLapRapThaoDo], [MaLapRapThaoDo], [MaHang], [SoLuong], [ThanhTien]) VALUES (1, NULL, N'000000000002', 21, 4410000)
INSERT [dbo].[ChiTietLapRapThaoDo] ([MaChiTietLapRapThaoDo], [MaLapRapThaoDo], [MaHang], [SoLuong], [ThanhTien]) VALUES (2, NULL, N'000000000003', 15, 3150000)
INSERT [dbo].[ChiTietLapRapThaoDo] ([MaChiTietLapRapThaoDo], [MaLapRapThaoDo], [MaHang], [SoLuong], [ThanhTien]) VALUES (3, N'LRTD000002', N'000000000002', 7, 210000)
INSERT [dbo].[ChiTietLapRapThaoDo] ([MaChiTietLapRapThaoDo], [MaLapRapThaoDo], [MaHang], [SoLuong], [ThanhTien]) VALUES (4, N'LRTD000002', N'000000000004', 14, 325000)
INSERT [dbo].[ChiTietLapRapThaoDo] ([MaChiTietLapRapThaoDo], [MaLapRapThaoDo], [MaHang], [SoLuong], [ThanhTien]) VALUES (5, N'LRTD000002', N'000000000003', 12, 210000)
INSERT [dbo].[ChiTietLapRapThaoDo] ([MaChiTietLapRapThaoDo], [MaLapRapThaoDo], [MaHang], [SoLuong], [ThanhTien]) VALUES (6, N'LRTD000003', N'000000000002', 13, 210000)
INSERT [dbo].[ChiTietLapRapThaoDo] ([MaChiTietLapRapThaoDo], [MaLapRapThaoDo], [MaHang], [SoLuong], [ThanhTien]) VALUES (7, N'LRTD000003', N'000000000003', 22, 210000)
SET IDENTITY_INSERT [dbo].[ChiTietLapRapThaoDo] OFF
SET IDENTITY_INSERT [dbo].[ChiTietPhieuChi] ON 

INSERT [dbo].[ChiTietPhieuChi] ([MaCTPC], [MaPhieuChi], [MaHang], [SoLuong], [SoTien], [DienGiai], [SoTaiKhoanCo], [SoTaiKhoanNo], [MaNhaCungCap], [TenNhaCungCap], [TaiKhoanNganHang], [MucThuChi], [DonVi], [CongTrinh], [HopDongBan], [MaThongKe], [KhoanMucCP], [DoiTuongDHCP], [DonDatHang], [DonMuaHang]) VALUES (1, N'PC000003', NULL, NULL, 1233324, N'Diễn giải 1', N'1361', N'1111', N'0005', N'Ngân hàng Kien Long bank', N'TK ngân hàng', N'Mục thu/chi', N'Đơn vị', N'Công trình', N'Hợp đồng bán', N'Mã thống kê', N'Khoản mục CP', N'Đối tượng DHCP', N'Đơn đặt hàng', N'Đơn mua hàng')
INSERT [dbo].[ChiTietPhieuChi] ([MaCTPC], [MaPhieuChi], [MaHang], [SoLuong], [SoTien], [DienGiai], [SoTaiKhoanCo], [SoTaiKhoanNo], [MaNhaCungCap], [TenNhaCungCap], [TaiKhoanNganHang], [MucThuChi], [DonVi], [CongTrinh], [HopDongBan], [MaThongKe], [KhoanMucCP], [DoiTuongDHCP], [DonDatHang], [DonMuaHang]) VALUES (2, N'PC000003', NULL, NULL, 2343333, N'Diễn giải 2', N'1332', N'1113', N'0003', N'Ngân hàng HSBC', N'TK ngân hàng	2', N'Mục thu/chi	2', N'Đơn vị	2', N'Công trình	2', N'Hợp đồng bán	2', N'Mã thống kêư2', N'Khoản mục CP	2', N'Đối tượng DHCP	2', N'Đơn đặt hàng	2', N'Đơn mua hàng	2')
INSERT [dbo].[ChiTietPhieuChi] ([MaCTPC], [MaPhieuChi], [MaHang], [SoLuong], [SoTien], [DienGiai], [SoTaiKhoanCo], [SoTaiKhoanNo], [MaNhaCungCap], [TenNhaCungCap], [TaiKhoanNganHang], [MucThuChi], [DonVi], [CongTrinh], [HopDongBan], [MaThongKe], [KhoanMucCP], [DoiTuongDHCP], [DonDatHang], [DonMuaHang]) VALUES (3, N'PC000027', NULL, NULL, 2500000, N'Diễn giải 1', N'1123', N'1111', N'0003', N'Ngân hàng HSBC', N'1232131', N'Mục thu/chi 1', N'Đơn vị 1', N'Công trình 1', N'Hợp đồng bán 1', N'Mã thống kê 1', N'Khoản mục CP 1', N'Đối tượng DHCP 1', N'Đơn đặt hàng 1', N'Đơn mua hàng 1')
INSERT [dbo].[ChiTietPhieuChi] ([MaCTPC], [MaPhieuChi], [MaHang], [SoLuong], [SoTien], [DienGiai], [SoTaiKhoanCo], [SoTaiKhoanNo], [MaNhaCungCap], [TenNhaCungCap], [TaiKhoanNganHang], [MucThuChi], [DonVi], [CongTrinh], [HopDongBan], [MaThongKe], [KhoanMucCP], [DoiTuongDHCP], [DonDatHang], [DonMuaHang]) VALUES (4, N'PC000027', NULL, NULL, 3200000, N'Diễn giải 2', N'1211', N'1113', N'0005', N'Ngân hàng Kien Long bank', N'3587335', N'Mục thu/chi 2', N'Đơn vị 2', N'Công trình 2', N'Hợp đồng bán 2', N'Mã thống kê 2', N'Khoản mục CP 2', N'Đối tượng DHCP 2', N'Đơn đặt hàng 2', N'Đơn mua hàng 2')
INSERT [dbo].[ChiTietPhieuChi] ([MaCTPC], [MaPhieuChi], [MaHang], [SoLuong], [SoTien], [DienGiai], [SoTaiKhoanCo], [SoTaiKhoanNo], [MaNhaCungCap], [TenNhaCungCap], [TaiKhoanNganHang], [MucThuChi], [DonVi], [CongTrinh], [HopDongBan], [MaThongKe], [KhoanMucCP], [DoiTuongDHCP], [DonDatHang], [DonMuaHang]) VALUES (5, NULL, N'000000000002', 43, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[ChiTietPhieuChi] ([MaCTPC], [MaPhieuChi], [MaHang], [SoLuong], [SoTien], [DienGiai], [SoTaiKhoanCo], [SoTaiKhoanNo], [MaNhaCungCap], [TenNhaCungCap], [TaiKhoanNganHang], [MucThuChi], [DonVi], [CongTrinh], [HopDongBan], [MaThongKe], [KhoanMucCP], [DoiTuongDHCP], [DonDatHang], [DonMuaHang]) VALUES (6, NULL, N'000000000003', 14, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[ChiTietPhieuChi] ([MaCTPC], [MaPhieuChi], [MaHang], [SoLuong], [SoTien], [DienGiai], [SoTaiKhoanCo], [SoTaiKhoanNo], [MaNhaCungCap], [TenNhaCungCap], [TaiKhoanNganHang], [MucThuChi], [DonVi], [CongTrinh], [HopDongBan], [MaThongKe], [KhoanMucCP], [DoiTuongDHCP], [DonDatHang], [DonMuaHang]) VALUES (7, NULL, N'000000000004', 15, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[ChiTietPhieuChi] ([MaCTPC], [MaPhieuChi], [MaHang], [SoLuong], [SoTien], [DienGiai], [SoTaiKhoanCo], [SoTaiKhoanNo], [MaNhaCungCap], [TenNhaCungCap], [TaiKhoanNganHang], [MucThuChi], [DonVi], [CongTrinh], [HopDongBan], [MaThongKe], [KhoanMucCP], [DoiTuongDHCP], [DonDatHang], [DonMuaHang]) VALUES (8, N'PC000030', N'000000000002', 43, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[ChiTietPhieuChi] ([MaCTPC], [MaPhieuChi], [MaHang], [SoLuong], [SoTien], [DienGiai], [SoTaiKhoanCo], [SoTaiKhoanNo], [MaNhaCungCap], [TenNhaCungCap], [TaiKhoanNganHang], [MucThuChi], [DonVi], [CongTrinh], [HopDongBan], [MaThongKe], [KhoanMucCP], [DoiTuongDHCP], [DonDatHang], [DonMuaHang]) VALUES (9, N'PC000030', N'000000000003', 14, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[ChiTietPhieuChi] ([MaCTPC], [MaPhieuChi], [MaHang], [SoLuong], [SoTien], [DienGiai], [SoTaiKhoanCo], [SoTaiKhoanNo], [MaNhaCungCap], [TenNhaCungCap], [TaiKhoanNganHang], [MucThuChi], [DonVi], [CongTrinh], [HopDongBan], [MaThongKe], [KhoanMucCP], [DoiTuongDHCP], [DonDatHang], [DonMuaHang]) VALUES (10, N'PC000030', N'000000000004', 15, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[ChiTietPhieuChi] ([MaCTPC], [MaPhieuChi], [MaHang], [SoLuong], [SoTien], [DienGiai], [SoTaiKhoanCo], [SoTaiKhoanNo], [MaNhaCungCap], [TenNhaCungCap], [TaiKhoanNganHang], [MucThuChi], [DonVi], [CongTrinh], [HopDongBan], [MaThongKe], [KhoanMucCP], [DoiTuongDHCP], [DonDatHang], [DonMuaHang]) VALUES (11, N'PC000031', N'000000000002', 3, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[ChiTietPhieuChi] ([MaCTPC], [MaPhieuChi], [MaHang], [SoLuong], [SoTien], [DienGiai], [SoTaiKhoanCo], [SoTaiKhoanNo], [MaNhaCungCap], [TenNhaCungCap], [TaiKhoanNganHang], [MucThuChi], [DonVi], [CongTrinh], [HopDongBan], [MaThongKe], [KhoanMucCP], [DoiTuongDHCP], [DonDatHang], [DonMuaHang]) VALUES (12, N'PC000031', N'000000000003', 4, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[ChiTietPhieuChi] ([MaCTPC], [MaPhieuChi], [MaHang], [SoLuong], [SoTien], [DienGiai], [SoTaiKhoanCo], [SoTaiKhoanNo], [MaNhaCungCap], [TenNhaCungCap], [TaiKhoanNganHang], [MucThuChi], [DonVi], [CongTrinh], [HopDongBan], [MaThongKe], [KhoanMucCP], [DoiTuongDHCP], [DonDatHang], [DonMuaHang]) VALUES (13, N'PC000032', N'000000000002', 3, 630000, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[ChiTietPhieuChi] ([MaCTPC], [MaPhieuChi], [MaHang], [SoLuong], [SoTien], [DienGiai], [SoTaiKhoanCo], [SoTaiKhoanNo], [MaNhaCungCap], [TenNhaCungCap], [TaiKhoanNganHang], [MucThuChi], [DonVi], [CongTrinh], [HopDongBan], [MaThongKe], [KhoanMucCP], [DoiTuongDHCP], [DonDatHang], [DonMuaHang]) VALUES (14, N'PC000032', N'000000000003', 4, 840000, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[ChiTietPhieuChi] ([MaCTPC], [MaPhieuChi], [MaHang], [SoLuong], [SoTien], [DienGiai], [SoTaiKhoanCo], [SoTaiKhoanNo], [MaNhaCungCap], [TenNhaCungCap], [TaiKhoanNganHang], [MucThuChi], [DonVi], [CongTrinh], [HopDongBan], [MaThongKe], [KhoanMucCP], [DoiTuongDHCP], [DonDatHang], [DonMuaHang]) VALUES (15, N'PC000033', N'000000000002', 43, 9030000, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[ChiTietPhieuChi] ([MaCTPC], [MaPhieuChi], [MaHang], [SoLuong], [SoTien], [DienGiai], [SoTaiKhoanCo], [SoTaiKhoanNo], [MaNhaCungCap], [TenNhaCungCap], [TaiKhoanNganHang], [MucThuChi], [DonVi], [CongTrinh], [HopDongBan], [MaThongKe], [KhoanMucCP], [DoiTuongDHCP], [DonDatHang], [DonMuaHang]) VALUES (16, N'PC000033', N'000000000003', 14, 2940000, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[ChiTietPhieuChi] ([MaCTPC], [MaPhieuChi], [MaHang], [SoLuong], [SoTien], [DienGiai], [SoTaiKhoanCo], [SoTaiKhoanNo], [MaNhaCungCap], [TenNhaCungCap], [TaiKhoanNganHang], [MucThuChi], [DonVi], [CongTrinh], [HopDongBan], [MaThongKe], [KhoanMucCP], [DoiTuongDHCP], [DonDatHang], [DonMuaHang]) VALUES (17, N'PC000033', N'000000000004', 15, 4875000, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[ChiTietPhieuChi] OFF
SET IDENTITY_INSERT [dbo].[ChiTietPhieuNhapKho] ON 

INSERT [dbo].[ChiTietPhieuNhapKho] ([MaChiTietPhieuNhapKho], [MaPhieuNhapKho], [MaHang], [Kho], [TKNo], [TKCo], [ThanhTien], [MaLenhSanXuat]) VALUES (7, N'NK0001', N'000000000002', N'22', N'2454', N'45454545', 5454000, N'545454')
INSERT [dbo].[ChiTietPhieuNhapKho] ([MaChiTietPhieuNhapKho], [MaPhieuNhapKho], [MaHang], [Kho], [TKNo], [TKCo], [ThanhTien], [MaLenhSanXuat]) VALUES (8, N'NK0001', N'000000000004', N'22', N'2454', N'45454545', 5454000, N'545454')
SET IDENTITY_INSERT [dbo].[ChiTietPhieuNhapKho] OFF
SET IDENTITY_INSERT [dbo].[ChiTietPhieuThu] ON 

INSERT [dbo].[ChiTietPhieuThu] ([MaCTPT], [MaPhieuThu], [MaHang], [SoLuong], [SoTien], [DienGiai], [SoTaiKhoanCo], [SoTaiKhoanNo], [MaKhachHang], [TenKhachHang], [TaiKhoanNganHang], [MucThuChi], [DonVi], [CongTrinh], [HopDongBan], [MaThongKe]) VALUES (10, N'PT000001', N'000000000002', 0, 2000000, NULL, N'1211', N'1112', N'000017', N'Đoàn Thanh Thảo', N'321', N'Mục thu/chi	2', N'Đơn vị	2', N'Công trình	2', N'Hợp đồng bán	2', N'Mã thống kê2')
INSERT [dbo].[ChiTietPhieuThu] ([MaCTPT], [MaPhieuThu], [MaHang], [SoLuong], [SoTien], [DienGiai], [SoTaiKhoanCo], [SoTaiKhoanNo], [MaKhachHang], [TenKhachHang], [TaiKhoanNganHang], [MucThuChi], [DonVi], [CongTrinh], [HopDongBan], [MaThongKe]) VALUES (11, N'PT000001', N'000000000002', 0, 5000000, NULL, N'1288', N'1111', N'000005', N'Cao Châu Minh Thư', N'123', N'Mục thu/chi', N'Đơn vị', N'Công trình', N'Hợp đồng bán', N'Mã thống kê')
INSERT [dbo].[ChiTietPhieuThu] ([MaCTPT], [MaPhieuThu], [MaHang], [SoLuong], [SoTien], [DienGiai], [SoTaiKhoanCo], [SoTaiKhoanNo], [MaKhachHang], [TenKhachHang], [TaiKhoanNganHang], [MucThuChi], [DonVi], [CongTrinh], [HopDongBan], [MaThongKe]) VALUES (12, N'PT000005', N'000000000002', 0, 1500000, N'Nộp test', N'1112', N'1111', N'000002', N'Công ty TNHH Công Minh', N'371861859', N'mục 1', N'đơn vị 1', N'công trình 1', N'hợp đồng bán 1', N'mã thống kê 1')
INSERT [dbo].[ChiTietPhieuThu] ([MaCTPT], [MaPhieuThu], [MaHang], [SoLuong], [SoTien], [DienGiai], [SoTaiKhoanCo], [SoTaiKhoanNo], [MaKhachHang], [TenKhachHang], [TaiKhoanNganHang], [MucThuChi], [DonVi], [CongTrinh], [HopDongBan], [MaThongKe]) VALUES (13, N'PT000005', N'000000000002', 0, 2500000, N'Nộp test 2', N'1121', N'1112', N'000001', N'Công ty cổ phần, thương mại và dịch vụ Mekong', N'13082000', N'mục 2', N'đơn vị 2', N'công trình 2', N'hợp đồng bán 2', N'mã thống kê 2')
INSERT [dbo].[ChiTietPhieuThu] ([MaCTPT], [MaPhieuThu], [MaHang], [SoLuong], [SoTien], [DienGiai], [SoTaiKhoanCo], [SoTaiKhoanNo], [MaKhachHang], [TenKhachHang], [TaiKhoanNganHang], [MucThuChi], [DonVi], [CongTrinh], [HopDongBan], [MaThongKe]) VALUES (14, N'PT000006', N'000000000002', 0, 2000000, N'Diễn giải', N'1123', N'1111', N'000005', N'Cao Châu Minh Thư', N'132584454', N'mục1', N'đơn vị', N'công trình', N'hợ pđồng', N'mã thống kê')
SET IDENTITY_INSERT [dbo].[ChiTietPhieuThu] OFF
SET IDENTITY_INSERT [dbo].[ChiTietPhieuXuatKho] ON 

INSERT [dbo].[ChiTietPhieuXuatKho] ([MaChiTietPhieuXuat], [MaPhieuXuat], [MaHang], [TKCongNo_ChiPhi], [TKDoanhThu], [SoLuong], [ThanhTien], [TienChietKhau], [TienThueGTGT], [Kho], [TKNo], [TKCo]) VALUES (42, N'XK0005', N'000000000002', N'3', N'4', 16, 3360000, 0, 560000, N'545000', N'542400', N'770000')
INSERT [dbo].[ChiTietPhieuXuatKho] ([MaChiTietPhieuXuat], [MaPhieuXuat], [MaHang], [TKCongNo_ChiPhi], [TKDoanhThu], [SoLuong], [ThanhTien], [TienChietKhau], [TienThueGTGT], [Kho], [TKNo], [TKCo]) VALUES (43, N'XK0006', N'000000000003', N'3', N'4', 17, 3570000, 0, 595000, N'545000', N'5235235', N'532532')
INSERT [dbo].[ChiTietPhieuXuatKho] ([MaChiTietPhieuXuat], [MaPhieuXuat], [MaHang], [TKCongNo_ChiPhi], [TKDoanhThu], [SoLuong], [ThanhTien], [TienChietKhau], [TienThueGTGT], [Kho], [TKNo], [TKCo]) VALUES (44, N'XK0007', N'000000000004', N'3', N'7', 10, 3250000, 0, 750000, N'545000', N'5325', N'532532')
INSERT [dbo].[ChiTietPhieuXuatKho] ([MaChiTietPhieuXuat], [MaPhieuXuat], [MaHang], [TKCongNo_ChiPhi], [TKDoanhThu], [SoLuong], [ThanhTien], [TienChietKhau], [TienThueGTGT], [Kho], [TKNo], [TKCo]) VALUES (45, N'XK0009', N'000000000003', N'44', N'55', 13, 2730000, 0, 455000, N'545000', N'55', N'35423523')
INSERT [dbo].[ChiTietPhieuXuatKho] ([MaChiTietPhieuXuat], [MaPhieuXuat], [MaHang], [TKCongNo_ChiPhi], [TKDoanhThu], [SoLuong], [ThanhTien], [TienChietKhau], [TienThueGTGT], [Kho], [TKNo], [TKCo]) VALUES (46, N'XK0010', N'000000000004', N'2', N'3', 15, 4875000, 0, 1125000, N'545000', N'35325', N'55235')
INSERT [dbo].[ChiTietPhieuXuatKho] ([MaChiTietPhieuXuat], [MaPhieuXuat], [MaHang], [TKCongNo_ChiPhi], [TKDoanhThu], [SoLuong], [ThanhTien], [TienChietKhau], [TienThueGTGT], [Kho], [TKNo], [TKCo]) VALUES (47, N'XK0011', N'000000000003', N'3', N'4', 15, 3150000, 0, 525000, N'545000', N'5325523', N'5325')
INSERT [dbo].[ChiTietPhieuXuatKho] ([MaChiTietPhieuXuat], [MaPhieuXuat], [MaHang], [TKCongNo_ChiPhi], [TKDoanhThu], [SoLuong], [ThanhTien], [TienChietKhau], [TienThueGTGT], [Kho], [TKNo], [TKCo]) VALUES (48, N'XK0012', N'000000000003', N'2', N'3', 144, 30240000, 0, 5040000, N'545000', N'825000', N'5532523')
INSERT [dbo].[ChiTietPhieuXuatKho] ([MaChiTietPhieuXuat], [MaPhieuXuat], [MaHang], [TKCongNo_ChiPhi], [TKDoanhThu], [SoLuong], [ThanhTien], [TienChietKhau], [TienThueGTGT], [Kho], [TKNo], [TKCo]) VALUES (49, N'XK0007', N'000000000004', N'3', N'7', 15, 4875000, 0, 1125000, N'545000', N'825000', N'532523')
INSERT [dbo].[ChiTietPhieuXuatKho] ([MaChiTietPhieuXuat], [MaPhieuXuat], [MaHang], [TKCongNo_ChiPhi], [TKDoanhThu], [SoLuong], [ThanhTien], [TienChietKhau], [TienThueGTGT], [Kho], [TKNo], [TKCo]) VALUES (50, N'XK0009', N'000000000004', N'4', N'5', 16, 5200000, 0, 1200000, N'545000', N'5232355', N'5235')
INSERT [dbo].[ChiTietPhieuXuatKho] ([MaChiTietPhieuXuat], [MaPhieuXuat], [MaHang], [TKCongNo_ChiPhi], [TKDoanhThu], [SoLuong], [ThanhTien], [TienChietKhau], [TienThueGTGT], [Kho], [TKNo], [TKCo]) VALUES (51, N'XK0005', N'000000000002', N'2', N'123', 1123, 235830000, 0, 39305000, N'545000', N'3525', N'5332523')
INSERT [dbo].[ChiTietPhieuXuatKho] ([MaChiTietPhieuXuat], [MaPhieuXuat], [MaHang], [TKCongNo_ChiPhi], [TKDoanhThu], [SoLuong], [ThanhTien], [TienChietKhau], [TienThueGTGT], [Kho], [TKNo], [TKCo]) VALUES (52, N'XK0005', N'000000000004', N'123', N'123', 1123, 364975000, 0, 84225000, N'545000', N'5', N'235')
INSERT [dbo].[ChiTietPhieuXuatKho] ([MaChiTietPhieuXuat], [MaPhieuXuat], [MaHang], [TKCongNo_ChiPhi], [TKDoanhThu], [SoLuong], [ThanhTien], [TienChietKhau], [TienThueGTGT], [Kho], [TKNo], [TKCo]) VALUES (53, N'XK0005', N'000000000002', N'12313', N'12313', 21, 4410000, 0, 735000, N'545000', N'323252', N'23523523')
INSERT [dbo].[ChiTietPhieuXuatKho] ([MaChiTietPhieuXuat], [MaPhieuXuat], [MaHang], [TKCongNo_ChiPhi], [TKDoanhThu], [SoLuong], [ThanhTien], [TienChietKhau], [TienThueGTGT], [Kho], [TKNo], [TKCo]) VALUES (54, N'XK0005', N'000000000003', N'12312', N'123', 13, 2730000, 0, 455000, N'545000', N'2355', N'235')
SET IDENTITY_INSERT [dbo].[ChiTietPhieuXuatKho] OFF
SET IDENTITY_INSERT [dbo].[ChiTietTraLaiHangBan] ON 

INSERT [dbo].[ChiTietTraLaiHangBan] ([MaChiTietTraLaiHangBan], [MaTraLaiHangBan], [MaHang], [TKTraLai], [TKTien], [SoLuong], [ThanhTien], [TienChietKhau], [MucThuChi]) VALUES (1, N'BTL000001', N'000000000002', N'12313     ', N'123132    ', 12, 2520000, 0, N'Mục 1')
INSERT [dbo].[ChiTietTraLaiHangBan] ([MaChiTietTraLaiHangBan], [MaTraLaiHangBan], [MaHang], [TKTraLai], [TKTien], [SoLuong], [ThanhTien], [TienChietKhau], [MucThuChi]) VALUES (2, N'BTL000001', N'000000000004', N'123       ', N'43534     ', 133, 43225000, 0, N'Mục 2')
INSERT [dbo].[ChiTietTraLaiHangBan] ([MaChiTietTraLaiHangBan], [MaTraLaiHangBan], [MaHang], [TKTraLai], [TKTien], [SoLuong], [ThanhTien], [TienChietKhau], [MucThuChi]) VALUES (3, N'BTL000002', N'000000000002', N'21313', N'123123', 43, 9030000, 0, NULL)
INSERT [dbo].[ChiTietTraLaiHangBan] ([MaChiTietTraLaiHangBan], [MaTraLaiHangBan], [MaHang], [TKTraLai], [TKTien], [SoLuong], [ThanhTien], [TienChietKhau], [MucThuChi]) VALUES (4, N'BTL000002', N'000000000003', N'2311', N'1231', 14, 2940000, 0, NULL)
INSERT [dbo].[ChiTietTraLaiHangBan] ([MaChiTietTraLaiHangBan], [MaTraLaiHangBan], [MaHang], [TKTraLai], [TKTien], [SoLuong], [ThanhTien], [TienChietKhau], [MucThuChi]) VALUES (5, N'BTL000002', N'000000000004', N'123', N'123', 15, 4875000, 0, NULL)
INSERT [dbo].[ChiTietTraLaiHangBan] ([MaChiTietTraLaiHangBan], [MaTraLaiHangBan], [MaHang], [TKTraLai], [TKTien], [SoLuong], [ThanhTien], [TienChietKhau], [MucThuChi]) VALUES (6, N'BTL000003', N'000000000002', NULL, NULL, 43, 9030000, 0, NULL)
INSERT [dbo].[ChiTietTraLaiHangBan] ([MaChiTietTraLaiHangBan], [MaTraLaiHangBan], [MaHang], [TKTraLai], [TKTien], [SoLuong], [ThanhTien], [TienChietKhau], [MucThuChi]) VALUES (7, N'BTL000003', N'000000000003', NULL, NULL, 14, 2940000, 0, NULL)
INSERT [dbo].[ChiTietTraLaiHangBan] ([MaChiTietTraLaiHangBan], [MaTraLaiHangBan], [MaHang], [TKTraLai], [TKTien], [SoLuong], [ThanhTien], [TienChietKhau], [MucThuChi]) VALUES (8, N'BTL000003', N'000000000004', NULL, NULL, 15, 4875000, 0, NULL)
INSERT [dbo].[ChiTietTraLaiHangBan] ([MaChiTietTraLaiHangBan], [MaTraLaiHangBan], [MaHang], [TKTraLai], [TKTien], [SoLuong], [ThanhTien], [TienChietKhau], [MucThuChi]) VALUES (9, N'BTL000004', N'000000000002', NULL, NULL, 16, 3360000, 0, NULL)
INSERT [dbo].[ChiTietTraLaiHangBan] ([MaChiTietTraLaiHangBan], [MaTraLaiHangBan], [MaHang], [TKTraLai], [TKTien], [SoLuong], [ThanhTien], [TienChietKhau], [MucThuChi]) VALUES (10, N'BTL000004', N'000000000003', NULL, NULL, 17, 3570000, 0, NULL)
INSERT [dbo].[ChiTietTraLaiHangBan] ([MaChiTietTraLaiHangBan], [MaTraLaiHangBan], [MaHang], [TKTraLai], [TKTien], [SoLuong], [ThanhTien], [TienChietKhau], [MucThuChi]) VALUES (11, N'BTL000005', N'000000000002', NULL, NULL, 43, 9030000, 0, NULL)
INSERT [dbo].[ChiTietTraLaiHangBan] ([MaChiTietTraLaiHangBan], [MaTraLaiHangBan], [MaHang], [TKTraLai], [TKTien], [SoLuong], [ThanhTien], [TienChietKhau], [MucThuChi]) VALUES (12, N'BTL000005', N'000000000003', NULL, NULL, 14, 2940000, 0, NULL)
INSERT [dbo].[ChiTietTraLaiHangBan] ([MaChiTietTraLaiHangBan], [MaTraLaiHangBan], [MaHang], [TKTraLai], [TKTien], [SoLuong], [ThanhTien], [TienChietKhau], [MucThuChi]) VALUES (13, N'BTL000005', N'000000000004', NULL, NULL, 15, 4875000, 0, NULL)
INSERT [dbo].[ChiTietTraLaiHangBan] ([MaChiTietTraLaiHangBan], [MaTraLaiHangBan], [MaHang], [TKTraLai], [TKTien], [SoLuong], [ThanhTien], [TienChietKhau], [MucThuChi]) VALUES (14, N'BTL000006', N'000000000002', NULL, NULL, 43, 9030000, 0, NULL)
INSERT [dbo].[ChiTietTraLaiHangBan] ([MaChiTietTraLaiHangBan], [MaTraLaiHangBan], [MaHang], [TKTraLai], [TKTien], [SoLuong], [ThanhTien], [TienChietKhau], [MucThuChi]) VALUES (15, N'BTL000006', N'000000000003', NULL, NULL, 14, 2940000, 0, NULL)
INSERT [dbo].[ChiTietTraLaiHangBan] ([MaChiTietTraLaiHangBan], [MaTraLaiHangBan], [MaHang], [TKTraLai], [TKTien], [SoLuong], [ThanhTien], [TienChietKhau], [MucThuChi]) VALUES (16, N'BTL000006', N'000000000004', NULL, NULL, 15, 4875000, 0, NULL)
SET IDENTITY_INSERT [dbo].[ChiTietTraLaiHangBan] OFF
SET IDENTITY_INSERT [dbo].[ChiTietTraLaiHangMua] ON 

INSERT [dbo].[ChiTietTraLaiHangMua] ([MaChiTietTraLaiHangMua], [MaTraLaiHangMua], [MaHang], [Kho], [TKKho], [TKCongNo], [SoLuong], [ThanhTien], [DienGiaiThue], [TienThueGTGT], [TKThueGTGT], [NhomHHDVMuaVao], [SoLo], [SoCTMuaHang], [SoHDMuaHang], [NgayHDMuaHang], [MaHopDongMua], [MaThongKe]) VALUES (1, N'0000002', N'000000000002', N'1', N'2', N'3', 15, 3150000, N'5', 525000, N'6', N'7', N'8', N'9', N'10', N'11', N'HĐM000001', N'12')
INSERT [dbo].[ChiTietTraLaiHangMua] ([MaChiTietTraLaiHangMua], [MaTraLaiHangMua], [MaHang], [Kho], [TKKho], [TKCongNo], [SoLuong], [ThanhTien], [DienGiaiThue], [TienThueGTGT], [TKThueGTGT], [NhomHHDVMuaVao], [SoLo], [SoCTMuaHang], [SoHDMuaHang], [NgayHDMuaHang], [MaHopDongMua], [MaThongKe]) VALUES (2, N'0000002', N'000000000003', N'1', N'2', N'3', 14, 2940000, N'5', 490000, N'6', N'78', N'9', N'10', N'11', N'12', N'HĐM000002', N'13')
INSERT [dbo].[ChiTietTraLaiHangMua] ([MaChiTietTraLaiHangMua], [MaTraLaiHangMua], [MaHang], [Kho], [TKKho], [TKCongNo], [SoLuong], [ThanhTien], [DienGiaiThue], [TienThueGTGT], [TKThueGTGT], [NhomHHDVMuaVao], [SoLo], [SoCTMuaHang], [SoHDMuaHang], [NgayHDMuaHang], [MaHopDongMua], [MaThongKe]) VALUES (3, N'0000003', N'000000000002', N'1', N'2', N'3', 3, 630000, N'4', 105000, N'5', N'6', N'7', N'8', N'9', N'10', N'HĐM000002', N'11')
INSERT [dbo].[ChiTietTraLaiHangMua] ([MaChiTietTraLaiHangMua], [MaTraLaiHangMua], [MaHang], [Kho], [TKKho], [TKCongNo], [SoLuong], [ThanhTien], [DienGiaiThue], [TienThueGTGT], [TKThueGTGT], [NhomHHDVMuaVao], [SoLo], [SoCTMuaHang], [SoHDMuaHang], [NgayHDMuaHang], [MaHopDongMua], [MaThongKe]) VALUES (4, N'0000003', N'000000000003', N'1', N'2', N'3', 2, 420000, N'4', 70000, N'5', N'7', N'8', N'9', N'10', N'11', N'HĐM000001', N'11')
INSERT [dbo].[ChiTietTraLaiHangMua] ([MaChiTietTraLaiHangMua], [MaTraLaiHangMua], [MaHang], [Kho], [TKKho], [TKCongNo], [SoLuong], [ThanhTien], [DienGiaiThue], [TienThueGTGT], [TKThueGTGT], [NhomHHDVMuaVao], [SoLo], [SoCTMuaHang], [SoHDMuaHang], [NgayHDMuaHang], [MaHopDongMua], [MaThongKe]) VALUES (5, N'0000004', N'000000000002', N'1', N'2', N'3', 3, 630000, N'4', 105000, N'5', N'6', N'7', N'8', N'9', N'10', N'HĐM000002', N'11')
INSERT [dbo].[ChiTietTraLaiHangMua] ([MaChiTietTraLaiHangMua], [MaTraLaiHangMua], [MaHang], [Kho], [TKKho], [TKCongNo], [SoLuong], [ThanhTien], [DienGiaiThue], [TienThueGTGT], [TKThueGTGT], [NhomHHDVMuaVao], [SoLo], [SoCTMuaHang], [SoHDMuaHang], [NgayHDMuaHang], [MaHopDongMua], [MaThongKe]) VALUES (6, N'0000004', N'000000000003', N'1', N'2', N'3', 2, 420000, N'4', 70000, N'5', N'7', N'8', N'9', N'10', N'11', N'HĐM000001', N'11')
INSERT [dbo].[ChiTietTraLaiHangMua] ([MaChiTietTraLaiHangMua], [MaTraLaiHangMua], [MaHang], [Kho], [TKKho], [TKCongNo], [SoLuong], [ThanhTien], [DienGiaiThue], [TienThueGTGT], [TKThueGTGT], [NhomHHDVMuaVao], [SoLo], [SoCTMuaHang], [SoHDMuaHang], [NgayHDMuaHang], [MaHopDongMua], [MaThongKe]) VALUES (7, N'0000001', N'000000000002', N'1', N'2', N'3', 3, 630000, N'4', 105000, N'5', N'6', N'7', N'8', N'9', N'10', N'HĐM000002', N'11')
INSERT [dbo].[ChiTietTraLaiHangMua] ([MaChiTietTraLaiHangMua], [MaTraLaiHangMua], [MaHang], [Kho], [TKKho], [TKCongNo], [SoLuong], [ThanhTien], [DienGiaiThue], [TienThueGTGT], [TKThueGTGT], [NhomHHDVMuaVao], [SoLo], [SoCTMuaHang], [SoHDMuaHang], [NgayHDMuaHang], [MaHopDongMua], [MaThongKe]) VALUES (8, N'0000001', N'000000000003', N'1', N'2', N'3', 2, 420000, N'4', 70000, N'5', N'7', N'8', N'9', N'10', N'11', N'HĐM000001', N'11')
SET IDENTITY_INSERT [dbo].[ChiTietTraLaiHangMua] OFF
INSERT [dbo].[ChucVu] ([MaChucVu], [TenChucVu]) VALUES (N'59', N'Nhân viên')
INSERT [dbo].[ChucVu] ([MaChucVu], [TenChucVu]) VALUES (N'78', N'Cửa hàng phó')
INSERT [dbo].[ChucVu] ([MaChucVu], [TenChucVu]) VALUES (N'79', N'Cửa hàng trưởng')
INSERT [dbo].[ChucVu] ([MaChucVu], [TenChucVu]) VALUES (N'88', N'Phó phòng hành chính tổng hợp')
INSERT [dbo].[ChucVu] ([MaChucVu], [TenChucVu]) VALUES (N'89', N'Trưởng phòng hành chính tổng hợp')
INSERT [dbo].[ChucVu] ([MaChucVu], [TenChucVu]) VALUES (N'98', N'Phó tổng giám đốc')
INSERT [dbo].[ChucVu] ([MaChucVu], [TenChucVu]) VALUES (N'99', N'Tổng giám đốc')
INSERT [dbo].[ChungTuBanHang] ([MaChungTuBanHang], [MaKhachHang], [DienGiai], [MaSoNhanVien], [NgayHoachToan], [NgayChungTu], [MaDieuKhoan], [SoNgayDuocNo], [HanThanhToan], [MaLoaiTien], [TyGia], [TongTienHang], [TienThueGTGT], [TienChietKhau], [TongTienThanhToan], [DaGhiSo], [MaSoBaoGia], [MaPhieuGoc], [DaThayDoi], [MaPhieuMoi], [NgayThayDoi], [NhanVienThayDoi], [CoSoThayDoi]) VALUES (N'BH000001', N'KH000001', N'Dieexn giai', N'0001', CAST(N'2020-08-18T00:00:00.000' AS DateTime), CAST(N'2020-08-19T00:00:00.000' AS DateTime), 1, 2, CAST(N'2020-08-18' AS Date), 1, 1000, 13975000, 3195000, 23175, 17170000, 0, NULL, NULL, 0, NULL, NULL, NULL, NULL)
INSERT [dbo].[ChungTuBanHang] ([MaChungTuBanHang], [MaKhachHang], [DienGiai], [MaSoNhanVien], [NgayHoachToan], [NgayChungTu], [MaDieuKhoan], [SoNgayDuocNo], [HanThanhToan], [MaLoaiTien], [TyGia], [TongTienHang], [TienThueGTGT], [TienChietKhau], [TongTienThanhToan], [DaGhiSo], [MaSoBaoGia], [MaPhieuGoc], [DaThayDoi], [MaPhieuMoi], [NgayThayDoi], [NhanVienThayDoi], [CoSoThayDoi]) VALUES (N'BH000002', N'KH000001', N'Diễn giải', N'0002', CAST(N'2020-08-18T00:00:00.000' AS DateTime), CAST(N'2020-08-19T00:00:00.000' AS DateTime), 1, 2, CAST(N'2020-08-12' AS Date), 1, 1000, 4550000, 910000, 23175, 5460000, 0, NULL, NULL, 0, NULL, NULL, NULL, NULL)
INSERT [dbo].[ChungTuBanHang] ([MaChungTuBanHang], [MaKhachHang], [DienGiai], [MaSoNhanVien], [NgayHoachToan], [NgayChungTu], [MaDieuKhoan], [SoNgayDuocNo], [HanThanhToan], [MaLoaiTien], [TyGia], [TongTienHang], [TienThueGTGT], [TienChietKhau], [TongTienThanhToan], [DaGhiSo], [MaSoBaoGia], [MaPhieuGoc], [DaThayDoi], [MaPhieuMoi], [NgayThayDoi], [NhanVienThayDoi], [CoSoThayDoi]) VALUES (N'BH000003', N'KH000001', N'abc', N'0001', CAST(N'2020-08-18T00:00:00.000' AS DateTime), CAST(N'2020-08-19T00:00:00.000' AS DateTime), 1, 2, CAST(N'2020-08-21' AS Date), 2, 23175, 2100000, 420000, 0, 2520000, 0, NULL, NULL, 0, NULL, NULL, NULL, NULL)
INSERT [dbo].[ChungTuBanHang] ([MaChungTuBanHang], [MaKhachHang], [DienGiai], [MaSoNhanVien], [NgayHoachToan], [NgayChungTu], [MaDieuKhoan], [SoNgayDuocNo], [HanThanhToan], [MaLoaiTien], [TyGia], [TongTienHang], [TienThueGTGT], [TienChietKhau], [TongTienThanhToan], [DaGhiSo], [MaSoBaoGia], [MaPhieuGoc], [DaThayDoi], [MaPhieuMoi], [NgayThayDoi], [NhanVienThayDoi], [CoSoThayDoi]) VALUES (N'BH000004', N'KH000001', N'Bán hàng Công ty cổ phần, thương mại và dịch vụ Mekong', N'0001', CAST(N'2020-08-19T00:00:00.000' AS DateTime), CAST(N'2020-08-19T00:00:00.000' AS DateTime), 1, 2, CAST(N'2020-08-20' AS Date), 1, 1000, 27400000, 5805000, 0, 33205000, 0, NULL, NULL, 0, NULL, NULL, NULL, NULL)
INSERT [dbo].[ChungTuBanHang] ([MaChungTuBanHang], [MaKhachHang], [DienGiai], [MaSoNhanVien], [NgayHoachToan], [NgayChungTu], [MaDieuKhoan], [SoNgayDuocNo], [HanThanhToan], [MaLoaiTien], [TyGia], [TongTienHang], [TienThueGTGT], [TienChietKhau], [TongTienThanhToan], [DaGhiSo], [MaSoBaoGia], [MaPhieuGoc], [DaThayDoi], [MaPhieuMoi], [NgayThayDoi], [NhanVienThayDoi], [CoSoThayDoi]) VALUES (N'BH000005', N'KH000001', N'Bán hàng Công ty cổ phần, thương mại và dịch vụ Mekong', N'0001', CAST(N'2020-08-19T00:00:00.000' AS DateTime), CAST(N'2020-08-19T00:00:00.000' AS DateTime), 1, 2, CAST(N'2020-08-22' AS Date), 1, 1000, 5775000, 1155000, 0, 6930000, 1, NULL, NULL, 0, NULL, NULL, NULL, NULL)
INSERT [dbo].[ChungTuBanHang] ([MaChungTuBanHang], [MaKhachHang], [DienGiai], [MaSoNhanVien], [NgayHoachToan], [NgayChungTu], [MaDieuKhoan], [SoNgayDuocNo], [HanThanhToan], [MaLoaiTien], [TyGia], [TongTienHang], [TienThueGTGT], [TienChietKhau], [TongTienThanhToan], [DaGhiSo], [MaSoBaoGia], [MaPhieuGoc], [DaThayDoi], [MaPhieuMoi], [NgayThayDoi], [NhanVienThayDoi], [CoSoThayDoi]) VALUES (N'BH000006', N'KH000001', N'Bán hàng Công ty cổ phần, thương mại và dịch vụ Mekong', N'0001', CAST(N'2020-08-19T00:00:00.000' AS DateTime), CAST(N'2020-08-19T00:00:00.000' AS DateTime), 1, 2, CAST(N'2020-08-21' AS Date), 1, 1000, 4900000, 980000, 23175, 5880000, 1, NULL, NULL, 0, NULL, NULL, NULL, NULL)
INSERT [dbo].[ChungTuBanHang] ([MaChungTuBanHang], [MaKhachHang], [DienGiai], [MaSoNhanVien], [NgayHoachToan], [NgayChungTu], [MaDieuKhoan], [SoNgayDuocNo], [HanThanhToan], [MaLoaiTien], [TyGia], [TongTienHang], [TienThueGTGT], [TienChietKhau], [TongTienThanhToan], [DaGhiSo], [MaSoBaoGia], [MaPhieuGoc], [DaThayDoi], [MaPhieuMoi], [NgayThayDoi], [NhanVienThayDoi], [CoSoThayDoi]) VALUES (N'BH000007', N'KH000002', N'Bán hàng Công ty TNHH Công Minh', NULL, CAST(N'2020-08-19T00:00:00.000' AS DateTime), CAST(N'2020-08-19T00:00:00.000' AS DateTime), NULL, NULL, NULL, NULL, 23175, 23175, 23175, 0, 0, 1, NULL, NULL, 0, NULL, NULL, NULL, NULL)
INSERT [dbo].[ChungTuBanHang] ([MaChungTuBanHang], [MaKhachHang], [DienGiai], [MaSoNhanVien], [NgayHoachToan], [NgayChungTu], [MaDieuKhoan], [SoNgayDuocNo], [HanThanhToan], [MaLoaiTien], [TyGia], [TongTienHang], [TienThueGTGT], [TienChietKhau], [TongTienThanhToan], [DaGhiSo], [MaSoBaoGia], [MaPhieuGoc], [DaThayDoi], [MaPhieuMoi], [NgayThayDoi], [NhanVienThayDoi], [CoSoThayDoi]) VALUES (N'BH000008', N'KH000001', N'Bán hàng Công ty cổ phần, thương mại và dịch vụ Mekong', N'0001', CAST(N'2020-08-19T00:00:00.000' AS DateTime), CAST(N'2020-08-19T00:00:00.000' AS DateTime), 1, 2, CAST(N'2020-08-19' AS Date), 1, 1000, 4900000, 980000, 0, 5880000, 1, NULL, NULL, 0, NULL, NULL, NULL, NULL)
INSERT [dbo].[ChungTuBanHang] ([MaChungTuBanHang], [MaKhachHang], [DienGiai], [MaSoNhanVien], [NgayHoachToan], [NgayChungTu], [MaDieuKhoan], [SoNgayDuocNo], [HanThanhToan], [MaLoaiTien], [TyGia], [TongTienHang], [TienThueGTGT], [TienChietKhau], [TongTienThanhToan], [DaGhiSo], [MaSoBaoGia], [MaPhieuGoc], [DaThayDoi], [MaPhieuMoi], [NgayThayDoi], [NhanVienThayDoi], [CoSoThayDoi]) VALUES (N'BH000009', N'KH000001', N'Bán hàng Công ty cổ phần, thương mại và dịch vụ Mekong', N'0001', CAST(N'2020-08-19T00:00:00.000' AS DateTime), CAST(N'2020-08-19T00:00:00.000' AS DateTime), 1, 2, CAST(N'2020-08-28' AS Date), 1, 1000, 4725000, 945000, 23175, 5670000, 1, NULL, NULL, 0, NULL, NULL, NULL, NULL)
INSERT [dbo].[ChungTuBanHang] ([MaChungTuBanHang], [MaKhachHang], [DienGiai], [MaSoNhanVien], [NgayHoachToan], [NgayChungTu], [MaDieuKhoan], [SoNgayDuocNo], [HanThanhToan], [MaLoaiTien], [TyGia], [TongTienHang], [TienThueGTGT], [TienChietKhau], [TongTienThanhToan], [DaGhiSo], [MaSoBaoGia], [MaPhieuGoc], [DaThayDoi], [MaPhieuMoi], [NgayThayDoi], [NhanVienThayDoi], [CoSoThayDoi]) VALUES (N'BH000010', N'KH000002', N'Bán hàng Công ty TNHH Công Minh', N'0002', CAST(N'2020-08-19T00:00:00.000' AS DateTime), CAST(N'2020-08-19T00:00:00.000' AS DateTime), 1, 4, CAST(N'2020-08-14' AS Date), 2, 23175, 3325000, 665000, 0, 3990000, 1, NULL, NULL, 0, NULL, NULL, NULL, NULL)
INSERT [dbo].[ChungTuBanHang] ([MaChungTuBanHang], [MaKhachHang], [DienGiai], [MaSoNhanVien], [NgayHoachToan], [NgayChungTu], [MaDieuKhoan], [SoNgayDuocNo], [HanThanhToan], [MaLoaiTien], [TyGia], [TongTienHang], [TienThueGTGT], [TienChietKhau], [TongTienThanhToan], [DaGhiSo], [MaSoBaoGia], [MaPhieuGoc], [DaThayDoi], [MaPhieuMoi], [NgayThayDoi], [NhanVienThayDoi], [CoSoThayDoi]) VALUES (N'BH000011', N'KH000002', N'Bán hàng Công ty TNHH Công Minh', N'0001', CAST(N'2020-08-19T00:00:00.000' AS DateTime), CAST(N'2020-08-19T00:00:00.000' AS DateTime), 1, 2, CAST(N'2020-08-21' AS Date), 1, 1000, 5775000, 1155000, 0, 6930000, 1, NULL, NULL, 0, NULL, NULL, NULL, NULL)
INSERT [dbo].[ChungTuBanHang] ([MaChungTuBanHang], [MaKhachHang], [DienGiai], [MaSoNhanVien], [NgayHoachToan], [NgayChungTu], [MaDieuKhoan], [SoNgayDuocNo], [HanThanhToan], [MaLoaiTien], [TyGia], [TongTienHang], [TienThueGTGT], [TienChietKhau], [TongTienThanhToan], [DaGhiSo], [MaSoBaoGia], [MaPhieuGoc], [DaThayDoi], [MaPhieuMoi], [NgayThayDoi], [NhanVienThayDoi], [CoSoThayDoi]) VALUES (N'BH000012', N'KH000004', N'Bán hàng Biện Công Nhân', NULL, CAST(N'2020-08-19T00:00:00.000' AS DateTime), CAST(N'2020-08-19T00:00:00.000' AS DateTime), 1, 5, CAST(N'2020-08-21' AS Date), 1, 1000, 5075000, 1015000, 0, 6090000, 1, NULL, NULL, 0, NULL, NULL, NULL, NULL)
INSERT [dbo].[ChungTuBanHang] ([MaChungTuBanHang], [MaKhachHang], [DienGiai], [MaSoNhanVien], [NgayHoachToan], [NgayChungTu], [MaDieuKhoan], [SoNgayDuocNo], [HanThanhToan], [MaLoaiTien], [TyGia], [TongTienHang], [TienThueGTGT], [TienChietKhau], [TongTienThanhToan], [DaGhiSo], [MaSoBaoGia], [MaPhieuGoc], [DaThayDoi], [MaPhieuMoi], [NgayThayDoi], [NhanVienThayDoi], [CoSoThayDoi]) VALUES (N'BH000013', N'KH000001', N'Bán hàng Công ty cổ phần, thương mại và dịch vụ Mekong', N'0001', CAST(N'2020-08-19T00:00:00.000' AS DateTime), CAST(N'2020-08-19T00:00:00.000' AS DateTime), 1, 4, NULL, 1, 1000, 8275000, 1905000, 0, 10180000, 1, NULL, NULL, 0, NULL, NULL, NULL, NULL)
INSERT [dbo].[ChungTuBanHang] ([MaChungTuBanHang], [MaKhachHang], [DienGiai], [MaSoNhanVien], [NgayHoachToan], [NgayChungTu], [MaDieuKhoan], [SoNgayDuocNo], [HanThanhToan], [MaLoaiTien], [TyGia], [TongTienHang], [TienThueGTGT], [TienChietKhau], [TongTienThanhToan], [DaGhiSo], [MaSoBaoGia], [MaPhieuGoc], [DaThayDoi], [MaPhieuMoi], [NgayThayDoi], [NhanVienThayDoi], [CoSoThayDoi]) VALUES (N'BH000014', N'KH000001', N'Bán hàng Công ty cổ phần, thương mại và dịch vụ Mekong', N'0003', CAST(N'2020-08-19T00:00:00.000' AS DateTime), CAST(N'2020-08-19T00:00:00.000' AS DateTime), 2, 2, CAST(N'2020-08-21' AS Date), 2, 23175, 4200000, 840000, 0, 5040000, 1, NULL, NULL, 0, NULL, NULL, NULL, NULL)
INSERT [dbo].[ChungTuBanHang] ([MaChungTuBanHang], [MaKhachHang], [DienGiai], [MaSoNhanVien], [NgayHoachToan], [NgayChungTu], [MaDieuKhoan], [SoNgayDuocNo], [HanThanhToan], [MaLoaiTien], [TyGia], [TongTienHang], [TienThueGTGT], [TienChietKhau], [TongTienThanhToan], [DaGhiSo], [MaSoBaoGia], [MaPhieuGoc], [DaThayDoi], [MaPhieuMoi], [NgayThayDoi], [NhanVienThayDoi], [CoSoThayDoi]) VALUES (N'BH000015', N'KH000001', N'Bán hàng Công ty cổ phần, thương mại và dịch vụ Mekong', N'0001', CAST(N'2020-08-19T00:00:00.000' AS DateTime), CAST(N'2020-08-19T00:00:00.000' AS DateTime), 1, 2, CAST(N'2020-08-21' AS Date), 2, 23175, 3750000, 1125000, 23175, 4875000, 1, NULL, NULL, 0, NULL, NULL, NULL, NULL)
INSERT [dbo].[ChungTuBanHang] ([MaChungTuBanHang], [MaKhachHang], [DienGiai], [MaSoNhanVien], [NgayHoachToan], [NgayChungTu], [MaDieuKhoan], [SoNgayDuocNo], [HanThanhToan], [MaLoaiTien], [TyGia], [TongTienHang], [TienThueGTGT], [TienChietKhau], [TongTienThanhToan], [DaGhiSo], [MaSoBaoGia], [MaPhieuGoc], [DaThayDoi], [MaPhieuMoi], [NgayThayDoi], [NhanVienThayDoi], [CoSoThayDoi]) VALUES (N'BH000016', N'KH000005', N'Bán hàng Cao Châu Minh Thư', N'0005', CAST(N'2020-08-19T00:00:00.000' AS DateTime), CAST(N'2020-08-19T00:00:00.000' AS DateTime), 1, 3, CAST(N'2020-08-21' AS Date), 1, 1000, 2625000, 525000, 0, 3150000, 1, NULL, NULL, 0, NULL, NULL, NULL, NULL)
INSERT [dbo].[ChungTuBanHang] ([MaChungTuBanHang], [MaKhachHang], [DienGiai], [MaSoNhanVien], [NgayHoachToan], [NgayChungTu], [MaDieuKhoan], [SoNgayDuocNo], [HanThanhToan], [MaLoaiTien], [TyGia], [TongTienHang], [TienThueGTGT], [TienChietKhau], [TongTienThanhToan], [DaGhiSo], [MaSoBaoGia], [MaPhieuGoc], [DaThayDoi], [MaPhieuMoi], [NgayThayDoi], [NhanVienThayDoi], [CoSoThayDoi]) VALUES (N'BH000017', N'KH000012', N'Bán hàng Đỗ Nguyệt Quế', N'0007', CAST(N'2020-08-19T00:00:00.000' AS DateTime), CAST(N'2020-08-19T00:00:00.000' AS DateTime), 2, 2, CAST(N'2020-08-28' AS Date), 1, 1000, 28950000, 6165000, 0, 35115000, 1, NULL, NULL, 0, NULL, NULL, NULL, NULL)
INSERT [dbo].[ChungTuBanHang] ([MaChungTuBanHang], [MaKhachHang], [DienGiai], [MaSoNhanVien], [NgayHoachToan], [NgayChungTu], [MaDieuKhoan], [SoNgayDuocNo], [HanThanhToan], [MaLoaiTien], [TyGia], [TongTienHang], [TienThueGTGT], [TienChietKhau], [TongTienThanhToan], [DaGhiSo], [MaSoBaoGia], [MaPhieuGoc], [DaThayDoi], [MaPhieuMoi], [NgayThayDoi], [NhanVienThayDoi], [CoSoThayDoi]) VALUES (N'BH000018', N'KH000001', N'Bán hàng Công ty cổ phần, thương mại và dịch vụ Mekong', N'0001', CAST(N'2020-08-19T00:00:00.000' AS DateTime), CAST(N'2020-08-19T00:00:00.000' AS DateTime), 1, 2, CAST(N'2020-08-20' AS Date), 1, 1000, 2450000, 490000, 0, 2940000, 1, NULL, NULL, 0, NULL, NULL, NULL, NULL)
INSERT [dbo].[ChungTuBanHang] ([MaChungTuBanHang], [MaKhachHang], [DienGiai], [MaSoNhanVien], [NgayHoachToan], [NgayChungTu], [MaDieuKhoan], [SoNgayDuocNo], [HanThanhToan], [MaLoaiTien], [TyGia], [TongTienHang], [TienThueGTGT], [TienChietKhau], [TongTienThanhToan], [DaGhiSo], [MaSoBaoGia], [MaPhieuGoc], [DaThayDoi], [MaPhieuMoi], [NgayThayDoi], [NhanVienThayDoi], [CoSoThayDoi]) VALUES (N'BH000019', N'KH000002', N'Bán hàng Công ty TNHH Công Minh', N'0002', CAST(N'2020-08-19T00:00:00.000' AS DateTime), CAST(N'2020-08-19T00:00:00.000' AS DateTime), 1, 12, CAST(N'2020-08-29' AS Date), 1, 1000, 4000000, 1200000, 0, 5200000, 1, NULL, NULL, 0, NULL, NULL, NULL, NULL)
INSERT [dbo].[ChungTuBanHang] ([MaChungTuBanHang], [MaKhachHang], [DienGiai], [MaSoNhanVien], [NgayHoachToan], [NgayChungTu], [MaDieuKhoan], [SoNgayDuocNo], [HanThanhToan], [MaLoaiTien], [TyGia], [TongTienHang], [TienThueGTGT], [TienChietKhau], [TongTienThanhToan], [DaGhiSo], [MaSoBaoGia], [MaPhieuGoc], [DaThayDoi], [MaPhieuMoi], [NgayThayDoi], [NhanVienThayDoi], [CoSoThayDoi]) VALUES (N'BH000020', N'KH000001', N'Bán hàng Công ty cổ phần, thương mại và dịch vụ Mekong', N'0001', CAST(N'2020-08-19T00:00:00.000' AS DateTime), CAST(N'2020-08-19T00:00:00.000' AS DateTime), 1, 2, CAST(N'2020-08-22' AS Date), 2, 23175, 4000000, 1200000, 0, 5200000, 1, NULL, NULL, 0, NULL, NULL, NULL, NULL)
INSERT [dbo].[ChungTuBanHang] ([MaChungTuBanHang], [MaKhachHang], [DienGiai], [MaSoNhanVien], [NgayHoachToan], [NgayChungTu], [MaDieuKhoan], [SoNgayDuocNo], [HanThanhToan], [MaLoaiTien], [TyGia], [TongTienHang], [TienThueGTGT], [TienChietKhau], [TongTienThanhToan], [DaGhiSo], [MaSoBaoGia], [MaPhieuGoc], [DaThayDoi], [MaPhieuMoi], [NgayThayDoi], [NhanVienThayDoi], [CoSoThayDoi]) VALUES (N'BH000021', N'KH000002', N'Bán hàng Công ty TNHH Công Minh', N'0002', CAST(N'2020-08-19T00:00:00.000' AS DateTime), CAST(N'2020-08-19T00:00:00.000' AS DateTime), 1, 2, CAST(N'2020-08-13' AS Date), 2, 23175, 2450000, 490000, 0, 2940000, 1, NULL, NULL, 0, NULL, NULL, NULL, NULL)
INSERT [dbo].[ChungTuBanHang] ([MaChungTuBanHang], [MaKhachHang], [DienGiai], [MaSoNhanVien], [NgayHoachToan], [NgayChungTu], [MaDieuKhoan], [SoNgayDuocNo], [HanThanhToan], [MaLoaiTien], [TyGia], [TongTienHang], [TienThueGTGT], [TienChietKhau], [TongTienThanhToan], [DaGhiSo], [MaSoBaoGia], [MaPhieuGoc], [DaThayDoi], [MaPhieuMoi], [NgayThayDoi], [NhanVienThayDoi], [CoSoThayDoi]) VALUES (N'BH000022', N'KH000002', N'Bán hàng Công ty TNHH Công Minh', NULL, CAST(N'2020-08-19T00:00:00.000' AS DateTime), CAST(N'2020-08-19T00:00:00.000' AS DateTime), 1, 2, CAST(N'2020-08-29' AS Date), 1, 1000, 4000000, 1200000, 0, 5200000, 1, NULL, NULL, 0, NULL, NULL, NULL, NULL)
INSERT [dbo].[ChungTuBanHang] ([MaChungTuBanHang], [MaKhachHang], [DienGiai], [MaSoNhanVien], [NgayHoachToan], [NgayChungTu], [MaDieuKhoan], [SoNgayDuocNo], [HanThanhToan], [MaLoaiTien], [TyGia], [TongTienHang], [TienThueGTGT], [TienChietKhau], [TongTienThanhToan], [DaGhiSo], [MaSoBaoGia], [MaPhieuGoc], [DaThayDoi], [MaPhieuMoi], [NgayThayDoi], [NhanVienThayDoi], [CoSoThayDoi]) VALUES (N'BH000023', N'KH000002', N'Bán hàng Công ty TNHH Công Minh', N'0002', CAST(N'2020-08-19T00:00:00.000' AS DateTime), CAST(N'2020-08-19T00:00:00.000' AS DateTime), 1, 3, CAST(N'2020-08-28' AS Date), 1, 1000, 2625000, 525000, 0, 3150000, 1, NULL, NULL, 0, NULL, NULL, NULL, NULL)
INSERT [dbo].[ChungTuBanHang] ([MaChungTuBanHang], [MaKhachHang], [DienGiai], [MaSoNhanVien], [NgayHoachToan], [NgayChungTu], [MaDieuKhoan], [SoNgayDuocNo], [HanThanhToan], [MaLoaiTien], [TyGia], [TongTienHang], [TienThueGTGT], [TienChietKhau], [TongTienThanhToan], [DaGhiSo], [MaSoBaoGia], [MaPhieuGoc], [DaThayDoi], [MaPhieuMoi], [NgayThayDoi], [NhanVienThayDoi], [CoSoThayDoi]) VALUES (N'BH000024', N'KH000001', N'Bán hàng Công ty cổ phần, thương mại và dịch vụ Mekong', NULL, CAST(N'2020-08-19T00:00:00.000' AS DateTime), CAST(N'2020-08-19T00:00:00.000' AS DateTime), 1, 2, CAST(N'2020-08-28' AS Date), 2, 23175, 9525000, 2280000, 0, 11805000, 1, NULL, NULL, 0, NULL, NULL, NULL, NULL)
INSERT [dbo].[ChungTuBanHang] ([MaChungTuBanHang], [MaKhachHang], [DienGiai], [MaSoNhanVien], [NgayHoachToan], [NgayChungTu], [MaDieuKhoan], [SoNgayDuocNo], [HanThanhToan], [MaLoaiTien], [TyGia], [TongTienHang], [TienThueGTGT], [TienChietKhau], [TongTienThanhToan], [DaGhiSo], [MaSoBaoGia], [MaPhieuGoc], [DaThayDoi], [MaPhieuMoi], [NgayThayDoi], [NhanVienThayDoi], [CoSoThayDoi]) VALUES (N'BH000025', N'KH000001', NULL, N'0001', CAST(N'2020-08-27T00:00:00.000' AS DateTime), CAST(N'2020-08-27T00:00:00.000' AS DateTime), NULL, NULL, NULL, NULL, NULL, 8000000, NULL, NULL, 8000000, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL)
INSERT [dbo].[ChungTuBanHang] ([MaChungTuBanHang], [MaKhachHang], [DienGiai], [MaSoNhanVien], [NgayHoachToan], [NgayChungTu], [MaDieuKhoan], [SoNgayDuocNo], [HanThanhToan], [MaLoaiTien], [TyGia], [TongTienHang], [TienThueGTGT], [TienChietKhau], [TongTienThanhToan], [DaGhiSo], [MaSoBaoGia], [MaPhieuGoc], [DaThayDoi], [MaPhieuMoi], [NgayThayDoi], [NhanVienThayDoi], [CoSoThayDoi]) VALUES (N'BH000026', N'KH000001', N'Bán hàng ', N'0001', CAST(N'2020-08-20T00:00:00.000' AS DateTime), CAST(N'2020-08-20T00:00:00.000' AS DateTime), 2, 2, CAST(N'2020-08-28' AS Date), 1, 1000, 1225000, 245000, 0, 1470000, 0, N'BG000001', NULL, 0, NULL, NULL, NULL, NULL)
INSERT [dbo].[ChungTuBanHang] ([MaChungTuBanHang], [MaKhachHang], [DienGiai], [MaSoNhanVien], [NgayHoachToan], [NgayChungTu], [MaDieuKhoan], [SoNgayDuocNo], [HanThanhToan], [MaLoaiTien], [TyGia], [TongTienHang], [TienThueGTGT], [TienChietKhau], [TongTienThanhToan], [DaGhiSo], [MaSoBaoGia], [MaPhieuGoc], [DaThayDoi], [MaPhieuMoi], [NgayThayDoi], [NhanVienThayDoi], [CoSoThayDoi]) VALUES (N'BH000027', N'KH000002', N'Bán hàng Công ty cổ phần, thương mại và dịch vụ Mekong', N'0001', CAST(N'2020-08-20T00:00:00.000' AS DateTime), CAST(N'2020-08-20T00:00:00.000' AS DateTime), 1, 2, CAST(N'2020-08-29' AS Date), 1, 1000, 8700000, 2015000, 0, 10715000, 0, N'BG000002', NULL, 0, NULL, NULL, NULL, NULL)
INSERT [dbo].[ChungTuBanHang] ([MaChungTuBanHang], [MaKhachHang], [DienGiai], [MaSoNhanVien], [NgayHoachToan], [NgayChungTu], [MaDieuKhoan], [SoNgayDuocNo], [HanThanhToan], [MaLoaiTien], [TyGia], [TongTienHang], [TienThueGTGT], [TienChietKhau], [TongTienThanhToan], [DaGhiSo], [MaSoBaoGia], [MaPhieuGoc], [DaThayDoi], [MaPhieuMoi], [NgayThayDoi], [NhanVienThayDoi], [CoSoThayDoi]) VALUES (N'BH000028', N'KH000001', NULL, N'0001', NULL, CAST(N'2020-08-20T00:00:00.000' AS DateTime), NULL, NULL, NULL, NULL, NULL, 65300000, NULL, NULL, 65300000, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL)
INSERT [dbo].[ChungTuBanHang] ([MaChungTuBanHang], [MaKhachHang], [DienGiai], [MaSoNhanVien], [NgayHoachToan], [NgayChungTu], [MaDieuKhoan], [SoNgayDuocNo], [HanThanhToan], [MaLoaiTien], [TyGia], [TongTienHang], [TienThueGTGT], [TienChietKhau], [TongTienThanhToan], [DaGhiSo], [MaSoBaoGia], [MaPhieuGoc], [DaThayDoi], [MaPhieuMoi], [NgayThayDoi], [NhanVienThayDoi], [CoSoThayDoi]) VALUES (N'BH000029', N'KH000000', NULL, N'0001', CAST(N'2020-01-09T15:17:00.000' AS DateTime), CAST(N'2020-08-20T00:00:00.000' AS DateTime), NULL, NULL, NULL, NULL, NULL, 1362000, NULL, NULL, 1362000, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL)
INSERT [dbo].[ChungTuBanHang] ([MaChungTuBanHang], [MaKhachHang], [DienGiai], [MaSoNhanVien], [NgayHoachToan], [NgayChungTu], [MaDieuKhoan], [SoNgayDuocNo], [HanThanhToan], [MaLoaiTien], [TyGia], [TongTienHang], [TienThueGTGT], [TienChietKhau], [TongTienThanhToan], [DaGhiSo], [MaSoBaoGia], [MaPhieuGoc], [DaThayDoi], [MaPhieuMoi], [NgayThayDoi], [NhanVienThayDoi], [CoSoThayDoi]) VALUES (N'BH000030', NULL, NULL, N'0001', CAST(N'2020-01-09T15:17:40.000' AS DateTime), CAST(N'2020-08-20T00:00:00.000' AS DateTime), NULL, NULL, NULL, NULL, NULL, 520000, NULL, NULL, 520000, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL)
INSERT [dbo].[ChungTuBanHang] ([MaChungTuBanHang], [MaKhachHang], [DienGiai], [MaSoNhanVien], [NgayHoachToan], [NgayChungTu], [MaDieuKhoan], [SoNgayDuocNo], [HanThanhToan], [MaLoaiTien], [TyGia], [TongTienHang], [TienThueGTGT], [TienChietKhau], [TongTienThanhToan], [DaGhiSo], [MaSoBaoGia], [MaPhieuGoc], [DaThayDoi], [MaPhieuMoi], [NgayThayDoi], [NhanVienThayDoi], [CoSoThayDoi]) VALUES (N'BH000031', NULL, NULL, N'0001', CAST(N'2020-01-09T15:17:50.000' AS DateTime), CAST(N'2020-08-20T00:00:00.000' AS DateTime), NULL, NULL, NULL, NULL, NULL, 1855000, NULL, NULL, 1855000, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL)
INSERT [dbo].[ChungTuBanHang] ([MaChungTuBanHang], [MaKhachHang], [DienGiai], [MaSoNhanVien], [NgayHoachToan], [NgayChungTu], [MaDieuKhoan], [SoNgayDuocNo], [HanThanhToan], [MaLoaiTien], [TyGia], [TongTienHang], [TienThueGTGT], [TienChietKhau], [TongTienThanhToan], [DaGhiSo], [MaSoBaoGia], [MaPhieuGoc], [DaThayDoi], [MaPhieuMoi], [NgayThayDoi], [NhanVienThayDoi], [CoSoThayDoi]) VALUES (N'BH000032', NULL, NULL, N'0001', CAST(N'2020-01-09T15:18:05.000' AS DateTime), CAST(N'2020-08-20T00:00:00.000' AS DateTime), NULL, NULL, NULL, NULL, NULL, 1817000, NULL, NULL, 1817000, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL)
INSERT [dbo].[ChungTuBanHang] ([MaChungTuBanHang], [MaKhachHang], [DienGiai], [MaSoNhanVien], [NgayHoachToan], [NgayChungTu], [MaDieuKhoan], [SoNgayDuocNo], [HanThanhToan], [MaLoaiTien], [TyGia], [TongTienHang], [TienThueGTGT], [TienChietKhau], [TongTienThanhToan], [DaGhiSo], [MaSoBaoGia], [MaPhieuGoc], [DaThayDoi], [MaPhieuMoi], [NgayThayDoi], [NhanVienThayDoi], [CoSoThayDoi]) VALUES (N'BH000033', NULL, NULL, N'0001', CAST(N'2020-01-09T15:18:15.000' AS DateTime), CAST(N'2020-08-20T00:00:00.000' AS DateTime), NULL, NULL, NULL, NULL, NULL, 1629000, NULL, NULL, 1629000, NULL, NULL, NULL, 1, N'BH000054', CAST(N'2020-09-03T17:19:13.000' AS DateTime), N'0001', N'001')
INSERT [dbo].[ChungTuBanHang] ([MaChungTuBanHang], [MaKhachHang], [DienGiai], [MaSoNhanVien], [NgayHoachToan], [NgayChungTu], [MaDieuKhoan], [SoNgayDuocNo], [HanThanhToan], [MaLoaiTien], [TyGia], [TongTienHang], [TienThueGTGT], [TienChietKhau], [TongTienThanhToan], [DaGhiSo], [MaSoBaoGia], [MaPhieuGoc], [DaThayDoi], [MaPhieuMoi], [NgayThayDoi], [NhanVienThayDoi], [CoSoThayDoi]) VALUES (N'BH000034', N'KH000000', NULL, N'0001', CAST(N'2020-01-09T16:05:42.000' AS DateTime), CAST(N'2020-08-20T00:00:00.000' AS DateTime), NULL, NULL, NULL, NULL, NULL, 197000, NULL, NULL, 197000, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL)
INSERT [dbo].[ChungTuBanHang] ([MaChungTuBanHang], [MaKhachHang], [DienGiai], [MaSoNhanVien], [NgayHoachToan], [NgayChungTu], [MaDieuKhoan], [SoNgayDuocNo], [HanThanhToan], [MaLoaiTien], [TyGia], [TongTienHang], [TienThueGTGT], [TienChietKhau], [TongTienThanhToan], [DaGhiSo], [MaSoBaoGia], [MaPhieuGoc], [DaThayDoi], [MaPhieuMoi], [NgayThayDoi], [NhanVienThayDoi], [CoSoThayDoi]) VALUES (N'BH000035', NULL, NULL, N'0001', CAST(N'2020-01-09T16:05:48.000' AS DateTime), CAST(N'2020-08-09T16:05:48.000' AS DateTime), NULL, NULL, NULL, NULL, NULL, 642000, NULL, NULL, 642000, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL)
INSERT [dbo].[ChungTuBanHang] ([MaChungTuBanHang], [MaKhachHang], [DienGiai], [MaSoNhanVien], [NgayHoachToan], [NgayChungTu], [MaDieuKhoan], [SoNgayDuocNo], [HanThanhToan], [MaLoaiTien], [TyGia], [TongTienHang], [TienThueGTGT], [TienChietKhau], [TongTienThanhToan], [DaGhiSo], [MaSoBaoGia], [MaPhieuGoc], [DaThayDoi], [MaPhieuMoi], [NgayThayDoi], [NhanVienThayDoi], [CoSoThayDoi]) VALUES (N'BH000036', NULL, NULL, N'0001', CAST(N'2020-01-09T16:05:53.000' AS DateTime), CAST(N'2020-08-09T16:05:53.000' AS DateTime), NULL, NULL, NULL, NULL, NULL, 1035000, NULL, NULL, 1035000, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL)
INSERT [dbo].[ChungTuBanHang] ([MaChungTuBanHang], [MaKhachHang], [DienGiai], [MaSoNhanVien], [NgayHoachToan], [NgayChungTu], [MaDieuKhoan], [SoNgayDuocNo], [HanThanhToan], [MaLoaiTien], [TyGia], [TongTienHang], [TienThueGTGT], [TienChietKhau], [TongTienThanhToan], [DaGhiSo], [MaSoBaoGia], [MaPhieuGoc], [DaThayDoi], [MaPhieuMoi], [NgayThayDoi], [NhanVienThayDoi], [CoSoThayDoi]) VALUES (N'BH000037', NULL, NULL, N'0001', CAST(N'2020-01-09T16:06:00.000' AS DateTime), CAST(N'2020-08-09T16:06:00.000' AS DateTime), NULL, NULL, NULL, NULL, NULL, 885000, NULL, NULL, 885000, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL)
INSERT [dbo].[ChungTuBanHang] ([MaChungTuBanHang], [MaKhachHang], [DienGiai], [MaSoNhanVien], [NgayHoachToan], [NgayChungTu], [MaDieuKhoan], [SoNgayDuocNo], [HanThanhToan], [MaLoaiTien], [TyGia], [TongTienHang], [TienThueGTGT], [TienChietKhau], [TongTienThanhToan], [DaGhiSo], [MaSoBaoGia], [MaPhieuGoc], [DaThayDoi], [MaPhieuMoi], [NgayThayDoi], [NhanVienThayDoi], [CoSoThayDoi]) VALUES (N'BH000038', NULL, NULL, N'0001', CAST(N'2020-01-09T16:06:04.000' AS DateTime), CAST(N'2020-08-09T16:06:04.000' AS DateTime), NULL, NULL, NULL, NULL, NULL, 1055000, NULL, NULL, 1055000, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL)
INSERT [dbo].[ChungTuBanHang] ([MaChungTuBanHang], [MaKhachHang], [DienGiai], [MaSoNhanVien], [NgayHoachToan], [NgayChungTu], [MaDieuKhoan], [SoNgayDuocNo], [HanThanhToan], [MaLoaiTien], [TyGia], [TongTienHang], [TienThueGTGT], [TienChietKhau], [TongTienThanhToan], [DaGhiSo], [MaSoBaoGia], [MaPhieuGoc], [DaThayDoi], [MaPhieuMoi], [NgayThayDoi], [NhanVienThayDoi], [CoSoThayDoi]) VALUES (N'BH000039', NULL, NULL, N'0001', CAST(N'2020-01-09T16:06:09.000' AS DateTime), CAST(N'2020-08-09T16:06:09.000' AS DateTime), NULL, NULL, NULL, NULL, NULL, 1482000, NULL, NULL, 1482000, NULL, NULL, NULL, 1, N'BH000040', CAST(N'2020-01-09T16:09:05.000' AS DateTime), N'0001', N'001')
INSERT [dbo].[ChungTuBanHang] ([MaChungTuBanHang], [MaKhachHang], [DienGiai], [MaSoNhanVien], [NgayHoachToan], [NgayChungTu], [MaDieuKhoan], [SoNgayDuocNo], [HanThanhToan], [MaLoaiTien], [TyGia], [TongTienHang], [TienThueGTGT], [TienChietKhau], [TongTienThanhToan], [DaGhiSo], [MaSoBaoGia], [MaPhieuGoc], [DaThayDoi], [MaPhieuMoi], [NgayThayDoi], [NhanVienThayDoi], [CoSoThayDoi]) VALUES (N'BH000040', NULL, NULL, N'0001', CAST(N'2020-01-09T16:09:05.000' AS DateTime), CAST(N'2020-08-09T16:09:05.000' AS DateTime), NULL, NULL, NULL, NULL, NULL, 2109000, NULL, NULL, 2109000, NULL, NULL, N'BH000039', 0, NULL, NULL, NULL, NULL)
INSERT [dbo].[ChungTuBanHang] ([MaChungTuBanHang], [MaKhachHang], [DienGiai], [MaSoNhanVien], [NgayHoachToan], [NgayChungTu], [MaDieuKhoan], [SoNgayDuocNo], [HanThanhToan], [MaLoaiTien], [TyGia], [TongTienHang], [TienThueGTGT], [TienChietKhau], [TongTienThanhToan], [DaGhiSo], [MaSoBaoGia], [MaPhieuGoc], [DaThayDoi], [MaPhieuMoi], [NgayThayDoi], [NhanVienThayDoi], [CoSoThayDoi]) VALUES (N'BH000041', N'KH000000', NULL, N'0001', CAST(N'2020-01-09T17:23:24.000' AS DateTime), CAST(N'2020-08-01T17:23:24.000' AS DateTime), NULL, NULL, NULL, NULL, NULL, 857000, NULL, NULL, 857000, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL)
INSERT [dbo].[ChungTuBanHang] ([MaChungTuBanHang], [MaKhachHang], [DienGiai], [MaSoNhanVien], [NgayHoachToan], [NgayChungTu], [MaDieuKhoan], [SoNgayDuocNo], [HanThanhToan], [MaLoaiTien], [TyGia], [TongTienHang], [TienThueGTGT], [TienChietKhau], [TongTienThanhToan], [DaGhiSo], [MaSoBaoGia], [MaPhieuGoc], [DaThayDoi], [MaPhieuMoi], [NgayThayDoi], [NhanVienThayDoi], [CoSoThayDoi]) VALUES (N'BH000042', NULL, NULL, N'0001', CAST(N'2020-01-09T17:23:46.000' AS DateTime), CAST(N'2020-08-05T17:23:46.000' AS DateTime), NULL, NULL, NULL, NULL, NULL, 772000, NULL, NULL, 772000, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL)
INSERT [dbo].[ChungTuBanHang] ([MaChungTuBanHang], [MaKhachHang], [DienGiai], [MaSoNhanVien], [NgayHoachToan], [NgayChungTu], [MaDieuKhoan], [SoNgayDuocNo], [HanThanhToan], [MaLoaiTien], [TyGia], [TongTienHang], [TienThueGTGT], [TienChietKhau], [TongTienThanhToan], [DaGhiSo], [MaSoBaoGia], [MaPhieuGoc], [DaThayDoi], [MaPhieuMoi], [NgayThayDoi], [NhanVienThayDoi], [CoSoThayDoi]) VALUES (N'BH000043', N'KH000000', NULL, N'0001', CAST(N'2020-01-09T17:24:44.000' AS DateTime), CAST(N'2020-08-20T00:00:00.000' AS DateTime), NULL, NULL, NULL, NULL, NULL, 612000, NULL, NULL, 612000, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL)
INSERT [dbo].[ChungTuBanHang] ([MaChungTuBanHang], [MaKhachHang], [DienGiai], [MaSoNhanVien], [NgayHoachToan], [NgayChungTu], [MaDieuKhoan], [SoNgayDuocNo], [HanThanhToan], [MaLoaiTien], [TyGia], [TongTienHang], [TienThueGTGT], [TienChietKhau], [TongTienThanhToan], [DaGhiSo], [MaSoBaoGia], [MaPhieuGoc], [DaThayDoi], [MaPhieuMoi], [NgayThayDoi], [NhanVienThayDoi], [CoSoThayDoi]) VALUES (N'BH000044', N'KH000000', NULL, N'0001', CAST(N'2020-01-09T17:24:57.000' AS DateTime), CAST(N'2020-08-20T00:00:00.000' AS DateTime), NULL, NULL, NULL, NULL, NULL, 547000, NULL, NULL, 547000, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL)
INSERT [dbo].[ChungTuBanHang] ([MaChungTuBanHang], [MaKhachHang], [DienGiai], [MaSoNhanVien], [NgayHoachToan], [NgayChungTu], [MaDieuKhoan], [SoNgayDuocNo], [HanThanhToan], [MaLoaiTien], [TyGia], [TongTienHang], [TienThueGTGT], [TienChietKhau], [TongTienThanhToan], [DaGhiSo], [MaSoBaoGia], [MaPhieuGoc], [DaThayDoi], [MaPhieuMoi], [NgayThayDoi], [NhanVienThayDoi], [CoSoThayDoi]) VALUES (N'BH000045', N'KH000000', NULL, N'0001', CAST(N'2020-09-02T17:24:44.000' AS DateTime), CAST(N'2020-09-03T17:24:44.000' AS DateTime), NULL, NULL, NULL, NULL, NULL, 612000, NULL, NULL, 612000, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL)
INSERT [dbo].[ChungTuBanHang] ([MaChungTuBanHang], [MaKhachHang], [DienGiai], [MaSoNhanVien], [NgayHoachToan], [NgayChungTu], [MaDieuKhoan], [SoNgayDuocNo], [HanThanhToan], [MaLoaiTien], [TyGia], [TongTienHang], [TienThueGTGT], [TienChietKhau], [TongTienThanhToan], [DaGhiSo], [MaSoBaoGia], [MaPhieuGoc], [DaThayDoi], [MaPhieuMoi], [NgayThayDoi], [NhanVienThayDoi], [CoSoThayDoi]) VALUES (N'BH000046', N'KH000000', NULL, N'0001', CAST(N'2020-09-01T14:53:38.000' AS DateTime), CAST(N'2020-09-01T14:53:38.000' AS DateTime), NULL, NULL, NULL, NULL, NULL, 1250000, NULL, NULL, 1250000, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL)
INSERT [dbo].[ChungTuBanHang] ([MaChungTuBanHang], [MaKhachHang], [DienGiai], [MaSoNhanVien], [NgayHoachToan], [NgayChungTu], [MaDieuKhoan], [SoNgayDuocNo], [HanThanhToan], [MaLoaiTien], [TyGia], [TongTienHang], [TienThueGTGT], [TienChietKhau], [TongTienThanhToan], [DaGhiSo], [MaSoBaoGia], [MaPhieuGoc], [DaThayDoi], [MaPhieuMoi], [NgayThayDoi], [NhanVienThayDoi], [CoSoThayDoi]) VALUES (N'BH000047', N'KH000000', NULL, N'0001', CAST(N'2020-09-01T14:55:34.000' AS DateTime), CAST(N'2020-09-01T14:55:34.000' AS DateTime), NULL, NULL, NULL, NULL, NULL, 417000, NULL, NULL, 417000, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL)
INSERT [dbo].[ChungTuBanHang] ([MaChungTuBanHang], [MaKhachHang], [DienGiai], [MaSoNhanVien], [NgayHoachToan], [NgayChungTu], [MaDieuKhoan], [SoNgayDuocNo], [HanThanhToan], [MaLoaiTien], [TyGia], [TongTienHang], [TienThueGTGT], [TienChietKhau], [TongTienThanhToan], [DaGhiSo], [MaSoBaoGia], [MaPhieuGoc], [DaThayDoi], [MaPhieuMoi], [NgayThayDoi], [NhanVienThayDoi], [CoSoThayDoi]) VALUES (N'BH000048', N'KH000000', NULL, N'0001', CAST(N'2020-09-02T14:56:29.000' AS DateTime), CAST(N'2020-09-02T14:56:29.000' AS DateTime), NULL, NULL, NULL, NULL, NULL, 977000, NULL, NULL, 977000, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL)
INSERT [dbo].[ChungTuBanHang] ([MaChungTuBanHang], [MaKhachHang], [DienGiai], [MaSoNhanVien], [NgayHoachToan], [NgayChungTu], [MaDieuKhoan], [SoNgayDuocNo], [HanThanhToan], [MaLoaiTien], [TyGia], [TongTienHang], [TienThueGTGT], [TienChietKhau], [TongTienThanhToan], [DaGhiSo], [MaSoBaoGia], [MaPhieuGoc], [DaThayDoi], [MaPhieuMoi], [NgayThayDoi], [NhanVienThayDoi], [CoSoThayDoi]) VALUES (N'BH000049', N'KH000000', NULL, N'0001', CAST(N'2020-09-03T00:00:00.000' AS DateTime), CAST(N'2020-09-02T00:00:00.000' AS DateTime), NULL, NULL, NULL, NULL, NULL, 1145000, NULL, NULL, 1145000, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL)
INSERT [dbo].[ChungTuBanHang] ([MaChungTuBanHang], [MaKhachHang], [DienGiai], [MaSoNhanVien], [NgayHoachToan], [NgayChungTu], [MaDieuKhoan], [SoNgayDuocNo], [HanThanhToan], [MaLoaiTien], [TyGia], [TongTienHang], [TienThueGTGT], [TienChietKhau], [TongTienThanhToan], [DaGhiSo], [MaSoBaoGia], [MaPhieuGoc], [DaThayDoi], [MaPhieuMoi], [NgayThayDoi], [NhanVienThayDoi], [CoSoThayDoi]) VALUES (N'BH000050', N'KH000000', NULL, N'0001', CAST(N'2020-09-03T15:02:34.000' AS DateTime), CAST(N'2020-09-02T15:02:34.000' AS DateTime), NULL, NULL, NULL, NULL, NULL, 1170000, NULL, NULL, 1170000, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL)
INSERT [dbo].[ChungTuBanHang] ([MaChungTuBanHang], [MaKhachHang], [DienGiai], [MaSoNhanVien], [NgayHoachToan], [NgayChungTu], [MaDieuKhoan], [SoNgayDuocNo], [HanThanhToan], [MaLoaiTien], [TyGia], [TongTienHang], [TienThueGTGT], [TienChietKhau], [TongTienThanhToan], [DaGhiSo], [MaSoBaoGia], [MaPhieuGoc], [DaThayDoi], [MaPhieuMoi], [NgayThayDoi], [NhanVienThayDoi], [CoSoThayDoi]) VALUES (N'BH000051', N'KH000000', NULL, N'0001', CAST(N'2020-09-03T15:02:34.000' AS DateTime), CAST(N'2020-09-03T17:02:34.000' AS DateTime), NULL, NULL, NULL, NULL, NULL, 1170000, NULL, NULL, 1170000, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL)
INSERT [dbo].[ChungTuBanHang] ([MaChungTuBanHang], [MaKhachHang], [DienGiai], [MaSoNhanVien], [NgayHoachToan], [NgayChungTu], [MaDieuKhoan], [SoNgayDuocNo], [HanThanhToan], [MaLoaiTien], [TyGia], [TongTienHang], [TienThueGTGT], [TienChietKhau], [TongTienThanhToan], [DaGhiSo], [MaSoBaoGia], [MaPhieuGoc], [DaThayDoi], [MaPhieuMoi], [NgayThayDoi], [NhanVienThayDoi], [CoSoThayDoi]) VALUES (N'BH000052', N'KH000000', NULL, N'0001', CAST(N'2020-09-03T17:16:56.000' AS DateTime), CAST(N'2020-09-02T17:16:56.000' AS DateTime), NULL, NULL, NULL, NULL, NULL, 1851000, NULL, NULL, 1851000, NULL, NULL, NULL, 1, N'BH000055', CAST(N'2020-09-03T17:19:59.000' AS DateTime), N'0001', N'001')
INSERT [dbo].[ChungTuBanHang] ([MaChungTuBanHang], [MaKhachHang], [DienGiai], [MaSoNhanVien], [NgayHoachToan], [NgayChungTu], [MaDieuKhoan], [SoNgayDuocNo], [HanThanhToan], [MaLoaiTien], [TyGia], [TongTienHang], [TienThueGTGT], [TienChietKhau], [TongTienThanhToan], [DaGhiSo], [MaSoBaoGia], [MaPhieuGoc], [DaThayDoi], [MaPhieuMoi], [NgayThayDoi], [NhanVienThayDoi], [CoSoThayDoi]) VALUES (N'BH000053', N'KH000000', NULL, N'0001', CAST(N'2020-09-03T17:17:17.000' AS DateTime), CAST(N'2020-09-03T17:17:17.000' AS DateTime), NULL, NULL, NULL, NULL, NULL, 755000, NULL, NULL, 755000, NULL, NULL, N'BH000052', 0, NULL, NULL, NULL, NULL)
INSERT [dbo].[ChungTuBanHang] ([MaChungTuBanHang], [MaKhachHang], [DienGiai], [MaSoNhanVien], [NgayHoachToan], [NgayChungTu], [MaDieuKhoan], [SoNgayDuocNo], [HanThanhToan], [MaLoaiTien], [TyGia], [TongTienHang], [TienThueGTGT], [TienChietKhau], [TongTienThanhToan], [DaGhiSo], [MaSoBaoGia], [MaPhieuGoc], [DaThayDoi], [MaPhieuMoi], [NgayThayDoi], [NhanVienThayDoi], [CoSoThayDoi]) VALUES (N'BH000054', N'KH000000', NULL, N'0001', CAST(N'2020-09-03T17:19:13.000' AS DateTime), CAST(N'2020-09-03T17:19:13.000' AS DateTime), NULL, NULL, NULL, NULL, NULL, 392000, NULL, NULL, 392000, NULL, NULL, N'BH000033', 0, NULL, NULL, NULL, NULL)
INSERT [dbo].[ChungTuBanHang] ([MaChungTuBanHang], [MaKhachHang], [DienGiai], [MaSoNhanVien], [NgayHoachToan], [NgayChungTu], [MaDieuKhoan], [SoNgayDuocNo], [HanThanhToan], [MaLoaiTien], [TyGia], [TongTienHang], [TienThueGTGT], [TienChietKhau], [TongTienThanhToan], [DaGhiSo], [MaSoBaoGia], [MaPhieuGoc], [DaThayDoi], [MaPhieuMoi], [NgayThayDoi], [NhanVienThayDoi], [CoSoThayDoi]) VALUES (N'BH000055', N'KH000000', NULL, N'0001', CAST(N'2020-09-03T17:19:59.000' AS DateTime), CAST(N'2020-09-03T17:19:59.000' AS DateTime), NULL, NULL, NULL, NULL, NULL, 195000, NULL, NULL, 195000, NULL, NULL, N'BH000052', 1, N'BH000056', CAST(N'2020-09-03T17:20:43.000' AS DateTime), N'0001', N'001')
INSERT [dbo].[ChungTuBanHang] ([MaChungTuBanHang], [MaKhachHang], [DienGiai], [MaSoNhanVien], [NgayHoachToan], [NgayChungTu], [MaDieuKhoan], [SoNgayDuocNo], [HanThanhToan], [MaLoaiTien], [TyGia], [TongTienHang], [TienThueGTGT], [TienChietKhau], [TongTienThanhToan], [DaGhiSo], [MaSoBaoGia], [MaPhieuGoc], [DaThayDoi], [MaPhieuMoi], [NgayThayDoi], [NhanVienThayDoi], [CoSoThayDoi]) VALUES (N'BH000056', N'KH000000', NULL, N'0001', CAST(N'2020-09-03T17:20:43.000' AS DateTime), CAST(N'2020-09-03T17:20:43.000' AS DateTime), NULL, NULL, NULL, NULL, NULL, 1109000, NULL, NULL, 1109000, NULL, NULL, N'BH000055', 0, NULL, NULL, NULL, NULL)
INSERT [dbo].[ChungTuMuaDichVu] ([MaChungTuMuaDichVu], [MaNhaCungCap], [DienGiai], [MaSoNhanVien], [MaDieuKhoan], [SoNgayDuocNo], [HanThanhToan], [MaLoaiTien], [TyGia], [NgayHoachToan], [NgayChungTu], [TienDichVu], [TienThueGTGT], [TienChietKhau], [TongTienThanhToan], [DaGhiSo]) VALUES (N'MDV000001', N'0001', N'Diễn giải', N'0001', 1, 2, CAST(N'2020-08-16' AS Date), 1, 1000, CAST(N'2020-08-17' AS Date), CAST(N'2020-08-17' AS Date), 7170000, 2249000, 0, 9419000, 0)
INSERT [dbo].[ChungTuMuaDichVu] ([MaChungTuMuaDichVu], [MaNhaCungCap], [DienGiai], [MaSoNhanVien], [MaDieuKhoan], [SoNgayDuocNo], [HanThanhToan], [MaLoaiTien], [TyGia], [NgayHoachToan], [NgayChungTu], [TienDichVu], [TienThueGTGT], [TienChietKhau], [TongTienThanhToan], [DaGhiSo]) VALUES (N'MDV000002', N'0002', N'Diễn giải', N'0001', 1, 2, CAST(N'2020-08-16' AS Date), 2, 1000, CAST(N'2020-08-17' AS Date), CAST(N'2020-08-17' AS Date), 8400000, 2515000, 0, 10915000, 1)
INSERT [dbo].[ChungTuMuaDichVu] ([MaChungTuMuaDichVu], [MaNhaCungCap], [DienGiai], [MaSoNhanVien], [MaDieuKhoan], [SoNgayDuocNo], [HanThanhToan], [MaLoaiTien], [TyGia], [NgayHoachToan], [NgayChungTu], [TienDichVu], [TienThueGTGT], [TienChietKhau], [TongTienThanhToan], [DaGhiSo]) VALUES (N'MDV000003', N'0002', N'ădawd', N'0001', 1, 2, CAST(N'2020-08-11' AS Date), 1, 1000, CAST(N'2020-08-17' AS Date), CAST(N'2020-08-17' AS Date), 4150000, 1465000, 0, 5615000, 1)
INSERT [dbo].[ChungTuMuaDichVu] ([MaChungTuMuaDichVu], [MaNhaCungCap], [DienGiai], [MaSoNhanVien], [MaDieuKhoan], [SoNgayDuocNo], [HanThanhToan], [MaLoaiTien], [TyGia], [NgayHoachToan], [NgayChungTu], [TienDichVu], [TienThueGTGT], [TienChietKhau], [TongTienThanhToan], [DaGhiSo]) VALUES (N'MDV000004', N'0001', N'Diễn giải', N'0001', 1, 1, CAST(N'2020-08-16' AS Date), 1, 1000, CAST(N'2020-08-17' AS Date), CAST(N'2020-08-17' AS Date), 3380000, 871000, 0, 4251000, 0)
INSERT [dbo].[ChungTuMuaHang] ([MaChungTuMuaHang], [MaNhaCungCap], [NguoiGiaoHang], [DienGiai], [MaSoNhanVien], [ChungTuGoc], [DieuKhoanTT], [SoNgayDuocNo], [HanThanhToan], [MaLoaiTien], [TyGia], [NgayHoachToan], [NgayChungTu], [TongTienHang], [ChiPhiGiaoHang], [TienChietKhau], [GiaTriNhapKho], [TongTienThanhToan]) VALUES (N'NK000001', N'0001', N'Người giao hàng', NULL, N'0001', 2, N'Điều khoản TT', 4, CAST(N'2020-02-02' AS Date), 1, 1000, CAST(N'2020-08-15' AS Date), NULL, 350000, 0, 0, NULL, 420000)
INSERT [dbo].[ChungTuMuaHang] ([MaChungTuMuaHang], [MaNhaCungCap], [NguoiGiaoHang], [DienGiai], [MaSoNhanVien], [ChungTuGoc], [DieuKhoanTT], [SoNgayDuocNo], [HanThanhToan], [MaLoaiTien], [TyGia], [NgayHoachToan], [NgayChungTu], [TongTienHang], [ChiPhiGiaoHang], [TienChietKhau], [GiaTriNhapKho], [TongTienThanhToan]) VALUES (N'NK000002', N'0001', N'Trần Văn Trường', NULL, N'0001', 2, N'Điều khoản TT', 2, CAST(N'2020-08-13' AS Date), 2, 23175, CAST(N'2020-08-15' AS Date), NULL, 675000, 0, 0, NULL, 860000)
INSERT [dbo].[ChungTuMuaHang] ([MaChungTuMuaHang], [MaNhaCungCap], [NguoiGiaoHang], [DienGiai], [MaSoNhanVien], [ChungTuGoc], [DieuKhoanTT], [SoNgayDuocNo], [HanThanhToan], [MaLoaiTien], [TyGia], [NgayHoachToan], [NgayChungTu], [TongTienHang], [ChiPhiGiaoHang], [TienChietKhau], [GiaTriNhapKho], [TongTienThanhToan]) VALUES (N'NK000003', N'0001', N'Người giao hàng', N'Diễn giải', N'0002', 3, N'Điều khoản TT', 3, CAST(N'2020-08-13' AS Date), 2, 111111, CAST(N'2020-08-15' AS Date), NULL, 5075000, 0, 0, 23, 6090000)
INSERT [dbo].[ChungTuMuaHang] ([MaChungTuMuaHang], [MaNhaCungCap], [NguoiGiaoHang], [DienGiai], [MaSoNhanVien], [ChungTuGoc], [DieuKhoanTT], [SoNgayDuocNo], [HanThanhToan], [MaLoaiTien], [TyGia], [NgayHoachToan], [NgayChungTu], [TongTienHang], [ChiPhiGiaoHang], [TienChietKhau], [GiaTriNhapKho], [TongTienThanhToan]) VALUES (N'NK000004', N'0001', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(N'2020-08-15' AS Date), NULL, 525000, 0, 0, 0, 630000)
INSERT [dbo].[ChungTuMuaHang] ([MaChungTuMuaHang], [MaNhaCungCap], [NguoiGiaoHang], [DienGiai], [MaSoNhanVien], [ChungTuGoc], [DieuKhoanTT], [SoNgayDuocNo], [HanThanhToan], [MaLoaiTien], [TyGia], [NgayHoachToan], [NgayChungTu], [TongTienHang], [ChiPhiGiaoHang], [TienChietKhau], [GiaTriNhapKho], [TongTienThanhToan]) VALUES (N'NK000005', N'0001', N'Trường', N'abc', N'0001', 2, N'1', 1, CAST(N'2020-08-19' AS Date), 1, 1000, CAST(N'2020-08-17' AS Date), NULL, 175000, 0, 0, 1, 210000)
INSERT [dbo].[ChungTuMuaHang] ([MaChungTuMuaHang], [MaNhaCungCap], [NguoiGiaoHang], [DienGiai], [MaSoNhanVien], [ChungTuGoc], [DieuKhoanTT], [SoNgayDuocNo], [HanThanhToan], [MaLoaiTien], [TyGia], [NgayHoachToan], [NgayChungTu], [TongTienHang], [ChiPhiGiaoHang], [TienChietKhau], [GiaTriNhapKho], [TongTienThanhToan]) VALUES (N'NK000006', N'0001', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(N'2020-08-17' AS Date), NULL, 0, 0, 0, 0, 0)
INSERT [dbo].[CoCauToChuc] ([MaDonVi], [TenDonVi], [DiaChi], [CapToChuc]) VALUES (N'000001', N'To chuc', N'80 trần phú', N'BBBBB')
INSERT [dbo].[CoCauToChuc] ([MaDonVi], [TenDonVi], [DiaChi], [CapToChuc]) VALUES (N'000002', N'tổ chức', N'80 trần phú', N'ABC')
INSERT [dbo].[CoCauToChuc] ([MaDonVi], [TenDonVi], [DiaChi], [CapToChuc]) VALUES (N'000003', N'cá nhân', N'20 Bà Triệu', N'cá nhân')
INSERT [dbo].[CoCauToChuc] ([MaDonVi], [TenDonVi], [DiaChi], [CapToChuc]) VALUES (N'000004', N'To chuc doanh nghiep', N'80 Hai bà trưng', N'Doanh nghiep')
INSERT [dbo].[CoSo] ([MaCoSo], [DiaChi], [TenCoSo], [CapToChuc]) VALUES (N'001', N'Rạch Giá Kiên Giang', N'Cơ sở Rạch Giá', NULL)
INSERT [dbo].[CoSo] ([MaCoSo], [DiaChi], [TenCoSo], [CapToChuc]) VALUES (N'002', N'Tp.HCM', N'Cơ sở Tp.HCM', NULL)
INSERT [dbo].[CoSo] ([MaCoSo], [DiaChi], [TenCoSo], [CapToChuc]) VALUES (N'003', N'Hà Nội', N'Cơ sở Hà Nội', NULL)
INSERT [dbo].[DichVu] ([MaDichVu], [TenDichVu], [DonViTinh], [DonGia], [VAT], [ChietKhau]) VALUES (N'Dich_Vu_1', N'Dịch Vụ 1', N'VND', 130000, 0.2, 0)
INSERT [dbo].[DichVu] ([MaDichVu], [TenDichVu], [DonViTinh], [DonGia], [VAT], [ChietKhau]) VALUES (N'Dich_Vu_2', N'Dịch Vụ 2', N'VND', 150000, 0.3, 0)
INSERT [dbo].[DichVu] ([MaDichVu], [TenDichVu], [DonViTinh], [DonGia], [VAT], [ChietKhau]) VALUES (N'Dich_Vu_3', N'Dịch Vụ 3', N'VND', 200000, 0.4, 0)
SET IDENTITY_INSERT [dbo].[DieuKhoanThanhToan] ON 

INSERT [dbo].[DieuKhoanThanhToan] ([MaDieuKhoan], [TenDieuKhoan]) VALUES (1, N'Điều khoản 1')
INSERT [dbo].[DieuKhoanThanhToan] ([MaDieuKhoan], [TenDieuKhoan]) VALUES (2, N'Điều khoản 2')
SET IDENTITY_INSERT [dbo].[DieuKhoanThanhToan] OFF
SET IDENTITY_INSERT [dbo].[DinhKhoanTuDong] ON 

INSERT [dbo].[DinhKhoanTuDong] ([Id], [LoaiChungTu], [TenDinhKhoan], [SoTaiKhoanCo], [SoTaiKhoanNo]) VALUES (1, N'Chi tiền gửi', N'Chi cho hoat dong dau tu', N'1122', N'1113')
SET IDENTITY_INSERT [dbo].[DinhKhoanTuDong] OFF
INSERT [dbo].[DonDatHang] ([MaDonDatHang], [MaKhachHang], [NguoiNhanHang], [DienGiai], [MaSoNhanVien], [MaDieuKhoan], [SoNgayDuocNo], [NgayDonHang], [MaTinhTrang], [NgayGiaoHang], [MaLoaiTien], [TyGia], [TongTienHang], [TienThueGTGT], [TongChietKhau], [TongTienThanhToan]) VALUES (N'ĐH000001', N'KH000001', N'Trường', N'Ghi chú', N'0001', 2, 2, CAST(N'2020-08-18' AS Date), 1, CAST(N'2020-08-19' AS Date), 1, NULL, 2325000, 540000, 0, 2865000)
INSERT [dbo].[DonDatHang] ([MaDonDatHang], [MaKhachHang], [NguoiNhanHang], [DienGiai], [MaSoNhanVien], [MaDieuKhoan], [SoNgayDuocNo], [NgayDonHang], [MaTinhTrang], [NgayGiaoHang], [MaLoaiTien], [TyGia], [TongTienHang], [TienThueGTGT], [TongChietKhau], [TongTienThanhToan]) VALUES (N'ĐH000002', N'KH000002', N'Luận', N'Ghi chú', N'0001', 2, 1, CAST(N'2020-08-18' AS Date), 1, CAST(N'2020-08-19' AS Date), 1, 1000, 7025000, 1705000, 0, 8730000)
INSERT [dbo].[DonDatHang] ([MaDonDatHang], [MaKhachHang], [NguoiNhanHang], [DienGiai], [MaSoNhanVien], [MaDieuKhoan], [SoNgayDuocNo], [NgayDonHang], [MaTinhTrang], [NgayGiaoHang], [MaLoaiTien], [TyGia], [TongTienHang], [TienThueGTGT], [TongChietKhau], [TongTienThanhToan]) VALUES (N'ĐH000003', N'KH000001', N'Khoa', N'Diễn giải', N'0001', 1, 2, CAST(N'2020-08-18' AS Date), 1, CAST(N'2020-08-19' AS Date), 1, 10000, 1225000, 245000, 0, 1470000)
INSERT [dbo].[DonDatHang] ([MaDonDatHang], [MaKhachHang], [NguoiNhanHang], [DienGiai], [MaSoNhanVien], [MaDieuKhoan], [SoNgayDuocNo], [NgayDonHang], [MaTinhTrang], [NgayGiaoHang], [MaLoaiTien], [TyGia], [TongTienHang], [TienThueGTGT], [TongChietKhau], [TongTienThanhToan]) VALUES (N'ĐH000004', N'KH000002', N'Luaajn', N'Diễn giải', N'0002', 1, 2, CAST(N'2020-08-18' AS Date), 2, CAST(N'2020-08-19' AS Date), 1, 1000, 8875000, 2050000, 0, 10925000)
INSERT [dbo].[DonDatHang] ([MaDonDatHang], [MaKhachHang], [NguoiNhanHang], [DienGiai], [MaSoNhanVien], [MaDieuKhoan], [SoNgayDuocNo], [NgayDonHang], [MaTinhTrang], [NgayGiaoHang], [MaLoaiTien], [TyGia], [TongTienHang], [TienThueGTGT], [TongChietKhau], [TongTienThanhToan]) VALUES (N'ĐH000005', N'KH000002', N'dawdwad', N'awdawd', N'0001', 1, 2, CAST(N'2020-08-18' AS Date), 1, CAST(N'2020-08-19' AS Date), 1, 1000, 9400000, 2155000, 0, 11555000)
INSERT [dbo].[DonDatHang] ([MaDonDatHang], [MaKhachHang], [NguoiNhanHang], [DienGiai], [MaSoNhanVien], [MaDieuKhoan], [SoNgayDuocNo], [NgayDonHang], [MaTinhTrang], [NgayGiaoHang], [MaLoaiTien], [TyGia], [TongTienHang], [TienThueGTGT], [TongChietKhau], [TongTienThanhToan]) VALUES (N'ĐH000006', N'KH000002', N'wad', N'awd', N'0001', 1, 2, CAST(N'2020-08-18' AS Date), 2, CAST(N'2020-08-19' AS Date), 1, 1000, 8700000, 2015000, 0, 10715000)
INSERT [dbo].[DonDatHang] ([MaDonDatHang], [MaKhachHang], [NguoiNhanHang], [DienGiai], [MaSoNhanVien], [MaDieuKhoan], [SoNgayDuocNo], [NgayDonHang], [MaTinhTrang], [NgayGiaoHang], [MaLoaiTien], [TyGia], [TongTienHang], [TienThueGTGT], [TongChietKhau], [TongTienThanhToan]) VALUES (N'ĐH000007', N'KH000001', N'dawdwad', NULL, N'0001', 1, 2, CAST(N'2020-08-18' AS Date), 2, CAST(N'2020-08-19' AS Date), 1, 1000, 1225000, 245000, 0, 1470000)
INSERT [dbo].[DonDatHang] ([MaDonDatHang], [MaKhachHang], [NguoiNhanHang], [DienGiai], [MaSoNhanVien], [MaDieuKhoan], [SoNgayDuocNo], [NgayDonHang], [MaTinhTrang], [NgayGiaoHang], [MaLoaiTien], [TyGia], [TongTienHang], [TienThueGTGT], [TongChietKhau], [TongTienThanhToan]) VALUES (N'ĐH000008', N'KH000002', N'dawdwad', NULL, N'0001', 1, 2, CAST(N'2020-08-18' AS Date), 2, CAST(N'2020-08-19' AS Date), 1, 1000, 8700000, 2015000, 0, 10715000)
INSERT [dbo].[DonDatHang] ([MaDonDatHang], [MaKhachHang], [NguoiNhanHang], [DienGiai], [MaSoNhanVien], [MaDieuKhoan], [SoNgayDuocNo], [NgayDonHang], [MaTinhTrang], [NgayGiaoHang], [MaLoaiTien], [TyGia], [TongTienHang], [TienThueGTGT], [TongChietKhau], [TongTienThanhToan]) VALUES (N'ĐH000009', N'KH000002', N'dawdwad', NULL, N'0001', 1, 2, CAST(N'2020-08-18' AS Date), 2, CAST(N'2020-08-19' AS Date), 1, 1000, 8700000, 2015000, 0, 10715000)
INSERT [dbo].[DonDatHang] ([MaDonDatHang], [MaKhachHang], [NguoiNhanHang], [DienGiai], [MaSoNhanVien], [MaDieuKhoan], [SoNgayDuocNo], [NgayDonHang], [MaTinhTrang], [NgayGiaoHang], [MaLoaiTien], [TyGia], [TongTienHang], [TienThueGTGT], [TongChietKhau], [TongTienThanhToan]) VALUES (N'ĐH000010', N'KH000002', N'dawdwad', NULL, N'0001', 1, 2, CAST(N'2020-08-18' AS Date), 2, CAST(N'2020-08-19' AS Date), 1, 1000, 8700000, 2015000, 0, 10715000)
INSERT [dbo].[DonDatHang] ([MaDonDatHang], [MaKhachHang], [NguoiNhanHang], [DienGiai], [MaSoNhanVien], [MaDieuKhoan], [SoNgayDuocNo], [NgayDonHang], [MaTinhTrang], [NgayGiaoHang], [MaLoaiTien], [TyGia], [TongTienHang], [TienThueGTGT], [TongChietKhau], [TongTienThanhToan]) VALUES (N'ĐH000011', N'KH000002', N'dawdwad', NULL, N'0001', 1, 2, CAST(N'2020-08-18' AS Date), 2, CAST(N'2020-08-19' AS Date), 1, 1000, 8700000, 2015000, 0, 10715000)
INSERT [dbo].[DonMuaHang] ([MaDonMuaHang], [MaNhaCungCap], [DienGiai], [MaSoNhanVien], [MaDieuKhoan], [SoNgayDuocNo], [NgayDonHang], [MaTinhTrang], [NgayGiaoHang], [MaLoaiTien], [TyGia], [TongTienHang], [TienThue], [TienChietKhau], [TongTienThanhToan]) VALUES (N'ĐMH000001', N'0001', N'abc', N'0002', 1, 1, CAST(N'2020-08-13' AS Date), 3, CAST(N'2020-08-23' AS Date), 1, 1000, 350000, NULL, 0, 420000)
INSERT [dbo].[DonMuaHang] ([MaDonMuaHang], [MaNhaCungCap], [DienGiai], [MaSoNhanVien], [MaDieuKhoan], [SoNgayDuocNo], [NgayDonHang], [MaTinhTrang], [NgayGiaoHang], [MaLoaiTien], [TyGia], [TongTienHang], [TienThue], [TienChietKhau], [TongTienThanhToan]) VALUES (N'ĐMH000002', N'0003', N'aa', N'0006', 1, 3, CAST(N'2020-08-13' AS Date), 2, CAST(N'2020-08-16' AS Date), 1, 1000, 350000, 70000, 0, 420000)
INSERT [dbo].[DonMuaHang] ([MaDonMuaHang], [MaNhaCungCap], [DienGiai], [MaSoNhanVien], [MaDieuKhoan], [SoNgayDuocNo], [NgayDonHang], [MaTinhTrang], [NgayGiaoHang], [MaLoaiTien], [TyGia], [TongTienHang], [TienThue], [TienChietKhau], [TongTienThanhToan]) VALUES (N'ĐMH000003', N'0003', N'aa', N'0002', 1, 1, CAST(N'2020-08-13' AS Date), 3, NULL, 1, 1000, 350000, 105000, 0, 630000)
INSERT [dbo].[DonMuaHang] ([MaDonMuaHang], [MaNhaCungCap], [DienGiai], [MaSoNhanVien], [MaDieuKhoan], [SoNgayDuocNo], [NgayDonHang], [MaTinhTrang], [NgayGiaoHang], [MaLoaiTien], [TyGia], [TongTienHang], [TienThue], [TienChietKhau], [TongTienThanhToan]) VALUES (N'ĐMH000004', N'0001', N'ăd', N'0001', 2, 2, CAST(N'2020-08-13' AS Date), 3, CAST(N'2020-08-16' AS Date), 1, 1000, 525000, 175000, 0, 1050000)
INSERT [dbo].[DonMuaHang] ([MaDonMuaHang], [MaNhaCungCap], [DienGiai], [MaSoNhanVien], [MaDieuKhoan], [SoNgayDuocNo], [NgayDonHang], [MaTinhTrang], [NgayGiaoHang], [MaLoaiTien], [TyGia], [TongTienHang], [TienThue], [TienChietKhau], [TongTienThanhToan]) VALUES (N'ĐMH000005', N'0003', N'abc', N'0001', 1, 2, CAST(N'2020-08-13' AS Date), 1, CAST(N'2020-08-15' AS Date), 1, 1000, 350000, 105000, 0, 630000)
INSERT [dbo].[DonMuaHang] ([MaDonMuaHang], [MaNhaCungCap], [DienGiai], [MaSoNhanVien], [MaDieuKhoan], [SoNgayDuocNo], [NgayDonHang], [MaTinhTrang], [NgayGiaoHang], [MaLoaiTien], [TyGia], [TongTienHang], [TienThue], [TienChietKhau], [TongTienThanhToan]) VALUES (N'ĐMH000006', N'0005', N'Dien giai', N'0001', 2, 2, CAST(N'2020-08-13' AS Date), 1, CAST(N'2020-08-23' AS Date), 2, 50000, 700000, 350000, 0, 2100000)
INSERT [dbo].[DonMuaHang] ([MaDonMuaHang], [MaNhaCungCap], [DienGiai], [MaSoNhanVien], [MaDieuKhoan], [SoNgayDuocNo], [NgayDonHang], [MaTinhTrang], [NgayGiaoHang], [MaLoaiTien], [TyGia], [TongTienHang], [TienThue], [TienChietKhau], [TongTienThanhToan]) VALUES (N'ĐMH000007', N'0001', NULL, N'0001', 1, 1, CAST(N'2020-08-13' AS Date), 0, CAST(N'2020-08-12' AS Date), 1, 1000, 350000, 105000, 0, 630000)
INSERT [dbo].[DonMuaHang] ([MaDonMuaHang], [MaNhaCungCap], [DienGiai], [MaSoNhanVien], [MaDieuKhoan], [SoNgayDuocNo], [NgayDonHang], [MaTinhTrang], [NgayGiaoHang], [MaLoaiTien], [TyGia], [TongTienHang], [TienThue], [TienChietKhau], [TongTienThanhToan]) VALUES (N'ĐMH000008', N'0001', NULL, N'0001', 1, NULL, CAST(N'2020-08-13' AS Date), 1, CAST(N'2020-08-14' AS Date), 1, 1000, 175000, 70000, 0, 420000)
INSERT [dbo].[DonVi] ([MaDonVi], [TenDonVi]) VALUES (N'BGD', N'Ban Giám đốc')
INSERT [dbo].[DonVi] ([MaDonVi], [TenDonVi]) VALUES (N'PHC', N'Phòng Hành chính')
INSERT [dbo].[DonVi] ([MaDonVi], [TenDonVi]) VALUES (N'PKD', N'Phòng Kinh doanh')
INSERT [dbo].[DonVi] ([MaDonVi], [TenDonVi]) VALUES (N'PKT', N'Phòng Kế toán')
SET IDENTITY_INSERT [dbo].[DonViTinh] ON 

INSERT [dbo].[DonViTinh] ([MaDonViTinh], [TenDonViTinh]) VALUES (1, N'Con')
INSERT [dbo].[DonViTinh] ([MaDonViTinh], [TenDonViTinh]) VALUES (2, N'Cái')
INSERT [dbo].[DonViTinh] ([MaDonViTinh], [TenDonViTinh]) VALUES (3, N'Chiếc')
INSERT [dbo].[DonViTinh] ([MaDonViTinh], [TenDonViTinh]) VALUES (4, N'Thùng')
INSERT [dbo].[DonViTinh] ([MaDonViTinh], [TenDonViTinh]) VALUES (5, N'KG')
INSERT [dbo].[DonViTinh] ([MaDonViTinh], [TenDonViTinh]) VALUES (6, N'Mét')
SET IDENTITY_INSERT [dbo].[DonViTinh] OFF
INSERT [dbo].[GiamGiaHangBan] ([MaGiamGiaHangBan], [MaKhachHang], [DienGiai], [MaSoNhanVien], [NgayHoachToan], [NgayChungTu], [TongTienHang], [TienThueGTGT], [TienChietKhau], [TongTienThanhToan], [MaLoaiTien], [TyGia], [DaGhiSo]) VALUES (N'BGG000001', N'KH000002', N'Diễn giải', N'0001', CAST(N'2020-08-19' AS Date), CAST(N'2020-08-15' AS Date), 4900000, 980000, 2400, 5880000, 2, 23175, 1)
INSERT [dbo].[GiamGiaHangBan] ([MaGiamGiaHangBan], [MaKhachHang], [DienGiai], [MaSoNhanVien], [NgayHoachToan], [NgayChungTu], [TongTienHang], [TienThueGTGT], [TienChietKhau], [TongTienThanhToan], [MaLoaiTien], [TyGia], [DaGhiSo]) VALUES (N'BGG000002', N'KH000002', N'Diễn giải', N'0006', CAST(N'2020-08-19' AS Date), CAST(N'2021-08-19' AS Date), 58725000, 15045000, 42, 73770000, 2, 23175, 0)
INSERT [dbo].[GiamGiaHangBan] ([MaGiamGiaHangBan], [MaKhachHang], [DienGiai], [MaSoNhanVien], [NgayHoachToan], [NgayChungTu], [TongTienHang], [TienThueGTGT], [TienChietKhau], [TongTienThanhToan], [MaLoaiTien], [TyGia], [DaGhiSo]) VALUES (N'BGG000003', N'KH000002', N'Bán hàng', N'0002', CAST(N'2020-08-19' AS Date), CAST(N'2020-08-19' AS Date), 27550000, 5885000, 24, 33435000, 2, 50000, 1)
INSERT [dbo].[GiamGiaHangBan] ([MaGiamGiaHangBan], [MaKhachHang], [DienGiai], [MaSoNhanVien], [NgayHoachToan], [NgayChungTu], [TongTienHang], [TienThueGTGT], [TienChietKhau], [TongTienThanhToan], [MaLoaiTien], [TyGia], [DaGhiSo]) VALUES (N'BGG000004', N'KH000012', N'Bán hàng', N'0011', CAST(N'2020-08-19' AS Date), CAST(N'2019-08-19' AS Date), 9200000, 2165000, 40, 4000, 2, 23175, 0)
INSERT [dbo].[GiamGiaHangBan] ([MaGiamGiaHangBan], [MaKhachHang], [DienGiai], [MaSoNhanVien], [NgayHoachToan], [NgayChungTu], [TongTienHang], [TienThueGTGT], [TienChietKhau], [TongTienThanhToan], [MaLoaiTien], [TyGia], [DaGhiSo]) VALUES (N'BGG000005', N'KH000002', NULL, N'0001', CAST(N'2020-08-20' AS Date), CAST(N'2020-08-19' AS Date), 1225000, 245000, 45000, 1470000, 1, 1000, 1)
INSERT [dbo].[GiamGiaHangMua] ([MaGiamGiaHangMua], [MaNhaCungCap], [DienGiai], [MaSoNhanVien], [ChungTuGoc], [MaLoaiTien], [TyGia], [NgayHoachToan], [NgayChungTu], [TongTienHang], [TienThueGTGT], [TongTienThanhToan], [DaGhiSo]) VALUES (N'MGG000001', N'0001', N'Diễn giải', N'0001', 1, 1, 1000, CAST(N'2020-08-17' AS Date), CAST(N'2020-08-17' AS Date), 350000, 70000, 420000, 1)
INSERT [dbo].[GiamGiaHangMua] ([MaGiamGiaHangMua], [MaNhaCungCap], [DienGiai], [MaSoNhanVien], [ChungTuGoc], [MaLoaiTien], [TyGia], [NgayHoachToan], [NgayChungTu], [TongTienHang], [TienThueGTGT], [TongTienThanhToan], [DaGhiSo]) VALUES (N'MGG000002', N'0001', N'Diễn giải', N'0001', 1, 1, 1000, CAST(N'2020-08-17' AS Date), CAST(N'2020-08-17' AS Date), 350000, 70000, 420000, 1)
INSERT [dbo].[GiamGiaHangMua] ([MaGiamGiaHangMua], [MaNhaCungCap], [DienGiai], [MaSoNhanVien], [ChungTuGoc], [MaLoaiTien], [TyGia], [NgayHoachToan], [NgayChungTu], [TongTienHang], [TienThueGTGT], [TongTienThanhToan], [DaGhiSo]) VALUES (N'MGG000003', N'0001', N'Diễn giải', N'0001', 1, 1, 1000, CAST(N'2020-08-17' AS Date), CAST(N'2020-08-17' AS Date), 350000, 70000, 420000, 0)
INSERT [dbo].[GiamGiaHangMua] ([MaGiamGiaHangMua], [MaNhaCungCap], [DienGiai], [MaSoNhanVien], [ChungTuGoc], [MaLoaiTien], [TyGia], [NgayHoachToan], [NgayChungTu], [TongTienHang], [TienThueGTGT], [TongTienThanhToan], [DaGhiSo]) VALUES (N'MGG000004', N'0001', N'Diễn giải', N'0001', 1, 1, 1000, CAST(N'2020-08-17' AS Date), CAST(N'2020-08-17' AS Date), 350000, 70000, 420000, 0)
INSERT [dbo].[HangHoa] ([MaHang], [TenHang], [MaNhomHH], [MaTinhChat], [DonViTinh], [BaoHanh], [NguonGoc], [MoTa], [GiaNhap], [GiaBan], [GiaKhuyenMai], [VAT], [ChietKhau], [HanSuDung], [ThanhPham], [SoLo], [HinhAnh], [NguoiSua], [NgaySua]) VALUES (N'000000000001', N'Áo thun', 2, 2, N'NVD', N'3 tháng', N'Việt Nam', N'Áo đẹp', 200000, 300000, 20000, 0.2, 0, N'2-02-2025', N'Lụa', N'3', N'/Assets/giaovien/img/files/aothun.jpg', N'Lê Trung Khoa', CAST(N'2020-08-27T17:01:45.113' AS DateTime))
INSERT [dbo].[HangHoa] ([MaHang], [TenHang], [MaNhomHH], [MaTinhChat], [DonViTinh], [BaoHanh], [NguonGoc], [MoTa], [GiaNhap], [GiaBan], [GiaKhuyenMai], [VAT], [ChietKhau], [HanSuDung], [ThanhPham], [SoLo], [HinhAnh], [NguoiSua], [NgaySua]) VALUES (N'000000000002', N'Quần Âu', 1, 2, N'VND', N'1 tháng', N'Việt Nam', N'Quần Âu', 150000, 200000, 15000, 0.2, 0, N'2-02-2025', N'Vải', N'2', N'/Assets/giaovien/img/files/quanau.jpg', NULL, NULL)
INSERT [dbo].[HangHoa] ([MaHang], [TenHang], [MaNhomHH], [MaTinhChat], [DonViTinh], [BaoHanh], [NguonGoc], [MoTa], [GiaNhap], [GiaBan], [GiaKhuyenMai], [VAT], [ChietKhau], [HanSuDung], [ThanhPham], [SoLo], [HinhAnh], [NguoiSua], [NgaySua]) VALUES (N'000000000003', N'Quần thể thao', 1, 2, N'VND', N'1 tháng', N'Việt nam', N'Quần đẹp', 150000, 200000, 25000, 0.2, 0, N'2-02-2025', N'Nỉ', N'4', N'/Assets/giaovien/img/files/quanthethao.jpg', NULL, NULL)
INSERT [dbo].[HangHoa] ([MaHang], [TenHang], [MaNhomHH], [MaTinhChat], [DonViTinh], [BaoHanh], [NguonGoc], [MoTa], [GiaNhap], [GiaBan], [GiaKhuyenMai], [VAT], [ChietKhau], [HanSuDung], [ThanhPham], [SoLo], [HinhAnh], [NguoiSua], [NgaySua]) VALUES (N'000000000004', N'Váy juyp', 2, 2, N'VND', N'2 tháng', N'Việt Nam', N'Quần Âu', 200000, 300000, 30000, 0.3, 0, N'2-02-2025', N'Lụa', N'1', N'/Assets/giaovien/img/files/b9bb6241e04a88572352cc5724ad0ce7.jpg', N'Lê Trung Khoa', CAST(N'2020-08-27T17:13:23.033' AS DateTime))
INSERT [dbo].[HangHoa] ([MaHang], [TenHang], [MaNhomHH], [MaTinhChat], [DonViTinh], [BaoHanh], [NguonGoc], [MoTa], [GiaNhap], [GiaBan], [GiaKhuyenMai], [VAT], [ChietKhau], [HanSuDung], [ThanhPham], [SoLo], [HinhAnh], [NguoiSua], [NgaySua]) VALUES (N'000000000005', N'ÁO THUN  57C5737', 1, 2, N'VDN', N'1 tháng', N'Korea', N'Quần Âu', 300000, 22000, 35000, 5, 5, N'2-02-2025', N'Lụa', N'2', N'/Assets/giaovien/img/files/b9bb6241e04a88572352cc5724ad0ce7.jpg', N'Lê Trung Khoa', CAST(N'2020-08-27T17:20:52.647' AS DateTime))
INSERT [dbo].[HangHoa] ([MaHang], [TenHang], [MaNhomHH], [MaTinhChat], [DonViTinh], [BaoHanh], [NguonGoc], [MoTa], [GiaNhap], [GiaBan], [GiaKhuyenMai], [VAT], [ChietKhau], [HanSuDung], [ThanhPham], [SoLo], [HinhAnh], [NguoiSua], [NgaySua]) VALUES (N'000000000006', N'ÁO THUN  57C5743', 1, 2, N'VDN', N'1 tháng', N'Korea', N'Áo đẹp', 150000, 1510000, 10000, 1, 5, N'2-02-2025', N'Lụa', N'4', N'/Assets/giaovien/img/files/aothun.jpg', NULL, NULL)
INSERT [dbo].[HangHoa] ([MaHang], [TenHang], [MaNhomHH], [MaTinhChat], [DonViTinh], [BaoHanh], [NguonGoc], [MoTa], [GiaNhap], [GiaBan], [GiaKhuyenMai], [VAT], [ChietKhau], [HanSuDung], [ThanhPham], [SoLo], [HinhAnh], [NguoiSua], [NgaySua]) VALUES (N'000000000007', N'ÁO THUN TOM', 1, 2, N'VND', N'12 tháng', N'Korea', N'Áo chất lượng', 2500000, 3000000, 30000, 0.5, 25, N'2-02-2025', N'Lụa', N'5', N'/Assets/giaovien/img/files/vay.jpg', NULL, NULL)
INSERT [dbo].[HangHoa] ([MaHang], [TenHang], [MaNhomHH], [MaTinhChat], [DonViTinh], [BaoHanh], [NguonGoc], [MoTa], [GiaNhap], [GiaBan], [GiaKhuyenMai], [VAT], [ChietKhau], [HanSuDung], [ThanhPham], [SoLo], [HinhAnh], [NguoiSua], [NgaySua]) VALUES (N'000000000008', N'ÁO THUN JERRY ', 1, 1, N'VDN', N'24 Thang', N'Viet Nam', N'Quần Âu', 25000, 250000, 10000, 1, 5, N'2-02-2025', N'Lụa', N'4', N'/Assets/giaovien/img/files/2_thumb.jpg', NULL, NULL)
INSERT [dbo].[HangHoa] ([MaHang], [TenHang], [MaNhomHH], [MaTinhChat], [DonViTinh], [BaoHanh], [NguonGoc], [MoTa], [GiaNhap], [GiaBan], [GiaKhuyenMai], [VAT], [ChietKhau], [HanSuDung], [ThanhPham], [SoLo], [HinhAnh], [NguoiSua], [NgaySua]) VALUES (N'000000000009', N'ÁO THUN TAY LIỀN', 1, 1, N'VDN', N'1 tháng', N'Korea', N'Quần Âu', 250000, 300000, 30000, 3, 2, N'2-02-2025', N'Lụa', N'24', N'/Assets/giaovien/img/files/aothun.jpg', N'Lê Trung Khoa', CAST(N'2020-08-27T17:14:40.400' AS DateTime))
INSERT [dbo].[HangHoa] ([MaHang], [TenHang], [MaNhomHH], [MaTinhChat], [DonViTinh], [BaoHanh], [NguonGoc], [MoTa], [GiaNhap], [GiaBan], [GiaKhuyenMai], [VAT], [ChietKhau], [HanSuDung], [ThanhPham], [SoLo], [HinhAnh], [NguoiSua], [NgaySua]) VALUES (N'000000000010', N'ÁO THUN  57C5741', 2, 2, N'VDN', N'1 tháng', N'Korea', N'Quần Âu', 300000, 110000, 20000, 2, 5, N'Vinh vien', N'cotton', N'2', N'/Assets/giaovien/img/files/vay.jpg', NULL, NULL)
INSERT [dbo].[HangHoa] ([MaHang], [TenHang], [MaNhomHH], [MaTinhChat], [DonViTinh], [BaoHanh], [NguonGoc], [MoTa], [GiaNhap], [GiaBan], [GiaKhuyenMai], [VAT], [ChietKhau], [HanSuDung], [ThanhPham], [SoLo], [HinhAnh], [NguoiSua], [NgaySua]) VALUES (N'000000000011', N'ÁO THUN TAY', 2, 1, N'VDN', N'1 tháng', N'Korea', N'Quần Âu', 300000, 28500000, 20000, 5, 7, N'2-02-2025', N'cotton', N'2', N'/Assets/giaovien/img/files/vay.jpg', NULL, NULL)
INSERT [dbo].[HangHoa] ([MaHang], [TenHang], [MaNhomHH], [MaTinhChat], [DonViTinh], [BaoHanh], [NguonGoc], [MoTa], [GiaNhap], [GiaBan], [GiaKhuyenMai], [VAT], [ChietKhau], [HanSuDung], [ThanhPham], [SoLo], [HinhAnh], [NguoiSua], [NgaySua]) VALUES (N'000000000012', N'ÁO THUN ', 2, 2, N'VND', N'1 tháng', N'Korea', N'Quần Âu', 150000, 200000, 10000, 0.2, 2, N'2-02-2025', N'Vải', N'2', N'/Assets/giaovien/img/files/vay.jpg', NULL, NULL)
INSERT [dbo].[HangHoa] ([MaHang], [TenHang], [MaNhomHH], [MaTinhChat], [DonViTinh], [BaoHanh], [NguonGoc], [MoTa], [GiaNhap], [GiaBan], [GiaKhuyenMai], [VAT], [ChietKhau], [HanSuDung], [ThanhPham], [SoLo], [HinhAnh], [NguoiSua], [NgaySua]) VALUES (N'000000000013', N'ÁO THUN ', 2, 2, N'VND', N'2 tháng', N'Korea', N'Quần Âu', 150000, 200000, 30000, 0.3, 3, N'2-02-2026', N'Vải', N'3', N'/Assets/giaovien/img/files/vay.jpg', NULL, NULL)
INSERT [dbo].[HangHoa] ([MaHang], [TenHang], [MaNhomHH], [MaTinhChat], [DonViTinh], [BaoHanh], [NguonGoc], [MoTa], [GiaNhap], [GiaBan], [GiaKhuyenMai], [VAT], [ChietKhau], [HanSuDung], [ThanhPham], [SoLo], [HinhAnh], [NguoiSua], [NgaySua]) VALUES (N'000000000014', N'ÁO THUN TOM&JERRY', 2, 2, N'VND', N'3 tháng', N'Korea', N'Quần Âu', 150000, 200000, 20000, 0.4, 4, N'2-02-2027', N'Vải', N'4', N'/Assets/giaovien/img/files/quanau.jpg', N'Lê Trung Khoa', CAST(N'2020-08-27T17:14:54.110' AS DateTime))
INSERT [dbo].[HangHoa] ([MaHang], [TenHang], [MaNhomHH], [MaTinhChat], [DonViTinh], [BaoHanh], [NguonGoc], [MoTa], [GiaNhap], [GiaBan], [GiaKhuyenMai], [VAT], [ChietKhau], [HanSuDung], [ThanhPham], [SoLo], [HinhAnh], [NguoiSua], [NgaySua]) VALUES (N'000000000015', N'ÁO THUN TOM&JERRY', 2, 2, N'VND', N'4 tháng', N'Korea', N'Quần Âu', 150000, 200000, 30000, 0.5, 5, N'2-02-2028', N'Vải', N'5', N'/Assets/giaovien/img/files/vay.jpg', NULL, NULL)
INSERT [dbo].[HangHoa] ([MaHang], [TenHang], [MaNhomHH], [MaTinhChat], [DonViTinh], [BaoHanh], [NguonGoc], [MoTa], [GiaNhap], [GiaBan], [GiaKhuyenMai], [VAT], [ChietKhau], [HanSuDung], [ThanhPham], [SoLo], [HinhAnh], [NguoiSua], [NgaySua]) VALUES (N'000000000016', N'ÁO MS 57C5741', 2, 2, N'VND', N'5 tháng', N'Korea', N'Quần Âu', 150000, 200000, 10000, 0.6, 6, N'2-02-2029', N'Vải', N'6', N'/Assets/giaovien/img/files/2_thumb.jpg', N'Lê Trung Khoa', CAST(N'2020-08-27T17:15:01.513' AS DateTime))
INSERT [dbo].[HangHoa] ([MaHang], [TenHang], [MaNhomHH], [MaTinhChat], [DonViTinh], [BaoHanh], [NguonGoc], [MoTa], [GiaNhap], [GiaBan], [GiaKhuyenMai], [VAT], [ChietKhau], [HanSuDung], [ThanhPham], [SoLo], [HinhAnh], [NguoiSua], [NgaySua]) VALUES (N'000000000017', N'ÁO THUN  MS 57C5742', 2, 2, N'VND', N'6 tháng', N'Korea', N'Quần Âu', 150000, 200000, 20000, 0.7, 7, N'2-02-2030', N'Vải', N'7', N'/Assets/giaovien/img/files/cd0cbe6fca9c8babd05a859da64f77bc.jpg', N'Lê Trung Khoa', CAST(N'2020-08-27T17:14:07.343' AS DateTime))
INSERT [dbo].[HangHoa] ([MaHang], [TenHang], [MaNhomHH], [MaTinhChat], [DonViTinh], [BaoHanh], [NguonGoc], [MoTa], [GiaNhap], [GiaBan], [GiaKhuyenMai], [VAT], [ChietKhau], [HanSuDung], [ThanhPham], [SoLo], [HinhAnh], [NguoiSua], [NgaySua]) VALUES (N'000000000018', N'QUẦN ', 2, 2, N'VND', N'7 tháng', N'Korea', N'Quần Âu', 150000, 200000, 20000, 0.8, 8, N'2-02-2031', N'Vải', N'8', N'/Assets/giaovien/img/files/vay.jpg', NULL, NULL)
INSERT [dbo].[HangHoa] ([MaHang], [TenHang], [MaNhomHH], [MaTinhChat], [DonViTinh], [BaoHanh], [NguonGoc], [MoTa], [GiaNhap], [GiaBan], [GiaKhuyenMai], [VAT], [ChietKhau], [HanSuDung], [ThanhPham], [SoLo], [HinhAnh], [NguoiSua], [NgaySua]) VALUES (N'000000000019', N'ÁO KHOÁC', 2, 2, N'VND', N'8 tháng', N'Korea', N'Quần Âu', 150000, 200000, 20000, 0.9, 9, N'2-02-2032', N'Vải', N'9', N'/Assets/giaovien/img/files/b9bb6241e04a88572352cc5724ad0ce7.jpg', N'Lê Trung Khoa', CAST(N'2020-08-27T17:15:11.447' AS DateTime))
INSERT [dbo].[HangHoa] ([MaHang], [TenHang], [MaNhomHH], [MaTinhChat], [DonViTinh], [BaoHanh], [NguonGoc], [MoTa], [GiaNhap], [GiaBan], [GiaKhuyenMai], [VAT], [ChietKhau], [HanSuDung], [ThanhPham], [SoLo], [HinhAnh], [NguoiSua], [NgaySua]) VALUES (N'000000000020', N'VÁY', 2, 2, N'VND', N'9 tháng', N'Korea', N'Quần Âu', 150000, 200000, 10000, 0.1, 10, N'2-02-2033', N'Vải', N'10', N'/Assets/giaovien/img/files/vay.jpg', NULL, NULL)
INSERT [dbo].[HangHoa] ([MaHang], [TenHang], [MaNhomHH], [MaTinhChat], [DonViTinh], [BaoHanh], [NguonGoc], [MoTa], [GiaNhap], [GiaBan], [GiaKhuyenMai], [VAT], [ChietKhau], [HanSuDung], [ThanhPham], [SoLo], [HinhAnh], [NguoiSua], [NgaySua]) VALUES (N'000000000021', N'ĐẦM', 2, 2, N'VND', N'10 tháng', N'Korea', N'Quần Âu', 150000, 200000, 20000, 0.11, 11, N'2-02-2034', N'Vải', N'11', N'/Assets/giaovien/img/files/2_thumb.jpg', N'Lê Trung Khoa', CAST(N'2020-08-27T17:14:16.157' AS DateTime))
INSERT [dbo].[HangHoa] ([MaHang], [TenHang], [MaNhomHH], [MaTinhChat], [DonViTinh], [BaoHanh], [NguonGoc], [MoTa], [GiaNhap], [GiaBan], [GiaKhuyenMai], [VAT], [ChietKhau], [HanSuDung], [ThanhPham], [SoLo], [HinhAnh], [NguoiSua], [NgaySua]) VALUES (N'000000000022', N'QUẦN TÂY', 2, 2, N'VND', N'11 tháng', N'Korea', N'Quần Âu', 150000, 200000, 10000, 0.12, 12, N'2-02-2035', N'Vải', N'12', N'/Assets/giaovien/img/files/c01bd0f0f6d31a39411d513879edf53c(1).jpg', N'Lê Trung Khoa', CAST(N'2020-08-27T17:14:27.953' AS DateTime))
INSERT [dbo].[HangHoa] ([MaHang], [TenHang], [MaNhomHH], [MaTinhChat], [DonViTinh], [BaoHanh], [NguonGoc], [MoTa], [GiaNhap], [GiaBan], [GiaKhuyenMai], [VAT], [ChietKhau], [HanSuDung], [ThanhPham], [SoLo], [HinhAnh], [NguoiSua], [NgaySua]) VALUES (N'000000000023', N'ÁO DA', 2, 2, N'VND', N'12 tháng', N'Korea', N'Quần Âu', 150000, 200000, 20000, 0.13, 13, N'2-02-2036', N'Vải', N'13', N'/Assets/giaovien/img/files/vay.jpg', NULL, NULL)
INSERT [dbo].[HangHoa] ([MaHang], [TenHang], [MaNhomHH], [MaTinhChat], [DonViTinh], [BaoHanh], [NguonGoc], [MoTa], [GiaNhap], [GiaBan], [GiaKhuyenMai], [VAT], [ChietKhau], [HanSuDung], [ThanhPham], [SoLo], [HinhAnh], [NguoiSua], [NgaySua]) VALUES (N'000000000024', N'GIÀY', 2, 2, N'VND', N'13 tháng', N'Korea', N'Quần Âu', 150000, 200000, 30000, 0.14, 14, N'2-02-2037', N'Vải', N'14', N'/Assets/giaovien/img/files/vay.jpg', NULL, NULL)
INSERT [dbo].[HangHoa] ([MaHang], [TenHang], [MaNhomHH], [MaTinhChat], [DonViTinh], [BaoHanh], [NguonGoc], [MoTa], [GiaNhap], [GiaBan], [GiaKhuyenMai], [VAT], [ChietKhau], [HanSuDung], [ThanhPham], [SoLo], [HinhAnh], [NguoiSua], [NgaySua]) VALUES (N'000000000025', N'DÉP', 2, 2, N'VND', N'13 tháng', N'Korea', N'Quần Âu', 150000, 200000, 30000, 0.14, 14, N'2-02-2037', N'Vải', N'14', N'/Assets/giaovien/img/files/vay.jpg', NULL, NULL)
SET IDENTITY_INSERT [dbo].[HangHoa_DonViTinh] ON 

INSERT [dbo].[HangHoa_DonViTinh] ([id], [MaDonViTinh], [MaHang], [DonGia]) VALUES (1, 2, N'000000000001', 300000)
INSERT [dbo].[HangHoa_DonViTinh] ([id], [MaDonViTinh], [MaHang], [DonGia]) VALUES (2, 2, N'000000000002', 400000)
INSERT [dbo].[HangHoa_DonViTinh] ([id], [MaDonViTinh], [MaHang], [DonGia]) VALUES (3, 3, N'000000000004', 250000)
INSERT [dbo].[HangHoa_DonViTinh] ([id], [MaDonViTinh], [MaHang], [DonGia]) VALUES (4, 2, N'000000000003', 200000)
INSERT [dbo].[HangHoa_DonViTinh] ([id], [MaDonViTinh], [MaHang], [DonGia]) VALUES (5, 3, N'000000000001', 350000)
INSERT [dbo].[HangHoa_DonViTinh] ([id], [MaDonViTinh], [MaHang], [DonGia]) VALUES (6, 4, N'000000000001', 100000)
INSERT [dbo].[HangHoa_DonViTinh] ([id], [MaDonViTinh], [MaHang], [DonGia]) VALUES (7, 2, N'000000000005', 250000)
INSERT [dbo].[HangHoa_DonViTinh] ([id], [MaDonViTinh], [MaHang], [DonGia]) VALUES (8, 2, N'000000000006', 175000)
INSERT [dbo].[HangHoa_DonViTinh] ([id], [MaDonViTinh], [MaHang], [DonGia]) VALUES (9, 2, N'000000000007', 150000)
INSERT [dbo].[HangHoa_DonViTinh] ([id], [MaDonViTinh], [MaHang], [DonGia]) VALUES (10, 2, N'000000000008', 250000)
INSERT [dbo].[HangHoa_DonViTinh] ([id], [MaDonViTinh], [MaHang], [DonGia]) VALUES (11, 2, N'000000000009', 350000)
INSERT [dbo].[HangHoa_DonViTinh] ([id], [MaDonViTinh], [MaHang], [DonGia]) VALUES (12, 2, N'000000000010', 100000)
INSERT [dbo].[HangHoa_DonViTinh] ([id], [MaDonViTinh], [MaHang], [DonGia]) VALUES (13, 2, N'000000000011', 80000)
INSERT [dbo].[HangHoa_DonViTinh] ([id], [MaDonViTinh], [MaHang], [DonGia]) VALUES (14, 2, N'000000000012', 350000)
INSERT [dbo].[HangHoa_DonViTinh] ([id], [MaDonViTinh], [MaHang], [DonGia]) VALUES (15, 2, N'000000000013', 50000)
INSERT [dbo].[HangHoa_DonViTinh] ([id], [MaDonViTinh], [MaHang], [DonGia]) VALUES (16, 2, N'000000000014', 300000)
INSERT [dbo].[HangHoa_DonViTinh] ([id], [MaDonViTinh], [MaHang], [DonGia]) VALUES (17, 2, N'000000000015', 420000)
INSERT [dbo].[HangHoa_DonViTinh] ([id], [MaDonViTinh], [MaHang], [DonGia]) VALUES (18, 2, N'000000000016', 375000)
INSERT [dbo].[HangHoa_DonViTinh] ([id], [MaDonViTinh], [MaHang], [DonGia]) VALUES (19, 2, N'000000000017', 285000)
INSERT [dbo].[HangHoa_DonViTinh] ([id], [MaDonViTinh], [MaHang], [DonGia]) VALUES (20, 2, N'000000000018', 165000)
INSERT [dbo].[HangHoa_DonViTinh] ([id], [MaDonViTinh], [MaHang], [DonGia]) VALUES (21, 2, N'000000000019', 130000)
INSERT [dbo].[HangHoa_DonViTinh] ([id], [MaDonViTinh], [MaHang], [DonGia]) VALUES (22, 2, N'000000000020', 450000)
INSERT [dbo].[HangHoa_DonViTinh] ([id], [MaDonViTinh], [MaHang], [DonGia]) VALUES (23, 2, N'000000000021', 282000)
INSERT [dbo].[HangHoa_DonViTinh] ([id], [MaDonViTinh], [MaHang], [DonGia]) VALUES (24, 2, N'000000000022', 390000)
INSERT [dbo].[HangHoa_DonViTinh] ([id], [MaDonViTinh], [MaHang], [DonGia]) VALUES (25, 2, N'000000000023', 175000)
INSERT [dbo].[HangHoa_DonViTinh] ([id], [MaDonViTinh], [MaHang], [DonGia]) VALUES (26, 2, N'000000000024', 225000)
INSERT [dbo].[HangHoa_DonViTinh] ([id], [MaDonViTinh], [MaHang], [DonGia]) VALUES (27, 2, N'000000000025', 227000)
SET IDENTITY_INSERT [dbo].[HangHoa_DonViTinh] OFF
SET IDENTITY_INSERT [dbo].[HeThongTaiKhoan] ON 

INSERT [dbo].[HeThongTaiKhoan] ([Id], [SoTaiKhoan], [TenTaiKhoan], [TinhChat], [TenTiengAnh], [DienGiai], [NgungTheoDoi]) VALUES (1, N'1111', N'Sacombank', N'tinh chat', N'Tieng anh anh', NULL, 1)
INSERT [dbo].[HeThongTaiKhoan] ([Id], [SoTaiKhoan], [TenTaiKhoan], [TinhChat], [TenTiengAnh], [DienGiai], [NgungTheoDoi]) VALUES (2, N'1112', N'vietconbank', N'A', N'Viet', N'Dien giai', 0)
INSERT [dbo].[HeThongTaiKhoan] ([Id], [SoTaiKhoan], [TenTaiKhoan], [TinhChat], [TenTiengAnh], [DienGiai], [NgungTheoDoi]) VALUES (3, N'1113', N'vietconbank', N'A', N'Viet', N'Dien giai', 1)
INSERT [dbo].[HeThongTaiKhoan] ([Id], [SoTaiKhoan], [TenTaiKhoan], [TinhChat], [TenTiengAnh], [DienGiai], [NgungTheoDoi]) VALUES (4, N'1121', N'Visa', N'The', N'Visa', N'Visa', 1)
INSERT [dbo].[HeThongTaiKhoan] ([Id], [SoTaiKhoan], [TenTaiKhoan], [TinhChat], [TenTiengAnh], [DienGiai], [NgungTheoDoi]) VALUES (5, N'1122', N'Taikhoan', N'Taikhoan', N'Taikhoan', N'Diengiai', 0)
SET IDENTITY_INSERT [dbo].[HeThongTaiKhoan] OFF
INSERT [dbo].[HoaDon_BanHang] ([MaHoaDon], [MaKhachHang], [TKNganHang], [NguoiMuaHang], [HinhThucTT], [MauSoHD], [KyHieuHD], [NgayHoaDon], [MaDieuKhoan], [SoNgayDuocNo], [HanThanhToan], [TyGia], [TongTienHang], [TienThueGTGT], [TienChietKhau], [TongTienThanhToan], [MaLoaiTien], [MaChungTuBanHang], [MaSoNhanVien]) VALUES (N'000001', N'KH000012', N'123123', N'Trường', N'CK', N'123', N'321', CAST(N'2020-08-19' AS Date), 2, 2, CAST(N'2020-08-28' AS Date), 1000, 28950000, 6165000, 0, 35115000, 1, NULL, N'0001')
INSERT [dbo].[HoaDon_BanHang] ([MaHoaDon], [MaKhachHang], [TKNganHang], [NguoiMuaHang], [HinhThucTT], [MauSoHD], [KyHieuHD], [NgayHoaDon], [MaDieuKhoan], [SoNgayDuocNo], [HanThanhToan], [TyGia], [TongTienHang], [TienThueGTGT], [TienChietKhau], [TongTienThanhToan], [MaLoaiTien], [MaChungTuBanHang], [MaSoNhanVien]) VALUES (N'000002', N'KH000001', N'123123', N'Người mua hàng', N'Hình thức TT', N'Mẫu số HĐ', N'Ký hiệu HĐ', CAST(N'2020-08-19' AS Date), 1, 2, CAST(N'2020-08-28' AS Date), 23175, 9525000, 2280000, 0, 11805000, 2, N'BH000024', N'0001')
INSERT [dbo].[HoaDon_BanHang] ([MaHoaDon], [MaKhachHang], [TKNganHang], [NguoiMuaHang], [HinhThucTT], [MauSoHD], [KyHieuHD], [NgayHoaDon], [MaDieuKhoan], [SoNgayDuocNo], [HanThanhToan], [TyGia], [TongTienHang], [TienThueGTGT], [TienChietKhau], [TongTienThanhToan], [MaLoaiTien], [MaChungTuBanHang], [MaSoNhanVien]) VALUES (N'000003', N'KH000001', N'123123', NULL, NULL, N'31qe2', N'123qe', CAST(N'2020-08-19' AS Date), 2, 4, CAST(N'2020-08-20' AS Date), NULL, 477275000, 123530000, 0, 600805000, 2, N'BH000025', N'0001')
INSERT [dbo].[HoaDon_BanHang] ([MaHoaDon], [MaKhachHang], [TKNganHang], [NguoiMuaHang], [HinhThucTT], [MauSoHD], [KyHieuHD], [NgayHoaDon], [MaDieuKhoan], [SoNgayDuocNo], [HanThanhToan], [TyGia], [TongTienHang], [TienThueGTGT], [TienChietKhau], [TongTienThanhToan], [MaLoaiTien], [MaChungTuBanHang], [MaSoNhanVien]) VALUES (N'000004', N'KH000001', N'213123123', N'Trường', N'Tiền mặt', N'123', N'231', CAST(N'2020-08-19' AS Date), 2, NULL, NULL, 1000, 25025000, 5355000, 0, 30380000, 1, NULL, N'0001')
INSERT [dbo].[HoaDon_BanHang] ([MaHoaDon], [MaKhachHang], [TKNganHang], [NguoiMuaHang], [HinhThucTT], [MauSoHD], [KyHieuHD], [NgayHoaDon], [MaDieuKhoan], [SoNgayDuocNo], [HanThanhToan], [TyGia], [TongTienHang], [TienThueGTGT], [TienChietKhau], [TongTienThanhToan], [MaLoaiTien], [MaChungTuBanHang], [MaSoNhanVien]) VALUES (N'000005', N'KH000002', N'123123', N'Luận', N'CK', N'1113', N'1114', CAST(N'2020-08-19' AS Date), 2, NULL, NULL, 23175, 4550000, 910000, 0, 5460000, 2, NULL, N'0001')
INSERT [dbo].[HoaDon_BanHang] ([MaHoaDon], [MaKhachHang], [TKNganHang], [NguoiMuaHang], [HinhThucTT], [MauSoHD], [KyHieuHD], [NgayHoaDon], [MaDieuKhoan], [SoNgayDuocNo], [HanThanhToan], [TyGia], [TongTienHang], [TienThueGTGT], [TienChietKhau], [TongTienThanhToan], [MaLoaiTien], [MaChungTuBanHang], [MaSoNhanVien]) VALUES (N'000006', N'KH000003', N'2133132', N'Khoa', N'CK', N'112', N'321', CAST(N'2020-08-19' AS Date), 2, NULL, NULL, 23175, 11000000, 3300000, 0, 14300000, 2, NULL, N'0001')
INSERT [dbo].[HoaDon_BanHang] ([MaHoaDon], [MaKhachHang], [TKNganHang], [NguoiMuaHang], [HinhThucTT], [MauSoHD], [KyHieuHD], [NgayHoaDon], [MaDieuKhoan], [SoNgayDuocNo], [HanThanhToan], [TyGia], [TongTienHang], [TienThueGTGT], [TienChietKhau], [TongTienThanhToan], [MaLoaiTien], [MaChungTuBanHang], [MaSoNhanVien]) VALUES (N'000007', N'KH000018', N'123123123', N'Nghĩa', N'TM', N'123', N'1231', CAST(N'2020-08-19' AS Date), 2, NULL, NULL, NULL, 40025000, 8280000, 0, 48305000, 2, NULL, N'0001')
INSERT [dbo].[HoaDon_BanHang] ([MaHoaDon], [MaKhachHang], [TKNganHang], [NguoiMuaHang], [HinhThucTT], [MauSoHD], [KyHieuHD], [NgayHoaDon], [MaDieuKhoan], [SoNgayDuocNo], [HanThanhToan], [TyGia], [TongTienHang], [TienThueGTGT], [TienChietKhau], [TongTienThanhToan], [MaLoaiTien], [MaChungTuBanHang], [MaSoNhanVien]) VALUES (N'000008', N'KH000001', N'43242342', N'Trường', N'CK', N'1231', N'3123', CAST(N'2020-08-19' AS Date), 2, NULL, NULL, 23175, 1225000, 245000, 0, 1470000, 2, NULL, N'0001')
INSERT [dbo].[HoaDon_BanHang] ([MaHoaDon], [MaKhachHang], [TKNganHang], [NguoiMuaHang], [HinhThucTT], [MauSoHD], [KyHieuHD], [NgayHoaDon], [MaDieuKhoan], [SoNgayDuocNo], [HanThanhToan], [TyGia], [TongTienHang], [TienThueGTGT], [TienChietKhau], [TongTienThanhToan], [MaLoaiTien], [MaChungTuBanHang], [MaSoNhanVien]) VALUES (N'000009', N'KH000001', N'2131312', N'Trường', N'CK', N'4324', N'234', CAST(N'2020-08-19' AS Date), 2, NULL, NULL, NULL, 13725000, 3120000, 0, 16845000, 2, NULL, N'0001')
INSERT [dbo].[HoaDon_BanHang] ([MaHoaDon], [MaKhachHang], [TKNganHang], [NguoiMuaHang], [HinhThucTT], [MauSoHD], [KyHieuHD], [NgayHoaDon], [MaDieuKhoan], [SoNgayDuocNo], [HanThanhToan], [TyGia], [TongTienHang], [TienThueGTGT], [TienChietKhau], [TongTienThanhToan], [MaLoaiTien], [MaChungTuBanHang], [MaSoNhanVien]) VALUES (N'000010', N'KH000001', N'13424', N'Luận', N'TM', N'213', N'12313', CAST(N'2020-08-19' AS Date), 2, NULL, NULL, 23175, 5775000, 1155000, 0, 6930000, 2, NULL, N'0001')
INSERT [dbo].[HoaDon_BanHang] ([MaHoaDon], [MaKhachHang], [TKNganHang], [NguoiMuaHang], [HinhThucTT], [MauSoHD], [KyHieuHD], [NgayHoaDon], [MaDieuKhoan], [SoNgayDuocNo], [HanThanhToan], [TyGia], [TongTienHang], [TienThueGTGT], [TienChietKhau], [TongTienThanhToan], [MaLoaiTien], [MaChungTuBanHang], [MaSoNhanVien]) VALUES (N'000011', N'KH000001', N'123', N'Trường', N'TM', N'113', N'112', CAST(N'2020-08-19' AS Date), 2, NULL, NULL, 23175, 4900000, 980000, NULL, 5880000, 2, NULL, N'0001')
INSERT [dbo].[HoaDon_BanHang] ([MaHoaDon], [MaKhachHang], [TKNganHang], [NguoiMuaHang], [HinhThucTT], [MauSoHD], [KyHieuHD], [NgayHoaDon], [MaDieuKhoan], [SoNgayDuocNo], [HanThanhToan], [TyGia], [TongTienHang], [TienThueGTGT], [TienChietKhau], [TongTienThanhToan], [MaLoaiTien], [MaChungTuBanHang], [MaSoNhanVien]) VALUES (N'000012', N'KH000002', N'123123123', N'Luận', N'CK', N'123213', N'123132', CAST(N'2020-08-19' AS Date), 2, NULL, NULL, 23175, 58725000, 15045000, NULL, 73770000, 2, NULL, N'0006')
INSERT [dbo].[HoaDon_BanHang] ([MaHoaDon], [MaKhachHang], [TKNganHang], [NguoiMuaHang], [HinhThucTT], [MauSoHD], [KyHieuHD], [NgayHoaDon], [MaDieuKhoan], [SoNgayDuocNo], [HanThanhToan], [TyGia], [TongTienHang], [TienThueGTGT], [TienChietKhau], [TongTienThanhToan], [MaLoaiTien], [MaChungTuBanHang], [MaSoNhanVien]) VALUES (N'000013', N'KH000001', N'123131231312', N'Trường', N'TM', N'123131', N'132123132', CAST(N'2020-08-19' AS Date), 2, NULL, NULL, 50000, 27550000, 5885000, NULL, 33435000, 2, NULL, N'0002')
INSERT [dbo].[HoaDon_BanHang] ([MaHoaDon], [MaKhachHang], [TKNganHang], [NguoiMuaHang], [HinhThucTT], [MauSoHD], [KyHieuHD], [NgayHoaDon], [MaDieuKhoan], [SoNgayDuocNo], [HanThanhToan], [TyGia], [TongTienHang], [TienThueGTGT], [TienChietKhau], [TongTienThanhToan], [MaLoaiTien], [MaChungTuBanHang], [MaSoNhanVien]) VALUES (N'000014', N'KH000012', N'1231312', N'Trường', N'CK', N'12313', N'21313', CAST(N'2020-08-19' AS Date), 2, NULL, NULL, 23175, 9200000, 2165000, NULL, NULL, 2, NULL, N'0011')
INSERT [dbo].[HoaDon_BanHang] ([MaHoaDon], [MaKhachHang], [TKNganHang], [NguoiMuaHang], [HinhThucTT], [MauSoHD], [KyHieuHD], [NgayHoaDon], [MaDieuKhoan], [SoNgayDuocNo], [HanThanhToan], [TyGia], [TongTienHang], [TienThueGTGT], [TienChietKhau], [TongTienThanhToan], [MaLoaiTien], [MaChungTuBanHang], [MaSoNhanVien]) VALUES (N'000015', N'KH000001', NULL, NULL, NULL, N'12313', N'123123', CAST(N'2020-08-20' AS Date), NULL, NULL, NULL, 23175, 35350000, 10395000, NULL, 45745000, 2, NULL, N'0002')
INSERT [dbo].[HoaDon_BanHang] ([MaHoaDon], [MaKhachHang], [TKNganHang], [NguoiMuaHang], [HinhThucTT], [MauSoHD], [KyHieuHD], [NgayHoaDon], [MaDieuKhoan], [SoNgayDuocNo], [HanThanhToan], [TyGia], [TongTienHang], [TienThueGTGT], [TienChietKhau], [TongTienThanhToan], [MaLoaiTien], [MaChungTuBanHang], [MaSoNhanVien]) VALUES (N'000016', N'KH000002', NULL, N'ădadaw', N'ădwa', N'12313', N'123213', CAST(N'2020-08-20' AS Date), 1, 2, CAST(N'2020-08-29' AS Date), 1000, 8700000, 2015000, 0, 10715000, 1, N'BH000027', N'0001')
SET IDENTITY_INSERT [dbo].[HoanThanhCongViec] ON 

INSERT [dbo].[HoanThanhCongViec] ([ID], [MaSoNhanVien], [LoaiDanhGia], [NgayBatDau], [NgayKetThuc], [XepLoai]) VALUES (1, N'0001', N'Giỏi', CAST(N'2020-08-03' AS Date), CAST(N'2020-08-05' AS Date), N'Tốt')
SET IDENTITY_INSERT [dbo].[HoanThanhCongViec] OFF
INSERT [dbo].[HopDongMua] ([MaHopDongMua], [TrichYeu], [MaNhaCungCap], [MaLoaiTien], [TyGia], [GiaTriHopDong], [NguoiLienHe], [GiaTriHopDongQuyDoi], [HanGiaoHang], [MaTinhTrang], [DiaChiGiaoHang], [GiaTriThanhLy], [GiaTriThanhLyQuyDoi], [HanThanhToan], [NgayThanhLy_HuyBo], [MaSoNhanVien], [LyDo], [DieuKhoanKhac], [LaHopDongPhatSinh], [TienChietKhau], [TienThueGTGT], [TongTienThanhToan], [NgayKy]) VALUES (N'HĐM000001', N'trích yếu', N'0001', 1, 1000, N'200000', N'Người liên hệ', N'GT hợp đồng quy đổi', CAST(N'2020-08-14' AS Date), 1, N'Địa chỉ giao hàng', N'Giá trị thanh lý', N'GT thanh lý quy đổi', CAST(N'2020-08-23' AS Date), N'Ngày thanh lý/hủy bỏ', N'0001', N'Lý do', N'Điều khoản khác', 0, 0, NULL, 745000, CAST(N'2020-08-15' AS Date))
INSERT [dbo].[HopDongMua] ([MaHopDongMua], [TrichYeu], [MaNhaCungCap], [MaLoaiTien], [TyGia], [GiaTriHopDong], [NguoiLienHe], [GiaTriHopDongQuyDoi], [HanGiaoHang], [MaTinhTrang], [DiaChiGiaoHang], [GiaTriThanhLy], [GiaTriThanhLyQuyDoi], [HanThanhToan], [NgayThanhLy_HuyBo], [MaSoNhanVien], [LyDo], [DieuKhoanKhac], [LaHopDongPhatSinh], [TienChietKhau], [TienThueGTGT], [TongTienThanhToan], [NgayKy]) VALUES (N'HĐM000002', N'Trích yếu', N'0003', 1, 1000, N'Giá trị hợp đồng', N'Người liên hệ', N'GT hợp đồng quy đổi', CAST(N'2020-08-05' AS Date), 1, N'Địa chỉ giao hàng', N'Giá trị thanh lý', N'GT thanh lý quy đổi', CAST(N'2020-08-29' AS Date), N'Ngày thanh lý/hủy bỏ', N'0001', N'Lý do', N'Điều khoản khác', 1, 0, 470000, 2445000, CAST(N'2020-08-15' AS Date))
INSERT [dbo].[KhachHang] ([MaKhachHang], [NhomKH_NCC], [PhanLoai], [XungHo], [TenKhachHang], [ChiNhanh], [DiaChi], [SoDienThoai], [Fax], [Email], [Website], [MaSoThue], [SoTaiKhoanNganHang], [TenNganHang], [NguoiLienHe], [DaXoa], [NguoiXoa], [NgayXoa], [NVBanHang], [DienGiai], [DieuKhoanTT], [SoNgayDuocNo], [SoNoToiDa], [QuocGia], [Quan_Huyen], [Tinh_TP], [Xa_Phuong], [DienThoaiCoDinh_LH], [HoVaTen_LH], [Email_LH], [ChucDanh_LH], [DiaChi_LH], [DTdidong_LH], [DTKhac_LH], [DaiDienTheoPL_LH], [TenNguoiNhan], [DienThoaiNguoiNhan], [DiaChiNguoiNhan], [EmailNguoiNhan], [DiaDiemGiaoHang], [NgayCap], [NoiCap], [CMND]) VALUES (N'KH000000', NULL, NULL, NULL, N'Khách lẻ', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[KhachHang] ([MaKhachHang], [NhomKH_NCC], [PhanLoai], [XungHo], [TenKhachHang], [ChiNhanh], [DiaChi], [SoDienThoai], [Fax], [Email], [Website], [MaSoThue], [SoTaiKhoanNganHang], [TenNganHang], [NguoiLienHe], [DaXoa], [NguoiXoa], [NgayXoa], [NVBanHang], [DienGiai], [DieuKhoanTT], [SoNgayDuocNo], [SoNoToiDa], [QuocGia], [Quan_Huyen], [Tinh_TP], [Xa_Phuong], [DienThoaiCoDinh_LH], [HoVaTen_LH], [Email_LH], [ChucDanh_LH], [DiaChi_LH], [DTdidong_LH], [DTKhac_LH], [DaiDienTheoPL_LH], [TenNguoiNhan], [DienThoaiNguoiNhan], [DiaChiNguoiNhan], [EmailNguoiNhan], [DiaDiemGiaoHang], [NgayCap], [NoiCap], [CMND]) VALUES (N'KH000001', N'02', N'Cá nhân', NULL, N'Công ty cổ phần, thương mại và dịch vụ Mekong', N'Rạch Giá', N'Rạch Giá, Kiên Giang', N'0939996445  ', N'0939996445  ', N'sale@mekong-tech.com', N'http://mekong-tech.com/', N'123', N'01232127407', N'Ngân hàng techcombank', N'Trung', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'Trần Văn Trường', NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[KhachHang] ([MaKhachHang], [NhomKH_NCC], [PhanLoai], [XungHo], [TenKhachHang], [ChiNhanh], [DiaChi], [SoDienThoai], [Fax], [Email], [Website], [MaSoThue], [SoTaiKhoanNganHang], [TenNganHang], [NguoiLienHe], [DaXoa], [NguoiXoa], [NgayXoa], [NVBanHang], [DienGiai], [DieuKhoanTT], [SoNgayDuocNo], [SoNoToiDa], [QuocGia], [Quan_Huyen], [Tinh_TP], [Xa_Phuong], [DienThoaiCoDinh_LH], [HoVaTen_LH], [Email_LH], [ChucDanh_LH], [DiaChi_LH], [DTdidong_LH], [DTKhac_LH], [DaiDienTheoPL_LH], [TenNguoiNhan], [DienThoaiNguoiNhan], [DiaChiNguoiNhan], [EmailNguoiNhan], [DiaDiemGiaoHang], [NgayCap], [NoiCap], [CMND]) VALUES (N'KH000002', N'02', N'Tổ chức', NULL, N'Công ty TNHH Công Minh', NULL, N'131 Nguyễn Thị Minh Khai, quận 3, Tp.HCM', N'0939996445  ', N'0939996445  ', N'bhpnguyen@vlcc.edu.vn', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[KhachHang] ([MaKhachHang], [NhomKH_NCC], [PhanLoai], [XungHo], [TenKhachHang], [ChiNhanh], [DiaChi], [SoDienThoai], [Fax], [Email], [Website], [MaSoThue], [SoTaiKhoanNganHang], [TenNganHang], [NguoiLienHe], [DaXoa], [NguoiXoa], [NgayXoa], [NVBanHang], [DienGiai], [DieuKhoanTT], [SoNgayDuocNo], [SoNoToiDa], [QuocGia], [Quan_Huyen], [Tinh_TP], [Xa_Phuong], [DienThoaiCoDinh_LH], [HoVaTen_LH], [Email_LH], [ChucDanh_LH], [DiaChi_LH], [DTdidong_LH], [DTKhac_LH], [DaiDienTheoPL_LH], [TenNguoiNhan], [DienThoaiNguoiNhan], [DiaChiNguoiNhan], [EmailNguoiNhan], [DiaDiemGiaoHang], [NgayCap], [NoiCap], [CMND]) VALUES (N'KH000003', N'02', N'Tổ chức', NULL, N'Bùi Minh Triều', NULL, N'An Giang', N'0939996445  ', N'0939996445  ', N'bmtrieu@vlcc.edu.vn', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[KhachHang] ([MaKhachHang], [NhomKH_NCC], [PhanLoai], [XungHo], [TenKhachHang], [ChiNhanh], [DiaChi], [SoDienThoai], [Fax], [Email], [Website], [MaSoThue], [SoTaiKhoanNganHang], [TenNganHang], [NguoiLienHe], [DaXoa], [NguoiXoa], [NgayXoa], [NVBanHang], [DienGiai], [DieuKhoanTT], [SoNgayDuocNo], [SoNoToiDa], [QuocGia], [Quan_Huyen], [Tinh_TP], [Xa_Phuong], [DienThoaiCoDinh_LH], [HoVaTen_LH], [Email_LH], [ChucDanh_LH], [DiaChi_LH], [DTdidong_LH], [DTKhac_LH], [DaiDienTheoPL_LH], [TenNguoiNhan], [DienThoaiNguoiNhan], [DiaChiNguoiNhan], [EmailNguoiNhan], [DiaDiemGiaoHang], [NgayCap], [NoiCap], [CMND]) VALUES (N'KH000004', N'03', N'Cá nhân', NULL, N'Biện Công Nhân', N'', N'TP.HCM', N'', N'0939996445  ', N'bctrung@vlcc.edu.vn', N'', N'', N'', N'', N'', NULL, N'', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[KhachHang] ([MaKhachHang], [NhomKH_NCC], [PhanLoai], [XungHo], [TenKhachHang], [ChiNhanh], [DiaChi], [SoDienThoai], [Fax], [Email], [Website], [MaSoThue], [SoTaiKhoanNganHang], [TenNganHang], [NguoiLienHe], [DaXoa], [NguoiXoa], [NgayXoa], [NVBanHang], [DienGiai], [DieuKhoanTT], [SoNgayDuocNo], [SoNoToiDa], [QuocGia], [Quan_Huyen], [Tinh_TP], [Xa_Phuong], [DienThoaiCoDinh_LH], [HoVaTen_LH], [Email_LH], [ChucDanh_LH], [DiaChi_LH], [DTdidong_LH], [DTKhac_LH], [DaiDienTheoPL_LH], [TenNguoiNhan], [DienThoaiNguoiNhan], [DiaChiNguoiNhan], [EmailNguoiNhan], [DiaDiemGiaoHang], [NgayCap], [NoiCap], [CMND]) VALUES (N'KH000005', N'04', N'Cá nhân', NULL, N'Cao Châu Minh Thư', N'', N'Cần Thơ', N'', N'0939996445  ', N'ccmthu@vlcc.edu.vn', N'', N'', N'', N'', N'', NULL, N'', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[KhachHang] ([MaKhachHang], [NhomKH_NCC], [PhanLoai], [XungHo], [TenKhachHang], [ChiNhanh], [DiaChi], [SoDienThoai], [Fax], [Email], [Website], [MaSoThue], [SoTaiKhoanNganHang], [TenNganHang], [NguoiLienHe], [DaXoa], [NguoiXoa], [NgayXoa], [NVBanHang], [DienGiai], [DieuKhoanTT], [SoNgayDuocNo], [SoNoToiDa], [QuocGia], [Quan_Huyen], [Tinh_TP], [Xa_Phuong], [DienThoaiCoDinh_LH], [HoVaTen_LH], [Email_LH], [ChucDanh_LH], [DiaChi_LH], [DTdidong_LH], [DTKhac_LH], [DaiDienTheoPL_LH], [TenNguoiNhan], [DienThoaiNguoiNhan], [DiaChiNguoiNhan], [EmailNguoiNhan], [DiaDiemGiaoHang], [NgayCap], [NoiCap], [CMND]) VALUES (N'KH000006', N'04', N'Tổ chức', NULL, N'Cao Hạnh Thủy', N'', N'TP.HCM', N'', N'', N'chthuy@vlcc.edu.vn', N'', N'', N'', N'', N'', NULL, N'', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[KhachHang] ([MaKhachHang], [NhomKH_NCC], [PhanLoai], [XungHo], [TenKhachHang], [ChiNhanh], [DiaChi], [SoDienThoai], [Fax], [Email], [Website], [MaSoThue], [SoTaiKhoanNganHang], [TenNganHang], [NguoiLienHe], [DaXoa], [NguoiXoa], [NgayXoa], [NVBanHang], [DienGiai], [DieuKhoanTT], [SoNgayDuocNo], [SoNoToiDa], [QuocGia], [Quan_Huyen], [Tinh_TP], [Xa_Phuong], [DienThoaiCoDinh_LH], [HoVaTen_LH], [Email_LH], [ChucDanh_LH], [DiaChi_LH], [DTdidong_LH], [DTKhac_LH], [DaiDienTheoPL_LH], [TenNguoiNhan], [DienThoaiNguoiNhan], [DiaChiNguoiNhan], [EmailNguoiNhan], [DiaDiemGiaoHang], [NgayCap], [NoiCap], [CMND]) VALUES (N'KH000007', N'04', N'Cá nhân', NULL, N'Cao Thị Lan Như', N'', N'Bến Tre', N'', N'', N'ctlnhu@vlcc.edu.vn', N'', N'', N'', N'', N'', NULL, N'', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[KhachHang] ([MaKhachHang], [NhomKH_NCC], [PhanLoai], [XungHo], [TenKhachHang], [ChiNhanh], [DiaChi], [SoDienThoai], [Fax], [Email], [Website], [MaSoThue], [SoTaiKhoanNganHang], [TenNganHang], [NguoiLienHe], [DaXoa], [NguoiXoa], [NgayXoa], [NVBanHang], [DienGiai], [DieuKhoanTT], [SoNgayDuocNo], [SoNoToiDa], [QuocGia], [Quan_Huyen], [Tinh_TP], [Xa_Phuong], [DienThoaiCoDinh_LH], [HoVaTen_LH], [Email_LH], [ChucDanh_LH], [DiaChi_LH], [DTdidong_LH], [DTKhac_LH], [DaiDienTheoPL_LH], [TenNguoiNhan], [DienThoaiNguoiNhan], [DiaChiNguoiNhan], [EmailNguoiNhan], [DiaDiemGiaoHang], [NgayCap], [NoiCap], [CMND]) VALUES (N'KH000008', N'04', N'Cá nhân', NULL, N'Cao Thảo Quyên', N'', N'Rạch Giá, Kiên Giang', N'', N'', N'ctquyen@vlcc.edu.vn', N'', N'', N'', N'', N'', NULL, N'', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[KhachHang] ([MaKhachHang], [NhomKH_NCC], [PhanLoai], [XungHo], [TenKhachHang], [ChiNhanh], [DiaChi], [SoDienThoai], [Fax], [Email], [Website], [MaSoThue], [SoTaiKhoanNganHang], [TenNganHang], [NguoiLienHe], [DaXoa], [NguoiXoa], [NgayXoa], [NVBanHang], [DienGiai], [DieuKhoanTT], [SoNgayDuocNo], [SoNoToiDa], [QuocGia], [Quan_Huyen], [Tinh_TP], [Xa_Phuong], [DienThoaiCoDinh_LH], [HoVaTen_LH], [Email_LH], [ChucDanh_LH], [DiaChi_LH], [DTdidong_LH], [DTKhac_LH], [DaiDienTheoPL_LH], [TenNguoiNhan], [DienThoaiNguoiNhan], [DiaChiNguoiNhan], [EmailNguoiNhan], [DiaDiemGiaoHang], [NgayCap], [NoiCap], [CMND]) VALUES (N'KH000009', N'03', N'Cá nhân', NULL, N'Đỗ Hồng Hạnh', N'', N'TP.HCM', N'', N'', N'dhhanh@vlcc.edu.vn', N'', N'', N'', N'', N'', NULL, N'', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[KhachHang] ([MaKhachHang], [NhomKH_NCC], [PhanLoai], [XungHo], [TenKhachHang], [ChiNhanh], [DiaChi], [SoDienThoai], [Fax], [Email], [Website], [MaSoThue], [SoTaiKhoanNganHang], [TenNganHang], [NguoiLienHe], [DaXoa], [NguoiXoa], [NgayXoa], [NVBanHang], [DienGiai], [DieuKhoanTT], [SoNgayDuocNo], [SoNoToiDa], [QuocGia], [Quan_Huyen], [Tinh_TP], [Xa_Phuong], [DienThoaiCoDinh_LH], [HoVaTen_LH], [Email_LH], [ChucDanh_LH], [DiaChi_LH], [DTdidong_LH], [DTKhac_LH], [DaiDienTheoPL_LH], [TenNguoiNhan], [DienThoaiNguoiNhan], [DiaChiNguoiNhan], [EmailNguoiNhan], [DiaDiemGiaoHang], [NgayCap], [NoiCap], [CMND]) VALUES (N'KH000010', N'02', N'Tổ chức', NULL, N'Đoàn Lê Thanh Linh', N'', N'Rạch Giá, Kiên Giang', N'', N'', N'dltlinh@vlcc.edu.vn', N'', N'', N'', N'', N'', NULL, N'', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[KhachHang] ([MaKhachHang], [NhomKH_NCC], [PhanLoai], [XungHo], [TenKhachHang], [ChiNhanh], [DiaChi], [SoDienThoai], [Fax], [Email], [Website], [MaSoThue], [SoTaiKhoanNganHang], [TenNganHang], [NguoiLienHe], [DaXoa], [NguoiXoa], [NgayXoa], [NVBanHang], [DienGiai], [DieuKhoanTT], [SoNgayDuocNo], [SoNoToiDa], [QuocGia], [Quan_Huyen], [Tinh_TP], [Xa_Phuong], [DienThoaiCoDinh_LH], [HoVaTen_LH], [Email_LH], [ChucDanh_LH], [DiaChi_LH], [DTdidong_LH], [DTKhac_LH], [DaiDienTheoPL_LH], [TenNguoiNhan], [DienThoaiNguoiNhan], [DiaChiNguoiNhan], [EmailNguoiNhan], [DiaDiemGiaoHang], [NgayCap], [NoiCap], [CMND]) VALUES (N'KH000011', N'01', N'Tổ chức', NULL, N'Đàm Ngọc Bích', N'', N'Rạch Giá, Kiên Giang', N'', N'', N'dnbich@vlcc.edu.vn', N'', N'', N'', N'', N'', NULL, N'', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[KhachHang] ([MaKhachHang], [NhomKH_NCC], [PhanLoai], [XungHo], [TenKhachHang], [ChiNhanh], [DiaChi], [SoDienThoai], [Fax], [Email], [Website], [MaSoThue], [SoTaiKhoanNganHang], [TenNganHang], [NguoiLienHe], [DaXoa], [NguoiXoa], [NgayXoa], [NVBanHang], [DienGiai], [DieuKhoanTT], [SoNgayDuocNo], [SoNoToiDa], [QuocGia], [Quan_Huyen], [Tinh_TP], [Xa_Phuong], [DienThoaiCoDinh_LH], [HoVaTen_LH], [Email_LH], [ChucDanh_LH], [DiaChi_LH], [DTdidong_LH], [DTKhac_LH], [DaiDienTheoPL_LH], [TenNguoiNhan], [DienThoaiNguoiNhan], [DiaChiNguoiNhan], [EmailNguoiNhan], [DiaDiemGiaoHang], [NgayCap], [NoiCap], [CMND]) VALUES (N'KH000012', N'02', N'Cá nhân', NULL, N'Đỗ Nguyệt Quế', N'', N'Vĩnh Long', N'', N'', N'dnque@vlcc.edu.vn', N'', N'', N'', N'', N'', NULL, N'', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[KhachHang] ([MaKhachHang], [NhomKH_NCC], [PhanLoai], [XungHo], [TenKhachHang], [ChiNhanh], [DiaChi], [SoDienThoai], [Fax], [Email], [Website], [MaSoThue], [SoTaiKhoanNganHang], [TenNganHang], [NguoiLienHe], [DaXoa], [NguoiXoa], [NgayXoa], [NVBanHang], [DienGiai], [DieuKhoanTT], [SoNgayDuocNo], [SoNoToiDa], [QuocGia], [Quan_Huyen], [Tinh_TP], [Xa_Phuong], [DienThoaiCoDinh_LH], [HoVaTen_LH], [Email_LH], [ChucDanh_LH], [DiaChi_LH], [DTdidong_LH], [DTKhac_LH], [DaiDienTheoPL_LH], [TenNguoiNhan], [DienThoaiNguoiNhan], [DiaChiNguoiNhan], [EmailNguoiNhan], [DiaDiemGiaoHang], [NgayCap], [NoiCap], [CMND]) VALUES (N'KH000013', N'04', N'Cá nhân', NULL, N'Đinh Phước Tường', N'', N'TP.HCM', N'', N'', N'dptuong@vlcc.edu.vn', N'', N'', N'', N'', N'', NULL, N'', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[KhachHang] ([MaKhachHang], [NhomKH_NCC], [PhanLoai], [XungHo], [TenKhachHang], [ChiNhanh], [DiaChi], [SoDienThoai], [Fax], [Email], [Website], [MaSoThue], [SoTaiKhoanNganHang], [TenNganHang], [NguoiLienHe], [DaXoa], [NguoiXoa], [NgayXoa], [NVBanHang], [DienGiai], [DieuKhoanTT], [SoNgayDuocNo], [SoNoToiDa], [QuocGia], [Quan_Huyen], [Tinh_TP], [Xa_Phuong], [DienThoaiCoDinh_LH], [HoVaTen_LH], [Email_LH], [ChucDanh_LH], [DiaChi_LH], [DTdidong_LH], [DTKhac_LH], [DaiDienTheoPL_LH], [TenNguoiNhan], [DienThoaiNguoiNhan], [DiaChiNguoiNhan], [EmailNguoiNhan], [DiaDiemGiaoHang], [NgayCap], [NoiCap], [CMND]) VALUES (N'KH000014', N'02', N'Tổ chức', NULL, N'Đinh Quang Minh', N'', N'Hậu Giang', N'', N'', N'dqminh@vlcc.edu.vn', N'', N'', N'', N'', N'', NULL, N'', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[KhachHang] ([MaKhachHang], [NhomKH_NCC], [PhanLoai], [XungHo], [TenKhachHang], [ChiNhanh], [DiaChi], [SoDienThoai], [Fax], [Email], [Website], [MaSoThue], [SoTaiKhoanNganHang], [TenNganHang], [NguoiLienHe], [DaXoa], [NguoiXoa], [NgayXoa], [NVBanHang], [DienGiai], [DieuKhoanTT], [SoNgayDuocNo], [SoNoToiDa], [QuocGia], [Quan_Huyen], [Tinh_TP], [Xa_Phuong], [DienThoaiCoDinh_LH], [HoVaTen_LH], [Email_LH], [ChucDanh_LH], [DiaChi_LH], [DTdidong_LH], [DTKhac_LH], [DaiDienTheoPL_LH], [TenNguoiNhan], [DienThoaiNguoiNhan], [DiaChiNguoiNhan], [EmailNguoiNhan], [DiaDiemGiaoHang], [NgayCap], [NoiCap], [CMND]) VALUES (N'KH000015', N'03', N'Cá nhân', NULL, N'Đỗ Trọng Hiếu', N'', N'Rạch Giá, Kiên Giang', N'', N'', N'dthieu@vlcc.edu.vn', N'', N'', N'', N'', N'', NULL, N'', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[KhachHang] ([MaKhachHang], [NhomKH_NCC], [PhanLoai], [XungHo], [TenKhachHang], [ChiNhanh], [DiaChi], [SoDienThoai], [Fax], [Email], [Website], [MaSoThue], [SoTaiKhoanNganHang], [TenNganHang], [NguoiLienHe], [DaXoa], [NguoiXoa], [NgayXoa], [NVBanHang], [DienGiai], [DieuKhoanTT], [SoNgayDuocNo], [SoNoToiDa], [QuocGia], [Quan_Huyen], [Tinh_TP], [Xa_Phuong], [DienThoaiCoDinh_LH], [HoVaTen_LH], [Email_LH], [ChucDanh_LH], [DiaChi_LH], [DTdidong_LH], [DTKhac_LH], [DaiDienTheoPL_LH], [TenNguoiNhan], [DienThoaiNguoiNhan], [DiaChiNguoiNhan], [EmailNguoiNhan], [DiaDiemGiaoHang], [NgayCap], [NoiCap], [CMND]) VALUES (N'KH000016', N'03', N'Tổ chức', NULL, N'Đoàn Thanh Liêm', N'', N'Cà Mau', N'', N'', N'dtliem@vlcc.edu.vn', N'', N'', N'', N'', N'', NULL, N'', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[KhachHang] ([MaKhachHang], [NhomKH_NCC], [PhanLoai], [XungHo], [TenKhachHang], [ChiNhanh], [DiaChi], [SoDienThoai], [Fax], [Email], [Website], [MaSoThue], [SoTaiKhoanNganHang], [TenNganHang], [NguoiLienHe], [DaXoa], [NguoiXoa], [NgayXoa], [NVBanHang], [DienGiai], [DieuKhoanTT], [SoNgayDuocNo], [SoNoToiDa], [QuocGia], [Quan_Huyen], [Tinh_TP], [Xa_Phuong], [DienThoaiCoDinh_LH], [HoVaTen_LH], [Email_LH], [ChucDanh_LH], [DiaChi_LH], [DTdidong_LH], [DTKhac_LH], [DaiDienTheoPL_LH], [TenNguoiNhan], [DienThoaiNguoiNhan], [DiaChiNguoiNhan], [EmailNguoiNhan], [DiaDiemGiaoHang], [NgayCap], [NoiCap], [CMND]) VALUES (N'KH000017', N'02', N'Cá nhân', NULL, N'Đoàn Thanh Thảo', N'', N'Bến Tre', N'', N'', N'dtthao@vlcc.edu.vn', N'', N'', N'', N'', N'', NULL, N'', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[KhachHang] ([MaKhachHang], [NhomKH_NCC], [PhanLoai], [XungHo], [TenKhachHang], [ChiNhanh], [DiaChi], [SoDienThoai], [Fax], [Email], [Website], [MaSoThue], [SoTaiKhoanNganHang], [TenNganHang], [NguoiLienHe], [DaXoa], [NguoiXoa], [NgayXoa], [NVBanHang], [DienGiai], [DieuKhoanTT], [SoNgayDuocNo], [SoNoToiDa], [QuocGia], [Quan_Huyen], [Tinh_TP], [Xa_Phuong], [DienThoaiCoDinh_LH], [HoVaTen_LH], [Email_LH], [ChucDanh_LH], [DiaChi_LH], [DTdidong_LH], [DTKhac_LH], [DaiDienTheoPL_LH], [TenNguoiNhan], [DienThoaiNguoiNhan], [DiaChiNguoiNhan], [EmailNguoiNhan], [DiaDiemGiaoHang], [NgayCap], [NoiCap], [CMND]) VALUES (N'KH000018', N'04', N'Cá nhân', NULL, N'Đỗ Thành Thịnh', N'', N'TP.HCM', N'', N'', N'dtthinh@vlcc.edu.vn', N'', N'', N'', N'', N'', NULL, N'', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[KhachHang] ([MaKhachHang], [NhomKH_NCC], [PhanLoai], [XungHo], [TenKhachHang], [ChiNhanh], [DiaChi], [SoDienThoai], [Fax], [Email], [Website], [MaSoThue], [SoTaiKhoanNganHang], [TenNganHang], [NguoiLienHe], [DaXoa], [NguoiXoa], [NgayXoa], [NVBanHang], [DienGiai], [DieuKhoanTT], [SoNgayDuocNo], [SoNoToiDa], [QuocGia], [Quan_Huyen], [Tinh_TP], [Xa_Phuong], [DienThoaiCoDinh_LH], [HoVaTen_LH], [Email_LH], [ChucDanh_LH], [DiaChi_LH], [DTdidong_LH], [DTKhac_LH], [DaiDienTheoPL_LH], [TenNguoiNhan], [DienThoaiNguoiNhan], [DiaChiNguoiNhan], [EmailNguoiNhan], [DiaDiemGiaoHang], [NgayCap], [NoiCap], [CMND]) VALUES (N'KH000019', N'01', N'Tổ chức', NULL, N'Đoàn Thị Tuyết Hoa', N'', N'Bến Tre', N'', N'', N'dtthoa@vlcc.edu.vn', N'', N'', N'', N'', N'', NULL, N'', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[KhachHang] ([MaKhachHang], [NhomKH_NCC], [PhanLoai], [XungHo], [TenKhachHang], [ChiNhanh], [DiaChi], [SoDienThoai], [Fax], [Email], [Website], [MaSoThue], [SoTaiKhoanNganHang], [TenNganHang], [NguoiLienHe], [DaXoa], [NguoiXoa], [NgayXoa], [NVBanHang], [DienGiai], [DieuKhoanTT], [SoNgayDuocNo], [SoNoToiDa], [QuocGia], [Quan_Huyen], [Tinh_TP], [Xa_Phuong], [DienThoaiCoDinh_LH], [HoVaTen_LH], [Email_LH], [ChucDanh_LH], [DiaChi_LH], [DTdidong_LH], [DTKhac_LH], [DaiDienTheoPL_LH], [TenNguoiNhan], [DienThoaiNguoiNhan], [DiaChiNguoiNhan], [EmailNguoiNhan], [DiaDiemGiaoHang], [NgayCap], [NoiCap], [CMND]) VALUES (N'KH000020', N'04', N'Cá nhân', NULL, N'Đặng Văn Hồng', N'', N'TP.HCM', N'', N'', N'dvhong@vlcc.edu.vn', N'', N'', N'', N'', N'', NULL, N'', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[KhachHang] ([MaKhachHang], [NhomKH_NCC], [PhanLoai], [XungHo], [TenKhachHang], [ChiNhanh], [DiaChi], [SoDienThoai], [Fax], [Email], [Website], [MaSoThue], [SoTaiKhoanNganHang], [TenNganHang], [NguoiLienHe], [DaXoa], [NguoiXoa], [NgayXoa], [NVBanHang], [DienGiai], [DieuKhoanTT], [SoNgayDuocNo], [SoNoToiDa], [QuocGia], [Quan_Huyen], [Tinh_TP], [Xa_Phuong], [DienThoaiCoDinh_LH], [HoVaTen_LH], [Email_LH], [ChucDanh_LH], [DiaChi_LH], [DTdidong_LH], [DTKhac_LH], [DaiDienTheoPL_LH], [TenNguoiNhan], [DienThoaiNguoiNhan], [DiaChiNguoiNhan], [EmailNguoiNhan], [DiaDiemGiaoHang], [NgayCap], [NoiCap], [CMND]) VALUES (N'KH000021', N'02', N'Cá nhân', NULL, N'Dương Văn Khuôn', N'', N'Cà Mau', N'', N'', N'dvkhuon@vlcc.edu.vn', N'', N'', N'', N'', N'', NULL, N'', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[KhachHang] ([MaKhachHang], [NhomKH_NCC], [PhanLoai], [XungHo], [TenKhachHang], [ChiNhanh], [DiaChi], [SoDienThoai], [Fax], [Email], [Website], [MaSoThue], [SoTaiKhoanNganHang], [TenNganHang], [NguoiLienHe], [DaXoa], [NguoiXoa], [NgayXoa], [NVBanHang], [DienGiai], [DieuKhoanTT], [SoNgayDuocNo], [SoNoToiDa], [QuocGia], [Quan_Huyen], [Tinh_TP], [Xa_Phuong], [DienThoaiCoDinh_LH], [HoVaTen_LH], [Email_LH], [ChucDanh_LH], [DiaChi_LH], [DTdidong_LH], [DTKhac_LH], [DaiDienTheoPL_LH], [TenNguoiNhan], [DienThoaiNguoiNhan], [DiaChiNguoiNhan], [EmailNguoiNhan], [DiaDiemGiaoHang], [NgayCap], [NoiCap], [CMND]) VALUES (N'KH000022', N'02', N'Tổ chức', NULL, N'Hg  Hoàng Hữu Hiện', N'', N'Vĩnh Long', N'', N'', N'hhhhien@vlcc.edu.vn', N'', N'', N'', N'', N'', NULL, N'', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[KhachHang] ([MaKhachHang], [NhomKH_NCC], [PhanLoai], [XungHo], [TenKhachHang], [ChiNhanh], [DiaChi], [SoDienThoai], [Fax], [Email], [Website], [MaSoThue], [SoTaiKhoanNganHang], [TenNganHang], [NguoiLienHe], [DaXoa], [NguoiXoa], [NgayXoa], [NVBanHang], [DienGiai], [DieuKhoanTT], [SoNgayDuocNo], [SoNoToiDa], [QuocGia], [Quan_Huyen], [Tinh_TP], [Xa_Phuong], [DienThoaiCoDinh_LH], [HoVaTen_LH], [Email_LH], [ChucDanh_LH], [DiaChi_LH], [DTdidong_LH], [DTKhac_LH], [DaiDienTheoPL_LH], [TenNguoiNhan], [DienThoaiNguoiNhan], [DiaChiNguoiNhan], [EmailNguoiNhan], [DiaDiemGiaoHang], [NgayCap], [NoiCap], [CMND]) VALUES (N'KH000023', N'03', N'Tổ chức', NULL, N'Huỳnh Hải Sơn', N'', N'TP.HCM', N'', N'', N'hhson@vlcc.edu.vn', N'', N'', N'', N'', N'', NULL, N'', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[KhachHang] ([MaKhachHang], [NhomKH_NCC], [PhanLoai], [XungHo], [TenKhachHang], [ChiNhanh], [DiaChi], [SoDienThoai], [Fax], [Email], [Website], [MaSoThue], [SoTaiKhoanNganHang], [TenNganHang], [NguoiLienHe], [DaXoa], [NguoiXoa], [NgayXoa], [NVBanHang], [DienGiai], [DieuKhoanTT], [SoNgayDuocNo], [SoNoToiDa], [QuocGia], [Quan_Huyen], [Tinh_TP], [Xa_Phuong], [DienThoaiCoDinh_LH], [HoVaTen_LH], [Email_LH], [ChucDanh_LH], [DiaChi_LH], [DTdidong_LH], [DTKhac_LH], [DaiDienTheoPL_LH], [TenNguoiNhan], [DienThoaiNguoiNhan], [DiaChiNguoiNhan], [EmailNguoiNhan], [DiaDiemGiaoHang], [NgayCap], [NoiCap], [CMND]) VALUES (N'KH000024', N'04', N'Tổ chức', NULL, N'Huỳnh Nga', N'', N'Rạch Giá, Kiên Giang', N'', N'', N'hnga@vlcc.edu.vn', N'', N'', N'', N'', N'', NULL, N'', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[KhachHang] ([MaKhachHang], [NhomKH_NCC], [PhanLoai], [XungHo], [TenKhachHang], [ChiNhanh], [DiaChi], [SoDienThoai], [Fax], [Email], [Website], [MaSoThue], [SoTaiKhoanNganHang], [TenNganHang], [NguoiLienHe], [DaXoa], [NguoiXoa], [NgayXoa], [NVBanHang], [DienGiai], [DieuKhoanTT], [SoNgayDuocNo], [SoNoToiDa], [QuocGia], [Quan_Huyen], [Tinh_TP], [Xa_Phuong], [DienThoaiCoDinh_LH], [HoVaTen_LH], [Email_LH], [ChucDanh_LH], [DiaChi_LH], [DTdidong_LH], [DTKhac_LH], [DaiDienTheoPL_LH], [TenNguoiNhan], [DienThoaiNguoiNhan], [DiaChiNguoiNhan], [EmailNguoiNhan], [DiaDiemGiaoHang], [NgayCap], [NoiCap], [CMND]) VALUES (N'KH000025', N'01', N'Cá nhân', NULL, N'Hà Quang Quyến', N'', N'Vĩnh Long', N'', N'', N'hqquyen@vlcc.edu.vn', N'', N'', N'', N'', N'', NULL, N'', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[KhachHang] ([MaKhachHang], [NhomKH_NCC], [PhanLoai], [XungHo], [TenKhachHang], [ChiNhanh], [DiaChi], [SoDienThoai], [Fax], [Email], [Website], [MaSoThue], [SoTaiKhoanNganHang], [TenNganHang], [NguoiLienHe], [DaXoa], [NguoiXoa], [NgayXoa], [NVBanHang], [DienGiai], [DieuKhoanTT], [SoNgayDuocNo], [SoNoToiDa], [QuocGia], [Quan_Huyen], [Tinh_TP], [Xa_Phuong], [DienThoaiCoDinh_LH], [HoVaTen_LH], [Email_LH], [ChucDanh_LH], [DiaChi_LH], [DTdidong_LH], [DTKhac_LH], [DaiDienTheoPL_LH], [TenNguoiNhan], [DienThoaiNguoiNhan], [DiaChiNguoiNhan], [EmailNguoiNhan], [DiaDiemGiaoHang], [NgayCap], [NoiCap], [CMND]) VALUES (N'KH000026', N'04', N'Cá nhân', NULL, N'Trần Văn Trường', N'Kiên Giang', N'Rạch Giá, Kiên Giang', N'0832127407', N'01232127407', N'truong.tran@mekong-tech.com', N'mekong-tech.com', N'123', N'371861', N'Techcombank', N'Trường', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[KhachHang] ([MaKhachHang], [NhomKH_NCC], [PhanLoai], [XungHo], [TenKhachHang], [ChiNhanh], [DiaChi], [SoDienThoai], [Fax], [Email], [Website], [MaSoThue], [SoTaiKhoanNganHang], [TenNganHang], [NguoiLienHe], [DaXoa], [NguoiXoa], [NgayXoa], [NVBanHang], [DienGiai], [DieuKhoanTT], [SoNgayDuocNo], [SoNoToiDa], [QuocGia], [Quan_Huyen], [Tinh_TP], [Xa_Phuong], [DienThoaiCoDinh_LH], [HoVaTen_LH], [Email_LH], [ChucDanh_LH], [DiaChi_LH], [DTdidong_LH], [DTKhac_LH], [DaiDienTheoPL_LH], [TenNguoiNhan], [DienThoaiNguoiNhan], [DiaChiNguoiNhan], [EmailNguoiNhan], [DiaDiemGiaoHang], [NgayCap], [NoiCap], [CMND]) VALUES (N'KH000027', N'02', N'Tổ chức', NULL, N'Công ty TNHH Tín Nghĩa', N'Rạch Giá', N'Tp.Rạch Giá, Kiên Giang', N'01232127407', N'113', N'tinnghia@gmail.com', N'tinnghia.com', N'123', N'321', N'abc', N'Tín Nghĩa', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[KhachHang] ([MaKhachHang], [NhomKH_NCC], [PhanLoai], [XungHo], [TenKhachHang], [ChiNhanh], [DiaChi], [SoDienThoai], [Fax], [Email], [Website], [MaSoThue], [SoTaiKhoanNganHang], [TenNganHang], [NguoiLienHe], [DaXoa], [NguoiXoa], [NgayXoa], [NVBanHang], [DienGiai], [DieuKhoanTT], [SoNgayDuocNo], [SoNoToiDa], [QuocGia], [Quan_Huyen], [Tinh_TP], [Xa_Phuong], [DienThoaiCoDinh_LH], [HoVaTen_LH], [Email_LH], [ChucDanh_LH], [DiaChi_LH], [DTdidong_LH], [DTKhac_LH], [DaiDienTheoPL_LH], [TenNguoiNhan], [DienThoaiNguoiNhan], [DiaChiNguoiNhan], [EmailNguoiNhan], [DiaDiemGiaoHang], [NgayCap], [NoiCap], [CMND]) VALUES (N'KH000028', N'01', N'Cá nhân', NULL, N'Diệp Minh Luận', N'Kiên Giang', N'Tp. Rạch Giá, Kiên Giang', N'0123456789', N'012345678910', N'luan.diep@mekong-tech.com', N'mekong-tech.com', N'123', N'12321232', N'acb', N'Luận', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[KhachHang] ([MaKhachHang], [NhomKH_NCC], [PhanLoai], [XungHo], [TenKhachHang], [ChiNhanh], [DiaChi], [SoDienThoai], [Fax], [Email], [Website], [MaSoThue], [SoTaiKhoanNganHang], [TenNganHang], [NguoiLienHe], [DaXoa], [NguoiXoa], [NgayXoa], [NVBanHang], [DienGiai], [DieuKhoanTT], [SoNgayDuocNo], [SoNoToiDa], [QuocGia], [Quan_Huyen], [Tinh_TP], [Xa_Phuong], [DienThoaiCoDinh_LH], [HoVaTen_LH], [Email_LH], [ChucDanh_LH], [DiaChi_LH], [DTdidong_LH], [DTKhac_LH], [DaiDienTheoPL_LH], [TenNguoiNhan], [DienThoaiNguoiNhan], [DiaChiNguoiNhan], [EmailNguoiNhan], [DiaDiemGiaoHang], [NgayCap], [NoiCap], [CMND]) VALUES (N'KH000029', N'05', N'Cá nhân', NULL, N'Công ty a', NULL, N'Việt nam', N'0123456789', NULL, N'a@gmail.com', NULL, N'123456', NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'ghi chú', NULL, NULL, NULL, N'Việt Nam', NULL, N'Kiên giang', N'Rạch giá', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[LapRapThaoDo] ([MaLapRapThaoDo], [MaHang], [MaThanhPham], [SoLuong], [Ngay], [DienGiai], [DonGia], [ThanhTien]) VALUES (N'LRTD000001', N'000000000003', N'TP0001', 2, CAST(N'2020-08-24' AS Date), N'Diễn giải', 22000, 100000)
INSERT [dbo].[LapRapThaoDo] ([MaLapRapThaoDo], [MaHang], [MaThanhPham], [SoLuong], [Ngay], [DienGiai], [DonGia], [ThanhTien]) VALUES (N'LRTD000002', N'000000000003', N'TP0001', 5, CAST(N'2020-08-24' AS Date), N'abc', 545000, 5000000)
INSERT [dbo].[LapRapThaoDo] ([MaLapRapThaoDo], [MaHang], [MaThanhPham], [SoLuong], [Ngay], [DienGiai], [DonGia], [ThanhTien]) VALUES (N'LRTD000003', N'000000000004', N'TP0002', 24, CAST(N'2020-08-24' AS Date), N'ccc', 540000, 500000)
INSERT [dbo].[LenhSanXuat] ([MaLenhSanXuat], [DienGiai], [Ngay], [MaTinhTrang], [DaGhiSo]) VALUES (N'000001', N'Diễn giải', CAST(N'2020-08-21' AS Date), 2, 1)
INSERT [dbo].[LenhSanXuat] ([MaLenhSanXuat], [DienGiai], [Ngay], [MaTinhTrang], [DaGhiSo]) VALUES (N'000002', N'Diễn giải', CAST(N'2020-08-21' AS Date), 1, 0)
INSERT [dbo].[LenhSanXuat] ([MaLenhSanXuat], [DienGiai], [Ngay], [MaTinhTrang], [DaGhiSo]) VALUES (N'000003', N'Diễn giải', CAST(N'2020-08-24' AS Date), 2, 1)
INSERT [dbo].[LenhSanXuat] ([MaLenhSanXuat], [DienGiai], [Ngay], [MaTinhTrang], [DaGhiSo]) VALUES (N'000004', N'Diễn giải', CAST(N'2020-08-24' AS Date), 1, 1)
INSERT [dbo].[LenhSanXuat] ([MaLenhSanXuat], [DienGiai], [Ngay], [MaTinhTrang], [DaGhiSo]) VALUES (N'000005', N'Diễn giải', CAST(N'2020-08-24' AS Date), 2, 0)
SET IDENTITY_INSERT [dbo].[LenhSanXuat_NVL] ON 

INSERT [dbo].[LenhSanXuat_NVL] ([MaLenhSanXuat_NVL], [MaLenhSanXuat], [MaHang], [SoLuong_1DonVi], [SoLuong], [DoiTuongDHCP], [KhoanMucCP], [MaThongKe]) VALUES (6, N'000005', N'000000000002', 2, 4, N'1         ', N'2         ', N'3         ')
INSERT [dbo].[LenhSanXuat_NVL] ([MaLenhSanXuat_NVL], [MaLenhSanXuat], [MaHang], [SoLuong_1DonVi], [SoLuong], [DoiTuongDHCP], [KhoanMucCP], [MaThongKe]) VALUES (7, N'000005', N'000000000004', 3, 5, N'4         ', N'5         ', N'6         ')
SET IDENTITY_INSERT [dbo].[LenhSanXuat_NVL] OFF
SET IDENTITY_INSERT [dbo].[LenhSanXuat_ThanhPham] ON 

INSERT [dbo].[LenhSanXuat_ThanhPham] ([MaLenhSanXuat_ThanhPham], [MaLenhSanXuat], [SoLuong], [MaThanhPham]) VALUES (1, N'000001', 1, N'TP0002')
INSERT [dbo].[LenhSanXuat_ThanhPham] ([MaLenhSanXuat_ThanhPham], [MaLenhSanXuat], [SoLuong], [MaThanhPham]) VALUES (2, N'000001', 4, N'TP0001')
INSERT [dbo].[LenhSanXuat_ThanhPham] ([MaLenhSanXuat_ThanhPham], [MaLenhSanXuat], [SoLuong], [MaThanhPham]) VALUES (4, N'000002', 1, N'TP0001')
INSERT [dbo].[LenhSanXuat_ThanhPham] ([MaLenhSanXuat_ThanhPham], [MaLenhSanXuat], [SoLuong], [MaThanhPham]) VALUES (5, N'000003', 12, N'TP0001')
INSERT [dbo].[LenhSanXuat_ThanhPham] ([MaLenhSanXuat_ThanhPham], [MaLenhSanXuat], [SoLuong], [MaThanhPham]) VALUES (6, N'000003', 13, N'TP0002')
INSERT [dbo].[LenhSanXuat_ThanhPham] ([MaLenhSanXuat_ThanhPham], [MaLenhSanXuat], [SoLuong], [MaThanhPham]) VALUES (7, N'000004', 2, N'TP0001')
INSERT [dbo].[LenhSanXuat_ThanhPham] ([MaLenhSanXuat_ThanhPham], [MaLenhSanXuat], [SoLuong], [MaThanhPham]) VALUES (8, N'000005', 12, N'TP0002')
SET IDENTITY_INSERT [dbo].[LenhSanXuat_ThanhPham] OFF
SET IDENTITY_INSERT [dbo].[LichSuLamViec] ON 

INSERT [dbo].[LichSuLamViec] ([ID], [MaSoNhanVien], [NgayBatDau], [NgayKetThuc], [TenCongTy], [ViTriLamViec], [NoiDungCongViec]) VALUES (27, N'0001', CAST(N'2020-07-03' AS Date), CAST(N'2020-07-09' AS Date), N'mekong-techaaa', N'nhân viên', N'code')
INSERT [dbo].[LichSuLamViec] ([ID], [MaSoNhanVien], [NgayBatDau], [NgayKetThuc], [TenCongTy], [ViTriLamViec], [NoiDungCongViec]) VALUES (28, N'0001', CAST(N'2020-08-04' AS Date), CAST(N'2020-08-09' AS Date), N'mekong-tech', N'Giám đốc', N'code')
INSERT [dbo].[LichSuLamViec] ([ID], [MaSoNhanVien], [NgayBatDau], [NgayKetThuc], [TenCongTy], [ViTriLamViec], [NoiDungCongViec]) VALUES (29, N'0003', CAST(N'2020-07-02' AS Date), CAST(N'2020-07-09' AS Date), N'mekong-tech', N'nhân viên', N'code')
INSERT [dbo].[LichSuLamViec] ([ID], [MaSoNhanVien], [NgayBatDau], [NgayKetThuc], [TenCongTy], [ViTriLamViec], [NoiDungCongViec]) VALUES (30, N'0004', CAST(N'2020-07-02' AS Date), CAST(N'2020-07-09' AS Date), N'mekong-tech', N'nhân viên', N'code')
INSERT [dbo].[LichSuLamViec] ([ID], [MaSoNhanVien], [NgayBatDau], [NgayKetThuc], [TenCongTy], [ViTriLamViec], [NoiDungCongViec]) VALUES (31, N'0005', CAST(N'2020-07-02' AS Date), CAST(N'2020-07-09' AS Date), N'mekong-tech', N'nhân viên', N'code')
INSERT [dbo].[LichSuLamViec] ([ID], [MaSoNhanVien], [NgayBatDau], [NgayKetThuc], [TenCongTy], [ViTriLamViec], [NoiDungCongViec]) VALUES (32, N'0006', CAST(N'2020-07-02' AS Date), CAST(N'2020-07-09' AS Date), N'mekong-tech', N'nhân viên', N'code')
INSERT [dbo].[LichSuLamViec] ([ID], [MaSoNhanVien], [NgayBatDau], [NgayKetThuc], [TenCongTy], [ViTriLamViec], [NoiDungCongViec]) VALUES (33, N'0007', CAST(N'2020-07-02' AS Date), CAST(N'2020-07-09' AS Date), N'mekong-tech', N'nhân viên', N'code')
INSERT [dbo].[LichSuLamViec] ([ID], [MaSoNhanVien], [NgayBatDau], [NgayKetThuc], [TenCongTy], [ViTriLamViec], [NoiDungCongViec]) VALUES (34, N'0008', CAST(N'2020-07-02' AS Date), CAST(N'2020-07-09' AS Date), N'mekong-tech', N'nhân viên', N'code')
INSERT [dbo].[LichSuLamViec] ([ID], [MaSoNhanVien], [NgayBatDau], [NgayKetThuc], [TenCongTy], [ViTriLamViec], [NoiDungCongViec]) VALUES (35, N'0009', CAST(N'2020-07-02' AS Date), CAST(N'2020-07-09' AS Date), N'mekong-tech', N'nhân viên', N'code')
INSERT [dbo].[LichSuLamViec] ([ID], [MaSoNhanVien], [NgayBatDau], [NgayKetThuc], [TenCongTy], [ViTriLamViec], [NoiDungCongViec]) VALUES (36, N'0010', CAST(N'2020-07-02' AS Date), CAST(N'2020-07-09' AS Date), N'mekong-tech', N'nhân viên', N'code')
INSERT [dbo].[LichSuLamViec] ([ID], [MaSoNhanVien], [NgayBatDau], [NgayKetThuc], [TenCongTy], [ViTriLamViec], [NoiDungCongViec]) VALUES (49, N'0001', CAST(N'2020-08-26' AS Date), CAST(N'2020-08-29' AS Date), N'fqwffwqf', N'Giám đốc', N'wfqfw')
INSERT [dbo].[LichSuLamViec] ([ID], [MaSoNhanVien], [NgayBatDau], [NgayKetThuc], [TenCongTy], [ViTriLamViec], [NoiDungCongViec]) VALUES (50, N'0001', CAST(N'2020-08-11' AS Date), CAST(N'2020-08-23' AS Date), N'gdag', N'gsa', N'gsag')
INSERT [dbo].[LichSuLamViec] ([ID], [MaSoNhanVien], [NgayBatDau], [NgayKetThuc], [TenCongTy], [ViTriLamViec], [NoiDungCongViec]) VALUES (51, N'0012', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[LichSuLamViec] ([ID], [MaSoNhanVien], [NgayBatDau], [NgayKetThuc], [TenCongTy], [ViTriLamViec], [NoiDungCongViec]) VALUES (52, N'0013', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[LichSuLamViec] ([ID], [MaSoNhanVien], [NgayBatDau], [NgayKetThuc], [TenCongTy], [ViTriLamViec], [NoiDungCongViec]) VALUES (53, N'0014', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[LichSuLamViec] ([ID], [MaSoNhanVien], [NgayBatDau], [NgayKetThuc], [TenCongTy], [ViTriLamViec], [NoiDungCongViec]) VALUES (54, N'0015', NULL, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[LichSuLamViec] OFF
SET IDENTITY_INSERT [dbo].[LoaiChi] ON 

INSERT [dbo].[LoaiChi] ([MaLoaiChi], [TenLoaiChi], [GhiChu]) VALUES (1, N'Tạm ứng cho nhân viên', NULL)
INSERT [dbo].[LoaiChi] ([MaLoaiChi], [TenLoaiChi], [GhiChu]) VALUES (2, N'Gửi tiền vào ngân hàng', NULL)
INSERT [dbo].[LoaiChi] ([MaLoaiChi], [TenLoaiChi], [GhiChu]) VALUES (3, N'Chi khác', NULL)
INSERT [dbo].[LoaiChi] ([MaLoaiChi], [TenLoaiChi], [GhiChu]) VALUES (4, N'Thuế TNDN tạm tính', NULL)
SET IDENTITY_INSERT [dbo].[LoaiChi] OFF
INSERT [dbo].[LoaiCongCuDungCu] ([MaLoaiCCDC], [TenLoaiCCDC], [DienGiai], [SoTaiKhoanCo]) VALUES (N'000001', N'Bàn phím', N'Bàn phím cơ', N'1211')
INSERT [dbo].[LoaiCongCuDungCu] ([MaLoaiCCDC], [TenLoaiCCDC], [DienGiai], [SoTaiKhoanCo]) VALUES (N'000002', N'Chuột', N'Chuột cơ', N'1123')
INSERT [dbo].[LoaiCongCuDungCu] ([MaLoaiCCDC], [TenLoaiCCDC], [DienGiai], [SoTaiKhoanCo]) VALUES (N'000003', N'Router wifi', N'Router wifi', N'1361')
INSERT [dbo].[LoaiTaiSanCoDinh] ([MaLoaiTSCD], [TenLoaiTSCD], [SoTaiKhoanCo], [SoTaiKhoanNo], [Thuoc]) VALUES (N'000001', N'Nhà cửa vật kiến trúc', N'1111', N'1112', N'Tài sản cố định hữu hình')
INSERT [dbo].[LoaiTaiSanCoDinh] ([MaLoaiTSCD], [TenLoaiTSCD], [SoTaiKhoanCo], [SoTaiKhoanNo], [Thuoc]) VALUES (N'000002', N'Máy móc, thiết bị', N'1281', N'1112', N'Tài sản cố định hữu hình')
INSERT [dbo].[LoaiTaiSanCoDinh] ([MaLoaiTSCD], [TenLoaiTSCD], [SoTaiKhoanCo], [SoTaiKhoanNo], [Thuoc]) VALUES (N'000003', N'Phương tiện vận tải, truyền dẫn', N'1332', N'1113', N'Tài sản cố định hữu hình')
INSERT [dbo].[LoaiTaiSanCoDinh] ([MaLoaiTSCD], [TenLoaiTSCD], [SoTaiKhoanCo], [SoTaiKhoanNo], [Thuoc]) VALUES (N'000004', N'Thiết bị, dụng cụ quản lý', N'1362', N'1113', N'Tài sản cố định hữu hình')
INSERT [dbo].[LoaiTaiSanCoDinh] ([MaLoaiTSCD], [TenLoaiTSCD], [SoTaiKhoanCo], [SoTaiKhoanNo], [Thuoc]) VALUES (N'000005', N'Vườn cây lâu năm, súc vật làm việc và cho sản phẩm', N'1363', N'1111', N'Tài sản cố định hữu hình')
INSERT [dbo].[LoaiTaiSanCoDinh] ([MaLoaiTSCD], [TenLoaiTSCD], [SoTaiKhoanCo], [SoTaiKhoanNo], [Thuoc]) VALUES (N'000006', N'Các TSCĐ là kết cấu hạ tầng, có giá trị lớn do Nhà nước ĐTXD từ NSNN giao cho các', N'1562', N'1113', N'Tài sản cố định hữu hình')
INSERT [dbo].[LoaiTaiSanCoDinh] ([MaLoaiTSCD], [TenLoaiTSCD], [SoTaiKhoanCo], [SoTaiKhoanNo], [Thuoc]) VALUES (N'000007', N'Tài sản cố định khác', N'157', N'1111', N'Tài sản cố định hữu hình')
INSERT [dbo].[LoaiTaiSanCoDinh] ([MaLoaiTSCD], [TenLoaiTSCD], [SoTaiKhoanCo], [SoTaiKhoanNo], [Thuoc]) VALUES (N'000008', N'Quyền sử dụng đất', N'158', N'1113', N'Tài sản cố định hữu hình')
INSERT [dbo].[LoaiTaiSanCoDinh] ([MaLoaiTSCD], [TenLoaiTSCD], [SoTaiKhoanCo], [SoTaiKhoanNo], [Thuoc]) VALUES (N'000009', N'Quyền phát hành', N'2143', N'1111', N'Tài sản cố định hữu hình')
INSERT [dbo].[LoaiTaiSanCoDinh] ([MaLoaiTSCD], [TenLoaiTSCD], [SoTaiKhoanCo], [SoTaiKhoanNo], [Thuoc]) VALUES (N'000010', N'Bản quyền, bằng sáng chế', N'2147', N'1112', N'Tài sản cố định vô hình')
INSERT [dbo].[LoaiTaiSanCoDinh] ([MaLoaiTSCD], [TenLoaiTSCD], [SoTaiKhoanCo], [SoTaiKhoanNo], [Thuoc]) VALUES (N'000011', N'Nhãn hiệu hàng hóa', N'242', N'1112', N'Tài sản cố định vô hình')
INSERT [dbo].[LoaiTaiSanCoDinh] ([MaLoaiTSCD], [TenLoaiTSCD], [SoTaiKhoanCo], [SoTaiKhoanNo], [Thuoc]) VALUES (N'000012', N'Phầm mềm máy vi tính', N'243', N'1112', N'Tài sản cố định vô hình')
INSERT [dbo].[LoaiTaiSanCoDinh] ([MaLoaiTSCD], [TenLoaiTSCD], [SoTaiKhoanCo], [SoTaiKhoanNo], [Thuoc]) VALUES (N'000013', N'Giấy phép và giấy phép nhượng quyền', N'3333', N'1112', N'Tài sản cố định vô hình')
INSERT [dbo].[LoaiTaiSanCoDinh] ([MaLoaiTSCD], [TenLoaiTSCD], [SoTaiKhoanCo], [SoTaiKhoanNo], [Thuoc]) VALUES (N'000014', N'Tài sản cố định vô hình khác', N'33312', N'1113', N'Tài sản cố định vô hình')
INSERT [dbo].[LoaiTaiSanCoDinh] ([MaLoaiTSCD], [TenLoaiTSCD], [SoTaiKhoanCo], [SoTaiKhoanNo], [Thuoc]) VALUES (N'000015', N'Phần mềm sáng chế', N'1332', N'1113', N'Tài sản cố định hữu hình')
INSERT [dbo].[LoaiTaiSanCoDinh] ([MaLoaiTSCD], [TenLoaiTSCD], [SoTaiKhoanCo], [SoTaiKhoanNo], [Thuoc]) VALUES (N'000016', N'Phần mếm sáng tạo', N'1123', N'1113', N'Tài sản cố định vô hình')
INSERT [dbo].[LoaiTaiSanCoDinh] ([MaLoaiTSCD], [TenLoaiTSCD], [SoTaiKhoanCo], [SoTaiKhoanNo], [Thuoc]) VALUES (N'000017', N'phần mềm sáng chế', N'1123', N'1112', N'Tài sản cố định hữu hình')
SET IDENTITY_INSERT [dbo].[LoaiThu] ON 

INSERT [dbo].[LoaiThu] ([MaLoaiThu], [TenLoaiThu], [GhiChu]) VALUES (1, N'Rút tiền gửi về nộp quỹ', NULL)
INSERT [dbo].[LoaiThu] ([MaLoaiThu], [TenLoaiThu], [GhiChu]) VALUES (2, N'Thu hoàn thuế GTGT', NULL)
INSERT [dbo].[LoaiThu] ([MaLoaiThu], [TenLoaiThu], [GhiChu]) VALUES (3, N'Thu hoàn ứng', NULL)
INSERT [dbo].[LoaiThu] ([MaLoaiThu], [TenLoaiThu], [GhiChu]) VALUES (4, N'Thu khác', NULL)
SET IDENTITY_INSERT [dbo].[LoaiThu] OFF
INSERT [dbo].[LoaiTien] ([MaLoaiTien], [TenLoaiTien], [VietTat], [MenhGia], [TyGia_VND]) VALUES (1, N'Việt Nam đồng', N'VND', NULL, 1000)
INSERT [dbo].[LoaiTien] ([MaLoaiTien], [TenLoaiTien], [VietTat], [MenhGia], [TyGia_VND]) VALUES (2, N'Đô-La Mỹ', N'USD', NULL, 23175)
SET IDENTITY_INSERT [dbo].[NgonNgu] ON 

INSERT [dbo].[NgonNgu] ([ID], [MaSoNhanVien], [TenNgonNgu], [Nghe], [Noi], [Doc], [Viet]) VALUES (17, N'0001', N'Tiếng Pháp', N'Giỏi', N'Giỏi', N'Giỏi', N'Giỏi')
INSERT [dbo].[NgonNgu] ([ID], [MaSoNhanVien], [TenNgonNgu], [Nghe], [Noi], [Doc], [Viet]) VALUES (18, N'0002', N'Tiếng Anh', NULL, NULL, NULL, NULL)
INSERT [dbo].[NgonNgu] ([ID], [MaSoNhanVien], [TenNgonNgu], [Nghe], [Noi], [Doc], [Viet]) VALUES (19, N'0003', N'Tiếng Anh', NULL, NULL, NULL, NULL)
INSERT [dbo].[NgonNgu] ([ID], [MaSoNhanVien], [TenNgonNgu], [Nghe], [Noi], [Doc], [Viet]) VALUES (20, N'0004', N'Tiếng Anh', NULL, NULL, NULL, NULL)
INSERT [dbo].[NgonNgu] ([ID], [MaSoNhanVien], [TenNgonNgu], [Nghe], [Noi], [Doc], [Viet]) VALUES (21, N'0005', N'Tiếng Anh', NULL, NULL, NULL, NULL)
INSERT [dbo].[NgonNgu] ([ID], [MaSoNhanVien], [TenNgonNgu], [Nghe], [Noi], [Doc], [Viet]) VALUES (22, N'0006', N'Tiếng Anh', NULL, NULL, NULL, NULL)
INSERT [dbo].[NgonNgu] ([ID], [MaSoNhanVien], [TenNgonNgu], [Nghe], [Noi], [Doc], [Viet]) VALUES (23, N'0007', N'Tiếng Anh', NULL, NULL, NULL, NULL)
INSERT [dbo].[NgonNgu] ([ID], [MaSoNhanVien], [TenNgonNgu], [Nghe], [Noi], [Doc], [Viet]) VALUES (24, N'0008', N'Tiếng Anh', NULL, NULL, NULL, NULL)
INSERT [dbo].[NgonNgu] ([ID], [MaSoNhanVien], [TenNgonNgu], [Nghe], [Noi], [Doc], [Viet]) VALUES (25, N'0009', N'Tiếng Anh', NULL, NULL, NULL, NULL)
INSERT [dbo].[NgonNgu] ([ID], [MaSoNhanVien], [TenNgonNgu], [Nghe], [Noi], [Doc], [Viet]) VALUES (26, N'0010', N'Tiếng Anh', NULL, NULL, NULL, NULL)
INSERT [dbo].[NgonNgu] ([ID], [MaSoNhanVien], [TenNgonNgu], [Nghe], [Noi], [Doc], [Viet]) VALUES (39, N'0001', N'fqwf', N'fqwfwqfwqf', N'Giỏi', N'fwqfwq', N'Giỏi')
INSERT [dbo].[NgonNgu] ([ID], [MaSoNhanVien], [TenNgonNgu], [Nghe], [Noi], [Doc], [Viet]) VALUES (40, N'0001', N'fasg', N'sgas', N'gágsgg', N'sfaf', N'à')
INSERT [dbo].[NgonNgu] ([ID], [MaSoNhanVien], [TenNgonNgu], [Nghe], [Noi], [Doc], [Viet]) VALUES (41, N'0001', N'à', N'fasf', N'fsaf', N'fasfsf', N'sfs')
INSERT [dbo].[NgonNgu] ([ID], [MaSoNhanVien], [TenNgonNgu], [Nghe], [Noi], [Doc], [Viet]) VALUES (42, N'0012', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[NgonNgu] ([ID], [MaSoNhanVien], [TenNgonNgu], [Nghe], [Noi], [Doc], [Viet]) VALUES (43, N'0013', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[NgonNgu] ([ID], [MaSoNhanVien], [TenNgonNgu], [Nghe], [Noi], [Doc], [Viet]) VALUES (44, N'0014', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[NgonNgu] ([ID], [MaSoNhanVien], [TenNgonNgu], [Nghe], [Noi], [Doc], [Viet]) VALUES (45, N'0015', NULL, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[NgonNgu] OFF
INSERT [dbo].[NhaCungCap] ([MaNhaCungCap], [NhomKH_NCC], [PhanLoai], [TenNhaCungCap], [ChiNhanh], [DiaChi], [SoDienThoai], [Fax], [Email], [Website], [MaSoThue], [SoTaiKhoanNganHang], [TenNganHang], [NguoiLienHe], [DaXoa], [NguoiXoa], [NgayXoa], [XungHo], [NVBanHang], [DienGiai], [DieuKhoanTT], [SoNgayDuocNo], [SoNoToiDa], [QuocGia], [Quan_Huyen], [Tinh_TP], [Xa_Phuong], [DienThoaiCoDinh_LH], [HoVaTen_LH], [Email_LH], [ChucDanh_LH], [DiaChi_LH], [DTdidong_LH], [DTKhac_LH], [DaiDienTheoPL_LH], [TenNguoiNhan], [DienThoaiNguoiNhan], [DiaChiNguoiNhan], [EmailNguoiNhan], [DiaDiemGiaoHang], [NgayCap], [NoiCap], [CMND]) VALUES (N'0001', N'0001', N'Tổ chức', N'Ngân hàng phát triển nông thôn', N'A', N'20/21/10/Quận Bình Tân', N'0528105152', N'5455', N'nghiale@gmail.com', N'www.Mekong-tech.com', N'111111111111', N'11111111111', N'VietCombank', N'Nguyen van a', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[NhaCungCap] ([MaNhaCungCap], [NhomKH_NCC], [PhanLoai], [TenNhaCungCap], [ChiNhanh], [DiaChi], [SoDienThoai], [Fax], [Email], [Website], [MaSoThue], [SoTaiKhoanNganHang], [TenNganHang], [NguoiLienHe], [DaXoa], [NguoiXoa], [NgayXoa], [XungHo], [NVBanHang], [DienGiai], [DieuKhoanTT], [SoNgayDuocNo], [SoNoToiDa], [QuocGia], [Quan_Huyen], [Tinh_TP], [Xa_Phuong], [DienThoaiCoDinh_LH], [HoVaTen_LH], [Email_LH], [ChucDanh_LH], [DiaChi_LH], [DTdidong_LH], [DTKhac_LH], [DaiDienTheoPL_LH], [TenNguoiNhan], [DienThoaiNguoiNhan], [DiaChiNguoiNhan], [EmailNguoiNhan], [DiaDiemGiaoHang], [NgayCap], [NoiCap], [CMND]) VALUES (N'0002', N'0002', N'Cá nhân', N'Ngân hàng S', N'30 Trần phú', N'20/31/Trần phú', N'5353', N'5353535', N'luan@gmail.com', N'wwww', N'21414124', N'42141', N'HSBC', N'Nguyễn văn D', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[NhaCungCap] ([MaNhaCungCap], [NhomKH_NCC], [PhanLoai], [TenNhaCungCap], [ChiNhanh], [DiaChi], [SoDienThoai], [Fax], [Email], [Website], [MaSoThue], [SoTaiKhoanNganHang], [TenNganHang], [NguoiLienHe], [DaXoa], [NguoiXoa], [NgayXoa], [XungHo], [NVBanHang], [DienGiai], [DieuKhoanTT], [SoNgayDuocNo], [SoNoToiDa], [QuocGia], [Quan_Huyen], [Tinh_TP], [Xa_Phuong], [DienThoaiCoDinh_LH], [HoVaTen_LH], [Email_LH], [ChucDanh_LH], [DiaChi_LH], [DTdidong_LH], [DTKhac_LH], [DaiDienTheoPL_LH], [TenNguoiNhan], [DienThoaiNguoiNhan], [DiaChiNguoiNhan], [EmailNguoiNhan], [DiaDiemGiaoHang], [NgayCap], [NoiCap], [CMND]) VALUES (N'0003', N'0003', N'Cá nhân', N'Ngân hàng HSBC', N'20 tran phu', N'21/31/Trần phú', N'515151511515', N'5515151', N'luan@gmail.com', N'www.google.com', N'54554545', N'5454545454', N'Paypal', N'Nguyễn văn c', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[NhaCungCap] ([MaNhaCungCap], [NhomKH_NCC], [PhanLoai], [TenNhaCungCap], [ChiNhanh], [DiaChi], [SoDienThoai], [Fax], [Email], [Website], [MaSoThue], [SoTaiKhoanNganHang], [TenNganHang], [NguoiLienHe], [DaXoa], [NguoiXoa], [NgayXoa], [XungHo], [NVBanHang], [DienGiai], [DieuKhoanTT], [SoNgayDuocNo], [SoNoToiDa], [QuocGia], [Quan_Huyen], [Tinh_TP], [Xa_Phuong], [DienThoaiCoDinh_LH], [HoVaTen_LH], [Email_LH], [ChucDanh_LH], [DiaChi_LH], [DTdidong_LH], [DTKhac_LH], [DaiDienTheoPL_LH], [TenNguoiNhan], [DienThoaiNguoiNhan], [DiaChiNguoiNhan], [EmailNguoiNhan], [DiaDiemGiaoHang], [NgayCap], [NoiCap], [CMND]) VALUES (N'0004', N'0004', N'Tổ chức', N'Ngân hàng S', N'30 Trần phú', N'20/31/Trần phú', N'4242', N'42424', N'nghiale@gmail.com', N'www.Mekong-tech.com', N'4124124242', N'65366', N'VietCombank', N'Nguyen van a', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[NhaCungCap] ([MaNhaCungCap], [NhomKH_NCC], [PhanLoai], [TenNhaCungCap], [ChiNhanh], [DiaChi], [SoDienThoai], [Fax], [Email], [Website], [MaSoThue], [SoTaiKhoanNganHang], [TenNganHang], [NguoiLienHe], [DaXoa], [NguoiXoa], [NgayXoa], [XungHo], [NVBanHang], [DienGiai], [DieuKhoanTT], [SoNgayDuocNo], [SoNoToiDa], [QuocGia], [Quan_Huyen], [Tinh_TP], [Xa_Phuong], [DienThoaiCoDinh_LH], [HoVaTen_LH], [Email_LH], [ChucDanh_LH], [DiaChi_LH], [DTdidong_LH], [DTKhac_LH], [DaiDienTheoPL_LH], [TenNguoiNhan], [DienThoaiNguoiNhan], [DiaChiNguoiNhan], [EmailNguoiNhan], [DiaDiemGiaoHang], [NgayCap], [NoiCap], [CMND]) VALUES (N'0005', N'0005', N'Cá nhân', N'Ngân hàng Kien Long bank', N'52 trần phú', N'20/01/ Trần phú', N'5455151515', N'4242424242424', N'Truong@gmail.com', N'www.facebook.com', N'53535', N'5353535', N'HSBC', N'Nguyen van D', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[NhaCungCap] ([MaNhaCungCap], [NhomKH_NCC], [PhanLoai], [TenNhaCungCap], [ChiNhanh], [DiaChi], [SoDienThoai], [Fax], [Email], [Website], [MaSoThue], [SoTaiKhoanNganHang], [TenNganHang], [NguoiLienHe], [DaXoa], [NguoiXoa], [NgayXoa], [XungHo], [NVBanHang], [DienGiai], [DieuKhoanTT], [SoNgayDuocNo], [SoNoToiDa], [QuocGia], [Quan_Huyen], [Tinh_TP], [Xa_Phuong], [DienThoaiCoDinh_LH], [HoVaTen_LH], [Email_LH], [ChucDanh_LH], [DiaChi_LH], [DTdidong_LH], [DTKhac_LH], [DaiDienTheoPL_LH], [TenNguoiNhan], [DienThoaiNguoiNhan], [DiaChiNguoiNhan], [EmailNguoiNhan], [DiaDiemGiaoHang], [NgayCap], [NoiCap], [CMND]) VALUES (N'0006', N'0004', N'Tổ chức', N'A', N'A', N'dgsdfg', N'5346346', N'63463463', N'luan@', N'qqqwwwww.com', N'43454353464', N'5r342523', N'Sacombank', N'Nguyen A', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[NhaCungCap] ([MaNhaCungCap], [NhomKH_NCC], [PhanLoai], [TenNhaCungCap], [ChiNhanh], [DiaChi], [SoDienThoai], [Fax], [Email], [Website], [MaSoThue], [SoTaiKhoanNganHang], [TenNganHang], [NguoiLienHe], [DaXoa], [NguoiXoa], [NgayXoa], [XungHo], [NVBanHang], [DienGiai], [DieuKhoanTT], [SoNgayDuocNo], [SoNoToiDa], [QuocGia], [Quan_Huyen], [Tinh_TP], [Xa_Phuong], [DienThoaiCoDinh_LH], [HoVaTen_LH], [Email_LH], [ChucDanh_LH], [DiaChi_LH], [DTdidong_LH], [DTKhac_LH], [DaiDienTheoPL_LH], [TenNguoiNhan], [DienThoaiNguoiNhan], [DiaChiNguoiNhan], [EmailNguoiNhan], [DiaDiemGiaoHang], [NgayCap], [NoiCap], [CMND]) VALUES (N'0007', N'0002', N'Cá nhân', N'Ngân hàng tư nhân', N'Chi nhánh 2', N'20/30 Quận Bình Tân', N'1515151555', N'51515151515', N'luan18@', N'www.ggggg.com', N'545151515', N'51515151515', N'VietCombank', N'Nguyen C', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[NhaCungCap] ([MaNhaCungCap], [NhomKH_NCC], [PhanLoai], [TenNhaCungCap], [ChiNhanh], [DiaChi], [SoDienThoai], [Fax], [Email], [Website], [MaSoThue], [SoTaiKhoanNganHang], [TenNganHang], [NguoiLienHe], [DaXoa], [NguoiXoa], [NgayXoa], [XungHo], [NVBanHang], [DienGiai], [DieuKhoanTT], [SoNgayDuocNo], [SoNoToiDa], [QuocGia], [Quan_Huyen], [Tinh_TP], [Xa_Phuong], [DienThoaiCoDinh_LH], [HoVaTen_LH], [Email_LH], [ChucDanh_LH], [DiaChi_LH], [DTdidong_LH], [DTKhac_LH], [DaiDienTheoPL_LH], [TenNguoiNhan], [DienThoaiNguoiNhan], [DiaChiNguoiNhan], [EmailNguoiNhan], [DiaDiemGiaoHang], [NgayCap], [NoiCap], [CMND]) VALUES (N'0008', N'0002', N'Cá nhân', N'Trường', N'Kiên giang', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[NhanVien] ([MaSoNhanVien], [HoVaTen], [GioiTinh], [SoCMND], [NgayCapCMND], [NoiCapCMND], [NgaySinh], [TinhTrangHonNhan], [QuocTich], [DiaChi], [SoDienThoai], [Email], [HoTenLienHeKhanCap], [QuanHeLienHeKhanCap], [DiaChiLienHeKhanCap], [SDTLienHeKhanCap], [Hinh], [Bac], [TrangThai], [MaCoSo], [MaChucVu], [MaSoThue], [SoTaiKhoanNganHang], [TenNganHang], [ChiNhanh], [MaDonVi]) VALUES (N'0001', N'Lê Trung Khoa', N'Nam', N'1234567', CAST(N'2020-07-17' AS Date), N'Việt Nam', CAST(N'2020-07-21' AS Date), NULL, N'Việt Nam', NULL, N'42141245215215', N'uttruong2015@gmail.com', NULL, NULL, NULL, NULL, N'/Assets/giaovien/img/files/download.png', 10, NULL, N'001', N'99', NULL, NULL, NULL, NULL, N'BGD')
INSERT [dbo].[NhanVien] ([MaSoNhanVien], [HoVaTen], [GioiTinh], [SoCMND], [NgayCapCMND], [NoiCapCMND], [NgaySinh], [TinhTrangHonNhan], [QuocTich], [DiaChi], [SoDienThoai], [Email], [HoTenLienHeKhanCap], [QuanHeLienHeKhanCap], [DiaChiLienHeKhanCap], [SDTLienHeKhanCap], [Hinh], [Bac], [TrangThai], [MaCoSo], [MaChucVu], [MaSoThue], [SoTaiKhoanNganHang], [TenNganHang], [ChiNhanh], [MaDonVi]) VALUES (N'0002', N'Nguyễn Vũ Lâm', N'Nam', N'123456', CAST(N'2020-07-09' AS Date), N'Việt Nam', CAST(N'2020-07-16' AS Date), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 10, NULL, N'003', N'79', NULL, NULL, NULL, NULL, N'PHC')
INSERT [dbo].[NhanVien] ([MaSoNhanVien], [HoVaTen], [GioiTinh], [SoCMND], [NgayCapCMND], [NoiCapCMND], [NgaySinh], [TinhTrangHonNhan], [QuocTich], [DiaChi], [SoDienThoai], [Email], [HoTenLienHeKhanCap], [QuanHeLienHeKhanCap], [DiaChiLienHeKhanCap], [SDTLienHeKhanCap], [Hinh], [Bac], [TrangThai], [MaCoSo], [MaChucVu], [MaSoThue], [SoTaiKhoanNganHang], [TenNganHang], [ChiNhanh], [MaDonVi]) VALUES (N'0003', N'Lê Trung Nghĩa', N'Nam', N'123456', CAST(N'2020-07-29' AS Date), N'Việt Nam', CAST(N'2020-07-23' AS Date), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 5, NULL, N'001', N'89', NULL, NULL, NULL, NULL, N'PHC')
INSERT [dbo].[NhanVien] ([MaSoNhanVien], [HoVaTen], [GioiTinh], [SoCMND], [NgayCapCMND], [NoiCapCMND], [NgaySinh], [TinhTrangHonNhan], [QuocTich], [DiaChi], [SoDienThoai], [Email], [HoTenLienHeKhanCap], [QuanHeLienHeKhanCap], [DiaChiLienHeKhanCap], [SDTLienHeKhanCap], [Hinh], [Bac], [TrangThai], [MaCoSo], [MaChucVu], [MaSoThue], [SoTaiKhoanNganHang], [TenNganHang], [ChiNhanh], [MaDonVi]) VALUES (N'0004', N'Lê Minh Tường', N'Nam', N'123456', CAST(N'2020-07-24' AS Date), N'Việt Nam', CAST(N'2020-07-22' AS Date), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 5, NULL, N'001', N'88', NULL, NULL, NULL, NULL, N'PKD')
INSERT [dbo].[NhanVien] ([MaSoNhanVien], [HoVaTen], [GioiTinh], [SoCMND], [NgayCapCMND], [NoiCapCMND], [NgaySinh], [TinhTrangHonNhan], [QuocTich], [DiaChi], [SoDienThoai], [Email], [HoTenLienHeKhanCap], [QuanHeLienHeKhanCap], [DiaChiLienHeKhanCap], [SDTLienHeKhanCap], [Hinh], [Bac], [TrangThai], [MaCoSo], [MaChucVu], [MaSoThue], [SoTaiKhoanNganHang], [TenNganHang], [ChiNhanh], [MaDonVi]) VALUES (N'0005', N'Lê Thị Ngọc Lan', N'Nữ', N'123456', CAST(N'2020-07-01' AS Date), N'Việt Nam', CAST(N'2020-07-11' AS Date), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 5, NULL, N'001', N'79', NULL, NULL, NULL, NULL, N'PKD')
INSERT [dbo].[NhanVien] ([MaSoNhanVien], [HoVaTen], [GioiTinh], [SoCMND], [NgayCapCMND], [NoiCapCMND], [NgaySinh], [TinhTrangHonNhan], [QuocTich], [DiaChi], [SoDienThoai], [Email], [HoTenLienHeKhanCap], [QuanHeLienHeKhanCap], [DiaChiLienHeKhanCap], [SDTLienHeKhanCap], [Hinh], [Bac], [TrangThai], [MaCoSo], [MaChucVu], [MaSoThue], [SoTaiKhoanNganHang], [TenNganHang], [ChiNhanh], [MaDonVi]) VALUES (N'0006', N'Trần Văn Trường', N'Nam', N'123456', CAST(N'2020-07-16' AS Date), N'Việt Nam', CAST(N'2020-07-22' AS Date), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 5, NULL, N'001', N'78', NULL, NULL, NULL, NULL, N'PKD')
INSERT [dbo].[NhanVien] ([MaSoNhanVien], [HoVaTen], [GioiTinh], [SoCMND], [NgayCapCMND], [NoiCapCMND], [NgaySinh], [TinhTrangHonNhan], [QuocTich], [DiaChi], [SoDienThoai], [Email], [HoTenLienHeKhanCap], [QuanHeLienHeKhanCap], [DiaChiLienHeKhanCap], [SDTLienHeKhanCap], [Hinh], [Bac], [TrangThai], [MaCoSo], [MaChucVu], [MaSoThue], [SoTaiKhoanNganHang], [TenNganHang], [ChiNhanh], [MaDonVi]) VALUES (N'0007', N'Diệp Minh Luận', N'Nam', N'123456', CAST(N'2020-07-23' AS Date), N'Việt Nam', CAST(N'2020-07-16' AS Date), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 5, NULL, N'002', N'79', NULL, NULL, NULL, NULL, N'PKD')
INSERT [dbo].[NhanVien] ([MaSoNhanVien], [HoVaTen], [GioiTinh], [SoCMND], [NgayCapCMND], [NoiCapCMND], [NgaySinh], [TinhTrangHonNhan], [QuocTich], [DiaChi], [SoDienThoai], [Email], [HoTenLienHeKhanCap], [QuanHeLienHeKhanCap], [DiaChiLienHeKhanCap], [SDTLienHeKhanCap], [Hinh], [Bac], [TrangThai], [MaCoSo], [MaChucVu], [MaSoThue], [SoTaiKhoanNganHang], [TenNganHang], [ChiNhanh], [MaDonVi]) VALUES (N'0008', N'Nguyễn Huy Lâm', N'Nam', N'123456', CAST(N'2020-07-23' AS Date), N'Việt Nam', CAST(N'2020-07-15' AS Date), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 5, NULL, N'001', N'59', NULL, NULL, NULL, NULL, N'PKT')
INSERT [dbo].[NhanVien] ([MaSoNhanVien], [HoVaTen], [GioiTinh], [SoCMND], [NgayCapCMND], [NoiCapCMND], [NgaySinh], [TinhTrangHonNhan], [QuocTich], [DiaChi], [SoDienThoai], [Email], [HoTenLienHeKhanCap], [QuanHeLienHeKhanCap], [DiaChiLienHeKhanCap], [SDTLienHeKhanCap], [Hinh], [Bac], [TrangThai], [MaCoSo], [MaChucVu], [MaSoThue], [SoTaiKhoanNganHang], [TenNganHang], [ChiNhanh], [MaDonVi]) VALUES (N'0009', N'Trương Minh Trường', N'Nam', N'123456', CAST(N'2020-07-23' AS Date), N'Việt Nam', CAST(N'2020-07-16' AS Date), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 5, NULL, N'002', N'59', NULL, NULL, NULL, NULL, N'PHC')
INSERT [dbo].[NhanVien] ([MaSoNhanVien], [HoVaTen], [GioiTinh], [SoCMND], [NgayCapCMND], [NoiCapCMND], [NgaySinh], [TinhTrangHonNhan], [QuocTich], [DiaChi], [SoDienThoai], [Email], [HoTenLienHeKhanCap], [QuanHeLienHeKhanCap], [DiaChiLienHeKhanCap], [SDTLienHeKhanCap], [Hinh], [Bac], [TrangThai], [MaCoSo], [MaChucVu], [MaSoThue], [SoTaiKhoanNganHang], [TenNganHang], [ChiNhanh], [MaDonVi]) VALUES (N'0010', N'Trần Trung Khoa', N'Nam', N'123456', CAST(N'2020-07-23' AS Date), N'Việt Nam', CAST(N'2020-07-23' AS Date), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 5, NULL, N'002', N'59', NULL, NULL, NULL, NULL, N'PHC')
INSERT [dbo].[NhanVien] ([MaSoNhanVien], [HoVaTen], [GioiTinh], [SoCMND], [NgayCapCMND], [NoiCapCMND], [NgaySinh], [TinhTrangHonNhan], [QuocTich], [DiaChi], [SoDienThoai], [Email], [HoTenLienHeKhanCap], [QuanHeLienHeKhanCap], [DiaChiLienHeKhanCap], [SDTLienHeKhanCap], [Hinh], [Bac], [TrangThai], [MaCoSo], [MaChucVu], [MaSoThue], [SoTaiKhoanNganHang], [TenNganHang], [ChiNhanh], [MaDonVi]) VALUES (N'0011', N'Trần Văn Nhân viên', N'Nam', NULL, CAST(N'2020-08-14' AS Date), N'Kiên Giang', CAST(N'2020-08-06' AS Date), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, N'001', NULL, N'12132', N'2313123', N'Teccombank', N'Kiên giang', N'PKT')
INSERT [dbo].[NhanVien] ([MaSoNhanVien], [HoVaTen], [GioiTinh], [SoCMND], [NgayCapCMND], [NoiCapCMND], [NgaySinh], [TinhTrangHonNhan], [QuocTich], [DiaChi], [SoDienThoai], [Email], [HoTenLienHeKhanCap], [QuanHeLienHeKhanCap], [DiaChiLienHeKhanCap], [SDTLienHeKhanCap], [Hinh], [Bac], [TrangThai], [MaCoSo], [MaChucVu], [MaSoThue], [SoTaiKhoanNganHang], [TenNganHang], [ChiNhanh], [MaDonVi]) VALUES (N'0012', N'Lê Tấn Đạt', N'Nam', N'1231223123', CAST(N'2020-08-27' AS Date), N'Việt Nam', CAST(N'2020-08-27' AS Date), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, N'001', N'59', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[NhanVien] ([MaSoNhanVien], [HoVaTen], [GioiTinh], [SoCMND], [NgayCapCMND], [NoiCapCMND], [NgaySinh], [TinhTrangHonNhan], [QuocTich], [DiaChi], [SoDienThoai], [Email], [HoTenLienHeKhanCap], [QuanHeLienHeKhanCap], [DiaChiLienHeKhanCap], [SDTLienHeKhanCap], [Hinh], [Bac], [TrangThai], [MaCoSo], [MaChucVu], [MaSoThue], [SoTaiKhoanNganHang], [TenNganHang], [ChiNhanh], [MaDonVi]) VALUES (N'0013', N'Huỳnh Thanh Vân', N'Nam', N'123456', CAST(N'2020-08-15' AS Date), N'Việt Nam', CAST(N'2020-08-18' AS Date), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, N'002', N'59', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[NhanVien] ([MaSoNhanVien], [HoVaTen], [GioiTinh], [SoCMND], [NgayCapCMND], [NoiCapCMND], [NgaySinh], [TinhTrangHonNhan], [QuocTich], [DiaChi], [SoDienThoai], [Email], [HoTenLienHeKhanCap], [QuanHeLienHeKhanCap], [DiaChiLienHeKhanCap], [SDTLienHeKhanCap], [Hinh], [Bac], [TrangThai], [MaCoSo], [MaChucVu], [MaSoThue], [SoTaiKhoanNganHang], [TenNganHang], [ChiNhanh], [MaDonVi]) VALUES (N'0014', N'Lê Minh Tường', N'Nam', N'1231223123', CAST(N'2020-08-23' AS Date), N'Việt Nam', CAST(N'2020-08-13' AS Date), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, N'002', N'59', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[NhanVien] ([MaSoNhanVien], [HoVaTen], [GioiTinh], [SoCMND], [NgayCapCMND], [NoiCapCMND], [NgaySinh], [TinhTrangHonNhan], [QuocTich], [DiaChi], [SoDienThoai], [Email], [HoTenLienHeKhanCap], [QuanHeLienHeKhanCap], [DiaChiLienHeKhanCap], [SDTLienHeKhanCap], [Hinh], [Bac], [TrangThai], [MaCoSo], [MaChucVu], [MaSoThue], [SoTaiKhoanNganHang], [TenNganHang], [ChiNhanh], [MaDonVi]) VALUES (N'0015', N'Nguyễn Anh Thi', NULL, N'1231223123', CAST(N'2020-08-29' AS Date), N'Việt Nam', CAST(N'2020-08-22' AS Date), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, N'003', N'59', NULL, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[NhomHangHoa] ON 

INSERT [dbo].[NhomHangHoa] ([MaNhomHH], [TenNhom], [GhiChu]) VALUES (1, N'Quần', NULL)
INSERT [dbo].[NhomHangHoa] ([MaNhomHH], [TenNhom], [GhiChu]) VALUES (2, N'Áo', NULL)
SET IDENTITY_INSERT [dbo].[NhomHangHoa] OFF
INSERT [dbo].[NhomKH_NCC] ([NhomKH_NCC], [TenNhomKH_NCC], [DienGiai]) VALUES (N'0001', N'Tiềm năng', N'abc')
INSERT [dbo].[NhomKH_NCC] ([NhomKH_NCC], [TenNhomKH_NCC], [DienGiai]) VALUES (N'0002', N'Nhóm a', N'Diễn giải')
INSERT [dbo].[NhomKH_NCC] ([NhomKH_NCC], [TenNhomKH_NCC], [DienGiai]) VALUES (N'0003', N'Nhóm b', NULL)
INSERT [dbo].[NhomKH_NCC] ([NhomKH_NCC], [TenNhomKH_NCC], [DienGiai]) VALUES (N'0004', N'Nhóm c', NULL)
INSERT [dbo].[NhomKH_NCC] ([NhomKH_NCC], [TenNhomKH_NCC], [DienGiai]) VALUES (N'0005', N'Nhóm d', NULL)
INSERT [dbo].[NhomKH_NCC] ([NhomKH_NCC], [TenNhomKH_NCC], [DienGiai]) VALUES (N'01', N'Nhóm 1', NULL)
INSERT [dbo].[NhomKH_NCC] ([NhomKH_NCC], [TenNhomKH_NCC], [DienGiai]) VALUES (N'02', N'Nhóm 2', NULL)
INSERT [dbo].[NhomKH_NCC] ([NhomKH_NCC], [TenNhomKH_NCC], [DienGiai]) VALUES (N'03', N'Nhóm 3', NULL)
INSERT [dbo].[NhomKH_NCC] ([NhomKH_NCC], [TenNhomKH_NCC], [DienGiai]) VALUES (N'04', N'Nhóm 4', NULL)
INSERT [dbo].[NhomKH_NCC] ([NhomKH_NCC], [TenNhomKH_NCC], [DienGiai]) VALUES (N'05', N'Nhóm A', N'Nhóm b')
INSERT [dbo].[NhomKH_NCC] ([NhomKH_NCC], [TenNhomKH_NCC], [DienGiai]) VALUES (N'KH', N'nhóm KH', NULL)
INSERT [dbo].[PhieuChi] ([MaPhieuChi], [MaSoNhanVien], [MaNhaCungCap], [MaLoaiChi], [MaTinhTrang], [LyDoChi], [DienGiai], [NgayHoachToan], [NgayChungTu], [TongTienDichVu], [TienChietKhau], [TienThueGTGT], [TongTienThanhToan], [ChungTuGoc], [MaLoaiTien], [TyGia], [NguoiNop], [DaGhiSo]) VALUES (N'PC000003', N'0001', N'0001', 1, 2, N'KHác', NULL, CAST(N'2020-08-12' AS Date), CAST(N'2020-08-12' AS Date), NULL, NULL, 0, 3576657, 2, 2, 25175, N'Trường', 0)
INSERT [dbo].[PhieuChi] ([MaPhieuChi], [MaSoNhanVien], [MaNhaCungCap], [MaLoaiChi], [MaTinhTrang], [LyDoChi], [DienGiai], [NgayHoachToan], [NgayChungTu], [TongTienDichVu], [TienChietKhau], [TienThueGTGT], [TongTienThanhToan], [ChungTuGoc], [MaLoaiTien], [TyGia], [NguoiNop], [DaGhiSo]) VALUES (N'PC000004', N'0001', N'0001', 1, 2, N'KHác', NULL, CAST(N'2020-08-12' AS Date), CAST(N'2020-07-11' AS Date), NULL, NULL, 0, 3576657, 2, 2, 25175, N'Trường', 1)
INSERT [dbo].[PhieuChi] ([MaPhieuChi], [MaSoNhanVien], [MaNhaCungCap], [MaLoaiChi], [MaTinhTrang], [LyDoChi], [DienGiai], [NgayHoachToan], [NgayChungTu], [TongTienDichVu], [TienChietKhau], [TienThueGTGT], [TongTienThanhToan], [ChungTuGoc], [MaLoaiTien], [TyGia], [NguoiNop], [DaGhiSo]) VALUES (N'PC000005', N'0001', N'0001', 1, 2, N'KHác', NULL, CAST(N'2020-08-12' AS Date), CAST(N'2020-08-10' AS Date), NULL, NULL, 0, 3576657, 2, 2, 25175, N'Trường', 1)
INSERT [dbo].[PhieuChi] ([MaPhieuChi], [MaSoNhanVien], [MaNhaCungCap], [MaLoaiChi], [MaTinhTrang], [LyDoChi], [DienGiai], [NgayHoachToan], [NgayChungTu], [TongTienDichVu], [TienChietKhau], [TienThueGTGT], [TongTienThanhToan], [ChungTuGoc], [MaLoaiTien], [TyGia], [NguoiNop], [DaGhiSo]) VALUES (N'PC000006', N'0001', N'0001', 1, 2, N'KHác', NULL, CAST(N'2020-08-12' AS Date), CAST(N'2020-06-09' AS Date), NULL, NULL, 0, 3576657, 2, 2, 25175, N'Trường', 0)
INSERT [dbo].[PhieuChi] ([MaPhieuChi], [MaSoNhanVien], [MaNhaCungCap], [MaLoaiChi], [MaTinhTrang], [LyDoChi], [DienGiai], [NgayHoachToan], [NgayChungTu], [TongTienDichVu], [TienChietKhau], [TienThueGTGT], [TongTienThanhToan], [ChungTuGoc], [MaLoaiTien], [TyGia], [NguoiNop], [DaGhiSo]) VALUES (N'PC000007', N'0001', N'0001', 1, 2, N'KHác', NULL, CAST(N'2020-08-12' AS Date), CAST(N'2020-08-08' AS Date), NULL, NULL, 0, 3576657, 2, 2, 25175, N'Trường', 1)
INSERT [dbo].[PhieuChi] ([MaPhieuChi], [MaSoNhanVien], [MaNhaCungCap], [MaLoaiChi], [MaTinhTrang], [LyDoChi], [DienGiai], [NgayHoachToan], [NgayChungTu], [TongTienDichVu], [TienChietKhau], [TienThueGTGT], [TongTienThanhToan], [ChungTuGoc], [MaLoaiTien], [TyGia], [NguoiNop], [DaGhiSo]) VALUES (N'PC000008', N'0001', N'0001', 1, 2, N'KHác', NULL, CAST(N'2020-08-12' AS Date), CAST(N'2019-08-07' AS Date), NULL, NULL, 0, 3576657, 2, 2, 25175, N'Trường', 0)
INSERT [dbo].[PhieuChi] ([MaPhieuChi], [MaSoNhanVien], [MaNhaCungCap], [MaLoaiChi], [MaTinhTrang], [LyDoChi], [DienGiai], [NgayHoachToan], [NgayChungTu], [TongTienDichVu], [TienChietKhau], [TienThueGTGT], [TongTienThanhToan], [ChungTuGoc], [MaLoaiTien], [TyGia], [NguoiNop], [DaGhiSo]) VALUES (N'PC000009', N'0001', N'0001', 1, 2, N'KHác', N'', CAST(N'2020-08-12' AS Date), CAST(N'2019-08-12' AS Date), NULL, NULL, 0, 3576657, 2, 2, 25175, N'Trường', 0)
INSERT [dbo].[PhieuChi] ([MaPhieuChi], [MaSoNhanVien], [MaNhaCungCap], [MaLoaiChi], [MaTinhTrang], [LyDoChi], [DienGiai], [NgayHoachToan], [NgayChungTu], [TongTienDichVu], [TienChietKhau], [TienThueGTGT], [TongTienThanhToan], [ChungTuGoc], [MaLoaiTien], [TyGia], [NguoiNop], [DaGhiSo]) VALUES (N'PC000010', N'0001', N'0001', 1, 2, N'KHác', N'', CAST(N'2020-08-12' AS Date), CAST(N'2021-07-11' AS Date), NULL, NULL, 0, 3576657, 2, 2, 25175, N'Trường', 1)
INSERT [dbo].[PhieuChi] ([MaPhieuChi], [MaSoNhanVien], [MaNhaCungCap], [MaLoaiChi], [MaTinhTrang], [LyDoChi], [DienGiai], [NgayHoachToan], [NgayChungTu], [TongTienDichVu], [TienChietKhau], [TienThueGTGT], [TongTienThanhToan], [ChungTuGoc], [MaLoaiTien], [TyGia], [NguoiNop], [DaGhiSo]) VALUES (N'PC000011', N'0001', N'0001', 1, 2, N'KHác', N'', CAST(N'2020-08-12' AS Date), CAST(N'2020-08-10' AS Date), NULL, NULL, 0, 3576657, 2, 2, 25175, N'Trường', 1)
INSERT [dbo].[PhieuChi] ([MaPhieuChi], [MaSoNhanVien], [MaNhaCungCap], [MaLoaiChi], [MaTinhTrang], [LyDoChi], [DienGiai], [NgayHoachToan], [NgayChungTu], [TongTienDichVu], [TienChietKhau], [TienThueGTGT], [TongTienThanhToan], [ChungTuGoc], [MaLoaiTien], [TyGia], [NguoiNop], [DaGhiSo]) VALUES (N'PC000012', N'0001', N'0001', 1, 2, N'KHác', N'', CAST(N'2020-08-12' AS Date), CAST(N'2020-07-11' AS Date), NULL, NULL, 0, 3576657, 2, 2, 25175, N'Trường', 0)
INSERT [dbo].[PhieuChi] ([MaPhieuChi], [MaSoNhanVien], [MaNhaCungCap], [MaLoaiChi], [MaTinhTrang], [LyDoChi], [DienGiai], [NgayHoachToan], [NgayChungTu], [TongTienDichVu], [TienChietKhau], [TienThueGTGT], [TongTienThanhToan], [ChungTuGoc], [MaLoaiTien], [TyGia], [NguoiNop], [DaGhiSo]) VALUES (N'PC000013', N'0001', N'0001', 1, 2, N'KHác', N'', CAST(N'2020-08-12' AS Date), CAST(N'2020-05-12' AS Date), NULL, NULL, 0, 3576657, 2, 2, 25175, N'Trường', 1)
INSERT [dbo].[PhieuChi] ([MaPhieuChi], [MaSoNhanVien], [MaNhaCungCap], [MaLoaiChi], [MaTinhTrang], [LyDoChi], [DienGiai], [NgayHoachToan], [NgayChungTu], [TongTienDichVu], [TienChietKhau], [TienThueGTGT], [TongTienThanhToan], [ChungTuGoc], [MaLoaiTien], [TyGia], [NguoiNop], [DaGhiSo]) VALUES (N'PC000014', N'0001', N'0001', 1, 2, N'KHác', N'', CAST(N'2020-08-12' AS Date), CAST(N'2020-08-13' AS Date), NULL, NULL, 0, 3576657, 2, 2, 25175, N'Trường', 0)
INSERT [dbo].[PhieuChi] ([MaPhieuChi], [MaSoNhanVien], [MaNhaCungCap], [MaLoaiChi], [MaTinhTrang], [LyDoChi], [DienGiai], [NgayHoachToan], [NgayChungTu], [TongTienDichVu], [TienChietKhau], [TienThueGTGT], [TongTienThanhToan], [ChungTuGoc], [MaLoaiTien], [TyGia], [NguoiNop], [DaGhiSo]) VALUES (N'PC000015', N'0001', N'0001', 1, 2, N'KHác', N'', CAST(N'2020-08-12' AS Date), CAST(N'2020-08-14' AS Date), NULL, NULL, 0, 3576657, 2, 2, 25175, N'Trường', 0)
INSERT [dbo].[PhieuChi] ([MaPhieuChi], [MaSoNhanVien], [MaNhaCungCap], [MaLoaiChi], [MaTinhTrang], [LyDoChi], [DienGiai], [NgayHoachToan], [NgayChungTu], [TongTienDichVu], [TienChietKhau], [TienThueGTGT], [TongTienThanhToan], [ChungTuGoc], [MaLoaiTien], [TyGia], [NguoiNop], [DaGhiSo]) VALUES (N'PC000016', N'0001', N'0001', 1, 2, N'KHác', N'', CAST(N'2020-08-12' AS Date), CAST(N'2020-08-15' AS Date), NULL, NULL, 0, 3576657, 2, 2, 25175, N'Trường', 1)
INSERT [dbo].[PhieuChi] ([MaPhieuChi], [MaSoNhanVien], [MaNhaCungCap], [MaLoaiChi], [MaTinhTrang], [LyDoChi], [DienGiai], [NgayHoachToan], [NgayChungTu], [TongTienDichVu], [TienChietKhau], [TienThueGTGT], [TongTienThanhToan], [ChungTuGoc], [MaLoaiTien], [TyGia], [NguoiNop], [DaGhiSo]) VALUES (N'PC000017', N'0001', N'0001', 1, 2, N'KHác', N'', CAST(N'2020-08-12' AS Date), CAST(N'2021-08-16' AS Date), NULL, NULL, 0, 3576657, 2, 2, 25175, N'Trường', 1)
INSERT [dbo].[PhieuChi] ([MaPhieuChi], [MaSoNhanVien], [MaNhaCungCap], [MaLoaiChi], [MaTinhTrang], [LyDoChi], [DienGiai], [NgayHoachToan], [NgayChungTu], [TongTienDichVu], [TienChietKhau], [TienThueGTGT], [TongTienThanhToan], [ChungTuGoc], [MaLoaiTien], [TyGia], [NguoiNop], [DaGhiSo]) VALUES (N'PC000018', N'0001', N'0001', 1, 2, N'KHác', N'', CAST(N'2020-08-12' AS Date), CAST(N'2020-08-17' AS Date), NULL, NULL, 0, 3576657, 2, 2, 25175, N'Trường', 0)
INSERT [dbo].[PhieuChi] ([MaPhieuChi], [MaSoNhanVien], [MaNhaCungCap], [MaLoaiChi], [MaTinhTrang], [LyDoChi], [DienGiai], [NgayHoachToan], [NgayChungTu], [TongTienDichVu], [TienChietKhau], [TienThueGTGT], [TongTienThanhToan], [ChungTuGoc], [MaLoaiTien], [TyGia], [NguoiNop], [DaGhiSo]) VALUES (N'PC000019', N'0001', N'0001', 1, 2, N'KHác', N'', CAST(N'2020-08-12' AS Date), CAST(N'2020-08-18' AS Date), NULL, NULL, 0, 3576657, 2, 2, 25175, N'Trường', 1)
INSERT [dbo].[PhieuChi] ([MaPhieuChi], [MaSoNhanVien], [MaNhaCungCap], [MaLoaiChi], [MaTinhTrang], [LyDoChi], [DienGiai], [NgayHoachToan], [NgayChungTu], [TongTienDichVu], [TienChietKhau], [TienThueGTGT], [TongTienThanhToan], [ChungTuGoc], [MaLoaiTien], [TyGia], [NguoiNop], [DaGhiSo]) VALUES (N'PC000020', N'0001', N'0001', 1, 2, N'KHác', N'', CAST(N'2020-08-12' AS Date), CAST(N'2020-08-19' AS Date), NULL, NULL, 0, 3576657, 2, 2, 25175, N'Trường', 0)
INSERT [dbo].[PhieuChi] ([MaPhieuChi], [MaSoNhanVien], [MaNhaCungCap], [MaLoaiChi], [MaTinhTrang], [LyDoChi], [DienGiai], [NgayHoachToan], [NgayChungTu], [TongTienDichVu], [TienChietKhau], [TienThueGTGT], [TongTienThanhToan], [ChungTuGoc], [MaLoaiTien], [TyGia], [NguoiNop], [DaGhiSo]) VALUES (N'PC000021', N'0001', N'0001', 1, 2, N'KHác', N'', CAST(N'2020-08-12' AS Date), CAST(N'2020-08-20' AS Date), NULL, NULL, 0, 3576657, 2, 2, 25175, N'Trường', 0)
INSERT [dbo].[PhieuChi] ([MaPhieuChi], [MaSoNhanVien], [MaNhaCungCap], [MaLoaiChi], [MaTinhTrang], [LyDoChi], [DienGiai], [NgayHoachToan], [NgayChungTu], [TongTienDichVu], [TienChietKhau], [TienThueGTGT], [TongTienThanhToan], [ChungTuGoc], [MaLoaiTien], [TyGia], [NguoiNop], [DaGhiSo]) VALUES (N'PC000022', N'0001', N'0001', 1, 2, N'KHác', N'', CAST(N'2020-08-12' AS Date), CAST(N'2020-08-21' AS Date), NULL, NULL, 0, 3576657, 2, 2, 25175, N'Trường', 1)
INSERT [dbo].[PhieuChi] ([MaPhieuChi], [MaSoNhanVien], [MaNhaCungCap], [MaLoaiChi], [MaTinhTrang], [LyDoChi], [DienGiai], [NgayHoachToan], [NgayChungTu], [TongTienDichVu], [TienChietKhau], [TienThueGTGT], [TongTienThanhToan], [ChungTuGoc], [MaLoaiTien], [TyGia], [NguoiNop], [DaGhiSo]) VALUES (N'PC000023', N'0001', N'0001', 1, 2, N'KHác', N'', CAST(N'2020-08-12' AS Date), CAST(N'2020-08-22' AS Date), NULL, NULL, 0, 3576657, 2, 2, 25175, N'Trường', 1)
INSERT [dbo].[PhieuChi] ([MaPhieuChi], [MaSoNhanVien], [MaNhaCungCap], [MaLoaiChi], [MaTinhTrang], [LyDoChi], [DienGiai], [NgayHoachToan], [NgayChungTu], [TongTienDichVu], [TienChietKhau], [TienThueGTGT], [TongTienThanhToan], [ChungTuGoc], [MaLoaiTien], [TyGia], [NguoiNop], [DaGhiSo]) VALUES (N'PC000024', N'0001', N'0001', 1, 2, N'KHác', N'', CAST(N'2020-08-12' AS Date), CAST(N'2020-08-23' AS Date), NULL, NULL, 0, 3576657, 2, 2, 25175, N'Trường', 0)
INSERT [dbo].[PhieuChi] ([MaPhieuChi], [MaSoNhanVien], [MaNhaCungCap], [MaLoaiChi], [MaTinhTrang], [LyDoChi], [DienGiai], [NgayHoachToan], [NgayChungTu], [TongTienDichVu], [TienChietKhau], [TienThueGTGT], [TongTienThanhToan], [ChungTuGoc], [MaLoaiTien], [TyGia], [NguoiNop], [DaGhiSo]) VALUES (N'PC000025', N'0001', N'0001', 1, 2, N'KHác', N'', CAST(N'2020-08-12' AS Date), CAST(N'2020-08-24' AS Date), NULL, NULL, 0, 3576657, 2, 2, 25175, N'Trường', 1)
INSERT [dbo].[PhieuChi] ([MaPhieuChi], [MaSoNhanVien], [MaNhaCungCap], [MaLoaiChi], [MaTinhTrang], [LyDoChi], [DienGiai], [NgayHoachToan], [NgayChungTu], [TongTienDichVu], [TienChietKhau], [TienThueGTGT], [TongTienThanhToan], [ChungTuGoc], [MaLoaiTien], [TyGia], [NguoiNop], [DaGhiSo]) VALUES (N'PC000026', N'0001', N'0001', 1, 2, N'KHác', N'', CAST(N'2020-08-12' AS Date), CAST(N'2020-08-25' AS Date), NULL, NULL, 0, 3576657, 2, 2, 25175, N'Trường', 0)
INSERT [dbo].[PhieuChi] ([MaPhieuChi], [MaSoNhanVien], [MaNhaCungCap], [MaLoaiChi], [MaTinhTrang], [LyDoChi], [DienGiai], [NgayHoachToan], [NgayChungTu], [TongTienDichVu], [TienChietKhau], [TienThueGTGT], [TongTienThanhToan], [ChungTuGoc], [MaLoaiTien], [TyGia], [NguoiNop], [DaGhiSo]) VALUES (N'PC000027', N'0006', N'0001', 4, 1, N'Nộp chi tiền', NULL, CAST(N'2020-08-13' AS Date), CAST(N'2020-08-13' AS Date), NULL, NULL, 0, 5700000, 3, 1, 1000, N'Trần Văn Trường', 0)
INSERT [dbo].[PhieuChi] ([MaPhieuChi], [MaSoNhanVien], [MaNhaCungCap], [MaLoaiChi], [MaTinhTrang], [LyDoChi], [DienGiai], [NgayHoachToan], [NgayChungTu], [TongTienDichVu], [TienChietKhau], [TienThueGTGT], [TongTienThanhToan], [ChungTuGoc], [MaLoaiTien], [TyGia], [NguoiNop], [DaGhiSo]) VALUES (N'PC000028', N'0001', NULL, NULL, NULL, NULL, N'Dieexn giai', CAST(N'2020-08-20' AS Date), CAST(N'2020-08-20' AS Date), NULL, NULL, 3120000, 16845000, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[PhieuChi] ([MaPhieuChi], [MaSoNhanVien], [MaNhaCungCap], [MaLoaiChi], [MaTinhTrang], [LyDoChi], [DienGiai], [NgayHoachToan], [NgayChungTu], [TongTienDichVu], [TienChietKhau], [TienThueGTGT], [TongTienThanhToan], [ChungTuGoc], [MaLoaiTien], [TyGia], [NguoiNop], [DaGhiSo]) VALUES (N'PC000029', N'0001', NULL, NULL, NULL, N'Lý do chi', N'Dieexn giai', CAST(N'2020-08-20' AS Date), CAST(N'2020-08-20' AS Date), NULL, NULL, 3120000, 16845000, NULL, 1, 1000, NULL, NULL)
INSERT [dbo].[PhieuChi] ([MaPhieuChi], [MaSoNhanVien], [MaNhaCungCap], [MaLoaiChi], [MaTinhTrang], [LyDoChi], [DienGiai], [NgayHoachToan], [NgayChungTu], [TongTienDichVu], [TienChietKhau], [TienThueGTGT], [TongTienThanhToan], [ChungTuGoc], [MaLoaiTien], [TyGia], [NguoiNop], [DaGhiSo]) VALUES (N'PC000030', N'0001', NULL, NULL, NULL, N'sadadwa', N'Dieexn giai', CAST(N'2020-08-20' AS Date), CAST(N'2020-08-20' AS Date), NULL, NULL, 3120000, 16845000, NULL, 2, 23175, NULL, NULL)
INSERT [dbo].[PhieuChi] ([MaPhieuChi], [MaSoNhanVien], [MaNhaCungCap], [MaLoaiChi], [MaTinhTrang], [LyDoChi], [DienGiai], [NgayHoachToan], [NgayChungTu], [TongTienDichVu], [TienChietKhau], [TienThueGTGT], [TongTienThanhToan], [ChungTuGoc], [MaLoaiTien], [TyGia], [NguoiNop], [DaGhiSo]) VALUES (N'PC000031', N'0001', NULL, NULL, NULL, N'ădad', NULL, CAST(N'2020-08-20' AS Date), CAST(N'2020-08-20' AS Date), NULL, NULL, 245000, 1470000, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[PhieuChi] ([MaPhieuChi], [MaSoNhanVien], [MaNhaCungCap], [MaLoaiChi], [MaTinhTrang], [LyDoChi], [DienGiai], [NgayHoachToan], [NgayChungTu], [TongTienDichVu], [TienChietKhau], [TienThueGTGT], [TongTienThanhToan], [ChungTuGoc], [MaLoaiTien], [TyGia], [NguoiNop], [DaGhiSo]) VALUES (N'PC000032', N'0001', NULL, NULL, NULL, NULL, NULL, CAST(N'2020-08-20' AS Date), CAST(N'2020-08-20' AS Date), NULL, NULL, 245000, 1470000, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[PhieuChi] ([MaPhieuChi], [MaSoNhanVien], [MaNhaCungCap], [MaLoaiChi], [MaTinhTrang], [LyDoChi], [DienGiai], [NgayHoachToan], [NgayChungTu], [TongTienDichVu], [TienChietKhau], [TienThueGTGT], [TongTienThanhToan], [ChungTuGoc], [MaLoaiTien], [TyGia], [NguoiNop], [DaGhiSo]) VALUES (N'PC000033', NULL, NULL, NULL, NULL, N'ădawd', N'adwdawdaw', CAST(N'2020-08-20' AS Date), CAST(N'2020-08-20' AS Date), NULL, NULL, 3120000, 16845000, NULL, 1, 1000, NULL, NULL)
INSERT [dbo].[PhieuNhapKho] ([MaPhieuNhapKho], [MaKhachHang], [NguoiGiaoHang], [DienGiai], [ChungTuGoc], [NgayHoachToan], [NgayChungTu], [ChungTuThamChieu], [LyDoNhap], [TongTienThanhToan], [DaGhiSo]) VALUES (N'NK0001', N'KH000001', N'Nguyen van  C', N'dien giai', 444, CAST(N'2019-08-19' AS Date), CAST(N'2020-08-19' AS Date), N'1515', N'252000', 2420000, 1)
INSERT [dbo].[PhieuThu] ([MaPhieuThu], [MaKhachHang], [MaSoNhanVien], [MaLoaiThu], [MaTinhTrang], [LyDoNop], [DienGiai], [NgayHoachToan], [NgayChungTu], [TongTienHang], [TienChietKhau], [TienThueGTGT], [TongTienThanhToan], [DaGhiSo], [ChungTuGoc], [MaLoaiTien], [TyGia], [ChungTuThamChieu], [NguoiNop]) VALUES (N'PT000001', N'KH000001', N'0001', 1, 1, N'Nộp khác', NULL, CAST(N'2020-08-12' AS Date), CAST(N'2020-08-11' AS Date), 7000000, NULL, 0, 7000000, 1, 2, 2, 50000, NULL, N'Trần Văn Trường')
INSERT [dbo].[PhieuThu] ([MaPhieuThu], [MaKhachHang], [MaSoNhanVien], [MaLoaiThu], [MaTinhTrang], [LyDoNop], [DienGiai], [NgayHoachToan], [NgayChungTu], [TongTienHang], [TienChietKhau], [TienThueGTGT], [TongTienThanhToan], [DaGhiSo], [ChungTuGoc], [MaLoaiTien], [TyGia], [ChungTuThamChieu], [NguoiNop]) VALUES (N'PT000002', NULL, NULL, NULL, NULL, NULL, NULL, CAST(N'2020-08-12' AS Date), CAST(N'2020-08-10' AS Date), 0, NULL, 0, 2152757, 0, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[PhieuThu] ([MaPhieuThu], [MaKhachHang], [MaSoNhanVien], [MaLoaiThu], [MaTinhTrang], [LyDoNop], [DienGiai], [NgayHoachToan], [NgayChungTu], [TongTienHang], [TienChietKhau], [TienThueGTGT], [TongTienThanhToan], [DaGhiSo], [ChungTuGoc], [MaLoaiTien], [TyGia], [ChungTuThamChieu], [NguoiNop]) VALUES (N'PT000003', NULL, NULL, NULL, NULL, NULL, NULL, CAST(N'2020-08-12' AS Date), CAST(N'2020-08-02' AS Date), 2152757, NULL, 0, 2152757, 1, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[PhieuThu] ([MaPhieuThu], [MaKhachHang], [MaSoNhanVien], [MaLoaiThu], [MaTinhTrang], [LyDoNop], [DienGiai], [NgayHoachToan], [NgayChungTu], [TongTienHang], [TienChietKhau], [TienThueGTGT], [TongTienThanhToan], [DaGhiSo], [ChungTuGoc], [MaLoaiTien], [TyGia], [ChungTuThamChieu], [NguoiNop]) VALUES (N'PT000004', NULL, NULL, NULL, NULL, NULL, NULL, CAST(N'2020-08-12' AS Date), CAST(N'2020-07-17' AS Date), 234234, NULL, 0, 2152757, 0, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[PhieuThu] ([MaPhieuThu], [MaKhachHang], [MaSoNhanVien], [MaLoaiThu], [MaTinhTrang], [LyDoNop], [DienGiai], [NgayHoachToan], [NgayChungTu], [TongTienHang], [TienChietKhau], [TienThueGTGT], [TongTienThanhToan], [DaGhiSo], [ChungTuGoc], [MaLoaiTien], [TyGia], [ChungTuThamChieu], [NguoiNop]) VALUES (N'PT000005', N'KH000008', N'0007', 3, 3, N'Nộp test', NULL, CAST(N'2020-08-12' AS Date), CAST(N'2020-05-13' AS Date), 4000000, NULL, 0, 2152757, 1, 2, 2, 22000, NULL, N'Trần Văn Trường')
INSERT [dbo].[PhieuThu] ([MaPhieuThu], [MaKhachHang], [MaSoNhanVien], [MaLoaiThu], [MaTinhTrang], [LyDoNop], [DienGiai], [NgayHoachToan], [NgayChungTu], [TongTienHang], [TienChietKhau], [TienThueGTGT], [TongTienThanhToan], [DaGhiSo], [ChungTuGoc], [MaLoaiTien], [TyGia], [ChungTuThamChieu], [NguoiNop]) VALUES (N'PT000006', N'KH000002', N'0001', 1, 3, N'Nộp khác', NULL, CAST(N'2020-08-12' AS Date), CAST(N'2020-08-06' AS Date), 2000000, NULL, 0, 2152757, 0, 1, 1, 1000, NULL, N'Trần Văn Trường')
INSERT [dbo].[PhieuThu] ([MaPhieuThu], [MaKhachHang], [MaSoNhanVien], [MaLoaiThu], [MaTinhTrang], [LyDoNop], [DienGiai], [NgayHoachToan], [NgayChungTu], [TongTienHang], [TienChietKhau], [TienThueGTGT], [TongTienThanhToan], [DaGhiSo], [ChungTuGoc], [MaLoaiTien], [TyGia], [ChungTuThamChieu], [NguoiNop]) VALUES (N'PT000007', N'KH000001', N'0001', 1, 1, N'Nộp khác', N'', CAST(N'2020-08-12' AS Date), CAST(N'2020-08-12' AS Date), 7000000, 0, 0, 7000000, 1, 2, 2, 50000, N'          ', N'Trần Văn Trường')
INSERT [dbo].[PhieuThu] ([MaPhieuThu], [MaKhachHang], [MaSoNhanVien], [MaLoaiThu], [MaTinhTrang], [LyDoNop], [DienGiai], [NgayHoachToan], [NgayChungTu], [TongTienHang], [TienChietKhau], [TienThueGTGT], [TongTienThanhToan], [DaGhiSo], [ChungTuGoc], [MaLoaiTien], [TyGia], [ChungTuThamChieu], [NguoiNop]) VALUES (N'PT000008', N'KH000001', N'0001', 1, 3, N'Nộp khác', N'', CAST(N'2020-08-12' AS Date), CAST(N'2019-07-10' AS Date), 7000001, 0, 0, 2152757, 0, 2, 2, 50001, N'          ', N'Trần Văn Trường')
INSERT [dbo].[PhieuThu] ([MaPhieuThu], [MaKhachHang], [MaSoNhanVien], [MaLoaiThu], [MaTinhTrang], [LyDoNop], [DienGiai], [NgayHoachToan], [NgayChungTu], [TongTienHang], [TienChietKhau], [TienThueGTGT], [TongTienThanhToan], [DaGhiSo], [ChungTuGoc], [MaLoaiTien], [TyGia], [ChungTuThamChieu], [NguoiNop]) VALUES (N'PT000009', N'KH000001', N'0001', 1, 3, N'Nộp khác', N'', CAST(N'2020-08-12' AS Date), CAST(N'2021-08-02' AS Date), 2152757, 0, 0, 2152757, 1, 2, 2, 50002, N'          ', N'Trần Văn Trường')
INSERT [dbo].[PhieuThu] ([MaPhieuThu], [MaKhachHang], [MaSoNhanVien], [MaLoaiThu], [MaTinhTrang], [LyDoNop], [DienGiai], [NgayHoachToan], [NgayChungTu], [TongTienHang], [TienChietKhau], [TienThueGTGT], [TongTienThanhToan], [DaGhiSo], [ChungTuGoc], [MaLoaiTien], [TyGia], [ChungTuThamChieu], [NguoiNop]) VALUES (N'PT000010', N'KH000001', N'0001', 1, 3, N'Nộp khác', N'', CAST(N'2020-08-12' AS Date), CAST(N'2020-06-17' AS Date), 234234, 0, 0, 2152757, 0, 1, 1, 50003, N'          ', N'Trần Văn Trường')
INSERT [dbo].[PhieuThu] ([MaPhieuThu], [MaKhachHang], [MaSoNhanVien], [MaLoaiThu], [MaTinhTrang], [LyDoNop], [DienGiai], [NgayHoachToan], [NgayChungTu], [TongTienHang], [TienChietKhau], [TienThueGTGT], [TongTienThanhToan], [DaGhiSo], [ChungTuGoc], [MaLoaiTien], [TyGia], [ChungTuThamChieu], [NguoiNop]) VALUES (N'PT000011', N'KH000001', N'0007', 3, 3, N'Nộp test', N'', CAST(N'2020-08-12' AS Date), CAST(N'2020-05-13' AS Date), 4000000, 0, 0, 2152757, 1, 2, 2, 22000, N'          ', N'Trần Văn Trường')
INSERT [dbo].[PhieuThu] ([MaPhieuThu], [MaKhachHang], [MaSoNhanVien], [MaLoaiThu], [MaTinhTrang], [LyDoNop], [DienGiai], [NgayHoachToan], [NgayChungTu], [TongTienHang], [TienChietKhau], [TienThueGTGT], [TongTienThanhToan], [DaGhiSo], [ChungTuGoc], [MaLoaiTien], [TyGia], [ChungTuThamChieu], [NguoiNop]) VALUES (N'PT000012', N'KH000002', N'0001', 1, 3, N'Nộp khác', N'', CAST(N'2020-08-12' AS Date), CAST(N'2020-08-06' AS Date), 2000000, 0, 0, 2152757, 0, 1, 1, 1000, N'          ', N'Trần Văn Trường')
INSERT [dbo].[PhieuThu] ([MaPhieuThu], [MaKhachHang], [MaSoNhanVien], [MaLoaiThu], [MaTinhTrang], [LyDoNop], [DienGiai], [NgayHoachToan], [NgayChungTu], [TongTienHang], [TienChietKhau], [TienThueGTGT], [TongTienThanhToan], [DaGhiSo], [ChungTuGoc], [MaLoaiTien], [TyGia], [ChungTuThamChieu], [NguoiNop]) VALUES (N'PT000013', N'KH000001', N'0001', 1, 1, N'Nộp khác', N'', CAST(N'2020-08-12' AS Date), CAST(N'2020-08-12' AS Date), 7000000, 0, 0, 7000000, 1, 2, 2, 50000, N'          ', N'Trần Văn Trường')
INSERT [dbo].[PhieuThu] ([MaPhieuThu], [MaKhachHang], [MaSoNhanVien], [MaLoaiThu], [MaTinhTrang], [LyDoNop], [DienGiai], [NgayHoachToan], [NgayChungTu], [TongTienHang], [TienChietKhau], [TienThueGTGT], [TongTienThanhToan], [DaGhiSo], [ChungTuGoc], [MaLoaiTien], [TyGia], [ChungTuThamChieu], [NguoiNop]) VALUES (N'PT000014', N'KH000001', NULL, 1, 3, N'Nộp khác', N'', CAST(N'2020-08-12' AS Date), CAST(N'2019-07-10' AS Date), 7000000, 0, 0, 2152757, 0, 2, 2, 50001, N'          ', N'Trần Văn Trường')
INSERT [dbo].[PhieuThu] ([MaPhieuThu], [MaKhachHang], [MaSoNhanVien], [MaLoaiThu], [MaTinhTrang], [LyDoNop], [DienGiai], [NgayHoachToan], [NgayChungTu], [TongTienHang], [TienChietKhau], [TienThueGTGT], [TongTienThanhToan], [DaGhiSo], [ChungTuGoc], [MaLoaiTien], [TyGia], [ChungTuThamChieu], [NguoiNop]) VALUES (N'PT000015', N'KH000001', NULL, 1, 3, N'Nộp khác', N'', CAST(N'2020-08-12' AS Date), CAST(N'2021-05-02' AS Date), 2152757, 0, 0, 2152757, 1, 2, 2, 50002, N'          ', N'Trần Văn Trường')
INSERT [dbo].[PhieuThu] ([MaPhieuThu], [MaKhachHang], [MaSoNhanVien], [MaLoaiThu], [MaTinhTrang], [LyDoNop], [DienGiai], [NgayHoachToan], [NgayChungTu], [TongTienHang], [TienChietKhau], [TienThueGTGT], [TongTienThanhToan], [DaGhiSo], [ChungTuGoc], [MaLoaiTien], [TyGia], [ChungTuThamChieu], [NguoiNop]) VALUES (N'PT000016', N'KH000001', NULL, 1, 3, N'Nộp khác', N'', CAST(N'2020-08-12' AS Date), CAST(N'2020-04-17' AS Date), 234234, 0, 0, 2152757, 0, 1, 1, 50003, N'          ', N'Trần Văn Trường')
INSERT [dbo].[PhieuThu] ([MaPhieuThu], [MaKhachHang], [MaSoNhanVien], [MaLoaiThu], [MaTinhTrang], [LyDoNop], [DienGiai], [NgayHoachToan], [NgayChungTu], [TongTienHang], [TienChietKhau], [TienThueGTGT], [TongTienThanhToan], [DaGhiSo], [ChungTuGoc], [MaLoaiTien], [TyGia], [ChungTuThamChieu], [NguoiNop]) VALUES (N'PT000017', N'KH000001', N'0007', 3, 3, N'Nộp test', N'', CAST(N'2020-08-12' AS Date), CAST(N'2020-05-13' AS Date), 4000000, 0, 0, 2152757, 1, 2, 2, 22000, N'          ', N'Trần Văn Trường')
INSERT [dbo].[PhieuThu] ([MaPhieuThu], [MaKhachHang], [MaSoNhanVien], [MaLoaiThu], [MaTinhTrang], [LyDoNop], [DienGiai], [NgayHoachToan], [NgayChungTu], [TongTienHang], [TienChietKhau], [TienThueGTGT], [TongTienThanhToan], [DaGhiSo], [ChungTuGoc], [MaLoaiTien], [TyGia], [ChungTuThamChieu], [NguoiNop]) VALUES (N'PT000018', N'KH000002', N'0001', 1, 3, N'Nộp khác', N'', CAST(N'2020-08-12' AS Date), CAST(N'2020-03-09' AS Date), 2000000, 0, 0, 2152757, 0, 1, 1, 1000, N'          ', N'Trần Văn Trường')
INSERT [dbo].[PhieuThu] ([MaPhieuThu], [MaKhachHang], [MaSoNhanVien], [MaLoaiThu], [MaTinhTrang], [LyDoNop], [DienGiai], [NgayHoachToan], [NgayChungTu], [TongTienHang], [TienChietKhau], [TienThueGTGT], [TongTienThanhToan], [DaGhiSo], [ChungTuGoc], [MaLoaiTien], [TyGia], [ChungTuThamChieu], [NguoiNop]) VALUES (N'PT000019', N'KH000001', N'0001', 1, 1, N'Nộp khác', N'', CAST(N'2020-08-12' AS Date), CAST(N'2020-09-12' AS Date), 7000000, 0, 0, 7000000, 1, 2, 2, 50000, N'          ', N'Trần Văn Trường')
INSERT [dbo].[PhieuThu] ([MaPhieuThu], [MaKhachHang], [MaSoNhanVien], [MaLoaiThu], [MaTinhTrang], [LyDoNop], [DienGiai], [NgayHoachToan], [NgayChungTu], [TongTienHang], [TienChietKhau], [TienThueGTGT], [TongTienThanhToan], [DaGhiSo], [ChungTuGoc], [MaLoaiTien], [TyGia], [ChungTuThamChieu], [NguoiNop]) VALUES (N'PT000020', N'KH000001', N'0001', 1, 3, N'Nộp khác', N'', CAST(N'2020-08-12' AS Date), CAST(N'2019-07-10' AS Date), 2152756, 0, 0, 2152757, 0, 2, 2, 50001, N'          ', N'Trần Văn Trường')
INSERT [dbo].[PhieuThu] ([MaPhieuThu], [MaKhachHang], [MaSoNhanVien], [MaLoaiThu], [MaTinhTrang], [LyDoNop], [DienGiai], [NgayHoachToan], [NgayChungTu], [TongTienHang], [TienChietKhau], [TienThueGTGT], [TongTienThanhToan], [DaGhiSo], [ChungTuGoc], [MaLoaiTien], [TyGia], [ChungTuThamChieu], [NguoiNop]) VALUES (N'PT000021', N'KH000001', N'0007', 1, 3, N'Nộp khác', N'', CAST(N'2020-08-12' AS Date), CAST(N'2021-08-02' AS Date), 2152757, 0, 0, 2152757, 1, 2, 2, 50002, N'          ', N'Trần Văn Trường')
INSERT [dbo].[PhieuThu] ([MaPhieuThu], [MaKhachHang], [MaSoNhanVien], [MaLoaiThu], [MaTinhTrang], [LyDoNop], [DienGiai], [NgayHoachToan], [NgayChungTu], [TongTienHang], [TienChietKhau], [TienThueGTGT], [TongTienThanhToan], [DaGhiSo], [ChungTuGoc], [MaLoaiTien], [TyGia], [ChungTuThamChieu], [NguoiNop]) VALUES (N'PT000022', N'KH000001', N'0007', 1, 3, N'Nộp khác', N'', CAST(N'2020-08-12' AS Date), CAST(N'2020-06-17' AS Date), 234234, 0, 0, 2152757, 0, 1, 1, 50003, N'          ', N'Trần Văn Trường')
INSERT [dbo].[PhieuThu] ([MaPhieuThu], [MaKhachHang], [MaSoNhanVien], [MaLoaiThu], [MaTinhTrang], [LyDoNop], [DienGiai], [NgayHoachToan], [NgayChungTu], [TongTienHang], [TienChietKhau], [TienThueGTGT], [TongTienThanhToan], [DaGhiSo], [ChungTuGoc], [MaLoaiTien], [TyGia], [ChungTuThamChieu], [NguoiNop]) VALUES (N'PT000023', N'KH000008', N'0007', 3, 3, N'Nộp test', N'', CAST(N'2020-08-12' AS Date), CAST(N'2020-05-13' AS Date), 4000000, 0, 0, 2152757, 1, 2, 2, 22000, N'          ', N'Trần Văn Trường')
INSERT [dbo].[PhieuThu] ([MaPhieuThu], [MaKhachHang], [MaSoNhanVien], [MaLoaiThu], [MaTinhTrang], [LyDoNop], [DienGiai], [NgayHoachToan], [NgayChungTu], [TongTienHang], [TienChietKhau], [TienThueGTGT], [TongTienThanhToan], [DaGhiSo], [ChungTuGoc], [MaLoaiTien], [TyGia], [ChungTuThamChieu], [NguoiNop]) VALUES (N'PT000024', N'KH000002', N'0001', 1, 3, N'Nộp khác', N'', CAST(N'2020-08-12' AS Date), CAST(N'2020-08-06' AS Date), 2000000, 0, 0, 2152757, 0, 1, 1, 1000, N'          ', N'Trần Văn Trường')
INSERT [dbo].[PhieuXuatKho] ([MaPhieuXuat], [MaKhachHang], [NguoiNhan], [LyDoXuat], [MaSoNhanVien], [ChungTuGoc], [NgayHoachToan], [NgayChungTu], [MaDieuKhoan], [SoNgayDuocNo], [HanThanhToan], [MaLoaiTien], [TyGia], [TongTienHang], [TienThueGTGT], [TienChietKhau], [TongTienThanhToan], [MaChungTuBanHang], [MaTraLaiHangBan], [DienGiai], [DaGhiSo], [Kho]) VALUES (N'XK0002', N'KH000001', N'Nguyen A', N'Xuất kho bán hàng Công ty cổ phần, thương mại và dịch vụ Mekong', N'0001', 4, CAST(N'2020-08-19' AS Date), CAST(N'2020-08-19' AS Date), 1, 2, CAST(N'2020-08-28' AS Date), 1, 1000, 4725000, 945000, 0, 5670000, N'BH000009', N'BTL000006', N'dien giai', 1, N'1         ')
INSERT [dbo].[PhieuXuatKho] ([MaPhieuXuat], [MaKhachHang], [NguoiNhan], [LyDoXuat], [MaSoNhanVien], [ChungTuGoc], [NgayHoachToan], [NgayChungTu], [MaDieuKhoan], [SoNgayDuocNo], [HanThanhToan], [MaLoaiTien], [TyGia], [TongTienHang], [TienThueGTGT], [TienChietKhau], [TongTienThanhToan], [MaChungTuBanHang], [MaTraLaiHangBan], [DienGiai], [DaGhiSo], [Kho]) VALUES (N'XK0003', N'KH000002', N'Nguyen B', N'Xuất kho bán hàng Công ty TNHH Công Minh', N'0001', 4, CAST(N'2020-08-19' AS Date), CAST(N'2020-08-19' AS Date), 1, 2, CAST(N'2020-08-21' AS Date), 1, 1000, 5775000, 1155000, 0, 6930000, N'BH000011', N'BTL000005', N'dien giai', 0, N'2         ')
INSERT [dbo].[PhieuXuatKho] ([MaPhieuXuat], [MaKhachHang], [NguoiNhan], [LyDoXuat], [MaSoNhanVien], [ChungTuGoc], [NgayHoachToan], [NgayChungTu], [MaDieuKhoan], [SoNgayDuocNo], [HanThanhToan], [MaLoaiTien], [TyGia], [TongTienHang], [TienThueGTGT], [TienChietKhau], [TongTienThanhToan], [MaChungTuBanHang], [MaTraLaiHangBan], [DienGiai], [DaGhiSo], [Kho]) VALUES (N'XK0004', N'KH000003', N'Nguyen A', N'Xuất kho bán hàng Biện Công Nhân', N'0001', 3, CAST(N'2020-08-19' AS Date), CAST(N'2020-08-19' AS Date), 1, 5, CAST(N'2020-08-21' AS Date), 1, 1000, 5075000, 1015000, 0, 6090000, N'BH000012', N'BTL000004', N'dien giai', 1, N'2         ')
INSERT [dbo].[PhieuXuatKho] ([MaPhieuXuat], [MaKhachHang], [NguoiNhan], [LyDoXuat], [MaSoNhanVien], [ChungTuGoc], [NgayHoachToan], [NgayChungTu], [MaDieuKhoan], [SoNgayDuocNo], [HanThanhToan], [MaLoaiTien], [TyGia], [TongTienHang], [TienThueGTGT], [TienChietKhau], [TongTienThanhToan], [MaChungTuBanHang], [MaTraLaiHangBan], [DienGiai], [DaGhiSo], [Kho]) VALUES (N'XK0005', N'KH000004', N'Nguyen C', N'Xuất kho bán hàng Công ty cổ phần, thương mại và dịch vụ Mekong', N'0001', 4, CAST(N'2020-08-19' AS Date), CAST(N'2020-08-19' AS Date), 1, 4, NULL, 1, 1000, 8275000, 1905000, 0, 10180000, N'BH000013', N'BTL000003', N'dien giai', 0, N'2         ')
INSERT [dbo].[PhieuXuatKho] ([MaPhieuXuat], [MaKhachHang], [NguoiNhan], [LyDoXuat], [MaSoNhanVien], [ChungTuGoc], [NgayHoachToan], [NgayChungTu], [MaDieuKhoan], [SoNgayDuocNo], [HanThanhToan], [MaLoaiTien], [TyGia], [TongTienHang], [TienThueGTGT], [TienChietKhau], [TongTienThanhToan], [MaChungTuBanHang], [MaTraLaiHangBan], [DienGiai], [DaGhiSo], [Kho]) VALUES (N'XK0006', N'KH000005', N'Nguyen A', N'Xuất kho bán hàng Công ty cổ phần, thương mại và dịch vụ Mekong', N'0003', 4, CAST(N'2020-08-19' AS Date), CAST(N'2020-08-19' AS Date), 2, 2, CAST(N'2020-08-21' AS Date), 2, 23175, 4200000, 840000, 0, 5040000, N'BH000014', N'BTL000002', N'dien giai', 1, N'2         ')
INSERT [dbo].[PhieuXuatKho] ([MaPhieuXuat], [MaKhachHang], [NguoiNhan], [LyDoXuat], [MaSoNhanVien], [ChungTuGoc], [NgayHoachToan], [NgayChungTu], [MaDieuKhoan], [SoNgayDuocNo], [HanThanhToan], [MaLoaiTien], [TyGia], [TongTienHang], [TienThueGTGT], [TienChietKhau], [TongTienThanhToan], [MaChungTuBanHang], [MaTraLaiHangBan], [DienGiai], [DaGhiSo], [Kho]) VALUES (N'XK0007', N'KH000006', N'Nguyen C', N'Xuất kho bán hàng Công ty cổ phần, thương mại và dịch vụ Mekong', N'0001', 2, CAST(N'2020-08-19' AS Date), CAST(N'2020-08-19' AS Date), 1, 2, CAST(N'2020-08-21' AS Date), 2, 23175, 3750000, 1125000, 0, 4875000, N'BH000015', N'BTL000001', N'dien giai', 1, N'2         ')
INSERT [dbo].[PhieuXuatKho] ([MaPhieuXuat], [MaKhachHang], [NguoiNhan], [LyDoXuat], [MaSoNhanVien], [ChungTuGoc], [NgayHoachToan], [NgayChungTu], [MaDieuKhoan], [SoNgayDuocNo], [HanThanhToan], [MaLoaiTien], [TyGia], [TongTienHang], [TienThueGTGT], [TienChietKhau], [TongTienThanhToan], [MaChungTuBanHang], [MaTraLaiHangBan], [DienGiai], [DaGhiSo], [Kho]) VALUES (N'XK0009', N'KH000012', N'Nguyen D', N'Xuất kho bán hàng Đỗ Nguyệt Quế', N'0007', 3, CAST(N'2020-08-19' AS Date), CAST(N'2020-08-19' AS Date), 2, 2, CAST(N'2020-08-28' AS Date), 1, 1000, 28950000, 6165000, 0, 35115000, N'BH000017', N'BTL000001', N'dien giai', 0, N'2         ')
INSERT [dbo].[PhieuXuatKho] ([MaPhieuXuat], [MaKhachHang], [NguoiNhan], [LyDoXuat], [MaSoNhanVien], [ChungTuGoc], [NgayHoachToan], [NgayChungTu], [MaDieuKhoan], [SoNgayDuocNo], [HanThanhToan], [MaLoaiTien], [TyGia], [TongTienHang], [TienThueGTGT], [TienChietKhau], [TongTienThanhToan], [MaChungTuBanHang], [MaTraLaiHangBan], [DienGiai], [DaGhiSo], [Kho]) VALUES (N'XK0010', N'KH000002', N'Nguyen A', N'Xuất kho bán hàng Công ty TNHH Công Minh', N'0002', 4, CAST(N'2020-08-19' AS Date), CAST(N'2020-08-19' AS Date), 1, 12, CAST(N'2020-08-29' AS Date), 1, 1000, 4000000, 1200000, 0, 5200000, N'BH000019', N'BTL000002', N'dien giai', 0, N'1         ')
INSERT [dbo].[PhieuXuatKho] ([MaPhieuXuat], [MaKhachHang], [NguoiNhan], [LyDoXuat], [MaSoNhanVien], [ChungTuGoc], [NgayHoachToan], [NgayChungTu], [MaDieuKhoan], [SoNgayDuocNo], [HanThanhToan], [MaLoaiTien], [TyGia], [TongTienHang], [TienThueGTGT], [TienChietKhau], [TongTienThanhToan], [MaChungTuBanHang], [MaTraLaiHangBan], [DienGiai], [DaGhiSo], [Kho]) VALUES (N'XK0011', N'KH000001', N'Nguyen E', N'Xuất kho bán hàng Công ty cổ phần, thương mại và dịch vụ Mekong', N'0001', 242, CAST(N'2020-08-19' AS Date), CAST(N'2020-08-19' AS Date), 2, 4, CAST(N'2020-08-20' AS Date), 1, NULL, 477275000, 123530000, 0, 600805000, N'BH000025', N'BTL000003', N'dien giai', 0, N'2         ')
INSERT [dbo].[PhieuXuatKho] ([MaPhieuXuat], [MaKhachHang], [NguoiNhan], [LyDoXuat], [MaSoNhanVien], [ChungTuGoc], [NgayHoachToan], [NgayChungTu], [MaDieuKhoan], [SoNgayDuocNo], [HanThanhToan], [MaLoaiTien], [TyGia], [TongTienHang], [TienThueGTGT], [TienChietKhau], [TongTienThanhToan], [MaChungTuBanHang], [MaTraLaiHangBan], [DienGiai], [DaGhiSo], [Kho]) VALUES (N'XK0012', N'KH000002', N'Nguyen A', N'Xuất kho bán hàng Công ty cổ phần, thương mại và dịch vụ Mekong', N'0001', 2, CAST(N'2020-08-20' AS Date), CAST(N'2020-08-20' AS Date), 1, 2, CAST(N'2020-08-29' AS Date), 1, 1000, 8700000, 2015000, 0, 10715000, N'BH000027', N'BTL000004', N'dien giai', 0, N'2         ')
INSERT [dbo].[PhieuXuatKho] ([MaPhieuXuat], [MaKhachHang], [NguoiNhan], [LyDoXuat], [MaSoNhanVien], [ChungTuGoc], [NgayHoachToan], [NgayChungTu], [MaDieuKhoan], [SoNgayDuocNo], [HanThanhToan], [MaLoaiTien], [TyGia], [TongTienHang], [TienThueGTGT], [TienChietKhau], [TongTienThanhToan], [MaChungTuBanHang], [MaTraLaiHangBan], [DienGiai], [DaGhiSo], [Kho]) VALUES (N'XK0013', N'KH000001', N'Nguyen G', N'Xuất kho bán hàng Công ty cổ phần, thương mại và dịch vụ Mekong', NULL, 2, CAST(N'2020-08-20' AS Date), CAST(N'2020-08-20' AS Date), 1, 1, NULL, 1, 1000, 13725000, 3120000, 2, 16845000, N'BH000027', N'BTL000005', N'dien giai', 1, N'2         ')
INSERT [dbo].[PhieuXuatKho] ([MaPhieuXuat], [MaKhachHang], [NguoiNhan], [LyDoXuat], [MaSoNhanVien], [ChungTuGoc], [NgayHoachToan], [NgayChungTu], [MaDieuKhoan], [SoNgayDuocNo], [HanThanhToan], [MaLoaiTien], [TyGia], [TongTienHang], [TienThueGTGT], [TienChietKhau], [TongTienThanhToan], [MaChungTuBanHang], [MaTraLaiHangBan], [DienGiai], [DaGhiSo], [Kho]) VALUES (N'XK0014', N'KH000001', N'Nguyen G', N'Xuất kho bán hàng Công ty cổ phần, thương mại và dịch vụ Mekong', NULL, 7, CAST(N'2020-08-20' AS Date), CAST(N'2020-08-20' AS Date), 1, 1, NULL, 1, 1000, 13725000, 3120000, 2, 16845000, N'BH000027', N'BTL000006', N'dien giai', 1, N'2         ')
SET IDENTITY_INSERT [dbo].[QuanLyCongTac] ON 

INSERT [dbo].[QuanLyCongTac] ([ID], [MaSoNhanVien], [GioBatDau], [NgayBatDau], [GioKetThuc], [NgayKetThuc], [TongGio], [TongNgayLamViec], [TongNgay], [DiaDiem], [NoiDung]) VALUES (1, N'0001', N'7:00', CAST(N'2020-08-03' AS Date), N'10:00', CAST(N'2020-08-05' AS Date), 9, 3, 3, N'Tp.HCM', N'Họp')
INSERT [dbo].[QuanLyCongTac] ([ID], [MaSoNhanVien], [GioBatDau], [NgayBatDau], [GioKetThuc], [NgayKetThuc], [TongGio], [TongNgayLamViec], [TongNgay], [DiaDiem], [NoiDung]) VALUES (3, N'0003', N'7:00', CAST(N'2020-08-03' AS Date), N'10:00', CAST(N'2020-08-05' AS Date), 9, 3, 3, N'Rạch Giá', N'Họp')
INSERT [dbo].[QuanLyCongTac] ([ID], [MaSoNhanVien], [GioBatDau], [NgayBatDau], [GioKetThuc], [NgayKetThuc], [TongGio], [TongNgayLamViec], [TongNgay], [DiaDiem], [NoiDung]) VALUES (4, N'0007', N'7:00', CAST(N'2020-08-03' AS Date), N'10:00', CAST(N'2020-08-05' AS Date), 9, 3, 3, N'Hà Nội', N'Họp')
INSERT [dbo].[QuanLyCongTac] ([ID], [MaSoNhanVien], [GioBatDau], [NgayBatDau], [GioKetThuc], [NgayKetThuc], [TongGio], [TongNgayLamViec], [TongNgay], [DiaDiem], [NoiDung]) VALUES (5, N'0003', N'7:00', CAST(N'2020-08-03' AS Date), N'10:00', CAST(N'2020-08-05' AS Date), 9, 3, 3, N'Rạch Giá', N'Họp')
INSERT [dbo].[QuanLyCongTac] ([ID], [MaSoNhanVien], [GioBatDau], [NgayBatDau], [GioKetThuc], [NgayKetThuc], [TongGio], [TongNgayLamViec], [TongNgay], [DiaDiem], [NoiDung]) VALUES (6, N'0002', N'7:00', CAST(N'2020-08-03' AS Date), N'10:00', CAST(N'2020-08-05' AS Date), 9, 3, 3, N'Tp.HCM', N'Họp')
INSERT [dbo].[QuanLyCongTac] ([ID], [MaSoNhanVien], [GioBatDau], [NgayBatDau], [GioKetThuc], [NgayKetThuc], [TongGio], [TongNgayLamViec], [TongNgay], [DiaDiem], [NoiDung]) VALUES (7, N'0001', N'7:00', CAST(N'2020-08-03' AS Date), N'10:00', CAST(N'2020-08-05' AS Date), 9, 3, 3, N'Tp.HCM', N'Họp')
INSERT [dbo].[QuanLyCongTac] ([ID], [MaSoNhanVien], [GioBatDau], [NgayBatDau], [GioKetThuc], [NgayKetThuc], [TongGio], [TongNgayLamViec], [TongNgay], [DiaDiem], [NoiDung]) VALUES (8, N'0003', N'7:00', CAST(N'2020-08-02' AS Date), N'10:00', CAST(N'2020-08-05' AS Date), 9, 3, 3, N'Tp.HCM', N'Họp')
INSERT [dbo].[QuanLyCongTac] ([ID], [MaSoNhanVien], [GioBatDau], [NgayBatDau], [GioKetThuc], [NgayKetThuc], [TongGio], [TongNgayLamViec], [TongNgay], [DiaDiem], [NoiDung]) VALUES (9, N'0003', N'7:00', CAST(N'2020-08-02' AS Date), N'10:00', CAST(N'2020-08-05' AS Date), 9, 3, 3, N'Rạch Giá', N'Họp')
INSERT [dbo].[QuanLyCongTac] ([ID], [MaSoNhanVien], [GioBatDau], [NgayBatDau], [GioKetThuc], [NgayKetThuc], [TongGio], [TongNgayLamViec], [TongNgay], [DiaDiem], [NoiDung]) VALUES (10, N'0007', N'7:00', CAST(N'2020-08-02' AS Date), N'10:00', CAST(N'2020-08-05' AS Date), 9, 3, 3, N'Hà Nội', N'Họp')
INSERT [dbo].[QuanLyCongTac] ([ID], [MaSoNhanVien], [GioBatDau], [NgayBatDau], [GioKetThuc], [NgayKetThuc], [TongGio], [TongNgayLamViec], [TongNgay], [DiaDiem], [NoiDung]) VALUES (11, N'0001', N'7:00', CAST(N'2020-08-02' AS Date), N'10:00', CAST(N'2020-08-05' AS Date), 9, 3, 3, N'Rạch Giá', N'Họp')
INSERT [dbo].[QuanLyCongTac] ([ID], [MaSoNhanVien], [GioBatDau], [NgayBatDau], [GioKetThuc], [NgayKetThuc], [TongGio], [TongNgayLamViec], [TongNgay], [DiaDiem], [NoiDung]) VALUES (12, N'0002', N'7:00', CAST(N'2020-08-02' AS Date), N'10:00', CAST(N'2020-08-05' AS Date), 9, 3, 3, N'Tp.HCM', N'Họp')
INSERT [dbo].[QuanLyCongTac] ([ID], [MaSoNhanVien], [GioBatDau], [NgayBatDau], [GioKetThuc], [NgayKetThuc], [TongGio], [TongNgayLamViec], [TongNgay], [DiaDiem], [NoiDung]) VALUES (13, N'0003', N'7:00', CAST(N'2020-07-25' AS Date), N'10:00', CAST(N'2020-08-05' AS Date), 9, 3, 3, N'Tp.HCM', N'Họp')
INSERT [dbo].[QuanLyCongTac] ([ID], [MaSoNhanVien], [GioBatDau], [NgayBatDau], [GioKetThuc], [NgayKetThuc], [TongGio], [TongNgayLamViec], [TongNgay], [DiaDiem], [NoiDung]) VALUES (14, N'0003', N'7:00', CAST(N'2020-07-25' AS Date), N'10:00', CAST(N'2020-08-05' AS Date), 9, 3, 3, N'Tp.HCM', N'Họp')
INSERT [dbo].[QuanLyCongTac] ([ID], [MaSoNhanVien], [GioBatDau], [NgayBatDau], [GioKetThuc], [NgayKetThuc], [TongGio], [TongNgayLamViec], [TongNgay], [DiaDiem], [NoiDung]) VALUES (15, N'0003', N'7:00', CAST(N'2020-07-25' AS Date), N'10:00', CAST(N'2020-08-05' AS Date), 9, 3, 3, N'Rạch Giá', N'Họp')
INSERT [dbo].[QuanLyCongTac] ([ID], [MaSoNhanVien], [GioBatDau], [NgayBatDau], [GioKetThuc], [NgayKetThuc], [TongGio], [TongNgayLamViec], [TongNgay], [DiaDiem], [NoiDung]) VALUES (16, N'0003', N'7:00', CAST(N'2020-07-25' AS Date), N'10:00', CAST(N'2020-08-05' AS Date), 9, 3, 3, N'Hà Nội', N'Họp')
INSERT [dbo].[QuanLyCongTac] ([ID], [MaSoNhanVien], [GioBatDau], [NgayBatDau], [GioKetThuc], [NgayKetThuc], [TongGio], [TongNgayLamViec], [TongNgay], [DiaDiem], [NoiDung]) VALUES (17, N'0003', N'7:00', CAST(N'2020-07-25' AS Date), N'10:00', CAST(N'2020-08-05' AS Date), 9, 3, 3, N'Rạch Giá', N'Họp')
INSERT [dbo].[QuanLyCongTac] ([ID], [MaSoNhanVien], [GioBatDau], [NgayBatDau], [GioKetThuc], [NgayKetThuc], [TongGio], [TongNgayLamViec], [TongNgay], [DiaDiem], [NoiDung]) VALUES (18, N'0003', N'7:00', CAST(N'2020-07-25' AS Date), N'10:00', CAST(N'2020-08-05' AS Date), 9, 3, 3, N'Tp.HCM', N'Họp')
INSERT [dbo].[QuanLyCongTac] ([ID], [MaSoNhanVien], [GioBatDau], [NgayBatDau], [GioKetThuc], [NgayKetThuc], [TongGio], [TongNgayLamViec], [TongNgay], [DiaDiem], [NoiDung]) VALUES (19, N'0001', N'7:00', CAST(N'2020-06-13' AS Date), N'10:00', CAST(N'2020-08-05' AS Date), 9, 3, 3, N'Tp.HCM', N'Họp')
INSERT [dbo].[QuanLyCongTac] ([ID], [MaSoNhanVien], [GioBatDau], [NgayBatDau], [GioKetThuc], [NgayKetThuc], [TongGio], [TongNgayLamViec], [TongNgay], [DiaDiem], [NoiDung]) VALUES (20, N'0006', N'7:00', CAST(N'2020-08-03' AS Date), N'10:00', CAST(N'2020-08-05' AS Date), 9, 3, 3, N'Tp.HCM', N'Họp')
INSERT [dbo].[QuanLyCongTac] ([ID], [MaSoNhanVien], [GioBatDau], [NgayBatDau], [GioKetThuc], [NgayKetThuc], [TongGio], [TongNgayLamViec], [TongNgay], [DiaDiem], [NoiDung]) VALUES (21, N'0006', N'7:00', CAST(N'2020-06-13' AS Date), N'10:00', CAST(N'2020-08-05' AS Date), 9, 3, 3, N'Tp.HCM', N'Họp')
INSERT [dbo].[QuanLyCongTac] ([ID], [MaSoNhanVien], [GioBatDau], [NgayBatDau], [GioKetThuc], [NgayKetThuc], [TongGio], [TongNgayLamViec], [TongNgay], [DiaDiem], [NoiDung]) VALUES (22, N'0006', N'7:00', CAST(N'2020-06-13' AS Date), N'10:00', CAST(N'2020-08-05' AS Date), 9, 3, 3, N'Rạch Giá', N'Họp')
INSERT [dbo].[QuanLyCongTac] ([ID], [MaSoNhanVien], [GioBatDau], [NgayBatDau], [GioKetThuc], [NgayKetThuc], [TongGio], [TongNgayLamViec], [TongNgay], [DiaDiem], [NoiDung]) VALUES (23, N'0004', N'7:00', CAST(N'2020-07-25' AS Date), N'10:00', CAST(N'2020-08-05' AS Date), 9, 3, 3, N'Hà Nội', N'Họp')
INSERT [dbo].[QuanLyCongTac] ([ID], [MaSoNhanVien], [GioBatDau], [NgayBatDau], [GioKetThuc], [NgayKetThuc], [TongGio], [TongNgayLamViec], [TongNgay], [DiaDiem], [NoiDung]) VALUES (24, N'0006', N'7:00', CAST(N'2020-08-03' AS Date), N'10:00', CAST(N'2020-08-05' AS Date), 9, 3, 3, N'Rạch Giá', N'Họp')
INSERT [dbo].[QuanLyCongTac] ([ID], [MaSoNhanVien], [GioBatDau], [NgayBatDau], [GioKetThuc], [NgayKetThuc], [TongGio], [TongNgayLamViec], [TongNgay], [DiaDiem], [NoiDung]) VALUES (25, N'0006', N'7:00', CAST(N'2020-06-13' AS Date), N'10:00', CAST(N'2020-08-05' AS Date), 9, 3, 3, N'Tp.HCM', N'Họp')
INSERT [dbo].[QuanLyCongTac] ([ID], [MaSoNhanVien], [GioBatDau], [NgayBatDau], [GioKetThuc], [NgayKetThuc], [TongGio], [TongNgayLamViec], [TongNgay], [DiaDiem], [NoiDung]) VALUES (26, N'0006', N'7:00', CAST(N'2020-06-13' AS Date), N'10:00', CAST(N'2020-08-05' AS Date), 9, 3, 3, N'Tp.HCM', N'Họp')
SET IDENTITY_INSERT [dbo].[QuanLyCongTac] OFF
SET IDENTITY_INSERT [dbo].[QuanLyNgayNghi] ON 

INSERT [dbo].[QuanLyNgayNghi] ([ID], [MaSoNhanVien], [GioBatDau], [NgayBatDau], [GioKetThuc], [NgayKetThuc], [LoaiNghi], [TongGio], [TongNgayLamViecNghi], [TongNgayNghi]) VALUES (1, N'0001', N'07:30', CAST(N'2020-08-03' AS Date), N'17:30', CAST(N'2020-08-05' AS Date), N'Có phép', 8, 1, 1)
INSERT [dbo].[QuanLyNgayNghi] ([ID], [MaSoNhanVien], [GioBatDau], [NgayBatDau], [GioKetThuc], [NgayKetThuc], [LoaiNghi], [TongGio], [TongNgayLamViecNghi], [TongNgayNghi]) VALUES (2, N'0001', N'07:30', CAST(N'2020-08-02' AS Date), N'17:30', CAST(N'2020-08-05' AS Date), N'Có phép', 8, 1, 1)
INSERT [dbo].[QuanLyNgayNghi] ([ID], [MaSoNhanVien], [GioBatDau], [NgayBatDau], [GioKetThuc], [NgayKetThuc], [LoaiNghi], [TongGio], [TongNgayLamViecNghi], [TongNgayNghi]) VALUES (3, N'0001', N'07:30', CAST(N'2020-08-02' AS Date), N'17:30', CAST(N'2020-08-05' AS Date), N'Có phép', 8, 1, 1)
INSERT [dbo].[QuanLyNgayNghi] ([ID], [MaSoNhanVien], [GioBatDau], [NgayBatDau], [GioKetThuc], [NgayKetThuc], [LoaiNghi], [TongGio], [TongNgayLamViecNghi], [TongNgayNghi]) VALUES (4, N'0002', N'07:30', CAST(N'2020-08-01' AS Date), N'17:30', CAST(N'2020-08-05' AS Date), N'Có phép', 8, 1, 1)
INSERT [dbo].[QuanLyNgayNghi] ([ID], [MaSoNhanVien], [GioBatDau], [NgayBatDau], [GioKetThuc], [NgayKetThuc], [LoaiNghi], [TongGio], [TongNgayLamViecNghi], [TongNgayNghi]) VALUES (5, N'0002', N'07:30', CAST(N'2020-08-01' AS Date), N'17:30', CAST(N'2020-08-05' AS Date), N'Có phép', 8, 1, 1)
INSERT [dbo].[QuanLyNgayNghi] ([ID], [MaSoNhanVien], [GioBatDau], [NgayBatDau], [GioKetThuc], [NgayKetThuc], [LoaiNghi], [TongGio], [TongNgayLamViecNghi], [TongNgayNghi]) VALUES (6, N'0002', N'07:30', CAST(N'2020-08-03' AS Date), N'17:30', CAST(N'2020-08-05' AS Date), N'Có phép', 8, 1, 1)
INSERT [dbo].[QuanLyNgayNghi] ([ID], [MaSoNhanVien], [GioBatDau], [NgayBatDau], [GioKetThuc], [NgayKetThuc], [LoaiNghi], [TongGio], [TongNgayLamViecNghi], [TongNgayNghi]) VALUES (7, N'0002', N'07:30', CAST(N'2020-08-02' AS Date), N'17:30', CAST(N'2020-08-05' AS Date), N'Có phép', 8, 1, 1)
INSERT [dbo].[QuanLyNgayNghi] ([ID], [MaSoNhanVien], [GioBatDau], [NgayBatDau], [GioKetThuc], [NgayKetThuc], [LoaiNghi], [TongGio], [TongNgayLamViecNghi], [TongNgayNghi]) VALUES (8, N'0002', N'07:30', CAST(N'2020-08-03' AS Date), N'17:30', CAST(N'2020-08-05' AS Date), N'Có phép', 8, 1, 1)
INSERT [dbo].[QuanLyNgayNghi] ([ID], [MaSoNhanVien], [GioBatDau], [NgayBatDau], [GioKetThuc], [NgayKetThuc], [LoaiNghi], [TongGio], [TongNgayLamViecNghi], [TongNgayNghi]) VALUES (9, N'0003', N'07:30', CAST(N'2020-07-25' AS Date), N'17:30', CAST(N'2020-08-05' AS Date), N'Có phép', 8, 1, 1)
INSERT [dbo].[QuanLyNgayNghi] ([ID], [MaSoNhanVien], [GioBatDau], [NgayBatDau], [GioKetThuc], [NgayKetThuc], [LoaiNghi], [TongGio], [TongNgayLamViecNghi], [TongNgayNghi]) VALUES (10, N'0003', N'07:30', CAST(N'2020-07-26' AS Date), N'17:30', CAST(N'2020-08-05' AS Date), N'Có phép', 8, 1, 1)
INSERT [dbo].[QuanLyNgayNghi] ([ID], [MaSoNhanVien], [GioBatDau], [NgayBatDau], [GioKetThuc], [NgayKetThuc], [LoaiNghi], [TongGio], [TongNgayLamViecNghi], [TongNgayNghi]) VALUES (11, N'0003', N'07:30', CAST(N'2020-07-25' AS Date), N'17:30', CAST(N'2020-08-05' AS Date), N'Có phép', 8, 1, 1)
INSERT [dbo].[QuanLyNgayNghi] ([ID], [MaSoNhanVien], [GioBatDau], [NgayBatDau], [GioKetThuc], [NgayKetThuc], [LoaiNghi], [TongGio], [TongNgayLamViecNghi], [TongNgayNghi]) VALUES (12, N'0003', N'07:30', CAST(N'2020-07-25' AS Date), N'17:30', CAST(N'2020-08-05' AS Date), N'Có phép', 8, 1, 1)
INSERT [dbo].[QuanLyNgayNghi] ([ID], [MaSoNhanVien], [GioBatDau], [NgayBatDau], [GioKetThuc], [NgayKetThuc], [LoaiNghi], [TongGio], [TongNgayLamViecNghi], [TongNgayNghi]) VALUES (13, N'0005', N'07:30', CAST(N'2020-07-25' AS Date), N'17:30', CAST(N'2020-08-05' AS Date), N'Có phép', 8, 1, 1)
INSERT [dbo].[QuanLyNgayNghi] ([ID], [MaSoNhanVien], [GioBatDau], [NgayBatDau], [GioKetThuc], [NgayKetThuc], [LoaiNghi], [TongGio], [TongNgayLamViecNghi], [TongNgayNghi]) VALUES (14, N'0006', N'07:30', CAST(N'2020-07-25' AS Date), N'17:30', CAST(N'2020-08-05' AS Date), N'Có phép', 8, 1, 1)
INSERT [dbo].[QuanLyNgayNghi] ([ID], [MaSoNhanVien], [GioBatDau], [NgayBatDau], [GioKetThuc], [NgayKetThuc], [LoaiNghi], [TongGio], [TongNgayLamViecNghi], [TongNgayNghi]) VALUES (15, N'0007', N'07:30', CAST(N'2020-07-25' AS Date), N'17:30', CAST(N'2020-08-05' AS Date), N'Có phép', 8, 1, 1)
INSERT [dbo].[QuanLyNgayNghi] ([ID], [MaSoNhanVien], [GioBatDau], [NgayBatDau], [GioKetThuc], [NgayKetThuc], [LoaiNghi], [TongGio], [TongNgayLamViecNghi], [TongNgayNghi]) VALUES (16, N'0004', N'07:30', CAST(N'2020-07-25' AS Date), N'17:30', CAST(N'2020-08-05' AS Date), N'Có phép', 8, 1, 1)
INSERT [dbo].[QuanLyNgayNghi] ([ID], [MaSoNhanVien], [GioBatDau], [NgayBatDau], [GioKetThuc], [NgayKetThuc], [LoaiNghi], [TongGio], [TongNgayLamViecNghi], [TongNgayNghi]) VALUES (17, N'0001', N'07:30', CAST(N'2020-07-25' AS Date), N'17:30', CAST(N'2020-08-05' AS Date), N'Có phép', 8, 1, 1)
INSERT [dbo].[QuanLyNgayNghi] ([ID], [MaSoNhanVien], [GioBatDau], [NgayBatDau], [GioKetThuc], [NgayKetThuc], [LoaiNghi], [TongGio], [TongNgayLamViecNghi], [TongNgayNghi]) VALUES (18, N'0001', N'07:30', CAST(N'2020-06-25' AS Date), N'17:30', CAST(N'2020-08-05' AS Date), N'Có phép', 8, 1, 1)
INSERT [dbo].[QuanLyNgayNghi] ([ID], [MaSoNhanVien], [GioBatDau], [NgayBatDau], [GioKetThuc], [NgayKetThuc], [LoaiNghi], [TongGio], [TongNgayLamViecNghi], [TongNgayNghi]) VALUES (19, N'0003', N'07:30', CAST(N'2020-06-25' AS Date), N'17:30', CAST(N'2020-08-05' AS Date), N'Có phép', 8, 1, 1)
INSERT [dbo].[QuanLyNgayNghi] ([ID], [MaSoNhanVien], [GioBatDau], [NgayBatDau], [GioKetThuc], [NgayKetThuc], [LoaiNghi], [TongGio], [TongNgayLamViecNghi], [TongNgayNghi]) VALUES (20, N'0002', N'07:30', CAST(N'2020-06-25' AS Date), N'17:30', CAST(N'2020-08-05' AS Date), N'Có phép', 8, 1, 1)
INSERT [dbo].[QuanLyNgayNghi] ([ID], [MaSoNhanVien], [GioBatDau], [NgayBatDau], [GioKetThuc], [NgayKetThuc], [LoaiNghi], [TongGio], [TongNgayLamViecNghi], [TongNgayNghi]) VALUES (21, N'0002', N'07:30', CAST(N'2020-06-25' AS Date), N'17:30', CAST(N'2020-08-05' AS Date), N'Có phép', 8, 1, 1)
SET IDENTITY_INSERT [dbo].[QuanLyNgayNghi] OFF
SET IDENTITY_INSERT [dbo].[QuanLyQuaGio] ON 

INSERT [dbo].[QuanLyQuaGio] ([ID], [MaSoNhanVien], [SoGio], [PhanLoai]) VALUES (1, N'0001', 1, NULL)
SET IDENTITY_INSERT [dbo].[QuanLyQuaGio] OFF
SET IDENTITY_INSERT [dbo].[QuanLyTaiSan] ON 

INSERT [dbo].[QuanLyTaiSan] ([ID], [MaSoNhanVien], [MaTaiSan]) VALUES (35, N'0002', N'000001')
INSERT [dbo].[QuanLyTaiSan] ([ID], [MaSoNhanVien], [MaTaiSan]) VALUES (36, N'0003', N'000002')
INSERT [dbo].[QuanLyTaiSan] ([ID], [MaSoNhanVien], [MaTaiSan]) VALUES (37, N'0004', N'000003')
INSERT [dbo].[QuanLyTaiSan] ([ID], [MaSoNhanVien], [MaTaiSan]) VALUES (38, N'0003', N'000004')
INSERT [dbo].[QuanLyTaiSan] ([ID], [MaSoNhanVien], [MaTaiSan]) VALUES (39, N'0007', N'000005')
INSERT [dbo].[QuanLyTaiSan] ([ID], [MaSoNhanVien], [MaTaiSan]) VALUES (40, N'0008', N'000006')
INSERT [dbo].[QuanLyTaiSan] ([ID], [MaSoNhanVien], [MaTaiSan]) VALUES (41, N'0009', N'000007')
INSERT [dbo].[QuanLyTaiSan] ([ID], [MaSoNhanVien], [MaTaiSan]) VALUES (42, N'0010', N'000008')
INSERT [dbo].[QuanLyTaiSan] ([ID], [MaSoNhanVien], [MaTaiSan]) VALUES (43, N'0002', N'000009')
INSERT [dbo].[QuanLyTaiSan] ([ID], [MaSoNhanVien], [MaTaiSan]) VALUES (53, N'0003', N'000010')
INSERT [dbo].[QuanLyTaiSan] ([ID], [MaSoNhanVien], [MaTaiSan]) VALUES (54, N'0002', N'000011')
INSERT [dbo].[QuanLyTaiSan] ([ID], [MaSoNhanVien], [MaTaiSan]) VALUES (55, N'0002', N'000012')
SET IDENTITY_INSERT [dbo].[QuanLyTaiSan] OFF
SET IDENTITY_INSERT [dbo].[QuanLyVangMat] ON 

INSERT [dbo].[QuanLyVangMat] ([ID], [MaSoNhanVien], [NgayVangMat], [GioVao], [GioRa], [TrangThai]) VALUES (176, N'0007', CAST(N'2020-06-15' AS Date), NULL, NULL, NULL)
INSERT [dbo].[QuanLyVangMat] ([ID], [MaSoNhanVien], [NgayVangMat], [GioVao], [GioRa], [TrangThai]) VALUES (177, N'0005', CAST(N'2020-06-15' AS Date), NULL, NULL, NULL)
INSERT [dbo].[QuanLyVangMat] ([ID], [MaSoNhanVien], [NgayVangMat], [GioVao], [GioRa], [TrangThai]) VALUES (178, N'0009', CAST(N'2020-06-15' AS Date), NULL, NULL, NULL)
INSERT [dbo].[QuanLyVangMat] ([ID], [MaSoNhanVien], [NgayVangMat], [GioVao], [GioRa], [TrangThai]) VALUES (182, N'0008', CAST(N'2020-07-31' AS Date), NULL, NULL, NULL)
INSERT [dbo].[QuanLyVangMat] ([ID], [MaSoNhanVien], [NgayVangMat], [GioVao], [GioRa], [TrangThai]) VALUES (183, N'0009', CAST(N'2020-07-31' AS Date), NULL, NULL, NULL)
INSERT [dbo].[QuanLyVangMat] ([ID], [MaSoNhanVien], [NgayVangMat], [GioVao], [GioRa], [TrangThai]) VALUES (184, N'0010', CAST(N'2020-07-31' AS Date), NULL, NULL, NULL)
INSERT [dbo].[QuanLyVangMat] ([ID], [MaSoNhanVien], [NgayVangMat], [GioVao], [GioRa], [TrangThai]) VALUES (185, N'0002', CAST(N'2020-06-15' AS Date), NULL, NULL, NULL)
INSERT [dbo].[QuanLyVangMat] ([ID], [MaSoNhanVien], [NgayVangMat], [GioVao], [GioRa], [TrangThai]) VALUES (186, N'0001', CAST(N'2020-07-03' AS Date), NULL, NULL, NULL)
INSERT [dbo].[QuanLyVangMat] ([ID], [MaSoNhanVien], [NgayVangMat], [GioVao], [GioRa], [TrangThai]) VALUES (187, N'0003', CAST(N'2020-07-31' AS Date), NULL, NULL, NULL)
INSERT [dbo].[QuanLyVangMat] ([ID], [MaSoNhanVien], [NgayVangMat], [GioVao], [GioRa], [TrangThai]) VALUES (188, N'0001', CAST(N'2020-07-31' AS Date), NULL, NULL, NULL)
INSERT [dbo].[QuanLyVangMat] ([ID], [MaSoNhanVien], [NgayVangMat], [GioVao], [GioRa], [TrangThai]) VALUES (189, N'0001', CAST(N'2020-07-30' AS Date), NULL, NULL, NULL)
INSERT [dbo].[QuanLyVangMat] ([ID], [MaSoNhanVien], [NgayVangMat], [GioVao], [GioRa], [TrangThai]) VALUES (190, N'0007', CAST(N'2020-08-03' AS Date), NULL, NULL, NULL)
INSERT [dbo].[QuanLyVangMat] ([ID], [MaSoNhanVien], [NgayVangMat], [GioVao], [GioRa], [TrangThai]) VALUES (191, N'0006', CAST(N'2020-07-03' AS Date), NULL, NULL, NULL)
INSERT [dbo].[QuanLyVangMat] ([ID], [MaSoNhanVien], [NgayVangMat], [GioVao], [GioRa], [TrangThai]) VALUES (192, N'0005', CAST(N'2020-08-03' AS Date), NULL, NULL, NULL)
INSERT [dbo].[QuanLyVangMat] ([ID], [MaSoNhanVien], [NgayVangMat], [GioVao], [GioRa], [TrangThai]) VALUES (193, N'0008', CAST(N'2020-07-03' AS Date), NULL, NULL, NULL)
INSERT [dbo].[QuanLyVangMat] ([ID], [MaSoNhanVien], [NgayVangMat], [GioVao], [GioRa], [TrangThai]) VALUES (194, N'0010', CAST(N'2020-07-03' AS Date), NULL, NULL, NULL)
INSERT [dbo].[QuanLyVangMat] ([ID], [MaSoNhanVien], [NgayVangMat], [GioVao], [GioRa], [TrangThai]) VALUES (195, N'0009', CAST(N'2020-08-03' AS Date), NULL, NULL, NULL)
INSERT [dbo].[QuanLyVangMat] ([ID], [MaSoNhanVien], [NgayVangMat], [GioVao], [GioRa], [TrangThai]) VALUES (196, N'0005', CAST(N'2020-08-05' AS Date), NULL, NULL, NULL)
INSERT [dbo].[QuanLyVangMat] ([ID], [MaSoNhanVien], [NgayVangMat], [GioVao], [GioRa], [TrangThai]) VALUES (197, N'0005', CAST(N'2020-08-05' AS Date), NULL, NULL, NULL)
INSERT [dbo].[QuanLyVangMat] ([ID], [MaSoNhanVien], [NgayVangMat], [GioVao], [GioRa], [TrangThai]) VALUES (198, N'0005', CAST(N'2020-08-02' AS Date), NULL, NULL, NULL)
INSERT [dbo].[QuanLyVangMat] ([ID], [MaSoNhanVien], [NgayVangMat], [GioVao], [GioRa], [TrangThai]) VALUES (199, N'0005', CAST(N'2020-08-01' AS Date), NULL, NULL, NULL)
INSERT [dbo].[QuanLyVangMat] ([ID], [MaSoNhanVien], [NgayVangMat], [GioVao], [GioRa], [TrangThai]) VALUES (201, N'0005', CAST(N'2020-08-01' AS Date), NULL, NULL, NULL)
INSERT [dbo].[QuanLyVangMat] ([ID], [MaSoNhanVien], [NgayVangMat], [GioVao], [GioRa], [TrangThai]) VALUES (202, N'0005', CAST(N'2020-06-15' AS Date), NULL, NULL, NULL)
INSERT [dbo].[QuanLyVangMat] ([ID], [MaSoNhanVien], [NgayVangMat], [GioVao], [GioRa], [TrangThai]) VALUES (203, N'0009', CAST(N'2020-08-04' AS Date), NULL, NULL, NULL)
INSERT [dbo].[QuanLyVangMat] ([ID], [MaSoNhanVien], [NgayVangMat], [GioVao], [GioRa], [TrangThai]) VALUES (204, N'0005', CAST(N'2020-08-05' AS Date), NULL, NULL, NULL)
INSERT [dbo].[QuanLyVangMat] ([ID], [MaSoNhanVien], [NgayVangMat], [GioVao], [GioRa], [TrangThai]) VALUES (205, N'0005', CAST(N'2020-08-05' AS Date), NULL, NULL, NULL)
INSERT [dbo].[QuanLyVangMat] ([ID], [MaSoNhanVien], [NgayVangMat], [GioVao], [GioRa], [TrangThai]) VALUES (206, N'0005', CAST(N'2020-08-02' AS Date), NULL, NULL, NULL)
INSERT [dbo].[QuanLyVangMat] ([ID], [MaSoNhanVien], [NgayVangMat], [GioVao], [GioRa], [TrangThai]) VALUES (207, N'0005', CAST(N'2020-08-02' AS Date), NULL, NULL, NULL)
INSERT [dbo].[QuanLyVangMat] ([ID], [MaSoNhanVien], [NgayVangMat], [GioVao], [GioRa], [TrangThai]) VALUES (208, N'0005', CAST(N'2020-08-09' AS Date), NULL, NULL, NULL)
INSERT [dbo].[QuanLyVangMat] ([ID], [MaSoNhanVien], [NgayVangMat], [GioVao], [GioRa], [TrangThai]) VALUES (209, N'0001', CAST(N'2020-07-30' AS Date), NULL, NULL, NULL)
INSERT [dbo].[QuanLyVangMat] ([ID], [MaSoNhanVien], [NgayVangMat], [GioVao], [GioRa], [TrangThai]) VALUES (210, N'0008', CAST(N'2020-07-31' AS Date), NULL, NULL, NULL)
INSERT [dbo].[QuanLyVangMat] ([ID], [MaSoNhanVien], [NgayVangMat], [GioVao], [GioRa], [TrangThai]) VALUES (211, N'0009', CAST(N'2020-07-31' AS Date), NULL, NULL, NULL)
INSERT [dbo].[QuanLyVangMat] ([ID], [MaSoNhanVien], [NgayVangMat], [GioVao], [GioRa], [TrangThai]) VALUES (212, N'0010', CAST(N'2020-07-31' AS Date), NULL, NULL, NULL)
INSERT [dbo].[QuanLyVangMat] ([ID], [MaSoNhanVien], [NgayVangMat], [GioVao], [GioRa], [TrangThai]) VALUES (213, N'0003', CAST(N'2020-07-31' AS Date), NULL, NULL, NULL)
INSERT [dbo].[QuanLyVangMat] ([ID], [MaSoNhanVien], [NgayVangMat], [GioVao], [GioRa], [TrangThai]) VALUES (214, N'0001', CAST(N'2020-07-31' AS Date), NULL, NULL, NULL)
INSERT [dbo].[QuanLyVangMat] ([ID], [MaSoNhanVien], [NgayVangMat], [GioVao], [GioRa], [TrangThai]) VALUES (215, N'0002', CAST(N'2020-07-03' AS Date), NULL, NULL, NULL)
INSERT [dbo].[QuanLyVangMat] ([ID], [MaSoNhanVien], [NgayVangMat], [GioVao], [GioRa], [TrangThai]) VALUES (216, N'0001', CAST(N'2020-07-03' AS Date), NULL, NULL, NULL)
INSERT [dbo].[QuanLyVangMat] ([ID], [MaSoNhanVien], [NgayVangMat], [GioVao], [GioRa], [TrangThai]) VALUES (217, N'0007', CAST(N'2020-07-03' AS Date), NULL, NULL, NULL)
INSERT [dbo].[QuanLyVangMat] ([ID], [MaSoNhanVien], [NgayVangMat], [GioVao], [GioRa], [TrangThai]) VALUES (218, N'0006', CAST(N'2020-08-03' AS Date), NULL, NULL, NULL)
INSERT [dbo].[QuanLyVangMat] ([ID], [MaSoNhanVien], [NgayVangMat], [GioVao], [GioRa], [TrangThai]) VALUES (219, N'0005', CAST(N'2020-07-03' AS Date), NULL, NULL, NULL)
INSERT [dbo].[QuanLyVangMat] ([ID], [MaSoNhanVien], [NgayVangMat], [GioVao], [GioRa], [TrangThai]) VALUES (220, N'0008', CAST(N'2020-07-03' AS Date), NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[QuanLyVangMat] OFF
SET IDENTITY_INSERT [dbo].[QuaTrinhDaoTao] ON 

INSERT [dbo].[QuaTrinhDaoTao] ([ID], [MaSoNhanVien], [NgayBatDau], [NgayKetThuc], [TenTruong], [LoaiBang], [ChuyenNganh], [XepLoai]) VALUES (24, N'0001', CAST(N'2020-07-05' AS Date), CAST(N'2020-08-08' AS Date), N'trường đại học quốc gia thành phố hồ chí minh', N'Đại học', N'CNTT', N'Xuất sắc')
INSERT [dbo].[QuaTrinhDaoTao] ([ID], [MaSoNhanVien], [NgayBatDau], [NgayKetThuc], [TenTruong], [LoaiBang], [ChuyenNganh], [XepLoai]) VALUES (25, N'0002', CAST(N'2020-07-02' AS Date), CAST(N'2020-07-09' AS Date), N'trường đại học quốc gia thành phố hồ chí minh', N'Đại học', N'CNTT', N'Giỏi')
INSERT [dbo].[QuaTrinhDaoTao] ([ID], [MaSoNhanVien], [NgayBatDau], [NgayKetThuc], [TenTruong], [LoaiBang], [ChuyenNganh], [XepLoai]) VALUES (26, N'0003', CAST(N'2020-07-02' AS Date), CAST(N'2020-07-09' AS Date), N'trường đại học quốc gia thành phố hồ chí minh', N'Đại học', N'CNTT', N'Giỏi')
INSERT [dbo].[QuaTrinhDaoTao] ([ID], [MaSoNhanVien], [NgayBatDau], [NgayKetThuc], [TenTruong], [LoaiBang], [ChuyenNganh], [XepLoai]) VALUES (27, N'0004', CAST(N'2020-07-02' AS Date), CAST(N'2020-07-09' AS Date), N'trường đại học quốc gia thành phố hồ chí minh', N'Đại học', N'CNTT', N'Giỏi')
INSERT [dbo].[QuaTrinhDaoTao] ([ID], [MaSoNhanVien], [NgayBatDau], [NgayKetThuc], [TenTruong], [LoaiBang], [ChuyenNganh], [XepLoai]) VALUES (28, N'0005', CAST(N'2020-07-02' AS Date), CAST(N'2020-07-09' AS Date), N'trường đại học quốc gia thành phố hồ chí minh', N'Đại học', N'CNTT', N'Giỏi')
INSERT [dbo].[QuaTrinhDaoTao] ([ID], [MaSoNhanVien], [NgayBatDau], [NgayKetThuc], [TenTruong], [LoaiBang], [ChuyenNganh], [XepLoai]) VALUES (29, N'0006', CAST(N'2020-07-02' AS Date), CAST(N'2020-07-09' AS Date), N'trường đại học quốc gia thành phố hồ chí minh', N'Đại học', N'CNTT', N'Giỏi')
INSERT [dbo].[QuaTrinhDaoTao] ([ID], [MaSoNhanVien], [NgayBatDau], [NgayKetThuc], [TenTruong], [LoaiBang], [ChuyenNganh], [XepLoai]) VALUES (30, N'0007', CAST(N'2020-07-02' AS Date), CAST(N'2020-07-09' AS Date), N'trường đại học quốc gia thành phố hồ chí minh', N'Đại học', N'CNTT', N'Giỏi')
INSERT [dbo].[QuaTrinhDaoTao] ([ID], [MaSoNhanVien], [NgayBatDau], [NgayKetThuc], [TenTruong], [LoaiBang], [ChuyenNganh], [XepLoai]) VALUES (31, N'0008', CAST(N'2020-07-02' AS Date), CAST(N'2020-07-09' AS Date), N'trường đại học quốc gia thành phố hồ chí minh', N'Đại học', N'CNTT', N'Giỏi')
INSERT [dbo].[QuaTrinhDaoTao] ([ID], [MaSoNhanVien], [NgayBatDau], [NgayKetThuc], [TenTruong], [LoaiBang], [ChuyenNganh], [XepLoai]) VALUES (32, N'0009', CAST(N'2020-07-02' AS Date), CAST(N'2020-07-09' AS Date), N'trường đại học quốc gia thành phố hồ chí minh', N'Đại học', N'CNTT', N'Giỏi')
INSERT [dbo].[QuaTrinhDaoTao] ([ID], [MaSoNhanVien], [NgayBatDau], [NgayKetThuc], [TenTruong], [LoaiBang], [ChuyenNganh], [XepLoai]) VALUES (33, N'0010', CAST(N'2020-07-02' AS Date), CAST(N'2020-07-09' AS Date), N'trường đại học quốc gia thành phố hồ chí minh', N'Đại học', N'CNTT', N'Giỏi')
INSERT [dbo].[QuaTrinhDaoTao] ([ID], [MaSoNhanVien], [NgayBatDau], [NgayKetThuc], [TenTruong], [LoaiBang], [ChuyenNganh], [XepLoai]) VALUES (49, N'0001', CAST(N'2020-08-15' AS Date), CAST(N'2020-08-21' AS Date), N'dwqfqwfwqfwqfwffwq', N'Đại học', N'fqw', N'Xuất sắc')
INSERT [dbo].[QuaTrinhDaoTao] ([ID], [MaSoNhanVien], [NgayBatDau], [NgayKetThuc], [TenTruong], [LoaiBang], [ChuyenNganh], [XepLoai]) VALUES (51, N'0001', CAST(N'2020-08-28' AS Date), CAST(N'2020-08-29' AS Date), N'geg', N'egw', N'gew', N'gewg')
INSERT [dbo].[QuaTrinhDaoTao] ([ID], [MaSoNhanVien], [NgayBatDau], [NgayKetThuc], [TenTruong], [LoaiBang], [ChuyenNganh], [XepLoai]) VALUES (52, N'0001', CAST(N'2020-08-22' AS Date), CAST(N'2020-08-29' AS Date), N'ghd', N'hds', N'hds', N'hdsh')
INSERT [dbo].[QuaTrinhDaoTao] ([ID], [MaSoNhanVien], [NgayBatDau], [NgayKetThuc], [TenTruong], [LoaiBang], [ChuyenNganh], [XepLoai]) VALUES (53, N'0001', CAST(N'2020-08-19' AS Date), CAST(N'2020-09-06' AS Date), N'dg', N'gds', N'gsd', N'gds')
INSERT [dbo].[QuaTrinhDaoTao] ([ID], [MaSoNhanVien], [NgayBatDau], [NgayKetThuc], [TenTruong], [LoaiBang], [ChuyenNganh], [XepLoai]) VALUES (54, N'0001', CAST(N'2020-08-12' AS Date), CAST(N'2020-08-20' AS Date), N'gds', N'gds', N'gds', N'gds')
INSERT [dbo].[QuaTrinhDaoTao] ([ID], [MaSoNhanVien], [NgayBatDau], [NgayKetThuc], [TenTruong], [LoaiBang], [ChuyenNganh], [XepLoai]) VALUES (55, N'0012', NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[QuaTrinhDaoTao] ([ID], [MaSoNhanVien], [NgayBatDau], [NgayKetThuc], [TenTruong], [LoaiBang], [ChuyenNganh], [XepLoai]) VALUES (56, N'0013', NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[QuaTrinhDaoTao] ([ID], [MaSoNhanVien], [NgayBatDau], [NgayKetThuc], [TenTruong], [LoaiBang], [ChuyenNganh], [XepLoai]) VALUES (57, N'0014', NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[QuaTrinhDaoTao] ([ID], [MaSoNhanVien], [NgayBatDau], [NgayKetThuc], [TenTruong], [LoaiBang], [ChuyenNganh], [XepLoai]) VALUES (58, N'0015', NULL, NULL, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[QuaTrinhDaoTao] OFF
SET IDENTITY_INSERT [dbo].[QuetThe] ON 

INSERT [dbo].[QuetThe] ([ID], [MaSoNhanVien], [GioQuetThe], [NgayQuetThe]) VALUES (3613, N'0001', N'7:30', CAST(N'2020-08-03' AS Date))
INSERT [dbo].[QuetThe] ([ID], [MaSoNhanVien], [GioQuetThe], [NgayQuetThe]) VALUES (3614, N'0002', N'7:30', CAST(N'2020-08-03' AS Date))
INSERT [dbo].[QuetThe] ([ID], [MaSoNhanVien], [GioQuetThe], [NgayQuetThe]) VALUES (3615, N'0003', N'7:30', CAST(N'2020-08-03' AS Date))
INSERT [dbo].[QuetThe] ([ID], [MaSoNhanVien], [GioQuetThe], [NgayQuetThe]) VALUES (3616, N'0003', N'11:30', CAST(N'2020-08-03' AS Date))
INSERT [dbo].[QuetThe] ([ID], [MaSoNhanVien], [GioQuetThe], [NgayQuetThe]) VALUES (3617, N'0003', N'13:30', CAST(N'2020-08-03' AS Date))
INSERT [dbo].[QuetThe] ([ID], [MaSoNhanVien], [GioQuetThe], [NgayQuetThe]) VALUES (3618, N'0003', N'17:30', CAST(N'2020-08-03' AS Date))
INSERT [dbo].[QuetThe] ([ID], [MaSoNhanVien], [GioQuetThe], [NgayQuetThe]) VALUES (3619, N'0004', N'7:30', CAST(N'2020-08-03' AS Date))
INSERT [dbo].[QuetThe] ([ID], [MaSoNhanVien], [GioQuetThe], [NgayQuetThe]) VALUES (3620, N'0004', N'11:30', CAST(N'2020-08-03' AS Date))
INSERT [dbo].[QuetThe] ([ID], [MaSoNhanVien], [GioQuetThe], [NgayQuetThe]) VALUES (3621, N'0004', N'13:30', CAST(N'2020-08-03' AS Date))
INSERT [dbo].[QuetThe] ([ID], [MaSoNhanVien], [GioQuetThe], [NgayQuetThe]) VALUES (3622, N'0004', N'17:30', CAST(N'2020-08-03' AS Date))
INSERT [dbo].[QuetThe] ([ID], [MaSoNhanVien], [GioQuetThe], [NgayQuetThe]) VALUES (3623, N'0001', N'7:30', CAST(N'2020-08-03' AS Date))
INSERT [dbo].[QuetThe] ([ID], [MaSoNhanVien], [GioQuetThe], [NgayQuetThe]) VALUES (3624, N'0002', N'7:30', CAST(N'2020-08-03' AS Date))
INSERT [dbo].[QuetThe] ([ID], [MaSoNhanVien], [GioQuetThe], [NgayQuetThe]) VALUES (3625, N'0003', N'7:30', CAST(N'2020-08-03' AS Date))
INSERT [dbo].[QuetThe] ([ID], [MaSoNhanVien], [GioQuetThe], [NgayQuetThe]) VALUES (3626, N'0003', N'11:30', CAST(N'2020-08-03' AS Date))
INSERT [dbo].[QuetThe] ([ID], [MaSoNhanVien], [GioQuetThe], [NgayQuetThe]) VALUES (3627, N'0003', N'13:30', CAST(N'2020-08-03' AS Date))
INSERT [dbo].[QuetThe] ([ID], [MaSoNhanVien], [GioQuetThe], [NgayQuetThe]) VALUES (3628, N'0003', N'17:30', CAST(N'2020-08-03' AS Date))
INSERT [dbo].[QuetThe] ([ID], [MaSoNhanVien], [GioQuetThe], [NgayQuetThe]) VALUES (3629, N'0004', N'7:30', CAST(N'2020-08-03' AS Date))
INSERT [dbo].[QuetThe] ([ID], [MaSoNhanVien], [GioQuetThe], [NgayQuetThe]) VALUES (3630, N'0004', N'11:30', CAST(N'2020-08-03' AS Date))
INSERT [dbo].[QuetThe] ([ID], [MaSoNhanVien], [GioQuetThe], [NgayQuetThe]) VALUES (3631, N'0004', N'13:30', CAST(N'2020-08-03' AS Date))
INSERT [dbo].[QuetThe] ([ID], [MaSoNhanVien], [GioQuetThe], [NgayQuetThe]) VALUES (3632, N'0004', N'17:30', CAST(N'2020-08-03' AS Date))
SET IDENTITY_INSERT [dbo].[QuetThe] OFF
SET IDENTITY_INSERT [dbo].[QuetTheTheoNgay] ON 

INSERT [dbo].[QuetTheTheoNgay] ([ID], [MaSoNhanVien], [GioQuetThe], [NgayQuetThe]) VALUES (21, N'0001', N'7:30', CAST(N'2020-08-03' AS Date))
INSERT [dbo].[QuetTheTheoNgay] ([ID], [MaSoNhanVien], [GioQuetThe], [NgayQuetThe]) VALUES (22, N'0002', N'7:30', CAST(N'2020-08-03' AS Date))
INSERT [dbo].[QuetTheTheoNgay] ([ID], [MaSoNhanVien], [GioQuetThe], [NgayQuetThe]) VALUES (23, N'0003', N'7:30', CAST(N'2020-08-03' AS Date))
INSERT [dbo].[QuetTheTheoNgay] ([ID], [MaSoNhanVien], [GioQuetThe], [NgayQuetThe]) VALUES (24, N'0003', N'11:30', CAST(N'2020-08-03' AS Date))
INSERT [dbo].[QuetTheTheoNgay] ([ID], [MaSoNhanVien], [GioQuetThe], [NgayQuetThe]) VALUES (25, N'0003', N'13:30', CAST(N'2020-08-03' AS Date))
INSERT [dbo].[QuetTheTheoNgay] ([ID], [MaSoNhanVien], [GioQuetThe], [NgayQuetThe]) VALUES (26, N'0003', N'17:30', CAST(N'2020-08-03' AS Date))
INSERT [dbo].[QuetTheTheoNgay] ([ID], [MaSoNhanVien], [GioQuetThe], [NgayQuetThe]) VALUES (27, N'0004', N'7:30', CAST(N'2020-08-03' AS Date))
INSERT [dbo].[QuetTheTheoNgay] ([ID], [MaSoNhanVien], [GioQuetThe], [NgayQuetThe]) VALUES (28, N'0004', N'11:30', CAST(N'2020-08-03' AS Date))
INSERT [dbo].[QuetTheTheoNgay] ([ID], [MaSoNhanVien], [GioQuetThe], [NgayQuetThe]) VALUES (29, N'0004', N'13:30', CAST(N'2020-08-03' AS Date))
INSERT [dbo].[QuetTheTheoNgay] ([ID], [MaSoNhanVien], [GioQuetThe], [NgayQuetThe]) VALUES (30, N'0004', N'17:30', CAST(N'2020-08-03' AS Date))
SET IDENTITY_INSERT [dbo].[QuetTheTheoNgay] OFF
INSERT [dbo].[TaiKhoanCo] ([SoTaiKhoanCo], [TenTaiKhoan]) VALUES (N'1111', N'Tiền Việt Nam')
INSERT [dbo].[TaiKhoanCo] ([SoTaiKhoanCo], [TenTaiKhoan]) VALUES (N'1112', N'Ngoại tệ')
INSERT [dbo].[TaiKhoanCo] ([SoTaiKhoanCo], [TenTaiKhoan]) VALUES (N'1113', N'Vàng ngoại tệ')
INSERT [dbo].[TaiKhoanCo] ([SoTaiKhoanCo], [TenTaiKhoan]) VALUES (N'1121', N'Tiền Việt Nam')
INSERT [dbo].[TaiKhoanCo] ([SoTaiKhoanCo], [TenTaiKhoan]) VALUES (N'1122', N'Ngoại tệ')
INSERT [dbo].[TaiKhoanCo] ([SoTaiKhoanCo], [TenTaiKhoan]) VALUES (N'1123', N'Vàng tiền tệ')
INSERT [dbo].[TaiKhoanCo] ([SoTaiKhoanCo], [TenTaiKhoan]) VALUES (N'1131', N'Tiền Việt Nam')
INSERT [dbo].[TaiKhoanCo] ([SoTaiKhoanCo], [TenTaiKhoan]) VALUES (N'1132', N'Ngoại tệ')
INSERT [dbo].[TaiKhoanCo] ([SoTaiKhoanCo], [TenTaiKhoan]) VALUES (N'1211', N'Cổ phiếu')
INSERT [dbo].[TaiKhoanCo] ([SoTaiKhoanCo], [TenTaiKhoan]) VALUES (N'1212', N'Trái phiếu')
INSERT [dbo].[TaiKhoanCo] ([SoTaiKhoanCo], [TenTaiKhoan]) VALUES (N'1218', N'Chứng khoáng và công cụ tài chính khác')
INSERT [dbo].[TaiKhoanCo] ([SoTaiKhoanCo], [TenTaiKhoan]) VALUES (N'1281', N'Tiền gửi có kỳ hạn')
INSERT [dbo].[TaiKhoanCo] ([SoTaiKhoanCo], [TenTaiKhoan]) VALUES (N'1282', N'Trái phiếu')
INSERT [dbo].[TaiKhoanCo] ([SoTaiKhoanCo], [TenTaiKhoan]) VALUES (N'1283', N'Cho vay')
INSERT [dbo].[TaiKhoanCo] ([SoTaiKhoanCo], [TenTaiKhoan]) VALUES (N'1288', N'Các khoản có đầu tư khác nắm giữ đến')
INSERT [dbo].[TaiKhoanCo] ([SoTaiKhoanCo], [TenTaiKhoan]) VALUES (N'131', N'Phải thu của khác hàng')
INSERT [dbo].[TaiKhoanCo] ([SoTaiKhoanCo], [TenTaiKhoan]) VALUES (N'1331', N'Thuế GTGT được khẩu trừ cửa hàng')
INSERT [dbo].[TaiKhoanCo] ([SoTaiKhoanCo], [TenTaiKhoan]) VALUES (N'1332', N'Thuế GTGT được khẩu trừ của TSCĐ')
INSERT [dbo].[TaiKhoanCo] ([SoTaiKhoanCo], [TenTaiKhoan]) VALUES (N'1361', N'Vốn kinh doanh ở các đơn vị trực thuộc')
INSERT [dbo].[TaiKhoanCo] ([SoTaiKhoanCo], [TenTaiKhoan]) VALUES (N'1362', N'Phải thu nội bộ về chênh lệch tỷ giá')
INSERT [dbo].[TaiKhoanCo] ([SoTaiKhoanCo], [TenTaiKhoan]) VALUES (N'1363', N'Phải thu nội bộ về chi phí đi vay đủ đi')
INSERT [dbo].[TaiKhoanCo] ([SoTaiKhoanCo], [TenTaiKhoan]) VALUES (N'1368', N'Phải thu nội bộ khác')
INSERT [dbo].[TaiKhoanCo] ([SoTaiKhoanCo], [TenTaiKhoan]) VALUES (N'1381', N'Tàu sản thiếu chờ xử lý')
INSERT [dbo].[TaiKhoanCo] ([SoTaiKhoanCo], [TenTaiKhoan]) VALUES (N'1385', N'Phải thu về cổ phần hóa')
INSERT [dbo].[TaiKhoanCo] ([SoTaiKhoanCo], [TenTaiKhoan]) VALUES (N'1388', N'Phải thu khác')
INSERT [dbo].[TaiKhoanCo] ([SoTaiKhoanCo], [TenTaiKhoan]) VALUES (N'141', N'Tạm ứng')
INSERT [dbo].[TaiKhoanCo] ([SoTaiKhoanCo], [TenTaiKhoan]) VALUES (N'151', N'Hàng mua đang đi đường')
INSERT [dbo].[TaiKhoanCo] ([SoTaiKhoanCo], [TenTaiKhoan]) VALUES (N'152', N'Nguyên liệu, vật liệu')
INSERT [dbo].[TaiKhoanCo] ([SoTaiKhoanCo], [TenTaiKhoan]) VALUES (N'1531', N'Công cụ, dụng cụ')
INSERT [dbo].[TaiKhoanCo] ([SoTaiKhoanCo], [TenTaiKhoan]) VALUES (N'1532', N'Bao bì luân chuyển')
INSERT [dbo].[TaiKhoanCo] ([SoTaiKhoanCo], [TenTaiKhoan]) VALUES (N'1533', N'Đồ dùng cho thuê')
INSERT [dbo].[TaiKhoanCo] ([SoTaiKhoanCo], [TenTaiKhoan]) VALUES (N'1534', N'Thiết bị, phụ tùng thay thế')
INSERT [dbo].[TaiKhoanCo] ([SoTaiKhoanCo], [TenTaiKhoan]) VALUES (N'154', N'Chi phí sản xuất, kinh đoanh dở dang')
INSERT [dbo].[TaiKhoanCo] ([SoTaiKhoanCo], [TenTaiKhoan]) VALUES (N'1551', N'Thành phẩm nhập kho')
INSERT [dbo].[TaiKhoanCo] ([SoTaiKhoanCo], [TenTaiKhoan]) VALUES (N'1557', N'Thành phẩm bất động sản')
INSERT [dbo].[TaiKhoanCo] ([SoTaiKhoanCo], [TenTaiKhoan]) VALUES (N'1561', N'Giá mua hàng hóa')
INSERT [dbo].[TaiKhoanCo] ([SoTaiKhoanCo], [TenTaiKhoan]) VALUES (N'1562', N'Chi phí thu mua hàng hóa')
INSERT [dbo].[TaiKhoanCo] ([SoTaiKhoanCo], [TenTaiKhoan]) VALUES (N'1567', N'Hàng hóa bất động sản')
INSERT [dbo].[TaiKhoanCo] ([SoTaiKhoanCo], [TenTaiKhoan]) VALUES (N'157', N'Hàng gửi đi bán')
INSERT [dbo].[TaiKhoanCo] ([SoTaiKhoanCo], [TenTaiKhoan]) VALUES (N'158', N'Hàng hóa kho bảo thuế')
INSERT [dbo].[TaiKhoanCo] ([SoTaiKhoanCo], [TenTaiKhoan]) VALUES (N'1611', N'Chi sự nghiệp năm trước')
INSERT [dbo].[TaiKhoanCo] ([SoTaiKhoanCo], [TenTaiKhoan]) VALUES (N'1612', N'Chi sự nghiệp năm nay')
INSERT [dbo].[TaiKhoanCo] ([SoTaiKhoanCo], [TenTaiKhoan]) VALUES (N'171', N'Gao dịch mua bán lại trái phiếu chính')
INSERT [dbo].[TaiKhoanCo] ([SoTaiKhoanCo], [TenTaiKhoan]) VALUES (N'2111', N'Nhà cửa, kiến trúc')
INSERT [dbo].[TaiKhoanCo] ([SoTaiKhoanCo], [TenTaiKhoan]) VALUES (N'2112', N'Máy móc, thiết bị')
INSERT [dbo].[TaiKhoanCo] ([SoTaiKhoanCo], [TenTaiKhoan]) VALUES (N'2113', N'Phương tiện vận tải, truyền dẫn')
INSERT [dbo].[TaiKhoanCo] ([SoTaiKhoanCo], [TenTaiKhoan]) VALUES (N'2114', N'Thiết bị, dụng cụ quản lý')
INSERT [dbo].[TaiKhoanCo] ([SoTaiKhoanCo], [TenTaiKhoan]) VALUES (N'2115', N'Cây lâu năm, súc vật làm việc và cho')
INSERT [dbo].[TaiKhoanCo] ([SoTaiKhoanCo], [TenTaiKhoan]) VALUES (N'2118', N'TSCĐ khác')
INSERT [dbo].[TaiKhoanCo] ([SoTaiKhoanCo], [TenTaiKhoan]) VALUES (N'2121', N'TSCĐ hữu hình thuê tài chính')
INSERT [dbo].[TaiKhoanCo] ([SoTaiKhoanCo], [TenTaiKhoan]) VALUES (N'2122', N'TSCĐ bô hình thuê tài chính')
INSERT [dbo].[TaiKhoanCo] ([SoTaiKhoanCo], [TenTaiKhoan]) VALUES (N'2131', N'Quyền sử dụng đất')
INSERT [dbo].[TaiKhoanCo] ([SoTaiKhoanCo], [TenTaiKhoan]) VALUES (N'2132', N'Quyền phát hành')
INSERT [dbo].[TaiKhoanCo] ([SoTaiKhoanCo], [TenTaiKhoan]) VALUES (N'2133', N'Bản quyền, bằng sáng chế')
INSERT [dbo].[TaiKhoanCo] ([SoTaiKhoanCo], [TenTaiKhoan]) VALUES (N'2134', N'Nhãn hiệu, tên thương mại')
INSERT [dbo].[TaiKhoanCo] ([SoTaiKhoanCo], [TenTaiKhoan]) VALUES (N'2135', N'Chương trình phần mềm')
INSERT [dbo].[TaiKhoanCo] ([SoTaiKhoanCo], [TenTaiKhoan]) VALUES (N'2136', N'Giấy phép và giấy phép nhượng quyền')
INSERT [dbo].[TaiKhoanCo] ([SoTaiKhoanCo], [TenTaiKhoan]) VALUES (N'2141', N'Hao mòn TSCĐ hữu hình')
INSERT [dbo].[TaiKhoanCo] ([SoTaiKhoanCo], [TenTaiKhoan]) VALUES (N'2142', N'Hao mòn TSCĐ thuê tài chính')
INSERT [dbo].[TaiKhoanCo] ([SoTaiKhoanCo], [TenTaiKhoan]) VALUES (N'2143', N'Hao mòn TSCĐ vô hình')
INSERT [dbo].[TaiKhoanCo] ([SoTaiKhoanCo], [TenTaiKhoan]) VALUES (N'2147', N'Hao mòn bất động sản đầu tư')
INSERT [dbo].[TaiKhoanCo] ([SoTaiKhoanCo], [TenTaiKhoan]) VALUES (N'2168', N'TSCĐ vô hình khác')
INSERT [dbo].[TaiKhoanCo] ([SoTaiKhoanCo], [TenTaiKhoan]) VALUES (N'217', N'Bất động sản đầu tư')
INSERT [dbo].[TaiKhoanCo] ([SoTaiKhoanCo], [TenTaiKhoan]) VALUES (N'221', N'Đầu tư vào công ty con')
INSERT [dbo].[TaiKhoanCo] ([SoTaiKhoanCo], [TenTaiKhoan]) VALUES (N'222', N'Đầu tư vào công ty liên doanh, liên kết')
INSERT [dbo].[TaiKhoanCo] ([SoTaiKhoanCo], [TenTaiKhoan]) VALUES (N'2281', N'Cổ phiếu')
INSERT [dbo].[TaiKhoanCo] ([SoTaiKhoanCo], [TenTaiKhoan]) VALUES (N'2288', N'Đầu tư khác')
INSERT [dbo].[TaiKhoanCo] ([SoTaiKhoanCo], [TenTaiKhoan]) VALUES (N'2291', N'Dự phòng giảm giá chứng khoáng kinh')
INSERT [dbo].[TaiKhoanCo] ([SoTaiKhoanCo], [TenTaiKhoan]) VALUES (N'2292', N'Dự phòng tổn thất đầ tư vào đơn vị')
INSERT [dbo].[TaiKhoanCo] ([SoTaiKhoanCo], [TenTaiKhoan]) VALUES (N'2293', N'Dự phòng phải thu khó đòi')
INSERT [dbo].[TaiKhoanCo] ([SoTaiKhoanCo], [TenTaiKhoan]) VALUES (N'2294', N'Dự phòng giảm giá hàng tồn kho')
INSERT [dbo].[TaiKhoanCo] ([SoTaiKhoanCo], [TenTaiKhoan]) VALUES (N'2411', N'Mua sắn TSCĐ')
INSERT [dbo].[TaiKhoanCo] ([SoTaiKhoanCo], [TenTaiKhoan]) VALUES (N'2412', N'Xây dựng cơ bản')
INSERT [dbo].[TaiKhoanCo] ([SoTaiKhoanCo], [TenTaiKhoan]) VALUES (N'2413', N'Sữa chữa lớn TSCĐ')
INSERT [dbo].[TaiKhoanCo] ([SoTaiKhoanCo], [TenTaiKhoan]) VALUES (N'242', N'Chi phí trả trước')
INSERT [dbo].[TaiKhoanCo] ([SoTaiKhoanCo], [TenTaiKhoan]) VALUES (N'243', N'Tài sản thuế thu nhập hoãn lại')
INSERT [dbo].[TaiKhoanCo] ([SoTaiKhoanCo], [TenTaiKhoan]) VALUES (N'244', N'Cầm cố, thuế chấp, ký quỹ, ký cược')
INSERT [dbo].[TaiKhoanCo] ([SoTaiKhoanCo], [TenTaiKhoan]) VALUES (N'331', N'Phải trả cho người bán')
INSERT [dbo].[TaiKhoanCo] ([SoTaiKhoanCo], [TenTaiKhoan]) VALUES (N'33311', N'Thuế GTGT đầu ra')
INSERT [dbo].[TaiKhoanCo] ([SoTaiKhoanCo], [TenTaiKhoan]) VALUES (N'33312', N'Thuế GTGT hàng nhập khẩu')
INSERT [dbo].[TaiKhoanCo] ([SoTaiKhoanCo], [TenTaiKhoan]) VALUES (N'3332', N'Thuế tiêu thụ đặc biệt')
INSERT [dbo].[TaiKhoanCo] ([SoTaiKhoanCo], [TenTaiKhoan]) VALUES (N'3333', N'Thuế xuất, nhập khẩu')
INSERT [dbo].[TaiKhoanCo] ([SoTaiKhoanCo], [TenTaiKhoan]) VALUES (N'3334', N'Thuế thu nhập doanh nghiệp')
INSERT [dbo].[TaiKhoanCo] ([SoTaiKhoanCo], [TenTaiKhoan]) VALUES (N'3335', N'Thuế thu nhập cá nhân')
INSERT [dbo].[TaiKhoanCo] ([SoTaiKhoanCo], [TenTaiKhoan]) VALUES (N'3336', N'Thuế tài nguyên')
INSERT [dbo].[TaiKhoanCo] ([SoTaiKhoanCo], [TenTaiKhoan]) VALUES (N'3337', N'Thuế nhà đất, tiền thuê đất')
INSERT [dbo].[TaiKhoanCo] ([SoTaiKhoanCo], [TenTaiKhoan]) VALUES (N'33381', N'Thuế bảo vệ môi trường')
INSERT [dbo].[TaiKhoanCo] ([SoTaiKhoanCo], [TenTaiKhoan]) VALUES (N'33382', N'Các loại thuế khác')
INSERT [dbo].[TaiKhoanCo] ([SoTaiKhoanCo], [TenTaiKhoan]) VALUES (N'3339', N'Phí, lệ phí và các khoản phải nộp khác')
INSERT [dbo].[TaiKhoanCo] ([SoTaiKhoanCo], [TenTaiKhoan]) VALUES (N'335', N'Chi phí phải trả')
INSERT [dbo].[TaiKhoanCo] ([SoTaiKhoanCo], [TenTaiKhoan]) VALUES (N'3361', N'Phải trả nội bộ về vốn kinh doanh')
INSERT [dbo].[TaiKhoanCo] ([SoTaiKhoanCo], [TenTaiKhoan]) VALUES (N'3362', N'Phải trả nội bộ về chênh lệch tỷ giá')
INSERT [dbo].[TaiKhoanCo] ([SoTaiKhoanCo], [TenTaiKhoan]) VALUES (N'3363', N'Phải trả nội bộ về chi phí đi vay đủ ')
INSERT [dbo].[TaiKhoanCo] ([SoTaiKhoanCo], [TenTaiKhoan]) VALUES (N'3368', N'Phải trả nội bộ khác')
INSERT [dbo].[TaiKhoanCo] ([SoTaiKhoanCo], [TenTaiKhoan]) VALUES (N'337', N'Thanh toán theo tiến độ kế hoạch hợp')
INSERT [dbo].[TaiKhoanCo] ([SoTaiKhoanCo], [TenTaiKhoan]) VALUES (N'3381', N'Tài sản thừa chờ giải quyết')
INSERT [dbo].[TaiKhoanCo] ([SoTaiKhoanCo], [TenTaiKhoan]) VALUES (N'3382', N'Kinh phí công đoàn')
INSERT [dbo].[TaiKhoanCo] ([SoTaiKhoanCo], [TenTaiKhoan]) VALUES (N'3383', N'Bảo hiểm xã hội')
INSERT [dbo].[TaiKhoanCo] ([SoTaiKhoanCo], [TenTaiKhoan]) VALUES (N'3384', N'Bảo hiểm y tế')
INSERT [dbo].[TaiKhoanCo] ([SoTaiKhoanCo], [TenTaiKhoan]) VALUES (N'3385', N'Phải trả về cổ phần hóa')
GO
INSERT [dbo].[TaiKhoanCo] ([SoTaiKhoanCo], [TenTaiKhoan]) VALUES (N'3386', N'Bảo hiểm thất nghiệp')
INSERT [dbo].[TaiKhoanCo] ([SoTaiKhoanCo], [TenTaiKhoan]) VALUES (N'3387', N'Doanh thu chưa được thực hiện')
INSERT [dbo].[TaiKhoanCo] ([SoTaiKhoanCo], [TenTaiKhoan]) VALUES (N'3388', N'Phải trả, phải nộp khác')
INSERT [dbo].[TaiKhoanCo] ([SoTaiKhoanCo], [TenTaiKhoan]) VALUES (N'3411', N'Các khoản đi vay')
INSERT [dbo].[TaiKhoanCo] ([SoTaiKhoanCo], [TenTaiKhoan]) VALUES (N'3412', N'Nợ thuê tài chính')
INSERT [dbo].[TaiKhoanCo] ([SoTaiKhoanCo], [TenTaiKhoan]) VALUES (N'34311', N'Mệnh giá trái phiếu')
INSERT [dbo].[TaiKhoanCo] ([SoTaiKhoanCo], [TenTaiKhoan]) VALUES (N'34312', N'Chiết khấu trái phiếu')
INSERT [dbo].[TaiKhoanCo] ([SoTaiKhoanCo], [TenTaiKhoan]) VALUES (N'34313', N'Phụ trội trái phiếu')
INSERT [dbo].[TaiKhoanCo] ([SoTaiKhoanCo], [TenTaiKhoan]) VALUES (N'3432', N'Trái phiếu chuyển đổi')
INSERT [dbo].[TaiKhoanCo] ([SoTaiKhoanCo], [TenTaiKhoan]) VALUES (N'344', N'Nhận ký quỹ, ký cược')
INSERT [dbo].[TaiKhoanCo] ([SoTaiKhoanCo], [TenTaiKhoan]) VALUES (N'347', N'Thuế thu nhập hoãn lại phải trả')
INSERT [dbo].[TaiKhoanCo] ([SoTaiKhoanCo], [TenTaiKhoan]) VALUES (N'3521', N'Dự phòng bảo hành sản phẩm hàng')
INSERT [dbo].[TaiKhoanCo] ([SoTaiKhoanCo], [TenTaiKhoan]) VALUES (N'3522', N'Dự phòng bảo hành công trình xây dựng')
INSERT [dbo].[TaiKhoanCo] ([SoTaiKhoanCo], [TenTaiKhoan]) VALUES (N'3523', N'Dự phòng tái cơ cấu doanh nghiệp')
INSERT [dbo].[TaiKhoanCo] ([SoTaiKhoanCo], [TenTaiKhoan]) VALUES (N'3524', N'Dự phòng phải trả khác')
INSERT [dbo].[TaiKhoanCo] ([SoTaiKhoanCo], [TenTaiKhoan]) VALUES (N'3531', N'Quỹ khen thưởng')
INSERT [dbo].[TaiKhoanCo] ([SoTaiKhoanCo], [TenTaiKhoan]) VALUES (N'3532', N'Quỹ phúc lợi')
INSERT [dbo].[TaiKhoanCo] ([SoTaiKhoanCo], [TenTaiKhoan]) VALUES (N'3533', N'Quỹ phúc lợi đã hình thành TSCĐ')
INSERT [dbo].[TaiKhoanCo] ([SoTaiKhoanCo], [TenTaiKhoan]) VALUES (N'3534', N'Quỹ thưởng ban quản ký điều hành')
INSERT [dbo].[TaiKhoanCo] ([SoTaiKhoanCo], [TenTaiKhoan]) VALUES (N'3561', N'Quỹ phát triển khoa học và công nghệ')
INSERT [dbo].[TaiKhoanCo] ([SoTaiKhoanCo], [TenTaiKhoan]) VALUES (N'3562', N'Quỹ phát triển khoa học và công nghệ')
INSERT [dbo].[TaiKhoanCo] ([SoTaiKhoanCo], [TenTaiKhoan]) VALUES (N'357', N'Quỹ bình ổn giá')
INSERT [dbo].[TaiKhoanCo] ([SoTaiKhoanCo], [TenTaiKhoan]) VALUES (N'41111', N'Cổ phiếu phổ thông có quyền biểu')
INSERT [dbo].[TaiKhoanCo] ([SoTaiKhoanCo], [TenTaiKhoan]) VALUES (N'41112', N'Cổ phiếu ưu đãi')
INSERT [dbo].[TaiKhoanCo] ([SoTaiKhoanCo], [TenTaiKhoan]) VALUES (N'4112', N'Thặng dư vốn cổ phần')
INSERT [dbo].[TaiKhoanCo] ([SoTaiKhoanCo], [TenTaiKhoan]) VALUES (N'4113', N'Quyền chọn chuyển đổi trái phiếu')
INSERT [dbo].[TaiKhoanCo] ([SoTaiKhoanCo], [TenTaiKhoan]) VALUES (N'4118', N'Vốn khác')
INSERT [dbo].[TaiKhoanCo] ([SoTaiKhoanCo], [TenTaiKhoan]) VALUES (N'412', N'Chênh lệch đánh giá lại tài sản')
INSERT [dbo].[TaiKhoanCo] ([SoTaiKhoanCo], [TenTaiKhoan]) VALUES (N'4131', N'Chênh lệch tỷ giá do đánh giá lại các')
INSERT [dbo].[TaiKhoanCo] ([SoTaiKhoanCo], [TenTaiKhoan]) VALUES (N'4132', N'Chênh lệch tỷ giá hối đoái trong giai đoạn')
INSERT [dbo].[TaiKhoanCo] ([SoTaiKhoanCo], [TenTaiKhoan]) VALUES (N'414', N'Quỹ đầu tư phát triển')
INSERT [dbo].[TaiKhoanCo] ([SoTaiKhoanCo], [TenTaiKhoan]) VALUES (N'417', N'Quỹ hỗ trợ sắp xếp doanh nghiệp')
INSERT [dbo].[TaiKhoanCo] ([SoTaiKhoanCo], [TenTaiKhoan]) VALUES (N'418', N'Các quỹ khác thuộc vốn chủ sở hữu')
INSERT [dbo].[TaiKhoanCo] ([SoTaiKhoanCo], [TenTaiKhoan]) VALUES (N'419', N'Cổ phiếu quỹ')
INSERT [dbo].[TaiKhoanCo] ([SoTaiKhoanCo], [TenTaiKhoan]) VALUES (N'4211', N'Lợi nhuận sau thuế chưa phân phối')
INSERT [dbo].[TaiKhoanCo] ([SoTaiKhoanCo], [TenTaiKhoan]) VALUES (N'4212', N'Lợi nhuận sau thuế chưa phân phối')
INSERT [dbo].[TaiKhoanCo] ([SoTaiKhoanCo], [TenTaiKhoan]) VALUES (N'441', N'Nguồn vốn đầu tư xây dựng cơ bản')
INSERT [dbo].[TaiKhoanCo] ([SoTaiKhoanCo], [TenTaiKhoan]) VALUES (N'4611', N'Nguồn kinh phí sự nghiệp năm trước')
INSERT [dbo].[TaiKhoanCo] ([SoTaiKhoanCo], [TenTaiKhoan]) VALUES (N'4612', N'Nguồn kinh phí sự nghiệp năm nay')
INSERT [dbo].[TaiKhoanCo] ([SoTaiKhoanCo], [TenTaiKhoan]) VALUES (N'466', N'Nguồn kinh phí đã hình thành TSCĐ')
INSERT [dbo].[TaiKhoanCo] ([SoTaiKhoanCo], [TenTaiKhoan]) VALUES (N'5111', N'Doanh thu bán hàng hóa')
INSERT [dbo].[TaiKhoanCo] ([SoTaiKhoanCo], [TenTaiKhoan]) VALUES (N'5112', N'Doanh thu bán các thành phẩm')
INSERT [dbo].[TaiKhoanCo] ([SoTaiKhoanCo], [TenTaiKhoan]) VALUES (N'5113', N'Doanh thu cung cấp dịch vụ')
INSERT [dbo].[TaiKhoanCo] ([SoTaiKhoanCo], [TenTaiKhoan]) VALUES (N'5114', N'Doanh thu trợ cấp, trợ giá')
INSERT [dbo].[TaiKhoanCo] ([SoTaiKhoanCo], [TenTaiKhoan]) VALUES (N'5117', N'Doanh thu kinh doanh bất động sản')
INSERT [dbo].[TaiKhoanCo] ([SoTaiKhoanCo], [TenTaiKhoan]) VALUES (N'5118', N'Doanh thu khác')
INSERT [dbo].[TaiKhoanCo] ([SoTaiKhoanCo], [TenTaiKhoan]) VALUES (N'515', N'Doanh thu các hoạt động tài chính')
INSERT [dbo].[TaiKhoanCo] ([SoTaiKhoanCo], [TenTaiKhoan]) VALUES (N'5211', N'Chiết khấu thương mại')
INSERT [dbo].[TaiKhoanCo] ([SoTaiKhoanCo], [TenTaiKhoan]) VALUES (N'5212', N'Hàng bán bị trả lại')
INSERT [dbo].[TaiKhoanCo] ([SoTaiKhoanCo], [TenTaiKhoan]) VALUES (N'5213', N'Giảm giá hàng bán')
INSERT [dbo].[TaiKhoanCo] ([SoTaiKhoanCo], [TenTaiKhoan]) VALUES (N'6111', N'Mua nguyên liệu, vật liệu')
INSERT [dbo].[TaiKhoanCo] ([SoTaiKhoanCo], [TenTaiKhoan]) VALUES (N'6112', N'Mua hàng hóa')
INSERT [dbo].[TaiKhoanCo] ([SoTaiKhoanCo], [TenTaiKhoan]) VALUES (N'621', N'Chi phí nguyên liệu, vật liệu trực tiếp')
INSERT [dbo].[TaiKhoanCo] ([SoTaiKhoanCo], [TenTaiKhoan]) VALUES (N'622', N'Chi phí nhân công trực tiếp')
INSERT [dbo].[TaiKhoanCo] ([SoTaiKhoanCo], [TenTaiKhoan]) VALUES (N'6231', N'Chi phí nhân công')
INSERT [dbo].[TaiKhoanCo] ([SoTaiKhoanCo], [TenTaiKhoan]) VALUES (N'6232', N'Chi phí vật liệu')
INSERT [dbo].[TaiKhoanCo] ([SoTaiKhoanCo], [TenTaiKhoan]) VALUES (N'6233', N'Chi phí dụng cụ sản xuất')
INSERT [dbo].[TaiKhoanCo] ([SoTaiKhoanCo], [TenTaiKhoan]) VALUES (N'6234', N'Chi phí khẩu hao máy thi công')
INSERT [dbo].[TaiKhoanCo] ([SoTaiKhoanCo], [TenTaiKhoan]) VALUES (N'6237', N'Chi phí dịch vụ mua ngoài')
INSERT [dbo].[TaiKhoanCo] ([SoTaiKhoanCo], [TenTaiKhoan]) VALUES (N'6238', N'Chi phí bằng tiền khác')
INSERT [dbo].[TaiKhoanCo] ([SoTaiKhoanCo], [TenTaiKhoan]) VALUES (N'6271', N'Chi phí nhân viên phân xưởng')
INSERT [dbo].[TaiKhoanCo] ([SoTaiKhoanCo], [TenTaiKhoan]) VALUES (N'6272', N'chi phí vật liệu')
INSERT [dbo].[TaiKhoanCo] ([SoTaiKhoanCo], [TenTaiKhoan]) VALUES (N'6273', N'Chi phí dụng cụ sản xuất')
INSERT [dbo].[TaiKhoanCo] ([SoTaiKhoanCo], [TenTaiKhoan]) VALUES (N'6274', N'Chi phí khẩu hao TSCĐ')
INSERT [dbo].[TaiKhoanCo] ([SoTaiKhoanCo], [TenTaiKhoan]) VALUES (N'6277', N'Chi phí dịch vụ mua ngoài')
INSERT [dbo].[TaiKhoanCo] ([SoTaiKhoanCo], [TenTaiKhoan]) VALUES (N'6278', N'Chi phí bằng tiền khác')
INSERT [dbo].[TaiKhoanCo] ([SoTaiKhoanCo], [TenTaiKhoan]) VALUES (N'631', N'Giá thành sản xuất')
INSERT [dbo].[TaiKhoanCo] ([SoTaiKhoanCo], [TenTaiKhoan]) VALUES (N'632', N'Giá vốn hàng bán')
INSERT [dbo].[TaiKhoanCo] ([SoTaiKhoanCo], [TenTaiKhoan]) VALUES (N'635', N'Chi phí tài chính')
INSERT [dbo].[TaiKhoanCo] ([SoTaiKhoanCo], [TenTaiKhoan]) VALUES (N'6411', N'Chi phí nhân viên')
INSERT [dbo].[TaiKhoanCo] ([SoTaiKhoanCo], [TenTaiKhoan]) VALUES (N'6412', N'Chi phí vật liệu, bao bì')
INSERT [dbo].[TaiKhoanCo] ([SoTaiKhoanCo], [TenTaiKhoan]) VALUES (N'6413', N'Chi phí dụng cụ, đồ dùng')
INSERT [dbo].[TaiKhoanCo] ([SoTaiKhoanCo], [TenTaiKhoan]) VALUES (N'6414', N'Chi phí khẩu hao TSCĐ')
INSERT [dbo].[TaiKhoanCo] ([SoTaiKhoanCo], [TenTaiKhoan]) VALUES (N'6415', N'Chi phí bảo hành')
INSERT [dbo].[TaiKhoanCo] ([SoTaiKhoanCo], [TenTaiKhoan]) VALUES (N'6417', N'Chi phí dịch vụ mua ngoài')
INSERT [dbo].[TaiKhoanCo] ([SoTaiKhoanCo], [TenTaiKhoan]) VALUES (N'6418', N'Chi phí bằng tiền khác')
INSERT [dbo].[TaiKhoanCo] ([SoTaiKhoanCo], [TenTaiKhoan]) VALUES (N'6421', N'Chi phí nhân viên quản lý')
INSERT [dbo].[TaiKhoanCo] ([SoTaiKhoanCo], [TenTaiKhoan]) VALUES (N'6422', N'Chi phí vật liệu quản lý')
INSERT [dbo].[TaiKhoanCo] ([SoTaiKhoanCo], [TenTaiKhoan]) VALUES (N'6423', N'Chi phí đồ dùng văn phòng')
INSERT [dbo].[TaiKhoanCo] ([SoTaiKhoanCo], [TenTaiKhoan]) VALUES (N'6424', N'Chi phí khẩu hao TSCĐ')
INSERT [dbo].[TaiKhoanCo] ([SoTaiKhoanCo], [TenTaiKhoan]) VALUES (N'6425', N'Thuế, phí và lệ phí')
INSERT [dbo].[TaiKhoanCo] ([SoTaiKhoanCo], [TenTaiKhoan]) VALUES (N'6426', N'Chi phí dự phòng')
INSERT [dbo].[TaiKhoanCo] ([SoTaiKhoanCo], [TenTaiKhoan]) VALUES (N'6427', N'Chi phí dịch vụ mua ngoài')
INSERT [dbo].[TaiKhoanCo] ([SoTaiKhoanCo], [TenTaiKhoan]) VALUES (N'6428', N'Chi phí bằng tiền khác')
INSERT [dbo].[TaiKhoanCo] ([SoTaiKhoanCo], [TenTaiKhoan]) VALUES (N'711', N'Thu nhập khác')
INSERT [dbo].[TaiKhoanCo] ([SoTaiKhoanCo], [TenTaiKhoan]) VALUES (N'811', N'Chi phí khác')
INSERT [dbo].[TaiKhoanCo] ([SoTaiKhoanCo], [TenTaiKhoan]) VALUES (N'8211', N'Chi phí thuế TNDN hiện hành')
INSERT [dbo].[TaiKhoanCo] ([SoTaiKhoanCo], [TenTaiKhoan]) VALUES (N'8212', N'Chi phí thuế TNDN hoãn lại')
INSERT [dbo].[TaiKhoanCo] ([SoTaiKhoanCo], [TenTaiKhoan]) VALUES (N'911', N'Xác định kết quả kinh doanh')
SET IDENTITY_INSERT [dbo].[TaiKhoanKetChuyen] ON 

INSERT [dbo].[TaiKhoanKetChuyen] ([Id], [ThuTuKetChuyen], [MaKetChuyen], [KetChuyenTu], [KetChuyenDen], [BenKetChuyen], [DienGiai], [LoaiKetChuyen], [NgungTheoDoi]) VALUES (1, 24, N'4131-515', N'4131', N'515', N'Có', N'kết chuyển lãi chênh lệch tỷ giá hồi đối', N'Kết chuyển xác định kết quả kinh doanh', 1)
INSERT [dbo].[TaiKhoanKetChuyen] ([Id], [ThuTuKetChuyen], [MaKetChuyen], [KetChuyenTu], [KetChuyenDen], [BenKetChuyen], [DienGiai], [LoaiKetChuyen], [NgungTheoDoi]) VALUES (2, 5, N'655-255', N'655', N'255', N'Có', N'kết chuyển chi phí nguyên vật liệu', N'Kết chuyển nguyên vật liệu', 1)
SET IDENTITY_INSERT [dbo].[TaiKhoanKetChuyen] OFF
INSERT [dbo].[TaiKhoanNo] ([SoTaiKhoanNo], [TenTaiKhoan]) VALUES (N'1111', N'Tiền Việt Nam')
INSERT [dbo].[TaiKhoanNo] ([SoTaiKhoanNo], [TenTaiKhoan]) VALUES (N'1112', N'Ngoại tệ')
INSERT [dbo].[TaiKhoanNo] ([SoTaiKhoanNo], [TenTaiKhoan]) VALUES (N'1113', N'Vàng ngoại tệ')
INSERT [dbo].[TaiSan] ([MaTaiSan], [NgayNhap], [NgayBatDauSuDung], [NgayHetHan], [MaCoSo], [KieuTaiSan], [MoTaChiTiet], [TinhTrang], [NgayNhapLieu], [NguoiNhap]) VALUES (N'000001', CAST(N'2020-08-21' AS Date), CAST(N'2020-08-20' AS Date), CAST(N'2021-05-21' AS Date), N'002', N'Máy tính', N'MacBook Pro 2019 Reconditionné màu bạc,Touch bar, màn hình Retina 13-inch, Processeur 1,4 GHz Intel core i5 quatre coeurs, Mémoire 8GB 2133MHz LPDDR3, Graphisme Intel Iris Plus Graphics 645 1536MB, ổ cứng 128 GB SSD, bàn phím tiếng Pháp AZERTY', N'Máy mới', CAST(N'2020-08-04' AS Date), N'0001')
INSERT [dbo].[TaiSan] ([MaTaiSan], [NgayNhap], [NgayBatDauSuDung], [NgayHetHan], [MaCoSo], [KieuTaiSan], [MoTaChiTiet], [TinhTrang], [NgayNhapLieu], [NguoiNhap]) VALUES (N'000002', CAST(N'2020-08-20' AS Date), CAST(N'2020-08-28' AS Date), CAST(N'2020-08-21' AS Date), N'003', N'Máy in', N'MacBook Pro 2019 Reconditionné màu bạc,Touch bar, màn hình Retina 13-inch, Processeur 1,4 GHz Intel core i5 quatre coeurs, Mémoire 8GB 2133MHz LPDDR3, Graphisme Intel Iris Plus Graphics 645 1536MB, ổ cứng 128 GB SSD, bàn phím tiếng Pháp AZERTY', N'Máy mới', CAST(N'2020-08-04' AS Date), N'0001')
INSERT [dbo].[TaiSan] ([MaTaiSan], [NgayNhap], [NgayBatDauSuDung], [NgayHetHan], [MaCoSo], [KieuTaiSan], [MoTaChiTiet], [TinhTrang], [NgayNhapLieu], [NguoiNhap]) VALUES (N'000003', CAST(N'2020-08-20' AS Date), CAST(N'2020-08-20' AS Date), CAST(N'2020-08-27' AS Date), N'002', N'Máy chiếu', N'MacBook Pro 2019 Reconditionné màu bạc,Touch bar, màn hình Retina 13-inch, Processeur 1,4 GHz Intel core i5 quatre coeurs, Mémoire 8GB 2133MHz LPDDR3, Graphisme Intel Iris Plus Graphics 645 1536MB, ổ cứng 128 GB SSD, bàn phím tiếng Pháp AZERTY', N'Máy mới', CAST(N'2020-08-04' AS Date), N'0001')
INSERT [dbo].[TaiSan] ([MaTaiSan], [NgayNhap], [NgayBatDauSuDung], [NgayHetHan], [MaCoSo], [KieuTaiSan], [MoTaChiTiet], [TinhTrang], [NgayNhapLieu], [NguoiNhap]) VALUES (N'000004', CAST(N'2020-08-14' AS Date), CAST(N'2020-08-20' AS Date), CAST(N'2020-08-20' AS Date), N'001', N'Máy tính', N'MacBook Pro 2019 Reconditionné màu bạc,Touch bar, màn hình Retina 13-inch, Processeur 1,4 GHz Intel core i5 quatre coeurs, Mémoire 8GB 2133MHz LPDDR3, Graphisme Intel Iris Plus Graphics 645 1536MB, ổ cứng 128 GB SSD, bàn phím tiếng Pháp AZERTY', N'Mới', CAST(N'2020-08-04' AS Date), N'0001')
INSERT [dbo].[TaiSan] ([MaTaiSan], [NgayNhap], [NgayBatDauSuDung], [NgayHetHan], [MaCoSo], [KieuTaiSan], [MoTaChiTiet], [TinhTrang], [NgayNhapLieu], [NguoiNhap]) VALUES (N'000005', CAST(N'2020-08-20' AS Date), CAST(N'2020-08-21' AS Date), CAST(N'2020-08-20' AS Date), N'002', N'Máy tính', N'MacBook Pro 2019 Reconditionné màu bạc,Touch bar, màn hình Retina 13-inch, Processeur 1,4 GHz Intel core i5 quatre coeurs, Mémoire 8GB 2133MHz LPDDR3, Graphisme Intel Iris Plus Graphics 645 1536MB, ổ cứng 128 GB SSD, bàn phím tiếng Pháp AZERTY', N'Mới', CAST(N'2020-08-04' AS Date), N'0001')
INSERT [dbo].[TaiSan] ([MaTaiSan], [NgayNhap], [NgayBatDauSuDung], [NgayHetHan], [MaCoSo], [KieuTaiSan], [MoTaChiTiet], [TinhTrang], [NgayNhapLieu], [NguoiNhap]) VALUES (N'000006', CAST(N'2020-08-20' AS Date), CAST(N'2020-08-21' AS Date), CAST(N'2020-08-13' AS Date), N'003', N'Máy in', N'MacBook Pro 2019 Reconditionné màu bạc,Touch bar, màn hình Retina 13-inch, Processeur 1,4 GHz Intel core i5 quatre coeurs, Mémoire 8GB 2133MHz LPDDR3, Graphisme Intel Iris Plus Graphics 645 1536MB, ổ cứng 128 GB SSD, bàn phím tiếng Pháp AZERTY', N'Máy mới', CAST(N'2020-08-04' AS Date), N'0001')
INSERT [dbo].[TaiSan] ([MaTaiSan], [NgayNhap], [NgayBatDauSuDung], [NgayHetHan], [MaCoSo], [KieuTaiSan], [MoTaChiTiet], [TinhTrang], [NgayNhapLieu], [NguoiNhap]) VALUES (N'000007', CAST(N'2020-08-05' AS Date), CAST(N'2020-08-21' AS Date), CAST(N'2020-08-28' AS Date), N'002', N'Máy in', N'MacBook Pro 2019 Reconditionné màu bạc,Touch bar, màn hình Retina 13-inch, Processeur 1,4 GHz Intel core i5 quatre coeurs, Mémoire 8GB 2133MHz LPDDR3, Graphisme Intel Iris Plus Graphics 645 1536MB, ổ cứng 128 GB SSD, bàn phím tiếng Pháp AZERTY', N'Máy mới', CAST(N'2020-08-04' AS Date), N'0001')
INSERT [dbo].[TaiSan] ([MaTaiSan], [NgayNhap], [NgayBatDauSuDung], [NgayHetHan], [MaCoSo], [KieuTaiSan], [MoTaChiTiet], [TinhTrang], [NgayNhapLieu], [NguoiNhap]) VALUES (N'000008', CAST(N'2020-08-20' AS Date), CAST(N'2020-08-21' AS Date), CAST(N'2020-08-20' AS Date), N'001', N'Máy chiếu', N'MacBook Pro 2019 Reconditionné màu bạc,Touch bar, màn hình Retina 13-inch, Processeur 1,4 GHz Intel core i5 quatre coeurs, Mémoire 8GB 2133MHz LPDDR3, Graphisme Intel Iris Plus Graphics 645 1536MB, ổ cứng 128 GB SSD, bàn phím tiếng Pháp AZERTY', N'Máy mới', CAST(N'2020-08-04' AS Date), N'0001')
INSERT [dbo].[TaiSan] ([MaTaiSan], [NgayNhap], [NgayBatDauSuDung], [NgayHetHan], [MaCoSo], [KieuTaiSan], [MoTaChiTiet], [TinhTrang], [NgayNhapLieu], [NguoiNhap]) VALUES (N'000009', CAST(N'2020-08-06' AS Date), CAST(N'2020-08-20' AS Date), CAST(N'2021-10-22' AS Date), N'001', N'Máy từ', N'Máy từ', N'Máy mới', CAST(N'2020-08-04' AS Date), N'0001')
INSERT [dbo].[TaiSan] ([MaTaiSan], [NgayNhap], [NgayBatDauSuDung], [NgayHetHan], [MaCoSo], [KieuTaiSan], [MoTaChiTiet], [TinhTrang], [NgayNhapLieu], [NguoiNhap]) VALUES (N'000010', CAST(N'2020-08-11' AS Date), CAST(N'2020-08-15' AS Date), CAST(N'2020-08-09' AS Date), N'001', N'ăd', N'ăd', N'ăd', CAST(N'2020-08-05' AS Date), N'0001')
INSERT [dbo].[TaiSan] ([MaTaiSan], [NgayNhap], [NgayBatDauSuDung], [NgayHetHan], [MaCoSo], [KieuTaiSan], [MoTaChiTiet], [TinhTrang], [NgayNhapLieu], [NguoiNhap]) VALUES (N'000011', CAST(N'2020-08-13' AS Date), CAST(N'2020-08-21' AS Date), CAST(N'2020-08-20' AS Date), N'002', N'sấd', N'dâd', N'dâdadadad', CAST(N'2020-08-07' AS Date), N'0001')
INSERT [dbo].[TaiSan] ([MaTaiSan], [NgayNhap], [NgayBatDauSuDung], [NgayHetHan], [MaCoSo], [KieuTaiSan], [MoTaChiTiet], [TinhTrang], [NgayNhapLieu], [NguoiNhap]) VALUES (N'000012', CAST(N'2020-08-06' AS Date), CAST(N'2020-08-09' AS Date), CAST(N'2020-08-05' AS Date), N'001', N'Kiểu 1', N'mô tả', N'tốt', CAST(N'2020-08-07' AS Date), N'0001')
INSERT [dbo].[ThanhPham] ([MaThanhPham], [TenThanhPham], [DonViTinh], [HopDongBan], [DoiTuongDHCP], [MaThongKe], [DonDatHang]) VALUES (N'TP0001', N'Thành phẩm 1', N'Chiếc', N'123', N'Đối tượng 1', N'Mã 1', N'Đơn 1')
INSERT [dbo].[ThanhPham] ([MaThanhPham], [TenThanhPham], [DonViTinh], [HopDongBan], [DoiTuongDHCP], [MaThongKe], [DonDatHang]) VALUES (N'TP0002', N'Thành phẩm 2', N'Cái', N'456', N'Đối tượng 2', N'Mã 2', N'Đơn 2')
INSERT [dbo].[ThanhPham] ([MaThanhPham], [TenThanhPham], [DonViTinh], [HopDongBan], [DoiTuongDHCP], [MaThongKe], [DonDatHang]) VALUES (N'TP0003', N'Thành phẩm 3', N'Thùng', N'789', N'Đối tượng 3', N'Mã 3', N'Đơn 3')
SET IDENTITY_INSERT [dbo].[The] ON 

INSERT [dbo].[The] ([ID], [MaSoNhanVien], [MaThe], [LoaiThe], [NgayYeuCau], [NgayCap], [NgayHetHan], [TrangThai]) VALUES (1, N'0001', N'0001', N'thẻ atm', CAST(N'1969-12-29' AS Date), CAST(N'1969-12-29' AS Date), CAST(N'2020-08-29' AS Date), NULL)
SET IDENTITY_INSERT [dbo].[The] OFF
INSERT [dbo].[ThongBao] ([MaSoTB], [TieuDe], [NoiDung], [GhiChu], [NgayTao], [NgayThongBao], [DaXoa], [NguoiXoa], [ThoiGianXoa]) VALUES (1, NULL, N'Thông báo Về việc thu học phí hệ Đào tạo Chính quy; hệ VLVH học kỳ 2 năm học 2019-2020', NULL, NULL, CAST(N'2020-04-24T00:00:00.000' AS DateTime), NULL, NULL, NULL)
INSERT [dbo].[ThongBao] ([MaSoTB], [TieuDe], [NoiDung], [GhiChu], [NgayTao], [NgayThongBao], [DaXoa], [NguoiXoa], [ThoiGianXoa]) VALUES (2, NULL, N'Thông báo Về việc nghỉ học phòng ngừa dịch bệnh viêm đường hô hấp cấp do chủng mới của viruts Corona (nCov)', NULL, NULL, CAST(N'2020-04-24T00:00:00.000' AS DateTime), NULL, NULL, NULL)
INSERT [dbo].[ThongBao] ([MaSoTB], [TieuDe], [NoiDung], [GhiChu], [NgayTao], [NgayThongBao], [DaXoa], [NguoiXoa], [ThoiGianXoa]) VALUES (3, NULL, N'Thông báo đăng ký đề tài nghiên cứu khoa học sinh viên năm 2015 khoa Công nghệ Thông', NULL, NULL, CAST(N'2020-04-24T00:00:00.003' AS DateTime), NULL, NULL, NULL)
INSERT [dbo].[ThongBao] ([MaSoTB], [TieuDe], [NoiDung], [GhiChu], [NgayTao], [NgayThongBao], [DaXoa], [NguoiXoa], [ThoiGianXoa]) VALUES (4, NULL, N'test', NULL, NULL, CAST(N'2020-04-24T00:00:00.003' AS DateTime), NULL, NULL, NULL)
INSERT [dbo].[ThongBao] ([MaSoTB], [TieuDe], [NoiDung], [GhiChu], [NgayTao], [NgayThongBao], [DaXoa], [NguoiXoa], [ThoiGianXoa]) VALUES (5, NULL, N'dddddddddddd', NULL, NULL, CAST(N'2020-04-24T00:00:00.003' AS DateTime), NULL, NULL, NULL)
INSERT [dbo].[ThongBao] ([MaSoTB], [TieuDe], [NoiDung], [GhiChu], [NgayTao], [NgayThongBao], [DaXoa], [NguoiXoa], [ThoiGianXoa]) VALUES (6, NULL, N'Thông báo đăng ký đề tài nghiên cứu khoa học sinh viên năm 2015 khoa Công nghệ Thông', NULL, NULL, CAST(N'2020-04-24T00:00:00.007' AS DateTime), NULL, NULL, NULL)
INSERT [dbo].[ThongBao] ([MaSoTB], [TieuDe], [NoiDung], [GhiChu], [NgayTao], [NgayThongBao], [DaXoa], [NguoiXoa], [ThoiGianXoa]) VALUES (7, NULL, N'Thông báo đăng ký đề tài nghiên cứu khoa học sinh viên năm 2015 khoa Công nghệ Thông', NULL, NULL, CAST(N'2020-04-24T00:00:00.007' AS DateTime), NULL, NULL, NULL)
INSERT [dbo].[ThongBao] ([MaSoTB], [TieuDe], [NoiDung], [GhiChu], [NgayTao], [NgayThongBao], [DaXoa], [NguoiXoa], [ThoiGianXoa]) VALUES (8, NULL, N'Thông báo đăng ký đề tài nghiên cứu khoa học sinh viên năm 2015 khoa Công nghệ Thông', NULL, NULL, CAST(N'2020-04-24T00:00:00.007' AS DateTime), NULL, NULL, NULL)
INSERT [dbo].[ThongBao] ([MaSoTB], [TieuDe], [NoiDung], [GhiChu], [NgayTao], [NgayThongBao], [DaXoa], [NguoiXoa], [ThoiGianXoa]) VALUES (9, NULL, N'Thông báo đăng ký đề tài nghiên cứu khoa học sinh viên năm 2015 khoa Công nghệ Thông', NULL, NULL, CAST(N'2020-04-24T00:00:00.007' AS DateTime), NULL, NULL, NULL)
INSERT [dbo].[ThongBao] ([MaSoTB], [TieuDe], [NoiDung], [GhiChu], [NgayTao], [NgayThongBao], [DaXoa], [NguoiXoa], [ThoiGianXoa]) VALUES (10, NULL, N'dwadadwadaw', NULL, NULL, CAST(N'2020-04-24T00:00:00.010' AS DateTime), NULL, NULL, NULL)
INSERT [dbo].[ThongTinCaNhan] ([MaSoVC], [HoTen], [NgaySinh], [DiaChi], [DienThoai], [Email], [NghiViec], [DaXoa], [NguoiXoa], [ThoiGianXoa], [MaPK], [Phai], [SHCC], [CMND], [NgayCap], [NoiCap], [MST], [QuocTich], [DanToc], [SoTaiKhoan], [NganHang], [ChiNhanh], [ChucVu], [CQCongTac], [DiaChiCQ], [WebsiteCQ], [LanhDaoCQ], [DienThoaiCQ], [DienThoaiLanhDao], [NamBatDauCongTac], [NamNghiHuu], [HocVu], [NamDat], [NuocTotNghiep], [ChuyenNganh], [ChuyenMonHienTai], [HocHam], [NamCongNhan], [ChucDanh], [Hinh]) VALUES (N'01', N'Tran Van Anh', CAST(N'2020-12-12' AS Date), N'Kien GIang', N'113', N'tranvana2gmail.com', NULL, NULL, NULL, NULL, N'00', N'Nam', N'25        ', N'37036061', CAST(N'2020-07-25' AS Date), N'Công An tỉnh Kiên Giang', N'250       ', N'Vietnam', N'Kinh', N'0515515150', N'VietCombank', N'KienGaing', N'VienChuc', N'đại học bách khoa hà nội', N'20 hai bà Trung', N'www.edu.vn', N'NguyenvanA', N'0528295789', N'0527894552', CAST(N'2020-07-22' AS Date), CAST(N'2020-07-23' AS Date), N'A', N'2021', N'Pháp', N'Kĩ tuật phần mềm', N'lập trình Viên', N'ABC', N'2021', N'Giám Đốc abc', N'/Assets/giaovien/img/files/download.png')
INSERT [dbo].[ThongTinCaNhan] ([MaSoVC], [HoTen], [NgaySinh], [DiaChi], [DienThoai], [Email], [NghiViec], [DaXoa], [NguoiXoa], [ThoiGianXoa], [MaPK], [Phai], [SHCC], [CMND], [NgayCap], [NoiCap], [MST], [QuocTich], [DanToc], [SoTaiKhoan], [NganHang], [ChiNhanh], [ChucVu], [CQCongTac], [DiaChiCQ], [WebsiteCQ], [LanhDaoCQ], [DienThoaiCQ], [DienThoaiLanhDao], [NamBatDauCongTac], [NamNghiHuu], [HocVu], [NamDat], [NuocTotNghiep], [ChuyenNganh], [ChuyenMonHienTai], [HocHam], [NamCongNhan], [ChucDanh], [Hinh]) VALUES (N'02', N'Tran Van C', NULL, N'Kien GIang', N'113', N'tranvana2gmail.com', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[ThongTinCaNhan] ([MaSoVC], [HoTen], [NgaySinh], [DiaChi], [DienThoai], [Email], [NghiViec], [DaXoa], [NguoiXoa], [ThoiGianXoa], [MaPK], [Phai], [SHCC], [CMND], [NgayCap], [NoiCap], [MST], [QuocTich], [DanToc], [SoTaiKhoan], [NganHang], [ChiNhanh], [ChucVu], [CQCongTac], [DiaChiCQ], [WebsiteCQ], [LanhDaoCQ], [DienThoaiCQ], [DienThoaiLanhDao], [NamBatDauCongTac], [NamNghiHuu], [HocVu], [NamDat], [NuocTotNghiep], [ChuyenNganh], [ChuyenMonHienTai], [HocHam], [NamCongNhan], [ChucDanh], [Hinh]) VALUES (N'113', N'ădad', CAST(N'2020-07-15' AS Date), N'123', N'12313132', N'uttruong2015@gmail.com', NULL, NULL, NULL, NULL, NULL, N'Nam', NULL, N'1231223123', CAST(N'2020-07-23' AS Date), N'ădaaaaaaaa', N'123       ', N'adawdawd', N'gsdgs', N'123131', N'gsg', N'gsg', N'gsg', N'123', N'ăd', N'https://localhost:44308/giaovien#/xemthoikhoabieu', N'123', N'123', N'123', CAST(N'2020-07-22' AS Date), CAST(N'2020-07-25' AS Date), N'gsg', N'1213', N'gsg', N'aădaaaaaaaa', N'gsg', N'ădaaaaaaaa', N'123', N'123', NULL)
INSERT [dbo].[ThongTinCaNhan] ([MaSoVC], [HoTen], [NgaySinh], [DiaChi], [DienThoai], [Email], [NghiViec], [DaXoa], [NguoiXoa], [ThoiGianXoa], [MaPK], [Phai], [SHCC], [CMND], [NgayCap], [NoiCap], [MST], [QuocTich], [DanToc], [SoTaiKhoan], [NganHang], [ChiNhanh], [ChucVu], [CQCongTac], [DiaChiCQ], [WebsiteCQ], [LanhDaoCQ], [DienThoaiCQ], [DienThoaiLanhDao], [NamBatDauCongTac], [NamNghiHuu], [HocVu], [NamDat], [NuocTotNghiep], [ChuyenNganh], [ChuyenMonHienTai], [HocHam], [NamCongNhan], [ChucDanh], [Hinh]) VALUES (N'114', N'ădad', CAST(N'2020-07-11' AS Date), N'gsg', N'12313132', N'uttruong2015@gmail.com', NULL, NULL, NULL, NULL, NULL, N'Nam', NULL, N'1231223123', CAST(N'2020-07-07' AS Date), N'adwad', N'gsg       ', N'ădada', N'gsdgs', N'23123123', N'adfafsfasf', N'adfafsfasf', N'123', N'ădaaaaaaaa', N'ădaaaaaaaa', N'https://localhost:44308/giaovien#/xemthoikhoabieu', N'123', N'123', N'23123', CAST(N'2020-07-21' AS Date), CAST(N'2020-07-24' AS Date), N'gsg', N'1213', N'123', N'aădaaaaaaaa', N'123', N'ădaaaaaaaa', N'12313', N'12313', NULL)
INSERT [dbo].[ThongTinCaNhan] ([MaSoVC], [HoTen], [NgaySinh], [DiaChi], [DienThoai], [Email], [NghiViec], [DaXoa], [NguoiXoa], [ThoiGianXoa], [MaPK], [Phai], [SHCC], [CMND], [NgayCap], [NoiCap], [MST], [QuocTich], [DanToc], [SoTaiKhoan], [NganHang], [ChiNhanh], [ChucVu], [CQCongTac], [DiaChiCQ], [WebsiteCQ], [LanhDaoCQ], [DienThoaiCQ], [DienThoaiLanhDao], [NamBatDauCongTac], [NamNghiHuu], [HocVu], [NamDat], [NuocTotNghiep], [ChuyenNganh], [ChuyenMonHienTai], [HocHam], [NamCongNhan], [ChucDanh], [Hinh]) VALUES (N'123', N'ădad', CAST(N'2020-07-14' AS Date), N'gsg', N'12313132', N'uttruong2015@gmail.com', NULL, NULL, NULL, NULL, NULL, N'Nam', NULL, N'1231223123', CAST(N'2020-07-14' AS Date), N'adwad', N'12313     ', N'adwadadw', N'ădawdwa', N'23123123', N'âdwawdw', N'ădawd', N'adawdad', N'ădawd', N'ădaaaaaaaa', N'https://localhost:44308/giaovien#/xemthoikhoabieu', N'123', N'123', N'123', CAST(N'2020-07-23' AS Date), CAST(N'2020-07-30' AS Date), N'gsg', N'1213', N'ădawd', N'aădaaaaaaaa', N'ădaaaaaaaa', N'ădaaaaaaaa', N'123', N'ădaaaaaaaa', NULL)
INSERT [dbo].[ThongTinCaNhan] ([MaSoVC], [HoTen], [NgaySinh], [DiaChi], [DienThoai], [Email], [NghiViec], [DaXoa], [NguoiXoa], [ThoiGianXoa], [MaPK], [Phai], [SHCC], [CMND], [NgayCap], [NoiCap], [MST], [QuocTich], [DanToc], [SoTaiKhoan], [NganHang], [ChiNhanh], [ChucVu], [CQCongTac], [DiaChiCQ], [WebsiteCQ], [LanhDaoCQ], [DienThoaiCQ], [DienThoaiLanhDao], [NamBatDauCongTac], [NamNghiHuu], [HocVu], [NamDat], [NuocTotNghiep], [ChuyenNganh], [ChuyenMonHienTai], [HocHam], [NamCongNhan], [ChucDanh], [Hinh]) VALUES (N'1308', N'Tran Van Admin', CAST(N'2020-07-17' AS Date), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'Nam', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(N'2020-07-12' AS Date), CAST(N'2020-07-25' AS Date), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[ThongTinCaNhan] ([MaSoVC], [HoTen], [NgaySinh], [DiaChi], [DienThoai], [Email], [NghiViec], [DaXoa], [NguoiXoa], [ThoiGianXoa], [MaPK], [Phai], [SHCC], [CMND], [NgayCap], [NoiCap], [MST], [QuocTich], [DanToc], [SoTaiKhoan], [NganHang], [ChiNhanh], [ChucVu], [CQCongTac], [DiaChiCQ], [WebsiteCQ], [LanhDaoCQ], [DienThoaiCQ], [DienThoaiLanhDao], [NamBatDauCongTac], [NamNghiHuu], [HocVu], [NamDat], [NuocTotNghiep], [ChuyenNganh], [ChuyenMonHienTai], [HocHam], [NamCongNhan], [ChucDanh], [Hinh]) VALUES (N'3167', N'Tran Van A', CAST(N'2020-07-01' AS Date), N'gsg', N'123123', N'awd@gmail.com', NULL, NULL, NULL, NULL, NULL, N'Nam', NULL, N'1231223123', CAST(N'2020-07-07' AS Date), N'Kien Giang', N'12313     ', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'123', NULL, CAST(N'2020-07-09' AS Date), CAST(N'2020-07-17' AS Date), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[ThongTinCaNhan] ([MaSoVC], [HoTen], [NgaySinh], [DiaChi], [DienThoai], [Email], [NghiViec], [DaXoa], [NguoiXoa], [ThoiGianXoa], [MaPK], [Phai], [SHCC], [CMND], [NgayCap], [NoiCap], [MST], [QuocTich], [DanToc], [SoTaiKhoan], [NganHang], [ChiNhanh], [ChucVu], [CQCongTac], [DiaChiCQ], [WebsiteCQ], [LanhDaoCQ], [DienThoaiCQ], [DienThoaiLanhDao], [NamBatDauCongTac], [NamNghiHuu], [HocVu], [NamDat], [NuocTotNghiep], [ChuyenNganh], [ChuyenMonHienTai], [HocHam], [NamCongNhan], [ChucDanh], [Hinh]) VALUES (N'45454545', N'fdsgdg', CAST(N'2020-07-09' AS Date), N'agagg', N'32555', N'uttruong2015@gmail.com', NULL, NULL, NULL, NULL, NULL, N'Nữ', NULL, N'45545', CAST(N'2020-07-22' AS Date), N'xcvxcgxc', N'bxgfg     ', N'gsdgsdgdsg', N'gsdg', N'425454', N'gdsg', N'gd', N'gsdg', N'gdsgsdgsd', N'gdsg', N'http://dffgdg', N'gdsggdgsd', N'sdggdsg', N'gdsgsdgdsgsdg', CAST(N'2020-07-10' AS Date), CAST(N'2020-07-21' AS Date), N'gsdgsdg', N'454545', N'dgdg', N'gsdgs', N'sdgsg', N'gsdgsd', N'325235', N'dsggs', NULL)
SET IDENTITY_INSERT [dbo].[ThongTinTuyenDung] ON 

INSERT [dbo].[ThongTinTuyenDung] ([ID], [MaSoNhanVien], [NgayTuyen], [LoaiHopDong], [DiaDiemLamViec], [NgayBatDau], [NgayKetThuc], [HinhThucLuong], [SoTienLuong]) VALUES (20, N'0001', CAST(N'2020-07-31' AS Date), N'Loại hợp đồng', N'Kiên Giang', CAST(N'2020-07-28' AS Date), CAST(N'2020-08-02' AS Date), N'Hình thức lương', N'5000000')
INSERT [dbo].[ThongTinTuyenDung] ([ID], [MaSoNhanVien], [NgayTuyen], [LoaiHopDong], [DiaDiemLamViec], [NgayBatDau], [NgayKetThuc], [HinhThucLuong], [SoTienLuong]) VALUES (21, N'0002', NULL, N'Loại hợp đồng', N'Kiên Giang', CAST(N'2020-07-29' AS Date), CAST(N'2020-08-03' AS Date), N'Hình thức lương', N'5000001')
INSERT [dbo].[ThongTinTuyenDung] ([ID], [MaSoNhanVien], [NgayTuyen], [LoaiHopDong], [DiaDiemLamViec], [NgayBatDau], [NgayKetThuc], [HinhThucLuong], [SoTienLuong]) VALUES (22, N'0003', NULL, N'Loại hợp đồng', N'Kiên Giang', CAST(N'2020-07-30' AS Date), CAST(N'2020-08-04' AS Date), N'Hình thức lương', N'5000002')
INSERT [dbo].[ThongTinTuyenDung] ([ID], [MaSoNhanVien], [NgayTuyen], [LoaiHopDong], [DiaDiemLamViec], [NgayBatDau], [NgayKetThuc], [HinhThucLuong], [SoTienLuong]) VALUES (23, N'0004', NULL, N'Loại hợp đồng', N'Kiên Giang', CAST(N'2020-07-31' AS Date), CAST(N'2020-08-05' AS Date), N'Hình thức lương', N'5000003')
INSERT [dbo].[ThongTinTuyenDung] ([ID], [MaSoNhanVien], [NgayTuyen], [LoaiHopDong], [DiaDiemLamViec], [NgayBatDau], [NgayKetThuc], [HinhThucLuong], [SoTienLuong]) VALUES (24, N'0005', NULL, N'Loại hợp đồng', N'Kiên Giang', NULL, CAST(N'2020-08-06' AS Date), N'Hình thức lương', N'5000004')
INSERT [dbo].[ThongTinTuyenDung] ([ID], [MaSoNhanVien], [NgayTuyen], [LoaiHopDong], [DiaDiemLamViec], [NgayBatDau], [NgayKetThuc], [HinhThucLuong], [SoTienLuong]) VALUES (25, N'0006', NULL, N'Loại hợp đồng', N'Kiên Giang', NULL, CAST(N'2020-08-07' AS Date), N'Hình thức lương', N'5000005')
INSERT [dbo].[ThongTinTuyenDung] ([ID], [MaSoNhanVien], [NgayTuyen], [LoaiHopDong], [DiaDiemLamViec], [NgayBatDau], [NgayKetThuc], [HinhThucLuong], [SoTienLuong]) VALUES (26, N'0007', NULL, N'Loại hợp đồng', N'Kiên Giang', NULL, CAST(N'2020-08-08' AS Date), N'Hình thức lương', N'5000006')
INSERT [dbo].[ThongTinTuyenDung] ([ID], [MaSoNhanVien], [NgayTuyen], [LoaiHopDong], [DiaDiemLamViec], [NgayBatDau], [NgayKetThuc], [HinhThucLuong], [SoTienLuong]) VALUES (27, N'0008', NULL, N'Loại hợp đồng', N'Kiên Giang', NULL, CAST(N'2020-08-09' AS Date), N'Hình thức lương', N'5000007')
INSERT [dbo].[ThongTinTuyenDung] ([ID], [MaSoNhanVien], [NgayTuyen], [LoaiHopDong], [DiaDiemLamViec], [NgayBatDau], [NgayKetThuc], [HinhThucLuong], [SoTienLuong]) VALUES (28, N'0009', NULL, N'Loại hợp đồng', N'Kiên Giang', NULL, CAST(N'2020-08-10' AS Date), N'Hình thức lương', N'5000008')
INSERT [dbo].[ThongTinTuyenDung] ([ID], [MaSoNhanVien], [NgayTuyen], [LoaiHopDong], [DiaDiemLamViec], [NgayBatDau], [NgayKetThuc], [HinhThucLuong], [SoTienLuong]) VALUES (29, N'0010', NULL, N'Loại hợp đồng', N'Kiên Giang', NULL, CAST(N'2020-08-11' AS Date), N'Hình thức lương', N'5000009')
INSERT [dbo].[ThongTinTuyenDung] ([ID], [MaSoNhanVien], [NgayTuyen], [LoaiHopDong], [DiaDiemLamViec], [NgayBatDau], [NgayKetThuc], [HinhThucLuong], [SoTienLuong]) VALUES (30, N'0012', NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[ThongTinTuyenDung] ([ID], [MaSoNhanVien], [NgayTuyen], [LoaiHopDong], [DiaDiemLamViec], [NgayBatDau], [NgayKetThuc], [HinhThucLuong], [SoTienLuong]) VALUES (31, N'0013', NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[ThongTinTuyenDung] ([ID], [MaSoNhanVien], [NgayTuyen], [LoaiHopDong], [DiaDiemLamViec], [NgayBatDau], [NgayKetThuc], [HinhThucLuong], [SoTienLuong]) VALUES (32, N'0014', NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[ThongTinTuyenDung] ([ID], [MaSoNhanVien], [NgayTuyen], [LoaiHopDong], [DiaDiemLamViec], [NgayBatDau], [NgayKetThuc], [HinhThucLuong], [SoTienLuong]) VALUES (33, N'0015', NULL, NULL, NULL, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[ThongTinTuyenDung] OFF
SET IDENTITY_INSERT [dbo].[TinhChatHangHoa] ON 

INSERT [dbo].[TinhChatHangHoa] ([MaTinhChat], [TenTinhChat], [GhiChu]) VALUES (1, N'Dịch vụ', NULL)
INSERT [dbo].[TinhChatHangHoa] ([MaTinhChat], [TenTinhChat], [GhiChu]) VALUES (2, N'Vật tư hàng hóa', NULL)
INSERT [dbo].[TinhChatHangHoa] ([MaTinhChat], [TenTinhChat], [GhiChu]) VALUES (3, N'Thành phẩm', NULL)
SET IDENTITY_INSERT [dbo].[TinhChatHangHoa] OFF
SET IDENTITY_INSERT [dbo].[TinhTrang] ON 

INSERT [dbo].[TinhTrang] ([MaTinhTrang], [TenTinhTrang], [GhiChu]) VALUES (1, N'Đang thực hiện', NULL)
INSERT [dbo].[TinhTrang] ([MaTinhTrang], [TenTinhTrang], [GhiChu]) VALUES (2, N'Chưa thực hiện', NULL)
INSERT [dbo].[TinhTrang] ([MaTinhTrang], [TenTinhTrang], [GhiChu]) VALUES (3, N'Đã thanh lý', NULL)
INSERT [dbo].[TinhTrang] ([MaTinhTrang], [TenTinhTrang], [GhiChu]) VALUES (4, N'Đã hủy bỏ', NULL)
SET IDENTITY_INSERT [dbo].[TinhTrang] OFF
INSERT [dbo].[TraLaiHangBan] ([MaTraLaiHangBan], [MaKhachHang], [DienGiai], [MaSoNhanVien], [MaLoaiTien], [NgayHoachToan], [NgayChungTu], [TyGia], [TongTienHang], [TienThueGTGT], [TienChietKhau], [TongTienThanhToan], [DaGhiSo]) VALUES (N'BTL000001', N'KH000001', N'Diễn giải', N'0002', 2, CAST(N'2020-08-20' AS Date), CAST(N'2020-08-20' AS Date), 23175, 35350000, 10395000, 23175, 45745000, 1)
INSERT [dbo].[TraLaiHangBan] ([MaTraLaiHangBan], [MaKhachHang], [DienGiai], [MaSoNhanVien], [MaLoaiTien], [NgayHoachToan], [NgayChungTu], [TyGia], [TongTienHang], [TienThueGTGT], [TienChietKhau], [TongTienThanhToan], [DaGhiSo]) VALUES (N'BTL000002', N'KH000001', N'ădawd', N'0001', 2, CAST(N'2020-08-20' AS Date), CAST(N'2020-08-20' AS Date), 1000, 13725000, 3120000, 23175, 16845000, 0)
INSERT [dbo].[TraLaiHangBan] ([MaTraLaiHangBan], [MaKhachHang], [DienGiai], [MaSoNhanVien], [MaLoaiTien], [NgayHoachToan], [NgayChungTu], [TyGia], [TongTienHang], [TienThueGTGT], [TienChietKhau], [TongTienThanhToan], [DaGhiSo]) VALUES (N'BTL000003', N'KH000001', N'ffas', N'0001', 2, CAST(N'2020-08-20' AS Date), CAST(N'2020-08-20' AS Date), 54, 13725000, 3120000, 2317535100, 16845000, 1)
INSERT [dbo].[TraLaiHangBan] ([MaTraLaiHangBan], [MaKhachHang], [DienGiai], [MaSoNhanVien], [MaLoaiTien], [NgayHoachToan], [NgayChungTu], [TyGia], [TongTienHang], [TienThueGTGT], [TienChietKhau], [TongTienThanhToan], [DaGhiSo]) VALUES (N'BTL000004', N'KH000001', N'fas', N'0001', 1, CAST(N'2020-08-20' AS Date), CAST(N'2020-08-20' AS Date), 545, 5775000, 1155000, 4010, 6930000, 0)
INSERT [dbo].[TraLaiHangBan] ([MaTraLaiHangBan], [MaKhachHang], [DienGiai], [MaSoNhanVien], [MaLoaiTien], [NgayHoachToan], [NgayChungTu], [TyGia], [TongTienHang], [TienThueGTGT], [TienChietKhau], [TongTienThanhToan], [DaGhiSo]) VALUES (N'BTL000005', N'KH000001', N'fas', N'0001', 1, CAST(N'2020-08-20' AS Date), CAST(N'2020-08-20' AS Date), 1000, 13725000, 3120000, 2000, 16845000, 1)
INSERT [dbo].[TraLaiHangBan] ([MaTraLaiHangBan], [MaKhachHang], [DienGiai], [MaSoNhanVien], [MaLoaiTien], [NgayHoachToan], [NgayChungTu], [TyGia], [TongTienHang], [TienThueGTGT], [TienChietKhau], [TongTienThanhToan], [DaGhiSo]) VALUES (N'BTL000006', N'KH000001', N'ădadawd', N'0001', 1, CAST(N'2020-08-20' AS Date), CAST(N'2020-08-20' AS Date), 1000, 13725000, 3120000, 522000, 16845000, 0)
INSERT [dbo].[TraLaiHangMua] ([MaTraLaiHangMua], [MaNhaCungCap], [NguoiNhanHang], [DienGiai], [MaSoNhanVien], [ChungTuGoc], [MaLoaiTien], [TyGia], [NgayHoachToan], [NgayChungTu], [TongTienHang], [TienThueGTGT], [TongTienThanhToan], [DaGhiSo]) VALUES (N'0000001', N'0001', N'Người nhận hàng', N'Diễn giải', N'0001', 2, 2, 23175, CAST(N'2020-08-17' AS Date), CAST(N'2020-08-17' AS Date), 0, 0, 0, 1)
INSERT [dbo].[TraLaiHangMua] ([MaTraLaiHangMua], [MaNhaCungCap], [NguoiNhanHang], [DienGiai], [MaSoNhanVien], [ChungTuGoc], [MaLoaiTien], [TyGia], [NgayHoachToan], [NgayChungTu], [TongTienHang], [TienThueGTGT], [TongTienThanhToan], [DaGhiSo]) VALUES (N'0000002', N'0003', N'Trường', N'diễn giải', N'0001', 2, 1, 2222, CAST(N'2020-08-17' AS Date), CAST(N'2020-08-17' AS Date), 5075000, 1015000, 6090000, 0)
INSERT [dbo].[TraLaiHangMua] ([MaTraLaiHangMua], [MaNhaCungCap], [NguoiNhanHang], [DienGiai], [MaSoNhanVien], [ChungTuGoc], [MaLoaiTien], [TyGia], [NgayHoachToan], [NgayChungTu], [TongTienHang], [TienThueGTGT], [TongTienThanhToan], [DaGhiSo]) VALUES (N'0000003', N'0005', N'Người nhận hàng', N'Diễn giải', N'0002', 2, 1, 1000, CAST(N'2020-08-17' AS Date), CAST(N'2020-08-17' AS Date), 875000, 175000, 1050000, 1)
INSERT [dbo].[TraLaiHangMua] ([MaTraLaiHangMua], [MaNhaCungCap], [NguoiNhanHang], [DienGiai], [MaSoNhanVien], [ChungTuGoc], [MaLoaiTien], [TyGia], [NgayHoachToan], [NgayChungTu], [TongTienHang], [TienThueGTGT], [TongTienThanhToan], [DaGhiSo]) VALUES (N'0000004', N'0005', N'Người nhận hàng', N'Diễn giải', N'0002', 2, 1, 1000, CAST(N'2020-08-17' AS Date), CAST(N'2020-08-17' AS Date), 875000, 175000, 1050000, 1)
ALTER TABLE [dbo].[ApplicationRoles] ADD  DEFAULT ('') FOR [Discriminator]
GO
ALTER TABLE [dbo].[ChungTuBanHang] ADD  CONSTRAINT [DF_ChungTuBanHang_DaThayDoi]  DEFAULT ((0)) FOR [DaThayDoi]
GO
ALTER TABLE [dbo].[ApplicationRoleGroups]  WITH CHECK ADD  CONSTRAINT [FK_dbo.ApplicationRoleGroups_dbo.ApplicationGroups_GroupId] FOREIGN KEY([GroupId])
REFERENCES [dbo].[ApplicationGroups] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ApplicationRoleGroups] CHECK CONSTRAINT [FK_dbo.ApplicationRoleGroups_dbo.ApplicationGroups_GroupId]
GO
ALTER TABLE [dbo].[ApplicationRoleGroups]  WITH CHECK ADD  CONSTRAINT [FK_dbo.ApplicationRoleGroups_dbo.ApplicationRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[ApplicationRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ApplicationRoleGroups] CHECK CONSTRAINT [FK_dbo.ApplicationRoleGroups_dbo.ApplicationRoles_RoleId]
GO
ALTER TABLE [dbo].[ApplicationUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_dbo.IdentityUserClaims_dbo.ApplicationUsers_ApplicationUser_Id] FOREIGN KEY([ApplicationUser_Id])
REFERENCES [dbo].[ApplicationUsers] ([Id])
GO
ALTER TABLE [dbo].[ApplicationUserClaims] CHECK CONSTRAINT [FK_dbo.IdentityUserClaims_dbo.ApplicationUsers_ApplicationUser_Id]
GO
ALTER TABLE [dbo].[ApplicationUserGroups]  WITH CHECK ADD  CONSTRAINT [FK_dbo.ApplicationUserGroups_dbo.ApplicationGroups_GroupId] FOREIGN KEY([GroupId])
REFERENCES [dbo].[ApplicationGroups] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ApplicationUserGroups] CHECK CONSTRAINT [FK_dbo.ApplicationUserGroups_dbo.ApplicationGroups_GroupId]
GO
ALTER TABLE [dbo].[ApplicationUserGroups]  WITH CHECK ADD  CONSTRAINT [FK_dbo.ApplicationUserGroups_dbo.ApplicationUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[ApplicationUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ApplicationUserGroups] CHECK CONSTRAINT [FK_dbo.ApplicationUserGroups_dbo.ApplicationUsers_UserId]
GO
ALTER TABLE [dbo].[ApplicationUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_dbo.IdentityUserLogins_dbo.ApplicationUsers_ApplicationUser_Id] FOREIGN KEY([ApplicationUser_Id])
REFERENCES [dbo].[ApplicationUsers] ([Id])
GO
ALTER TABLE [dbo].[ApplicationUserLogins] CHECK CONSTRAINT [FK_dbo.IdentityUserLogins_dbo.ApplicationUsers_ApplicationUser_Id]
GO
ALTER TABLE [dbo].[ApplicationUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.IdentityUserRoles_dbo.ApplicationUsers_ApplicationUser_Id] FOREIGN KEY([ApplicationUser_Id])
REFERENCES [dbo].[ApplicationUsers] ([Id])
GO
ALTER TABLE [dbo].[ApplicationUserRoles] CHECK CONSTRAINT [FK_dbo.IdentityUserRoles_dbo.ApplicationUsers_ApplicationUser_Id]
GO
ALTER TABLE [dbo].[ApplicationUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.IdentityUserRoles_dbo.IdentityRoles_IdentityRole_Id] FOREIGN KEY([IdentityRole_Id])
REFERENCES [dbo].[ApplicationRoles] ([Id])
GO
ALTER TABLE [dbo].[ApplicationUserRoles] CHECK CONSTRAINT [FK_dbo.IdentityUserRoles_dbo.IdentityRoles_IdentityRole_Id]
GO
ALTER TABLE [dbo].[BaoGia]  WITH CHECK ADD  CONSTRAINT [FK_BaoGia_KhachHang] FOREIGN KEY([MaKhachHang])
REFERENCES [dbo].[KhachHang] ([MaKhachHang])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[BaoGia] CHECK CONSTRAINT [FK_BaoGia_KhachHang]
GO
ALTER TABLE [dbo].[BaoGia]  WITH CHECK ADD  CONSTRAINT [FK_BaoGia_LoaiTien] FOREIGN KEY([MaLoaiTien])
REFERENCES [dbo].[LoaiTien] ([MaLoaiTien])
GO
ALTER TABLE [dbo].[BaoGia] CHECK CONSTRAINT [FK_BaoGia_LoaiTien]
GO
ALTER TABLE [dbo].[BaoGia]  WITH CHECK ADD  CONSTRAINT [FK_BaoGia_NhanVien] FOREIGN KEY([MaSoNhanVien])
REFERENCES [dbo].[NhanVien] ([MaSoNhanVien])
GO
ALTER TABLE [dbo].[BaoGia] CHECK CONSTRAINT [FK_BaoGia_NhanVien]
GO
ALTER TABLE [dbo].[ChiTietBaoGia]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietBaoGia_BaoGia] FOREIGN KEY([MaSoBaoGia])
REFERENCES [dbo].[BaoGia] ([MaSoBaoGia])
GO
ALTER TABLE [dbo].[ChiTietBaoGia] CHECK CONSTRAINT [FK_ChiTietBaoGia_BaoGia]
GO
ALTER TABLE [dbo].[ChiTietBaoGia]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietBaoGia_HangHoa] FOREIGN KEY([MaHang])
REFERENCES [dbo].[HangHoa] ([MaHang])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[ChiTietBaoGia] CHECK CONSTRAINT [FK_ChiTietBaoGia_HangHoa]
GO
ALTER TABLE [dbo].[ChiTietChungTuBanHang]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietChungTuBanHang_ChungTuBanHang] FOREIGN KEY([MaChungTuBanHang])
REFERENCES [dbo].[ChungTuBanHang] ([MaChungTuBanHang])
GO
ALTER TABLE [dbo].[ChiTietChungTuBanHang] CHECK CONSTRAINT [FK_ChiTietChungTuBanHang_ChungTuBanHang]
GO
ALTER TABLE [dbo].[ChiTietChungTuBanHang]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietChungTuBanHang_HangHoa] FOREIGN KEY([MaHang])
REFERENCES [dbo].[HangHoa] ([MaHang])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[ChiTietChungTuBanHang] CHECK CONSTRAINT [FK_ChiTietChungTuBanHang_HangHoa]
GO
ALTER TABLE [dbo].[ChiTietChungTuMuaDichVu]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietChungTuMuaDichVu_ChungTuMuaDichVu] FOREIGN KEY([MaChungTuMuaDichVu])
REFERENCES [dbo].[ChungTuMuaDichVu] ([MaChungTuMuaDichVu])
GO
ALTER TABLE [dbo].[ChiTietChungTuMuaDichVu] CHECK CONSTRAINT [FK_ChiTietChungTuMuaDichVu_ChungTuMuaDichVu]
GO
ALTER TABLE [dbo].[ChiTietChungTuMuaDichVu]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietChungTuMuaDichVu_DichVu] FOREIGN KEY([MaDichVu])
REFERENCES [dbo].[DichVu] ([MaDichVu])
GO
ALTER TABLE [dbo].[ChiTietChungTuMuaDichVu] CHECK CONSTRAINT [FK_ChiTietChungTuMuaDichVu_DichVu]
GO
ALTER TABLE [dbo].[ChiTietChungTuMuaHang]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietChungTuMuaHang_ChungTuMuaHang] FOREIGN KEY([MaChungTuMuaHang])
REFERENCES [dbo].[ChungTuMuaHang] ([MaChungTuMuaHang])
GO
ALTER TABLE [dbo].[ChiTietChungTuMuaHang] CHECK CONSTRAINT [FK_ChiTietChungTuMuaHang_ChungTuMuaHang]
GO
ALTER TABLE [dbo].[ChiTietChungTuMuaHang]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietChungTuMuaHang_DonMuaHang] FOREIGN KEY([MaDonMuaHang])
REFERENCES [dbo].[DonMuaHang] ([MaDonMuaHang])
GO
ALTER TABLE [dbo].[ChiTietChungTuMuaHang] CHECK CONSTRAINT [FK_ChiTietChungTuMuaHang_DonMuaHang]
GO
ALTER TABLE [dbo].[ChiTietChungTuMuaHang]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietChungTuMuaHang_HangHoa] FOREIGN KEY([MaHang])
REFERENCES [dbo].[HangHoa] ([MaHang])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[ChiTietChungTuMuaHang] CHECK CONSTRAINT [FK_ChiTietChungTuMuaHang_HangHoa]
GO
ALTER TABLE [dbo].[ChiTietChungTuMuaHang]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietChungTuMuaHang_HopDongMua] FOREIGN KEY([MaHopDongMua])
REFERENCES [dbo].[HopDongMua] ([MaHopDongMua])
GO
ALTER TABLE [dbo].[ChiTietChungTuMuaHang] CHECK CONSTRAINT [FK_ChiTietChungTuMuaHang_HopDongMua]
GO
ALTER TABLE [dbo].[ChiTietDonDatHang]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietDonDatHang_DonDatHang] FOREIGN KEY([MaDonDatHang])
REFERENCES [dbo].[DonDatHang] ([MaDonDatHang])
GO
ALTER TABLE [dbo].[ChiTietDonDatHang] CHECK CONSTRAINT [FK_ChiTietDonDatHang_DonDatHang]
GO
ALTER TABLE [dbo].[ChiTietDonDatHang]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietDonDatHang_HangHoa] FOREIGN KEY([MaHang])
REFERENCES [dbo].[HangHoa] ([MaHang])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[ChiTietDonDatHang] CHECK CONSTRAINT [FK_ChiTietDonDatHang_HangHoa]
GO
ALTER TABLE [dbo].[ChiTietDonMuaHang]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietDonMuaHang_DonMuaHang] FOREIGN KEY([MaDonMuaHang])
REFERENCES [dbo].[DonMuaHang] ([MaDonMuaHang])
GO
ALTER TABLE [dbo].[ChiTietDonMuaHang] CHECK CONSTRAINT [FK_ChiTietDonMuaHang_DonMuaHang]
GO
ALTER TABLE [dbo].[ChiTietDonMuaHang]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietDonMuaHang_HangHoa] FOREIGN KEY([MaHang])
REFERENCES [dbo].[HangHoa] ([MaHang])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[ChiTietDonMuaHang] CHECK CONSTRAINT [FK_ChiTietDonMuaHang_HangHoa]
GO
ALTER TABLE [dbo].[ChiTietGiamGiaHangBan]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietGiamGiaHangBan_GiamGiaHangBan] FOREIGN KEY([MaGiamGiaHangBan])
REFERENCES [dbo].[GiamGiaHangBan] ([MaGiamGiaHangBan])
GO
ALTER TABLE [dbo].[ChiTietGiamGiaHangBan] CHECK CONSTRAINT [FK_ChiTietGiamGiaHangBan_GiamGiaHangBan]
GO
ALTER TABLE [dbo].[ChiTietGiamGiaHangBan]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietGiamGiaHangBan_HangHoa] FOREIGN KEY([MaHang])
REFERENCES [dbo].[HangHoa] ([MaHang])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[ChiTietGiamGiaHangBan] CHECK CONSTRAINT [FK_ChiTietGiamGiaHangBan_HangHoa]
GO
ALTER TABLE [dbo].[ChiTietGiamGiaHangMua]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietGiamGiaHangMua_GiamGiaHangMua] FOREIGN KEY([MaGiamGiaHangMua])
REFERENCES [dbo].[GiamGiaHangMua] ([MaGiamGiaHangMua])
GO
ALTER TABLE [dbo].[ChiTietGiamGiaHangMua] CHECK CONSTRAINT [FK_ChiTietGiamGiaHangMua_GiamGiaHangMua]
GO
ALTER TABLE [dbo].[ChiTietGiamGiaHangMua]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietGiamGiaHangMua_HopDongMua] FOREIGN KEY([MaHopDongMua])
REFERENCES [dbo].[HopDongMua] ([MaHopDongMua])
GO
ALTER TABLE [dbo].[ChiTietGiamGiaHangMua] CHECK CONSTRAINT [FK_ChiTietGiamGiaHangMua_HopDongMua]
GO
ALTER TABLE [dbo].[ChiTietHoaDon_BanHang]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietHoaDon_BanHang_HangHoa] FOREIGN KEY([MaHang])
REFERENCES [dbo].[HangHoa] ([MaHang])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[ChiTietHoaDon_BanHang] CHECK CONSTRAINT [FK_ChiTietHoaDon_BanHang_HangHoa]
GO
ALTER TABLE [dbo].[ChiTietHoaDon_BanHang]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietHoaDon_BanHang_HoaDon_BanHang] FOREIGN KEY([MaHoaDon])
REFERENCES [dbo].[HoaDon_BanHang] ([MaHoaDon])
GO
ALTER TABLE [dbo].[ChiTietHoaDon_BanHang] CHECK CONSTRAINT [FK_ChiTietHoaDon_BanHang_HoaDon_BanHang]
GO
ALTER TABLE [dbo].[ChiTietHopDongMua]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietHopDongMua_HangHoa] FOREIGN KEY([MaHang])
REFERENCES [dbo].[HangHoa] ([MaHang])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[ChiTietHopDongMua] CHECK CONSTRAINT [FK_ChiTietHopDongMua_HangHoa]
GO
ALTER TABLE [dbo].[ChiTietHopDongMua]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietHopDongMua_HopDongMua] FOREIGN KEY([MaHopDongMua])
REFERENCES [dbo].[HopDongMua] ([MaHopDongMua])
GO
ALTER TABLE [dbo].[ChiTietHopDongMua] CHECK CONSTRAINT [FK_ChiTietHopDongMua_HopDongMua]
GO
ALTER TABLE [dbo].[ChiTietLapRapThaoDo]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietLapRapThaoDo_HangHoa] FOREIGN KEY([MaHang])
REFERENCES [dbo].[HangHoa] ([MaHang])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[ChiTietLapRapThaoDo] CHECK CONSTRAINT [FK_ChiTietLapRapThaoDo_HangHoa]
GO
ALTER TABLE [dbo].[ChiTietLapRapThaoDo]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietLapRapThaoDo_LapRapThaoDo] FOREIGN KEY([MaLapRapThaoDo])
REFERENCES [dbo].[LapRapThaoDo] ([MaLapRapThaoDo])
GO
ALTER TABLE [dbo].[ChiTietLapRapThaoDo] CHECK CONSTRAINT [FK_ChiTietLapRapThaoDo_LapRapThaoDo]
GO
ALTER TABLE [dbo].[ChiTietPhieuChi]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietPhieuChi_HangHoa] FOREIGN KEY([MaHang])
REFERENCES [dbo].[HangHoa] ([MaHang])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[ChiTietPhieuChi] CHECK CONSTRAINT [FK_ChiTietPhieuChi_HangHoa]
GO
ALTER TABLE [dbo].[ChiTietPhieuChi]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietPhieuChi_PhieuChi] FOREIGN KEY([MaPhieuChi])
REFERENCES [dbo].[PhieuChi] ([MaPhieuChi])
GO
ALTER TABLE [dbo].[ChiTietPhieuChi] CHECK CONSTRAINT [FK_ChiTietPhieuChi_PhieuChi]
GO
ALTER TABLE [dbo].[ChiTietPhieuNhapKho]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietPhieuNhapKho_HangHoa] FOREIGN KEY([MaHang])
REFERENCES [dbo].[HangHoa] ([MaHang])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[ChiTietPhieuNhapKho] CHECK CONSTRAINT [FK_ChiTietPhieuNhapKho_HangHoa]
GO
ALTER TABLE [dbo].[ChiTietPhieuNhapKho]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietPhieuNhapKho_PhieuNhapKho] FOREIGN KEY([MaPhieuNhapKho])
REFERENCES [dbo].[PhieuNhapKho] ([MaPhieuNhapKho])
GO
ALTER TABLE [dbo].[ChiTietPhieuNhapKho] CHECK CONSTRAINT [FK_ChiTietPhieuNhapKho_PhieuNhapKho]
GO
ALTER TABLE [dbo].[ChiTietPhieuThu]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietThu_HangHoa] FOREIGN KEY([MaHang])
REFERENCES [dbo].[HangHoa] ([MaHang])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[ChiTietPhieuThu] CHECK CONSTRAINT [FK_ChiTietThu_HangHoa]
GO
ALTER TABLE [dbo].[ChiTietPhieuThu]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietThu_PhieuThu] FOREIGN KEY([MaPhieuThu])
REFERENCES [dbo].[PhieuThu] ([MaPhieuThu])
GO
ALTER TABLE [dbo].[ChiTietPhieuThu] CHECK CONSTRAINT [FK_ChiTietThu_PhieuThu]
GO
ALTER TABLE [dbo].[ChiTietPhieuXuatKho]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietPhieuXuat_BanHang_HangHoa] FOREIGN KEY([MaHang])
REFERENCES [dbo].[HangHoa] ([MaHang])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[ChiTietPhieuXuatKho] CHECK CONSTRAINT [FK_ChiTietPhieuXuat_BanHang_HangHoa]
GO
ALTER TABLE [dbo].[ChiTietPhieuXuatKho]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietPhieuXuat_BanHang_PhieuXuat_BanHang] FOREIGN KEY([MaPhieuXuat])
REFERENCES [dbo].[PhieuXuatKho] ([MaPhieuXuat])
GO
ALTER TABLE [dbo].[ChiTietPhieuXuatKho] CHECK CONSTRAINT [FK_ChiTietPhieuXuat_BanHang_PhieuXuat_BanHang]
GO
ALTER TABLE [dbo].[ChiTietTraLaiHangBan]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietTraLaiHangBan_HangHoa] FOREIGN KEY([MaHang])
REFERENCES [dbo].[HangHoa] ([MaHang])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[ChiTietTraLaiHangBan] CHECK CONSTRAINT [FK_ChiTietTraLaiHangBan_HangHoa]
GO
ALTER TABLE [dbo].[ChiTietTraLaiHangBan]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietTraLaiHangBan_TraLaiHangBan] FOREIGN KEY([MaTraLaiHangBan])
REFERENCES [dbo].[TraLaiHangBan] ([MaTraLaiHangBan])
GO
ALTER TABLE [dbo].[ChiTietTraLaiHangBan] CHECK CONSTRAINT [FK_ChiTietTraLaiHangBan_TraLaiHangBan]
GO
ALTER TABLE [dbo].[ChiTietTraLaiHangMua]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietTraLaiHangMua_HangHoa] FOREIGN KEY([MaHang])
REFERENCES [dbo].[HangHoa] ([MaHang])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[ChiTietTraLaiHangMua] CHECK CONSTRAINT [FK_ChiTietTraLaiHangMua_HangHoa]
GO
ALTER TABLE [dbo].[ChiTietTraLaiHangMua]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietTraLaiHangMua_HopDongMua] FOREIGN KEY([MaHopDongMua])
REFERENCES [dbo].[HopDongMua] ([MaHopDongMua])
GO
ALTER TABLE [dbo].[ChiTietTraLaiHangMua] CHECK CONSTRAINT [FK_ChiTietTraLaiHangMua_HopDongMua]
GO
ALTER TABLE [dbo].[ChiTietTraLaiHangMua]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietTraLaiHangMua_TraLaiHangMua] FOREIGN KEY([MaTraLaiHangMua])
REFERENCES [dbo].[TraLaiHangMua] ([MaTraLaiHangMua])
GO
ALTER TABLE [dbo].[ChiTietTraLaiHangMua] CHECK CONSTRAINT [FK_ChiTietTraLaiHangMua_TraLaiHangMua]
GO
ALTER TABLE [dbo].[ChungTuBanHang]  WITH CHECK ADD  CONSTRAINT [FK_ChungTuBanHang_BaoGia] FOREIGN KEY([MaSoBaoGia])
REFERENCES [dbo].[BaoGia] ([MaSoBaoGia])
GO
ALTER TABLE [dbo].[ChungTuBanHang] CHECK CONSTRAINT [FK_ChungTuBanHang_BaoGia]
GO
ALTER TABLE [dbo].[ChungTuBanHang]  WITH CHECK ADD  CONSTRAINT [FK_ChungTuBanHang_DieuKhoanThanhToan] FOREIGN KEY([MaDieuKhoan])
REFERENCES [dbo].[DieuKhoanThanhToan] ([MaDieuKhoan])
GO
ALTER TABLE [dbo].[ChungTuBanHang] CHECK CONSTRAINT [FK_ChungTuBanHang_DieuKhoanThanhToan]
GO
ALTER TABLE [dbo].[ChungTuBanHang]  WITH CHECK ADD  CONSTRAINT [FK_ChungTuBanHang_KhachHang] FOREIGN KEY([MaKhachHang])
REFERENCES [dbo].[KhachHang] ([MaKhachHang])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[ChungTuBanHang] CHECK CONSTRAINT [FK_ChungTuBanHang_KhachHang]
GO
ALTER TABLE [dbo].[ChungTuBanHang]  WITH CHECK ADD  CONSTRAINT [FK_ChungTuBanHang_LoaiTien] FOREIGN KEY([MaLoaiTien])
REFERENCES [dbo].[LoaiTien] ([MaLoaiTien])
GO
ALTER TABLE [dbo].[ChungTuBanHang] CHECK CONSTRAINT [FK_ChungTuBanHang_LoaiTien]
GO
ALTER TABLE [dbo].[ChungTuBanHang]  WITH CHECK ADD  CONSTRAINT [FK_ChungTuBanHang_NhanVien] FOREIGN KEY([MaSoNhanVien])
REFERENCES [dbo].[NhanVien] ([MaSoNhanVien])
GO
ALTER TABLE [dbo].[ChungTuBanHang] CHECK CONSTRAINT [FK_ChungTuBanHang_NhanVien]
GO
ALTER TABLE [dbo].[ChungTuMuaDichVu]  WITH CHECK ADD  CONSTRAINT [FK_ChungTuMuaDichVu_DieuKhoanThanhToan] FOREIGN KEY([MaDieuKhoan])
REFERENCES [dbo].[DieuKhoanThanhToan] ([MaDieuKhoan])
GO
ALTER TABLE [dbo].[ChungTuMuaDichVu] CHECK CONSTRAINT [FK_ChungTuMuaDichVu_DieuKhoanThanhToan]
GO
ALTER TABLE [dbo].[ChungTuMuaDichVu]  WITH CHECK ADD  CONSTRAINT [FK_ChungTuMuaDichVu_LoaiTien] FOREIGN KEY([MaLoaiTien])
REFERENCES [dbo].[LoaiTien] ([MaLoaiTien])
GO
ALTER TABLE [dbo].[ChungTuMuaDichVu] CHECK CONSTRAINT [FK_ChungTuMuaDichVu_LoaiTien]
GO
ALTER TABLE [dbo].[ChungTuMuaDichVu]  WITH CHECK ADD  CONSTRAINT [FK_ChungTuMuaDichVu_NhaCungCap] FOREIGN KEY([MaNhaCungCap])
REFERENCES [dbo].[NhaCungCap] ([MaNhaCungCap])
GO
ALTER TABLE [dbo].[ChungTuMuaDichVu] CHECK CONSTRAINT [FK_ChungTuMuaDichVu_NhaCungCap]
GO
ALTER TABLE [dbo].[ChungTuMuaDichVu]  WITH CHECK ADD  CONSTRAINT [FK_ChungTuMuaDichVu_NhanVien] FOREIGN KEY([MaSoNhanVien])
REFERENCES [dbo].[NhanVien] ([MaSoNhanVien])
GO
ALTER TABLE [dbo].[ChungTuMuaDichVu] CHECK CONSTRAINT [FK_ChungTuMuaDichVu_NhanVien]
GO
ALTER TABLE [dbo].[ChungTuMuaHang]  WITH CHECK ADD  CONSTRAINT [FK_ChungTuMuaHang_LoaiTien] FOREIGN KEY([MaLoaiTien])
REFERENCES [dbo].[LoaiTien] ([MaLoaiTien])
GO
ALTER TABLE [dbo].[ChungTuMuaHang] CHECK CONSTRAINT [FK_ChungTuMuaHang_LoaiTien]
GO
ALTER TABLE [dbo].[ChungTuMuaHang]  WITH CHECK ADD  CONSTRAINT [FK_ChungTuMuaHang_NhaCungCap] FOREIGN KEY([MaNhaCungCap])
REFERENCES [dbo].[NhaCungCap] ([MaNhaCungCap])
GO
ALTER TABLE [dbo].[ChungTuMuaHang] CHECK CONSTRAINT [FK_ChungTuMuaHang_NhaCungCap]
GO
ALTER TABLE [dbo].[ChungTuMuaHang]  WITH CHECK ADD  CONSTRAINT [FK_ChungTuMuaHang_NhanVien] FOREIGN KEY([MaSoNhanVien])
REFERENCES [dbo].[NhanVien] ([MaSoNhanVien])
GO
ALTER TABLE [dbo].[ChungTuMuaHang] CHECK CONSTRAINT [FK_ChungTuMuaHang_NhanVien]
GO
ALTER TABLE [dbo].[DonDatHang]  WITH CHECK ADD  CONSTRAINT [FK_DonDatHang_DieuKhoanThanhToan] FOREIGN KEY([MaDieuKhoan])
REFERENCES [dbo].[DieuKhoanThanhToan] ([MaDieuKhoan])
GO
ALTER TABLE [dbo].[DonDatHang] CHECK CONSTRAINT [FK_DonDatHang_DieuKhoanThanhToan]
GO
ALTER TABLE [dbo].[DonDatHang]  WITH CHECK ADD  CONSTRAINT [FK_DonDatHang_KhachHang] FOREIGN KEY([MaKhachHang])
REFERENCES [dbo].[KhachHang] ([MaKhachHang])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[DonDatHang] CHECK CONSTRAINT [FK_DonDatHang_KhachHang]
GO
ALTER TABLE [dbo].[DonDatHang]  WITH CHECK ADD  CONSTRAINT [FK_DonDatHang_LoaiTien] FOREIGN KEY([MaLoaiTien])
REFERENCES [dbo].[LoaiTien] ([MaLoaiTien])
GO
ALTER TABLE [dbo].[DonDatHang] CHECK CONSTRAINT [FK_DonDatHang_LoaiTien]
GO
ALTER TABLE [dbo].[DonDatHang]  WITH CHECK ADD  CONSTRAINT [FK_DonDatHang_NhanVien] FOREIGN KEY([MaSoNhanVien])
REFERENCES [dbo].[NhanVien] ([MaSoNhanVien])
GO
ALTER TABLE [dbo].[DonDatHang] CHECK CONSTRAINT [FK_DonDatHang_NhanVien]
GO
ALTER TABLE [dbo].[DonDatHang]  WITH CHECK ADD  CONSTRAINT [FK_DonDatHang_TinhTrang] FOREIGN KEY([MaTinhTrang])
REFERENCES [dbo].[TinhTrang] ([MaTinhTrang])
GO
ALTER TABLE [dbo].[DonDatHang] CHECK CONSTRAINT [FK_DonDatHang_TinhTrang]
GO
ALTER TABLE [dbo].[DonMuaHang]  WITH CHECK ADD  CONSTRAINT [FK_DonMuaHang_DieuKhoanTT] FOREIGN KEY([MaDieuKhoan])
REFERENCES [dbo].[DieuKhoanThanhToan] ([MaDieuKhoan])
GO
ALTER TABLE [dbo].[DonMuaHang] CHECK CONSTRAINT [FK_DonMuaHang_DieuKhoanTT]
GO
ALTER TABLE [dbo].[DonMuaHang]  WITH CHECK ADD  CONSTRAINT [FK_DonMuaHang_NhaCungCap] FOREIGN KEY([MaNhaCungCap])
REFERENCES [dbo].[NhaCungCap] ([MaNhaCungCap])
GO
ALTER TABLE [dbo].[DonMuaHang] CHECK CONSTRAINT [FK_DonMuaHang_NhaCungCap]
GO
ALTER TABLE [dbo].[GiamGiaHangBan]  WITH CHECK ADD  CONSTRAINT [FK_GiamGiaHangBan_KhachHang] FOREIGN KEY([MaKhachHang])
REFERENCES [dbo].[KhachHang] ([MaKhachHang])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[GiamGiaHangBan] CHECK CONSTRAINT [FK_GiamGiaHangBan_KhachHang]
GO
ALTER TABLE [dbo].[GiamGiaHangBan]  WITH CHECK ADD  CONSTRAINT [FK_GiamGiaHangBan_LoaiTien] FOREIGN KEY([MaLoaiTien])
REFERENCES [dbo].[LoaiTien] ([MaLoaiTien])
GO
ALTER TABLE [dbo].[GiamGiaHangBan] CHECK CONSTRAINT [FK_GiamGiaHangBan_LoaiTien]
GO
ALTER TABLE [dbo].[GiamGiaHangBan]  WITH CHECK ADD  CONSTRAINT [FK_GiamGiaHangBan_NhanVien] FOREIGN KEY([MaSoNhanVien])
REFERENCES [dbo].[NhanVien] ([MaSoNhanVien])
GO
ALTER TABLE [dbo].[GiamGiaHangBan] CHECK CONSTRAINT [FK_GiamGiaHangBan_NhanVien]
GO
ALTER TABLE [dbo].[GiamGiaHangMua]  WITH CHECK ADD  CONSTRAINT [FK_GiamGiaHangMua_LoaiTien] FOREIGN KEY([MaLoaiTien])
REFERENCES [dbo].[LoaiTien] ([MaLoaiTien])
GO
ALTER TABLE [dbo].[GiamGiaHangMua] CHECK CONSTRAINT [FK_GiamGiaHangMua_LoaiTien]
GO
ALTER TABLE [dbo].[GiamGiaHangMua]  WITH CHECK ADD  CONSTRAINT [FK_GiamGiaHangMua_NhaCungCap] FOREIGN KEY([MaNhaCungCap])
REFERENCES [dbo].[NhaCungCap] ([MaNhaCungCap])
GO
ALTER TABLE [dbo].[GiamGiaHangMua] CHECK CONSTRAINT [FK_GiamGiaHangMua_NhaCungCap]
GO
ALTER TABLE [dbo].[GiamGiaHangMua]  WITH CHECK ADD  CONSTRAINT [FK_GiamGiaHangMua_NhanVien] FOREIGN KEY([MaSoNhanVien])
REFERENCES [dbo].[NhanVien] ([MaSoNhanVien])
GO
ALTER TABLE [dbo].[GiamGiaHangMua] CHECK CONSTRAINT [FK_GiamGiaHangMua_NhanVien]
GO
ALTER TABLE [dbo].[HangHoa]  WITH CHECK ADD  CONSTRAINT [FK_HangHoa_NhomHangHoa] FOREIGN KEY([MaNhomHH])
REFERENCES [dbo].[NhomHangHoa] ([MaNhomHH])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[HangHoa] CHECK CONSTRAINT [FK_HangHoa_NhomHangHoa]
GO
ALTER TABLE [dbo].[HangHoa]  WITH CHECK ADD  CONSTRAINT [FK_HangHoa_TinhChatHangHoa] FOREIGN KEY([MaTinhChat])
REFERENCES [dbo].[TinhChatHangHoa] ([MaTinhChat])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[HangHoa] CHECK CONSTRAINT [FK_HangHoa_TinhChatHangHoa]
GO
ALTER TABLE [dbo].[HangHoa_DonViTinh]  WITH CHECK ADD  CONSTRAINT [FK_HangHoa_DonViTinh_DonViTinh] FOREIGN KEY([MaDonViTinh])
REFERENCES [dbo].[DonViTinh] ([MaDonViTinh])
GO
ALTER TABLE [dbo].[HangHoa_DonViTinh] CHECK CONSTRAINT [FK_HangHoa_DonViTinh_DonViTinh]
GO
ALTER TABLE [dbo].[HangHoa_DonViTinh]  WITH CHECK ADD  CONSTRAINT [FK_HangHoa_DonViTinh_HangHoa] FOREIGN KEY([MaHang])
REFERENCES [dbo].[HangHoa] ([MaHang])
GO
ALTER TABLE [dbo].[HangHoa_DonViTinh] CHECK CONSTRAINT [FK_HangHoa_DonViTinh_HangHoa]
GO
ALTER TABLE [dbo].[HoaDon_BanHang]  WITH CHECK ADD  CONSTRAINT [FK_HoaDon_BanHang_ChungTuBanHang] FOREIGN KEY([MaChungTuBanHang])
REFERENCES [dbo].[ChungTuBanHang] ([MaChungTuBanHang])
GO
ALTER TABLE [dbo].[HoaDon_BanHang] CHECK CONSTRAINT [FK_HoaDon_BanHang_ChungTuBanHang]
GO
ALTER TABLE [dbo].[HoaDon_BanHang]  WITH CHECK ADD  CONSTRAINT [FK_HoaDon_BanHang_DieuKhoanThanhToan] FOREIGN KEY([MaDieuKhoan])
REFERENCES [dbo].[DieuKhoanThanhToan] ([MaDieuKhoan])
GO
ALTER TABLE [dbo].[HoaDon_BanHang] CHECK CONSTRAINT [FK_HoaDon_BanHang_DieuKhoanThanhToan]
GO
ALTER TABLE [dbo].[HoaDon_BanHang]  WITH CHECK ADD  CONSTRAINT [FK_HoaDon_BanHang_KhachHang] FOREIGN KEY([MaKhachHang])
REFERENCES [dbo].[KhachHang] ([MaKhachHang])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[HoaDon_BanHang] CHECK CONSTRAINT [FK_HoaDon_BanHang_KhachHang]
GO
ALTER TABLE [dbo].[HoaDon_BanHang]  WITH CHECK ADD  CONSTRAINT [FK_HoaDon_BanHang_LoaiTien] FOREIGN KEY([MaLoaiTien])
REFERENCES [dbo].[LoaiTien] ([MaLoaiTien])
GO
ALTER TABLE [dbo].[HoaDon_BanHang] CHECK CONSTRAINT [FK_HoaDon_BanHang_LoaiTien]
GO
ALTER TABLE [dbo].[HoaDon_BanHang]  WITH CHECK ADD  CONSTRAINT [FK_HoaDon_BanHang_NhanVien] FOREIGN KEY([MaSoNhanVien])
REFERENCES [dbo].[NhanVien] ([MaSoNhanVien])
GO
ALTER TABLE [dbo].[HoaDon_BanHang] CHECK CONSTRAINT [FK_HoaDon_BanHang_NhanVien]
GO
ALTER TABLE [dbo].[HoanThanhCongViec]  WITH CHECK ADD  CONSTRAINT [FK_HoanThanhCongViec_NhanVien] FOREIGN KEY([MaSoNhanVien])
REFERENCES [dbo].[NhanVien] ([MaSoNhanVien])
GO
ALTER TABLE [dbo].[HoanThanhCongViec] CHECK CONSTRAINT [FK_HoanThanhCongViec_NhanVien]
GO
ALTER TABLE [dbo].[HopDongMua]  WITH CHECK ADD  CONSTRAINT [FK_HopDongMua_LoaiTien] FOREIGN KEY([MaLoaiTien])
REFERENCES [dbo].[LoaiTien] ([MaLoaiTien])
GO
ALTER TABLE [dbo].[HopDongMua] CHECK CONSTRAINT [FK_HopDongMua_LoaiTien]
GO
ALTER TABLE [dbo].[HopDongMua]  WITH CHECK ADD  CONSTRAINT [FK_HopDongMua_NhaCungCap] FOREIGN KEY([MaNhaCungCap])
REFERENCES [dbo].[NhaCungCap] ([MaNhaCungCap])
GO
ALTER TABLE [dbo].[HopDongMua] CHECK CONSTRAINT [FK_HopDongMua_NhaCungCap]
GO
ALTER TABLE [dbo].[HopDongMua]  WITH CHECK ADD  CONSTRAINT [FK_HopDongMua_NhanVien] FOREIGN KEY([MaSoNhanVien])
REFERENCES [dbo].[NhanVien] ([MaSoNhanVien])
GO
ALTER TABLE [dbo].[HopDongMua] CHECK CONSTRAINT [FK_HopDongMua_NhanVien]
GO
ALTER TABLE [dbo].[HopDongMua]  WITH CHECK ADD  CONSTRAINT [FK_HopDongMua_TinhTrang] FOREIGN KEY([MaTinhTrang])
REFERENCES [dbo].[TinhTrang] ([MaTinhTrang])
GO
ALTER TABLE [dbo].[HopDongMua] CHECK CONSTRAINT [FK_HopDongMua_TinhTrang]
GO
ALTER TABLE [dbo].[KhachHang]  WITH CHECK ADD  CONSTRAINT [FK_KhachHang_NhomKH_NCC] FOREIGN KEY([NhomKH_NCC])
REFERENCES [dbo].[NhomKH_NCC] ([NhomKH_NCC])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[KhachHang] CHECK CONSTRAINT [FK_KhachHang_NhomKH_NCC]
GO
ALTER TABLE [dbo].[KhachHang_TaiKhoan]  WITH CHECK ADD  CONSTRAINT [FK_KhachHang_TaiKhoan_KhachHang] FOREIGN KEY([MaKhachHang])
REFERENCES [dbo].[KhachHang] ([MaKhachHang])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[KhachHang_TaiKhoan] CHECK CONSTRAINT [FK_KhachHang_TaiKhoan_KhachHang]
GO
ALTER TABLE [dbo].[KhachHang_TaiKhoan]  WITH CHECK ADD  CONSTRAINT [FK_KhachHang_TaiKhoan_TaiKhoanNganHang] FOREIGN KEY([MaTaiKhoan])
REFERENCES [dbo].[TaiKhoanNganHang] ([MaTaiKhoan])
GO
ALTER TABLE [dbo].[KhachHang_TaiKhoan] CHECK CONSTRAINT [FK_KhachHang_TaiKhoan_TaiKhoanNganHang]
GO
ALTER TABLE [dbo].[KhungGio]  WITH CHECK ADD  CONSTRAINT [FK_KhungGio_NhanVien] FOREIGN KEY([MaSoNhanVien])
REFERENCES [dbo].[NhanVien] ([MaSoNhanVien])
GO
ALTER TABLE [dbo].[KhungGio] CHECK CONSTRAINT [FK_KhungGio_NhanVien]
GO
ALTER TABLE [dbo].[LapRapThaoDo]  WITH CHECK ADD  CONSTRAINT [FK_LapRapThaoDo_HangHoa] FOREIGN KEY([MaHang])
REFERENCES [dbo].[HangHoa] ([MaHang])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[LapRapThaoDo] CHECK CONSTRAINT [FK_LapRapThaoDo_HangHoa]
GO
ALTER TABLE [dbo].[LapRapThaoDo]  WITH CHECK ADD  CONSTRAINT [FK_LapRapThaoDo_ThanhPham] FOREIGN KEY([MaThanhPham])
REFERENCES [dbo].[ThanhPham] ([MaThanhPham])
GO
ALTER TABLE [dbo].[LapRapThaoDo] CHECK CONSTRAINT [FK_LapRapThaoDo_ThanhPham]
GO
ALTER TABLE [dbo].[LenhSanXuat]  WITH CHECK ADD  CONSTRAINT [FK_LenhSanXuat_TinhTrang] FOREIGN KEY([MaTinhTrang])
REFERENCES [dbo].[TinhTrang] ([MaTinhTrang])
GO
ALTER TABLE [dbo].[LenhSanXuat] CHECK CONSTRAINT [FK_LenhSanXuat_TinhTrang]
GO
ALTER TABLE [dbo].[LenhSanXuat_NVL]  WITH CHECK ADD  CONSTRAINT [FK_LenhSanXuat_NVL_HangHoa] FOREIGN KEY([MaHang])
REFERENCES [dbo].[HangHoa] ([MaHang])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[LenhSanXuat_NVL] CHECK CONSTRAINT [FK_LenhSanXuat_NVL_HangHoa]
GO
ALTER TABLE [dbo].[LenhSanXuat_NVL]  WITH CHECK ADD  CONSTRAINT [FK_LenhSanXuat_NVL_LenhSanXuat] FOREIGN KEY([MaLenhSanXuat])
REFERENCES [dbo].[LenhSanXuat] ([MaLenhSanXuat])
GO
ALTER TABLE [dbo].[LenhSanXuat_NVL] CHECK CONSTRAINT [FK_LenhSanXuat_NVL_LenhSanXuat]
GO
ALTER TABLE [dbo].[LenhSanXuat_ThanhPham]  WITH CHECK ADD  CONSTRAINT [FK_LenhSanXuat_ThanhPham_LenhSanXuat] FOREIGN KEY([MaLenhSanXuat])
REFERENCES [dbo].[LenhSanXuat] ([MaLenhSanXuat])
GO
ALTER TABLE [dbo].[LenhSanXuat_ThanhPham] CHECK CONSTRAINT [FK_LenhSanXuat_ThanhPham_LenhSanXuat]
GO
ALTER TABLE [dbo].[LenhSanXuat_ThanhPham]  WITH CHECK ADD  CONSTRAINT [FK_LenhSanXuat_ThanhPham_ThanhPham] FOREIGN KEY([MaThanhPham])
REFERENCES [dbo].[ThanhPham] ([MaThanhPham])
GO
ALTER TABLE [dbo].[LenhSanXuat_ThanhPham] CHECK CONSTRAINT [FK_LenhSanXuat_ThanhPham_ThanhPham]
GO
ALTER TABLE [dbo].[LichSuLamViec]  WITH CHECK ADD  CONSTRAINT [FK_LichSuLamViec_NhanVien] FOREIGN KEY([MaSoNhanVien])
REFERENCES [dbo].[NhanVien] ([MaSoNhanVien])
GO
ALTER TABLE [dbo].[LichSuLamViec] CHECK CONSTRAINT [FK_LichSuLamViec_NhanVien]
GO
ALTER TABLE [dbo].[LoaiTaiSanCoDinh]  WITH CHECK ADD  CONSTRAINT [FK_LoaiTaiSanCoDinh_TaiKhoanCo] FOREIGN KEY([SoTaiKhoanCo])
REFERENCES [dbo].[TaiKhoanCo] ([SoTaiKhoanCo])
GO
ALTER TABLE [dbo].[LoaiTaiSanCoDinh] CHECK CONSTRAINT [FK_LoaiTaiSanCoDinh_TaiKhoanCo]
GO
ALTER TABLE [dbo].[LoaiTaiSanCoDinh]  WITH CHECK ADD  CONSTRAINT [FK_LoaiTaiSanCoDinh_TaiKhoanNo] FOREIGN KEY([SoTaiKhoanNo])
REFERENCES [dbo].[TaiKhoanNo] ([SoTaiKhoanNo])
GO
ALTER TABLE [dbo].[LoaiTaiSanCoDinh] CHECK CONSTRAINT [FK_LoaiTaiSanCoDinh_TaiKhoanNo]
GO
ALTER TABLE [dbo].[NgonNgu]  WITH CHECK ADD  CONSTRAINT [FK_NgonNgu_NhanVien] FOREIGN KEY([MaSoNhanVien])
REFERENCES [dbo].[NhanVien] ([MaSoNhanVien])
GO
ALTER TABLE [dbo].[NgonNgu] CHECK CONSTRAINT [FK_NgonNgu_NhanVien]
GO
ALTER TABLE [dbo].[NguoiQuanLy]  WITH CHECK ADD  CONSTRAINT [FK_NguoiQuanLy_NhanVien] FOREIGN KEY([MaSoNhanVien])
REFERENCES [dbo].[NhanVien] ([MaSoNhanVien])
GO
ALTER TABLE [dbo].[NguoiQuanLy] CHECK CONSTRAINT [FK_NguoiQuanLy_NhanVien]
GO
ALTER TABLE [dbo].[NhaCungCap]  WITH CHECK ADD  CONSTRAINT [FK_NhaCungCap_NhomKH_NCC] FOREIGN KEY([NhomKH_NCC])
REFERENCES [dbo].[NhomKH_NCC] ([NhomKH_NCC])
GO
ALTER TABLE [dbo].[NhaCungCap] CHECK CONSTRAINT [FK_NhaCungCap_NhomKH_NCC]
GO
ALTER TABLE [dbo].[NhaCungCap_TaiKhoan]  WITH CHECK ADD  CONSTRAINT [FK_NhaCungCap_TaiKhoan_NhaCungCap] FOREIGN KEY([MaNhaCungCap])
REFERENCES [dbo].[NhaCungCap] ([MaNhaCungCap])
GO
ALTER TABLE [dbo].[NhaCungCap_TaiKhoan] CHECK CONSTRAINT [FK_NhaCungCap_TaiKhoan_NhaCungCap]
GO
ALTER TABLE [dbo].[NhaCungCap_TaiKhoan]  WITH CHECK ADD  CONSTRAINT [FK_NhaCungCap_TaiKhoan_TaiKhoanNganHang] FOREIGN KEY([MaTaiKhoan])
REFERENCES [dbo].[TaiKhoanNganHang] ([MaTaiKhoan])
GO
ALTER TABLE [dbo].[NhaCungCap_TaiKhoan] CHECK CONSTRAINT [FK_NhaCungCap_TaiKhoan_TaiKhoanNganHang]
GO
ALTER TABLE [dbo].[NhanVien]  WITH CHECK ADD  CONSTRAINT [FK_NhanVien_ChucVu] FOREIGN KEY([MaChucVu])
REFERENCES [dbo].[ChucVu] ([MaChucVu])
GO
ALTER TABLE [dbo].[NhanVien] CHECK CONSTRAINT [FK_NhanVien_ChucVu]
GO
ALTER TABLE [dbo].[NhanVien]  WITH CHECK ADD  CONSTRAINT [FK_NhanVien_CoSo] FOREIGN KEY([MaCoSo])
REFERENCES [dbo].[CoSo] ([MaCoSo])
GO
ALTER TABLE [dbo].[NhanVien] CHECK CONSTRAINT [FK_NhanVien_CoSo]
GO
ALTER TABLE [dbo].[NhanVien]  WITH CHECK ADD  CONSTRAINT [FK_NhanVien_DonVi] FOREIGN KEY([MaDonVi])
REFERENCES [dbo].[DonVi] ([MaDonVi])
GO
ALTER TABLE [dbo].[NhanVien] CHECK CONSTRAINT [FK_NhanVien_DonVi]
GO
ALTER TABLE [dbo].[PhieuChi]  WITH CHECK ADD  CONSTRAINT [FK_PhieuChi_LoaiChi] FOREIGN KEY([MaLoaiChi])
REFERENCES [dbo].[LoaiChi] ([MaLoaiChi])
GO
ALTER TABLE [dbo].[PhieuChi] CHECK CONSTRAINT [FK_PhieuChi_LoaiChi]
GO
ALTER TABLE [dbo].[PhieuChi]  WITH CHECK ADD  CONSTRAINT [FK_PhieuChi_NhaCungCap] FOREIGN KEY([MaNhaCungCap])
REFERENCES [dbo].[NhaCungCap] ([MaNhaCungCap])
GO
ALTER TABLE [dbo].[PhieuChi] CHECK CONSTRAINT [FK_PhieuChi_NhaCungCap]
GO
ALTER TABLE [dbo].[PhieuChi]  WITH CHECK ADD  CONSTRAINT [FK_PhieuChi_NhanVien] FOREIGN KEY([MaSoNhanVien])
REFERENCES [dbo].[NhanVien] ([MaSoNhanVien])
GO
ALTER TABLE [dbo].[PhieuChi] CHECK CONSTRAINT [FK_PhieuChi_NhanVien]
GO
ALTER TABLE [dbo].[PhieuChi]  WITH CHECK ADD  CONSTRAINT [FK_PhieuChi_TinhTrang] FOREIGN KEY([MaTinhTrang])
REFERENCES [dbo].[TinhTrang] ([MaTinhTrang])
GO
ALTER TABLE [dbo].[PhieuChi] CHECK CONSTRAINT [FK_PhieuChi_TinhTrang]
GO
ALTER TABLE [dbo].[PhieuNhapKho]  WITH CHECK ADD  CONSTRAINT [FK_PhieuNhapKho_KhachHang] FOREIGN KEY([MaKhachHang])
REFERENCES [dbo].[KhachHang] ([MaKhachHang])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[PhieuNhapKho] CHECK CONSTRAINT [FK_PhieuNhapKho_KhachHang]
GO
ALTER TABLE [dbo].[PhieuThu]  WITH CHECK ADD  CONSTRAINT [FK_PhieuThu_KhachHang] FOREIGN KEY([MaKhachHang])
REFERENCES [dbo].[KhachHang] ([MaKhachHang])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[PhieuThu] CHECK CONSTRAINT [FK_PhieuThu_KhachHang]
GO
ALTER TABLE [dbo].[PhieuThu]  WITH CHECK ADD  CONSTRAINT [FK_PhieuThu_LoaiThu] FOREIGN KEY([MaLoaiThu])
REFERENCES [dbo].[LoaiThu] ([MaLoaiThu])
GO
ALTER TABLE [dbo].[PhieuThu] CHECK CONSTRAINT [FK_PhieuThu_LoaiThu]
GO
ALTER TABLE [dbo].[PhieuThu]  WITH CHECK ADD  CONSTRAINT [FK_PhieuThu_LoaiTien] FOREIGN KEY([MaLoaiTien])
REFERENCES [dbo].[LoaiTien] ([MaLoaiTien])
GO
ALTER TABLE [dbo].[PhieuThu] CHECK CONSTRAINT [FK_PhieuThu_LoaiTien]
GO
ALTER TABLE [dbo].[PhieuThu]  WITH CHECK ADD  CONSTRAINT [FK_PhieuThu_NhanVien] FOREIGN KEY([MaSoNhanVien])
REFERENCES [dbo].[NhanVien] ([MaSoNhanVien])
GO
ALTER TABLE [dbo].[PhieuThu] CHECK CONSTRAINT [FK_PhieuThu_NhanVien]
GO
ALTER TABLE [dbo].[PhieuThu]  WITH CHECK ADD  CONSTRAINT [FK_PhieuThu_TinhTrang] FOREIGN KEY([MaTinhTrang])
REFERENCES [dbo].[TinhTrang] ([MaTinhTrang])
GO
ALTER TABLE [dbo].[PhieuThu] CHECK CONSTRAINT [FK_PhieuThu_TinhTrang]
GO
ALTER TABLE [dbo].[PhieuXuatKho]  WITH CHECK ADD  CONSTRAINT [FK_PhieuXuat_BanHang_ChungTuBanHang] FOREIGN KEY([MaChungTuBanHang])
REFERENCES [dbo].[ChungTuBanHang] ([MaChungTuBanHang])
GO
ALTER TABLE [dbo].[PhieuXuatKho] CHECK CONSTRAINT [FK_PhieuXuat_BanHang_ChungTuBanHang]
GO
ALTER TABLE [dbo].[PhieuXuatKho]  WITH CHECK ADD  CONSTRAINT [FK_PhieuXuat_BanHang_DieuKhoanThanhToan] FOREIGN KEY([MaDieuKhoan])
REFERENCES [dbo].[DieuKhoanThanhToan] ([MaDieuKhoan])
GO
ALTER TABLE [dbo].[PhieuXuatKho] CHECK CONSTRAINT [FK_PhieuXuat_BanHang_DieuKhoanThanhToan]
GO
ALTER TABLE [dbo].[PhieuXuatKho]  WITH CHECK ADD  CONSTRAINT [FK_PhieuXuat_BanHang_KhachHang] FOREIGN KEY([MaKhachHang])
REFERENCES [dbo].[KhachHang] ([MaKhachHang])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[PhieuXuatKho] CHECK CONSTRAINT [FK_PhieuXuat_BanHang_KhachHang]
GO
ALTER TABLE [dbo].[PhieuXuatKho]  WITH CHECK ADD  CONSTRAINT [FK_PhieuXuat_BanHang_LoaiTien] FOREIGN KEY([MaLoaiTien])
REFERENCES [dbo].[LoaiTien] ([MaLoaiTien])
GO
ALTER TABLE [dbo].[PhieuXuatKho] CHECK CONSTRAINT [FK_PhieuXuat_BanHang_LoaiTien]
GO
ALTER TABLE [dbo].[PhieuXuatKho]  WITH CHECK ADD  CONSTRAINT [FK_PhieuXuat_BanHang_NhanVien] FOREIGN KEY([MaSoNhanVien])
REFERENCES [dbo].[NhanVien] ([MaSoNhanVien])
GO
ALTER TABLE [dbo].[PhieuXuatKho] CHECK CONSTRAINT [FK_PhieuXuat_BanHang_NhanVien]
GO
ALTER TABLE [dbo].[PhieuXuatKho]  WITH CHECK ADD  CONSTRAINT [FK_PhieuXuatKho_TraLaiHangBan] FOREIGN KEY([MaTraLaiHangBan])
REFERENCES [dbo].[TraLaiHangBan] ([MaTraLaiHangBan])
GO
ALTER TABLE [dbo].[PhieuXuatKho] CHECK CONSTRAINT [FK_PhieuXuatKho_TraLaiHangBan]
GO
ALTER TABLE [dbo].[QuanLyCongTac]  WITH CHECK ADD  CONSTRAINT [FK_QuanLyCongTac_NhanVien] FOREIGN KEY([MaSoNhanVien])
REFERENCES [dbo].[NhanVien] ([MaSoNhanVien])
GO
ALTER TABLE [dbo].[QuanLyCongTac] CHECK CONSTRAINT [FK_QuanLyCongTac_NhanVien]
GO
ALTER TABLE [dbo].[QuanLyNgayNghi]  WITH CHECK ADD  CONSTRAINT [FK_QuanLyNgayNghi_NhanVien] FOREIGN KEY([MaSoNhanVien])
REFERENCES [dbo].[NhanVien] ([MaSoNhanVien])
GO
ALTER TABLE [dbo].[QuanLyNgayNghi] CHECK CONSTRAINT [FK_QuanLyNgayNghi_NhanVien]
GO
ALTER TABLE [dbo].[QuanLyQuaGio]  WITH CHECK ADD  CONSTRAINT [FK_QuanLyQuaGio_NhanVien] FOREIGN KEY([MaSoNhanVien])
REFERENCES [dbo].[NhanVien] ([MaSoNhanVien])
GO
ALTER TABLE [dbo].[QuanLyQuaGio] CHECK CONSTRAINT [FK_QuanLyQuaGio_NhanVien]
GO
ALTER TABLE [dbo].[QuanLyTaiSan]  WITH CHECK ADD  CONSTRAINT [FK_QuanLyTaiSan_NhanVien] FOREIGN KEY([MaSoNhanVien])
REFERENCES [dbo].[NhanVien] ([MaSoNhanVien])
GO
ALTER TABLE [dbo].[QuanLyTaiSan] CHECK CONSTRAINT [FK_QuanLyTaiSan_NhanVien]
GO
ALTER TABLE [dbo].[QuanLyTaiSan]  WITH CHECK ADD  CONSTRAINT [FK_QuanLyTaiSan_TaiSan] FOREIGN KEY([MaTaiSan])
REFERENCES [dbo].[TaiSan] ([MaTaiSan])
GO
ALTER TABLE [dbo].[QuanLyTaiSan] CHECK CONSTRAINT [FK_QuanLyTaiSan_TaiSan]
GO
ALTER TABLE [dbo].[QuanLyVangMat]  WITH CHECK ADD  CONSTRAINT [FK_QuanLyVangMat_NhanVien] FOREIGN KEY([MaSoNhanVien])
REFERENCES [dbo].[NhanVien] ([MaSoNhanVien])
GO
ALTER TABLE [dbo].[QuanLyVangMat] CHECK CONSTRAINT [FK_QuanLyVangMat_NhanVien]
GO
ALTER TABLE [dbo].[QuaTrinhDaoTao]  WITH CHECK ADD  CONSTRAINT [FK_QuaTrinhDaoTao_NhanVien] FOREIGN KEY([MaSoNhanVien])
REFERENCES [dbo].[NhanVien] ([MaSoNhanVien])
GO
ALTER TABLE [dbo].[QuaTrinhDaoTao] CHECK CONSTRAINT [FK_QuaTrinhDaoTao_NhanVien]
GO
ALTER TABLE [dbo].[QuetThe]  WITH CHECK ADD  CONSTRAINT [FK_QuetThe_NhanVien] FOREIGN KEY([MaSoNhanVien])
REFERENCES [dbo].[NhanVien] ([MaSoNhanVien])
GO
ALTER TABLE [dbo].[QuetThe] CHECK CONSTRAINT [FK_QuetThe_NhanVien]
GO
ALTER TABLE [dbo].[QuetTheTheoNgay]  WITH CHECK ADD  CONSTRAINT [FK_QuetTheTheoNgay_NhanVien] FOREIGN KEY([MaSoNhanVien])
REFERENCES [dbo].[NhanVien] ([MaSoNhanVien])
GO
ALTER TABLE [dbo].[QuetTheTheoNgay] CHECK CONSTRAINT [FK_QuetTheTheoNgay_NhanVien]
GO
ALTER TABLE [dbo].[TaiSan]  WITH CHECK ADD  CONSTRAINT [FK_TaiSan_CoSo] FOREIGN KEY([MaCoSo])
REFERENCES [dbo].[CoSo] ([MaCoSo])
GO
ALTER TABLE [dbo].[TaiSan] CHECK CONSTRAINT [FK_TaiSan_CoSo]
GO
ALTER TABLE [dbo].[The]  WITH CHECK ADD  CONSTRAINT [FK_The_NhanVien] FOREIGN KEY([MaSoNhanVien])
REFERENCES [dbo].[NhanVien] ([MaSoNhanVien])
GO
ALTER TABLE [dbo].[The] CHECK CONSTRAINT [FK_The_NhanVien]
GO
ALTER TABLE [dbo].[ThongTinTuyenDung]  WITH CHECK ADD  CONSTRAINT [FK_ThongTinTuyenDung_NhanVien] FOREIGN KEY([MaSoNhanVien])
REFERENCES [dbo].[NhanVien] ([MaSoNhanVien])
GO
ALTER TABLE [dbo].[ThongTinTuyenDung] CHECK CONSTRAINT [FK_ThongTinTuyenDung_NhanVien]
GO
ALTER TABLE [dbo].[TraLaiHangBan]  WITH CHECK ADD  CONSTRAINT [FK_TraLaiHangBan_KhachHang] FOREIGN KEY([MaKhachHang])
REFERENCES [dbo].[KhachHang] ([MaKhachHang])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[TraLaiHangBan] CHECK CONSTRAINT [FK_TraLaiHangBan_KhachHang]
GO
ALTER TABLE [dbo].[TraLaiHangBan]  WITH CHECK ADD  CONSTRAINT [FK_TraLaiHangBan_LoaiTien] FOREIGN KEY([MaLoaiTien])
REFERENCES [dbo].[LoaiTien] ([MaLoaiTien])
GO
ALTER TABLE [dbo].[TraLaiHangBan] CHECK CONSTRAINT [FK_TraLaiHangBan_LoaiTien]
GO
ALTER TABLE [dbo].[TraLaiHangBan]  WITH CHECK ADD  CONSTRAINT [FK_TraLaiHangBan_NhanVien] FOREIGN KEY([MaSoNhanVien])
REFERENCES [dbo].[NhanVien] ([MaSoNhanVien])
GO
ALTER TABLE [dbo].[TraLaiHangBan] CHECK CONSTRAINT [FK_TraLaiHangBan_NhanVien]
GO
ALTER TABLE [dbo].[TraLaiHangMua]  WITH CHECK ADD  CONSTRAINT [FK_TraLaiHangMua_LoaiTien] FOREIGN KEY([MaLoaiTien])
REFERENCES [dbo].[LoaiTien] ([MaLoaiTien])
GO
ALTER TABLE [dbo].[TraLaiHangMua] CHECK CONSTRAINT [FK_TraLaiHangMua_LoaiTien]
GO
ALTER TABLE [dbo].[TraLaiHangMua]  WITH CHECK ADD  CONSTRAINT [FK_TraLaiHangMua_NhaCungCap] FOREIGN KEY([MaNhaCungCap])
REFERENCES [dbo].[NhaCungCap] ([MaNhaCungCap])
GO
ALTER TABLE [dbo].[TraLaiHangMua] CHECK CONSTRAINT [FK_TraLaiHangMua_NhaCungCap]
GO
ALTER TABLE [dbo].[TraLaiHangMua]  WITH CHECK ADD  CONSTRAINT [FK_TraLaiHangMua_NhanVien] FOREIGN KEY([MaSoNhanVien])
REFERENCES [dbo].[NhanVien] ([MaSoNhanVien])
GO
ALTER TABLE [dbo].[TraLaiHangMua] CHECK CONSTRAINT [FK_TraLaiHangMua_NhanVien]
GO
