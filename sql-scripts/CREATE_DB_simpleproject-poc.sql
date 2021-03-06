USE [master]
GO

/****** Object:  Database [simpleproject-poc]    Script Date: 05.03.2021 19:47:07 ******/
CREATE DATABASE [simpleproject-poc]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'simpleproject-poc', FILENAME = N'D:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\simpleproject-poc.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'simpleproject-poc_log', FILENAME = N'D:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\simpleproject-poc_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [simpleproject-poc].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [simpleproject-poc] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [simpleproject-poc] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [simpleproject-poc] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [simpleproject-poc] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [simpleproject-poc] SET ARITHABORT OFF 
GO

ALTER DATABASE [simpleproject-poc] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [simpleproject-poc] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [simpleproject-poc] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [simpleproject-poc] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [simpleproject-poc] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [simpleproject-poc] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [simpleproject-poc] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [simpleproject-poc] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [simpleproject-poc] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [simpleproject-poc] SET  DISABLE_BROKER 
GO

ALTER DATABASE [simpleproject-poc] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [simpleproject-poc] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [simpleproject-poc] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [simpleproject-poc] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [simpleproject-poc] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [simpleproject-poc] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [simpleproject-poc] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [simpleproject-poc] SET RECOVERY SIMPLE 
GO

ALTER DATABASE [simpleproject-poc] SET  MULTI_USER 
GO

ALTER DATABASE [simpleproject-poc] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [simpleproject-poc] SET DB_CHAINING OFF 
GO

ALTER DATABASE [simpleproject-poc] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [simpleproject-poc] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO

ALTER DATABASE [simpleproject-poc] SET DELAYED_DURABILITY = DISABLED 
GO

ALTER DATABASE [simpleproject-poc] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO

ALTER DATABASE [simpleproject-poc] SET QUERY_STORE = OFF
GO

ALTER DATABASE [simpleproject-poc] SET  READ_WRITE 
GO

