USE [master]
GO
/****** Object:  Database [GaleriProje3]    Script Date: 5.06.2022 20:28:43 ******/
CREATE DATABASE [GaleriProje3]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'GaleriProje3', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\GaleriProje3.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'GaleriProje3_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\GaleriProje3_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [GaleriProje3] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [GaleriProje3].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [GaleriProje3] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [GaleriProje3] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [GaleriProje3] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [GaleriProje3] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [GaleriProje3] SET ARITHABORT OFF 
GO
ALTER DATABASE [GaleriProje3] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [GaleriProje3] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [GaleriProje3] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [GaleriProje3] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [GaleriProje3] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [GaleriProje3] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [GaleriProje3] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [GaleriProje3] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [GaleriProje3] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [GaleriProje3] SET  DISABLE_BROKER 
GO
ALTER DATABASE [GaleriProje3] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [GaleriProje3] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [GaleriProje3] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [GaleriProje3] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [GaleriProje3] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [GaleriProje3] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [GaleriProje3] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [GaleriProje3] SET RECOVERY FULL 
GO
ALTER DATABASE [GaleriProje3] SET  MULTI_USER 
GO
ALTER DATABASE [GaleriProje3] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [GaleriProje3] SET DB_CHAINING OFF 
GO
ALTER DATABASE [GaleriProje3] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [GaleriProje3] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [GaleriProje3] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [GaleriProje3] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'GaleriProje3', N'ON'
GO
ALTER DATABASE [GaleriProje3] SET QUERY_STORE = OFF
GO
USE [GaleriProje3]
GO
/****** Object:  Table [dbo].[arac]    Script Date: 5.06.2022 20:28:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[arac](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[fiyat] [int] NULL,
	[adet] [int] NULL,
	[marka] [varchar](50) NULL,
	[model] [varchar](50) NULL,
	[yil] [varchar](50) NULL,
	[ozellik] [varchar](50) NULL,
	[motor] [varchar](50) NULL,
	[renk] [varchar](50) NULL,
 CONSTRAINT [PK_arac] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Kullanici]    Script Date: 5.06.2022 20:28:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Kullanici](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[kulAd] [varchar](50) NULL,
	[Sifre] [varchar](50) NULL,
 CONSTRAINT [PK_Kullanici] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Musteri]    Script Date: 5.06.2022 20:28:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Musteri](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nameSurname] [varchar](50) NULL,
	[adress] [varchar](50) NULL,
	[phone] [char](12) NULL,
 CONSTRAINT [PK_Musteri] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Satis]    Script Date: 5.06.2022 20:28:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Satis](
	[SatisId] [int] IDENTITY(1,1) NOT NULL,
	[SubeId] [int] NULL,
	[MusteriId] [int] NULL,
	[AracId] [int] NULL,
	[SatisTarih] [date] NULL,
 CONSTRAINT [PK_Satis] PRIMARY KEY CLUSTERED 
(
	[SatisId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sube]    Script Date: 5.06.2022 20:28:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sube](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[SubeAd] [varchar](50) NULL,
	[CalisanSayisi] [int] NULL,
	[SubeCiro] [int] NULL,
 CONSTRAINT [PK_Sube] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[arac] ON 

INSERT [dbo].[arac] ([id], [fiyat], [adet], [marka], [model], [yil], [ozellik], [motor], [renk]) VALUES (2, 150000, 1, N'Opel', N'Astra', N'2000', N'zscdfs', N'bb', N'Kırmızı')
INSERT [dbo].[arac] ([id], [fiyat], [adet], [marka], [model], [yil], [ozellik], [motor], [renk]) VALUES (6, 100000, 100, N'Ford', N'Fiesta', N'2010', N'a', N'aa', N'Mint')
SET IDENTITY_INSERT [dbo].[arac] OFF
GO
SET IDENTITY_INSERT [dbo].[Kullanici] ON 

INSERT [dbo].[Kullanici] ([id], [kulAd], [Sifre]) VALUES (1, N'm', N'm')
INSERT [dbo].[Kullanici] ([id], [kulAd], [Sifre]) VALUES (2, N'ali', N'a')
INSERT [dbo].[Kullanici] ([id], [kulAd], [Sifre]) VALUES (8, N'irem', N'irem12')
INSERT [dbo].[Kullanici] ([id], [kulAd], [Sifre]) VALUES (9, N'Alican015', N'ali')
SET IDENTITY_INSERT [dbo].[Kullanici] OFF
GO
SET IDENTITY_INSERT [dbo].[Musteri] ON 

INSERT [dbo].[Musteri] ([id], [nameSurname], [adress], [phone]) VALUES (6, N'Akif Sönmez', N'Şişli', N'05345624454 ')
INSERT [dbo].[Musteri] ([id], [nameSurname], [adress], [phone]) VALUES (7, N'Fikri Ertürk', N'Bağcılar', N'021200000000')
INSERT [dbo].[Musteri] ([id], [nameSurname], [adress], [phone]) VALUES (14, N'Asude', N'NİŞANTAŞI', N'0212345586  ')
SET IDENTITY_INSERT [dbo].[Musteri] OFF
GO
SET IDENTITY_INSERT [dbo].[Satis] ON 

INSERT [dbo].[Satis] ([SatisId], [SubeId], [MusteriId], [AracId], [SatisTarih]) VALUES (1, 1, 6, 2, CAST(N'2022-05-18' AS Date))
INSERT [dbo].[Satis] ([SatisId], [SubeId], [MusteriId], [AracId], [SatisTarih]) VALUES (2, 2, 7, 6, CAST(N'2021-08-12' AS Date))
INSERT [dbo].[Satis] ([SatisId], [SubeId], [MusteriId], [AracId], [SatisTarih]) VALUES (3, 1, 14, 2, CAST(N'1996-08-22' AS Date))
INSERT [dbo].[Satis] ([SatisId], [SubeId], [MusteriId], [AracId], [SatisTarih]) VALUES (4, 2, 7, 6, CAST(N'2022-04-16' AS Date))
SET IDENTITY_INSERT [dbo].[Satis] OFF
GO
SET IDENTITY_INSERT [dbo].[Sube] ON 

INSERT [dbo].[Sube] ([id], [SubeAd], [CalisanSayisi], [SubeCiro]) VALUES (1, N'Asil CAR', 100, 120000)
INSERT [dbo].[Sube] ([id], [SubeAd], [CalisanSayisi], [SubeCiro]) VALUES (2, N'Akel', 21321, 3242432)
SET IDENTITY_INSERT [dbo].[Sube] OFF
GO
ALTER TABLE [dbo].[Satis]  WITH CHECK ADD  CONSTRAINT [FK_Satis_arac] FOREIGN KEY([AracId])
REFERENCES [dbo].[arac] ([id])
GO
ALTER TABLE [dbo].[Satis] CHECK CONSTRAINT [FK_Satis_arac]
GO
ALTER TABLE [dbo].[Satis]  WITH CHECK ADD  CONSTRAINT [FK_Satis_Musteri] FOREIGN KEY([MusteriId])
REFERENCES [dbo].[Musteri] ([id])
GO
ALTER TABLE [dbo].[Satis] CHECK CONSTRAINT [FK_Satis_Musteri]
GO
ALTER TABLE [dbo].[Satis]  WITH CHECK ADD  CONSTRAINT [FK_Satis_Sube] FOREIGN KEY([SubeId])
REFERENCES [dbo].[Sube] ([id])
GO
ALTER TABLE [dbo].[Satis] CHECK CONSTRAINT [FK_Satis_Sube]
GO
USE [master]
GO
ALTER DATABASE [GaleriProje3] SET  READ_WRITE 
GO
