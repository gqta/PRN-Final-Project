USE [master]
GO
/****** Object:  Database [QuizOnline]    Script Date: 04/03/2021 14:40:01 ******/
CREATE DATABASE [QuizOnline]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'QuizOnline', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\QuizOnline.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'QuizOnline_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\QuizOnline_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [QuizOnline] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [QuizOnline].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [QuizOnline] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [QuizOnline] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [QuizOnline] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [QuizOnline] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [QuizOnline] SET ARITHABORT OFF 
GO
ALTER DATABASE [QuizOnline] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [QuizOnline] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [QuizOnline] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [QuizOnline] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [QuizOnline] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [QuizOnline] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [QuizOnline] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [QuizOnline] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [QuizOnline] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [QuizOnline] SET  ENABLE_BROKER 
GO
ALTER DATABASE [QuizOnline] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [QuizOnline] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [QuizOnline] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [QuizOnline] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [QuizOnline] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [QuizOnline] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [QuizOnline] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [QuizOnline] SET RECOVERY FULL 
GO
ALTER DATABASE [QuizOnline] SET  MULTI_USER 
GO
ALTER DATABASE [QuizOnline] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [QuizOnline] SET DB_CHAINING OFF 
GO
ALTER DATABASE [QuizOnline] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [QuizOnline] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [QuizOnline] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [QuizOnline] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'QuizOnline', N'ON'
GO
ALTER DATABASE [QuizOnline] SET QUERY_STORE = OFF
GO
USE [QuizOnline]
GO
/****** Object:  User [IIS APPPOOL\quiz]    Script Date: 04/03/2021 14:40:02 ******/
CREATE USER [IIS APPPOOL\quiz] FOR LOGIN [IIS APPPOOL\quiz] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_accessadmin] ADD MEMBER [IIS APPPOOL\quiz]
GO
ALTER ROLE [db_datareader] ADD MEMBER [IIS APPPOOL\quiz]
GO
ALTER ROLE [db_datawriter] ADD MEMBER [IIS APPPOOL\quiz]
GO
/****** Object:  Table [dbo].[Progress]    Script Date: 04/03/2021 14:40:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Progress](
	[progressld] [int] IDENTITY(1,1) NOT NULL,
	[username] [varchar](16) NULL,
	[quizId] [int] NULL,
	[lastLearn] [datetime] NOT NULL,
	[progress] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[progressld] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Quiz]    Script Date: 04/03/2021 14:40:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Quiz](
	[username] [varchar](16) NOT NULL,
	[quizId] [int] IDENTITY(1,1) NOT NULL,
	[quizName] [nvarchar](50) NOT NULL,
	[quizDescription] [nvarchar](200) NOT NULL,
	[access] [int] NULL,
	[createdDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[quizId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[QuizDetail]    Script Date: 04/03/2021 14:40:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QuizDetail](
	[quizId] [int] NOT NULL,
	[termId] [int] IDENTITY(1,1) NOT NULL,
	[key] [nvarchar](max) NOT NULL,
	[value] [nvarchar](max) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[termId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 04/03/2021 14:40:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[username] [varchar](16) NOT NULL,
	[password] [varchar](max) NULL,
	[email] [varchar](50) NOT NULL,
	[fullName] [nvarchar](50) NOT NULL,
	[activeCode] [varchar](16) NULL,
	[status] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Progress] ON 

INSERT [dbo].[Progress] ([progressld], [username], [quizId], [lastLearn], [progress]) VALUES (1, N'havusontung007', 1, CAST(N'2021-04-03T11:07:41.813' AS DateTime), 0)
INSERT [dbo].[Progress] ([progressld], [username], [quizId], [lastLearn], [progress]) VALUES (2, N'thanhgq', 2, CAST(N'2021-04-03T11:23:18.243' AS DateTime), 6)
INSERT [dbo].[Progress] ([progressld], [username], [quizId], [lastLearn], [progress]) VALUES (4, N'havusontung007', 5, CAST(N'2021-04-01T23:40:53.790' AS DateTime), 0)
INSERT [dbo].[Progress] ([progressld], [username], [quizId], [lastLearn], [progress]) VALUES (5, N'thanhgq', 1, CAST(N'2021-04-03T03:31:11.907' AS DateTime), 0)
INSERT [dbo].[Progress] ([progressld], [username], [quizId], [lastLearn], [progress]) VALUES (6, N'thanhanh', 1, CAST(N'2021-04-03T11:45:52.047' AS DateTime), 2)
INSERT [dbo].[Progress] ([progressld], [username], [quizId], [lastLearn], [progress]) VALUES (7, N'thanhanh', 2, CAST(N'2021-04-03T12:09:38.810' AS DateTime), 8)
INSERT [dbo].[Progress] ([progressld], [username], [quizId], [lastLearn], [progress]) VALUES (8, N'thanhanh', 17, CAST(N'2021-04-03T13:53:34.317' AS DateTime), 7)
INSERT [dbo].[Progress] ([progressld], [username], [quizId], [lastLearn], [progress]) VALUES (9, N'voodanh', 2, CAST(N'2021-04-03T14:32:12.777' AS DateTime), 0)
INSERT [dbo].[Progress] ([progressld], [username], [quizId], [lastLearn], [progress]) VALUES (10, N'voodanh', 1, CAST(N'2021-04-03T14:37:34.057' AS DateTime), 0)
SET IDENTITY_INSERT [dbo].[Progress] OFF
GO
SET IDENTITY_INSERT [dbo].[Quiz] ON 

INSERT [dbo].[Quiz] ([username], [quizId], [quizName], [quizDescription], [access], [createdDate]) VALUES (N'havusontung007', 1, N'VNI101', N'Món ăn Việt Nam', 2, CAST(N'2021-04-02T21:01:13.290' AS DateTime))
INSERT [dbo].[Quiz] ([username], [quizId], [quizName], [quizDescription], [access], [createdDate]) VALUES (N'thanhgq', 2, N'VNI102', N'Địa danh nổi tiếng ở Việt Nam', 2, CAST(N'2021-04-02T21:01:13.290' AS DateTime))
INSERT [dbo].[Quiz] ([username], [quizId], [quizName], [quizDescription], [access], [createdDate]) VALUES (N'havusontung007', 5, N'VNI103', N'Phim Ảnh', 2, CAST(N'2021-04-02T21:01:13.290' AS DateTime))
INSERT [dbo].[Quiz] ([username], [quizId], [quizName], [quizDescription], [access], [createdDate]) VALUES (N'thanhgq', 16, N'MG666', N'Văn Học ', 2, CAST(N'2021-04-02T08:21:28.127' AS DateTime))
INSERT [dbo].[Quiz] ([username], [quizId], [quizName], [quizDescription], [access], [createdDate]) VALUES (N'havusontung007', 17, N'HTR111', N'Lich Su Viet Nam', 2, CAST(N'2021-04-02T08:30:07.797' AS DateTime))
SET IDENTITY_INSERT [dbo].[Quiz] OFF
GO
SET IDENTITY_INSERT [dbo].[QuizDetail] ON 

INSERT [dbo].[QuizDetail] ([quizId], [termId], [key], [value]) VALUES (1, 4, N'Hòa Lạc', N'Bún bò ngon nhất là ở đâu ?')
INSERT [dbo].[QuizDetail] ([quizId], [termId], [key], [value]) VALUES (1, 5, N'Thanh Hóa', N'Nem chua có xuất sứ ở đâu ?')
INSERT [dbo].[QuizDetail] ([quizId], [termId], [key], [value]) VALUES (1, 6, N'Vũng Tàu', N'Nơi nào sau đây ở Việt Nam có vùng biển được bình chọn là đẹp nhất năm 2018 ?')
INSERT [dbo].[QuizDetail] ([quizId], [termId], [key], [value]) VALUES (1, 7, N'Hà Nội', N'Đâu là thử đô của Việt Nam ?')
INSERT [dbo].[QuizDetail] ([quizId], [termId], [key], [value]) VALUES (2, 8, N'Ai Cập', N'Kim tự tháp Giza thuộc đất nước nào sau đây ?')
INSERT [dbo].[QuizDetail] ([quizId], [termId], [key], [value]) VALUES (2, 9, N'Anh', N'Tháp đồng hồ Big Ben thuộc đất nước nào ?')
INSERT [dbo].[QuizDetail] ([quizId], [termId], [key], [value]) VALUES (2, 10, N'Trung Quốc', N'Vạn lý trường thành nằm ở đâu ?')
INSERT [dbo].[QuizDetail] ([quizId], [termId], [key], [value]) VALUES (2, 11, N'Brazil', N'Đất nước nào có sản lượng cà phê cao nhất thế giới ?')
INSERT [dbo].[QuizDetail] ([quizId], [termId], [key], [value]) VALUES (5, 12, N'Avatar', N'Trong những bộ phim sau đây, phim nào đạt doanh thu cao nhất từ trước đến nay ?')
INSERT [dbo].[QuizDetail] ([quizId], [termId], [key], [value]) VALUES (5, 13, N'Avenger : Endgame', N'Bộ phim nào đạt doanh thu cao nhất năm 2020 ?')
INSERT [dbo].[QuizDetail] ([quizId], [termId], [key], [value]) VALUES (5, 14, N'Avenger : Infinity War', N'Bộ phim nào đạt doanh thu cao nhất năm 2019 ?')
INSERT [dbo].[QuizDetail] ([quizId], [termId], [key], [value]) VALUES (5, 15, N'Inception', N'Trong những bộ phim sau đây, bộ phim nào có sự xuất hiện của nam diễn viên Leonardo Dicaprio')
INSERT [dbo].[QuizDetail] ([quizId], [termId], [key], [value]) VALUES (17, 16, N'Hội Đền Hai Bà Trưng', N'Di sản thời Trưng Vương ?')
INSERT [dbo].[QuizDetail] ([quizId], [termId], [key], [value]) VALUES (17, 17, N'Di tích chiến thắng Bạch Đằng', N'Di tích nhà Trần ?')
INSERT [dbo].[QuizDetail] ([quizId], [termId], [key], [value]) VALUES (17, 18, N'Đền Hùng', N'Di tích thời Hùng Vương ?')
INSERT [dbo].[QuizDetail] ([quizId], [termId], [key], [value]) VALUES (17, 19, N'Chùa Tây Phương', N'Di tích tiêu biểu triều đại Tây Sơn ?')
INSERT [dbo].[QuizDetail] ([quizId], [termId], [key], [value]) VALUES (17, 20, N'Chùa Một Cột', N'Di sản văn hóa nhà Lý?')
INSERT [dbo].[QuizDetail] ([quizId], [termId], [key], [value]) VALUES (5, 21, N'Yêu em từ cái nhìn đầu tiên', N'Bộ phim được yêu thích năm 2016 ?')
INSERT [dbo].[QuizDetail] ([quizId], [termId], [key], [value]) VALUES (5, 22, N'Người Tiên Phong', N'Bộ phim được đánh giá cao nhất ?')
INSERT [dbo].[QuizDetail] ([quizId], [termId], [key], [value]) VALUES (5, 23, N'Ký sinh trùng', N'bộ phim đoạt giải oscar 2020 ?')
INSERT [dbo].[QuizDetail] ([quizId], [termId], [key], [value]) VALUES (5, 24, N'đạo diễn Bong Joon Ho', N'Đạo diễn đoạt giải oscar 2020')
INSERT [dbo].[QuizDetail] ([quizId], [termId], [key], [value]) VALUES (5, 25, N'Công xưởng Hoa Kỳ', N'Phim tài liệu xuất sắc nhất 2020?')
INSERT [dbo].[QuizDetail] ([quizId], [termId], [key], [value]) VALUES (5, 26, N'Nhóc Jojo', N'Kịch bản chuyển thể xuất sắc nhất ?')
INSERT [dbo].[QuizDetail] ([quizId], [termId], [key], [value]) VALUES (5, 27, N'Kí Sinh Trùng', N'Kịch bản gốc xuất sắc nhất 2020?')
INSERT [dbo].[QuizDetail] ([quizId], [termId], [key], [value]) VALUES (5, 28, N'Khung cửa sổ nhà hàng xóm', N'Phim ngắn xuất sắc nhất ?')
INSERT [dbo].[QuizDetail] ([quizId], [termId], [key], [value]) VALUES (5, 29, N'Joker', N'Nam diễn viên chính xuất sắc nhất?')
INSERT [dbo].[QuizDetail] ([quizId], [termId], [key], [value]) VALUES (5, 30, N'Joker', N'Nhạc phim xuất sắc nhất ?')
INSERT [dbo].[QuizDetail] ([quizId], [termId], [key], [value]) VALUES (5, 31, N'Chuyện ngày xưa ở Hollywood', N'Thiết kế sản xuất xuất sắc nhất ?')
INSERT [dbo].[QuizDetail] ([quizId], [termId], [key], [value]) VALUES (5, 32, N'Cuộc đua lịch sử', N'Biên tập âm thanh xuất sắc nhất ?')
INSERT [dbo].[QuizDetail] ([quizId], [termId], [key], [value]) VALUES (5, 33, N'Thế chiến I', N'Quay phim xuất sắc nhất?')
INSERT [dbo].[QuizDetail] ([quizId], [termId], [key], [value]) VALUES (5, 34, N'Rocketman', N'Ca khúc trong phim xuất sắc nhất')
INSERT [dbo].[QuizDetail] ([quizId], [termId], [key], [value]) VALUES (5, 35, N'Plan 9 From Outer Space', N'Giải Mâm xôi vàng cho phim dở nhất ?')
INSERT [dbo].[QuizDetail] ([quizId], [termId], [key], [value]) VALUES (5, 36, N'Yêu em từ cái nhìn cầu tiên', N'Phim có lượt xem cao nhất năm 2016?')
INSERT [dbo].[QuizDetail] ([quizId], [termId], [key], [value]) VALUES (17, 37, N'Ninh Bình', N'Cố đô Hoa Lư thuộc tỉnh?')
INSERT [dbo].[QuizDetail] ([quizId], [termId], [key], [value]) VALUES (17, 38, N'Hà Nội', N'Đại La là tên cũ của?')
INSERT [dbo].[QuizDetail] ([quizId], [termId], [key], [value]) VALUES (17, 39, N'Minh Mạng', N'Tên Hà Nội có từ thời vua nào?')
INSERT [dbo].[QuizDetail] ([quizId], [termId], [key], [value]) VALUES (17, 40, N'1993', N'Quần thể di tích Huế được công nhận là di sản văn hóa thế giới năm nào?')
INSERT [dbo].[QuizDetail] ([quizId], [termId], [key], [value]) VALUES (17, 41, N'Đảo Lý Sơn', N'Đảo lớn nhất Việt Nam là đảo nào?')
INSERT [dbo].[QuizDetail] ([quizId], [termId], [key], [value]) VALUES (17, 42, N'Quảng Nam', N'Quần thể thánh địa Mỹ Sơn thuộc tỉnh nào?')
INSERT [dbo].[QuizDetail] ([quizId], [termId], [key], [value]) VALUES (17, 43, N'Di sản quần thể di tích cố đô Huế.', N'Di sản nào sau đây không phải là di sản văn hóa phi vật thể của thế giới tại Việt nam?')
INSERT [dbo].[QuizDetail] ([quizId], [termId], [key], [value]) VALUES (17, 44, N'Vị trí địa lí và tài nguyên du lịch', N'Sự phân hóa lãnh thổ du lịch nước ta phụ thuộc vào các yếu tố nào sau đây?')
INSERT [dbo].[QuizDetail] ([quizId], [termId], [key], [value]) VALUES (17, 45, N'Anh - Mĩ - Liên Xô.', N' Hội nghị Ianta (1945) có sự tham gia của các nước nào?')
INSERT [dbo].[QuizDetail] ([quizId], [termId], [key], [value]) VALUES (17, 46, N'Nhật Bản bị quân đội Mĩ chiếm đóng.', N'Tương lai của Nhật Bản được quyết định như thế nào theo Hội nghị Ianta (2-1945)?')
INSERT [dbo].[QuizDetail] ([quizId], [termId], [key], [value]) VALUES (17, 47, N'Tổ chức lại thế giới sau chiến tranh.', N'Nội dung nào không phải là mục đích triệu tập Hội nghị Ianta (tháng 2-1945)?')
INSERT [dbo].[QuizDetail] ([quizId], [termId], [key], [value]) VALUES (17, 48, N'Yêu cầu thắt chặt khối đồng minh chống phát xít', N'Đâu không phải là nguyên nhân dẫn tới việc các cường quốc đồng minh triệu tập Hội nghị Ianta (2-1945)?')
INSERT [dbo].[QuizDetail] ([quizId], [termId], [key], [value]) VALUES (17, 49, N'Sau khi đánh bại phát xít Đức, Liên Xô sẽ tham chiến chống Nhật ở châu Á.', N'Theo Hội nghị Ianta, để nhanh chóng kết thúc nhanh chiến tranh, ba cường quốc đã thống nhất điều gì?')
INSERT [dbo].[QuizDetail] ([quizId], [termId], [key], [value]) VALUES (17, 50, N'Trật tự thế giới mới phân thành 2 cực đứng đầu là Mĩ - Liên Xô được đặt khuôn khổ từ Hội nghị Ianta. ', N'Vì sao gọi là “trật tự hai cực Ianta”?')
INSERT [dbo].[QuizDetail] ([quizId], [termId], [key], [value]) VALUES (17, 51, N'Tạo điều kiện để các nước phương Tây khôi phục lại quyền thống trị ở các thuộc địa cũ', N'Những quyết định của hội nghị Ianta (2-1945) có hạn chế gì?')
INSERT [dbo].[QuizDetail] ([quizId], [termId], [key], [value]) VALUES (16, 52, N'Làng Phượng Trì, huyện Đan Phượng (nay thuộc Hà Nội)', N'Địa danh nào dưới đây là quê hương của Quang Dũng?')
INSERT [dbo].[QuizDetail] ([quizId], [termId], [key], [value]) VALUES (16, 53, N'Dạy học', N'Trước Cách mạng tháng Tám, Quang Dũng làm công việc gì?')
INSERT [dbo].[QuizDetail] ([quizId], [termId], [key], [value]) VALUES (16, 54, N'1947', N'Quang Dũng làm Đại đội trưởng ở tiểu đoàn 212, Trung đoàn 52 Tây Tiến năm bao nhiêu?')
INSERT [dbo].[QuizDetail] ([quizId], [termId], [key], [value]) VALUES (16, 55, N'Cuối năm 1948', N'Quang Dũng làm Trưởng tiểu ban tuyên huấn của Trung đoàn 52 Tây Tiến năm bao nhiêu?')
INSERT [dbo].[QuizDetail] ([quizId], [termId], [key], [value]) VALUES (16, 56, N'Giải thưởng Nhà nước về Văn học Nghệ thuật', N'Năm 2001, Quang Dũng được trao tặng giải thưởng gì?')
INSERT [dbo].[QuizDetail] ([quizId], [termId], [key], [value]) VALUES (16, 57, N'Mang hồn thơ phóng khoáng, hồn hậu, lãng mạn và tài hoa', N'Phong cách sáng tác của nhà thơ Quang Dũng là:')
INSERT [dbo].[QuizDetail] ([quizId], [termId], [key], [value]) VALUES (16, 58, N'Sáng tác nhạc', N'Quang Dũng đã từng làm những lĩnh vực nào dưới đây?')
INSERT [dbo].[QuizDetail] ([quizId], [termId], [key], [value]) VALUES (16, 59, N'Mấy đầu ô (1986)', N'Tích vào những tác phẩm không phải của nhà thơ Quang Dũng:')
INSERT [dbo].[QuizDetail] ([quizId], [termId], [key], [value]) VALUES (16, 60, N'Cuối năm 1948, khi Quang Dũng không còn ở đoàn quân Tây Tiến mà đã chuyển sang đơn vị khác.', N'Bài thơ “Tây Tiến” được Quang Dũng sáng tác trong hoàn cảnh nào?')
INSERT [dbo].[QuizDetail] ([quizId], [termId], [key], [value]) VALUES (16, 61, N'1947', N' Đoàn quân Tây Tiến được thành lập năm nào?')
INSERT [dbo].[QuizDetail] ([quizId], [termId], [key], [value]) VALUES (16, 62, N'Phối hợp với bộ đội Lào để bảo vệ biên giới Việt-Lào.', N'Nhiệm vụ của đoàn quân Tây Tiến là gì?')
INSERT [dbo].[QuizDetail] ([quizId], [termId], [key], [value]) VALUES (16, 63, N'Lính Tây Tiến phần đông là thanh niên Hà Nội, trong đó có nhiều học sinh, sinh viên tri thức.', N'Lời giới thiệu nào về lính Tây Tiến là cụ thể và chính xác nhất?')
INSERT [dbo].[QuizDetail] ([quizId], [termId], [key], [value]) VALUES (16, 64, N'Nhớ Tây Tiến', N'Bài thơ “Tây Tiến” của Quang Dũng còn có tên khác nào trong các tên sau đây?')
INSERT [dbo].[QuizDetail] ([quizId], [termId], [key], [value]) VALUES (16, 66, N'Ngôn ngữ thơ linh hoạt, đa dạng', N'Đáp án nào không phải biện pháp nghệ thuật được sử dụng trong bài thơ Tây Tiến?')
INSERT [dbo].[QuizDetail] ([quizId], [termId], [key], [value]) VALUES (16, 68, N'“Em”, các cô gái dân tộc nơi đoàn quân Tây Tiến đóng quân.', N'Nhân vật trung tâm trong đêm lửa trại ở đoạn thơ thứ hai là ai?')
INSERT [dbo].[QuizDetail] ([quizId], [termId], [key], [value]) VALUES (16, 69, N'Hình tượng người lính Tây Tiến', N'Nội dung chính đoạn 3 bài thơ “Tây Tiến” là:')
INSERT [dbo].[QuizDetail] ([quizId], [termId], [key], [value]) VALUES (16, 70, N'Nhân hóa “Sông Mã gầm lên”', N'Hai câu thơ sau sử dụng biện pháp nghệ thuật gì?')
INSERT [dbo].[QuizDetail] ([quizId], [termId], [key], [value]) VALUES (16, 71, N' Lời thề gắn bó với đoàn quân Tây Tiến và miền Tây Bắc', N'Nội dung chính đoạn 4 bài thơ “Tây Tiến” là:')
INSERT [dbo].[QuizDetail] ([quizId], [termId], [key], [value]) VALUES (16, 72, N'ô đậm bầu không khí chung của một thời Tây Tiến với lời thề cổ kim: ra đi không hẹn ngày về, một đi không trở lại', N'Câu thơ “Tây Tiến người đi không hẹn ước” được hiểu như thế nào?')
INSERT [dbo].[QuizDetail] ([quizId], [termId], [key], [value]) VALUES (16, 73, N'Tính triết lý, suy tưởng.', N'Đáp án nào sau đây không phải nội dung thơ của Tố Hữu?')
INSERT [dbo].[QuizDetail] ([quizId], [termId], [key], [value]) VALUES (1, 74, N'Sóc Trăng', N'Bánh Pía là đặc sản của tỉnh nào sau đây?')
INSERT [dbo].[QuizDetail] ([quizId], [termId], [key], [value]) VALUES (1, 76, N'Đà Lạt', N'Bánh tráng nướng là món ăn nổi tiếng nhất ở địa phương nào?')
INSERT [dbo].[QuizDetail] ([quizId], [termId], [key], [value]) VALUES (1, 77, N'Lẩu mắm', N'U Minh nổi tiếng với món đặc sản nào sau đây? ')
INSERT [dbo].[QuizDetail] ([quizId], [termId], [key], [value]) VALUES (1, 78, N'Vũng Tàu', N'Bánh khọt là đặc sản của tỉnh:')
INSERT [dbo].[QuizDetail] ([quizId], [termId], [key], [value]) VALUES (1, 79, N'Đồng Tháp', N'Các món ăn về chuột đồng không thể bỏ lỡ khi bạn đến với tỉnh thành nào? ')
INSERT [dbo].[QuizDetail] ([quizId], [termId], [key], [value]) VALUES (1, 80, N'Gỏi lá sầu đâu', N'Châu Đốc, An Giang nổi tiếng với món gỏi nào sao đây?')
INSERT [dbo].[QuizDetail] ([quizId], [termId], [key], [value]) VALUES (1, 81, N'Bình Thuận', N'Món bánh xèo là đặc sản nổi tiếng của địa phương nào dưới đây?')
INSERT [dbo].[QuizDetail] ([quizId], [termId], [key], [value]) VALUES (1, 83, N'Nha Trang', N'Bạn có thể tìm thấy món bún sứa thơm ngon ở vùng nào sau đây?')
INSERT [dbo].[QuizDetail] ([quizId], [termId], [key], [value]) VALUES (1, 84, N'Đắk Nông', N'Cá lăng nướng than là món ăn đặc trưng của vùng nào sau đây?')
INSERT [dbo].[QuizDetail] ([quizId], [termId], [key], [value]) VALUES (1, 85, N'Bún chả cá', N'Nói đến Đà Nẵng thì đặc sản đầu tiên phải kể đến đó chính là:')
INSERT [dbo].[QuizDetail] ([quizId], [termId], [key], [value]) VALUES (1, 86, N'Bánh đa cua', N' Nhắn đến đặc sản đất cảng Hải Phòng, không thể không kể đến món nào dưới đây? ')
INSERT [dbo].[QuizDetail] ([quizId], [termId], [key], [value]) VALUES (1, 87, N'Nam Định', N'Bún đũa là đặc sản của tỉnh:')
INSERT [dbo].[QuizDetail] ([quizId], [termId], [key], [value]) VALUES (1, 88, N'Ninh Bình', N'Cơm cháy là đặc sản nổi tiếng của vùng địa phương nào dưới đây?')
INSERT [dbo].[QuizDetail] ([quizId], [termId], [key], [value]) VALUES (1, 89, N' Bánh bèo', N'Tên gọi của món đặc sản nổi tiếng đất Huế dưới đây là:')
INSERT [dbo].[QuizDetail] ([quizId], [termId], [key], [value]) VALUES (1, 90, N'Thanh Hóa', N' Nem chua là đặc sản của tỉnh nào?')
INSERT [dbo].[QuizDetail] ([quizId], [termId], [key], [value]) VALUES (1, 91, N'Hà Nội', N'Đâu là địa danh nổi tiếng với món phở gà?')
INSERT [dbo].[QuizDetail] ([quizId], [termId], [key], [value]) VALUES (2, 92, N'chuột Mickey', N'Nhân vật hư cấu nào không có tên trên Đại lộ danh vọng Hollywood?')
INSERT [dbo].[QuizDetail] ([quizId], [termId], [key], [value]) VALUES (2, 93, N'Hầm mộ Paris ', N'Hầm mộ chứa hơn 6 triệu bộ hài cốt nằm ở thành phố châu Âu nào?')
INSERT [dbo].[QuizDetail] ([quizId], [termId], [key], [value]) VALUES (2, 94, N'Sơn Đoong', N'Đâu là hang động tự nhiên lớn nhất thế giới?')
INSERT [dbo].[QuizDetail] ([quizId], [termId], [key], [value]) VALUES (2, 95, N'Khánh Hòa', N'Cực Đông của Việt Nam nằm ở tỉnh nào?')
INSERT [dbo].[QuizDetail] ([quizId], [termId], [key], [value]) VALUES (2, 96, N'Putaleng', N'Ngọn núi nào cao thứ hai Việt Nam?')
INSERT [dbo].[QuizDetail] ([quizId], [termId], [key], [value]) VALUES (2, 97, N'Ngưng tụ hào quang', N'Ý nghĩa tên cầu Thê Húc ở hồ Hoàn Kiếm là gì?')
INSERT [dbo].[QuizDetail] ([quizId], [termId], [key], [value]) VALUES (2, 98, N'Đà Lạt', N'Thành phố nào nổi tiếng là nơi du khách có thể trải nghiệm bốn mùa trong một ngày?')
INSERT [dbo].[QuizDetail] ([quizId], [termId], [key], [value]) VALUES (2, 99, N'1999', N'Hội An được UNESCO công nhận là Di sản văn hóa thế giới vào năm nào? ')
INSERT [dbo].[QuizDetail] ([quizId], [termId], [key], [value]) VALUES (2, 100, N'Quảng Ninh', N'Tỉnh nào có nhiều thành phố nhất Việt Nam?')
INSERT [dbo].[QuizDetail] ([quizId], [termId], [key], [value]) VALUES (2, 102, N'Tháp Keangnam Landmark', N'Tòa nhà nào cao nhất Việt Nam? ')
INSERT [dbo].[QuizDetail] ([quizId], [termId], [key], [value]) VALUES (2, 103, N'Hồ Ba Bể, Bắc Kạn', N' Hồ nước tự nhiên nào lớn nhất Việt Nam?')
INSERT [dbo].[QuizDetail] ([quizId], [termId], [key], [value]) VALUES (2, 104, N'Bắc Ninh', N'Tỉnh nào có diện tích nhỏ nhất Việt Nam?')
INSERT [dbo].[QuizDetail] ([quizId], [termId], [key], [value]) VALUES (2, 105, N'A Pa Chải, Điện Biên', N'Nơi được mệnh danh là “một con gà gáy ba nước đều nghe”?')
INSERT [dbo].[QuizDetail] ([quizId], [termId], [key], [value]) VALUES (2, 106, N'Thịt chua', N' Đặc sản nào không phải là của miền Tây Nam Bộ?')
INSERT [dbo].[QuizDetail] ([quizId], [termId], [key], [value]) VALUES (2, 107, N'Điệp Sơn', N'Hòn đảo nào có lối đi giữa biển? ')
GO
INSERT [dbo].[QuizDetail] ([quizId], [termId], [key], [value]) VALUES (2, 108, N'Hải Vân', N'Đèo nào không nằm trong “Tứ đại đỉnh đèo” của Việt Nam?')
SET IDENTITY_INSERT [dbo].[QuizDetail] OFF
GO
INSERT [dbo].[User] ([username], [password], [email], [fullName], [activeCode], [status]) VALUES (N'havusontung007', N'tumotden0', N'havusontung007@gmail.com', N'Hà Vũ Sơn Tùng', NULL, 1)
INSERT [dbo].[User] ([username], [password], [email], [fullName], [activeCode], [status]) VALUES (N'thanhanh', N'BE64CB14DE44253E390706A1EE252CAB', N'giapthanh2000@gmail.com', N'GIAP THANH', NULL, 1)
INSERT [dbo].[User] ([username], [password], [email], [fullName], [activeCode], [status]) VALUES (N'thanhgq', N'thanhgiap', N'thanhgq@gmail.com', N'Giáp Quang Thành', NULL, 1)
INSERT [dbo].[User] ([username], [password], [email], [fullName], [activeCode], [status]) VALUES (N'voodanh', N'A5051876FC4DBCA39DAACE668A502D16', N'voodanh00@gmail.com', N'voo danh', N'w6snxf1g', 1)
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Progress__3F2491B1244E860C]    Script Date: 04/03/2021 14:40:02 ******/
ALTER TABLE [dbo].[Progress] ADD UNIQUE NONCLUSTERED 
(
	[username] ASC,
	[quizId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__User__AB6E61647E44CEEB]    Script Date: 04/03/2021 14:40:02 ******/
ALTER TABLE [dbo].[User] ADD UNIQUE NONCLUSTERED 
(
	[email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Progress] ADD  DEFAULT (getdate()) FOR [lastLearn]
GO
ALTER TABLE [dbo].[Progress] ADD  DEFAULT ((0)) FOR [progress]
GO
ALTER TABLE [dbo].[Quiz] ADD  DEFAULT ((2)) FOR [access]
GO
ALTER TABLE [dbo].[Quiz] ADD  DEFAULT (getdate()) FOR [createdDate]
GO
ALTER TABLE [dbo].[User] ADD  DEFAULT ((0)) FOR [status]
GO
ALTER TABLE [dbo].[Progress]  WITH CHECK ADD FOREIGN KEY([quizId])
REFERENCES [dbo].[Quiz] ([quizId])
GO
ALTER TABLE [dbo].[Progress]  WITH CHECK ADD FOREIGN KEY([username])
REFERENCES [dbo].[User] ([username])
GO
ALTER TABLE [dbo].[Quiz]  WITH CHECK ADD FOREIGN KEY([username])
REFERENCES [dbo].[User] ([username])
GO
ALTER TABLE [dbo].[Quiz]  WITH CHECK ADD FOREIGN KEY([username])
REFERENCES [dbo].[User] ([username])
GO
ALTER TABLE [dbo].[QuizDetail]  WITH CHECK ADD FOREIGN KEY([quizId])
REFERENCES [dbo].[Quiz] ([quizId])
GO
ALTER TABLE [dbo].[QuizDetail]  WITH CHECK ADD FOREIGN KEY([quizId])
REFERENCES [dbo].[Quiz] ([quizId])
GO
/****** Object:  Trigger [dbo].[Update_Progress_Time]    Script Date: 04/03/2021 14:40:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create trigger [dbo].[Update_Progress_Time]
 on [dbo].[Progress]
 after update
 as 
	update Progress 
	set lastLearn = GETDATE()
	where progressld in (select progressld from deleted)
 
GO
ALTER TABLE [dbo].[Progress] ENABLE TRIGGER [Update_Progress_Time]
GO
/****** Object:  Trigger [dbo].[Delete_Quiz]    Script Date: 04/03/2021 14:40:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create trigger [dbo].[Delete_Quiz] on [dbo].[Quiz]
instead of delete
as
	
	delete Progress
	where quizId in (select quizId from deleted)
	delete QuizDetail
	where quizId in (select quizId from deleted)
	delete Quiz
	where quizId in (select quizId from deleted)
GO
ALTER TABLE [dbo].[Quiz] ENABLE TRIGGER [Delete_Quiz]
GO
/****** Object:  Trigger [dbo].[get_quizId]    Script Date: 04/03/2021 14:40:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [dbo].[get_quizId] on [dbo].[Quiz] after insert
As
	Begin

		select quizId from inserted
	End
GO
ALTER TABLE [dbo].[Quiz] ENABLE TRIGGER [get_quizId]
GO
USE [master]
GO
ALTER DATABASE [QuizOnline] SET  READ_WRITE 
GO
