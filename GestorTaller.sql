USE [master]
GO
/****** Object:  Database [Taller]    Script Date: 26/1/2022 16:51:22 ******/
CREATE DATABASE [Taller]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Taller', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Taller.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Taller_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Taller_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Taller] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Taller].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Taller] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Taller] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Taller] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Taller] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Taller] SET ARITHABORT OFF 
GO
ALTER DATABASE [Taller] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Taller] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Taller] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Taller] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Taller] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Taller] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Taller] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Taller] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Taller] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Taller] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Taller] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Taller] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Taller] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Taller] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Taller] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Taller] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Taller] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Taller] SET RECOVERY FULL 
GO
ALTER DATABASE [Taller] SET  MULTI_USER 
GO
ALTER DATABASE [Taller] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Taller] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Taller] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Taller] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Taller] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Taller] SET QUERY_STORE = OFF
GO
USE [Taller]
GO
/****** Object:  Table [dbo].[Articulo]    Script Date: 26/1/2022 16:51:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Articulo](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](max) NOT NULL,
	[Marca] [varchar](max) NOT NULL,
	[Descripcion] [varchar](max) NOT NULL,
 CONSTRAINT [PK_DispositivoElectronico] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Clientes]    Script Date: 26/1/2022 16:51:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clientes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](max) NOT NULL,
	[Apellidos] [varchar](max) NOT NULL,
	[Email] [varchar](max) NOT NULL,
	[Dirrecion] [varchar](max) NOT NULL,
 CONSTRAINT [PK_dbo.Clientes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DetalleOrdenesDeMantenimiento]    Script Date: 26/1/2022 16:51:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DetalleOrdenesDeMantenimiento](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Id_OrdenesDeMantenimiento] [int] NOT NULL,
	[Id_Mantenimiento] [int] NOT NULL,
 CONSTRAINT [PK_DetalleOrdenesDeMantenimiento] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Mantenimientos]    Script Date: 26/1/2022 16:51:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Mantenimientos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Id_Articulo] [int] NOT NULL,
	[Descripcion] [varchar](max) NOT NULL,
	[CostoFijo] [float] NOT NULL,
 CONSTRAINT [PK_MantenimientoDispositivoElectronico] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrdenesDeMantenimiento]    Script Date: 26/1/2022 16:51:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrdenesDeMantenimiento](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[NombreDelCliente] [varchar](100) NOT NULL,
	[Estado] [int] NOT NULL,
	[DescripcionDelProblema] [varchar](300) NOT NULL,
	[FechaDeIngreso] [datetime] NOT NULL,
	[MontoDeAdelanto] [money] NOT NULL,
	[Id_Articulo] [int] NOT NULL,
	[FechaDeInicio] [datetime] NULL,
	[FechaDeFinalizacion] [datetime] NULL,
	[MotivoDeCancelacion] [varchar](max) NULL,
 CONSTRAINT [PK_Ordenes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Repuestos]    Script Date: 26/1/2022 16:51:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Repuestos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](max) NOT NULL,
	[Id_Articulo] [int] NOT NULL,
	[Precio] [float] NOT NULL,
	[Descripcion] [varchar](max) NOT NULL,
 CONSTRAINT [PK_RepuestosDispositivoElectronico] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RepuestosParaMantenimiento]    Script Date: 26/1/2022 16:51:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RepuestosParaMantenimiento](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Id_Mantenimiento] [int] NOT NULL,
	[Id_Repuesto] [int] NOT NULL,
 CONSTRAINT [PK_RepuestosParaMantenimiento] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[DetalleOrdenesDeMantenimiento]  WITH CHECK ADD  CONSTRAINT [FK_DetalleOrdenesDeMantenimiento_Mantenimientos] FOREIGN KEY([Id_Mantenimiento])
REFERENCES [dbo].[Mantenimientos] ([Id])
GO
ALTER TABLE [dbo].[DetalleOrdenesDeMantenimiento] CHECK CONSTRAINT [FK_DetalleOrdenesDeMantenimiento_Mantenimientos]
GO
ALTER TABLE [dbo].[DetalleOrdenesDeMantenimiento]  WITH CHECK ADD  CONSTRAINT [FK_DetalleOrdenesDeMantenimiento_OrdenesDeMantenimiento] FOREIGN KEY([Id_OrdenesDeMantenimiento])
REFERENCES [dbo].[OrdenesDeMantenimiento] ([Id])
GO
ALTER TABLE [dbo].[DetalleOrdenesDeMantenimiento] CHECK CONSTRAINT [FK_DetalleOrdenesDeMantenimiento_OrdenesDeMantenimiento]
GO
ALTER TABLE [dbo].[Mantenimientos]  WITH CHECK ADD  CONSTRAINT [FK_Mantenimientos_Articulo] FOREIGN KEY([Id_Articulo])
REFERENCES [dbo].[Articulo] ([Id])
GO
ALTER TABLE [dbo].[Mantenimientos] CHECK CONSTRAINT [FK_Mantenimientos_Articulo]
GO
ALTER TABLE [dbo].[OrdenesDeMantenimiento]  WITH CHECK ADD  CONSTRAINT [FK_OrdenesDeMantenimiento_Articulo] FOREIGN KEY([Id_Articulo])
REFERENCES [dbo].[Articulo] ([Id])
GO
ALTER TABLE [dbo].[OrdenesDeMantenimiento] CHECK CONSTRAINT [FK_OrdenesDeMantenimiento_Articulo]
GO
ALTER TABLE [dbo].[Repuestos]  WITH CHECK ADD  CONSTRAINT [FK_Repuestos_Articulo] FOREIGN KEY([Id_Articulo])
REFERENCES [dbo].[Articulo] ([Id])
GO
ALTER TABLE [dbo].[Repuestos] CHECK CONSTRAINT [FK_Repuestos_Articulo]
GO
ALTER TABLE [dbo].[RepuestosParaMantenimiento]  WITH CHECK ADD  CONSTRAINT [FK_RepuestosParaMantenimiento_Mantenimientos] FOREIGN KEY([Id_Mantenimiento])
REFERENCES [dbo].[Mantenimientos] ([Id])
GO
ALTER TABLE [dbo].[RepuestosParaMantenimiento] CHECK CONSTRAINT [FK_RepuestosParaMantenimiento_Mantenimientos]
GO
ALTER TABLE [dbo].[RepuestosParaMantenimiento]  WITH CHECK ADD  CONSTRAINT [FK_RepuestosParaMantenimiento_Repuestos] FOREIGN KEY([Id_Repuesto])
REFERENCES [dbo].[Repuestos] ([Id])
GO
ALTER TABLE [dbo].[RepuestosParaMantenimiento] CHECK CONSTRAINT [FK_RepuestosParaMantenimiento_Repuestos]
GO
USE [master]
GO
ALTER DATABASE [Taller] SET  READ_WRITE 
GO
