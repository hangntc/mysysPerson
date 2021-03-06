USE [master]
GO
/****** Object:  Database [WebBanHang]    Script Date: 6/24/2019 9:30:29 PM ******/
CREATE DATABASE [WebBanHang]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'WebBanHang', FILENAME = N'D:\SQL\WebBanHang.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'WebBanHang_log', FILENAME = N'D:\SQL\WebBanHang_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [WebBanHang] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [WebBanHang].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [WebBanHang] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [WebBanHang] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [WebBanHang] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [WebBanHang] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [WebBanHang] SET ARITHABORT OFF 
GO
ALTER DATABASE [WebBanHang] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [WebBanHang] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [WebBanHang] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [WebBanHang] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [WebBanHang] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [WebBanHang] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [WebBanHang] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [WebBanHang] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [WebBanHang] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [WebBanHang] SET  DISABLE_BROKER 
GO
ALTER DATABASE [WebBanHang] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [WebBanHang] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [WebBanHang] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [WebBanHang] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [WebBanHang] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [WebBanHang] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [WebBanHang] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [WebBanHang] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [WebBanHang] SET  MULTI_USER 
GO
ALTER DATABASE [WebBanHang] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [WebBanHang] SET DB_CHAINING OFF 
GO
ALTER DATABASE [WebBanHang] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [WebBanHang] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [WebBanHang] SET DELAYED_DURABILITY = DISABLED 
GO
USE [WebBanHang]
GO
/****** Object:  Table [dbo].[BaiVietHeThong]    Script Date: 6/24/2019 9:30:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BaiVietHeThong](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[cCode] [nvarchar](20) NOT NULL,
	[cValue] [ntext] NOT NULL,
	[cLangID] [nvarchar](10) NOT NULL,
	[cUpdateTime] [datetime] NOT NULL,
 CONSTRAINT [PK_BaiVietHeThong] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Chitietdonhang]    Script Date: 6/24/2019 9:30:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Chitietdonhang](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdDonHang] [int] NULL,
	[IdSanPham] [int] NULL,
	[Soluong] [int] NULL,
	[Dongia] [float] NULL,
 CONSTRAINT [PK_Chitietdonhang] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Donhang_KhachHang]    Script Date: 6/24/2019 9:30:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Donhang_KhachHang](
	[IdDonHang] [int] IDENTITY(1,1) NOT NULL,
	[Idkhachhang] [int] NULL,
	[Ngaydat] [datetime] NULL,
	[Ngaygiao] [datetime] NULL,
	[Yeucau] [ntext] NULL,
	[Kieuthanhtoan] [nvarchar](100) NULL,
	[Trangthai] [int] NULL,
	[Duyet] [int] NULL,
	[Tennguoinhan] [nvarchar](50) NULL,
	[DTnguoinhan] [varchar](50) NULL,
	[EmailnguoiNhan] [varchar](50) NULL,
	[Diachinguoinhan] [nvarchar](200) NULL,
 CONSTRAINT [PK_Donhang_KhachHang_IdDonHang] PRIMARY KEY CLUSTERED 
(
	[IdDonHang] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[GroupSupport]    Script Date: 6/24/2019 9:30:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[GroupSupport](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](256) NULL,
	[Ord] [int] NULL,
	[Active] [int] NULL,
	[Lang] [varchar](5) NULL,
 CONSTRAINT [PRK_GroupSupport_Id] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[HangSX]    Script Date: 6/24/2019 9:30:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[HangSX](
	[IdHang] [int] IDENTITY(1,1) NOT NULL,
	[Mota] [ntext] NULL,
	[Website] [varchar](255) NULL,
	[LienHe] [nvarchar](max) NULL,
 CONSTRAINT [PK_HangSX_1] PRIMARY KEY CLUSTERED 
(
	[IdHang] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[KhachHang]    Script Date: 6/24/2019 9:30:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[KhachHang](
	[IdKhachhang] [int] IDENTITY(1,1) NOT NULL,
	[Tentruynhap] [nvarchar](100) NOT NULL,
	[Matkhau] [nvarchar](200) NOT NULL,
	[Tenkhachhang] [nvarchar](200) NULL,
	[Ngaysinh] [date] NULL,
	[Gioitinh] [nvarchar](10) NULL,
	[Diachi] [nvarchar](200) NULL,
	[Dienthoai] [varchar](12) NULL,
	[Email] [varchar](100) NULL,
	[Cauhoi] [nvarchar](300) NULL,
	[Traloi] [nvarchar](30) NULL,
	[Ngaytao] [datetime] NULL,
 CONSTRAINT [PK_KhachHang] PRIMARY KEY CLUSTERED 
(
	[IdKhachhang] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[LoaiSanPham]    Script Date: 6/24/2019 9:30:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[LoaiSanPham](
	[IdLoai] [int] IDENTITY(1,1) NOT NULL,
	[Ten] [nvarchar](256) NULL,
	[Tieude] [nvarchar](300) NULL,
	[Mota] [ntext] NULL,
	[Uutien] [smallint] NULL,
	[Hinhanh] [varchar](256) NULL,
	[Tukhoa] [nvarchar](300) NULL,
	[Vitri] [int] NULL,
 CONSTRAINT [PRK_LoaiDT_IdLoai] PRIMARY KEY CLUSTERED 
(
	[IdLoai] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Media]    Script Date: 6/24/2019 9:30:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Media](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Ten] [nvarchar](255) NULL,
	[LienKet] [nvarchar](512) NULL,
	[Vitri] [int] NULL,
	[Loai] [int] NULL,
 CONSTRAINT [PK_Video] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Menu]    Script Date: 6/24/2019 9:30:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Menu](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Ten] [nvarchar](50) NULL,
	[TieuDe] [nvarchar](50) NULL,
	[MoTa] [ntext] NULL,
	[Thutu] [int] NULL,
	[Trang] [nvarchar](50) NULL,
	[ThuMuc] [nvarchar](50) NULL,
	[Active] [bit] NULL,
 CONSTRAINT [PK_ThucDon] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[NguoiDung]    Script Date: 6/24/2019 9:30:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NguoiDung](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](32) NOT NULL CONSTRAINT [DF_NguoiDung_Username]  DEFAULT (''),
	[Password] [nvarchar](100) NOT NULL CONSTRAINT [DF_NguoiDung_Password]  DEFAULT (''),
	[Status] [bit] NOT NULL CONSTRAINT [DF_NguoiDung_Status]  DEFAULT ((1)),
 CONSTRAINT [PK_NguoiDung] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[QuangCao]    Script Date: 6/24/2019 9:30:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QuangCao](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[AdsName] [nvarchar](150) NOT NULL,
	[AdsUrl] [nvarchar](150) NOT NULL,
	[AdsImage] [nvarchar](150) NOT NULL,
	[AdsIndex] [int] NOT NULL,
	[AdsViewed] [int] NOT NULL,
 CONSTRAINT [PK_Ads] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Sanpham]    Script Date: 6/24/2019 9:30:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sanpham](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[MaSanPham] [nvarchar](50) NOT NULL,
	[IdLoai] [int] NULL,
	[Ten] [nvarchar](256) NOT NULL,
	[Model] [nvarchar](30) NULL,
	[MotaNgan] [nvarchar](300) NULL,
	[MotaChiTiet] [ntext] NULL,
	[TSKyThuat] [ntext] NULL,
	[Tukhoa] [nvarchar](300) NULL,
	[IdHang] [int] NULL,
	[NgayNhap] [date] NULL,
	[NgayCapNhatCuoi] [date] NULL,
	[GiaCu] [float] NULL,
	[GiaMoi] [float] NULL,
	[Uutien] [smallint] NULL,
	[HinhAnh] [nvarchar](300) NULL,
	[HinhAnh1] [nvarchar](300) NULL,
	[TieuBieu] [bit] NULL,
 CONSTRAINT [PRK_DienThoai_IdDienThoai] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Support]    Script Date: 6/24/2019 9:30:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Support](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](256) NULL,
	[Tel] [nvarchar](256) NULL,
	[Type] [int] NULL,
	[Nick] [varchar](128) NULL,
	[Ord] [int] NULL,
	[Active] [int] NULL,
	[GroupSupportId] [int] NULL,
	[Location] [int] NULL,
 CONSTRAINT [PRK_Support_Id] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbvisistor]    Script Date: 6/24/2019 9:30:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbvisistor](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[iuseronline] [int] NULL,
	[ivisistor] [bigint] NULL,
	[iuseronlinedate] [int] NULL,
	[dateonline] [datetime] NULL,
 CONSTRAINT [PRK_tbvisistor_Id] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[BaiVietHeThong] ADD  CONSTRAINT [DF_BaiVietHeThong_cCode]  DEFAULT ('') FOR [cCode]
GO
ALTER TABLE [dbo].[BaiVietHeThong] ADD  CONSTRAINT [DF_BaiVietHeThong_cValue]  DEFAULT ('') FOR [cValue]
GO
ALTER TABLE [dbo].[BaiVietHeThong] ADD  CONSTRAINT [DF_BaiVietHeThong_cLangID]  DEFAULT ('') FOR [cLangID]
GO
ALTER TABLE [dbo].[BaiVietHeThong] ADD  CONSTRAINT [DF_BaiVietHeThong_cUpdateTime]  DEFAULT (getdate()) FOR [cUpdateTime]
GO
ALTER TABLE [dbo].[Menu] ADD  CONSTRAINT [DF_ThucDon_Active]  DEFAULT ((1)) FOR [Active]
GO
ALTER TABLE [dbo].[QuangCao] ADD  CONSTRAINT [DF_Ads_AdsName]  DEFAULT ('') FOR [AdsName]
GO
ALTER TABLE [dbo].[QuangCao] ADD  CONSTRAINT [DF_Ads_AdsUrl]  DEFAULT ('') FOR [AdsUrl]
GO
ALTER TABLE [dbo].[QuangCao] ADD  CONSTRAINT [DF_Ads_AdsImage]  DEFAULT ('') FOR [AdsImage]
GO
ALTER TABLE [dbo].[QuangCao] ADD  CONSTRAINT [DF_Ads_AdsIndex]  DEFAULT ((1)) FOR [AdsIndex]
GO
ALTER TABLE [dbo].[QuangCao] ADD  CONSTRAINT [DF_Ads_AdsViewed]  DEFAULT ((0)) FOR [AdsViewed]
GO
ALTER TABLE [dbo].[Chitietdonhang]  WITH CHECK ADD  CONSTRAINT [FK_Chitietdonhang_Donhang_KhachHang] FOREIGN KEY([IdDonHang])
REFERENCES [dbo].[Donhang_KhachHang] ([IdDonHang])
GO
ALTER TABLE [dbo].[Chitietdonhang] CHECK CONSTRAINT [FK_Chitietdonhang_Donhang_KhachHang]
GO
ALTER TABLE [dbo].[Chitietdonhang]  WITH CHECK ADD  CONSTRAINT [FK_Chitietdonhang_Sanpham] FOREIGN KEY([IdSanPham])
REFERENCES [dbo].[Sanpham] ([id])
GO
ALTER TABLE [dbo].[Chitietdonhang] CHECK CONSTRAINT [FK_Chitietdonhang_Sanpham]
GO
ALTER TABLE [dbo].[Sanpham]  WITH CHECK ADD  CONSTRAINT [FK_Sanpham_HangSX] FOREIGN KEY([IdHang])
REFERENCES [dbo].[HangSX] ([IdHang])
GO
ALTER TABLE [dbo].[Sanpham] CHECK CONSTRAINT [FK_Sanpham_HangSX]
GO
ALTER TABLE [dbo].[Sanpham]  WITH CHECK ADD  CONSTRAINT [FK_SP_LoaiSP] FOREIGN KEY([IdLoai])
REFERENCES [dbo].[LoaiSanPham] ([IdLoai])
GO
ALTER TABLE [dbo].[Sanpham] CHECK CONSTRAINT [FK_SP_LoaiSP]
GO
USE [master]
GO
ALTER DATABASE [WebBanHang] SET  READ_WRITE 
GO
